using System;
using System.IO;
using Gtk;

namespace TuBS
{
	//этот код существует по приципу "работает, и не трогай".
	//Я нашёл его на китайском форуме, он был написан на C++. 
	//Вставил сюда и исправлял пока не заработает.
	static class Comp
	{
		static byte[] buffer;
		static int controlpos, datapos;
		static int readflag = 8;
		static int writeflag = 8;

		private static bool readbit()
		{
			if(readflag == 0)
			{
				controlpos = datapos++;
				readflag = 8;
			}
			readflag--;
			return (buffer[controlpos] & (1 << readflag)) != 0;
		}

		public static void uncompr(string file)
		{
			Console.WriteLine ("File: " + file);
			BinaryReader reader = new BinaryReader (new FileStream (file, FileMode.Open));
			int size = reader.ReadInt32 ();
			reader.ReadInt32 ();
			buffer = new byte[reader.BaseStream.Length - 8];
			byte[] outbuf = new byte[size];
			for(int i = 0; reader.BaseStream.Position < reader.BaseStream.Length; i++)
				buffer[i] = reader.ReadByte (); 
			reader.Close ();

			controlpos = 0;
			datapos = 1;
			readflag = 8;
			int epos = 0;
			while (epos < size) {
				if (readbit ()) //1 uncompressed
					outbuf [epos++] = buffer [datapos++];
				else {
					int len = 0;
					if(readbit()) {
						//01 len from 3 to 9, pos from -1 to -8192
						int t1 = (buffer[datapos] << 8) + buffer[datapos + 1];
						//1111 1111 1001 0         110
						datapos += 2;
						len = t1 & 7;
						t1 >>= 3;
						t1 |= -0x2000;

						//01 len from 1 to 256, pos from -1 to -8192
						if(len != 0)
							len += 2;
						else
							len = buffer[datapos++] + 1;
						for(int i = 0; i < len; ++i) {
							outbuf[epos] = outbuf[epos + t1];
							++epos;
						}
					} else {
						//00xx len from 2 to 6, pos from -1 to -256
						len = Convert.ToInt32(readbit()) * 2 + Convert.ToInt32(readbit()) + 2;
						int tpos = 256 - buffer[datapos++];
						for(int i = 0; i < len; ++i) {
							outbuf[epos] = outbuf[epos - tpos];
							++epos;
						}
					}
				}
			}
			File.WriteAllBytes (file, outbuf);
		}

		private static void writebit (int n)
		{
			if(writeflag == 0)
			{
				controlpos = datapos++;
				writeflag = 8;
			}
			if((n % 2) != 0)
				buffer[controlpos] = (byte)(buffer[controlpos] | (1 << (writeflag-1)));
			writeflag--;

		}

		public static byte[] compr(string input)
		{
			byte[] f1buf = File.ReadAllBytes (input);
			int f1len = f1buf.Length;
			int pos = 0;
			controlpos = 0;
			datapos = 1;
			int b;
			int h;
			int len1 = 0;
			int len = 0;
			int c = 0;
			writeflag = 8;
			buffer = new byte[f1len * 2];

			while (pos < f1len) {
				Main.IterationDo (false);
				c=0;
				len=0;
				for (int i = 0; i < pos && pos <= f1len; i++) {
					if (pos - i >= 0x2000)
						i = pos - 0x2000;
					b = 0;
					h = 0;
					if (f1buf [i] == f1buf [pos]) {
						for (h = 0; f1buf [i + h] == f1buf [pos + h] && (pos + h) < f1len && pos - i <= 0x2000 && b <= 0xff;) {
							b++;
							h++;
							if (i + h == f1buf.Length | pos + h == f1buf.Length)
								break;
						}
					} else
						continue;

					if (b >= len) {
						len = b;
						c = i;
					}
				}
				if(pos>0)
					for(len1 = 0; pos + len1 < f1len && f1buf[pos-1] == f1buf[pos+len1] && len <= 0xff; len1++);
				if(len1>len) {
					len = len1;
					c = pos - 1;
				}
				if(len > 1 && (pos-c) <= 256 && len < 6) {
					writebit(0);
					writebit(0);
					writebit((len-2) / 2);
					writebit(len-2);
					buffer[datapos++]=(byte)((c-pos)&0xff);
					pos+=len;
				} else if(len >= 9) {
					writebit(0);
					writebit(1);
					int a = ((c-pos) << 3) & 0xffff;
					buffer[datapos++] = (byte)(a >> 8);
					buffer[datapos++] = (byte)(a & 0xff);
					buffer [datapos++] = (byte)(len - 1);
					pos += len;

				} else if(len > 2) {
					writebit (0);
					writebit (1);
					int a = ((c - pos) << 3) & 0xffff;
					a = a | (len - 2);
					buffer [datapos++] = (byte)(a >> 8);
					buffer [datapos++] = (byte)(a & 0xff);
					pos+=len;
				} else {
					writebit (1);
					buffer[datapos++]=f1buf[pos++];
				}
			}
			writebit (0);
			writebit (1);
			buffer [datapos++] = 0;
			buffer [datapos++] = 0;
			buffer [datapos++] = 0;
			MemoryStream stream = new MemoryStream ();
			BinaryWriter writer = new BinaryWriter (stream);
			writer.Write(f1len);
			writer.Write(datapos);
			byte[] wbuffer = new byte[datapos];
			for (int i = 0; i < datapos; i++)
				wbuffer [i] = buffer [i];
			writer.Write(wbuffer);
			writer.Flush ();
			writer.Close ();
			return stream.ToArray ();
		}
	}
}

