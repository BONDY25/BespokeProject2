namespace BespokeProject_2
{
    partial class Exceptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Exceptions));
            btnClose = new Button();
            txbRefNo = new TextBox();
            resultsTable = new DataGridView();
            lblTitle = new Label();
            btnAdd = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)resultsTable).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Black;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(8, 406);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(102, 36);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            btnClose.MouseEnter += btnClose_MouseEnter;
            btnClose.MouseLeave += btnClose_MouseLeave;
            // 
            // txbRefNo
            // 
            txbRefNo.CharacterCasing = CharacterCasing.Upper;
            txbRefNo.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbRefNo.Location = new Point(8, 76);
            txbRefNo.Name = "txbRefNo";
            txbRefNo.Size = new Size(191, 23);
            txbRefNo.TabIndex = 0;
            txbRefNo.Enter += txbRefNo_Enter;
            txbRefNo.Leave += txbRefNo_Leave;
            // 
            // resultsTable
            // 
            resultsTable.AllowUserToAddRows = false;
            resultsTable.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            resultsTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resultsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            resultsTable.BackgroundColor = Color.White;
            resultsTable.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            resultsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            resultsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = Color.Yellow;
            dataGridViewCellStyle3.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.Yellow;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            resultsTable.DefaultCellStyle = dataGridViewCellStyle3;
            resultsTable.Location = new Point(8, 105);
            resultsTable.MinimumSize = new Size(10, 0);
            resultsTable.Name = "resultsTable";
            resultsTable.ReadOnly = true;
            resultsTable.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            resultsTable.RowHeadersVisible = false;
            resultsTable.RowTemplate.Height = 25;
            resultsTable.Size = new Size(280, 295);
            resultsTable.TabIndex = 11;
            resultsTable.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(8, -2);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(280, 47);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "Bespoke Project - Home";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Black;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(205, 76);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(83, 23);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            btnAdd.MouseEnter += btnAdd_MouseEnter;
            btnAdd.MouseLeave += btnAdd_MouseLeave;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(8, 55);
            label1.Name = "label1";
            label1.Size = new Size(191, 18);
            label1.TabIndex = 7;
            label1.Text = "Exception Reference";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Exceptions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(300, 454);
            ControlBox = false;
            Controls.Add(btnAdd);
            Controls.Add(btnClose);
            Controls.Add(txbRefNo);
            Controls.Add(resultsTable);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Exceptions";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Exceptions";
            Load += Exceptions_Load;
            ((System.ComponentModel.ISupportInitialize)resultsTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private TextBox txbRefNo;
        private DataGridView resultsTable;
        private Label lblTitle;
        private Button btnAdd;
        private Label label1;
    }
}