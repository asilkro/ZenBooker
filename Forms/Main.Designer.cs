namespace ZenoBook.Forms
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            logoutBtn = new Button();
            SuspendLayout();
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(672, 499);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(100, 50);
            logoutBtn.TabIndex = 1;
            logoutBtn.Text = "Log Out";
            logoutBtn.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(logoutBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            Text = "ZTH - ZenoBook";
            ResumeLayout(false);
        }

        #endregion

        private Button logoutBtn;
    }
}