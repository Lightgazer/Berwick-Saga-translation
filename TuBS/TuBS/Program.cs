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


//ToDo list for 2.0
// 1.лучшее форматирование текста
// 2.new flow of work (prepare(once) -> update images (one time) -> import text (every time))
// 3.хедеры для скриптов (и картинок?)
// 4.кёрнинг и sjis.dat
// 5.самопроверка
// 6.архивы в памяти