﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace c4palette
{
	public class PaletteCanvas : Control
	{
		private ComEsp32.Px16BitColorBars _px16cb = null;
		public ComEsp32.Px16BitColorBars px16cb
		{
			get { return _px16cb; }
			set
			{
				_px16cb = value;
				if (value != null)
				{
					if(_SelectedIndex>=0)
						px16cb.Col = _paletteColors[_SelectedIndex];
					_px16cb.ColorChanged += (sender, e) =>
					{
						if (_SelectedIndex >= 0)
						{
							_paletteColors[_SelectedIndex] = _px16cb.Col;
							this.Invalidate();
						}

					};
				}
			}
		}

		private Color[] _paletteColors = new Color[16]
		{
			Color.FromArgb(0xff,0x00,0x00,0xff),
			Color.FromArgb(0xff,0xe1,0xa9,0x90),
			Color.FromArgb(0xff,0x00,0x00,0x00),
			Color.FromArgb(0xff,0x30,0x30,0x30),
			Color.FromArgb(0xff,0x4d,0x4d,0x4d),
			Color.FromArgb(0xff,0x5d,0x03,0x03),
			Color.FromArgb(0xff,0x68,0x0a,0x0a),
			Color.FromArgb(0xff,0xa1,0x29,0x29),
			Color.FromArgb(0xff,0xcd,0x42,0x42),
			Color.FromArgb(0xff,0xe4,0x4e,0x4e),
			Color.FromArgb(0xff,0xeb,0x7c,0x7c),
			Color.FromArgb(0xff,0xef,0x54,0x54),
			Color.FromArgb(0xff,0xc8,0xc8,0xc8),
			Color.FromArgb(0xff,0xf1,0xb2,0xfe),
			Color.FromArgb(0xff,0xfe,0xc4,0xc4),
			Color.FromArgb(0xff,0xFF,0xFF,0xFF),
		};
		private Size baseSize = new Size(32	, 32);	
		private int _SelectedIndex = -1;
		public int SelectedIndex
		{
			get { return _SelectedIndex; }
		}
		private int _DispHeight = 20;
		private Button _btnR = new Button();
		private Button _btnL = new Button();
		public PaletteCanvas()
		{

			this.Size = new Size(baseSize.Width*16+4,baseSize.Height+ _DispHeight+4);
			this.MinimumSize =this.Size;
			this.MaximumSize = this.Size;

			_btnL.Text = "<<";
			_btnL.Size = new Size(baseSize.Width * 2, _DispHeight - 1);
			_btnL.Location = new Point(baseSize.Width * 12, 0);
			_btnL.Enabled = false;
			_btnR.Text = ">>";
			_btnR.Size = new Size(baseSize.Width * 2, _DispHeight - 1);
			_btnR.Location = new Point(baseSize.Width * 14, 0);
			_btnR.Enabled = false;
			this.Controls.Add(_btnL);
			this.Controls.Add(_btnR);
			this.SetStyle(
ControlStyles.UserMouse |
ControlStyles.DoubleBuffer |
ControlStyles.UserPaint |
ControlStyles.AllPaintingInWmPaint ,
true);
			DoubleBuffered = true;

			_btnL.Click += (s, e) =>
			{
				PalLeft();
			};
			_btnR.Click += (s, e) =>
			{
				PalRight();
			};
			ChkPalette();
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics g = e.Graphics;
			g.Clear(base.BackColor);
			Rectangle rect = new Rectangle(0, _DispHeight, baseSize.Width, baseSize.Height);
			using(SolidBrush brush = new SolidBrush(Color.FromArgb(0xFF, 0xFF, 0xFF)))
			using(StringFormat sf = new StringFormat())
			using (Pen p = new Pen(ForeColor))
			{
				sf.Alignment = StringAlignment.Center;
				sf.LineAlignment = StringAlignment.Center;
				for (int i = 0; i < 16; i++)
				{
					rect.X = i * baseSize.Width;
					brush.Color = _paletteColors[i];
					g.FillRectangle(brush, rect);
					if (_SelectedIndex == i)
					{
						Rectangle selRect = new Rectangle(rect.X, rect.Y, rect.Width - 2, rect.Height - 2);
						p.Color = Color.Black;
						g.DrawRectangle(p, selRect);
						selRect = new Rectangle(rect.X+1, rect.Y+1, rect.Width - 4, rect.Height - 4);
						p.Color = Color.White;
						g.DrawRectangle(p, selRect);
					}
					brush.Color = _paletteColors[15-i];
					g.DrawString($"{i}", this.Font, brush, rect, sf);
				}
			}
		}
		private string ColotrToHex24(Color c)
		{
			int r = c.R;
			int g = c.G;
			int b = c.B;
			r = r | 0b00000111;
			if (r == 0b111) r = 0;
			g = g | 0b00000011;
			if (g == 0b11) g = 0;
			b = b | 0b00000111;
			if (b == 0b111) b = 0;

			return string.Format("{0:X2}{1:X2}{2:X2}", r,g,b);
		}
		private string ColotrToHex16(Color c)
		{
			int r = c.R;
			int g = c.G;
			int b = c.B;
			r = (r >> 3) & 0b011111;
			g = (g >> 2) & 0b111111;
			b = (b >> 3) & 0b011111;

			return string.Format("{0:X2}{1:X2}{2:X2}", r, g, b);
		}
		private Color HexToColotr24(string s)
		{
			s = s.Trim();
			if (s.Length < 6) return Color.Empty;
			if (s[1]=='#') s = s.Substring(1);
			if (s.Length < 6) return Color.Empty;
			try
			{
				int r = Convert.ToInt32(s.Substring(0, 2), 16);
				int g = Convert.ToInt32(s.Substring(2, 2), 16);
				int b = Convert.ToInt32(s.Substring(4, 2), 16);
				r = r | 0b00000111;
				if (r == 0b111) r = 0;
				g = g | 0b00000011;
				if (g == 0b11) g = 0;
				b = b | 0b00000111;
				if (b == 0b111) b = 0;
				return Color.FromArgb(0xFF, r, g, b);
			}
			catch
			{
				return Color.Empty;
			}
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			//_SelectedIndex = -1;
			if (e.Button == MouseButtons.Left)
			{
				if (e.Y >= _DispHeight)
				{
					int index = e.X / baseSize.Width;

					if (index >= 0 && index < 16)
					{
						if(_SelectedIndex != index)
						{
							_SelectedIndex = index;
							Color c = _paletteColors[_SelectedIndex];
							if(px16cb!=null)
							{
								px16cb.Col = c;
							}
							_btnL.Enabled = (_SelectedIndex > 0);
							_btnR.Enabled = (_SelectedIndex < 15);
							this.Invalidate();
						}
					}
				}
			}
			base.OnMouseDown(e);
		}
		protected override void OnDoubleClick(EventArgs e)
		{
					if (_SelectedIndex >= 0 && _SelectedIndex < 16)
					{
						ColorDlg();
					}
		}

		private void PalRight()
		{
			if ((_SelectedIndex >=0) &&(_SelectedIndex < 15))
			{
				Color color = _paletteColors[_SelectedIndex];
				_paletteColors[_SelectedIndex] = _paletteColors[_SelectedIndex + 1];
				_paletteColors[_SelectedIndex + 1] = color;
				_SelectedIndex++;
				if (_SelectedIndex > 15) _SelectedIndex = 15;
				_btnL.Enabled = (_SelectedIndex > 0);
				_btnR.Enabled = (_SelectedIndex < 15);
				this.Invalidate();
			}
		}
		private void PalLeft()
		{
			if ((_SelectedIndex >0) && (_SelectedIndex < 16))
			{
				Color color = _paletteColors[_SelectedIndex];
				_paletteColors[_SelectedIndex] = _paletteColors[_SelectedIndex - 1];
				_paletteColors[_SelectedIndex - 1] = color;
				_SelectedIndex--;
				if(_SelectedIndex < 0) _SelectedIndex = 0;
				_btnL.Enabled = (_SelectedIndex > 0);
				_btnR.Enabled = (_SelectedIndex < 15);
				this.Invalidate();
			}
		}
		public bool LoadPalFile(string s)
		{
			bool ret = false;

			if (File.Exists(s))
			{
				string str = File.ReadAllText(s);
				string[] lines = str.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				if (lines.Length >= 16)
				{
					Color[] pals = new Color[16];
					for (int i = 0; i < 16; i++)
					{
						string line = lines[i].Trim();
						int cc = Convert.ToInt32(line, 16);
						pals[i] = Color.FromArgb(0xFF, (cc >> 16) & 0xFF, (cc >> 8) & 0xFF, cc & 0xFF);
					}
					_paletteColors = pals;
					ChkPalette();

					ret = true;
				}
				else
				{
					ret = false;
				}
			}
			return ret;
		}
		public bool SavePalFile(string s,bool is16bit =false)
		{
			bool ret = false;
			string str = string.Empty;
			ChkPalette();
			foreach (Color c in _paletteColors)
			{
				if (str != "")
				{
					str += ",\r\n";
				}
				if (is16bit)
				{
					int v = (c.R >> 3) << 11 | (c.G >> 2) << 5 | c.B >> 3;
					str += string.Format("0x{0:X}", v);
				}
				else
				{
					str += string.Format("{0:X2}{1:X2}{2:X2}", c.R, c.G, c.B);

				}			
			}
			if (File.Exists(s))
			{
				File.Delete(s);
			}
			str = str.TrimEnd(',');
			if(is16bit)
			{
				str = "u_int16_t palette[16]={\r\n" + str + "};\r\n";
			}
			File.WriteAllText(s, str);

			return ret;
		}
		private void ChkPalette()
		{
			int idx;
			for (idx = 0; idx < _paletteColors.Length; idx++)
			{
				Color c = _paletteColors[idx];
				int r = c.R;
				int g = c.G;
				int b = c.B;
				r = r | 0b00000111;
				if (r == 0b111) r = 0;
				g = g | 0b00000011;
				if (g == 0b11) g = 0;
				b = b | 0b00000111;
				if (b == 0b111) b = 0;
				_paletteColors[idx] = Color.FromArgb(0xFF, r, g, b);
			}
		}
		private int[] CustomColors = new int[0];
		void ColorDlg()
		{
			if (_SelectedIndex < 0 || _SelectedIndex > 15) return;
			using (ColorDialog dlg = new ColorDialog())
			{
				dlg.AllowFullOpen = true;
				dlg.ShowHelp = true;
				dlg.AnyColor = true;
				dlg.SolidColorOnly = false;
				dlg.FullOpen = true;
				dlg.Color = _paletteColors[_SelectedIndex];
				if(CustomColors.Length > 0)
				{
					dlg.CustomColors = CustomColors;
				}
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					_paletteColors[_SelectedIndex] = dlg.Color;
					if(px16cb!=null)
					{
						px16cb.Col= _paletteColors[_SelectedIndex];
					}
					ChkPalette();
					this.Invalidate();
				}
				if (dlg.CustomColors.Length > 0)
				{
					CustomColors = dlg.CustomColors;
					for (int i = 0; i < CustomColors.Length; i++)
					{
						CustomColors[i] = ColorTranslator.ToWin32(Color.FromArgb(CustomColors[i]));
					}
				}
			}
		}
		public void Copy()
		{
			if (_SelectedIndex >= 0 && _SelectedIndex < 16)
			{
				Clipboard.SetText(ColotrToHex24(_paletteColors[_SelectedIndex]));
			}
		}
		public void Paste()
		{
			if (_SelectedIndex >= 0 && _SelectedIndex < 16)
			{
				string s = Clipboard.GetText();
				try
				{
					Color c = HexToColotr24(s);
					if (c != Color.Empty)
					{
						_paletteColors[_SelectedIndex] = c;
						this.Invalidate();
					}
				}
				catch
				{

				}
			}
		}

		public void SavePict(string s)
		{
			Bitmap bitmap = new Bitmap(baseSize.Width * 16, baseSize.Height);
			using (Graphics g = Graphics.FromImage(bitmap))
			{
				Rectangle rect = new Rectangle(0, 0, baseSize.Width, baseSize.Height);
				using (SolidBrush brush = new SolidBrush(Color.FromArgb(0xFF, 0xFF, 0xFF)))
				using (Pen p = new Pen(ForeColor))
				{
					for (int i = 0; i < 16; i++)
					{
						rect.X = i * baseSize.Width;
						brush.Color = _paletteColors[i];
						g.FillRectangle(brush, rect);
					}
				}
			}
			bitmap.Save(s, System.Drawing.Imaging.ImageFormat.Png);

		}
		public void LoadPict(string s)
		{
			if (File.Exists(s))
			{
				Bitmap bitmap = new Bitmap(s);
				for (int i = 0; i < 16; i++)
				{
					int x = i * baseSize.Width + baseSize.Width/2;
					int y = 0 + baseSize.Height/2;
					Color c = bitmap.GetPixel(x, y);
					_paletteColors[i] = c;
				}
				this.Invalidate();
			}
		}
		public void SetColor(int idx , Color c)
		{
			if (idx >= 0 && idx < 16)
			{
				_paletteColors[idx] = c;
				this.Invalidate();
			}
		}
		private  Color[] Read4BitBmpPalette(string filePath)
		{
			using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
			using (var reader = new BinaryReader(fs))
			{
				// BITMAPFILEHEADER (14 bytes)
				ushort bfType = reader.ReadUInt16(); // "BM" = 0x4D42
				if (bfType != 0x4D42)
					throw new InvalidDataException("Not a BMP file.");

				// bfSize, bfReserved1, bfReserved2
				reader.ReadUInt32();
				reader.ReadUInt16();
				reader.ReadUInt16();

				uint bfOffBits = reader.ReadUInt32();

				// BITMAPINFOHEADER (40 bytes)
				uint biSize = reader.ReadUInt32();
				int biWidth = reader.ReadInt32();
				int biHeight = reader.ReadInt32();
				ushort biPlanes = reader.ReadUInt16();
				ushort biBitCount = reader.ReadUInt16();

				if (biBitCount != 4)
					throw new InvalidDataException("Not a 4-bit BMP file.");

				// biCompression, biSizeImage, biXPelsPerMeter, biYPelsPerMeter, biClrUsed, biClrImportant
				reader.ReadUInt32(); // biCompression
				reader.ReadUInt32(); // biSizeImage
				reader.ReadInt32();  // biXPelsPerMeter
				reader.ReadInt32();  // biYPelsPerMeter
				uint biClrUsed = reader.ReadUInt32();
				reader.ReadUInt32(); // biClrImportant

				// パレットの色数を決定
				int colorCount = (int)(biClrUsed != 0 ? biClrUsed : 16);

				// パレットの先頭にシーク
				long paletteOffset = 14 + biSize;
				reader.BaseStream.Seek(paletteOffset, SeekOrigin.Begin);

				Color[] palette = new Color[16];
				for (int i = 0; i < 16; i++)
				{
					byte b = reader.ReadByte();
					byte g = reader.ReadByte();
					byte r = reader.ReadByte();
					byte reserved = reader.ReadByte();
					palette[i] = Color.FromArgb(255, r, g, b);
				}

				return palette;
			}
		}
		public  bool Load4BitBmpPalette(string filePath)
		{
			try
			{
				Color[] palette = Read4BitBmpPalette(filePath);
				if (palette.Length == 16)
				{
					_paletteColors = palette;
					ChkPalette();
					this.Invalidate();
					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error loading palette: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return false;
		}
	}

}
