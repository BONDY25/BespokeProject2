namespace BespokeProject_2
{
    partial class CustomMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomMessageBox));
            btnYesOk = new Button();
            btnNo = new Button();
            lblSummary = new Label();
            lblDescription = new Label();
            pbLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // btnYesOk
            // 
            btnYesOk.BackColor = Color.Black;
            btnYesOk.BackgroundImageLayout = ImageLayout.None;
            btnYesOk.Cursor = Cursors.Hand;
            btnYesOk.FlatStyle = FlatStyle.Flat;
            btnYesOk.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnYesOk.ForeColor = Color.White;
            btnYesOk.Location = new Point(343, 375);
            btnYesOk.Name = "btnYesOk";
            btnYesOk.Size = new Size(107, 50);
            btnYesOk.TabIndex = 2;
            btnYesOk.Text = "Yes/Ok";
            btnYesOk.UseVisualStyleBackColor = false;
            btnYesOk.Click += btnYesOk_Click;
            btnYesOk.MouseEnter += btnYesOk_MouseEnter;
            btnYesOk.MouseLeave += btnYesOk_MouseLeave;
            // 
            // btnNo
            // 
            btnNo.BackColor = Color.Black;
            btnNo.BackgroundImageLayout = ImageLayout.None;
            btnNo.Cursor = Cursors.Hand;
            btnNo.FlatStyle = FlatStyle.Flat;
            btnNo.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnNo.ForeColor = Color.White;
            btnNo.Location = new Point(5, 375);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(107, 50);
            btnNo.TabIndex = 3;
            btnNo.Text = "No";
            btnNo.UseVisualStyleBackColor = false;
            btnNo.Click += btnNo_Click;
            btnNo.MouseEnter += btnNo_MouseEnter;
            btnNo.MouseLeave += btnNo_MouseLeave;
            // 
            // lblSummary
            // 
            lblSummary.Anchor = AnchorStyles.None;
            lblSummary.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lblSummary.Location = new Point(3, 9);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(445, 41);
            lblSummary.TabIndex = 7;
            lblSummary.Text = "Summary";
            lblSummary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            lblDescription.BackColor = Color.Black;
            lblDescription.Font = new Font("Arial", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescription.ForeColor = Color.White;
            lblDescription.Location = new Point(5, 50);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(445, 242);
            lblDescription.TabIndex = 8;
            lblDescription.Text = "Description";
            lblDescription.TextAlign = ContentAlignment.TopCenter;
            // 
            // pbLogo
            // 
            pbLogo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(150, 288);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(153, 137);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 21;
            pbLogo.TabStop = false;
            // 
            // CustomMessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(456, 437);
            ControlBox = false;
            Controls.Add(lblDescription);
            Controls.Add(lblSummary);
            Controls.Add(btnNo);
            Controls.Add(btnYesOk);
            Controls.Add(pbLogo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CustomMessageBox";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CustomMessageBox";
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnYesOk;
        private Button btnNo;
        private Label lblSummary;
        private Label lblDescription;
        private PictureBox pbLogo;
    }
}