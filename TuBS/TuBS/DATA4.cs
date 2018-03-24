using System;
using System.IO;


static class Data4
{
	public static long[] offset;
	public static int[] size;

	static Data4 ()
	{
		offset = new long[3741];
		size = new int[3741];
		using (BinaryReader reader = new BinaryReader (File.OpenRead(Config.InputIsoPath))) {
			for (int i = 0; i < 3741; i++) {
				reader.BaseStream.Position = 368L + i * 12 + Config.OffsetDATA4;
				reader.ReadUInt32 ();
				offset [i] = (long)(reader.ReadInt32 () * 2048);
				size [i] = reader.ReadInt32 ();
			}
		}
	}

	public static void Flush ()
	{
		using (BinaryWriter writer = new BinaryWriter ((Stream)new FileStream (Config.OutputIsoPath, FileMode.Open, FileAccess.ReadWrite))) {
			writer.BaseStream.Position = 368L + Config.OffsetDATA4;
			for (int i = 0; i < 3741; ++i) {
				writer.BaseStream.Position += 4L;
				writer.Write ((int)offset [i] / 2048);
				writer.Write (size [i]);
			}
			writer.Flush ();
		}
	}
}


