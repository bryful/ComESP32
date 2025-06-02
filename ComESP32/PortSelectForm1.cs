using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComEsp32
{
	public partial class PortSelectForm1 : Form
	{
		private SerialPortESP32 esp32_ = null;
		public PortSelectForm1()
		{
			InitializeComponent();
			btnOK.DialogResult = DialogResult.OK;
			btnClose.DialogResult = DialogResult.Cancel;
			listBox1.SelectedIndexChanged += (sender, e) =>
			{
				btnOK.Enabled = (listBox1.SelectedIndex >= 0);
			};
			btnOK.Enabled = (listBox1.SelectedIndex >= 0);
		}
		public bool ShowDialog(SerialPortESP32 esp32)
		{
			esp32_ = esp32;
			GetPortList();
			 if (ShowDialog() == DialogResult.OK)
			{
				esp32_.PortIndex = listBox1.SelectedIndex;
				return true;
			}
			else
			{
				return false;
			}
		}
		public void GetPortList()
		{
			listBox1.Items.AddRange(esp32_.ListupPort());
			listBox1.SelectedIndex = esp32_.PortIndex;
		}
	}
}
