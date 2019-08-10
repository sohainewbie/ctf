using MemeCatBattlestation.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MemeCatBattlestation
{
	public class LogoForm : Form
	{
		private IContainer components;

		private PictureBox pictureBox1;

		private Timer autoCloseTimer;

		public LogoForm()
		{
			this.InitializeComponent();
		}

		private void AutoCloseTimer_Tick(object sender, EventArgs e)
		{
			base.Close();
		}

		private void PictureBox1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new Container();
			this.pictureBox1 = new PictureBox();
			this.autoCloseTimer = new Timer(this.components);
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.pictureBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.pictureBox1.Image = Resources.PhotoFunia_1564436764;
			this.pictureBox1.Location = new Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(1200, 800);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new EventHandler(this.PictureBox1_Click);
			this.autoCloseTimer.Enabled = true;
			this.autoCloseTimer.Interval = 3000;
			this.autoCloseTimer.Tick += new EventHandler(this.AutoCloseTimer_Tick);
			base.AutoScaleDimensions = new SizeF(8f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1200, 800);
			base.Controls.Add(this.pictureBox1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "LogoForm";
			this.Text = "LogoForm";
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}
	}
}
