namespace ZenoBook.Forms
{
    partial class FormHomeAppt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHomeAppt));
            validateBtn = new Button();
            cancelBtn = new Button();
            saveBtn = new Button();
            cxIdTB = new TextBox();
            officeCountryTB = new TextBox();
            officeStateTB = new TextBox();
            address1TB = new TextBox();
            officeIdTB = new TextBox();
            SearchButton = new Button();
            saSearchTB = new TextBox();
            address2TB = new TextBox();
            cityTB = new TextBox();
            SuspendLayout();
            // 
            // validateBtn
            // 
            validateBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            validateBtn.Location = new Point(186, 357);
            validateBtn.Name = "validateBtn";
            validateBtn.Size = new Size(76, 27);
            validateBtn.TabIndex = 0;
            validateBtn.Text = "Validate";
            validateBtn.UseVisualStyleBackColor = true;
            validateBtn.Click += validateBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cancelBtn.Location = new Point(26, 357);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(76, 27);
            cancelBtn.TabIndex = 1;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // saveBtn
            // 
            saveBtn.Enabled = false;
            saveBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            saveBtn.Location = new Point(326, 357);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(76, 27);
            saveBtn.TabIndex = 2;
            saveBtn.Text = "Submit";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // cxIdTB
            // 
            cxIdTB.Location = new Point(26, 22);
            cxIdTB.Name = "cxIdTB";
            cxIdTB.PlaceholderText = "Customer Id";
            cxIdTB.Size = new Size(124, 25);
            cxIdTB.TabIndex = 18;
            // 
            // officeCountryTB
            // 
            officeCountryTB.Location = new Point(26, 257);
            officeCountryTB.Name = "officeCountryTB";
            officeCountryTB.PlaceholderText = "Office Country";
            officeCountryTB.ReadOnly = true;
            officeCountryTB.Size = new Size(291, 25);
            officeCountryTB.TabIndex = 44;
            // 
            // officeStateTB
            // 
            officeStateTB.Location = new Point(340, 257);
            officeStateTB.Name = "officeStateTB";
            officeStateTB.PlaceholderText = "Office State";
            officeStateTB.ReadOnly = true;
            officeStateTB.Size = new Size(80, 25);
            officeStateTB.TabIndex = 43;
            // 
            // address1TB
            // 
            address1TB.Location = new Point(26, 133);
            address1TB.Name = "address1TB";
            address1TB.PlaceholderText = "Address Line 1";
            address1TB.ReadOnly = true;
            address1TB.Size = new Size(394, 25);
            address1TB.TabIndex = 41;
            // 
            // officeIdTB
            // 
            officeIdTB.Location = new Point(26, 102);
            officeIdTB.Name = "officeIdTB";
            officeIdTB.PlaceholderText = "Service Address Id";
            officeIdTB.ReadOnly = true;
            officeIdTB.Size = new Size(124, 25);
            officeIdTB.TabIndex = 40;
            // 
            // SearchButton
            // 
            SearchButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            SearchButton.Location = new Point(311, 18);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(60, 29);
            SearchButton.TabIndex = 39;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // saSearchTB
            // 
            saSearchTB.Location = new Point(26, 53);
            saSearchTB.Name = "saSearchTB";
            saSearchTB.PlaceholderText = "Enter another part of the service address and search.";
            saSearchTB.Size = new Size(345, 25);
            saSearchTB.TabIndex = 38;
            // 
            // address2TB
            // 
            address2TB.Location = new Point(26, 164);
            address2TB.Name = "address2TB";
            address2TB.PlaceholderText = "Address Line 2 (Optional)";
            address2TB.ReadOnly = true;
            address2TB.Size = new Size(394, 25);
            address2TB.TabIndex = 45;
            // 
            // cityTB
            // 
            cityTB.Location = new Point(26, 195);
            cityTB.Name = "cityTB";
            cityTB.PlaceholderText = "City (optional, recommended)";
            cityTB.ReadOnly = true;
            cityTB.Size = new Size(394, 25);
            cityTB.TabIndex = 46;
            // 
            // FormHomeAppt
            // 
            AcceptButton = saveBtn;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBtn;
            ClientSize = new Size(434, 411);
            Controls.Add(cityTB);
            Controls.Add(address2TB);
            Controls.Add(officeCountryTB);
            Controls.Add(officeStateTB);
            Controls.Add(address1TB);
            Controls.Add(officeIdTB);
            Controls.Add(SearchButton);
            Controls.Add(saSearchTB);
            Controls.Add(cxIdTB);
            Controls.Add(saveBtn);
            Controls.Add(cancelBtn);
            Controls.Add(validateBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormHomeAppt";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ZTH - Home Appointment Details";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button validateBtn;
        private Button cancelBtn;
        private Button saveBtn;
        private Button AddressSearchButton;
        private TextBox addressSearchTB;
        private TextBox cxIdTB;
        private TextBox officeCountryTB;
        private TextBox officeStateTB;
        private TextBox address1TB;
        private TextBox officeIdTB;
        private Button SearchButton;
        private TextBox saSearchTB;
        private TextBox address2TB;
        private TextBox cityTB;
    }
}