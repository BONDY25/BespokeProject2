namespace BespokeProject_2
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            pbLogo = new PictureBox();
            btnExit = new Button();
            btnCustom = new Button();
            btnPlate = new Button();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // pbLogo
            // 
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(24, 12);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(258, 240);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 6;
            pbLogo.TabStop = false;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Black;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(12, 542);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(107, 50);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            btnExit.MouseEnter += btnExit_MouseEnter;
            btnExit.MouseLeave += btnExit_MouseLeave;
            // 
            // btnCustom
            // 
            btnCustom.BackColor = Color.Black;
            btnCustom.Cursor = Cursors.Hand;
            btnCustom.FlatStyle = FlatStyle.Flat;
            btnCustom.Font = new Font("Arial Rounded MT Bold", 20F, FontStyle.Regular, GraphicsUnit.Point);
            btnCustom.ForeColor = Color.White;
            btnCustom.Location = new Point(12, 268);
            btnCustom.Name = "btnCustom";
            btnCustom.Size = new Size(285, 131);
            btnCustom.TabIndex = 1;
            btnCustom.Text = "Custom Receipt";
            btnCustom.UseVisualStyleBackColor = false;
            btnCustom.Click += btnCustom_Click;
            btnCustom.MouseEnter += btnCustom_MouseEnter;
            btnCustom.MouseLeave += btnCustom_MouseLeave;
            // 
            // btnPlate
            // 
            btnPlate.BackColor = Color.Black;
            btnPlate.Cursor = Cursors.Hand;
            btnPlate.FlatStyle = FlatStyle.Flat;
            btnPlate.Font = new Font("Arial Rounded MT Bold", 20F, FontStyle.Regular, GraphicsUnit.Point);
            btnPlate.ForeColor = Color.White;
            btnPlate.Location = new Point(12, 405);
            btnPlate.Name = "btnPlate";
            btnPlate.Size = new Size(285, 131);
            btnPlate.TabIndex = 2;
            btnPlate.Text = "License Plate Entry";
            btnPlate.UseVisualStyleBackColor = false;
            btnPlate.Click += btnPlate_Click;
            btnPlate.MouseEnter += btnPlate_MouseEnter;
            btnPlate.MouseLeave += btnPlate_MouseLeave;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(309, 601);
            Controls.Add(pbLogo);
            Controls.Add(btnPlate);
            Controls.Add(btnCustom);
            Controls.Add(btnExit);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu_Form";
            FormClosing += MenuForm_FormClosing;
            Load += MenuForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbLogo;
        private Button btnExit;
        private Button btnCustom;
        private Button btnPlate;
    }
}