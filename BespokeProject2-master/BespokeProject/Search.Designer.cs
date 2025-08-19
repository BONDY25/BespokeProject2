namespace BespokeProject_2
{
    partial class Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            txbSearch = new TextBox();
            btnClose = new Button();
            dgHistory = new DataGridView();
            pbLogo = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dgHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // txbSearch
            // 
            txbSearch.CharacterCasing = CharacterCasing.Upper;
            txbSearch.Cursor = Cursors.IBeam;
            txbSearch.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txbSearch.Location = new Point(12, 135);
            txbSearch.MaxLength = 255;
            txbSearch.Name = "txbSearch";
            txbSearch.Size = new Size(498, 35);
            txbSearch.TabIndex = 1;
            txbSearch.Enter += txbSearch_Enter;
            txbSearch.Leave += txbSearch_Leave;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Black;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(12, 460);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(117, 34);
            btnClose.TabIndex = 3;
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
            dgHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgHistory.BackgroundColor = Color.White;
            dgHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgHistory.Location = new Point(12, 176);
            dgHistory.MinimumSize = new Size(11, 0);
            dgHistory.Name = "dgHistory";
            dgHistory.ReadOnly = true;
            dgHistory.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgHistory.RowHeadersVisible = false;
            dgHistory.RowTemplate.Height = 25;
            dgHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgHistory.Size = new Size(621, 278);
            dgHistory.TabIndex = 4;
            dgHistory.TabStop = false;
            // 
            // pbLogo
            // 
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(12, 12);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(110, 100);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 6;
            pbLogo.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 118);
            label1.Name = "label1";
            label1.Size = new Size(116, 14);
            label1.TabIndex = 7;
            label1.Text = "Enter Search Term";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(281, 51);
            label2.Name = "label2";
            label2.Size = new Size(128, 37);
            label2.TabIndex = 11;
            label2.Text = "Search";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Black;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(516, 135);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(117, 35);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            btnSearch.MouseEnter += btnSearch_MouseEnter;
            btnSearch.MouseLeave += btnSearch_MouseLeave;
            // 
            // Search
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(645, 506);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(txbSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnClose);
            Controls.Add(label2);
            Controls.Add(dgHistory);
            Controls.Add(pbLogo);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Search";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Search";
            FormClosing += Search_FormClosing;
            Load += Search_Load;
            KeyDown += Search_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgHistory).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbSearch;
        private Button btnClose;
        private DataGridView dgHistory;
        private PictureBox pbLogo;
        private Label label1;
        private Label label2;
        private Button btnSearch;
    }
}