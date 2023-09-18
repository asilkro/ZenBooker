namespace ZenoBook.Forms
{
    partial class FormCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCustomer));
            cancelBtn = new Button();
            saveBtn = new Button();
            removeBtn = new Button();
            tbFirstName = new TextBox();
            tbLastName = new TextBox();
            tbPhone = new TextBox();
            tbEmail = new TextBox();
            tbOffice = new TextBox();
            SuspendLayout();
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(650, 475);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(100, 50);
            cancelBtn.TabIndex = 1;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.LightSteelBlue;
            saveBtn.Location = new Point(525, 475);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(100, 50);
            saveBtn.TabIndex = 2;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = false;
            // 
            // removeBtn
            // 
            removeBtn.BackColor = Color.RosyBrown;
            removeBtn.Location = new Point(50, 475);
            removeBtn.Name = "removeBtn";
            removeBtn.Size = new Size(100, 50);
            removeBtn.TabIndex = 3;
            removeBtn.Text = "Remove";
            removeBtn.UseVisualStyleBackColor = false;
            // 
            // tbFirstName
            // 
            tbFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbFirstName.Location = new Point(102, 122);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.PlaceholderText = "First Name";
            tbFirstName.Size = new Size(332, 29);
            tbFirstName.TabIndex = 4;
            // 
            // tbLastName
            // 
            tbLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbLastName.Location = new Point(102, 187);
            tbLastName.Name = "tbLastName";
            tbLastName.PlaceholderText = "Last Name";
            tbLastName.Size = new Size(332, 29);
            tbLastName.TabIndex = 5;
            // 
            // tbPhone
            // 
            tbPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbPhone.Location = new Point(102, 248);
            tbPhone.Name = "tbPhone";
            tbPhone.PlaceholderText = "Phone Number";
            tbPhone.Size = new Size(332, 29);
            tbPhone.TabIndex = 6;
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbEmail.Location = new Point(102, 306);
            tbEmail.Name = "tbEmail";
            tbEmail.PlaceholderText = "E-Mail";
            tbEmail.Size = new Size(332, 29);
            tbEmail.TabIndex = 7;
            // 
            // tbOffice
            // 
            tbOffice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbOffice.Location = new Point(102, 369);
            tbOffice.Name = "tbOffice";
            tbOffice.PlaceholderText = "Preferred Office";
            tbOffice.Size = new Size(177, 29);
            tbOffice.TabIndex = 8;
            // 
            // FormCustomer
            // 
            AcceptButton = saveBtn;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBtn;
            ClientSize = new Size(784, 561);
            Controls.Add(tbOffice);
            Controls.Add(tbEmail);
            Controls.Add(tbPhone);
            Controls.Add(tbLastName);
            Controls.Add(tbFirstName);
            Controls.Add(removeBtn);
            Controls.Add(saveBtn);
            Controls.Add(cancelBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormCustomer";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ZTH - Customer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelBtn;
        private Button saveBtn;
        private Button removeBtn;
        private TextBox tbFirstName;
        private TextBox tbLastName;
        private TextBox tbPhone;
        private TextBox tbEmail;
        private TextBox tbOffice;
    }
}