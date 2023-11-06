using System.ComponentModel;

namespace ZenoBook.Forms
{
    partial class AdminService
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminService));
            backBtn = new Button();
            saveBtn = new Button();
            serviceNameTB = new TextBox();
            serviceDescTB = new TextBox();
            serviceIdTB = new TextBox();
            SuspendLayout();
            // 
            // backBtn
            // 
            backBtn.Location = new Point(192, 226);
            backBtn.Margin = new Padding(1);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(75, 23);
            backBtn.TabIndex = 0;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.LightSteelBlue;
            saveBtn.Location = new Point(285, 226);
            saveBtn.Margin = new Padding(1);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(75, 23);
            saveBtn.TabIndex = 1;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // serviceNameTB
            // 
            serviceNameTB.Location = new Point(34, 80);
            serviceNameTB.Name = "serviceNameTB";
            serviceNameTB.PlaceholderText = "Service Name";
            serviceNameTB.Size = new Size(233, 23);
            serviceNameTB.TabIndex = 2;
            // 
            // serviceDescTB
            // 
            serviceDescTB.Location = new Point(34, 109);
            serviceDescTB.Name = "serviceDescTB";
            serviceDescTB.PlaceholderText = "Service Description";
            serviceDescTB.Size = new Size(326, 23);
            serviceDescTB.TabIndex = 3;
            // 
            // serviceIdTB
            // 
            serviceIdTB.Location = new Point(34, 51);
            serviceIdTB.Name = "serviceIdTB";
            serviceIdTB.PlaceholderText = "Service Id";
            serviceIdTB.Size = new Size(83, 23);
            serviceIdTB.TabIndex = 4;
            // 
            // AdminService
            // 
            AcceptButton = saveBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = backBtn;
            ClientSize = new Size(384, 261);
            Controls.Add(serviceIdTB);
            Controls.Add(serviceDescTB);
            Controls.Add(serviceNameTB);
            Controls.Add(saveBtn);
            Controls.Add(backBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminService";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ZTH - Admin - Service";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button backBtn;
        private Button saveBtn;
        private TextBox serviceNameTB;
        private TextBox serviceDescTB;
        private TextBox serviceIdTB;
    }
}