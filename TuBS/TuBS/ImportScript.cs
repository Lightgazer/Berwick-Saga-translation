using System;
using Gtk;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;

public partial class MainWindow : Gtk.Window
{
	protected static ushort FindChar (char ch, char[] code_page, char[] second_code_page)
	{
		ushort ret = FindChar (ch, code_page);
		if (ret == 10000)
			return FindChar (ch, second_code_page);
		return ret;
	}

	protected static ushort FindChar (char ch, char[] code_page)
	{
		if (ch == 32) //space
			return FindChar((char)12288, code_page);

		for (ushort i = 0; i < code_page.Length; i++)
			if (ch == code_page [i])
				return i;
		return 10000;
	}

	protected static byte[] GetSqr (string parent, string name, int index)
	{
		StreamReader sqreader = new StreamReader (new FileStream (System.IO.Path.Combine(parent, "Squares.txt"), FileMode.Open));
		string line;

		while ((line = sqreader.ReadLine ()) != null)
			if (line.Contains ("<" + name + ">"))
				break;
		line = sqreader.ReadLine ();
		sqreader.Close ();

		string[] sliced_line = line.Split ('[');
		string[] bytes = sliced_line [index + 1].Split ('.');
		byte[] ret = new byte[bytes.Length - 1];
		for (int i = 0; i < bytes.Length - 1; i++)
			ret [i] = byte.Parse (bytes [i]);
		return ret;
	}

	protected static bool CheckSq (string script_file)
	{
		bool ret = true;
		string parent;
		if (script_file.Split (System.IO.Path.DirectorySeparatorChar).Length > 1) {
			string[] slice = script_file.Split (System.IO.Path.DirectorySeparatorChar);
			parent = System.IO.Path.Combine("DATA3", slice [0], slice [1].Substring (0, slice [1].Length - 4));
		} else {
			parent = System.IO.Path.Combine ("DATA3", script_file.Split ('.') [0]);
		}

		string scr = File.ReadAllText(System.IO.Path.Combine ("Script", script_file));
		if (!File.Exists (System.IO.Path.Combine (parent, "Squares.txt")))
			return ret;
		string[] sq = File.ReadAllLines(System.IO.Path.Combine (parent, "Squares.txt"));
		string[] scripts = scr.Split (new string[] { "### File " }, StringSplitOptions.RemoveEmptyEntries);
		foreach (var file in scripts) {
			if (file == "#")
				continue;
			var name = file.Split (' ') [1];
			for (int i = 0; i < sq.Length; i++)
				if (sq [i].Contains ("<" + name + ">")) {
					i++;
					string ffile = Regex.Replace (file, "#.*?\r", string.Empty);
					int fcount = ffile.Split ('■').Length;
					int qcount = sq [i].Split ('[').Length;
					if (fcount > qcount) {
						ret = false;
						File.AppendAllText ("error.txt", "\r\nError: " + (fcount-qcount).ToString() + " extra ■ in " + script_file + " File: " + name + "\r\n");
					} else if (fcount < qcount) {
						ret = false;
						File.AppendAllText ("error.txt", "\r\nError: " + (qcount-fcount).ToString() + " missing ■ in " + script_file + " File: " + name + "\r\n");
					}
				}
		}
		return ret;
	}

	Match cir_match;
	Match rgb_match;
	protected List<string> ScriptReader (string script_file) //возвращает список родителей
	{
		List<string> out_list = new List<string> ();  
		if (!CheckSq (script_file))
			return out_list;

		//lets find the parent and encoding
		string parent;
		char[] code_page;
		char[] original_code_page;
		if (script_file.Split (System.IO.Path.DirectorySeparatorChar).Length > 1) {
			string[] slice = script_file.Split (System.IO.Path.DirectorySeparatorChar);
			parent = slice [0];
			code_page = GetCodePage (int.Parse (parent), slice [1].Substring (0, slice [1].Length - 4), "import");
			original_code_page = GetCodePage (int.Parse (parent), slice [1].Substring (0, slice [1].Length - 4));
			parent = System.IO.Path.Combine("DATA3", parent, slice [1].Substring (0, slice [1].Length - 4));
		} else {
			parent = script_file.Split ('.') [0];
			code_page = GetCodePage (int.Parse (parent), "none", "import");
			original_code_page = GetCodePage (int.Parse (parent));
			parent = System.IO.Path.Combine ("DATA3", parent);
		}

		StreamReader script_reader = new StreamReader (new FileStream ("Script" + System.IO.Path.DirectorySeparatorChar + script_file, FileMode.Open));
		Regex rgb_regex = new Regex (@"<\[(\d+),(\d+),(\d+)\]");
		Regex cir_regex = new Regex (@"●\[(\d+)\]");
		string header_pattern = @"####\sFile\s\d+:\s(\w+)\s####";
		string border_pattern = "--------";
		string end_pattern = @"#+\s+End\s+#+";
		bool end_flag;
		int sq_index = 0;


		string cur_line = script_reader.ReadLine ();
		while (cur_line != null) {
			if (!Regex.IsMatch (cur_line, header_pattern)) {
				cur_line = script_reader.ReadLine ();
				continue;
			}
			string file_name = Regex.Replace (cur_line, header_pattern, "$1");
			string full_name = System.IO.Path.Combine (parent, file_name);
			out_list.Add (full_name);
			BinaryWriter writer = new BinaryWriter (new FileStream (full_name, FileMode.Create), Encoding.Default);

			bool cirflag = false;
			bool rgbflag = false;
			end_flag = false;
			sq_index = 0;
			cur_line = script_reader.ReadLine ();
			while (end_flag == false) {
				//cur_line = script_reader.ReadLine ();
				char [] ch = cur_line.ToCharArray ();
				if (ch.Length > 0)
				if (ch [0] == '#') { //comment line
					cur_line = script_reader.ReadLine ();
					continue; 
				}
				for (int i = 0; i < ch.Length; i++) {
					if (ch [i] == '▲')
						writer.Write ((ushort)44544);
					else if (ch [i] == '■') {
						writer.Write (GetSqr (parent, file_name, sq_index));
						sq_index++;
					} else if (ch [i] == '<') {
						i++;
						if (ch [i] == '[') {
							writer.Write ((ushort)38147);
							if (rgbflag == false) {
								rgb_match = rgb_regex.Match (cur_line);
								rgbflag = true;
							} else
								rgb_match = rgb_match.NextMatch ();
							writer.Write (short.Parse (rgb_match.Groups [1].Value));
							writer.Write (short.Parse (rgb_match.Groups [2].Value));
							writer.Write (short.Parse (rgb_match.Groups [3].Value));
							i = rgb_match.Index + rgb_match.Length - 1;
						} else {
							i--;
							writer.Write (FindChar ('<', code_page, original_code_page));
						}
					} else if (ch [i] == '>') {
						writer.Write ((ushort)38144); //9500h
					} else if (ch [i] == '●') {
						i++;
						if (ch [i] == '[') {
							writer.Write ((ushort)32769);
							if (cirflag == false) {
								cir_match = cir_regex.Match (cur_line);
								cirflag = true;
							} else
								cir_match = cir_match.NextMatch ();
							writer.Write (ushort.Parse (cir_match.Groups [1].Value));
							i = cir_match.Index + cir_match.Length - 1;
						} else {
							i--;
							writer.Write (FindChar ('●', code_page, original_code_page));
						}
					} else if (ch [i] == '#') { //comment on the same line
						break;
					} else
						writer.Write (FindChar (ch [i], code_page, original_code_page));
				}
				cirflag = false;
				rgbflag = false;
				cur_line = script_reader.ReadLine ();
				if (Regex.IsMatch (cur_line, border_pattern)) {
					writer.Write ((ushort)33024);
					cur_line = script_reader.ReadLine ();
					if (Regex.IsMatch (cur_line, end_pattern)) {     // это если граница а за ней конец фалйла.
						writer.Flush ();
						writer.Close ();
						end_flag = true;
						cur_line = script_reader.ReadLine ();
					}
				} else if (Regex.IsMatch (cur_line, end_pattern)) {
					writer.Flush ();
					writer.Close ();
					end_flag = true;
					cur_line = script_reader.ReadLine ();
				} else
					writer.Write ((ushort)33536);
			}
		}
		script_reader.Close ();
		return out_list;
	}
}

