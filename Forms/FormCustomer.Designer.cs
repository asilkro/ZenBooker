using System.ComponentModel;

namespace ZenoBook.Forms
{
    partial class FormCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCustomer));
            cancelBtn = new Button();
            saveBtn = new Button();
            tbFirstName = new TextBox();
            tbLastName = new TextBox();
            tbPhone = new TextBox();
            tbEmail = new TextBox();
            tbOffice = new TextBox();
            validateBtn = new Button();
            cxIdTB = new TextBox();
            SuspendLayout();
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(650, 419);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(100, 44);
            cancelBtn.TabIndex = 1;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.LightSteelBlue;
            saveBtn.Location = new Point(525, 419);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(100, 44);
            saveBtn.TabIndex = 2;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += SaveBtn_Click;
            // 
            // tbFirstName
            // 
            tbFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbFirstName.Location = new Point(102, 108);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.PlaceholderText = "First Name";
            tbFirstName.Size = new Size(332, 29);
            tbFirstName.TabIndex = 4;
            // 
            // tbLastName
            // 
            tbLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbLastName.Location = new Point(102, 165);
            tbLastName.Name = "tbLastName";
            tbLastName.PlaceholderText = "Last Name";
            tbLastName.Size = new Size(332, 29);
            tbLastName.TabIndex = 5;
            // 
            // tbPhone
            // 
            tbPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbPhone.Location = new Point(102, 219);
            tbPhone.Name = "tbPhone";
            tbPhone.PlaceholderText = "Phone Number";
            tbPhone.Size = new Size(332, 29);
            tbPhone.TabIndex = 6;
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbEmail.Location = new Point(102, 270);
            tbEmail.Name = "tbEmail";
            tbEmail.PlaceholderText = "E-Mail";
            tbEmail.Size = new Size(332, 29);
            tbEmail.TabIndex = 7;
            // 
            // tbOffice
            // 
            tbOffice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbOffice.Location = new Point(102, 326);
            tbOffice.Name = "tbOffice";
            tbOffice.PlaceholderText = "Preferred Office";
            tbOffice.Size = new Size(177, 29);
            tbOffice.TabIndex = 8;
            // 
            // validateBtn
            // 
            validateBtn.BackColor = Color.MintCream;
            validateBtn.Location = new Point(525, 419);
            validateBtn.Name = "validateBtn";
            validateBtn.Size = new Size(100, 44);
            validateBtn.TabIndex = 9;
            validateBtn.Text = "Validate";
            validateBtn.UseVisualStyleBackColor = false;
            validateBtn.Click += ValidateBtn_Click;
            // 
            // cxIdTB
            // 
            cxIdTB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cxIdTB.Location = new Point(285, 326);
            cxIdTB.Name = "cxIdTB";
            cxIdTB.PlaceholderText = "Customer Id";
            cxIdTB.ReadOnly = true;
            cxIdTB.Size = new Size(149, 29);
            cxIdTB.TabIndex = 10;
            // 
            // FormCustomer
            // 
            AcceptButton = saveBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBtn;
            ClientSize = new Size(784, 495);
            Controls.Add(cxIdTB);
            Controls.Add(validateBtn);
            Controls.Add(tbOffice);
            Controls.Add(tbEmail);
            Controls.Add(tbPhone);
            Controls.Add(tbLastName);
            Controls.Add(tbFirstName);
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
        private TextBox tbFirstName;
        private TextBox tbLastName;
        private TextBox tbPhone;
        private TextBox tbEmail;
        private TextBox tbOffice;
        private Button validateBtn;
        private TextBox cxIdTB;
    }
}