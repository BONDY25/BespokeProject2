namespace BespokeProject_2
{
    partial class InputEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputEdit));
            pbLogo = new PictureBox();
            msMain = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            licensePlateGenerationToolStripMenuItem = new ToolStripMenuItem();
            licensePlateDetailToolStripMenuItem = new ToolStripMenuItem();
            misInjectionsToolStripMenuItem = new ToolStripMenuItem();
            dashboardToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            openLicensePlatesToolStripMenuItem = new ToolStripMenuItem();
            consignmentsToolStripMenuItem = new ToolStripMenuItem();
            misInjectionsToolStripMenuItem1 = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            manifestsToolStripMenuItem = new ToolStripMenuItem();
            editModeToolStripMenuItem = new ToolStripMenuItem();
            carrierManagementToolStripMenuItem = new ToolStripMenuItem();
            locationManagementToolStripMenuItem = new ToolStripMenuItem();
            txbConsign = new TextBox();
            txbPlate = new TextBox();
            lblConsign = new Label();
            lblPlate = new Label();
            cbLocation = new ComboBox();
            lblLocation = new Label();
            rbtnInput = new RadioButton();
            rbtnEdit = new RadioButton();
            lblMode = new Label();
            dgHistory = new DataGridView();
            btnClose = new Button();
            btnFun = new Button();
            lblTitle = new Label();
            lblInstructions = new Label();
            lblStatus = new Label();
            btnMisInject = new Button();
            cntMain = new Panel();
            timerMain = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgHistory).BeginInit();
            cntMain.SuspendLayout();
            SuspendLayout();
            // 
            // pbLogo
            // 
            pbLogo.Cursor = Cursors.Hand;
            pbLogo.Image = Properties.Resources.BespokeProject_2_Logo;
            pbLogo.Location = new Point(613, 23);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(110, 100);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 6;
            pbLogo.TabStop = false;
            pbLogo.Click += pbLogo_Click;
            pbLogo.MouseEnter += pbLogo_MouseEnter;
            pbLogo.MouseLeave += pbLogo_MouseLeave;
            // 
            // msMain
            // 
            msMain.BackColor = Color.Black;
            msMain.BackgroundImageLayout = ImageLayout.None;
            msMain.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            msMain.ForeColor = Color.White;
            msMain.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
            msMain.Location = new Point(0, 0);
            msMain.Name = "msMain";
            msMain.Padding = new Padding(7, 2, 0, 2);
            msMain.Size = new Size(736, 24);
            msMain.TabIndex = 7;
            msMain.Text = "msMain";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reportsToolStripMenuItem, searchToolStripMenuItem, closeToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(39, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { licensePlateGenerationToolStripMenuItem, licensePlateDetailToolStripMenuItem, misInjectionsToolStripMenuItem, dashboardToolStripMenuItem });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(180, 22);
            reportsToolStripMenuItem.Text = "Reports";
            // 
            // licensePlateGenerationToolStripMenuItem
            // 
            licensePlateGenerationToolStripMenuItem.Name = "licensePlateGenerationToolStripMenuItem";
            licensePlateGenerationToolStripMenuItem.Size = new Size(218, 22);
            licensePlateGenerationToolStripMenuItem.Text = "License Plate Generation";
            licensePlateGenerationToolStripMenuItem.Click += licensePlateGenerationToolStripMenuItem_Click;
            // 
            // licensePlateDetailToolStripMenuItem
            // 
            licensePlateDetailToolStripMenuItem.Name = "licensePlateDetailToolStripMenuItem";
            licensePlateDetailToolStripMenuItem.Size = new Size(218, 22);
            licensePlateDetailToolStripMenuItem.Text = "License Plate Detail";
            licensePlateDetailToolStripMenuItem.Click += licensePlateDetailToolStripMenuItem_Click;
            // 
            // misInjectionsToolStripMenuItem
            // 
            misInjectionsToolStripMenuItem.Name = "misInjectionsToolStripMenuItem";
            misInjectionsToolStripMenuItem.Size = new Size(218, 22);
            misInjectionsToolStripMenuItem.Text = "Mis-Injections";
            misInjectionsToolStripMenuItem.Click += misInjectionsToolStripMenuItem_Click;
            // 
            // dashboardToolStripMenuItem
            // 
            dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            dashboardToolStripMenuItem.Size = new Size(218, 22);
            dashboardToolStripMenuItem.Text = "Dashboard";
            dashboardToolStripMenuItem.Click += dashboardToolStripMenuItem_Click;
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openLicensePlatesToolStripMenuItem, consignmentsToolStripMenuItem, misInjectionsToolStripMenuItem1 });
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(180, 22);
            searchToolStripMenuItem.Text = "Search";
            // 
            // openLicensePlatesToolStripMenuItem
            // 
            openLicensePlatesToolStripMenuItem.Name = "openLicensePlatesToolStripMenuItem";
            openLicensePlatesToolStripMenuItem.Size = new Size(193, 22);
            openLicensePlatesToolStripMenuItem.Text = "Open License Plates";
            openLicensePlatesToolStripMenuItem.Click += openLicensePlatesToolStripMenuItem_Click;
            // 
            // consignmentsToolStripMenuItem
            // 
            consignmentsToolStripMenuItem.Name = "consignmentsToolStripMenuItem";
            consignmentsToolStripMenuItem.Size = new Size(193, 22);
            consignmentsToolStripMenuItem.Text = "Consignment(s)";
            consignmentsToolStripMenuItem.Click += consignmentsToolStripMenuItem_Click;
            // 
            // misInjectionsToolStripMenuItem1
            // 
            misInjectionsToolStripMenuItem1.Name = "misInjectionsToolStripMenuItem1";
            misInjectionsToolStripMenuItem1.Size = new Size(193, 22);
            misInjectionsToolStripMenuItem1.Text = "Mis-Injections";
            misInjectionsToolStripMenuItem1.Click += misInjectionsToolStripMenuItem1_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(180, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { manifestsToolStripMenuItem, editModeToolStripMenuItem, carrierManagementToolStripMenuItem, locationManagementToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(42, 20);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // manifestsToolStripMenuItem
            // 
            manifestsToolStripMenuItem.Name = "manifestsToolStripMenuItem";
            manifestsToolStripMenuItem.Size = new Size(201, 22);
            manifestsToolStripMenuItem.Text = "Manifests";
            manifestsToolStripMenuItem.Click += manifestsToolStripMenuItem_Click;
            // 
            // editModeToolStripMenuItem
            // 
            editModeToolStripMenuItem.Name = "editModeToolStripMenuItem";
            editModeToolStripMenuItem.Size = new Size(201, 22);
            editModeToolStripMenuItem.Text = "Edit Mode";
            editModeToolStripMenuItem.Click += editModeToolStripMenuItem_Click;
            // 
            // carrierManagementToolStripMenuItem
            // 
            carrierManagementToolStripMenuItem.Name = "carrierManagementToolStripMenuItem";
            carrierManagementToolStripMenuItem.Size = new Size(201, 22);
            carrierManagementToolStripMenuItem.Text = "Carrier Management";
            carrierManagementToolStripMenuItem.Click += carrierManagementToolStripMenuItem_Click;
            // 
            // locationManagementToolStripMenuItem
            // 
            locationManagementToolStripMenuItem.Name = "locationManagementToolStripMenuItem";
            locationManagementToolStripMenuItem.Size = new Size(201, 22);
            locationManagementToolStripMenuItem.Text = "Location Management";
            locationManagementToolStripMenuItem.Click += locationManagementToolStripMenuItem_Click;
            // 
            // txbConsign
            // 
            txbConsign.CharacterCasing = CharacterCasing.Upper;
            txbConsign.Cursor = Cursors.IBeam;
            txbConsign.Font = new Font("Arial Rounded MT Bold", 30F, FontStyle.Regular, GraphicsUnit.Point);
            txbConsign.Location = new Point(47, 126);
            txbConsign.MaxLength = 255;
            txbConsign.Name = "txbConsign";
            txbConsign.Size = new Size(630, 54);
            txbConsign.TabIndex = 2;
            txbConsign.Enter += txbConsign_Enter;
            txbConsign.Leave += txbConsign_Leave;
            // 
            // txbPlate
            // 
            txbPlate.CharacterCasing = CharacterCasing.Upper;
            txbPlate.Cursor = Cursors.IBeam;
            txbPlate.Font = new Font("Arial Rounded MT Bold", 30F, FontStyle.Regular, GraphicsUnit.Point);
            txbPlate.Location = new Point(47, 200);
            txbPlate.MaxLength = 255;
            txbPlate.Name = "txbPlate";
            txbPlate.Size = new Size(630, 54);
            txbPlate.TabIndex = 3;
            txbPlate.Enter += txbPlate_Enter;
            txbPlate.Leave += txbPlate_Leave;
            txbPlate.PreviewKeyDown += txbPlate_PreviewKeyDown;
            // 
            // lblConsign
            // 
            lblConsign.AutoSize = true;
            lblConsign.Location = new Point(47, 109);
            lblConsign.Name = "lblConsign";
            lblConsign.Size = new Size(84, 14);
            lblConsign.TabIndex = 11;
            lblConsign.Text = "Consignment";
            // 
            // lblPlate
            // 
            lblPlate.AutoSize = true;
            lblPlate.Location = new Point(47, 183);
            lblPlate.Name = "lblPlate";
            lblPlate.Size = new Size(84, 14);
            lblPlate.TabIndex = 12;
            lblPlate.Text = "License Plate";
            // 
            // cbLocation
            // 
            cbLocation.BackColor = Color.White;
            cbLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLocation.FlatStyle = FlatStyle.System;
            cbLocation.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cbLocation.FormattingEnabled = true;
            cbLocation.Location = new Point(11, 39);
            cbLocation.Name = "cbLocation";
            cbLocation.Size = new Size(210, 25);
            cbLocation.TabIndex = 1;
            cbLocation.Enter += cbLocation_Enter;
            cbLocation.Leave += cbLocation_Leave;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(11, 22);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(56, 14);
            lblLocation.TabIndex = 9;
            lblLocation.Text = "Location";
            // 
            // rbtnInput
            // 
            rbtnInput.AutoSize = true;
            rbtnInput.Location = new Point(111, 92);
            rbtnInput.Name = "rbtnInput";
            rbtnInput.Size = new Size(55, 18);
            rbtnInput.TabIndex = 4;
            rbtnInput.TabStop = true;
            rbtnInput.Text = "Input";
            rbtnInput.UseVisualStyleBackColor = true;
            rbtnInput.CheckedChanged += rbtnInput_CheckedChanged;
            rbtnInput.Click += rbtnInput_Click;
            rbtnInput.Enter += rbtnInput_Enter;
            rbtnInput.Leave += rbtnInput_Leave;
            // 
            // rbtnEdit
            // 
            rbtnEdit.AutoSize = true;
            rbtnEdit.Location = new Point(57, 92);
            rbtnEdit.Name = "rbtnEdit";
            rbtnEdit.Size = new Size(48, 18);
            rbtnEdit.TabIndex = 5;
            rbtnEdit.TabStop = true;
            rbtnEdit.Text = "Edit";
            rbtnEdit.UseVisualStyleBackColor = true;
            rbtnEdit.CheckedChanged += rbtnEdit_CheckedChanged;
            rbtnEdit.Click += rbtnEdit_Click;
            rbtnEdit.Enter += rbtnEdit_Enter;
            rbtnEdit.Leave += rbtnEdit_Leave;
            // 
            // lblMode
            // 
            lblMode.AutoSize = true;
            lblMode.Location = new Point(12, 94);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(39, 14);
            lblMode.TabIndex = 10;
            lblMode.Text = "Mode";
            // 
            // dgHistory
            // 
            dgHistory.AllowUserToAddRows = false;
            dgHistory.AllowUserToDeleteRows = false;
            dgHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgHistory.BackgroundColor = Color.White;
            dgHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgHistory.Location = new Point(48, 285);
            dgHistory.MinimumSize = new Size(10, 0);
            dgHistory.Name = "dgHistory";
            dgHistory.ReadOnly = true;
            dgHistory.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgHistory.RowHeadersVisible = false;
            dgHistory.RowTemplate.Height = 25;
            dgHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgHistory.Size = new Size(630, 232);
            dgHistory.TabIndex = 8;
            dgHistory.TabStop = false;
            dgHistory.CellFormatting += dgHistory_CellFormatting;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Black;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(12, 523);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(102, 36);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            btnClose.MouseEnter += btnClose_MouseEnter;
            btnClose.MouseLeave += btnClose_MouseLeave;
            // 
            // btnFun
            // 
            btnFun.BackColor = Color.Black;
            btnFun.Cursor = Cursors.Hand;
            btnFun.FlatStyle = FlatStyle.Flat;
            btnFun.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnFun.ForeColor = Color.White;
            btnFun.Location = new Point(622, 523);
            btnFun.Name = "btnFun";
            btnFun.Size = new Size(102, 36);
            btnFun.TabIndex = 6;
            btnFun.Text = "Insert";
            btnFun.UseVisualStyleBackColor = false;
            btnFun.Click += btnFun_Click;
            btnFun.MouseEnter += btnFun_MouseEnter;
            btnFun.MouseLeave += btnFun_MouseLeave;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(206, 86);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(315, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "License Plate Entry";
            // 
            // lblInstructions
            // 
            lblInstructions.BackColor = Color.Black;
            lblInstructions.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblInstructions.ForeColor = Color.Yellow;
            lblInstructions.Location = new Point(237, 2);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(418, 24);
            lblInstructions.TabIndex = 2;
            lblInstructions.Text = "Instructions";
            lblInstructions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.White;
            lblStatus.Font = new Font("Arial", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.Silver;
            lblStatus.Location = new Point(12, 572);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(712, 15);
            lblStatus.TabIndex = 19;
            lblStatus.Text = "Status";
            lblStatus.MouseEnter += lblStatus_MouseEnter;
            lblStatus.MouseLeave += lblStatus_MouseLeave;
            // 
            // btnMisInject
            // 
            btnMisInject.BackColor = Color.Black;
            btnMisInject.Cursor = Cursors.Hand;
            btnMisInject.FlatStyle = FlatStyle.Flat;
            btnMisInject.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnMisInject.ForeColor = Color.White;
            btnMisInject.Location = new Point(420, 523);
            btnMisInject.Name = "btnMisInject";
            btnMisInject.Size = new Size(196, 36);
            btnMisInject.TabIndex = 20;
            btnMisInject.Text = "Mis-Injections";
            btnMisInject.UseVisualStyleBackColor = false;
            btnMisInject.Visible = false;
            btnMisInject.Click += btnMisInject_Click;
            btnMisInject.MouseEnter += btnMisInject_MouseEnter;
            btnMisInject.MouseLeave += btnMisInject_MouseLeave;
            // 
            // cntMain
            // 
            cntMain.BackColor = Color.White;
            cntMain.BorderStyle = BorderStyle.FixedSingle;
            cntMain.Controls.Add(lblInstructions);
            cntMain.Controls.Add(pbLogo);
            cntMain.Controls.Add(lblLocation);
            cntMain.Controls.Add(cbLocation);
            cntMain.Controls.Add(lblTitle);
            cntMain.Controls.Add(txbConsign);
            cntMain.Controls.Add(lblPlate);
            cntMain.Controls.Add(txbPlate);
            cntMain.Controls.Add(lblConsign);
            cntMain.Location = new Point(0, 22);
            cntMain.Name = "cntMain";
            cntMain.Size = new Size(736, 580);
            cntMain.TabIndex = 21;
            // 
            // timerMain
            // 
            timerMain.Interval = 300;
            timerMain.Tick += timerMain_Tick;
            // 
            // InputEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(736, 602);
            Controls.Add(btnMisInject);
            Controls.Add(btnFun);
            Controls.Add(btnClose);
            Controls.Add(rbtnEdit);
            Controls.Add(lblStatus);
            Controls.Add(rbtnInput);
            Controls.Add(lblMode);
            Controls.Add(msMain);
            Controls.Add(dgHistory);
            Controls.Add(cntMain);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = msMain;
            Name = "InputEdit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InputEdit";
            FormClosing += InputEdit_FormClosing;
            Load += InputEdit_Load;
            KeyDown += InputEdit_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgHistory).EndInit();
            cntMain.ResumeLayout(false);
            cntMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbLogo;
        private MenuStrip msMain;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private TextBox txbConsign;
        private TextBox txbPlate;
        private Label lblConsign;
        private Label lblPlate;
        private ComboBox cbLocation;
        private Label lblLocation;
        private RadioButton rbtnInput;
        private RadioButton rbtnEdit;
        private Label lblMode;
        private DataGridView dgHistory;
        private Button btnClose;
        private Button btnFun;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem licensePlateGenerationToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripMenuItem openLicensePlatesToolStripMenuItem;
        private ToolStripMenuItem consignmentsToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem manifestsToolStripMenuItem;
        private ToolStripMenuItem editModeToolStripMenuItem;
        private ToolStripMenuItem carrierManagementToolStripMenuItem;
        private ToolStripMenuItem locationManagementToolStripMenuItem;
        private Label lblTitle;
        private Label lblInstructions;
        private Label lblStatus;
        private Button btnMisInject;
        private ToolStripMenuItem licensePlateDetailToolStripMenuItem;
        private ToolStripMenuItem misInjectionsToolStripMenuItem;
        private ToolStripMenuItem misInjectionsToolStripMenuItem1;
        private Panel cntMain;
        private System.Windows.Forms.Timer timerMain;
        private ToolStripMenuItem dashboardToolStripMenuItem;
    }
}