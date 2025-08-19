namespace BespokeProject_2
{
    partial class OpenPlate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenPlate));
            dgHistory = new DataGridView();
            pbLogo = new PictureBox();
            btnClose = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // dgHistory
            // 
            dgHistory.AllowUserToAddRows = false;
            dgHistory.AllowUserToDeleteRows = false;
            dgHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgHistory.BackgroundColor = Color.White;
            dgHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgHistory.Location = new Point(7, 117);
            dgHistory.MinimumSize = new Size(11, 0);
            dgHistory.Name = "dgHistory";
            dgHistory.ReadOnly = true;
            dgHistory.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgHistory.RowHeadersVisible = false;
            dgHistory.RowTemplate.Height = 25;
            dgHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgHistory.Size = new Size(549, 309);
            dgHistory.TabIndex = 8;
            dgHistory.TabStop = false;
            dgHistory.CellClick += dgHistory_CellClick;
            dgHistory.CellFormatting += dgHistory_CellFormatting;
            // 
            // pbLogo
            // 
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(7, 11);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(110, 100);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 6;
            pbLogo.TabStop = false;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Black;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(7, 432);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(117, 34);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            btnClose.MouseEnter += btnClose_MouseEnter;
            btnClose.MouseLeave += btnClose_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(152, 38);
            label1.Name = "label1";
            label1.Size = new Size(333, 37);
            label1.TabIndex = 11;
            label1.Text = "Open License Plates";
            // 
            // OpenPlate
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(568, 477);
            ControlBox = false;
            Controls.Add(dgHistory);
            Controls.Add(btnClose);
            Controls.Add(pbLogo);
            Controls.Add(label1);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "OpenPlate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OpenPlate";
            FormClosing += OpenPlate_FormClosing;
            Load += OpenPlate_Load;
            ((System.ComponentModel.ISupportInitialize)dgHistory).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgHistory;
        private PictureBox pbLogo;
        private Button btnClose;
        private Label label1;
    }
}