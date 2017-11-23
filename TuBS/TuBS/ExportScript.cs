using TuBS;
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
	protected List<string> DumpText (FileInfo file, char[] code_page)
	{
		List<string> script = new List<string> ();  
		BinaryReader reader = new BinaryReader ((Stream)new FileStream (file.FullName, FileMode.Open));
		Scene scene = new Scene ();
		string str = "";
		string strsq = "";

		while (reader.BaseStream.Position < reader.BaseStream.Length) {
			ushort num1 = reader.ReadUInt16 ();
			if ((int)num1 < 32768) {//ordinary char from "font" 
				if (code_page.Length > num1)
					str += code_page [num1].ToString ();
				else
					str += "<" + num1.ToString () + ">";
			} else if ((int)num1 == 38147)
				str = str + "<[" + (reader.ReadUInt16 ()).ToString () + "," + (reader.ReadUInt16 ()).ToString () + "," + (reader.ReadUInt16 ()).ToString () + "]";
			else if ((int)num1 == 32769)
				str = str + "●" + "[" + (reader.ReadUInt16 ()).ToString () + "]";
			else if ((int)num1 == 38144)
				str += ">";
			else if ((int)num1 == 33536)
				str += "\r\n";
			else if ((int)num1 == 44544)
				str += "▲";
			else if ((int)num1 == 33024) { // window end
				if (scene.Active == true)
					script.Add ("#" + scene.Window + "; Size: " + scene.GetSize () + "; " + scene.GetActor ());
				script.Add (str);
				script.Add ("-----------------------");
				str = "";
				//info bytes
			} else if ((int)num1 == 35074) {
				str += "■";
				reader.BaseStream.Position -= 2;
				strsq += "[";
				for (int i = 0; i < 6; i++)
					strsq += reader.ReadByte () + ".";
				strsq += "]";
			} else if ((int)num1 == 39168) { //upper window
				scene.Window = "Upper Window";
				str += "■";
				reader.BaseStream.Position -= 2;
				strsq += "[" + reader.ReadByte () + "." + reader.ReadByte () + ".]";
			} else if ((int)num1 == 39424) { //lower window	
				scene.Window = "Lower Window";
				str += "■";
				reader.BaseStream.Position -= 2;
				strsq += "[" + reader.ReadByte () + "." + reader.ReadByte () + ".]";
			} else if ((int)num1 == 2024 || (int)num1 == 33280 || (int)num1 == 39936 || (int)num1 == 47104) { //some strange chars
				str += "■";
				reader.BaseStream.Position -= 2;
				strsq += "[" + reader.ReadByte () + "." + reader.ReadByte () + ".]";
			} else if ((int)num1 == 41985) { //actor tag
				ushort actor_id = reader.ReadUInt16 ();
				scene.SetActor (actor_id);
				str += "■";
				reader.BaseStream.Position -= 4;
				strsq += "[";
				for (int i = 0; i < 4; i++)
					if (reader.BaseStream.Position < reader.BaseStream.Length) {
						strsq += reader.ReadByte () + ".";
					}
				strsq += "]";
			} else if ((int)num1 == 40961) { //window size
				ushort size = reader.ReadUInt16 ();
				scene.SetSize (size);
				str += "■";
				reader.BaseStream.Position -= 4;
				strsq += "[";
				for (int i = 0; i < 4; i++)
					if (reader.BaseStream.Position < reader.BaseStream.Length) {
						strsq += reader.ReadByte () + ".";
					}
				strsq += "]";
			} else { 
				str += "■";
				reader.BaseStream.Position -= 2;
				strsq += "[";
				for (int i = 0; i < 4; i++)
					if (reader.BaseStream.Position < reader.BaseStream.Length) {
						strsq += reader.ReadByte () + ".";
					}
				strsq += "]";
			}
		}
		if (str != "")
			script.Add (str);
		if (strsq != "") {
			StreamWriter sqwriter = new StreamWriter (file.Directory.ToString () + System.IO.Path.DirectorySeparatorChar + "Squares.txt", true);
			sqwriter.WriteLine ("<" + file.Name + ">");
			sqwriter.WriteLine (strsq);
			sqwriter.WriteLine ();
			sqwriter.Flush ();
			sqwriter.Close ();
		}
		reader.Close ();
		return script;
	}

	protected void ScriptMaker (string script_dir, string out_txt)
	{
		StreamWriter writer = new StreamWriter ((Stream)new FileStream (out_txt, FileMode.Create));
		DirectoryInfo info = new DirectoryInfo (script_dir);
		FileInfo[] files = info.GetFiles ().OrderBy (p => p.CreationTime).ToArray ();
		string[] num = script_dir.Split(System.IO.Path.DirectorySeparatorChar);
		char[] code_page;
		if(num.Length == 3)
			code_page = GetCodePage(Int32.Parse(num[1]), num[2]);
		else
			code_page = GetCodePage(Int32.Parse(num[1]));
		int index = 0;
		foreach (FileInfo file in files) {
			index++;
			if (file.Extension == "") {
				List<string> script_list = DumpText (file, code_page);
				string line = "#### File " + index + ": " + file.Name + " ####";
				if (script_list.Count > 0) {
					if (script_list.Count == 1 && script_list [0] == "\r\n")
						continue;
					writer.WriteLine (line);
					for (int index2 = 0; index2 < script_list.Count; ++index2) {
						writer.Write (script_list [index2]);
						writer.WriteLine ();
					}
					writer.WriteLine ("###### End ######");
					writer.WriteLine ();
				}
			}
		}
		writer.Flush ();
		writer.Close ();
	}
}

class Scene 
{
	ushort upper_actor;
	ushort lower_actor;
	ushort upper_size;
	ushort lower_size;
	public string Window = "Lower Window";  //message appears in lower window by default
	public bool Active = false;

	public void SetSize (ushort size)
	{
		if (Window == "Upper Window")
			upper_size = size;
		else
			lower_size = size;
	}

	public string GetSize ()
	{
		if (Window == "Upper Window")
			return upper_size.ToString ();
		return lower_size.ToString ();
	}

	public void SetActor (ushort id)
	{
		Active = true;
		if (Window == "Upper Window")
			upper_actor = id;
		else //"Lower Window"
			lower_actor = id;
	}

	public string GetActor ()
	{
		if (Window == "Upper Window") 
			return Cast.GetActorById (upper_actor);
		return Cast.GetActorById (lower_actor);
	}
}

static class Cast
{
	static string[] actors;
	static Cast ()
	{
		if (File.Exists ("faces.txt"))
			actors = File.ReadAllLines ("faces.txt");
		else
			actors = new string[1568];
	}

	public static string GetActorById (ushort id)
	{
		return actors [id];
	}
}

