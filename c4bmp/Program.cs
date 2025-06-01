using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace c4bmp
{



	internal class Program
	{
		static void Usage()
		{
			Console.WriteLine("[c4bmp.exe]");
			Console.WriteLine("Usage: c4bmp <input.png> [paletteFile]");
			Console.WriteLine("Convert 24BitPNG to 4BitBMP.");
			Console.WriteLine("paletteFile: 16色のパレットファイル(テキスト)を指定。");
		}
		static void Main(string[] args)
		{
			BitmapConverter aaa = new BitmapConverter();
			if (args.Length < 1)
			{
				Usage();
				return;
			}
			string op = args[0].ToLower();
			if (op=="-palette")
			{
				aaa.SavePalFile("palette.txt");
				return;
			}
			if (args.Length < 2)
			{
				Console.WriteLine("param eeror!");
				return ;
			}
			string fileName = "";
			string paletteFile = "";
			fileName = args[0];
			paletteFile = args[1];

			if (File.Exists(paletteFile))
			{
				aaa.LoadPalFile(paletteFile);
			}
			else
			{
				Console.WriteLine("palette load error!");
			}
				string d = "";
			try
			{
				d = Path.GetDirectoryName(fileName);
			}
			catch
			{
			}
			if (d=="")
			{
				d = Directory.GetCurrentDirectory();
			}
			string f = Path.GetFileName(fileName);
			if(f.IndexOf("*") >= 0)
			{
				string[] files = Directory.GetFiles(d, f);
				foreach(string s in files)
				{
					Console.WriteLine(s);
					aaa.Exec(s);
				}
			}
			else if (Directory.Exists(fileName))
			{
				string[] files = Directory.GetFiles(fileName, "*.png");
				foreach (string s in files)
				{
					aaa.Exec(s);
					Console.WriteLine(s);
				}

			}
			else if (File.Exists(fileName))
			{
				if (aaa.Exec(fileName))
				{
					Console.WriteLine(fileName);
				}
				else
				{
					Console.WriteLine("error!:" + fileName);
				}
			}
			else
			{
				Usage();
			}
		}
	}
}
