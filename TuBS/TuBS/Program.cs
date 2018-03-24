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
				File.AppendAllText("error.txt", argse.ExceptionObject.ToString());
				argse.ExitApplication = true;
			};
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}