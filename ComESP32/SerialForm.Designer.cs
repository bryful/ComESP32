namespace ComEsp32
{
	partial class SerialForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.tbSend = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.tbRecive = new System.Windows.Forms.TextBox();
			this.BtnGetSkin = new System.Windows.Forms.Button();
			this.BtnSetSkin = new System.Windows.Forms.Button();
			this.cmbPortList = new System.Windows.Forms.ComboBox();
			this.bntPortList = new System.Windows.Forms.Button();
			this.gpSkin = new System.Windows.Forms.GroupBox();
			this.btnClear = new System.Windows.Forms.Button();
			this.gbSend = new System.Windows.Forms.GroupBox();
			this.gpRecived = new System.Windows.Forms.GroupBox();
			this.px16BitColorBars1 = new ComEsp32.Px16BitColorBars();
			this.gpWifi = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSetWifi = new System.Windows.Forms.Button();
			this.tbPASSWORD = new System.Windows.Forms.TextBox();
			this.tbSSID = new System.Windows.Forms.TextBox();
			this.tbHeader = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.gpSkin.SuspendLayout();
			this.gbSend.SuspendLayout();
			this.gpRecived.SuspendLayout();
			this.gpWifi.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbSend
			// 
			this.tbSend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSend.Location = new System.Drawing.Point(0, 43);
			this.tbSend.Multiline = true;
			this.tbSend.Name = "tbSend";
			this.tbSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbSend.Size = new System.Drawing.Size(453, 178);
			this.tbSend.TabIndex = 0;
			// 
			// btnSend
			// 
			this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSend.Enabled = false;
			this.btnSend.Location = new System.Drawing.Point(355, 227);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(98, 23);
			this.btnSend.TabIndex = 1;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// tbRecive
			// 
			this.tbRecive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbRecive.Location = new System.Drawing.Point(6, 18);
			this.tbRecive.Multiline = true;
			this.tbRecive.Name = "tbRecive";
			this.tbRecive.ReadOnly = true;
			this.tbRecive.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbRecive.Size = new System.Drawing.Size(452, 105);
			this.tbRecive.TabIndex = 0;
			// 
			// BtnGetSkin
			// 
			this.BtnGetSkin.Location = new System.Drawing.Point(157, 113);
			this.BtnGetSkin.Name = "BtnGetSkin";
			this.BtnGetSkin.Size = new System.Drawing.Size(130, 23);
			this.BtnGetSkin.TabIndex = 1;
			this.BtnGetSkin.Text = "getSkin";
			this.BtnGetSkin.UseVisualStyleBackColor = true;
			this.BtnGetSkin.Click += new System.EventHandler(this.BtnGetSkin_Click);
			// 
			// BtnSetSkin
			// 
			this.BtnSetSkin.Location = new System.Drawing.Point(21, 113);
			this.BtnSetSkin.Name = "BtnSetSkin";
			this.BtnSetSkin.Size = new System.Drawing.Size(130, 23);
			this.BtnSetSkin.TabIndex = 2;
			this.BtnSetSkin.Text = "setSkin";
			this.BtnSetSkin.UseVisualStyleBackColor = true;
			this.BtnSetSkin.Click += new System.EventHandler(this.BtnSetSkin_Click);
			// 
			// cmbPortList
			// 
			this.cmbPortList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPortList.FormattingEnabled = true;
			this.cmbPortList.Location = new System.Drawing.Point(106, 15);
			this.cmbPortList.Name = "cmbPortList";
			this.cmbPortList.Size = new System.Drawing.Size(152, 20);
			this.cmbPortList.TabIndex = 1;
			// 
			// bntPortList
			// 
			this.bntPortList.Location = new System.Drawing.Point(25, 12);
			this.bntPortList.Name = "bntPortList";
			this.bntPortList.Size = new System.Drawing.Size(75, 23);
			this.bntPortList.TabIndex = 0;
			this.bntPortList.Text = "getPortList";
			this.bntPortList.UseVisualStyleBackColor = true;
			this.bntPortList.Click += new System.EventHandler(this.bntPortList_Click);
			// 
			// gpSkin
			// 
			this.gpSkin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gpSkin.Controls.Add(this.px16BitColorBars1);
			this.gpSkin.Controls.Add(this.BtnGetSkin);
			this.gpSkin.Controls.Add(this.BtnSetSkin);
			this.gpSkin.Enabled = false;
			this.gpSkin.Location = new System.Drawing.Point(490, 21);
			this.gpSkin.Name = "gpSkin";
			this.gpSkin.Size = new System.Drawing.Size(391, 157);
			this.gpSkin.TabIndex = 4;
			this.gpSkin.TabStop = false;
			this.gpSkin.Text = "SkinColor";
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnClear.Location = new System.Drawing.Point(5, 129);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(98, 23);
			this.btnClear.TabIndex = 1;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// gbSend
			// 
			this.gbSend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbSend.Controls.Add(this.label3);
			this.gbSend.Controls.Add(this.tbHeader);
			this.gbSend.Controls.Add(this.tbSend);
			this.gbSend.Controls.Add(this.btnSend);
			this.gbSend.Location = new System.Drawing.Point(12, 46);
			this.gbSend.Name = "gbSend";
			this.gbSend.Size = new System.Drawing.Size(459, 255);
			this.gbSend.TabIndex = 2;
			this.gbSend.TabStop = false;
			this.gbSend.Text = "SendText";
			// 
			// gpRecived
			// 
			this.gpRecived.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gpRecived.Controls.Add(this.tbRecive);
			this.gpRecived.Controls.Add(this.btnClear);
			this.gpRecived.Location = new System.Drawing.Point(7, 307);
			this.gpRecived.Name = "gpRecived";
			this.gpRecived.Size = new System.Drawing.Size(464, 169);
			this.gpRecived.TabIndex = 3;
			this.gpRecived.TabStop = false;
			this.gpRecived.Text = "Recived";
			// 
			// px16BitColorBars1
			// 
			this.px16BitColorBars1.ColorValue = 0;
			this.px16BitColorBars1.Location = new System.Drawing.Point(21, 18);
			this.px16BitColorBars1.MaximumSize = new System.Drawing.Size(348, 80);
			this.px16BitColorBars1.MinimumSize = new System.Drawing.Size(348, 80);
			this.px16BitColorBars1.Name = "px16BitColorBars1";
			this.px16BitColorBars1.Size = new System.Drawing.Size(348, 80);
			this.px16BitColorBars1.TabIndex = 7;
			this.px16BitColorBars1.Text = "px16BitColorBars1";
			this.px16BitColorBars1.Click += new System.EventHandler(this.px16BitColorBars1_Click);
			// 
			// gpWifi
			// 
			this.gpWifi.Controls.Add(this.label2);
			this.gpWifi.Controls.Add(this.label1);
			this.gpWifi.Controls.Add(this.btnSetWifi);
			this.gpWifi.Controls.Add(this.tbPASSWORD);
			this.gpWifi.Controls.Add(this.tbSSID);
			this.gpWifi.Location = new System.Drawing.Point(490, 184);
			this.gpWifi.Name = "gpWifi";
			this.gpWifi.Size = new System.Drawing.Size(151, 127);
			this.gpWifi.TabIndex = 5;
			this.gpWifi.TabStop = false;
			this.gpWifi.Text = "WiFI Setting";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(19, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 12);
			this.label2.TabIndex = 4;
			this.label2.Text = "PASSWORD";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 12);
			this.label1.TabIndex = 3;
			this.label1.Text = "SSID";
			// 
			// btnSetWifi
			// 
			this.btnSetWifi.Location = new System.Drawing.Point(21, 93);
			this.btnSetWifi.Name = "btnSetWifi";
			this.btnSetWifi.Size = new System.Drawing.Size(100, 23);
			this.btnSetWifi.TabIndex = 2;
			this.btnSetWifi.Text = "Set";
			this.btnSetWifi.UseVisualStyleBackColor = true;
			this.btnSetWifi.Click += new System.EventHandler(this.btnWifi_Click);
			// 
			// tbPASSWORD
			// 
			this.tbPASSWORD.Location = new System.Drawing.Point(21, 67);
			this.tbPASSWORD.Name = "tbPASSWORD";
			this.tbPASSWORD.Size = new System.Drawing.Size(100, 19);
			this.tbPASSWORD.TabIndex = 1;
			// 
			// tbSSID
			// 
			this.tbSSID.Location = new System.Drawing.Point(21, 30);
			this.tbSSID.Name = "tbSSID";
			this.tbSSID.Size = new System.Drawing.Size(100, 19);
			this.tbSSID.TabIndex = 0;
			// 
			// tbHeader
			// 
			this.tbHeader.Location = new System.Drawing.Point(70, 18);
			this.tbHeader.Name = "tbHeader";
			this.tbHeader.Size = new System.Drawing.Size(65, 19);
			this.tbHeader.TabIndex = 2;
			this.tbHeader.Text = "text";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(23, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 12);
			this.label3.TabIndex = 3;
			this.label3.Text = "Header";
			// 
			// SerialForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(989, 491);
			this.Controls.Add(this.gpWifi);
			this.Controls.Add(this.gpRecived);
			this.Controls.Add(this.gbSend);
			this.Controls.Add(this.gpSkin);
			this.Controls.Add(this.bntPortList);
			this.Controls.Add(this.cmbPortList);
			this.Name = "SerialForm";
			this.Text = "ESP32 Serial Control";
			this.gpSkin.ResumeLayout(false);
			this.gbSend.ResumeLayout(false);
			this.gbSend.PerformLayout();
			this.gpRecived.ResumeLayout(false);
			this.gpRecived.PerformLayout();
			this.gpWifi.ResumeLayout(false);
			this.gpWifi.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TextBox tbSend;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.TextBox tbRecive;
		private System.Windows.Forms.Button BtnGetSkin;
		private System.Windows.Forms.Button BtnSetSkin;
		private System.Windows.Forms.ComboBox cmbPortList;
		private System.Windows.Forms.Button bntPortList;
		private System.Windows.Forms.GroupBox gpSkin;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.GroupBox gbSend;
		private System.Windows.Forms.GroupBox gpRecived;
		private System.Windows.Forms.GroupBox gpWifi;
		private System.Windows.Forms.Button btnSetWifi;
		private System.Windows.Forms.TextBox tbPASSWORD;
		private System.Windows.Forms.TextBox tbSSID;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private Px16BitColorBars px16BitColorBars1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbHeader;
	}
}

