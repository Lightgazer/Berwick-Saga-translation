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
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		string pathdat4 = "DATA4.DAT";
		string pathdat3 = "DATA3.DAT";
		if (!File.Exists (pathdat4))
			progressbar.Text = "Status: " + pathdat4 + " not found";
		if (!File.Exists (pathdat3))
			progressbar.Text = "Status: " + pathdat3 + " not found";
		foreach (string list in Directory.EnumerateFiles(Directory.GetCurrentDirectory (), "list*.txt", SearchOption.TopDirectoryOnly))
			ReadImportList (list);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void UnpackTARC (string file, string child_dir, string out_dir)
	{
		BinaryWriter writer;
		BinaryReader reader = new BinaryReader ((Stream)new FileStream (file, FileMode.Open), Encoding.Default);
		if (1129464148 != reader.ReadInt32 ()) //check TARC or not
			return;
		int num_of_files = reader.ReadInt32 ();
		int offset_to_filelist = reader.ReadInt32 ();
		long list_offset;

		string filename = new FileInfo (file).Name;
		System.IO.Directory.CreateDirectory (out_dir + filename);
		reader.BaseStream.Seek ((long)offset_to_filelist, SeekOrigin.Begin);
		for (int index = 0; index < num_of_files; ++index) {
			string child_name = "";
			for (char buf = reader.ReadChar (); buf != 0; buf = reader.ReadChar ())
				child_name += (object)buf;
			list_offset = reader.BaseStream.Position;
			reader.BaseStream.Seek ((long)(16 + index * 12), SeekOrigin.Begin);
			int offset = reader.ReadInt32 ();
			int size = reader.ReadInt32 ();
			reader.BaseStream.Seek ((long)(offset >> 1), SeekOrigin.Begin);
			byte[] buffer = reader.ReadBytes (size);
			string out_path = out_dir + filename + System.IO.Path.DirectorySeparatorChar + child_name;
			writer = new BinaryWriter ((Stream)new FileStream (out_path, FileMode.Create), Encoding.Default);
			writer.Write (buffer);
			writer.Flush ();
			writer.Close ();
			reader.BaseStream.Seek (list_offset, SeekOrigin.Begin);
			//Decompression
			if (offset % 2 == 1)
				Comp.uncompr (out_path);
		}
		//Move child TARC from out_dir
		string[] child_tarc_files = System.IO.Directory.GetFiles (out_dir + filename, "*.ar");
		if (child_tarc_files.Length != 0) {
			System.IO.Directory.CreateDirectory (child_dir + filename);
			foreach (string tarc in child_tarc_files) {
				string[] tarcname = tarc.Split (System.IO.Path.DirectorySeparatorChar);
				string new_path = child_dir + filename + System.IO.Path.DirectorySeparatorChar + tarcname [2];
				File.Move (tarc, new_path);
			}
		}
	}

	protected void PackDATA (string[] pathed_parents)
	{
		if (pathed_parents.Length == 0)
			return;
		string dat4 = "DATA4.DAT";
		string dat3 = "DATA3.DAT";
		string new_dir = "NEW" + System.IO.Path.DirectorySeparatorChar;
		string newdat4 = new_dir + dat4;
		string newdat3 = new_dir + dat3;
		System.IO.Directory.CreateDirectory (new_dir);
		if (File.Exists (newdat4))
			File.Delete (newdat4);
		if (File.Exists (newdat3))
			File.Delete (newdat3);
		File.Copy (dat4, newdat4);
		BinaryReader reader_dat4 = new BinaryReader ((Stream)new FileStream (dat4, FileMode.Open));
		BinaryReader reader_dat3 = new BinaryReader ((Stream)new FileStream (dat3, FileMode.Open));
		BinaryWriter writer_dat3 = new BinaryWriter ((Stream)new FileStream (newdat3, FileMode.Create));
		BinaryWriter writer_dat4 = new BinaryWriter ((Stream)new FileStream (newdat4, FileMode.Open, FileAccess.ReadWrite));
		writer_dat4.BaseStream.Position = 368L;

		progressbar.Text = "Status: DATA3 rebuilding";
		progressbar.Fraction = 0.6;
		Main.IterationDo (false);

		int[] new_flag = new int[236];
		Array.Sort (pathed_parents, (a, b) => int.Parse (Regex.Replace (a, "[^0-9]", "")) - int.Parse (Regex.Replace (b, "[^0-9]", "")));
		for (int i = 0; i < pathed_parents.Length; i++)
			new_flag [i] = Int32.Parse (pathed_parents [i].Split(System.IO.Path.DirectorySeparatorChar)[1]);

		int path_index = 0;
		int offset_container = 0;
		for (int index = 0; index < 3740; ++index) {
			if (index == new_flag [path_index]) {
				writer_dat4.BaseStream.Position += 4L;
				writer_dat4.Write (offset_container / 2048);
				byte[] buffer1 = File.ReadAllBytes (pathed_parents [path_index]);
				writer_dat3.Write (buffer1);
				byte[] buffer2 = new byte[(2048 - buffer1.Length % 2048) % 2048];
				writer_dat3.Write (buffer2);
				writer_dat4.Write (buffer1.Length);
				offset_container = (int)writer_dat3.BaseStream.Length;
				path_index++;
			} else {
				writer_dat4.BaseStream.Position += 4L;
				reader_dat4.BaseStream.Position = writer_dat4.BaseStream.Position;
				long offset = (long)(reader_dat4.ReadInt32 () * 2048);
				int size = reader_dat4.ReadInt32 ();
				writer_dat4.Write (offset_container / 2048);
				writer_dat4.BaseStream.Position += 4L; 
				reader_dat3.BaseStream.Position = offset;
				writer_dat3.Write (reader_dat3.ReadBytes (size));
				byte[] buffer = new byte[(2048 - size % 2048) % 2048];
				writer_dat3.Write (buffer);
				offset_container = (int)writer_dat3.BaseStream.Length;
			}
			progressbar.Fraction = 0.6 + ((double)offset_container / reader_dat3.BaseStream.Length) * 0.4;
			Main.IterationDo (false);
		}
		writer_dat3.Write (new byte[1073741824L - writer_dat3.BaseStream.Position]);
		reader_dat3.Close ();
		reader_dat4.Close ();
		writer_dat3.Flush ();
		writer_dat4.Flush ();
		writer_dat3.Close ();
		writer_dat4.Close ();
		progressbar.Fraction = 1;
		progressbar.Text = "Status: Done";
	}

	protected void OnUnpackButtonClicked (object sender, EventArgs e)
	{
		int[] files_to_unpack = new int[235] {0, 1, 2, 4, 6, 8, 11, 13, 14, 15, 549, 552, 2256, 2257, 2261, 2263, 2264, 2265, 2266, 2267, 2268, 2269, 2270, 2271,
			2272, 2273, 2274, 2275, 2276, 2277, 2278, 2279, 2283, 2284, 2286, 2288, 2289, 2290, 2291, 2292, 2293, 2294, 2295, 2296, 2297, 2298, 2299, 2300, 2301,
			2302, 2303, 2304, 2305, 2306, 2307, 2308, 2309, 2310, 2311, 2312, 2313, 2314, 2315, 2319, 2320, 2322, 2323, 2325, 2327, 2331, 2333, 2334, 2335, 2337,
			2338, 2340, 2341, 2342, 2344, 2345, 2347, 2348, 2349, 2350, 2351, 2352, 2353, 2354, 2356, 2357, 2358, 2359, 2360, 2361, 2362, 2363, 2364, 2365, 2366,
			2367, 2368, 2369, 2371, 2373, 2375, 2376, 2377, 2378, 2380, 2381, 2382, 2383, 2385, 2386, 2387, 2388, 2389, 2390, 2391, 2392, 2393, 2394, 2398, 2399,
			2400, 2401, 2403, 2404, 2405, 2406, 2408, 2409, 2410, 2411, 2412, 2413, 2419, 2420, 2421, 2423, 2425, 2428, 2435, 2437, 2439, 2440, 2441, 2442, 2443,
			2444, 2445, 2446, 2447, 2449, 2455, 2456, 2457, 2458, 2459, 2460, 2462, 2916, 2919, 2930, 2931, 2932, 2939, 2940, 2962, 3030, 3057, 3058, 3059, //2919 title screen; 2982 eb logo
			3101, 3107, 3117, 3123, 3124, 3133, 3146, 3165, 3188, 3251, 3258, 3297, 3384, 3386, 3389, 3390, 3391, 3393, 3394, 3396, 3397, 3398, 3400, 3401, 3402,
			3404, 3405, 3407, 3408, 3410, 3411, 3413, 3414, 3416, 3417, 3420, 3422, 3424, 3426, 3428, 3431, 3434, 3435, 3437, 3439, 3442, 3445, 3446, 3449, 3451,
			3453, 3456, 3458, 3462, 3467, 3469, 3470, 3471, 3475, 3499, 3504, 3525
		};
		string parent_dir = "pDATA3" + System.IO.Path.DirectorySeparatorChar;
		string child_dir = "cDATA3" + System.IO.Path.DirectorySeparatorChar;
		string out_dir = "DATA3" + System.IO.Path.DirectorySeparatorChar;
		string last_dir = "lDATA3" + System.IO.Path.DirectorySeparatorChar;
		string script_dir = "Script" + System.IO.Path.DirectorySeparatorChar;
		progressbar.Text = "Status: Removing old folders";
		Main.IterationDo (false);
		Main.IterationDo (false);
        if (System.IO.Directory.Exists (parent_dir))
			DeleteDirectory (parent_dir);
		if (System.IO.Directory.Exists (child_dir))
			DeleteDirectory (child_dir);
		if (System.IO.Directory.Exists (out_dir))
			DeleteDirectory (out_dir);
		if (System.IO.Directory.Exists (last_dir))
			DeleteDirectory (last_dir);
        System.IO.Directory.CreateDirectory (parent_dir);
        System.IO.Directory.CreateDirectory (child_dir);
        System.IO.Directory.CreateDirectory (out_dir);
		System.IO.Directory.CreateDirectory (last_dir);
		for (int index = 0; index < files_to_unpack.Length; ++index) {
			progressbar.Text = "Status: " + (object)index + "/" + files_to_unpack.Length + " extraction";
			progressbar.Fraction = (double)(index + 1) / files_to_unpack.Length * 0.2;
			Main.IterationDo (false);
			ExtractTARC (files_to_unpack [index], parent_dir);
		}
		File.Move(parent_dir + "15", out_dir + "15"); //needs special treatment
		File.Move(parent_dir + "2916", out_dir + "2916"); //ttx image

		string[] parent_files = System.IO.Directory.GetFiles (parent_dir);
		for (int index = 0; index < parent_files.Length; ++index) {
			progressbar.Text = "Status: " + (object)index + "/" + parent_files.Length + " child unpacking";
			progressbar.Fraction = 0.2 + ((double)(index + 1) / parent_files.Length * 0.5);
			Main.IterationDo (false);
			UnpackTARC (parent_files [index], child_dir, out_dir);
		}

		string[] child_tarc_dirs = System.IO.Directory.GetDirectories (child_dir);
		for (int index = 0; index < child_tarc_dirs.Length; ++index) {
			progressbar.Text = "Status: " + (object)index + "/" + child_tarc_dirs.Length + " grandchild unpacking";
			progressbar.Fraction = (double)0.7 + ((double)(index + 1) / child_tarc_dirs.Length * 0.2);
			Main.IterationDo (false);
			string sliced_tarc_dir = new FileInfo (child_tarc_dirs [index]).Name;
			string grandchild_dir = out_dir + sliced_tarc_dir + System.IO.Path.DirectorySeparatorChar;
			string lastgen_dir = last_dir + sliced_tarc_dir + System.IO.Path.DirectorySeparatorChar;
			string[] child_tarcs = System.IO.Directory.GetFiles (child_tarc_dirs [index]);
			for (int i = 0; i < child_tarcs.Length; ++i) {
				UnpackTARC (child_tarcs [i], lastgen_dir, grandchild_dir);
			}
		}

		//make script files
		System.IO.Directory.CreateDirectory (script_dir);
		string[] msg_parents = new string [] {"549", "552", "2256", "2257", "2261", "2263", "2264", "2265", "2266", "2267", "2268", "2269", "2270", "2271",
			"2272", "2273", "2274", "2275", "2276", "2277", "2278", "2279", "2283", "2284", "2286", "2288", "2289", "2290", "2291", "2292", "2293", 
			"2294", "2295", "2296", "2297", "2298", "2299", "2300", "2301", "2302", "2303", "2304", "2305", "2306", "2307", "2308", "2309", "2310", 
			"2311", "2312", "2313", "2314", "2315", "2319", "2320", "2322", "2323", "2325", "2327", "2331", "2333", "2334", "2335", "2337", "2338", 
			"2340", "2341", "2342", "2344", "2345", "2347", "2348", "2349", "2350", "2351", "2352", "2353", "2354", "2356", "2357", "2358", "2359",
			"2360", "2361", "2362", "2363", "2364", "2365", "2366", "2367", "2368", "2369", "2371", "2373", "2375", "2376", "2377", "2378", "2380",
			"2381", "2382", "2383", "2385", "2386", "2387", "2388", "2389", "2390", "2391", "2392", "2393", "2394", "2398", "2399", "2400", "2401",
			"2403", "2404", "2405", "2406", "2408", "2409", "2410", "2411", "2412", "2413", "2419", "2420", "2421", "2423", "2425", "2428", "2435",
			"2437", "2439", "2440", "2441", "2442", "2443", "2444", "2445", "2446", "2447", "2449", "2455", "2456", "2457", "2458", "2459", "2460",
			"2462"
		};  //msg
		string[] pack_parents = new string[] {System.IO.Path.Combine("0", "athmap05.ar"),
			System.IO.Path.Combine("1", "athmap04.ar"), System.IO.Path.Combine("2", "athmap01.ar"),
			System.IO.Path.Combine("4", "athmap06.ar"), System.IO.Path.Combine("6", "athmap03.ar"),
			System.IO.Path.Combine("8", "evm0320.ar"),  System.IO.Path.Combine("11", "athmap02.ar"),
			System.IO.Path.Combine("13", "areanml.ar"), System.IO.Path.Combine("13", "evitem.ar"),
			System.IO.Path.Combine("13", "mission.ar"), System.IO.Path.Combine("13", "townarea.ar"),
			System.IO.Path.Combine("14", "evm0050.ar"), System.IO.Path.Combine("14", "guidemsg.ar"),
			System.IO.Path.Combine("14", "helpmsg.ar"), System.IO.Path.Combine("14", "helpmsgb.ar"),
			System.IO.Path.Combine("14", "sysfont.ar"), System.IO.Path.Combine("14", "smenui.ar"),
			System.IO.Path.Combine("14", "namene.ar")
		}; //pack
		for (int index = 0; index < msg_parents.Length; index++) {
			progressbar.Text = "Status: " + (object)index + "/" + msg_parents.Length + " making script from msg";
			progressbar.Fraction = 0.9 + ((double)(index + 1) / msg_parents.Length * 0.06);
			Main.IterationDo (false);
			ScriptMaker (out_dir + msg_parents [index], script_dir + msg_parents [index] + ".msg" + ".txt");
		}
		for (int index = 0; index < pack_parents.Length; index++) {
			progressbar.Text = "Status: " + (object)(index + 1) + "/" + pack_parents.Length + " making script from pack";
			progressbar.Fraction = 0.96 + ((double)(index + 1) / pack_parents.Length * 0.04);
			Main.IterationDo (false);
			Directory.CreateDirectory (System.IO.Path.GetDirectoryName (script_dir + pack_parents [index]));
			ScriptMaker (out_dir + pack_parents [index], script_dir + pack_parents [index] + ".txt");
		}

		progressbar.Text = "Status: Converting images";
		Main.IterationDo (false);
		Main.IterationDo (false);
		ConvertPics ();

		progressbar.Text = "Status: Done";
		progressbar.Fraction = 1;
	}

	protected void OnImportButtonClicked (object sender, EventArgs e)
	{
		FileChooserDialog filechooser = new Gtk.FileChooserDialog ("Choose files to import",
			                                this, FileChooserAction.Open, "Cancel", 
			                                ResponseType.Cancel, "Select", ResponseType.Accept);
		filechooser.SelectMultiple = true;
		if (filechooser.Run () == (int)ResponseType.Accept) {
			import_list.AddRange (filechooser.Filenames);
		}
		filechooser.Destroy ();
		SortImportFiles ();
		PrintImportFiles ();
	}

	protected void OnSaveButtonClicked (object sender, EventArgs e)
	{
		string child_dir = "cDATA3" + System.IO.Path.DirectorySeparatorChar;
		string out_dir = "DATA3" + System.IO.Path.DirectorySeparatorChar;
		string parent_dir = "pDATA3" + System.IO.Path.DirectorySeparatorChar;
		string pic_dir = "Pictures" + System.IO.Path.DirectorySeparatorChar;

		progressbar.Text = "Status: Work";
		Main.IterationDo (false);

		int i = 0;
		foreach (string file in ttx_list) {
			progressbar.Text = "Status: Converting image: " + file;
			i++;
			progressbar.Fraction = ((double)i / ttx_list.Count * 0.50);
			Main.IterationDo (false);
			Main.IterationDo (false);
			string ttx = out_dir + file.Substring (0, file.Length - 4);
			ImageConv.PNGToTTX (pic_dir + file, ttx);
			import_list.Add (ttx);
		}
		SortImportFiles ();
		ttx_list.Clear ();

		i = 0;
		foreach (string file in tb_list) {
			progressbar.Text = "Status: Converting image: " + file;
			i++;
			progressbar.Fraction = 0.5 + ((double)i / tb_list.Count * 0.05);
			Main.IterationDo (false);
			Main.IterationDo (false);
			string screen = out_dir + file.Substring (0, file.Length - 4) + System.IO.Path.DirectorySeparatorChar;
			ImageConv.PNGToTb (pic_dir + file, screen + "000.tp", screen + "000.tb");
			import_list.Add (screen + "000.tb");
		}
		SortImportFiles ();
		tb_list.Clear ();

		progressbar.Text = "Status: Packing files";
		progressbar.Fraction = 0.58;
		Main.IterationDo (false);
		Main.IterationDo (false);
		foreach (string file in script_list) {
			import_list = ScriptReader (file);
			SortImportFiles ();
		}
		script_list.Clear ();

		//here place for lastgen implementation

		foreach (string file in grandchild_list.Distinct ()) {
			string[] sliced_grandchild = file.Split (System.IO.Path.DirectorySeparatorChar);
			string father = child_dir + sliced_grandchild [1] + System.IO.Path.DirectorySeparatorChar + sliced_grandchild [2];
			progressbar.Text = "Status: Packing " + file + " in " + father;
			Main.IterationDo (false);
			Pack (file, father);
			child_list.Add (father);
		}
		grandchild_list.Clear ();

		foreach (string file in child_list.Distinct()) {
			string[] sliced_child = file.Split (System.IO.Path.DirectorySeparatorChar);
			string father = parent_dir + sliced_child [1];
			progressbar.Text = "Status: Packing " + file + " in " + father;
			Main.IterationDo (false);
			Pack (file, father);
			parent_list.Add (father);
		}
		child_list.Clear ();

		PackDATA (parent_list.Distinct ().ToArray ());
		parent_list.Clear ();

		textview.Buffer.Text = "";
		progressbar.Text = "Status: Done";
		progressbar.Fraction = 1;
	}

	protected void OnRefreshButtonClicked (object sender, EventArgs e)
	{
		string pathdat4 = "DATA4.DAT";
		string pathdat3 = "DATA3.DAT";
		if (!File.Exists (pathdat4))
			progressbar.Text = "Status: " + pathdat4 + " not found";
		else if (!File.Exists (pathdat3))
			progressbar.Text = "Status: " + pathdat3 + " not found";
		else 
			progressbar.Text = "Status: Ready";
		import_list.Clear ();
		lastgen_list.Clear ();
		grandchild_list.Clear ();
		child_list.Clear ();
		parent_list.Clear ();
		script_list.Clear ();
		ttx_list.Clear ();
		tb_list.Clear (); 
		foreach (string list in Directory.EnumerateFiles(Directory.GetCurrentDirectory (), "list*.txt", SearchOption.TopDirectoryOnly))
			ReadImportList (list);
	}
}
