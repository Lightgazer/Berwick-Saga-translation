using System;
using System.IO;
using System.Text.RegularExpressions;

static class Config
{
	static string input_iso;
	static string output_iso;
	static string slps;
	static bool copy;
	public static string InputIsoPath {
		get {
			return  input_iso;
		}
	}
	public static string OutputIsoPath {
		get {
			return  output_iso;
		}
	}
	public static string SlpsPath {
		get {
			return  slps;
		}
	}
	public static bool Copy {
		get {
			return  copy;
		}
	}
	public static long OffsetDATA3 {
		get {
			return  3221794816;
		}
	}
	public static long OffsetDATA4 {
		get {
			return  4295536640;
		}
	}
	public static long OffsetSLPS {
		get {
			return  4296202240;
		}
	}

	static Config ()
	{
		Refresh ();
	}

	public static void Refresh ()
	{
		string[] config_file = File.ReadAllLines ("config.txt");
		foreach (string line in config_file) {
			string[] conf = Regex.Replace (line, "#.*?\r", string.Empty).Split (new char[] {'='}, 2);
			if (conf [0] == "Input Iso")
				input_iso = conf [1];
			else if (conf [0] == "Output Iso")
				output_iso = conf [1];
			else if (conf [0] == "ELF")
				slps = conf [1];
		}
		if (input_iso == output_iso)
			copy = false;
		else
			copy = true;
	}
}


