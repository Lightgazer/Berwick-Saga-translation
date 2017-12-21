using System;
using System.IO;

namespace TuBS
{
	static class Data4
	{
		static string dat4 = "DATA4.DAT";
		static string newdat4 = Path.Combine("NEW", dat4);
		public static long[] offset;
		public static int[] size;

		static Data4 ()
		{
			offset = new long[3741];
			size = new int[3741];
			using (BinaryReader dat4Reader = new BinaryReader (new FileStream (dat4, FileMode.Open))) {
				for (int i = 0; i < 3741; i++) {
					dat4Reader.BaseStream.Position = 368L + i * 12;
					dat4Reader.ReadUInt32 ();
					offset [i] = (long)(dat4Reader.ReadInt32 () * 2048);
					size [i] = dat4Reader.ReadInt32 ();
				}
			}
		}

		public static void Flush ()
		{
			if (File.Exists (newdat4))
				File.Delete (newdat4);
			File.Copy (dat4, newdat4);
			using (BinaryWriter writer = new BinaryWriter ((Stream)new FileStream (newdat4, FileMode.Open, FileAccess.ReadWrite))) {
				writer.BaseStream.Position = 368L;
				for (int i = 0; i < 3741; ++i) {
					writer.BaseStream.Position += 4L;
					writer.Write ((int)offset [i] / 2048);
					writer.Write (size [i]);
				}
				writer.Flush ();
			}
		}
	}
}

