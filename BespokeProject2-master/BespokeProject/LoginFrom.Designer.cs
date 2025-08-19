namespace BespokeProject
{
    partial class LoginFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFrom));
            txbUsername = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            lblUsername = new Label();
            lblTitle = new Label();
            pbLogo = new PictureBox();
            lblVersion = new Label();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // txbUsername
            // 
            txbUsername.CharacterCasing = CharacterCasing.Upper;
            txbUsername.Cursor = Cursors.IBeam;
            txbUsername.Location = new Point(79, 308);
            txbUsername.Name = "txbUsername";
            txbUsername.Size = new Size(228, 23);
            txbUsername.TabIndex = 0;
            txbUsername.Enter += txbUsername_Enter;
            txbUsername.Leave += txbUsername_Leave;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Black;
            btnLogin.BackgroundImageLayout = ImageLayout.None;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(200, 361);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(107, 50);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            btnLogin.MouseEnter += btnLogin_MouseEnter;
            btnLogin.MouseLeave += btnLogin_MouseLeave;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Black;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(79, 361);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(107, 50);
            btnExit.TabIndex = 2;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            btnExit.MouseEnter += btnExit_MouseEnter;
            btnExit.MouseLeave += btnExit_MouseLeave;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsername.Location = new Point(79, 290);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(66, 15);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Username";
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(12, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(346, 47);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Bespoke Project II";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbLogo
            // 
            pbLogo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            pbLogo.Image = BespokeProject_2.Properties.Resources.BespokeProject_2_Logo;
            pbLogo.Location = new Point(62, 48);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(258, 240);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 6;
            pbLogo.TabStop = false;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblVersion.Location = new Point(12, 433);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(30, 14);
            lblVersion.TabIndex = 7;
            lblVersion.Text = "Build";
            // 
            // LoginFrom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(370, 456);
            Controls.Add(lblVersion);
            Controls.Add(pbLogo);
            Controls.Add(lblTitle);
            Controls.Add(lblUsername);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(txbUsername);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginFrom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bespoke Project II - Login";
            Load += LoginFrom_Load;
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbUsername;
        private Button btnLogin;
        private Button btnExit;
        private Label lblUsername;
        private Label lblTitle;
        private PictureBox pbLogo;
        private Label lblVersion;
    }
}