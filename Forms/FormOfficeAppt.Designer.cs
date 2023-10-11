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
            submitBtn = new Button();
            cancelBtn = new Button();
            validateBtn = new Button();
            SuspendLayout();
            // 
            // officeCountryTB
            // 
            officeCountryTB.Location = new Point(22, 198);
            officeCountryTB.Margin = new Padding(6, 6, 6, 6);
            officeCountryTB.Name = "officeCountryTB";
            officeCountryTB.PlaceholderText = "Office Country";
            officeCountryTB.ReadOnly = true;
            officeCountryTB.Size = new Size(595, 39);
            officeCountryTB.TabIndex = 44;
            // 
            // officeStateTB
            // 
            officeStateTB.Location = new Point(444, 139);
            officeStateTB.Margin = new Padding(6, 6, 6, 6);
            officeStateTB.Name = "officeStateTB";
            officeStateTB.PlaceholderText = "Office State";
            officeStateTB.ReadOnly = true;
            officeStateTB.Size = new Size(173, 39);
            officeStateTB.TabIndex = 43;
            // 
            // officeCityTB
            // 
            officeCityTB.Location = new Point(24, 139);
            officeCityTB.Margin = new Padding(6, 6, 6, 6);
            officeCityTB.Name = "officeCityTB";
            officeCityTB.PlaceholderText = "Office City";
            officeCityTB.ReadOnly = true;
            officeCityTB.Size = new Size(405, 39);
            officeCityTB.TabIndex = 42;
            // 
            // officeNameTB
            // 
            officeNameTB.Location = new Point(24, 81);
            officeNameTB.Margin = new Padding(6, 6, 6, 6);
            officeNameTB.Name = "officeNameTB";
            officeNameTB.PlaceholderText = "Office Name";
            officeNameTB.ReadOnly = true;
            officeNameTB.Size = new Size(450, 39);
            officeNameTB.TabIndex = 41;
            // 
            // officeIdTB
            // 
            officeIdTB.Location = new Point(488, 81);
            officeIdTB.Margin = new Padding(6, 6, 6, 6);
            officeIdTB.Name = "officeIdTB";
            officeIdTB.PlaceholderText = "Office Id";
            officeIdTB.ReadOnly = true;
            officeIdTB.Size = new Size(128, 39);
            officeIdTB.TabIndex = 40;
            // 
            // officeSearchButton
            // 
            officeSearchButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            officeSearchButton.Location = new Point(644, 23);
            officeSearchButton.Margin = new Padding(6, 6, 6, 6);
            officeSearchButton.Name = "officeSearchButton";
            officeSearchButton.Size = new Size(139, 55);
            officeSearchButton.TabIndex = 39;
            officeSearchButton.Text = "Search";
            officeSearchButton.UseVisualStyleBackColor = true;
            // 
            // officeSearchTB
            // 
            officeSearchTB.Location = new Point(24, 23);
            officeSearchTB.Margin = new Padding(6, 6, 6, 6);
            officeSearchTB.Name = "officeSearchTB";
            officeSearchTB.PlaceholderText = "Enter office name, city, or ID then click -->";
            officeSearchTB.Size = new Size(593, 39);
            officeSearchTB.TabIndex = 38;
            // 
            // submitBtn
            // 
            submitBtn.Enabled = false;
            submitBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            submitBtn.Location = new Point(596, 680);
            submitBtn.Margin = new Padding(6, 6, 6, 6);
            submitBtn.Name = "submitBtn";
            submitBtn.Size = new Size(141, 51);
            submitBtn.TabIndex = 47;
            submitBtn.Text = "Submit";
            submitBtn.UseVisualStyleBackColor = true;
            submitBtn.Click += SaveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cancelBtn.Location = new Point(39, 680);
            cancelBtn.Margin = new Padding(6, 6, 6, 6);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(141, 51);
            cancelBtn.TabIndex = 46;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // validateBtn
            // 
            validateBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            validateBtn.Location = new Point(336, 680);
            validateBtn.Margin = new Padding(6, 6, 6, 6);
            validateBtn.Name = "validateBtn";
            validateBtn.Size = new Size(141, 51);
            validateBtn.TabIndex = 45;
            validateBtn.Text = "Validate";
            validateBtn.UseVisualStyleBackColor = true;
            validateBtn.Click += validateBtn_Click;
            // 
            // FormOfficeAppt
            // 
            AcceptButton = validateBtn;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBtn;
            ClientSize = new Size(806, 774);
            Controls.Add(submitBtn);
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
            Margin = new Padding(6, 6, 6, 6);
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
        private Button submitBtn;
        private Button cancelBtn;
        private Button validateBtn;
    }
}