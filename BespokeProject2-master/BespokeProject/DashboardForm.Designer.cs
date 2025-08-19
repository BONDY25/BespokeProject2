namespace BespokeProject_2
{
    partial class DashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            lblLog = new Label();
            lblTitle = new Label();
            lblConsign = new Label();
            btnClose = new Button();
            btnRefresh = new Button();
            dglog = new DataGridView();
            dgConsign = new DataGridView();
            pbLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dglog).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgConsign).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // lblLog
            // 
            lblLog.AutoSize = true;
            lblLog.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lblLog.Location = new Point(14, 191);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(203, 37);
            lblLog.TabIndex = 1;
            lblLog.Text = "Log Entries:";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Arial Rounded MT Bold", 35F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(223, 11);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1217, 54);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Dashboard";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConsign
            // 
            lblConsign.AutoSize = true;
            lblConsign.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lblConsign.Location = new Point(944, 191);
            lblConsign.Name = "lblConsign";
            lblConsign.Size = new Size(248, 37);
            lblConsign.TabIndex = 1;
            lblConsign.Text = "Consignments:";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Black;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(14, 584);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(117, 34);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            btnClose.MouseEnter += btnClose_MouseEnter;
            btnClose.MouseLeave += btnClose_MouseLeave;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Black;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(1446, 11);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(117, 34);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            btnRefresh.MouseEnter += btnRefresh_MouseEnter;
            btnRefresh.MouseLeave += btnRefresh_MouseLeave;
            // 
            // dglog
            // 
            dglog.AllowUserToAddRows = false;
            dglog.AllowUserToDeleteRows = false;
            dglog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dglog.BackgroundColor = Color.White;
            dglog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dglog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dglog.Location = new Point(14, 229);
            dglog.MinimumSize = new Size(11, 0);
            dglog.Name = "dglog";
            dglog.ReadOnly = true;
            dglog.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dglog.RowHeadersVisible = false;
            dglog.RowTemplate.Height = 25;
            dglog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dglog.Size = new Size(924, 350);
            dglog.TabIndex = 8;
            dglog.TabStop = false;
            // 
            // dgConsign
            // 
            dgConsign.AllowUserToAddRows = false;
            dgConsign.AllowUserToDeleteRows = false;
            dgConsign.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgConsign.BackgroundColor = Color.White;
            dgConsign.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgConsign.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgConsign.Location = new Point(944, 229);
            dgConsign.MinimumSize = new Size(11, 0);
            dgConsign.Name = "dgConsign";
            dgConsign.ReadOnly = true;
            dgConsign.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgConsign.RowHeadersVisible = false;
            dgConsign.RowTemplate.Height = 25;
            dgConsign.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgConsign.Size = new Size(619, 350);
            dgConsign.TabIndex = 8;
            dgConsign.TabStop = false;
            // 
            // pbLogo
            // 
            pbLogo.Cursor = Cursors.Hand;
            pbLogo.Image = Properties.Resources.BespokeProject_2_Logo;
            pbLogo.Location = new Point(14, 11);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(203, 177);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 6;
            pbLogo.TabStop = false;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1574, 629);
            Controls.Add(lblTitle);
            Controls.Add(pbLogo);
            Controls.Add(lblConsign);
            Controls.Add(btnRefresh);
            Controls.Add(btnClose);
            Controls.Add(lblLog);
            Controls.Add(dgConsign);
            Controls.Add(dglog);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "DashboardForm";
            Text = "DashboardForm";
            FormClosing += DashboardForm_FormClosing;
            Load += DashboardForm_Load;
            KeyDown += DashboardForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dglog).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgConsign).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLog;
        private Label lblTitle;
        private Label lblConsign;
        private Button btnClose;
        private Button btnRefresh;
        private DataGridView dglog;
        private DataGridView dgConsign;
        private PictureBox pbLogo;
    }
}