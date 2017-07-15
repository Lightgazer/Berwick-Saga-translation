using System;
using Gtk;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using TuBS;

public partial class MainWindow : Gtk.Window
{
	protected void ConvertPics ()
	{ 
		string out_dir = "DATA3" + System.IO.Path.DirectorySeparatorChar;
		string pic_dir = "Pictures";
		string[] fonts = Directory.GetFiles(out_dir, "font*.ttx", SearchOption.AllDirectories);
		foreach (string font in fonts) {
			string[] slice = font.Split (new string[] { "DATA3" }, StringSplitOptions.None);  
			string outpath = pic_dir + slice[slice.Length - 1] + ".png";
			Directory.CreateDirectory (System.IO.Path.GetDirectoryName (outpath));
			ImageConv.TTXToPNG (font, outpath);
		}

		string[] pics = new string[] {System.IO.Path.Combine ("DATA3", "13", "icon07.ar", "tex.ttx"), 
			System.IO.Path.Combine ("DATA3", "13", "misswp.ar", "kabe123.ttx"),
			System.IO.Path.Combine ("DATA3", "13", "misswp.ar", "kabe124.ttx"),
			System.IO.Path.Combine ("DATA3", "13", "misswp2.ar", "kabe130.ttx"),
			System.IO.Path.Combine ("DATA3", "13", "qitemwp.ar", "kabe131.ttx"),
			System.IO.Path.Combine ("DATA3", "13", "qlistwp.ar", "kabe125.ttx"),
			System.IO.Path.Combine ("DATA3", "13", "qlistwp.ar", "kabe126.ttx"),
			System.IO.Path.Combine ("DATA3", "2919", "title.ttx"),
			System.IO.Path.Combine ("DATA3", "2930", "kabe120.ttx"),
			System.IO.Path.Combine ("DATA3", "2931", "kabe125.ttx"),
			System.IO.Path.Combine ("DATA3", "2931", "kabe126.ttx"),
			System.IO.Path.Combine ("DATA3", "2932", "kabe131.ttx"),
			System.IO.Path.Combine ("DATA3", "2939", "kabe130.ttx"),
			System.IO.Path.Combine ("DATA3", "2940", "kabe123.ttx"),
			System.IO.Path.Combine ("DATA3", "2940", "kabe124.ttx"),
			System.IO.Path.Combine ("DATA3", "2962", "icon02.ar", "tex.ttx"),
			System.IO.Path.Combine ("DATA3", "2962", "icon03.ar", "tex.ttx"),
			System.IO.Path.Combine ("DATA3", "2962", "icon04.ar", "tex.ttx"),
			System.IO.Path.Combine ("DATA3", "2962", "icon05.ar", "tex.ttx"),
			System.IO.Path.Combine ("DATA3", "2962", "icon07.ar", "tex.ttx"),
			System.IO.Path.Combine ("DATA3", "2962", "iconwp10.ar", "tex.ttx"),
			System.IO.Path.Combine ("DATA3", "2962", "iconwp11.ar", "tex.ttx"),
			System.IO.Path.Combine ("DATA3", "2962", "iconwp13.ar", "tex.ttx"),
			System.IO.Path.Combine ("DATA3", "2962", "iconwp15.ar", "tex.ttx"),
			System.IO.Path.Combine ("DATA3", "2962", "iconwp17.ar", "tex.ttx"),
			System.IO.Path.Combine ("DATA3", "2916")
		};
		foreach (string pic in pics) {
			string[] slice = pic.Split (new string[] { "DATA3" }, StringSplitOptions.None);  
			string outpath = pic_dir + slice[slice.Length - 1] + ".png";
			Directory.CreateDirectory (System.IO.Path.GetDirectoryName (outpath));
			ImageConv.TTXToPNG (pic, outpath);
		}

		string[] screens = new string[] {"3057", "3058", "3059", "3101", "3107", "3117", "3123", "3124", "3133", "3146",
			"3165", "3188", "3251", "3258", "3297" 
		};
		foreach (string screen in screens) {
			ImageConv.TbToPNG(System.IO.Path.Combine(out_dir, screen, "000.tb"), System.IO.Path.Combine(out_dir, screen, "000.tp"), System.IO.Path.Combine(pic_dir, screen + ".png"));
		}
	}

	List<string> import_list = new List<string> ();
	List<string> lastgen_list = new List<string> ();
	List<string> grandchild_list = new List<string> ();
	List<string> child_list = new List<string> ();
	List<string> parent_list = new List<string> ();
	List<string> script_list = new List<string> ();
	List<string> ttx_list = new List<string> (); 
	List<string> tb_list = new List<string> (); 

	protected void SortImportFiles ()
	{
		string[] files_to_import = import_list.ToArray ();

		foreach (string file in files_to_import) {
			string[] sliced_path;
			FileInfo fileinfo = new FileInfo (file);
			if (fileinfo.Extension == ".txt") {
				sliced_path = file.Split (new string[] { "Script" + System.IO.Path.DirectorySeparatorChar }, StringSplitOptions.None); 
				script_list.Add (sliced_path [sliced_path.Length - 1]);
				continue;
			}
			if (fileinfo.Extension == ".png") {
				sliced_path = file.Split (new string[] { "Pictures" + System.IO.Path.DirectorySeparatorChar }, StringSplitOptions.None);
				if(Int32.Parse(sliced_path [sliced_path.Length - 1].Split(System.IO.Path.DirectorySeparatorChar)[0].Split('.')[0]) < 3057)
					ttx_list.Add (sliced_path [sliced_path.Length - 1]);
				else 
					tb_list.Add (sliced_path [sliced_path.Length - 1]);
				continue;
			}
			sliced_path = file.Split (new string[] { "DATA3" }, StringSplitOptions.None); //помни, ты делишь строкой
			string[] sliced_file = sliced_path [sliced_path.Length - 1].Split (System.IO.Path.DirectorySeparatorChar);
			if (sliced_file.Length == 5)  //its lastgen 
				lastgen_list.Add ("DATA3" + System.IO.Path.DirectorySeparatorChar + sliced_file [1] + System.IO.Path.DirectorySeparatorChar + sliced_file [2] +
					System.IO.Path.DirectorySeparatorChar + sliced_file [3] + System.IO.Path.DirectorySeparatorChar + sliced_file [4]);
			if (sliced_file.Length == 4) //its grandchild
				grandchild_list.Add ("DATA3" + System.IO.Path.DirectorySeparatorChar + sliced_file [1] + System.IO.Path.DirectorySeparatorChar + sliced_file [2] +
					System.IO.Path.DirectorySeparatorChar + sliced_file [3]);
			if (sliced_file.Length == 3) //its child
				child_list.Add ("DATA3" + System.IO.Path.DirectorySeparatorChar + sliced_file [1] + System.IO.Path.DirectorySeparatorChar + sliced_file [2]);
			if (sliced_file.Length == 2) //parent 
				parent_list.Add ("DATA3" + System.IO.Path.DirectorySeparatorChar + sliced_file [1]);	
		}
		import_list.Clear ();
	}

	protected void PrintImportFiles ()
	{
		textview.Buffer.Text = "";
		foreach(string item in import_list)
			textview.Buffer.Text += item + "\n";
		foreach(string item in script_list)
			textview.Buffer.Text += "Script: " + item + "\n";
		foreach(string item in ttx_list)
			textview.Buffer.Text += "Picture (TTX): " + item + "\n";
		foreach(string item in tb_list)
			textview.Buffer.Text += "Picture (Tb): " + item + "\n";
		foreach(string item in grandchild_list)
			textview.Buffer.Text += item + "\n";
		foreach(string item in child_list)
			textview.Buffer.Text += item + "\n";
		foreach(string item in parent_list)
			textview.Buffer.Text += item + "\n";
	}

	protected void  ReadImportList (string list)
	{
		StreamReader reader = new StreamReader (new FileStream (list, FileMode.Open));
		string item = reader.ReadLine ();
		while (item != null) {
			import_list.Add (item);
			item = reader.ReadLine ();
		}
		SortImportFiles ();
		PrintImportFiles ();
		reader.Close ();
	}

	public static void DeleteDirectory (string target_dir)
	{
		string[] files = Directory.GetFiles (target_dir);
		string[] dirs = Directory.GetDirectories (target_dir);

		foreach (string file in files) {
			File.SetAttributes (file, FileAttributes.Normal);
			File.Delete (file);
		}

		foreach (string dir in dirs) {
			DeleteDirectory (dir);
		}

		Directory.Delete (target_dir, false);
	}

	protected void ExtractTARC (int tarc_numb, string dir)
	{
		string dat4 = "DATA4.DAT";
		string dat3 = "DATA3.DAT";

		BinaryReader dat4Reader = new BinaryReader ((Stream)new FileStream (dat4, FileMode.Open));
		dat4Reader.BaseStream.Position = 368L + tarc_numb * 12;
		dat4Reader.ReadUInt32 ();
		string filename = tarc_numb.ToString ();
		long offset = (long)(dat4Reader.ReadInt32 () * 2048);
		int size = dat4Reader.ReadInt32 ();
		dat4Reader.Close ();

		BinaryReader dat3Reader = new BinaryReader ((Stream)new FileStream (dat3, FileMode.Open));
		BinaryWriter writer = new BinaryWriter ((Stream)new FileStream (dir + filename, FileMode.Create), Encoding.Default);
		dat3Reader.BaseStream.Position = offset;
		byte[] buffer = dat3Reader.ReadBytes (size);
		writer.Write (buffer);
		writer.Flush ();
		writer.Close ();
		dat3Reader.Close ();
	}

	protected void Pack (string child, string father)
	{
		int filelist_size = 0;
		//first read file list in father
		string[] child_names = new string[8911];
		BinaryReader father_reader = new BinaryReader ((Stream)new FileStream (father, FileMode.Open), Encoding.Default);
		if (1129464148 != father_reader.ReadInt32 ()) //check TARC or not
			return;
		int num_of_files = father_reader.ReadInt32 ();
		int offset_to_filelist = father_reader.ReadInt32 ();
		father_reader.BaseStream.Seek ((long)offset_to_filelist, SeekOrigin.Begin);
		for (int index = 0; index < num_of_files; ++index) {
			child_names [index] = "";
			for (char buf = father_reader.ReadChar (); buf != 0; buf = father_reader.ReadChar ())
				child_names [index] += (object)buf;
			filelist_size += child_names [index].Length + 1;
		}
		//next check our child
		int child_num = -1;
		string name = new FileInfo (child).Name;
		for (int i = 0; i < num_of_files; i++)
			if (name == child_names [i]) //so its our child
				child_num = i;
		if (child_num == -1)
			return;
		//lets pack
		string tmp = "temp";
		string tmp2 = "temp2";
		BinaryWriter writer = new BinaryWriter ((Stream)new FileStream (tmp, FileMode.Create));
		BinaryReader child_reader = new BinaryReader ((Stream)new FileStream (child, FileMode.Open), Encoding.Default);

		father_reader.BaseStream.Position = 0L;
		writer.Write (father_reader.ReadBytes (16 + 12 * num_of_files));

		for (int index = 0; index < num_of_files; ++index) {
			father_reader.BaseStream.Position = 16 + 12 * index;
			int offset = father_reader.ReadInt32 ();
			int size = father_reader.ReadInt32 ();
			int protect = (int)offset % 2;
			if (child_num == index) {
				int compress_flag = 0;
				if (child_reader.BaseStream.Length > 8L) {
					child_reader.BaseStream.Position = 4L;
					if ((long)(child_reader.ReadInt32 () + 8) == child_reader.BaseStream.Length)
						compress_flag = 1;
				}
				long length = child_reader.BaseStream.Length;
				child_reader.Close ();
				byte[] buffer;
				if (protect == 1 && compress_flag == 0) { //if needs compression
					Comp.compr (child, tmp2);
					buffer = File.ReadAllBytes (tmp2);
					File.Delete (tmp2);
					if (length < (long)buffer.Length) {
						buffer = File.ReadAllBytes (child);
						compress_flag = 0;
					} else
						compress_flag = 1;
				} else
					buffer = File.ReadAllBytes (child);
				writer.BaseStream.Position = (long)(16 + 12 * index);
				writer.Write ((int)writer.BaseStream.Length << 1 | compress_flag); //????
				writer.Write (buffer.Length);
				writer.BaseStream.Position = writer.BaseStream.Length;
				writer.Write (buffer);
			} else {
				writer.BaseStream.Position = (long)(16 + 12 * index);
				writer.Write ((int)writer.BaseStream.Length << 1 | protect);
				writer.BaseStream.Position = writer.BaseStream.Length;
				father_reader.BaseStream.Position = offset >> 1;
				writer.Write (father_reader.ReadBytes (size));
			}
		}
		//next write new file list
		writer.BaseStream.Position = 8L;
		writer.Write ((int)writer.BaseStream.Length);
		writer.BaseStream.Position = writer.BaseStream.Length;
		father_reader.BaseStream.Position = 8L;
		offset_to_filelist = father_reader.ReadInt32 ();
		father_reader.BaseStream.Position = (long)offset_to_filelist;
		writer.Write (father_reader.ReadBytes (filelist_size));
		writer.Flush ();
		writer.Close ();
		father_reader.Close ();
		File.Delete (father);
		File.Move (tmp, father);
	}
}

