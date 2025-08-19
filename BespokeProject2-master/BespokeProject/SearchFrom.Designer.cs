namespace BespokeProject
{
    partial class SearchFrom
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchFrom));
            label1 = new Label();
            txbSearch = new TextBox();
            cbField = new ComboBox();
            btnSearch = new Button();
            btnClear = new Button();
            btnBack = new Button();
            label2 = new Label();
            label3 = new Label();
            resultsTable = new DataGridView();
            lblUserName = new Label();
            lblKey = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)resultsTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(925, 38);
            label1.TabIndex = 0;
            label1.Text = "Bespoke Project - Search";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txbSearch
            // 
            txbSearch.CharacterCasing = CharacterCasing.Upper;
            txbSearch.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txbSearch.Location = new Point(219, 86);
            txbSearch.Name = "txbSearch";
            txbSearch.Size = new Size(268, 21);
            txbSearch.TabIndex = 2;
            txbSearch.Enter += txbSearch_Enter;
            txbSearch.Leave += txbSearch_Leave;
            // 
            // cbField
            // 
            cbField.DropDownStyle = ComboBoxStyle.DropDownList;
            cbField.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cbField.FormattingEnabled = true;
            cbField.Items.AddRange(new object[] { "1", "2", "3" });
            cbField.Location = new Point(12, 86);
            cbField.Name = "cbField";
            cbField.Size = new Size(201, 23);
            cbField.TabIndex = 1;
            cbField.Enter += cbField_Enter;
            cbField.Leave += cbField_Leave;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Black;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(238, 364);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(107, 41);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            btnSearch.MouseEnter += btnSearch_MouseEnter;
            btnSearch.MouseLeave += btnSearch_MouseLeave;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Black;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(125, 364);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(107, 41);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            btnClear.MouseEnter += btnClear_MouseEnter;
            btnClear.MouseLeave += btnClear_MouseLeave;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Black;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(12, 364);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(107, 41);
            btnBack.TabIndex = 5;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            btnBack.MouseEnter += btnBack_MouseEnter;
            btnBack.MouseLeave += btnBack_MouseLeave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 68);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 6;
            label2.Text = "Field";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(219, 68);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 7;
            label3.Text = "Search";
            // 
            // resultsTable
            // 
            resultsTable.AllowUserToAddRows = false;
            resultsTable.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            resultsTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resultsTable.BackgroundColor = Color.White;
            resultsTable.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            resultsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            resultsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Yellow;
            dataGridViewCellStyle3.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.Yellow;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            resultsTable.DefaultCellStyle = dataGridViewCellStyle3;
            resultsTable.Location = new Point(14, 134);
            resultsTable.Name = "resultsTable";
            resultsTable.ReadOnly = true;
            resultsTable.RowHeadersVisible = false;
            resultsTable.RowTemplate.Height = 25;
            resultsTable.Size = new Size(923, 224);
            resultsTable.TabIndex = 8;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblUserName.Location = new Point(11, 5);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(69, 14);
            lblUserName.TabIndex = 9;
            lblUserName.Text = "UserName";
            // 
            // lblKey
            // 
            lblKey.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblKey.Location = new Point(11, 408);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(926, 69);
            lblKey.TabIndex = 10;
            lblKey.Text = "Field Key";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = BespokeProject_2.Properties.Resources.BespokeProject_2_Logo;
            pictureBox1.Location = new Point(857, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(80, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // SearchFrom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(949, 488);
            ControlBox = false;
            Controls.Add(pictureBox1);
            Controls.Add(lblKey);
            Controls.Add(lblUserName);
            Controls.Add(resultsTable);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnBack);
            Controls.Add(btnClear);
            Controls.Add(btnSearch);
            Controls.Add(cbField);
            Controls.Add(txbSearch);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SearchFrom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bespoke Project - Search";
            Load += SearchFrom_Load;
            ((System.ComponentModel.ISupportInitialize)resultsTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txbSearch;
        private ComboBox cbField;
        private Button btnSearch;
        private Button btnClear;
        private Button btnBack;
        private Label label2;
        private Label label3;
        private DataGridView resultsTable;
        private Label lblUserName;
        private Label lblKey;
        private PictureBox pictureBox1;
    }
}