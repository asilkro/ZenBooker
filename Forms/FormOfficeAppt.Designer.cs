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
            officeNameTB = new TextBox();
            officeIdTB = new TextBox();
            officeSearchButton = new Button();
            officeSearchTB = new TextBox();
            submitBtn = new Button();
            cancelBtn = new Button();
            validateBtn = new Button();
            SuspendLayout();
            // 
            // officeNameTB
            // 
            officeNameTB.Location = new Point(13, 38);
            officeNameTB.Name = "officeNameTB";
            officeNameTB.PlaceholderText = "Office Name";
            officeNameTB.ReadOnly = true;
            officeNameTB.Size = new Size(244, 23);
            officeNameTB.TabIndex = 41;
            // 
            // officeIdTB
            // 
            officeIdTB.Location = new Point(263, 38);
            officeIdTB.Name = "officeIdTB";
            officeIdTB.PlaceholderText = "Office Id";
            officeIdTB.ReadOnly = true;
            officeIdTB.Size = new Size(71, 23);
            officeIdTB.TabIndex = 40;
            // 
            // officeSearchButton
            // 
            officeSearchButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            officeSearchButton.Location = new Point(347, 11);
            officeSearchButton.Name = "officeSearchButton";
            officeSearchButton.Size = new Size(75, 26);
            officeSearchButton.TabIndex = 39;
            officeSearchButton.Text = "Search";
            officeSearchButton.UseVisualStyleBackColor = true;
            // 
            // officeSearchTB
            // 
            officeSearchTB.Location = new Point(13, 11);
            officeSearchTB.Name = "officeSearchTB";
            officeSearchTB.PlaceholderText = "Enter office name, city, or ID then click -->";
            officeSearchTB.Size = new Size(321, 23);
            officeSearchTB.TabIndex = 38;
            // 
            // submitBtn
            // 
            submitBtn.Enabled = false;
            submitBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            submitBtn.Location = new Point(321, 319);
            submitBtn.Name = "submitBtn";
            submitBtn.Size = new Size(76, 24);
            submitBtn.TabIndex = 47;
            submitBtn.Text = "Submit";
            submitBtn.UseVisualStyleBackColor = true;
            submitBtn.Click += SaveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cancelBtn.Location = new Point(21, 319);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(76, 24);
            cancelBtn.TabIndex = 46;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // validateBtn
            // 
            validateBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            validateBtn.Location = new Point(181, 319);
            validateBtn.Name = "validateBtn";
            validateBtn.Size = new Size(76, 24);
            validateBtn.TabIndex = 45;
            validateBtn.Text = "Validate";
            validateBtn.UseVisualStyleBackColor = true;
            validateBtn.Click += validateBtn_Click;
            // 
            // FormOfficeAppt
            // 
            AcceptButton = validateBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBtn;
            ClientSize = new Size(434, 363);
            Controls.Add(submitBtn);
            Controls.Add(cancelBtn);
            Controls.Add(validateBtn);
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
        private TextBox officeNameTB;
        private TextBox officeIdTB;
        private Button officeSearchButton;
        private TextBox officeSearchTB;
        private Button submitBtn;
        private Button cancelBtn;
        private Button validateBtn;
    }
}