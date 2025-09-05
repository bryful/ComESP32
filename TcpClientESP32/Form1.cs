
namespace TcpClientESP32
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			btnSend.Click += BtnSend_Click;

		}

		private async void BtnSend_Click(object sender, EventArgs e)
		{
			string ip = tbIP.Text;
			if (!int.TryParse(tbPort.Text, out int port))
			{
				tbRecieved.Text = "�|�[�g�ԍ����s���ł��B";
				return;
			}
			string sText = tbSendText.Text;

			try
			{
				// �ʐM��UI�X���b�h���u���b�N���Ȃ��悤Task�Ŏ��s
				string response = await Task.Run(() =>
				{
					var sender = new Esp32DataSender(ip, port);
					return sender.SendText(sText);
				});
				tbRecieved.Text = response;
			}
			catch (Exception ex)
			{
				tbRecieved.Text = $"���M�G���[: {ex.Message}";
			}
		}
	}
}
