using MemeCatBattlestation.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MemeCatBattlestation
{
	public class Stage1Form : Form
	{
		private int victoryTicks;

		public string WeaponCode;

		private IContainer components;

		private PictureBox playerPictureBox;

		private PictureBox enemyPictureBox;

		private PictureBox stageLabelPictureBox;

		private TextBox codeTextBox;

		private Label armingCodeLabel;

		private Button fireButton;

		private Timer enemyEntryTimer;

		private Label invalidWeaponLabel;

		private Timer victoryAnimationTimer;

		private PictureBox laserBeamPictureBox;

		private PictureBox explosionPictureBox;

		public Stage1Form()
		{
			this.InitializeComponent();
		}

		private void Timer1_Tick(object sender, EventArgs e)
		{
			if (this.enemyPictureBox.Location.X < 50)
			{
				this.enemyPictureBox.Location = new Point(this.enemyPictureBox.Location.X + 10, this.enemyPictureBox.Location.Y);
				return;
			}
			this.enemyEntryTimer.Enabled = false;
		}

		private void CodeTextBox_TextChanged(object sender, EventArgs e)
		{
			if (this.codeTextBox.Text != "")
			{
				this.fireButton.Enabled = true;
				return;
			}
			this.fireButton.Enabled = false;
		}

		private void FireButton_Click(object sender, EventArgs e)
		{
			if (this.codeTextBox.Text == "RAINBOW")
			{
				this.fireButton.Visible = false;
				this.codeTextBox.Visible = false;
				this.armingCodeLabel.Visible = false;
				this.invalidWeaponLabel.Visible = false;
				this.WeaponCode = this.codeTextBox.Text;
				this.victoryAnimationTimer.Start();
				return;
			}
			this.invalidWeaponLabel.Visible = true;
			this.codeTextBox.Text = "";
		}

		private void VictoryAnimationTimer_Tick(object sender, EventArgs e)
		{
			this.victoryTicks++;
			if (this.victoryTicks < 10)
			{
				if (this.victoryTicks % 2 == 1)
				{
					this.playerPictureBox.Location = new Point(this.playerPictureBox.Location.X, this.playerPictureBox.Location.Y - 10);
					return;
				}
				this.playerPictureBox.Location = new Point(this.playerPictureBox.Location.X, this.playerPictureBox.Location.Y + 10);
				return;
			}
			else
			{
				if (this.victoryTicks == 10)
				{
					this.laserBeamPictureBox.Visible = true;
					return;
				}
				if (this.victoryTicks == 20)
				{
					this.laserBeamPictureBox.Visible = false;
					this.explosionPictureBox.Visible = true;
					return;
				}
				if (this.victoryTicks >= 30)
				{
					this.victoryAnimationTimer.Stop();
					base.Close();
				}
				return;
			}
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Stage1Form));
			this.playerPictureBox = new PictureBox();
			this.enemyPictureBox = new PictureBox();
			this.stageLabelPictureBox = new PictureBox();
			this.codeTextBox = new TextBox();
			this.armingCodeLabel = new Label();
			this.fireButton = new Button();
			this.enemyEntryTimer = new Timer(this.components);
			this.invalidWeaponLabel = new Label();
			this.victoryAnimationTimer = new Timer(this.components);
			this.laserBeamPictureBox = new PictureBox();
			this.explosionPictureBox = new PictureBox();
			((ISupportInitialize)this.playerPictureBox).BeginInit();
			((ISupportInitialize)this.enemyPictureBox).BeginInit();
			((ISupportInitialize)this.stageLabelPictureBox).BeginInit();
			((ISupportInitialize)this.laserBeamPictureBox).BeginInit();
			((ISupportInitialize)this.explosionPictureBox).BeginInit();
			base.SuspendLayout();
			this.playerPictureBox.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.playerPictureBox.BackColor = Color.Transparent;
			this.playerPictureBox.Image = Resources.grumpy_face;
			this.playerPictureBox.Location = new Point(625, 121);
			this.playerPictureBox.Name = "playerPictureBox";
			this.playerPictureBox.Size = new Size(545, 518);
			this.playerPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
			this.playerPictureBox.TabIndex = 0;
			this.playerPictureBox.TabStop = false;
			this.enemyPictureBox.BackColor = Color.Transparent;
			this.enemyPictureBox.Image = (Image)componentResourceManager.GetObject("enemyPictureBox.Image");
			this.enemyPictureBox.Location = new Point(-281, 287);
			this.enemyPictureBox.Name = "enemyPictureBox";
			this.enemyPictureBox.Size = new Size(284, 204);
			this.enemyPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			this.enemyPictureBox.TabIndex = 1;
			this.enemyPictureBox.TabStop = false;
			this.stageLabelPictureBox.BackColor = Color.Transparent;
			this.stageLabelPictureBox.Image = Resources.stage1text;
			this.stageLabelPictureBox.Location = new Point(218, 65);
			this.stageLabelPictureBox.Name = "stageLabelPictureBox";
			this.stageLabelPictureBox.Size = new Size(796, 50);
			this.stageLabelPictureBox.TabIndex = 2;
			this.stageLabelPictureBox.TabStop = false;
			this.codeTextBox.BackColor = Color.FromArgb(0, 192, 192);
			this.codeTextBox.Font = new Font("Microsoft Sans Serif", 32f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.codeTextBox.ForeColor = Color.White;
			this.codeTextBox.Location = new Point(344, 673);
			this.codeTextBox.Name = "codeTextBox";
			this.codeTextBox.RightToLeft = RightToLeft.Yes;
			this.codeTextBox.Size = new Size(432, 68);
			this.codeTextBox.TabIndex = 3;
			this.codeTextBox.TextChanged += new EventHandler(this.CodeTextBox_TextChanged);
			this.armingCodeLabel.AutoSize = true;
			this.armingCodeLabel.BackColor = Color.Transparent;
			this.armingCodeLabel.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.armingCodeLabel.ForeColor = Color.FromArgb(128, 255, 255);
			this.armingCodeLabel.Location = new Point(336, 624);
			this.armingCodeLabel.Name = "armingCodeLabel";
			this.armingCodeLabel.Size = new Size(443, 46);
			this.armingCodeLabel.TabIndex = 4;
			this.armingCodeLabel.Text = "Weapon Arming Code:";
			this.armingCodeLabel.TextAlign = ContentAlignment.MiddleRight;
			this.fireButton.BackColor = Color.Red;
			this.fireButton.Enabled = false;
			this.fireButton.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.fireButton.ForeColor = Color.White;
			this.fireButton.Location = new Point(785, 673);
			this.fireButton.Name = "fireButton";
			this.fireButton.Size = new Size(114, 68);
			this.fireButton.TabIndex = 5;
			this.fireButton.Text = "Fire!";
			this.fireButton.UseVisualStyleBackColor = false;
			this.fireButton.Click += new EventHandler(this.FireButton_Click);
			this.enemyEntryTimer.Enabled = true;
			this.enemyEntryTimer.Tick += new EventHandler(this.Timer1_Tick);
			this.invalidWeaponLabel.AutoSize = true;
			this.invalidWeaponLabel.BackColor = Color.Transparent;
			this.invalidWeaponLabel.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.invalidWeaponLabel.ForeColor = Color.Red;
			this.invalidWeaponLabel.Location = new Point(908, 695);
			this.invalidWeaponLabel.Name = "invalidWeaponLabel";
			this.invalidWeaponLabel.Size = new Size(262, 29);
			this.invalidWeaponLabel.TabIndex = 6;
			this.invalidWeaponLabel.Text = "Invalid Weapon Code";
			this.invalidWeaponLabel.Visible = false;
			this.victoryAnimationTimer.Tick += new EventHandler(this.VictoryAnimationTimer_Tick);
			this.laserBeamPictureBox.BackColor = Color.Transparent;
			this.laserBeamPictureBox.Image = Resources.rainbowlaser_flipped;
			this.laserBeamPictureBox.Location = new Point(239, 332);
			this.laserBeamPictureBox.Name = "laserBeamPictureBox";
			this.laserBeamPictureBox.Size = new Size(447, 159);
			this.laserBeamPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			this.laserBeamPictureBox.TabIndex = 7;
			this.laserBeamPictureBox.TabStop = false;
			this.laserBeamPictureBox.Visible = false;
			this.explosionPictureBox.BackColor = Color.Transparent;
			this.explosionPictureBox.Image = Resources.Explosion;
			this.explosionPictureBox.Location = new Point(12, 121);
			this.explosionPictureBox.Name = "explosionPictureBox";
			this.explosionPictureBox.Size = new Size(569, 500);
			this.explosionPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			this.explosionPictureBox.TabIndex = 8;
			this.explosionPictureBox.TabStop = false;
			this.explosionPictureBox.Visible = false;
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackgroundImage = Resources.Starsinthesky_reduced;
			base.ClientSize = new Size(1182, 753);
			base.Controls.Add(this.explosionPictureBox);
			base.Controls.Add(this.laserBeamPictureBox);
			base.Controls.Add(this.invalidWeaponLabel);
			base.Controls.Add(this.fireButton);
			base.Controls.Add(this.armingCodeLabel);
			base.Controls.Add(this.codeTextBox);
			base.Controls.Add(this.stageLabelPictureBox);
			base.Controls.Add(this.enemyPictureBox);
			base.Controls.Add(this.playerPictureBox);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.Name = "Stage1Form";
			this.Text = "Memecat Battlestation - Stage 1 - Marauding Tabby Frigate";
			((ISupportInitialize)this.playerPictureBox).EndInit();
			((ISupportInitialize)this.enemyPictureBox).EndInit();
			((ISupportInitialize)this.stageLabelPictureBox).EndInit();
			((ISupportInitialize)this.laserBeamPictureBox).EndInit();
			((ISupportInitialize)this.explosionPictureBox).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
