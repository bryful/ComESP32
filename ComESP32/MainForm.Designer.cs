namespace ComEsp32
{
	partial class MainForm
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
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.pxBitBar2 = new ComEsp32.PxBitBar();
			this.pxBitBar1 = new ComEsp32.PxBitBar();
			this.px16BitColorBars1 = new ComEsp32.Px16BitColorBars();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// trackBar1
			// 
			this.trackBar1.AutoSize = false;
			this.trackBar1.LargeChange = 1;
			this.trackBar1.Location = new System.Drawing.Point(312, 225);
			this.trackBar1.Maximum = 31;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(104, 19);
			this.trackBar1.TabIndex = 1;
			this.trackBar1.Value = 12;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(206, 225);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 19);
			this.textBox1.TabIndex = 2;
			// 
			// pxBitBar2
			// 
			this.pxBitBar2.Is6Bit = false;
			this.pxBitBar2.Location = new System.Drawing.Point(137, 46);
			this.pxBitBar2.Name = "pxBitBar2";
			this.pxBitBar2.Size = new System.Drawing.Size(288, 19);
			this.pxBitBar2.TabIndex = 3;
			this.pxBitBar2.Text = "pxBitBar2";
			this.pxBitBar2.Value = ((byte)(0));
			// 
			// pxBitBar1
			// 
			this.pxBitBar1.Is6Bit = false;
			this.pxBitBar1.Location = new System.Drawing.Point(161, 122);
			this.pxBitBar1.Name = "pxBitBar1";
			this.pxBitBar1.Size = new System.Drawing.Size(221, 19);
			this.pxBitBar1.TabIndex = 0;
			this.pxBitBar1.Text = "pxBitBar1";
			this.pxBitBar1.Value = ((byte)(15));
			// 
			// px16BitColorBars1
			// 
			this.px16BitColorBars1.ColorValue = 0;
			this.px16BitColorBars1.Location = new System.Drawing.Point(161, 265);
			this.px16BitColorBars1.MaximumSize = new System.Drawing.Size(348, 80);
			this.px16BitColorBars1.MinimumSize = new System.Drawing.Size(348, 80);
			this.px16BitColorBars1.Name = "px16BitColorBars1";
			this.px16BitColorBars1.Size = new System.Drawing.Size(348, 80);
			this.px16BitColorBars1.TabIndex = 4;
			this.px16BitColorBars1.Text = "px16BitColorBars1";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(633, 349);
			this.Controls.Add(this.px16BitColorBars1);
			this.Controls.Add(this.pxBitBar2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.pxBitBar1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "MainForm";
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private PxBitBar pxBitBar1;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.TextBox textBox1;
		private PxBitBar pxBitBar2;
		private Px16BitColorBars px16BitColorBars1;
	}
}