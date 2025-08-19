namespace BespokeProject_2
{
    partial class ClientSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientSelectionForm));
            cbClient = new ComboBox();
            lblClient = new Label();
            btnOpen = new Button();
            btnExit = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // cbClient
            // 
            cbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClient.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cbClient.FormattingEnabled = true;
            cbClient.Location = new Point(9, 74);
            cbClient.Name = "cbClient";
            cbClient.Size = new Size(298, 23);
            cbClient.TabIndex = 0;
            cbClient.Enter += cbClient_Enter;
            cbClient.Leave += cbClient_Leave;
            // 
            // lblClient
            // 
            lblClient.AutoSize = true;
            lblClient.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblClient.Location = new Point(12, 56);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(39, 15);
            lblClient.TabIndex = 7;
            lblClient.Text = "Client";
            // 
            // btnOpen
            // 
            btnOpen.BackColor = Color.Black;
            btnOpen.BackgroundImageLayout = ImageLayout.None;
            btnOpen.Cursor = Cursors.Hand;
            btnOpen.FlatStyle = FlatStyle.Flat;
            btnOpen.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnOpen.ForeColor = Color.White;
            btnOpen.Location = new Point(203, 109);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(107, 50);
            btnOpen.TabIndex = 8;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = false;
            btnOpen.Click += btnOpen_Click;
            btnOpen.MouseEnter += btnOpen_MouseEnter;
            btnOpen.MouseLeave += btnOpen_MouseLeave;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Black;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(9, 109);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(107, 50);
            btnExit.TabIndex = 9;
            btnExit.Text = "Close";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            btnExit.MouseEnter += btnExit_MouseEnter;
            btnExit.MouseLeave += btnExit_MouseLeave;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(298, 47);
            label1.TabIndex = 7;
            label1.Text = "Client Selection";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(250, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(60, 57);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // ClientSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(319, 171);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(btnExit);
            Controls.Add(btnOpen);
            Controls.Add(lblClient);
            Controls.Add(cbClient);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClientSelectionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Client Selection";
            FormClosing += ClientSelectionForm_FormClosing;
            Load += ClientSelectionForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbClient;
        private Label lblClient;
        private Button btnOpen;
        private Button btnExit;
        private Label label1;
        private PictureBox pictureBox1;
    }
}