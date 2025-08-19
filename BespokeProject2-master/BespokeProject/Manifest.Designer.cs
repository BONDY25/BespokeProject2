namespace BespokeProject_2
{
    partial class Manifest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manifest));
            dgHistory = new DataGridView();
            pbLogo = new PictureBox();
            btnClose = new Button();
            txbPlate = new TextBox();
            label1 = new Label();
            btnComplete = new Button();
            btnClear = new Button();
            lblLocation = new Label();
            lblStatus = new Label();
            lblTotal = new Label();
            btnCancel = new Button();
            btnOpenPlate = new Button();
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
            dgHistory.Location = new Point(12, 197);
            dgHistory.MinimumSize = new Size(11, 0);
            dgHistory.Name = "dgHistory";
            dgHistory.ReadOnly = true;
            dgHistory.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgHistory.RowHeadersVisible = false;
            dgHistory.RowTemplate.Height = 25;
            dgHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgHistory.Size = new Size(720, 217);
            dgHistory.TabIndex = 5;
            dgHistory.TabStop = false;
            dgHistory.CellFormatting += dgHistory_CellFormatting;
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
            // btnClose
            // 
            btnClose.BackColor = Color.Black;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(7, 530);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(117, 34);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            btnClose.MouseEnter += btnClose_MouseEnter;
            btnClose.MouseLeave += btnClose_MouseLeave;
            // 
            // txbPlate
            // 
            txbPlate.CharacterCasing = CharacterCasing.Upper;
            txbPlate.Cursor = Cursors.IBeam;
            txbPlate.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txbPlate.Location = new Point(297, 76);
            txbPlate.MaxLength = 255;
            txbPlate.Name = "txbPlate";
            txbPlate.Size = new Size(437, 35);
            txbPlate.TabIndex = 1;
            txbPlate.Enter += txbPlate_Enter;
            txbPlate.Leave += txbPlate_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(297, 59);
            label1.Name = "label1";
            label1.Size = new Size(84, 14);
            label1.TabIndex = 9;
            label1.Text = "License Plate";
            // 
            // btnComplete
            // 
            btnComplete.BackColor = Color.Black;
            btnComplete.Cursor = Cursors.Hand;
            btnComplete.FlatStyle = FlatStyle.Flat;
            btnComplete.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnComplete.ForeColor = Color.White;
            btnComplete.Location = new Point(230, 420);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(284, 34);
            btnComplete.TabIndex = 2;
            btnComplete.Text = "Complete";
            btnComplete.UseVisualStyleBackColor = false;
            btnComplete.Click += btnComplete_Click;
            btnComplete.MouseEnter += btnComplete_MouseEnter;
            btnComplete.MouseLeave += btnComplete_MouseLeave;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Black;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(130, 530);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(117, 34);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            btnClear.MouseEnter += btnClear_MouseEnter;
            btnClear.MouseLeave += btnClear_MouseLeave;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(12, 180);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(60, 14);
            lblLocation.TabIndex = 10;
            lblLocation.Text = "Location:";
            lblLocation.Visible = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 166);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(48, 14);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Status:";
            lblStatus.Visible = false;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 152);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(127, 14);
            lblTotal.TabIndex = 10;
            lblTotal.Text = "Total Consignments:";
            lblTotal.Visible = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Black;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Enabled = false;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(230, 460);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(284, 34);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Visible = false;
            btnCancel.Click += btnCancel_Click;
            btnCancel.MouseEnter += btnCancel_MouseEnter;
            btnCancel.MouseLeave += btnCancel_MouseLeave;
            // 
            // btnOpenPlate
            // 
            btnOpenPlate.BackColor = Color.Black;
            btnOpenPlate.Cursor = Cursors.Hand;
            btnOpenPlate.FlatStyle = FlatStyle.Flat;
            btnOpenPlate.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnOpenPlate.ForeColor = Color.White;
            btnOpenPlate.Location = new Point(531, 12);
            btnOpenPlate.Name = "btnOpenPlate";
            btnOpenPlate.Size = new Size(205, 34);
            btnOpenPlate.TabIndex = 3;
            btnOpenPlate.Text = "View Open License Plates";
            btnOpenPlate.UseVisualStyleBackColor = false;
            btnOpenPlate.Click += btnOpenPlate_Click;
            btnOpenPlate.MouseEnter += btnOpenPlate_MouseEnter;
            btnOpenPlate.MouseLeave += btnOpenPlate_MouseLeave;
            // 
            // Manifest
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(748, 576);
            ControlBox = false;
            Controls.Add(lblTotal);
            Controls.Add(lblStatus);
            Controls.Add(lblLocation);
            Controls.Add(btnCancel);
            Controls.Add(btnComplete);
            Controls.Add(label1);
            Controls.Add(txbPlate);
            Controls.Add(dgHistory);
            Controls.Add(btnOpenPlate);
            Controls.Add(btnClear);
            Controls.Add(btnClose);
            Controls.Add(pbLogo);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Manifest";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manifest";
            FormClosing += Manifest_FormClosing;
            Load += Manifest_Load;
            KeyDown += Manifest_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgHistory).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgHistory;
        private PictureBox pbLogo;
        private Button btnClose;
        private TextBox txbPlate;
        private Label label1;
        private Button btnComplete;
        private Button btnClear;
        private Label lblLocation;
        private Label lblStatus;
        private Label lblTotal;
        private Button btnCancel;
        private Button btnOpenPlate;
    }
}