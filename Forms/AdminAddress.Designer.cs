namespace ZenoBook.Forms
{
    partial class AdminAddress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminAddress));
            saveBtn = new Button();
            backBtn = new Button();
            addressIdTB = new TextBox();
            address1Tb = new TextBox();
            address2Tb = new TextBox();
            cityTb = new TextBox();
            countryTb = new TextBox();
            stateTb = new TextBox();
            SuspendLayout();
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.LightSteelBlue;
            saveBtn.Location = new Point(199, 228);
            saveBtn.Margin = new Padding(1);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(75, 23);
            saveBtn.TabIndex = 3;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(122, 228);
            backBtn.Margin = new Padding(1);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(75, 23);
            backBtn.TabIndex = 2;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // addressIdTB
            // 
            addressIdTB.Location = new Point(26, 12);
            addressIdTB.Name = "addressIdTB";
            addressIdTB.PlaceholderText = "Address Id";
            addressIdTB.ReadOnly = true;
            addressIdTB.Size = new Size(83, 23);
            addressIdTB.TabIndex = 7;
            // 
            // address1Tb
            // 
            address1Tb.Location = new Point(26, 41);
            address1Tb.MaxLength = 45;
            address1Tb.Name = "address1Tb";
            address1Tb.PlaceholderText = "Address Line 1";
            address1Tb.Size = new Size(233, 23);
            address1Tb.TabIndex = 5;
            // 
            // address2Tb
            // 
            address2Tb.Location = new Point(26, 70);
            address2Tb.MaxLength = 45;
            address2Tb.Name = "address2Tb";
            address2Tb.PlaceholderText = "Address Line 2 (Optional)";
            address2Tb.Size = new Size(233, 23);
            address2Tb.TabIndex = 8;
            // 
            // cityTb
            // 
            cityTb.Location = new Point(26, 99);
            cityTb.MaxLength = 45;
            cityTb.Name = "cityTb";
            cityTb.PlaceholderText = "City";
            cityTb.Size = new Size(233, 23);
            cityTb.TabIndex = 9;
            // 
            // countryTb
            // 
            countryTb.Location = new Point(26, 156);
            countryTb.MaxLength = 45;
            countryTb.Name = "countryTb";
            countryTb.PlaceholderText = "Country";
            countryTb.Size = new Size(233, 23);
            countryTb.TabIndex = 11;
            // 
            // stateTb
            // 
            stateTb.Location = new Point(26, 127);
            stateTb.MaxLength = 45;
            stateTb.Name = "stateTb";
            stateTb.PlaceholderText = "State (Optional)";
            stateTb.Size = new Size(233, 23);
            stateTb.TabIndex = 10;
            // 
            // AdminAddress
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 261);
            Controls.Add(countryTb);
            Controls.Add(stateTb);
            Controls.Add(cityTb);
            Controls.Add(address2Tb);
            Controls.Add(addressIdTB);
            Controls.Add(address1Tb);
            Controls.Add(saveBtn);
            Controls.Add(backBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdminAddress";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "ZTH - Admin - Address";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button saveBtn;
        private Button backBtn;
        private TextBox addressIdTB;
        private TextBox address1Tb;
        private TextBox address2Tb;
        private TextBox cityTb;
        private TextBox countryTb;
        private TextBox stateTb;
    }
}