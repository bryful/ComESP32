namespace ComEsp32
{
	partial class PortSelectForm1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(13, 13);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(166, 23);
			this.btnRefresh.TabIndex = 1;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(198, 206);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(116, 41);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "Select";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(198, 159);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(116, 41);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(13, 42);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(179, 208);
			this.listBox1.TabIndex = 4;
			// 
			// PortSelectForm1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(326, 259);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnRefresh);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "PortSelectForm1";
			this.Text = "Port Select";
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ListBox listBox1;
	}
}