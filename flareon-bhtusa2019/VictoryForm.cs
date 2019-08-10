using MemeCatBattlestation.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MemeCatBattlestation
{
	public class VictoryForm : Form
	{
		public string Arsenal;

		private IContainer components;

		private Label flagLabel;

		public VictoryForm()
		{
			this.InitializeComponent();
		}

		private void VictoryForm_Load(object sender, EventArgs e)
		{
			byte[] data = new byte[]
			{
				74,
				240,
				181,
				167,
				229,
				232,
				186,
				112,
				186,
				234,
				154,
				75,
				116,
				154,
				71,
				235,
				31,
				132,
				41,
				179,
				119,
				137,
				199,
				167,
				215,
				148,
				25,
				196,
				152,
				253,
				227
			};
			byte[] bytes = BattleCatManagerInstance.InitializeBattleCat(Encoding.UTF8.GetBytes(this.Arsenal), data);
			this.flagLabel.Text = Encoding.UTF8.GetString(bytes);
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
			this.flagLabel = new Label();
			base.SuspendLayout();
			this.flagLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.flagLabel.BackColor = Color.Transparent;
			this.flagLabel.Font = new Font("Rockwell Extra Bold", 32f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.flagLabel.ForeColor = Color.FromArgb(255, 255, 192);
			this.flagLabel.Location = new Point(0, 598);
			this.flagLabel.Name = "flagLabel";
			this.flagLabel.Size = new Size(1181, 161);
			this.flagLabel.TabIndex = 0;
			this.flagLabel.Text = "EXAMPLE_KEY@flare-on.com";
			this.flagLabel.TextAlign = ContentAlignment.MiddleCenter;
			this.flagLabel.UseWaitCursor = true;
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackgroundImage = Resources.victory;
			this.BackgroundImageLayout = ImageLayout.Stretch;
			base.ClientSize = new Size(1182, 753);
			base.Controls.Add(this.flagLabel);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.Name = "VictoryForm";
			base.StartPosition = FormStartPosition.Manual;
			this.Text = "Memecat Battlestation - You have success win";
			base.UseWaitCursor = true;
			base.Load += new EventHandler(this.VictoryForm_Load);
			base.ResumeLayout(false);
		}
	}
}
