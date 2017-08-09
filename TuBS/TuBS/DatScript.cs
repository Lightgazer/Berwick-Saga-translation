using System;
using System.IO;
using System.Collections.Generic;

namespace TuBS
{
	static class DatScript
	{
		private static byte[] ToCP932 (string str)
		{
			byte[] ret = new byte[str.ToCharArray ().Length * 2 + (4 - (str.ToCharArray ().Length * 2) % 4)]; 
			char[] upper_case = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray ();
			char[] lower_case = "abcdefghijklmnopqrstuvwxyz".ToCharArray ();
			char[] digits = "0123456789".ToCharArray ();
			char[] symbs = " 、。,.・:;?!゛゜'`\"^￣_ヽヾゝゞ〃仝々〆〇ー―-/\\~∥|…‥‘’“”()".ToCharArray (); // starts at 0x8140
			int i = 0;
			foreach (char strch in str) {
				byte j = 0;
				foreach (char codech in upper_case) {
					if (strch == codech) {
						ret [i++] = 0x82;
						ret [i++] = (byte)(0x60 + j);
						goto cont;
					}
					j++;
				}
				j = 0;
				foreach (char codech in lower_case) {
					if (strch == codech) {
						ret [i++] = 0x82;
						ret [i++] = (byte)(0x81 + j);
						goto cont;
					}
					j++;
				}
				j = 0;
				foreach (char codech in digits) {
					if (strch == codech) {
						ret [i++] = 0x82;
						ret [i++] = (byte)(0x4F + j);
						goto cont;
					}
					j++;
				}
				j = 0;
				foreach (char codech in symbs) {
					if (strch == codech) {
						ret [i++] = 0x81;
						ret [i++] = (byte)(0x40 + j);
						goto cont;
					}
					j++;
				}
				byte[] bt = System.Text.Encoding.GetEncoding (932).GetBytes (strch.ToString ());
				ret [i++] = bt [0];
				ret [i++] = bt [1];
				cont:;
			}
			return ret;
		}

		static public void Import (string input_file, string original)
		{
			string tmp = "temp4";
			string[] input = File.ReadAllLines (input_file);
			BinaryReader reader = new BinaryReader (new FileStream (original, FileMode.Open));
			BinaryWriter writer = new BinaryWriter (new FileStream (tmp, FileMode.Create));
			writer.Write (reader.ReadBytes (20)); //copy header
			int field_count = 0;
			foreach (string line in input) {
				if(line.StartsWith("#")) //comment on separate line
					continue;
				int field_num = int.Parse (line.Split ('>') [0]);  
				int field_size;
				while (field_num != field_count) { //copy unchanged fields
					field_size = reader.ReadInt32 ();
					reader.BaseStream.Position -= 4;
					writer.Write (reader.ReadBytes (field_size));
					field_count++;
				}
				field_size = reader.ReadInt32 ();
				int field_type = reader.ReadInt32 ();
				byte[] mail_str = ToCP932 (line.Split ('>') [1]);
				if (field_type == 494) {   //mail string
					writer.Write (mail_str.Length + 40); //field size
					writer.Write (field_type);
					writer.Write (mail_str.Length + 12);
					writer.Write (12);
					writer.Write (mail_str.Length + 12);
					writer.Write (2);
					writer.Write (mail_str.Length);
					writer.Write (mail_str);

					reader.BaseStream.Position += 16;
					int original_len = reader.ReadInt32 ();
					reader.BaseStream.Position += original_len + 12;

					writer.Write (12);
					writer.Write (1);
					writer.Write (0);
				} else if (field_type == 977) {
					writer.Write (mail_str.Length + 72); //field size
					writer.Write (field_type);
					writer.Write (reader.ReadBytes (12));
					writer.Write (mail_str.Length + 12); //alt size
					reader.BaseStream.Position += 4;
					writer.Write (reader.ReadBytes (36));
					writer.Write (mail_str.Length + 12); //same size
					reader.BaseStream.Position += 4;
					writer.Write (reader.ReadInt32 ());
					writer.Write (mail_str.Length);      //string size
					writer.Write (mail_str);             //field body
					int original_len = reader.ReadInt32 ();
					reader.BaseStream.Position += original_len;
				}
				field_count++;
			}
			while (reader.BaseStream.Position < reader.BaseStream.Length)
				writer.Write (reader.ReadInt32 ());
			writer.BaseStream.Position = 0;
			writer.Write ((int)writer.BaseStream.Length);
			writer.BaseStream.Position = 16;
			writer.Write ((int)writer.BaseStream.Length - 20);
			writer.Flush ();
			writer.Close ();
			reader.Close ();
			File.Delete (original);
			File.Move (tmp, original);
		}

		static public void Export (string input, string output)
		{
			List<string> out_list = new List<string> (); 
			BinaryReader reader = new BinaryReader (new FileStream (input, FileMode.Open));
			reader.BaseStream.Position = 20; //first field
			int field_count = 0;
			for (; reader.BaseStream.Position < reader.BaseStream.Length; field_count++) {
				int field_size = reader.ReadInt32 ();
				int field_type = reader.ReadInt32 ();
				if (field_type == 494) {   //mail string
					if (field_size < 9)
						continue; //filter some empty fields
					reader.BaseStream.Position += 16;
					int string_size = reader.ReadInt32 ();
					out_list.Add (field_count.ToString () + ">" + System.Text.Encoding.GetEncoding (932).GetString (reader.ReadBytes (string_size)).Replace ("\0", ""));
					reader.BaseStream.Position += 12;
				} else if (field_type == 977) {
					reader.BaseStream.Position += 60;
					int string_size = reader.ReadInt32 ();
					out_list.Add (field_count.ToString () + ">" + System.Text.Encoding.GetEncoding (932).GetString (reader.ReadBytes (string_size)).Replace ("\0", ""));
				} else
					reader.BaseStream.Position += field_size - 8;
			}
			reader.Close ();
			File.WriteAllLines (output, out_list);
		}
	}
}

