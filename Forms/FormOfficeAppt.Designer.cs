namespace ZenoBook.Forms
{
    partial class FormOfficeAppt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOfficeAppt));
            officeCountryTB = new TextBox();
            officeStateTB = new TextBox();
            officeCityTB = new TextBox();
            officeNameTB = new TextBox();
            officeIdTB = new TextBox();
            officeSearchButton = new Button();
            officeSearchTB = new TextBox();
            saveBtn = new Button();
            cancelBtn = new Button();
            validateBtn = new Button();
            SuspendLayout();
            // 
            // officeCountryTB
            // 
            officeCountryTB.Location = new Point(12, 105);
            officeCountryTB.Name = "officeCountryTB";
            officeCountryTB.PlaceholderText = "Office Country";
            officeCountryTB.ReadOnly = true;
            officeCountryTB.Size = new Size(322, 25);
            officeCountryTB.TabIndex = 44;
            // 
            // officeStateTB
            // 
            officeStateTB.Location = new Point(239, 74);
            officeStateTB.Name = "officeStateTB";
            officeStateTB.PlaceholderText = "Office State";
            officeStateTB.ReadOnly = true;
            officeStateTB.Size = new Size(95, 25);
            officeStateTB.TabIndex = 43;
            // 
            // officeCityTB
            // 
            officeCityTB.Location = new Point(13, 74);
            officeCityTB.Name = "officeCityTB";
            officeCityTB.PlaceholderText = "Office City";
            officeCityTB.ReadOnly = true;
            officeCityTB.Size = new Size(220, 25);
            officeCityTB.TabIndex = 42;
            // 
            // officeNameTB
            // 
            officeNameTB.Location = new Point(13, 43);
            officeNameTB.Name = "officeNameTB";
            officeNameTB.PlaceholderText = "Office Name";
            officeNameTB.ReadOnly = true;
            officeNameTB.Size = new Size(244, 25);
            officeNameTB.TabIndex = 41;
            // 
            // officeIdTB
            // 
            officeIdTB.Location = new Point(263, 43);
            officeIdTB.Name = "officeIdTB";
            officeIdTB.PlaceholderText = "Office Id";
            officeIdTB.ReadOnly = true;
            officeIdTB.Size = new Size(71, 25);
            officeIdTB.TabIndex = 40;
            // 
            // officeSearchButton
            // 
            officeSearchButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            officeSearchButton.Location = new Point(347, 12);
            officeSearchButton.Name = "officeSearchButton";
            officeSearchButton.Size = new Size(75, 29);
            officeSearchButton.TabIndex = 39;
            officeSearchButton.Text = "Search";
            officeSearchButton.UseVisualStyleBackColor = true;
            // 
            // officeSearchTB
            // 
            officeSearchTB.Location = new Point(13, 12);
            officeSearchTB.Name = "officeSearchTB";
            officeSearchTB.PlaceholderText = "Enter office name, city, or ID then click -->";
            officeSearchTB.Size = new Size(321, 25);
            officeSearchTB.TabIndex = 38;
            // 
            // saveBtn
            // 
            saveBtn.Enabled = false;
            saveBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            saveBtn.Location = new Point(321, 361);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(76, 27);
            saveBtn.TabIndex = 47;
            saveBtn.Text = "Submit";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cancelBtn.Location = new Point(21, 361);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(76, 27);
            cancelBtn.TabIndex = 46;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // validateBtn
            // 
            validateBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            validateBtn.Location = new Point(181, 361);
            validateBtn.Name = "validateBtn";
            validateBtn.Size = new Size(76, 27);
            validateBtn.TabIndex = 45;
            validateBtn.Text = "Validate";
            validateBtn.UseVisualStyleBackColor = true;
            validateBtn.Click += validateBtn_Click;
            // 
            // FormOfficeAppt
            // 
            AcceptButton = validateBtn;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBtn;
            ClientSize = new Size(434, 411);
            Controls.Add(saveBtn);
            Controls.Add(cancelBtn);
            Controls.Add(validateBtn);
            Controls.Add(officeCountryTB);
            Controls.Add(officeStateTB);
            Controls.Add(officeCityTB);
            Controls.Add(officeNameTB);
            Controls.Add(officeIdTB);
            Controls.Add(officeSearchButton);
            Controls.Add(officeSearchTB);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormOfficeAppt";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ZTH - Office Appointment Details";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox officeCountryTB;
        private TextBox officeStateTB;
        private TextBox officeCityTB;
        private TextBox officeNameTB;
        private TextBox officeIdTB;
        private Button officeSearchButton;
        private TextBox officeSearchTB;
        private Button saveBtn;
        private Button cancelBtn;
        private Button validateBtn;
    }
}