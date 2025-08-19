namespace BespokeProject
{
    partial class MaintenanceFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaintenanceFrom));
            label1 = new Label();
            txbBatchNo = new TextBox();
            cbField = new ComboBox();
            txbNewData = new TextBox();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnBack = new Button();
            lblField1 = new Label();
            label3 = new Label();
            label4 = new Label();
            resultsTable = new DataGridView();
            lblUserName = new Label();
            btnClear = new Button();
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
            label1.Size = new Size(871, 38);
            label1.TabIndex = 0;
            label1.Text = "Bespoke Project - Maintenance";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txbBatchNo
            // 
            txbBatchNo.CharacterCasing = CharacterCasing.Upper;
            txbBatchNo.Location = new Point(12, 68);
            txbBatchNo.Name = "txbBatchNo";
            txbBatchNo.Size = new Size(244, 23);
            txbBatchNo.TabIndex = 1;
            txbBatchNo.TextChanged += txbBatchNo_TextChanged;
            txbBatchNo.Enter += txbBatchNo_Enter;
            txbBatchNo.Leave += txbBatchNo_Leave;
            // 
            // cbField
            // 
            cbField.DropDownStyle = ComboBoxStyle.DropDownList;
            cbField.FormattingEnabled = true;
            cbField.Items.AddRange(new object[] { "1", "2", "3" });
            cbField.Location = new Point(12, 112);
            cbField.Name = "cbField";
            cbField.Size = new Size(244, 23);
            cbField.TabIndex = 2;
            cbField.Enter += cbField_Enter;
            cbField.Leave += cbField_Leave;
            // 
            // txbNewData
            // 
            txbNewData.CharacterCasing = CharacterCasing.Upper;
            txbNewData.Location = new Point(12, 156);
            txbNewData.Name = "txbNewData";
            txbNewData.Size = new Size(244, 23);
            txbNewData.TabIndex = 3;
            txbNewData.Enter += txbNewData_Enter;
            txbNewData.Leave += txbNewData_Leave;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Black;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(339, 466);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(103, 36);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            btnUpdate.MouseEnter += btnUpdate_MouseEnter;
            btnUpdate.MouseLeave += btnUpdate_MouseLeave;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Black;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(121, 466);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(103, 36);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            btnDelete.MouseEnter += btnDelete_MouseEnter;
            btnDelete.MouseLeave += btnDelete_MouseLeave;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Black;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(12, 466);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(103, 36);
            btnBack.TabIndex = 7;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            btnBack.MouseEnter += btnBack_MouseEnter;
            btnBack.MouseLeave += btnBack_MouseLeave;
            // 
            // lblField1
            // 
            lblField1.AutoSize = true;
            lblField1.Location = new Point(12, 50);
            lblField1.Name = "lblField1";
            lblField1.Size = new Size(16, 15);
            lblField1.TabIndex = 8;
            lblField1.Text = "1.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 94);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 9;
            label3.Text = "Update Field";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 138);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 10;
            label4.Text = "New Data";
            // 
            // resultsTable
            // 
            resultsTable.AllowUserToAddRows = false;
            resultsTable.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            resultsTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resultsTable.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            resultsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            resultsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Yellow;
            dataGridViewCellStyle3.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            resultsTable.DefaultCellStyle = dataGridViewCellStyle3;
            resultsTable.Location = new Point(12, 185);
            resultsTable.Name = "resultsTable";
            resultsTable.RowHeadersVisible = false;
            resultsTable.RowTemplate.Height = 25;
            resultsTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            resultsTable.Size = new Size(871, 275);
            resultsTable.TabIndex = 11;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblUserName.Location = new Point(8, 5);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(69, 14);
            lblUserName.TabIndex = 12;
            lblUserName.Text = "UserName";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Black;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(230, 466);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(103, 36);
            btnClear.TabIndex = 5;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            btnClear.MouseEnter += btnClear_MouseEnter;
            btnClear.MouseLeave += btnClear_MouseLeave;
            // 
            // lblKey
            // 
            lblKey.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblKey.Location = new Point(12, 505);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(871, 69);
            lblKey.TabIndex = 13;
            lblKey.Text = "Field Key";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = BespokeProject_2.Properties.Resources.BespokeProject_2_Logo;
            pictureBox1.Location = new Point(783, 56);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 97);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // MaintenanceFrom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(895, 588);
            Controls.Add(pictureBox1);
            Controls.Add(lblKey);
            Controls.Add(btnClear);
            Controls.Add(lblUserName);
            Controls.Add(resultsTable);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lblField1);
            Controls.Add(btnBack);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(txbNewData);
            Controls.Add(cbField);
            Controls.Add(txbBatchNo);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MaintenanceFrom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bespoke Project - Maintenance";
            Load += MaintenanceFrom_Load;
            KeyDown += MaintenanceFrom_KeyDown;
            ((System.ComponentModel.ISupportInitialize)resultsTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txbBatchNo;
        private ComboBox cbField;
        private TextBox txbNewData;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnBack;
        private Label lblField1;
        private Label label3;
        private Label label4;
        private DataGridView resultsTable;
        private Label lblUserName;
        private Button btnClear;
        private Label lblKey;
        private PictureBox pictureBox1;
    }
}