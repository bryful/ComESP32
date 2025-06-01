using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComEsp32
{
	public partial class SerialForm : Form
	{
		public ComESP32 comesp32 = new ComESP32();
		delegate void SetTextCallback(string text);

		public SerialForm()
		{
			InitializeComponent();
			comesp32.Receved += (sender, e) =>
			{
				if (e.Tag == "text")
				{
					if (tbRecive.InvokeRequired)
					{
						tbRecive.Invoke(new Action(() => tbRecive.AppendText(e.DataString + "\r\n")));
					}
					else
					{
						tbRecive.AppendText(e.DataString + "\r\n");
					}
				}
				else if(e.Tag == "gskn")
				{
					int col = BitConverter.ToInt32( e.Data, 0);
					if (px16BitColorBars1.InvokeRequired)
					{
						px16BitColorBars1.Invoke(new Action(() => px16BitColorBars1.ColorValue = col));
					}
					else
					{
						px16BitColorBars1.ColorValue = col;
					}
				}
				/*
				if((parts.Length >= 2) && (parts[0]=="skin"))
				{
					if (m3StackColorBar1.InvokeRequired)
					{
						m3StackColorBar1.Invoke(new Action(() => m3StackColorBar1.ColorValue = int.Parse(parts[1])));
					}
					else
					{
						m3StackColorBar1.ColorValue = int.Parse(parts[1]);
					}
				}*/
			};
			//ListupPort();
			cmbPortList.SelectedIndexChanged += (sender, e) =>
			{
				btnSend.Enabled = (cmbPortList.SelectedIndex >= 0);
			};
		}
		private void ListupPort()
		{
			cmbPortList.Items.Clear();
			cmbPortList.Items.AddRange(comesp32.ListupPort());
			if(cmbPortList.Items.Count > 0)
			{
				cmbPortList.SelectedIndex = comesp32.PortIndex;
			}
			btnSend.Enabled = (cmbPortList.SelectedIndex >= 0);
			gpSkin.Enabled = (cmbPortList.SelectedIndex >= 0);
		}
		private bool chekPort()
		{
			bool ret = false;
			if (cmbPortList.SelectedIndex < 0) return ret;
			if (comesp32.PortIndex < 0)
			{
				ret =  comesp32.OpenPort(cmbPortList.SelectedIndex);
			}
			else
			{
				if (cmbPortList.SelectedIndex != comesp32.PortIndex)
				{
					comesp32.ClosePort();
					ret = comesp32.OpenPort(cmbPortList.SelectedIndex);
				}
				else
				{
					ret = true;
				}
			}
			return ret;
		}
		private void btnSend_Click(object sender, EventArgs e)
		{
			if(chekPort() == false) return;
			string h = tbSend.Text.Trim();
			if(h.Length != 4) return;
			if(h=="text")
			{
				comesp32.SendTextData("text");
				return;
			}
			else
			{
				byte[] bdata = System.Text.Encoding.UTF8.GetBytes(tbSend.Text + '\0');
				comesp32.SendBinData(h,bdata);
			}
		}

		private void BtnGetSkin_Click(object sender, EventArgs e)
		{
			if (chekPort() == false) return;
			comesp32.GetSkin();

		}


		private void bntPortList_Click(object sender, EventArgs e)
		{
			ListupPort();
		}


		private void btnClear_Click(object sender, EventArgs e)
		{
			tbRecive.Clear();
		}

		private void BtnSetSkin_Click(object sender, EventArgs e)
		{
			if (chekPort() == false) return;
			comesp32.SetSkin(px16BitColorBars1.ColorValue);

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Int32 value = 0x0500FF01;
			byte[] data = BitConverter.GetBytes(value);

			string str = string.Format("{0:X2}{1:X2}{2:X2}{3:X2}", data[0], data[1], data[2], data[3]);
			tbRecive.AppendText(str + "\r\n");
		}

		private void btnWifi_Click(object sender, EventArgs e)
		{
			if (chekPort() == false) return;

			string ss = tbSSID.Text.Trim();
			string pp = tbPASSWORD.Text.Trim();
			if ((ss.Length == 0)||(pp.Length==0)) return;
			comesp32.SendBinData("wifi",ss+","+pp);
		}

		private void px16BitColorBars1_Click(object sender, EventArgs e)
		{

		}
	}
}
