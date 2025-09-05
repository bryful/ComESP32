using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComEsp32
{
	public class Px16BitColorBars : Control
	{
		public event EventHandler ColorChanged;

		protected virtual void OnColorChanged(EventArgs e)
		{
			if (ColorChanged != null)
			{
				ColorChanged(this, e);
			}
		}
		private bool refFlag=false;
		private Label lb16Value = new Label();
		private TextBox tb16Value = new TextBox();
		private Button btn16Value = new Button();

		private Label lb24Value = new Label();
		private TextBox tb24Value = new TextBox();
		private Button btn24Value = new Button();

		private PxBitBar numR = new PxBitBar();
		private PxBitBar numG = new PxBitBar();
		private PxBitBar numB = new PxBitBar();
		private int _colWidth = 60;
		private int _NumWidth = 128;

		private int red255 = 0;
		private int green255 = 0;
		private int blue255 = 0;


		public int ColorValue
		{
			get
			{
				return Get16Color();
			}
			set
			{
				Set16Color(value);
			}
		}
		public Color Col
		{
			get { return Color.FromArgb(red255, green255, blue255); }
			set
			{
				Set24Color(value.ToArgb());
			}
		}
		public Px16BitColorBars()
		{
			int w = 288;
			this.Size = new Size(w + _colWidth, 80);
			this.MinimumSize = new Size(w + _colWidth, 80);
			this.MaximumSize = new Size(w + _colWidth, 80);

			int x = _colWidth;
			lb16Value.Text = "16Bit";
			lb16Value.Location = new Point(x, 0);
			lb16Value.AutoSize = false;
			lb16Value.Size = new Size(40, 19);
			lb16Value.TextAlign = ContentAlignment.MiddleRight;
			x += lb16Value.Width;
			tb16Value.Location = new Point(x, 0);
			tb16Value.Size = new Size(50, 19);
			x += tb16Value.Width;
			btn16Value.Location = new Point(x , 0);
			btn16Value.Size = new Size(50, 19);
			btn16Value.Text = "Set";
			x += btn16Value.Width;

			lb24Value.Text = "24Bit";
			lb24Value.Location = new Point(x, 0);
			lb24Value.AutoSize = false;
			lb24Value.Size = new Size(40, 19);
			lb24Value.TextAlign = ContentAlignment.MiddleRight;
			x += lb24Value.Width;

			tb24Value.Location = new Point(x, 0);
			tb24Value.Size = new Size(50, 19);
			x += tb24Value.Width;

			btn24Value.Location = new Point(x, 0);
			btn24Value.Size = new Size(50, 19);
			btn24Value.Text = "Set";


			numR.Location = new Point(_colWidth, 20);
			numR.Size = new Size(288, 19);
			numG.Location = new Point(_colWidth, 40);
			numG.Size = new Size(288, 19);
			numB.Location = new Point(_colWidth, 60);
			numB.Size = new Size(288, 19);

			numR.Text = "R";
			numG.Text = "G";
			numB.Text = "B";
			numR.Is6Bit = false;
			numG.Is6Bit = true;
			numB.Is6Bit = false;

			this.Controls.Add(lb16Value);
			this.Controls.Add(tb16Value);
			this.Controls.Add(btn16Value);
			this.Controls.Add(lb24Value);
			this.Controls.Add(tb24Value);
			this.Controls.Add(btn24Value);
			this.Controls.Add(numR);
			this.Controls.Add(numG);
			this.Controls.Add(numB);
			numR.ValueChanged += (sender, e) =>
			{
				if (refFlag == true) return;
				Calc();
				this.Invalidate();
			};
			numG.ValueChanged += (sender, e) =>
			{
				if (refFlag == true) return;
				Calc();
				this.Invalidate();
			};
			numB.ValueChanged += (sender, e) =>
			{
				if (refFlag == true) return;
				Calc();
				this.Invalidate();
			};
			btn16Value.Click += (sender, e) =>
			{
				if (refFlag == true) return;
				int v =0;
				if(int.TryParse(tb16Value.Text, System.Globalization.NumberStyles.HexNumber, null, out v))
				{
					Set16Color(v);
				}

			};
			btn24Value.Click += (sender, e) =>
			{
				if (refFlag == true) return;
				int v = 0;
				if (int.TryParse(tb24Value.Text, System.Globalization.NumberStyles.HexNumber, null, out v))
				{
					Set24Color(v);
				}

			};
		}
		private string bit24ToStr(int v)
		{
			int r = v >> 16 & 0xFF;
			int g = v >> 8 & 0xFF;
			int b = v >> 0 & 0xFF;
			return $"{r:X02}{g:X02}{b:X02}";
		}
		private string bit24ToStr(int r,int g, int b)
		{
			return $"{r:X02}{g:X02}{b:X02}";
		}
		private void Calc()
		{
			red255 = (int)Math.Round(numR.Value*255.0 /31.0);
			if (red255 <= 0b0111) red255 = 0;
			green255 = (int)Math.Round(numG.Value * 255.0 / 63.0); ;
			if (green255 <= 0b0111) green255 = 0;
			blue255 = (int)Math.Round(numB.Value * 255.0 / 31.0);
			if (blue255 <= 0b0111) blue255 = 0;

			refFlag = true;
			tb16Value.Text = string.Format("{0:X4}", Get16Color());
			tb24Value.Text = bit24ToStr(red255, green255, blue255);
			OnColorChanged(new EventArgs());
			refFlag = false;
		}
		private int Get16Color()
		{
			int r = (int)numR.Value;
			int g = (int)numG.Value;
			int b = (int)numB.Value;
			return (r << 11) | (g << 5) | b;
		}
		private void Set16Color(int v)
		{
			int r = (v >> 11) & 0x1F;
			int g = (v >> 5) & 0x3F;
			int b = v & 0x1F;
			refFlag = true;
			numR.Value = (byte)r;
			numG.Value = (byte)g;
			numB.Value = (byte)b;

			Calc();
			refFlag = false;
			this.Invalidate();
		}
		private void Set24Color(int v)
		{
			int r = (v >> 16 >> 3) & 0x1F;
			int g = (v >> 8 >> 2) & 0x3F;
			int b = (v>>3) & 0x1F;
			refFlag = true;
			numR.Value = (byte)r;
			numG.Value = (byte)g;
			numB.Value = (byte)b;

			Calc();
			refFlag = false;
			this.Invalidate();
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			//Calc();
			Graphics g = e.Graphics;
			Rectangle rect = new Rectangle(0, 0, _colWidth, this.Height);
			using (Brush b = new SolidBrush(Color.FromArgb(red255, green255, blue255)))
			{
				g.FillRectangle(b, rect);
			}
		}
		private void ShowColorDialog()
		{

			using (ColorDialog colorDialog = new ColorDialog())
			{
				colorDialog.AllowFullOpen = true;
				colorDialog.AnyColor = true;
				colorDialog.SolidColorOnly = false;
				colorDialog.FullOpen = true;
				colorDialog.ShowHelp = false;
				Calc();
				colorDialog.Color = Color.FromArgb(red255, green255, blue255);
				if (colorDialog.ShowDialog() == DialogResult.OK)
				{
					refFlag = true;
					numR.Value = (byte)((double)colorDialog.Color.R * 31 / 255 + 0.5);
					numG.Value = (byte)((double)colorDialog.Color.G * 63 / 255 + 0.5);
					numB.Value = (byte)((double)colorDialog.Color.B * 31 / 255+0.5);
					Calc();
					refFlag = false;
					this.Invalidate();
				}

			}

		}
		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);
			if (e.Button == MouseButtons.Left)
			{
				if(e.X < _colWidth)
				{
					ShowColorDialog();
				}
			}
		}
	}
}
