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
	public class PxBitBar :Control
	{
		public class valueChangedEventArgs : EventArgs
		{
			public byte Value;
			public valueChangedEventArgs(byte v)
			{
				Value = v;
			}
		}
		public delegate void valueChangedtHandler(object sender, valueChangedEventArgs e);
		public event valueChangedtHandler ValueChanged;


		public void OnValueChanged(valueChangedEventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}
		private bool refFlag = false;
		private Label lb = new Label();
		private NumericUpDown numR = new NumericUpDown();
		private TrackBar bar = new TrackBar();
		private byte _Value = 0x00;
		public byte Value
		{
			get { return _Value; }
			set
			{
				if (_Is6Bit)
				{
					if (value > 63) value = 63;
				}
				else
				{
					if (value > 31) value = 31;
				}
				if (_Value != value)
				{
					refFlag = true;
					_Value = value;
					numR.Value = _Value;
					bar.Value = _Value;
					refFlag = false;
					OnValueChanged(new valueChangedEventArgs(_Value));
				}
			}
		}
		public void SetValue(byte v)
		{
			if (_Is6Bit)
			{
				if (v > 63) v = 63;
			}
			else
			{
				if (v > 31) v = 31;
			}
			if (_Value != v)
			{
				refFlag = true;
				_Value = v;
				numR.Value = _Value;
				bar.Value = _Value;
				refFlag = false;
			}
		}

		private bool _Is6Bit = false;
		public bool Is6Bit
		{
			get { return _Is6Bit; }
			set
			{
				bool b = (value != _Is6Bit);
				if(b)
				{
					if(_Is6Bit==true)
					{
						_Value = (byte)((double)numR.Value *31/63 + 0.5);
						if (_Value > 31) _Value = 31;
					}
					else
					{
						_Value = (byte)((double)numR.Value * 63 / 31+0.5);
						if (_Value > 63) _Value = 63;
					}
				}
				_Is6Bit = value;
				if (_Is6Bit)
				{
					numR.Maximum = 63;
					bar.Maximum = 63;
				}
				else
				{
					numR.Maximum = 31;
					bar.Maximum = 31;
				}
				if (b)
				{
					refFlag = true;
					numR.Value = (decimal)_Value;
					bar.Value = (int)_Value;
				}
			}
		}
		public new String Text
		{
			get { return base.Text; }
			set
			{
				lb.Text = value;
				base.Text = value;
			}
		}
		public PxBitBar()
		{
			base.Text = "R";
			int h = 19;
			int x = 0;
			lb.Location = new Point(0, 0);
			lb.AutoSize = false;
			lb.Size = new Size(12, h);
			lb.TextAlign = ContentAlignment.MiddleRight;
			lb.Text = base.Text;
			x += lb.Size.Width+2;

			numR.Location = new Point(x, 0);
			numR.AutoSize = false;
			numR.Size = new Size(70, h);
			x += numR.Size.Width + 2;

			bar.Location = new Point(x, 0);
			bar.AutoSize = false;
			bar.LargeChange = 1;
			bar.Size = new Size(200, h);
			x += bar.Size.Width + 2;
			this.Size = new Size(x, h);
			Is6Bit = false; // default 6 bit mode is false, 5 bit mode is true
			this.Controls.Add(lb);
			this.Controls.Add(numR);
			this.Controls.Add(bar);
			numR.ValueChanged += NumR_ValueChanged;
			bar.ValueChanged += Bar_ValueChanged;
		}

		private void Bar_ValueChanged(object sender, EventArgs e)
		{
			if (refFlag) return;
			if (_Is6Bit)
			{
				if (bar.Value > 63) bar.Value = 63;
			}
			else
			{
				if (bar.Value > 31) bar.Value = 31;
			}
			_Value = (byte)bar.Value;
			refFlag = true;
			numR.Value = (decimal)_Value;
			refFlag = false;
			OnValueChanged(new valueChangedEventArgs(_Value));
		}

		private void NumR_ValueChanged(object sender, EventArgs e)
		{
			if (refFlag) return;
			if (_Is6Bit)
			{
				if (numR.Value > 63) numR.Value = 63;
			}
			else
			{
				if (numR.Value > 31) numR.Value = 31;
			}
			_Value = (byte)numR.Value;
			refFlag = true;
			bar.Value = (int)_Value;
			refFlag = false;
			OnValueChanged(new valueChangedEventArgs(_Value));
		}

		protected override void OnResize(EventArgs e)
		{
			int h = this.Height - 2;
			lb.Size = new Size(12, h);
			numR.Size = new Size(70, h);
			bar.Size = new Size(this.Width - lb.Width - numR.Width - 4, h);
		}
	}
}
