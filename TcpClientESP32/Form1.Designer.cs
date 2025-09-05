namespace TcpClientESP32
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			tbIP = new TextBox();
			tbPort = new TextBox();
			tbSendText = new TextBox();
			tbRecieved = new TextBox();
			btnSend = new Button();
			SuspendLayout();
			// 
			// tbIP
			// 
			tbIP.Location = new Point(62, 12);
			tbIP.Name = "tbIP";
			tbIP.Size = new Size(140, 23);
			tbIP.TabIndex = 0;
			tbIP.Text = "192.168.10.61";
			// 
			// tbPort
			// 
			tbPort.Location = new Point(62, 41);
			tbPort.Name = "tbPort";
			tbPort.Size = new Size(140, 23);
			tbPort.TabIndex = 1;
			tbPort.Text = "12345";
			// 
			// tbSendText
			// 
			tbSendText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbSendText.Location = new Point(12, 70);
			tbSendText.Multiline = true;
			tbSendText.Name = "tbSendText";
			tbSendText.ScrollBars = ScrollBars.Both;
			tbSendText.Size = new Size(685, 228);
			tbSendText.TabIndex = 2;
			tbSendText.Text = "{\"cmd\":\"status\",\"data\":\"aaa\"}";
			// 
			// tbRecieved
			// 
			tbRecieved.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			tbRecieved.Location = new Point(12, 304);
			tbRecieved.Multiline = true;
			tbRecieved.Name = "tbRecieved";
			tbRecieved.ScrollBars = ScrollBars.Both;
			tbRecieved.Size = new Size(685, 134);
			tbRecieved.TabIndex = 3;
			// 
			// btnSend
			// 
			btnSend.Location = new Point(598, 41);
			btnSend.Name = "btnSend";
			btnSend.Size = new Size(75, 23);
			btnSend.TabIndex = 4;
			btnSend.Text = "Send";
			btnSend.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(709, 450);
			Controls.Add(btnSend);
			Controls.Add(tbRecieved);
			Controls.Add(tbSendText);
			Controls.Add(tbPort);
			Controls.Add(tbIP);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox tbIP;
		private TextBox tbPort;
		private TextBox tbSendText;
		private TextBox tbRecieved;
		private Button btnSend;
	}
}
