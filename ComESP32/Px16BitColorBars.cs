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
		private bool refFlag=false;
		private Label lbValue = new Label();
		private TextBox tbValue = new TextBox();
		private Button btnValue = new Button();
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
				return M3Color();
			}
			set
			{
				SetM3Color(value);
			}
		}
		public Px16BitColorBars()
		{
			int w = 288;
			this.Size = new Size(w + _colWidth, 80);
			this.MinimumSize = new Size(w + _colWidth, 80);
			this.MaximumSize = new Size(w + _colWidth, 80);

			lbValue.Text = "16Bit";
			lbValue.Location = new Point(_colWidth, 0);
			lbValue.AutoSize = false;
			lbValue.Size = new Size(86, 19);
			lbValue.TextAlign = ContentAlignment.MiddleRight;

			tbValue.Location = new Point(_colWidth + 86, 0);
			tbValue.Size = new Size(100, 19);

			btnValue.Location = new Point(_colWidth + 186, 0);
			btnValue.Size = new Size(80, 19);
			btnValue.Text = "Set";

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

			this.Controls.Add(lbValue);
			this.Controls.Add(tbValue);
			this.Controls.Add(btnValue);
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
			btnValue.Click += (sender, e) =>
			{
				if (refFlag == true) return;
				int v =0;
				if(int.TryParse(tbValue.Text, System.Globalization.NumberStyles.HexNumber, null, out v))
				{
					SetM3Color(v);
				}

			};
		}
		private void Calc()
		{
			red255 = (int)((double)numR.Value * 255 / 31+0.5);
			green255 = (int)((double)numG.Value * 255 / 63+0.5);
			blue255 = (int)((double)numB.Value * 255 / 31 + 0.5);

			refFlag = true;
			tbValue.Text = string.Format("{0:X4}", M3Color());
			refFlag = false;
		}
		private int M3Color()
		{
			int r = (int)numR.Value;
			int g = (int)numG.Value;
			int b = (int)numB.Value;
			return (r << 11) | (g << 5) | b;
		}
		private void SetM3Color(int v)
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
