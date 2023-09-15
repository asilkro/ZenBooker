namespace ZenoBook
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            exitBtn = new Button();
            loginBtn = new Button();
            logo = new PictureBox();
            loginTB = new TextBox();
            pwTB = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // exitBtn
            // 
            exitBtn.Location = new Point(663, 500);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(100, 50);
            exitBtn.TabIndex = 0;
            exitBtn.Text = "Exit";
            exitBtn.UseVisualStyleBackColor = true;
            exitBtn.Click += exitBtn_Click;
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(531, 448);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(100, 50);
            loginBtn.TabIndex = 1;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            // 
            // logo
            // 
            logo.Image = Properties.Resources.Zenobia_Transparent;
            logo.Location = new Point(192, 21);
            logo.Name = "logo";
            logo.Size = new Size(400, 400);
            logo.SizeMode = PictureBoxSizeMode.StretchImage;
            logo.TabIndex = 2;
            logo.TabStop = false;
            // 
            // loginTB
            // 
            loginTB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            loginTB.Location = new Point(192, 459);
            loginTB.Name = "loginTB";
            loginTB.PlaceholderText = "Login ID";
            loginTB.Size = new Size(150, 29);
            loginTB.TabIndex = 3;
            // 
            // pwTB
            // 
            pwTB.AsciiOnly = true;
            pwTB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            pwTB.Location = new Point(363, 459);
            pwTB.Name = "pwTB";
            pwTB.Size = new Size(150, 29);
            pwTB.TabIndex = 4;
            pwTB.UseSystemPasswordChar = true;
            // 
            // Login
            // 
            AcceptButton = loginBtn;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            CancelButton = exitBtn;
            ClientSize = new Size(780, 557);
            Controls.Add(pwTB);
            Controls.Add(loginTB);
            Controls.Add(logo);
            Controls.Add(loginBtn);
            Controls.Add(exitBtn);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ZenoBook - Login";
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button exitBtn;
        private Button loginBtn;
        private PictureBox logo;
        private TextBox loginTB;
        private MaskedTextBox pwTB;
    }
}