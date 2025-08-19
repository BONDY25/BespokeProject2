namespace BespokeProject
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            txbBatchNo = new TextBox();
            txbBoxID = new TextBox();
            txbRefNo = new TextBox();
            btnInsert = new Button();
            btnMaintenance = new Button();
            btnSearch = new Button();
            lblTitle = new Label();
            lblBatchNo = new Label();
            lblRefNo = new Label();
            lblBagID = new Label();
            resultsTable = new DataGridView();
            lblUserName = new Label();
            lblDupe = new Label();
            lblCount = new Label();
            btnClear = new Button();
            lblBatchCounter = new Label();
            lblBoxCount = new Label();
            lblLastScan = new Label();
            lblStatus = new Label();
            pbLogo = new PictureBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            breakdownToolStripMenuItem = new ToolStripMenuItem();
            labelGeneratorToolStripMenuItem = new ToolStripMenuItem();
            moreToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            formsToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            maintenanceToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            insertToolStripMenuItem = new ToolStripMenuItem();
            clearToolStripMenuItem = new ToolStripMenuItem();
            exceptionsToolStripMenuItem = new ToolStripMenuItem();
            lblPraise = new Label();
            btnExit = new Button();
            sessionTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)resultsTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txbBatchNo
            // 
            txbBatchNo.CharacterCasing = CharacterCasing.Upper;
            txbBatchNo.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txbBatchNo.Location = new Point(9, 101);
            txbBatchNo.Name = "txbBatchNo";
            txbBatchNo.Size = new Size(250, 21);
            txbBatchNo.TabIndex = 0;
            txbBatchNo.TextChanged += txbBatchNo_TextChanged;
            txbBatchNo.Enter += txbBatchNo_Enter;
            txbBatchNo.Leave += txbBatchNo_Leave;
            // 
            // txbBoxID
            // 
            txbBoxID.CharacterCasing = CharacterCasing.Upper;
            txbBoxID.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txbBoxID.Location = new Point(292, 101);
            txbBoxID.Name = "txbBoxID";
            txbBoxID.Size = new Size(250, 21);
            txbBoxID.TabIndex = 1;
            txbBoxID.TextChanged += txbBoxID_TextChanged;
            txbBoxID.Enter += txbBoxID_Enter;
            txbBoxID.Leave += txbBoxID_Leave;
            // 
            // txbRefNo
            // 
            txbRefNo.CharacterCasing = CharacterCasing.Upper;
            txbRefNo.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txbRefNo.Location = new Point(9, 144);
            txbRefNo.Name = "txbRefNo";
            txbRefNo.Size = new Size(533, 21);
            txbRefNo.TabIndex = 2;
            txbRefNo.TextChanged += txbRefNo_TextChanged;
            txbRefNo.Enter += txbRefNo_Enter;
            txbRefNo.Leave += txbRefNo_Leave;
            txbRefNo.PreviewKeyDown += txbRefNo_PreviewKeyDown;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.Black;
            btnInsert.Cursor = Cursors.Hand;
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(440, 467);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(102, 36);
            btnInsert.TabIndex = 3;
            btnInsert.TabStop = false;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += btnInsert_Click;
            btnInsert.MouseEnter += btnInsert_MouseEnter;
            btnInsert.MouseLeave += btnInsert_MouseLeave;
            // 
            // btnMaintenance
            // 
            btnMaintenance.BackColor = Color.Black;
            btnMaintenance.Cursor = Cursors.Hand;
            btnMaintenance.FlatStyle = FlatStyle.Flat;
            btnMaintenance.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnMaintenance.ForeColor = Color.White;
            btnMaintenance.Location = new Point(332, 467);
            btnMaintenance.Name = "btnMaintenance";
            btnMaintenance.Size = new Size(102, 36);
            btnMaintenance.TabIndex = 4;
            btnMaintenance.TabStop = false;
            btnMaintenance.Text = "Maintenance";
            btnMaintenance.UseVisualStyleBackColor = false;
            btnMaintenance.Click += btnMaintenance_Click;
            btnMaintenance.MouseEnter += btnMaintenance_MouseEnter;
            btnMaintenance.MouseLeave += btnMaintenance_MouseLeave;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Black;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(224, 467);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(102, 36);
            btnSearch.TabIndex = 5;
            btnSearch.TabStop = false;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            btnSearch.MouseEnter += btnSearch_MouseEnter;
            btnSearch.MouseLeave += btnSearch_MouseLeave;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(9, 36);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(532, 47);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "Bespoke Project - Home";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBatchNo
            // 
            lblBatchNo.AutoSize = true;
            lblBatchNo.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblBatchNo.Location = new Point(9, 83);
            lblBatchNo.Name = "lblBatchNo";
            lblBatchNo.Size = new Size(99, 15);
            lblBatchNo.TabIndex = 8;
            lblBatchNo.Text = "1. Batch Number";
            // 
            // lblRefNo
            // 
            lblRefNo.AutoSize = true;
            lblRefNo.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblRefNo.Location = new Point(9, 126);
            lblRefNo.Name = "lblRefNo";
            lblRefNo.Size = new Size(125, 15);
            lblRefNo.TabIndex = 9;
            lblRefNo.Text = "3. Reference Number";
            // 
            // lblBagID
            // 
            lblBagID.AutoSize = true;
            lblBagID.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblBagID.Location = new Point(292, 83);
            lblBagID.Name = "lblBagID";
            lblBagID.Size = new Size(57, 15);
            lblBagID.TabIndex = 10;
            lblBagID.Text = "2. Bag ID";
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
            resultsTable.Location = new Point(9, 229);
            resultsTable.MinimumSize = new Size(10, 0);
            resultsTable.Name = "resultsTable";
            resultsTable.ReadOnly = true;
            resultsTable.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            resultsTable.RowHeadersVisible = false;
            resultsTable.RowTemplate.Height = 25;
            resultsTable.Size = new Size(533, 232);
            resultsTable.TabIndex = 11;
            resultsTable.TabStop = false;
            resultsTable.CellFormatting += resultsTable_CellFormatting;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblUserName.Location = new Point(3, 31);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(69, 14);
            lblUserName.TabIndex = 12;
            lblUserName.Text = "UserName";
            // 
            // lblDupe
            // 
            lblDupe.AutoSize = true;
            lblDupe.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDupe.ForeColor = Color.Red;
            lblDupe.Location = new Point(9, 177);
            lblDupe.Name = "lblDupe";
            lblDupe.Size = new Size(60, 15);
            lblDupe.TabIndex = 13;
            lblDupe.Text = "Duplicate";
            lblDupe.Visible = false;
            // 
            // lblCount
            // 
            lblCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCount.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCount.ImageAlign = ContentAlignment.MiddleRight;
            lblCount.Location = new Point(402, 177);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(139, 19);
            lblCount.TabIndex = 14;
            lblCount.Text = "User Count: 0";
            lblCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Black;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(117, 467);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(102, 36);
            btnClear.TabIndex = 15;
            btnClear.TabStop = false;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            btnClear.MouseEnter += btnClear_MouseEnter;
            btnClear.MouseLeave += btnClear_MouseLeave;
            // 
            // lblBatchCounter
            // 
            lblBatchCounter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBatchCounter.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblBatchCounter.ImageAlign = ContentAlignment.MiddleRight;
            lblBatchCounter.Location = new Point(389, 211);
            lblBatchCounter.Name = "lblBatchCounter";
            lblBatchCounter.Size = new Size(152, 15);
            lblBatchCounter.TabIndex = 16;
            lblBatchCounter.Text = "Batch Count: 0";
            lblBatchCounter.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBoxCount
            // 
            lblBoxCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBoxCount.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblBoxCount.ImageAlign = ContentAlignment.MiddleRight;
            lblBoxCount.Location = new Point(389, 196);
            lblBoxCount.Name = "lblBoxCount";
            lblBoxCount.Size = new Size(152, 15);
            lblBoxCount.TabIndex = 17;
            lblBoxCount.Text = "Bag Count: 0";
            lblBoxCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblLastScan
            // 
            lblLastScan.AutoSize = true;
            lblLastScan.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblLastScan.Location = new Point(9, 211);
            lblLastScan.Name = "lblLastScan";
            lblLastScan.Size = new Size(67, 15);
            lblLastScan.TabIndex = 18;
            lblLastScan.Text = "Last Input: ";
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.White;
            lblStatus.Font = new Font("Arial", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.Silver;
            lblStatus.Location = new Point(9, 511);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(532, 15);
            lblStatus.TabIndex = 19;
            lblStatus.Text = "Status";
            lblStatus.Click += lblStatus_Click;
            lblStatus.MouseEnter += lblStatus_MouseEnter;
            lblStatus.MouseLeave += lblStatus_MouseLeave;
            // 
            // pbLogo
            // 
            pbLogo.Image = BespokeProject_2.Properties.Resources.BespokeProject_2_Logo;
            pbLogo.Location = new Point(482, 41);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(60, 57);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 20;
            pbLogo.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, formsToolStripMenuItem, editToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(556, 24);
            menuStrip1.TabIndex = 21;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reportsToolStripMenuItem, closeToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(39, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportToolStripMenuItem, breakdownToolStripMenuItem, labelGeneratorToolStripMenuItem, moreToolStripMenuItem });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(121, 22);
            reportsToolStripMenuItem.Text = "Reports";
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(168, 22);
            exportToolStripMenuItem.Text = "Export";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // breakdownToolStripMenuItem
            // 
            breakdownToolStripMenuItem.Name = "breakdownToolStripMenuItem";
            breakdownToolStripMenuItem.Size = new Size(168, 22);
            breakdownToolStripMenuItem.Text = "Breakdown";
            breakdownToolStripMenuItem.Click += breakdownToolStripMenuItem_Click;
            // 
            // labelGeneratorToolStripMenuItem
            // 
            labelGeneratorToolStripMenuItem.Name = "labelGeneratorToolStripMenuItem";
            labelGeneratorToolStripMenuItem.Size = new Size(168, 22);
            labelGeneratorToolStripMenuItem.Text = "Label Generator";
            labelGeneratorToolStripMenuItem.Click += labelGeneratorToolStripMenuItem_Click;
            // 
            // moreToolStripMenuItem
            // 
            moreToolStripMenuItem.Name = "moreToolStripMenuItem";
            moreToolStripMenuItem.Size = new Size(168, 22);
            moreToolStripMenuItem.Text = "More...";
            moreToolStripMenuItem.Click += moreToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(121, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // formsToolStripMenuItem
            // 
            formsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { searchToolStripMenuItem, maintenanceToolStripMenuItem });
            formsToolStripMenuItem.Name = "formsToolStripMenuItem";
            formsToolStripMenuItem.Size = new Size(56, 20);
            formsToolStripMenuItem.Text = "Forms";
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(147, 22);
            searchToolStripMenuItem.Text = "Search";
            searchToolStripMenuItem.Click += searchToolStripMenuItem_Click;
            // 
            // maintenanceToolStripMenuItem
            // 
            maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            maintenanceToolStripMenuItem.Size = new Size(147, 22);
            maintenanceToolStripMenuItem.Text = "Maintenance";
            maintenanceToolStripMenuItem.Click += maintenanceToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { insertToolStripMenuItem, clearToolStripMenuItem, exceptionsToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(42, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // insertToolStripMenuItem
            // 
            insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            insertToolStripMenuItem.Size = new Size(138, 22);
            insertToolStripMenuItem.Text = "Insert";
            insertToolStripMenuItem.Click += insertToolStripMenuItem_Click;
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(138, 22);
            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.Click += clearToolStripMenuItem_Click;
            // 
            // exceptionsToolStripMenuItem
            // 
            exceptionsToolStripMenuItem.Name = "exceptionsToolStripMenuItem";
            exceptionsToolStripMenuItem.Size = new Size(138, 22);
            exceptionsToolStripMenuItem.Text = "Exceptions";
            exceptionsToolStripMenuItem.Click += exceptionsToolStripMenuItem_Click;
            // 
            // lblPraise
            // 
            lblPraise.BackColor = Color.Black;
            lblPraise.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPraise.ForeColor = Color.White;
            lblPraise.Location = new Point(255, 31);
            lblPraise.Name = "lblPraise";
            lblPraise.Size = new Size(248, 14);
            lblPraise.TabIndex = 22;
            lblPraise.Text = "Praise";
            lblPraise.Visible = false;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Black;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(9, 467);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(102, 36);
            btnExit.TabIndex = 6;
            btnExit.TabStop = false;
            btnExit.Text = "Close";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            btnExit.MouseEnter += btnExit_MouseEnter;
            btnExit.MouseLeave += btnExit_MouseLeave;
            // 
            // sessionTimer
            // 
            sessionTimer.Interval = 600000;
            sessionTimer.Tick += sessionTimer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(556, 531);
            ControlBox = false;
            Controls.Add(btnExit);
            Controls.Add(lblPraise);
            Controls.Add(pbLogo);
            Controls.Add(lblStatus);
            Controls.Add(lblLastScan);
            Controls.Add(lblBoxCount);
            Controls.Add(lblBatchCounter);
            Controls.Add(btnClear);
            Controls.Add(lblCount);
            Controls.Add(lblDupe);
            Controls.Add(lblUserName);
            Controls.Add(resultsTable);
            Controls.Add(lblBagID);
            Controls.Add(lblRefNo);
            Controls.Add(lblBatchNo);
            Controls.Add(lblTitle);
            Controls.Add(btnSearch);
            Controls.Add(btnMaintenance);
            Controls.Add(btnInsert);
            Controls.Add(txbRefNo);
            Controls.Add(txbBoxID);
            Controls.Add(txbBatchNo);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bespoke Project - Home";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)resultsTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbBatchNo;
        private TextBox txbBoxID;
        private TextBox txbRefNo;
        private Button btnInsert;
        private Button btnMaintenance;
        private Button btnSearch;
        private Label lblTitle;
        private Label lblBatchNo;
        private Label lblRefNo;
        private Label lblBagID;
        private DataGridView resultsTable;
        private Label lblUserName;
        private Label lblDupe;
        private Label lblCount;
        private Button btnClear;
        private Label lblBatchCounter;
        private Label lblBoxCount;
        private Label lblLastScan;
        private Label lblStatus;
        private PictureBox pbLogo;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem breakdownToolStripMenuItem;
        private ToolStripMenuItem moreToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem formsToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripMenuItem maintenanceToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem insertToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem labelGeneratorToolStripMenuItem;
        private Label lblPraise;
        private Button btnExit;
        private ToolStripMenuItem exceptionsToolStripMenuItem;
        private System.Windows.Forms.Timer sessionTimer;
    }
}