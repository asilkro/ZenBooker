namespace ZenoBook.Forms
{
    partial class AdminOffice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminOffice));
            officeIdTB = new TextBox();
            officeNameTB = new TextBox();
            officeAddressIdTB = new TextBox();
            saveBtn = new Button();
            backBtn = new Button();
            SuspendLayout();
            // 
            // officeIdTB
            // 
            officeIdTB.Location = new Point(24, 51);
            officeIdTB.Name = "officeIdTB";
            officeIdTB.PlaceholderText = "Office Id";
            officeIdTB.ReadOnly = true;
            officeIdTB.Size = new Size(83, 23);
            officeIdTB.TabIndex = 9;
            // 
            // officeNameTB
            // 
            officeNameTB.Location = new Point(24, 109);
            officeNameTB.MaxLength = 32;
            officeNameTB.Name = "officeNameTB";
            officeNameTB.PlaceholderText = "Office Name";
            officeNameTB.Size = new Size(233, 23);
            officeNameTB.TabIndex = 8;
            // 
            // officeAddressIdTB
            // 
            officeAddressIdTB.Location = new Point(24, 80);
            officeAddressIdTB.MaxLength = 32;
            officeAddressIdTB.Name = "officeAddressIdTB";
            officeAddressIdTB.PlaceholderText = "Office Address Id";
            officeAddressIdTB.Size = new Size(233, 23);
            officeAddressIdTB.TabIndex = 7;
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.LightSteelBlue;
            saveBtn.Location = new Point(182, 202);
            saveBtn.Margin = new Padding(1);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(75, 23);
            saveBtn.TabIndex = 6;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = false;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(105, 202);
            backBtn.Margin = new Padding(1);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(75, 23);
            backBtn.TabIndex = 5;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            // 
            // AdminOffice
            // 
            AcceptButton = saveBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = backBtn;
            ClientSize = new Size(284, 261);
            Controls.Add(officeIdTB);
            Controls.Add(officeNameTB);
            Controls.Add(officeAddressIdTB);
            Controls.Add(saveBtn);
            Controls.Add(backBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminOffice";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ZTH - Admin - Office";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox officeIdTB;
        private TextBox officeNameTB;
        private TextBox officeAddressIdTB;
        private Button saveBtn;
        private Button backBtn;
    }
}