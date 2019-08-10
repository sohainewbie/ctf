using MemeCatBattlestation.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MemeCatBattlestation
{
	public class Stage2Form : Form
	{
		private int victoryTicks;

		public string WeaponCode;

		private IContainer components;

		private Label invalidWeaponLabel;

		private Button fireButton;

		private Label armingCodeLabel;

		private TextBox codeTextBox;

		private PictureBox playerPictureBox;

		private PictureBox enemyPictureBox;

		private PictureBox stageLabelPictureBox;

		private Timer enemyEntryTimer;

		private Timer victoryAnimationTimer;

		private PictureBox bagelsPictureBox;

		private PictureBox explosionPictureBox;

		public Stage2Form()
		{
			this.InitializeComponent();
		}

		private void EnemyEntryTimer_Tick(object sender, EventArgs e)
		{
			if (this.enemyPictureBox.Location.X < 50)
			{
				this.enemyPictureBox.Location = new Point(this.enemyPictureBox.Location.X + 10, this.enemyPictureBox.Location.Y);
				return;
			}
			this.enemyEntryTimer.Enabled = false;
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
					this.bagelsPictureBox.Visible = true;
					return;
				}
				if (this.victoryTicks == 20)
				{
					this.bagelsPictureBox.Visible = false;
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

		private void CodeTextBox_TextChanged(object sender, EventArgs e)
		{
			if (this.codeTextBox.Text != "")
			{
				this.fireButton.Enabled = true;
				return;
			}
			this.fireButton.Enabled = false;
		}

		private bool isValidWeaponCode(string s)
		{
			char[] array = s.ToCharArray();
			int length = s.Length;
			for (int i = 0; i < length; i++)
			{
				char[] expr_19_cp_0 = array;
				int expr_19_cp_1 = i;
				expr_19_cp_0[expr_19_cp_1] ^= (char)(65 + i * 2);
			}
			return array.SequenceEqual(new char[]
			{
				'\u0003',
				'"',
				'"',
				'"',
				'%',
				'\u0014',
				'\u000e',
				'.',
				'?',
				'=',
				':',
				'9'
			});
		}

		private void FireButton_Click(object sender, EventArgs e)
		{
			if (this.isValidWeaponCode(this.codeTextBox.Text))
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
			this.invalidWeaponLabel = new Label();
			this.fireButton = new Button();
			this.armingCodeLabel = new Label();
			this.codeTextBox = new TextBox();
			this.playerPictureBox = new PictureBox();
			this.enemyPictureBox = new PictureBox();
			this.stageLabelPictureBox = new PictureBox();
			this.enemyEntryTimer = new Timer(this.components);
			this.victoryAnimationTimer = new Timer(this.components);
			this.bagelsPictureBox = new PictureBox();
			this.explosionPictureBox = new PictureBox();
			((ISupportInitialize)this.playerPictureBox).BeginInit();
			((ISupportInitialize)this.enemyPictureBox).BeginInit();
			((ISupportInitialize)this.stageLabelPictureBox).BeginInit();
			((ISupportInitialize)this.bagelsPictureBox).BeginInit();
			((ISupportInitialize)this.explosionPictureBox).BeginInit();
			base.SuspendLayout();
			this.invalidWeaponLabel.AutoSize = true;
			this.invalidWeaponLabel.BackColor = Color.Transparent;
			this.invalidWeaponLabel.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.invalidWeaponLabel.ForeColor = Color.Red;
			this.invalidWeaponLabel.Location = new Point(887, 695);
			this.invalidWeaponLabel.Name = "invalidWeaponLabel";
			this.invalidWeaponLabel.Size = new Size(262, 29);
			this.invalidWeaponLabel.TabIndex = 10;
			this.invalidWeaponLabel.Text = "Invalid Weapon Code";
			this.invalidWeaponLabel.Visible = false;
			this.fireButton.BackColor = Color.Red;
			this.fireButton.Enabled = false;
			this.fireButton.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.fireButton.ForeColor = Color.White;
			this.fireButton.Location = new Point(764, 673);
			this.fireButton.Name = "fireButton";
			this.fireButton.Size = new Size(114, 68);
			this.fireButton.TabIndex = 9;
			this.fireButton.Text = "Fire!";
			this.fireButton.UseVisualStyleBackColor = false;
			this.fireButton.Click += new EventHandler(this.FireButton_Click);
			this.armingCodeLabel.AutoSize = true;
			this.armingCodeLabel.BackColor = Color.Transparent;
			this.armingCodeLabel.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.armingCodeLabel.ForeColor = Color.FromArgb(128, 255, 255);
			this.armingCodeLabel.Location = new Point(315, 624);
			this.armingCodeLabel.Name = "armingCodeLabel";
			this.armingCodeLabel.Size = new Size(443, 46);
			this.armingCodeLabel.TabIndex = 8;
			this.armingCodeLabel.Text = "Weapon Arming Code:";
			this.armingCodeLabel.TextAlign = ContentAlignment.MiddleRight;
			this.codeTextBox.BackColor = Color.FromArgb(0, 192, 192);
			this.codeTextBox.Font = new Font("Microsoft Sans Serif", 32f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.codeTextBox.ForeColor = Color.White;
			this.codeTextBox.Location = new Point(323, 673);
			this.codeTextBox.Name = "codeTextBox";
			this.codeTextBox.RightToLeft = RightToLeft.Yes;
			this.codeTextBox.Size = new Size(432, 68);
			this.codeTextBox.TabIndex = 7;
			this.codeTextBox.TextChanged += new EventHandler(this.CodeTextBox_TextChanged);
			this.playerPictureBox.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.playerPictureBox.BackColor = Color.Transparent;
			this.playerPictureBox.Image = Resources.grumpy_face;
			this.playerPictureBox.Location = new Point(625, 90);
			this.playerPictureBox.Name = "playerPictureBox";
			this.playerPictureBox.Size = new Size(545, 518);
			this.playerPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
			this.playerPictureBox.TabIndex = 11;
			this.playerPictureBox.TabStop = false;
			this.enemyPictureBox.BackColor = Color.Transparent;
			this.enemyPictureBox.Image = Resources.kittyelaine;
			this.enemyPictureBox.Location = new Point(-275, 251);
			this.enemyPictureBox.Name = "enemyPictureBox";
			this.enemyPictureBox.Size = new Size(294, 267);
			this.enemyPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			this.enemyPictureBox.TabIndex = 12;
			this.enemyPictureBox.TabStop = false;
			this.stageLabelPictureBox.BackColor = Color.Transparent;
			this.stageLabelPictureBox.Image = Resources.stage2text;
			this.stageLabelPictureBox.Location = new Point(207, 58);
			this.stageLabelPictureBox.Name = "stageLabelPictureBox";
			this.stageLabelPictureBox.Size = new Size(796, 50);
			this.stageLabelPictureBox.TabIndex = 13;
			this.stageLabelPictureBox.TabStop = false;
			this.enemyEntryTimer.Enabled = true;
			this.enemyEntryTimer.Tick += new EventHandler(this.EnemyEntryTimer_Tick);
			this.victoryAnimationTimer.Tick += new EventHandler(this.VictoryAnimationTimer_Tick);
			this.bagelsPictureBox.BackColor = Color.Transparent;
			this.bagelsPictureBox.Image = Resources.bagels;
			this.bagelsPictureBox.Location = new Point(413, 319);
			this.bagelsPictureBox.Name = "bagelsPictureBox";
			this.bagelsPictureBox.Size = new Size(279, 117);
			this.bagelsPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			this.bagelsPictureBox.TabIndex = 14;
			this.bagelsPictureBox.TabStop = false;
			this.bagelsPictureBox.Visible = false;
			this.explosionPictureBox.BackColor = Color.Transparent;
			this.explosionPictureBox.Image = Resources.Explosion;
			this.explosionPictureBox.Location = new Point(-5, 108);
			this.explosionPictureBox.Name = "explosionPictureBox";
			this.explosionPictureBox.Size = new Size(569, 500);
			this.explosionPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			this.explosionPictureBox.TabIndex = 15;
			this.explosionPictureBox.TabStop = false;
			this.explosionPictureBox.Visible = false;
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackgroundImage = Resources.Starsinthesky_reduced;
			base.ClientSize = new Size(1182, 753);
			base.Controls.Add(this.explosionPictureBox);
			base.Controls.Add(this.bagelsPictureBox);
			base.Controls.Add(this.invalidWeaponLabel);
			base.Controls.Add(this.fireButton);
			base.Controls.Add(this.armingCodeLabel);
			base.Controls.Add(this.codeTextBox);
			base.Controls.Add(this.stageLabelPictureBox);
			base.Controls.Add(this.enemyPictureBox);
			base.Controls.Add(this.playerPictureBox);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.Name = "Stage2Form";
			base.StartPosition = FormStartPosition.Manual;
			this.Text = "Memecat Battlestation - Stage 2 - Perimeter Defense Kitteh";
			((ISupportInitialize)this.playerPictureBox).EndInit();
			((ISupportInitialize)this.enemyPictureBox).EndInit();
			((ISupportInitialize)this.stageLabelPictureBox).EndInit();
			((ISupportInitialize)this.bagelsPictureBox).EndInit();
			((ISupportInitialize)this.explosionPictureBox).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
