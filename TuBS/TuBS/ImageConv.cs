using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using Gtk;

namespace TuBS
{
	public class ImageConv
	{
		public static void TbToPNG (string image, string pal, string output)
		{
			int width = 512;
			int height = 448;
			PaletteBGRS palette = new PaletteBGRS(pal);

			BinaryReader reader = new BinaryReader (File.OpenRead(image));
			Bitmap bmp = new Bitmap (width, height);
			for (int i = 0; i < bmp.Height; i++)
				for (int j = 0; j < bmp.Width; j++) {
					byte index = reader.ReadByte ();
					bmp.SetPixel (j, i, palette.GetColor(index));
				}
			bmp.Save (output, ImageFormat.Png); 
			reader.Close ();
		}

		public static void PNGToTb (string image, string pal, string output)
		{
			BinaryReader reader = new BinaryReader(File.OpenRead(output));  //uncompress output if compressed
			reader.BaseStream.Position = 0x04;
			if ((long)(reader.ReadInt32 () + 8) == reader.BaseStream.Length) {
				reader.Close ();
				Comp.uncompr (output);
			} else
				reader.Close();

			PaletteBGRS palette = new PaletteBGRS(pal);

			Bitmap bmp = new Bitmap (image);
			BinaryWriter writer = new BinaryWriter ((Stream)new FileStream (output, FileMode.Open));
			for (int i = 0; i < bmp.Height; i++)
				for (int j = 0; j < bmp.Width; j++) 
					writer.Write(palette.GetIndex (bmp.GetPixel (j, i)));

			writer.Flush ();
			writer.Close ();
		}

		public static void TTXToPNG (string input, string output)
		{
			BinaryReader reader = new BinaryReader (File.OpenRead(input));
			if (reader.ReadInt32 () != 811095124) //TTX0
				return;
			reader.ReadInt32 (); //zeros
			int bpp = reader.ReadInt32 (); 
			reader.ReadInt32 (); //image size in bytes
			int width = reader.ReadInt32 ();
			int height = reader.ReadInt32 ();
			int palette_type = reader.ReadInt32 (); //2 - BGR555, 0 - RGBA
			int palette_size = reader.ReadInt32 ();
			reader.BaseStream.Position = 32 + palette_size;

			Bitmap bmp = new Bitmap (width, height);
			if (palette_type == 2) {  //BGR555
				PaletteBGR palette = new PaletteBGR(input);
				for (int i = 0; i < bmp.Height; i++)
					for (int j = 0; j < bmp.Width; j++) {
						byte index = reader.ReadByte ();
						bmp.SetPixel (j, i, palette.GetColor(index));
					}
			} else {  //RGBA
				if (bpp == 0x14) {    //4bpp
					PaletteRGBA4 palette = new PaletteRGBA4(input);
					for (int i = 0; i < bmp.Height; i++)
						for (int j = 0; j < bmp.Width; j++) {
							byte pixel = reader.ReadByte ();
							byte index = (byte)(pixel & 0x0F);
							bmp.SetPixel (j, i, palette.GetColor(index));
							j++;
							index = (byte)(pixel >> 4);
							bmp.SetPixel (j, i, palette.GetColor(index));
						}
				} else if (bpp == 0x13) { //8bpp
					PaletteRGBA8 palette = new PaletteRGBA8(input);
					for (int i = 0; i < bmp.Height; i++)
						for (int j = 0; j < bmp.Width; j++) {
							byte index = reader.ReadByte ();
							bmp.SetPixel (j, i, palette.GetColor(index));
						}
				}
			}
			bmp.Save (output, ImageFormat.Png); 
			reader.Close ();
		}

		public static void PNGToTTX (string input, string output)
		{
			BinaryReader reader = new BinaryReader(File.OpenRead(output));
			reader.BaseStream.Position = 0x04;
			if ((long)(reader.ReadInt32 () + 8) == reader.BaseStream.Length) {
				reader.Close();
				Comp.uncompr (output);
				reader = new BinaryReader(File.OpenRead(output));
				reader.BaseStream.Position = 0x08;
			}
			int bpp = reader.ReadInt32 ();
			reader.BaseStream.Position = 0x18;
			int palette_type = reader.ReadInt32 ();
			int palette_size = reader.ReadInt32 ();
			reader.Close ();

			Console.WriteLine (input);
			Bitmap bmp = new Bitmap (input);
			// 4bpp. Fonts. Without pallete rearrange. RGBA palette
			if (bpp == 0x14) { 
				PaletteRGBA4 palette = new PaletteRGBA4 (output);
				BinaryWriter writer = new BinaryWriter (new FileStream (output, FileMode.Open));
				writer.BaseStream.Position = 32 + palette_size;
				for (int i = 0; i < bmp.Height; i++)
					for (int j = 0; j < bmp.Width; j++) {
						byte ttx_pixel = palette.GetIndex(bmp.GetPixel (j, i));
						j++;
						byte hi_pix = palette.GetIndex(bmp.GetPixel (j, i));
						ttx_pixel += (byte)(hi_pix << 4);
						writer.Write (ttx_pixel);
						Main.IterationDo (false);
					}
				writer.Flush ();
				writer.Close ();
			// 8bpp. Needs palette rearrange. BGR 555 palette.
			} else if (palette_type == 0x02) {
				PaletteBGR palette = new PaletteBGR (output);
				BinaryWriter writer = new BinaryWriter (new FileStream (output, FileMode.Open));
				writer.BaseStream.Position = 32 + palette_size;
				//image writing
				for (int i = 0; i < bmp.Height; i++)
					for (int j = 0; j < bmp.Width; j++) {
						writer.Write (palette.GetIndex (bmp.GetPixel (j, i)));
						Main.IterationDo (false);
					}

				writer.Flush ();
				writer.Close ();
			// 8bpp. Needs palette rearrange. RGBA.
			} else {
				PaletteRGBA8 palette = new PaletteRGBA8 (output);
				BinaryWriter writer = new BinaryWriter ((Stream)new FileStream (output, FileMode.Open));
				writer.BaseStream.Position = 32 + palette_size;
				//image writing
				for (int i = 0; i < bmp.Height; i++)
					for (int j = 0; j < bmp.Width; j++) { //Color pixel = bmp.GetPixel (j, i);
						writer.Write (palette.GetIndex (bmp.GetPixel (j, i)));
						Main.IterationDo (false);
					}

				writer.Flush ();
				writer.Close ();
			}
		}
	}
}

