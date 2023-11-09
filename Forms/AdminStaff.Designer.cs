using System.ComponentModel;

namespace ZenoBook.Forms
{
    partial class AdminStaff
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(AdminStaff));
            staffIdTB = new TextBox();
            staffPhoneTB = new TextBox();
            staffNameTB = new TextBox();
            saveBtn = new Button();
            backBtn = new Button();
            staffEmailTB = new TextBox();
            officeIdTB = new TextBox();
            userIdTB = new TextBox();
            SuspendLayout();
            // 
            // staffIdTB
            // 
            staffIdTB.Location = new Point(12, 12);
            staffIdTB.MaxLength = 7;
            staffIdTB.Name = "staffIdTB";
            staffIdTB.PlaceholderText = "Staff Id #";
            staffIdTB.ReadOnly = true;
            staffIdTB.Size = new Size(114, 23);
            staffIdTB.TabIndex = 9;
            // 
            // staffPhoneTB
            // 
            staffPhoneTB.Location = new Point(12, 70);
            staffPhoneTB.MaxLength = 12;
            staffPhoneTB.Name = "staffPhoneTB";
            staffPhoneTB.PlaceholderText = "Staff Phone";
            staffPhoneTB.Size = new Size(348, 23);
            staffPhoneTB.TabIndex = 8;
            // 
            // staffNameTB
            // 
            staffNameTB.Location = new Point(12, 41);
            staffNameTB.MaxLength = 45;
            staffNameTB.Name = "staffNameTB";
            staffNameTB.PlaceholderText = "Staff Name";
            staffNameTB.Size = new Size(348, 23);
            staffNameTB.TabIndex = 7;
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.LightSteelBlue;
            saveBtn.Location = new Point(285, 226);
            saveBtn.Margin = new Padding(1);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(75, 23);
            saveBtn.TabIndex = 6;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(208, 226);
            backBtn.Margin = new Padding(1);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(75, 23);
            backBtn.TabIndex = 5;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // staffEmailTB
            // 
            staffEmailTB.Location = new Point(12, 99);
            staffEmailTB.MaxLength = 45;
            staffEmailTB.Name = "staffEmailTB";
            staffEmailTB.PlaceholderText = "Staff Email";
            staffEmailTB.Size = new Size(348, 23);
            staffEmailTB.TabIndex = 10;
            // 
            // officeIdTB
            // 
            officeIdTB.Location = new Point(132, 12);
            officeIdTB.MaxLength = 7;
            officeIdTB.Name = "officeIdTB";
            officeIdTB.PlaceholderText = "Staff Office Id #";
            officeIdTB.Size = new Size(111, 23);
            officeIdTB.TabIndex = 11;
            // 
            // userIdTB
            // 
            userIdTB.Location = new Point(250, 12);
            userIdTB.MaxLength = 7;
            userIdTB.Name = "userIdTB";
            userIdTB.PlaceholderText = "Staff User Id #";
            userIdTB.Size = new Size(111, 23);
            userIdTB.TabIndex = 12;
            // 
            // AdminStaff
            // 
            AcceptButton = saveBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = backBtn;
            ClientSize = new Size(384, 261);
            Controls.Add(userIdTB);
            Controls.Add(officeIdTB);
            Controls.Add(staffEmailTB);
            Controls.Add(staffIdTB);
            Controls.Add(staffPhoneTB);
            Controls.Add(staffNameTB);
            Controls.Add(saveBtn);
            Controls.Add(backBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminStaff";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ZTH - Admin - Staff";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox staffIdTB;
        private TextBox staffPhoneTB;
        private TextBox staffNameTB;
        private Button saveBtn;
        private Button backBtn;
        private TextBox staffEmailTB;
        private TextBox officeIdTB;
        private TextBox userIdTB;
    }
}