namespace BespokeProject_2
{
    partial class CarrierManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarrierManagement));
            btnClose = new Button();
            txbCarrier = new TextBox();
            txbDescr = new TextBox();
            txbPrefix = new TextBox();
            cbStatus = new ComboBox();
            cbColour = new ComboBox();
            btnSave = new Button();
            btnClear = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            pbLogo = new PictureBox();
            lblColor = new Label();
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
            btnClose.Location = new Point(12, 283);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(69, 34);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            btnClose.MouseEnter += btnClose_MouseEnter;
            btnClose.MouseLeave += btnClose_MouseLeave;
            // 
            // txbCarrier
            // 
            txbCarrier.CharacterCasing = CharacterCasing.Upper;
            txbCarrier.Cursor = Cursors.IBeam;
            txbCarrier.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbCarrier.Location = new Point(12, 98);
            txbCarrier.MaxLength = 6;
            txbCarrier.Name = "txbCarrier";
            txbCarrier.Size = new Size(291, 26);
            txbCarrier.TabIndex = 1;
            txbCarrier.Enter += txbCarrier_Enter;
            txbCarrier.Leave += txbCarrier_Leave;
            // 
            // txbDescr
            // 
            txbDescr.Cursor = Cursors.IBeam;
            txbDescr.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbDescr.Location = new Point(12, 143);
            txbDescr.MaxLength = 255;
            txbDescr.Name = "txbDescr";
            txbDescr.Size = new Size(291, 26);
            txbDescr.TabIndex = 2;
            txbDescr.Enter += txbDescr_Enter;
            txbDescr.Leave += txbDescr_Leave;
            // 
            // txbPrefix
            // 
            txbPrefix.CharacterCasing = CharacterCasing.Upper;
            txbPrefix.Cursor = Cursors.IBeam;
            txbPrefix.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbPrefix.Location = new Point(12, 189);
            txbPrefix.MaxLength = 3;
            txbPrefix.Name = "txbPrefix";
            txbPrefix.Size = new Size(119, 26);
            txbPrefix.TabIndex = 3;
            txbPrefix.Enter += txbPrefix_Enter;
            txbPrefix.Leave += txbPrefix_Leave;
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(151, 189);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(152, 26);
            cbStatus.TabIndex = 4;
            cbStatus.Enter += cbStatus_Enter;
            cbStatus.Leave += cbStatus_Leave;
            // 
            // cbColour
            // 
            cbColour.DropDownStyle = ComboBoxStyle.DropDownList;
            cbColour.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbColour.FormattingEnabled = true;
            cbColour.Location = new Point(12, 235);
            cbColour.Name = "cbColour";
            cbColour.Size = new Size(199, 26);
            cbColour.TabIndex = 5;
            cbColour.TextChanged += cbColour_TextChanged;
            cbColour.Enter += cbColour_Enter;
            cbColour.Leave += cbColour_Leave;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Black;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(234, 283);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(69, 34);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            btnSave.MouseEnter += btnSave_MouseEnter;
            btnSave.MouseLeave += btnSave_MouseLeave;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Black;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(87, 283);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(69, 34);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            btnClear.MouseEnter += btnClear_MouseEnter;
            btnClear.MouseLeave += btnClear_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 81);
            label1.Name = "label1";
            label1.Size = new Size(48, 14);
            label1.TabIndex = 9;
            label1.Text = "Carrier";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 126);
            label2.Name = "label2";
            label2.Size = new Size(74, 14);
            label2.TabIndex = 9;
            label2.Text = "Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 172);
            label3.Name = "label3";
            label3.Size = new Size(40, 14);
            label3.TabIndex = 9;
            label3.Text = "Prefix";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(151, 172);
            label4.Name = "label4";
            label4.Size = new Size(44, 14);
            label4.TabIndex = 9;
            label4.Text = "Status";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 218);
            label5.Name = "label5";
            label5.Size = new Size(45, 14);
            label5.TabIndex = 9;
            label5.Text = "Colour";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(92, 29);
            label6.Name = "label6";
            label6.Size = new Size(190, 26);
            label6.TabIndex = 9;
            label6.Text = "Carrier Manager";
            // 
            // pbLogo
            // 
            pbLogo.Anchor = AnchorStyles.None;
            pbLogo.Image = Properties.Resources.BespokeProject_2_Logo;
            pbLogo.Location = new Point(12, 12);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(74, 66);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 6;
            pbLogo.TabStop = false;
            // 
            // lblColor
            // 
            lblColor.BorderStyle = BorderStyle.FixedSingle;
            lblColor.Cursor = Cursors.No;
            lblColor.ForeColor = Color.Black;
            lblColor.Location = new Point(217, 235);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(86, 26);
            lblColor.TabIndex = 10;
            // 
            // CarrierManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(315, 330);
            ControlBox = false;
            Controls.Add(lblColor);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(cbColour);
            Controls.Add(cbStatus);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Controls.Add(txbPrefix);
            Controls.Add(txbDescr);
            Controls.Add(txbCarrier);
            Controls.Add(pbLogo);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CarrierManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CarrierManagement";
            Load += CarrierManagement_Load;
            KeyDown += CarrierManagement_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private TextBox txbCarrier;
        private TextBox txbDescr;
        private TextBox txbPrefix;
        private ComboBox cbStatus;
        private ComboBox cbColour;
        private Button btnSave;
        private Button btnClear;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private PictureBox pbLogo;
        private Label lblColor;
    }
}