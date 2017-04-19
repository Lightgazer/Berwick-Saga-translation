using System;
using System.IO;
using Gtk;
using GLib;

namespace TuBS
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			GLib.ExceptionManager.UnhandledException += delegate(GLib.UnhandledExceptionArgs  argse)
			{
				var log = new StreamWriter(new FileStream("error.txt", FileMode.OpenOrCreate));
				log.WriteLine(argse.ExceptionObject.ToString());
				log.Flush();
				log.Close();
				argse.ExitApplication = true;
			};
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
