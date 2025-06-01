using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;
namespace c4palette
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			openMenu.Click += (s, e) => OpenDlg();
			saveMenu.Click += (s, e) => SaveDlg();
			copyMenu.Click += (s, e) => paletteCanvas1.Copy();
			pasteMenu.Click += (s, e) => paletteCanvas1.Paste();
			importPngMenu.Click += (s, e) => ImportPng();
			exportPngMenu.Click += (s, e) => ExportPng();
			btnOpen.Click += (s, e) => OpenPreview();

			previewPanel1.MouseClick += PreviewPanel1_MouseClick;
			paletteFrom4BirBmpMenu.Click += (s, e) => PaletteFrom4BitBmp();
			export16bitPaletteMenu.Click += (s, e) => SaveDlg16bit();
		}

		private void PreviewPanel1_MouseClick(object sender, MouseEventArgs e)
		{
			if(cbSpoit.Checked==false) return;
			if (paletteCanvas1.SelectedIndex>=0)
			{
				Color c = previewPanel1.Color;
				if (c != Color.Empty)
				{
					paletteCanvas1.SetColor(paletteCanvas1.SelectedIndex, c);
					paletteCanvas1.Invalidate();
				}

			}
		}

		private string _PalFileName = "";
		private string _BmpFileName = "";
		private string _PngFileName = "";
		private string _PreviewFileName = "";
		private string _BaseDir = "";
		public void OpenDlg()
		{
			using (var dlg = new OpenFileDialog())
			{
				{
					dlg.Filter = "Palette File (*.pal)|*.pal|All files (*.*)|*.*";

					if(_BaseDir != "")
					{
						dlg.InitialDirectory = _BaseDir;
					}
					if (_PalFileName != "")
					{
						dlg.FileName = _PalFileName;
					}
					else
					{
						dlg.FileName = "palette.pal";
					}
					dlg.DefaultExt = ".pal";
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						paletteCanvas1.LoadPalFile(dlg.FileName);
						_PalFileName = Path.GetFileName(dlg.FileName);
						_BaseDir = Path.GetDirectoryName(dlg.FileName);
					}
				}
			}
		}
		public void SaveDlg()
		{
			using (var dlg = new SaveFileDialog())
			{

				dlg.Filter = "Palette File (*.pal)|*.pal|All files (*.*)|*.*";
				if (_BaseDir != "")
				{
					dlg.InitialDirectory = _BaseDir;
				}
				if (_PalFileName != "")
				{
					dlg.FileName = Path.ChangeExtension(_PalFileName, ".pal");
				}
				else
				{
					dlg.FileName = "palette.pal";
				}
				dlg.DefaultExt = ".pal";
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					paletteCanvas1.SavePalFile(dlg.FileName);
					_PalFileName = Path.GetFileName(dlg.FileName);
					_BaseDir = Path.GetDirectoryName(dlg.FileName);
				}
			}

		}
		public void ImportPng()
		{
					using (var dlg = new OpenFileDialog())
			{
				dlg.Filter = "PNG File (*.png)|*.png|All files (*.*)|*.*";
				if (_BaseDir != "")
				{
					dlg.InitialDirectory = _BaseDir;
				}
				if (_PngFileName != "")
				{
					dlg.FileName = _PngFileName;
			}else
			{
				dlg.FileName = "palette.png";
			}
			dlg.DefaultExt = ".png";
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					paletteCanvas1.LoadPict(dlg.FileName);
					_PalFileName = Path.GetFileName(dlg.FileName);
					_BaseDir = Path.GetDirectoryName(dlg.FileName);
				}
			}
		}
		public void ExportPng()
		{
			using (var dlg = new SaveFileDialog())
			{
				dlg.Filter = "PNG File (*.png)|*.png|All files (*.*)|*.*";
				if (_BaseDir != "")
				{
					dlg.InitialDirectory = _BaseDir;
				}
				if (_PngFileName != "")
				{
					dlg.FileName = _PngFileName;
				}else
				{
					dlg.FileName = "palette.png";
				}
				dlg.DefaultExt = ".png";
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					paletteCanvas1.SavePict(dlg.FileName);
					_PngFileName = Path.GetFileName(dlg.FileName);
					_BaseDir = Path.GetDirectoryName(dlg.FileName);
				}
			}
		}
		public void SaveDlg16bit()
		{
			using (var dlg = new SaveFileDialog())
			{

				dlg.Filter = "Palette File (*.pal16bit)|*.pal16bit|All files (*.*)|*.*";
				if (_BaseDir != "")
				{
					dlg.InitialDirectory = _BaseDir;
				}
				if (_PalFileName != "")
				{
					dlg.FileName = Path.ChangeExtension(_PalFileName, ".pal16bit");
				}
				else
				{
					dlg.FileName = "palette.pal16bit";
				}
				dlg.DefaultExt = ".pal16bit";
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					paletteCanvas1.SavePalFile(dlg.FileName,true);
					_PalFileName = Path.GetFileName(dlg.FileName);
					_BaseDir = Path.GetDirectoryName(dlg.FileName);
				}
			}

		}
		public static Color[] Read4BitBmpPalette(string filePath)
		{
			using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
			using (var reader = new BinaryReader(fs))
			{
				// BITMAPFILEHEADER (14 bytes)
				ushort bfType = reader.ReadUInt16(); // "BM" = 0x4D42
				if (bfType != 0x4D42)
					throw new InvalidDataException("Not a BMP file.");

				reader.BaseStream.Seek(10, SeekOrigin.Begin);
				uint bfOffBits = reader.ReadUInt32();

				// BITMAPINFOHEADER (starts at offset 14, total 40 bytes)
				reader.BaseStream.Seek(14, SeekOrigin.Begin);
				uint biSize = reader.ReadUInt32();
				int biWidth = reader.ReadInt32();
				int biHeight = reader.ReadInt32();
				ushort biPlanes = reader.ReadUInt16();
				ushort biBitCount = reader.ReadUInt16();

				if (biBitCount != 4)
					throw new InvalidDataException("Not a 4-bit BMP file.");

				// パレット読み出し
				const int colorCount = 16;
				Color[] palette = new Color[colorCount];
				for (int i = 0; i < colorCount; i++)
				{
					byte b = reader.ReadByte();
					byte g = reader.ReadByte();
					byte r = reader.ReadByte();
					byte reserved = reader.ReadByte(); // usually 0
					palette[i] = Color.FromArgb(255, r, g, b); // ARGB
				}

				return palette;
			}
		}
		public void PaletteFrom4BitBmp()
		{
			using (var dlg = new OpenFileDialog())
			{
				dlg.Filter = "BMP File (*.bmp)|*.bmp|All files (*.*)|*.*";
				if (_BaseDir != "")
				{
					dlg.InitialDirectory = _BaseDir;
				}
				if (_PngFileName != "")
				{
					dlg.FileName = _BmpFileName;
				}
				else
				{
					dlg.FileName = "palette.bmp";
				}
				dlg.DefaultExt = ".bmp";
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					paletteCanvas1.Load4BitBmpPalette(dlg.FileName);
					_BmpFileName = Path.GetFileName(dlg.FileName);
					_BaseDir = Path.GetDirectoryName(dlg.FileName);
				}
			}
		}
		public void OpenPreview()
		{
			using (var dlg = new OpenFileDialog())
			{
				dlg.Filter = "PNG File (*.png)|*.png|All files (*.*)|*.*";
				if (_BaseDir != "")
				{
					dlg.InitialDirectory = _BaseDir;
				}
				if (_PreviewFileName != "")
				{
					dlg.FileName = _PreviewFileName;
				}
				else
				{
					dlg.FileName = "preview.png";
				}
				dlg.DefaultExt = ".png";
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					previewPanel1.LoadPngFile(dlg.FileName);
					_PreviewFileName = Path.GetFileName(dlg.FileName);
					_BaseDir = Path.GetDirectoryName(dlg.FileName);
				}
			}
		}
		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}

