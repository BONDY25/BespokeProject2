namespace BespokeProject_2
{
    partial class LocationManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocationManager));
            btnClose = new Button();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            txbLocation = new TextBox();
            cbStatus = new ComboBox();
            txbDescr = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnClear = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Black;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(12, 176);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(69, 34);
            btnClose.TabIndex = 9;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            btnClose.MouseEnter += btnClose_MouseEnter;
            btnClose.MouseLeave += btnClose_MouseLeave;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.BespokeProject_2_Logo;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(74, 66);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(92, 33);
            label6.Name = "label6";
            label6.Size = new Size(204, 26);
            label6.TabIndex = 12;
            label6.Text = "Location Manager";
            // 
            // txbLocation
            // 
            txbLocation.CharacterCasing = CharacterCasing.Upper;
            txbLocation.Cursor = Cursors.IBeam;
            txbLocation.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbLocation.Location = new Point(12, 98);
            txbLocation.MaxLength = 6;
            txbLocation.Name = "txbLocation";
            txbLocation.Size = new Size(291, 26);
            txbLocation.TabIndex = 13;
            txbLocation.Enter += txbLocation_Enter;
            txbLocation.Leave += txbLocation_Leave;
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(309, 98);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(152, 26);
            cbStatus.TabIndex = 11;
            cbStatus.Enter += cbStatus_Enter;
            cbStatus.Leave += cbStatus_Leave;
            // 
            // txbDescr
            // 
            txbDescr.Cursor = Cursors.IBeam;
            txbDescr.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbDescr.Location = new Point(12, 144);
            txbDescr.MaxLength = 255;
            txbDescr.Name = "txbDescr";
            txbDescr.Size = new Size(449, 26);
            txbDescr.TabIndex = 14;
            txbDescr.Enter += txbDescr_Enter;
            txbDescr.Leave += txbDescr_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 127);
            label1.Name = "label1";
            label1.Size = new Size(74, 14);
            label1.TabIndex = 11;
            label1.Text = "Description";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(309, 81);
            label2.Name = "label2";
            label2.Size = new Size(44, 14);
            label2.TabIndex = 11;
            label2.Text = "Status";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 81);
            label3.Name = "label3";
            label3.Size = new Size(56, 14);
            label3.TabIndex = 15;
            label3.Text = "Location";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Black;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(87, 176);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(69, 34);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            btnClear.MouseEnter += btnClear_MouseEnter;
            btnClear.MouseLeave += btnClear_MouseLeave;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Black;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(392, 176);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(69, 34);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            btnSave.MouseEnter += btnSave_MouseEnter;
            btnSave.MouseLeave += btnSave_MouseLeave;
            // 
            // LocationManager
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(470, 219);
            ControlBox = false;
            Controls.Add(btnSave);
            Controls.Add(btnClear);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txbDescr);
            Controls.Add(cbStatus);
            Controls.Add(txbLocation);
            Controls.Add(label6);
            Controls.Add(pictureBox1);
            Controls.Add(btnClose);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LocationManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LocationManager";
            Load += LocationManager_Load;
            KeyDown += LocationManagement_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private PictureBox pictureBox1;
        private Label label6;
        private TextBox txbLocation;
        private ComboBox cbStatus;
        private TextBox txbDescr;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnClear;
        private Button btnSave;
    }
}