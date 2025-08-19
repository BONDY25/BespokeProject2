namespace BespokeProject_2
{
    partial class MisInject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MisInject));
            btnClose = new Button();
            dgHistory = new DataGridView();
            label5 = new Label();
            pbLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Black;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(12, 371);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(102, 36);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            btnClose.MouseEnter += btnClose_MouseEnter;
            btnClose.MouseLeave += btnClose_MouseLeave;
            // 
            // dgHistory
            // 
            dgHistory.AllowUserToAddRows = false;
            dgHistory.AllowUserToDeleteRows = false;
            dgHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgHistory.BackgroundColor = Color.White;
            dgHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgHistory.Location = new Point(12, 115);
            dgHistory.MinimumSize = new Size(10, 0);
            dgHistory.Name = "dgHistory";
            dgHistory.ReadOnly = true;
            dgHistory.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgHistory.RowHeadersVisible = false;
            dgHistory.RowTemplate.Height = 25;
            dgHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgHistory.Size = new Size(504, 250);
            dgHistory.TabIndex = 9;
            dgHistory.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 33);
            label5.Name = "label5";
            label5.Size = new Size(232, 37);
            label5.TabIndex = 0;
            label5.Text = "Mis-Injections";
            // 
            // pbLogo
            // 
            pbLogo.Cursor = Cursors.Hand;
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(406, 9);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(110, 100);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 10;
            pbLogo.TabStop = false;
            // 
            // MisInject
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(528, 419);
            ControlBox = false;
            Controls.Add(pbLogo);
            Controls.Add(dgHistory);
            Controls.Add(btnClose);
            Controls.Add(label5);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MisInject";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MisInject";
            Load += MisInject_Load;
            KeyDown += MisInject_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgHistory).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private DataGridView dgHistory;
        private Label label5;
        private PictureBox pbLogo;
    }
}