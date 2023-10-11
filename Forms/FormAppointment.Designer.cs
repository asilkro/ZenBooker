namespace ZenoBook.Forms
{
    partial class FormAppointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAppointment));
            saveBtn = new Button();
            cancelBtn = new Button();
            dateCalendar = new MonthCalendar();
            startDtPicker = new DateTimePicker();
            endDtPicker = new DateTimePicker();
            cxSearchTB = new TextBox();
            cxSearchButton = new Button();
            cxIdTB = new TextBox();
            cxNameTb = new TextBox();
            cxEmailTB = new TextBox();
            cxPhoneTB = new TextBox();
            staffSearchButton = new Button();
            staffSearchTB = new TextBox();
            staffNameTb = new TextBox();
            staffIdTB = new TextBox();
            startLbl = new Label();
            endLbl = new Label();
            serviceSearchButton = new Button();
            serviceSearchTB = new TextBox();
            serviceDescTb = new TextBox();
            serviceNameTb = new TextBox();
            serviceIdTB = new TextBox();
            officeCityTB = new TextBox();
            officeNameTB = new TextBox();
            officeIdTB = new TextBox();
            officeSearchButton = new Button();
            officeSearchTB = new TextBox();
            officeStateTB = new TextBox();
            officeCountryTB = new TextBox();
            apptIdTB = new TextBox();
            mySqlDataAdapter1 = new MySqlConnector.MySqlDataAdapter();
            SuspendLayout();
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.LightSteelBlue;
            saveBtn.Location = new Point(600, 559);
            saveBtn.Margin = new Padding(3, 4, 3, 4);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(114, 59);
            saveBtn.TabIndex = 5;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = false;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(743, 559);
            cancelBtn.Margin = new Padding(3, 4, 3, 4);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(114, 59);
            cancelBtn.TabIndex = 4;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // dateCalendar
            // 
            dateCalendar.FirstDayOfWeek = Day.Saturday;
            dateCalendar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dateCalendar.Location = new Point(616, 45);
            dateCalendar.Margin = new Padding(10, 11, 10, 11);
            dateCalendar.MaxSelectionCount = 1;
            dateCalendar.Name = "dateCalendar";
            dateCalendar.TabIndex = 7;
            // 
            // startDtPicker
            // 
            startDtPicker.Checked = false;
            startDtPicker.CustomFormat = "HH:mm";
            startDtPicker.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            startDtPicker.Format = DateTimePickerFormat.Custom;
            startDtPicker.Location = new Point(771, 258);
            startDtPicker.Margin = new Padding(3, 4, 3, 4);
            startDtPicker.Name = "startDtPicker";
            startDtPicker.Size = new Size(85, 34);
            startDtPicker.TabIndex = 8;
            startDtPicker.Value = new DateTime(2023, 9, 17, 14, 0, 0, 0);
            // 
            // endDtPicker
            // 
            endDtPicker.Checked = false;
            endDtPicker.CustomFormat = "HH:mm";
            endDtPicker.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            endDtPicker.Format = DateTimePickerFormat.Custom;
            endDtPicker.Location = new Point(771, 299);
            endDtPicker.Margin = new Padding(3, 4, 3, 4);
            endDtPicker.Name = "endDtPicker";
            endDtPicker.Size = new Size(85, 34);
            endDtPicker.TabIndex = 9;
            endDtPicker.Value = new DateTime(2023, 9, 17, 15, 0, 0, 0);
            // 
            // cxSearchTB
            // 
            cxSearchTB.Location = new Point(26, 45);
            cxSearchTB.Margin = new Padding(3, 4, 3, 4);
            cxSearchTB.Name = "cxSearchTB";
            cxSearchTB.PlaceholderText = "Enter a customer name, email, and/or ID then click this button -->";
            cxSearchTB.Size = new Size(467, 27);
            cxSearchTB.TabIndex = 14;
            // 
            // cxSearchButton
            // 
            cxSearchButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cxSearchButton.Location = new Point(501, 41);
            cxSearchButton.Margin = new Padding(3, 4, 3, 4);
            cxSearchButton.Name = "cxSearchButton";
            cxSearchButton.Size = new Size(86, 34);
            cxSearchButton.TabIndex = 15;
            cxSearchButton.Text = "Search";
            cxSearchButton.UseVisualStyleBackColor = true;
            cxSearchButton.Click += cxSearchButton_Click;
            // 
            // cxIdTB
            // 
            cxIdTB.Location = new Point(503, 80);
            cxIdTB.Margin = new Padding(3, 4, 3, 4);
            cxIdTB.Name = "cxIdTB";
            cxIdTB.PlaceholderText = "Cust. Id";
            cxIdTB.ReadOnly = true;
            cxIdTB.Size = new Size(83, 27);
            cxIdTB.TabIndex = 16;
            // 
            // cxNameTb
            // 
            cxNameTb.Location = new Point(26, 80);
            cxNameTb.Margin = new Padding(3, 4, 3, 4);
            cxNameTb.Name = "cxNameTb";
            cxNameTb.PlaceholderText = "Customer Name";
            cxNameTb.ReadOnly = true;
            cxNameTb.Size = new Size(467, 27);
            cxNameTb.TabIndex = 17;
            // 
            // cxEmailTB
            // 
            cxEmailTB.Location = new Point(26, 116);
            cxEmailTB.Margin = new Padding(3, 4, 3, 4);
            cxEmailTB.Name = "cxEmailTB";
            cxEmailTB.PlaceholderText = "Customer Email";
            cxEmailTB.ReadOnly = true;
            cxEmailTB.Size = new Size(467, 27);
            cxEmailTB.TabIndex = 18;
            // 
            // cxPhoneTB
            // 
            cxPhoneTB.Location = new Point(26, 153);
            cxPhoneTB.Margin = new Padding(3, 4, 3, 4);
            cxPhoneTB.Name = "cxPhoneTB";
            cxPhoneTB.PlaceholderText = "Customer Phone";
            cxPhoneTB.ReadOnly = true;
            cxPhoneTB.Size = new Size(467, 27);
            cxPhoneTB.TabIndex = 19;
            // 
            // staffSearchButton
            // 
            staffSearchButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            staffSearchButton.Location = new Point(501, 196);
            staffSearchButton.Margin = new Padding(3, 4, 3, 4);
            staffSearchButton.Name = "staffSearchButton";
            staffSearchButton.Size = new Size(86, 34);
            staffSearchButton.TabIndex = 21;
            staffSearchButton.Text = "Search";
            staffSearchButton.UseVisualStyleBackColor = true;
            staffSearchButton.Click += staffSearchButton_Click;
            // 
            // staffSearchTB
            // 
            staffSearchTB.Location = new Point(26, 200);
            staffSearchTB.Margin = new Padding(3, 4, 3, 4);
            staffSearchTB.Name = "staffSearchTB";
            staffSearchTB.PlaceholderText = "Enter the staff member's name or email then click this button -->";
            staffSearchTB.Size = new Size(467, 27);
            staffSearchTB.TabIndex = 20;
            // 
            // staffNameTb
            // 
            staffNameTb.Location = new Point(26, 236);
            staffNameTb.Margin = new Padding(3, 4, 3, 4);
            staffNameTb.Name = "staffNameTb";
            staffNameTb.PlaceholderText = "Staff Member";
            staffNameTb.ReadOnly = true;
            staffNameTb.Size = new Size(467, 27);
            staffNameTb.TabIndex = 23;
            // 
            // staffIdTB
            // 
            staffIdTB.Location = new Point(503, 236);
            staffIdTB.Margin = new Padding(3, 4, 3, 4);
            staffIdTB.Name = "staffIdTB";
            staffIdTB.PlaceholderText = "Staff Id";
            staffIdTB.ReadOnly = true;
            staffIdTB.Size = new Size(83, 27);
            staffIdTB.TabIndex = 22;
            // 
            // startLbl
            // 
            startLbl.AutoSize = true;
            startLbl.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            startLbl.Location = new Point(701, 260);
            startLbl.Name = "startLbl";
            startLbl.Size = new Size(68, 32);
            startLbl.TabIndex = 24;
            startLbl.Text = "Start";
            // 
            // endLbl
            // 
            endLbl.AutoSize = true;
            endLbl.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            endLbl.Location = new Point(712, 304);
            endLbl.Name = "endLbl";
            endLbl.Size = new Size(57, 32);
            endLbl.TabIndex = 25;
            endLbl.Text = "End";
            // 
            // serviceSearchButton
            // 
            serviceSearchButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            serviceSearchButton.Location = new Point(503, 274);
            serviceSearchButton.Margin = new Padding(3, 4, 3, 4);
            serviceSearchButton.Name = "serviceSearchButton";
            serviceSearchButton.Size = new Size(86, 34);
            serviceSearchButton.TabIndex = 27;
            serviceSearchButton.Text = "Search";
            serviceSearchButton.UseVisualStyleBackColor = true;
            serviceSearchButton.Click += serviceSearchButton_Click;
            // 
            // serviceSearchTB
            // 
            serviceSearchTB.Location = new Point(26, 279);
            serviceSearchTB.Margin = new Padding(3, 4, 3, 4);
            serviceSearchTB.Name = "serviceSearchTB";
            serviceSearchTB.PlaceholderText = "Enter a service name or ID then click this button -->";
            serviceSearchTB.Size = new Size(467, 27);
            serviceSearchTB.TabIndex = 26;
            // 
            // serviceDescTb
            // 
            serviceDescTb.Location = new Point(26, 352);
            serviceDescTb.Margin = new Padding(3, 4, 3, 4);
            serviceDescTb.Name = "serviceDescTb";
            serviceDescTb.PlaceholderText = "Service Description";
            serviceDescTb.ReadOnly = true;
            serviceDescTb.Size = new Size(559, 27);
            serviceDescTb.TabIndex = 30;
            // 
            // serviceNameTb
            // 
            serviceNameTb.Location = new Point(26, 315);
            serviceNameTb.Margin = new Padding(3, 4, 3, 4);
            serviceNameTb.Name = "serviceNameTb";
            serviceNameTb.PlaceholderText = "Service Name";
            serviceNameTb.ReadOnly = true;
            serviceNameTb.Size = new Size(467, 27);
            serviceNameTb.TabIndex = 29;
            // 
            // serviceIdTB
            // 
            serviceIdTB.Location = new Point(503, 315);
            serviceIdTB.Margin = new Padding(3, 4, 3, 4);
            serviceIdTB.Name = "serviceIdTB";
            serviceIdTB.PlaceholderText = "Service Id";
            serviceIdTB.ReadOnly = true;
            serviceIdTB.Size = new Size(85, 27);
            serviceIdTB.TabIndex = 28;
            // 
            // officeCityTB
            // 
            officeCityTB.Location = new Point(26, 475);
            officeCityTB.Margin = new Padding(3, 4, 3, 4);
            officeCityTB.Name = "officeCityTB";
            officeCityTB.PlaceholderText = "Office City";
            officeCityTB.ReadOnly = true;
            officeCityTB.Size = new Size(251, 27);
            officeCityTB.TabIndex = 35;
            // 
            // officeNameTB
            // 
            officeNameTB.Location = new Point(26, 439);
            officeNameTB.Margin = new Padding(3, 4, 3, 4);
            officeNameTB.Name = "officeNameTB";
            officeNameTB.PlaceholderText = "Office Name";
            officeNameTB.ReadOnly = true;
            officeNameTB.Size = new Size(467, 27);
            officeNameTB.TabIndex = 34;
            // 
            // officeIdTB
            // 
            officeIdTB.Location = new Point(507, 439);
            officeIdTB.Margin = new Padding(3, 4, 3, 4);
            officeIdTB.Name = "officeIdTB";
            officeIdTB.PlaceholderText = "Office Id";
            officeIdTB.ReadOnly = true;
            officeIdTB.Size = new Size(81, 27);
            officeIdTB.TabIndex = 33;
            // 
            // officeSearchButton
            // 
            officeSearchButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            officeSearchButton.Location = new Point(503, 398);
            officeSearchButton.Margin = new Padding(3, 4, 3, 4);
            officeSearchButton.Name = "officeSearchButton";
            officeSearchButton.Size = new Size(86, 34);
            officeSearchButton.TabIndex = 32;
            officeSearchButton.Text = "Search";
            officeSearchButton.UseVisualStyleBackColor = true;
            officeSearchButton.Click += officeSearchButton_Click;
            // 
            // officeSearchTB
            // 
            officeSearchTB.Location = new Point(26, 402);
            officeSearchTB.Margin = new Padding(3, 4, 3, 4);
            officeSearchTB.Name = "officeSearchTB";
            officeSearchTB.PlaceholderText = "Enter an office name, city, or ID then click this button -->";
            officeSearchTB.Size = new Size(467, 27);
            officeSearchTB.TabIndex = 31;
            // 
            // officeStateTB
            // 
            officeStateTB.Location = new Point(285, 475);
            officeStateTB.Margin = new Padding(3, 4, 3, 4);
            officeStateTB.Name = "officeStateTB";
            officeStateTB.PlaceholderText = "Office State";
            officeStateTB.ReadOnly = true;
            officeStateTB.Size = new Size(108, 27);
            officeStateTB.TabIndex = 36;
            // 
            // officeCountryTB
            // 
            officeCountryTB.Location = new Point(400, 475);
            officeCountryTB.Margin = new Padding(3, 4, 3, 4);
            officeCountryTB.Name = "officeCountryTB";
            officeCountryTB.PlaceholderText = "Office Country";
            officeCountryTB.ReadOnly = true;
            officeCountryTB.Size = new Size(188, 27);
            officeCountryTB.TabIndex = 37;
            // 
            // apptIdTB
            // 
            apptIdTB.Location = new Point(614, 267);
            apptIdTB.Margin = new Padding(3, 4, 3, 4);
            apptIdTB.Name = "apptIdTB";
            apptIdTB.PlaceholderText = "Appt Id";
            apptIdTB.ReadOnly = true;
            apptIdTB.Size = new Size(81, 27);
            apptIdTB.TabIndex = 38;
            // 
            // mySqlDataAdapter1
            // 
            mySqlDataAdapter1.DeleteCommand = null;
            mySqlDataAdapter1.InsertCommand = null;
            mySqlDataAdapter1.SelectCommand = null;
            mySqlDataAdapter1.UpdateBatchSize = 0;
            mySqlDataAdapter1.UpdateCommand = null;
            // 
            // FormAppointment
            // 
            AcceptButton = saveBtn;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBtn;
            ClientSize = new Size(896, 660);
            Controls.Add(apptIdTB);
            Controls.Add(officeCountryTB);
            Controls.Add(officeStateTB);
            Controls.Add(officeCityTB);
            Controls.Add(officeNameTB);
            Controls.Add(officeIdTB);
            Controls.Add(officeSearchButton);
            Controls.Add(officeSearchTB);
            Controls.Add(serviceDescTb);
            Controls.Add(serviceNameTb);
            Controls.Add(serviceIdTB);
            Controls.Add(serviceSearchButton);
            Controls.Add(serviceSearchTB);
            Controls.Add(endLbl);
            Controls.Add(startLbl);
            Controls.Add(staffNameTb);
            Controls.Add(staffIdTB);
            Controls.Add(staffSearchButton);
            Controls.Add(staffSearchTB);
            Controls.Add(cxPhoneTB);
            Controls.Add(cxEmailTB);
            Controls.Add(cxNameTb);
            Controls.Add(cxIdTB);
            Controls.Add(cxSearchButton);
            Controls.Add(cxSearchTB);
            Controls.Add(endDtPicker);
            Controls.Add(startDtPicker);
            Controls.Add(dateCalendar);
            Controls.Add(saveBtn);
            Controls.Add(cancelBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormAppointment";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ZTH - Appointment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button saveBtn;
        private Button cancelBtn;
        private MonthCalendar dateCalendar;
        private DateTimePicker startDtPicker;
        private DateTimePicker endDtPicker;
        private TextBox cxSearchTB;
        private Button cxSearchButton;
        private TextBox cxIdTB;
        private TextBox cxNameTb;
        private TextBox cxEmailTB;
        private TextBox cxPhoneTB;
        private Button staffSearchButton;
        private TextBox staffSearchTB;
        private TextBox staffNameTb;
        private TextBox staffIdTB;
        private Label startLbl;
        private Label endLbl;
        private Button serviceSearchButton;
        private TextBox serviceSearchTB;
        private TextBox serviceDescTb;
        private TextBox serviceNameTb;
        private TextBox serviceIdTB;
        private TextBox officeCityTB;
        private TextBox officeNameTB;
        private TextBox officeIdTB;
        private Button officeSearchButton;
        private TextBox officeSearchTB;
        private TextBox officeStateTB;
        private TextBox officeCountryTB;
        private TextBox apptIdTB;
        private MySqlConnector.MySqlDataAdapter mySqlDataAdapter1;
    }
}