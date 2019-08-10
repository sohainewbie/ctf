using MemeCatBattlestation.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MemeCatBattlestation
{
	public class Stage3Form : Form
	{
		private int victoryTicks;

		public string WeaponCode;

		public string PriorWeaponCode;

		private IContainer components;

		private Label invalidWeaponLabel;

		private Button fireButton;

		private Label armingCodeLabel;

		private TextBox codeTextBox;

		private PictureBox stageLabelPictureBox;

		private PictureBox playerPictureBox;

		private PictureBox enemyPictureBox;

		private Timer enemyEntryTimer;

		private Timer victoryAnimationTimer;

		private PictureBox explosionPictureBox;

		private PictureBox loveBombPictureBox;

		public Stage3Form()
		{
			this.InitializeComponent();
		}

		private void EnemyEntryTimer_Tick(object sender, EventArgs e)
		{
			if (this.enemyPictureBox.Location.X < 0)
			{
				this.enemyPictureBox.Location = new Point(this.enemyPictureBox.Location.X + 10, this.enemyPictureBox.Location.Y);
				return;
			}
			this.enemyEntryTimer.Enabled = false;
		}

		public static string Base64Encode(string plainText)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
		}

		public static string Base64Decode(string base64EncodedData)
		{
			byte[] bytes = Convert.FromBase64String(base64EncodedData);
			return Encoding.UTF8.GetString(bytes);
		}

		private string getCatGenetics()
		{
			return Stage3Form.Base64Encode(this.PriorWeaponCode);
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
					this.loveBombPictureBox.Visible = true;
					return;
				}
				if (this.victoryTicks < 20)
				{
					this.loveBombPictureBox.Location = new Point(this.loveBombPictureBox.Location.X - 10, this.loveBombPictureBox.Location.Y);
					return;
				}
				if (this.victoryTicks == 20)
				{
					this.loveBombPictureBox.Visible = false;
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
			string catGenetics = this.getCatGenetics();
			return BattleCatManagerInstance.InitializeBattleCat(Encoding.UTF8.GetBytes(catGenetics), Encoding.UTF8.GetBytes(s)).SequenceEqual(new byte[]
			{
				95,
				193,
				50,
				12,
				127,
				228,
				98,
				6,
				215,
				46,
				200,
				106,
				251,
				121,
				186,
				119,
				109,
				73,
				35,
				14,
				20
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
			this.stageLabelPictureBox = new PictureBox();
			this.playerPictureBox = new PictureBox();
			this.enemyPictureBox = new PictureBox();
			this.enemyEntryTimer = new Timer(this.components);
			this.victoryAnimationTimer = new Timer(this.components);
			this.explosionPictureBox = new PictureBox();
			this.loveBombPictureBox = new PictureBox();
			((ISupportInitialize)this.stageLabelPictureBox).BeginInit();
			((ISupportInitialize)this.playerPictureBox).BeginInit();
			((ISupportInitialize)this.enemyPictureBox).BeginInit();
			((ISupportInitialize)this.explosionPictureBox).BeginInit();
			((ISupportInitialize)this.loveBombPictureBox).BeginInit();
			base.SuspendLayout();
			this.invalidWeaponLabel.AutoSize = true;
			this.invalidWeaponLabel.BackColor = Color.Transparent;
			this.invalidWeaponLabel.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.invalidWeaponLabel.ForeColor = Color.Red;
			this.invalidWeaponLabel.Location = new Point(885, 670);
			this.invalidWeaponLabel.Name = "invalidWeaponLabel";
			this.invalidWeaponLabel.Size = new Size(210, 24);
			this.invalidWeaponLabel.TabIndex = 12;
			this.invalidWeaponLabel.Text = "Invalid Weapon Code";
			this.invalidWeaponLabel.Visible = false;
			this.fireButton.BackColor = Color.Red;
			this.fireButton.Enabled = false;
			this.fireButton.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.fireButton.ForeColor = Color.White;
			this.fireButton.Location = new Point(762, 648);
			this.fireButton.Name = "fireButton";
			this.fireButton.Size = new Size(114, 68);
			this.fireButton.TabIndex = 11;
			this.fireButton.Text = "Fire!";
			this.fireButton.UseVisualStyleBackColor = false;
			this.fireButton.Click += new EventHandler(this.FireButton_Click);
			this.armingCodeLabel.AutoSize = true;
			this.armingCodeLabel.BackColor = Color.Transparent;
			this.armingCodeLabel.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.armingCodeLabel.ForeColor = Color.FromArgb(128, 255, 255);
			this.armingCodeLabel.Location = new Point(313, 599);
			this.armingCodeLabel.Name = "armingCodeLabel";
			this.armingCodeLabel.Size = new Size(362, 37);
			this.armingCodeLabel.TabIndex = 10;
			this.armingCodeLabel.Text = "Weapon Arming Code:";
			this.armingCodeLabel.TextAlign = ContentAlignment.MiddleRight;
			this.codeTextBox.BackColor = Color.FromArgb(0, 192, 192);
			this.codeTextBox.Font = new Font("Microsoft Sans Serif", 32f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.codeTextBox.ForeColor = Color.White;
			this.codeTextBox.Location = new Point(140, 648);
			this.codeTextBox.Name = "codeTextBox";
			this.codeTextBox.RightToLeft = RightToLeft.Yes;
			this.codeTextBox.Size = new Size(613, 56);
			this.codeTextBox.TabIndex = 9;
			this.codeTextBox.TextChanged += new EventHandler(this.CodeTextBox_TextChanged);
			this.stageLabelPictureBox.BackColor = Color.Transparent;
			this.stageLabelPictureBox.Image = Resources.stage3text;
			this.stageLabelPictureBox.Location = new Point(195, 40);
			this.stageLabelPictureBox.Name = "stageLabelPictureBox";
			this.stageLabelPictureBox.Size = new Size(796, 50);
			this.stageLabelPictureBox.TabIndex = 8;
			this.stageLabelPictureBox.TabStop = false;
			this.playerPictureBox.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.playerPictureBox.BackColor = Color.Transparent;
			this.playerPictureBox.Image = Resources.grumpy_face;
			this.playerPictureBox.Location = new Point(625, 96);
			this.playerPictureBox.Name = "playerPictureBox";
			this.playerPictureBox.Size = new Size(545, 518);
			this.playerPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
			this.playerPictureBox.TabIndex = 7;
			this.playerPictureBox.TabStop = false;
			this.enemyPictureBox.BackColor = Color.Transparent;
			this.enemyPictureBox.Image = Resources.keyboard_cat_transparent;
			this.enemyPictureBox.Location = new Point(-466, 252);
			this.enemyPictureBox.Name = "enemyPictureBox";
			this.enemyPictureBox.Size = new Size(479, 311);
			this.enemyPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			this.enemyPictureBox.TabIndex = 13;
			this.enemyPictureBox.TabStop = false;
			this.enemyEntryTimer.Enabled = true;
			this.enemyEntryTimer.Tick += new EventHandler(this.EnemyEntryTimer_Tick);
			this.victoryAnimationTimer.Tick += new EventHandler(this.VictoryAnimationTimer_Tick);
			this.explosionPictureBox.BackColor = Color.Transparent;
			this.explosionPictureBox.Image = Resources.Explosion;
			this.explosionPictureBox.Location = new Point(2, 105);
			this.explosionPictureBox.Name = "explosionPictureBox";
			this.explosionPictureBox.Size = new Size(569, 500);
			this.explosionPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			this.explosionPictureBox.TabIndex = 15;
			this.explosionPictureBox.TabStop = false;
			this.explosionPictureBox.Visible = false;
			this.loveBombPictureBox.BackColor = Color.Transparent;
			this.loveBombPictureBox.Image = Resources.lovebomb;
			this.loveBombPictureBox.Location = new Point(568, 213);
			this.loveBombPictureBox.Name = "loveBombPictureBox";
			this.loveBombPictureBox.Size = new Size(114, 326);
			this.loveBombPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			this.loveBombPictureBox.TabIndex = 14;
			this.loveBombPictureBox.TabStop = false;
			this.loveBombPictureBox.Visible = false;
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackgroundImage = Resources.Starsinthesky_reduced;
			this.BackgroundImageLayout = ImageLayout.Stretch;
			base.ClientSize = new Size(1182, 753);
			base.Controls.Add(this.explosionPictureBox);
			base.Controls.Add(this.loveBombPictureBox);
			base.Controls.Add(this.enemyPictureBox);
			base.Controls.Add(this.invalidWeaponLabel);
			base.Controls.Add(this.fireButton);
			base.Controls.Add(this.armingCodeLabel);
			base.Controls.Add(this.codeTextBox);
			base.Controls.Add(this.stageLabelPictureBox);
			base.Controls.Add(this.playerPictureBox);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.Name = "Stage3Form";
			base.StartPosition = FormStartPosition.Manual;
			this.Text = "Memecat Battlestation - Stage 3 - Keyboard Cat Juggernaut";
			((ISupportInitialize)this.stageLabelPictureBox).EndInit();
			((ISupportInitialize)this.playerPictureBox).EndInit();
			((ISupportInitialize)this.enemyPictureBox).EndInit();
			((ISupportInitialize)this.explosionPictureBox).EndInit();
			((ISupportInitialize)this.loveBombPictureBox).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
