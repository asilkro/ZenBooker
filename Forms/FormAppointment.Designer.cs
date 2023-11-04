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
            officeNameTB = new TextBox();
            officeIdTB = new TextBox();
            officeSearchButton = new Button();
            officeSearchTB = new TextBox();
            apptIdTB = new TextBox();
            officeRadioBtn = new RadioButton();
            homeRadioBtn = new RadioButton();
            cityTB = new TextBox();
            address2TB = new TextBox();
            countryTB = new TextBox();
            stateTB = new TextBox();
            address1TB = new TextBox();
            addressIdTB = new TextBox();
            homeSearchBtn = new Button();
            saSearchTB = new TextBox();
            debugBtn = new Button();
            SuspendLayout();
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.LightSteelBlue;
            saveBtn.Location = new Point(535, 419);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(100, 44);
            saveBtn.TabIndex = 5;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(650, 419);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(100, 44);
            cancelBtn.TabIndex = 4;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // dateCalendar
            // 
            dateCalendar.FirstDayOfWeek = Day.Saturday;
            dateCalendar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dateCalendar.Location = new Point(539, 34);
            dateCalendar.Margin = new Padding(9, 8, 9, 8);
            dateCalendar.MaxSelectionCount = 1;
            dateCalendar.MinDate = new DateTime(2023, 10, 1, 0, 0, 0, 0);
            dateCalendar.Name = "dateCalendar";
            dateCalendar.TabIndex = 7;
            // 
            // startDtPicker
            // 
            startDtPicker.Checked = false;
            startDtPicker.CustomFormat = "HH:mm tt";
            startDtPicker.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            startDtPicker.Format = DateTimePickerFormat.Custom;
            startDtPicker.Location = new Point(601, 203);
            startDtPicker.MinDate = new DateTime(2023, 10, 1, 0, 0, 0, 0);
            startDtPicker.Name = "startDtPicker";
            startDtPicker.ShowUpDown = true;
            startDtPicker.Size = new Size(100, 29);
            startDtPicker.TabIndex = 8;
            // 
            // endDtPicker
            // 
            endDtPicker.Checked = false;
            endDtPicker.CustomFormat = "HH:mm tt";
            endDtPicker.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            endDtPicker.Format = DateTimePickerFormat.Custom;
            endDtPicker.Location = new Point(601, 233);
            endDtPicker.MinDate = new DateTime(2023, 10, 1, 0, 0, 0, 0);
            endDtPicker.Name = "endDtPicker";
            endDtPicker.ShowUpDown = true;
            endDtPicker.Size = new Size(100, 29);
            endDtPicker.TabIndex = 9;
            // 
            // cxSearchTB
            // 
            cxSearchTB.Location = new Point(23, 34);
            cxSearchTB.Name = "cxSearchTB";
            cxSearchTB.PlaceholderText = "Enter a customer name, email, and/or ID then click this button -->";
            cxSearchTB.Size = new Size(409, 23);
            cxSearchTB.TabIndex = 14;
            // 
            // cxSearchButton
            // 
            cxSearchButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cxSearchButton.Location = new Point(438, 32);
            cxSearchButton.Name = "cxSearchButton";
            cxSearchButton.Size = new Size(75, 26);
            cxSearchButton.TabIndex = 15;
            cxSearchButton.Text = "Search";
            cxSearchButton.UseVisualStyleBackColor = true;
            cxSearchButton.Click += cxSearchButton_Click;
            // 
            // cxIdTB
            // 
            cxIdTB.Location = new Point(440, 60);
            cxIdTB.Name = "cxIdTB";
            cxIdTB.PlaceholderText = "Cust. Id";
            cxIdTB.ReadOnly = true;
            cxIdTB.Size = new Size(73, 23);
            cxIdTB.TabIndex = 16;
            // 
            // cxNameTb
            // 
            cxNameTb.Location = new Point(23, 60);
            cxNameTb.Name = "cxNameTb";
            cxNameTb.PlaceholderText = "Customer Name";
            cxNameTb.ReadOnly = true;
            cxNameTb.Size = new Size(409, 23);
            cxNameTb.TabIndex = 17;
            // 
            // cxEmailTB
            // 
            cxEmailTB.Location = new Point(23, 87);
            cxEmailTB.Name = "cxEmailTB";
            cxEmailTB.PlaceholderText = "Customer Email";
            cxEmailTB.ReadOnly = true;
            cxEmailTB.Size = new Size(253, 23);
            cxEmailTB.TabIndex = 18;
            // 
            // cxPhoneTB
            // 
            cxPhoneTB.Location = new Point(312, 87);
            cxPhoneTB.Name = "cxPhoneTB";
            cxPhoneTB.PlaceholderText = "Customer Phone";
            cxPhoneTB.ReadOnly = true;
            cxPhoneTB.Size = new Size(201, 23);
            cxPhoneTB.TabIndex = 19;
            // 
            // staffSearchButton
            // 
            staffSearchButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            staffSearchButton.Location = new Point(438, 113);
            staffSearchButton.Name = "staffSearchButton";
            staffSearchButton.Size = new Size(75, 26);
            staffSearchButton.TabIndex = 21;
            staffSearchButton.Text = "Search";
            staffSearchButton.UseVisualStyleBackColor = true;
            staffSearchButton.Click += staffSearchButton_Click;
            // 
            // staffSearchTB
            // 
            staffSearchTB.Location = new Point(23, 116);
            staffSearchTB.Name = "staffSearchTB";
            staffSearchTB.PlaceholderText = "Enter the staff member's name or email then click this button -->";
            staffSearchTB.Size = new Size(409, 23);
            staffSearchTB.TabIndex = 20;
            // 
            // staffNameTb
            // 
            staffNameTb.Location = new Point(23, 145);
            staffNameTb.Name = "staffNameTb";
            staffNameTb.PlaceholderText = "Staff Member";
            staffNameTb.ReadOnly = true;
            staffNameTb.Size = new Size(409, 23);
            staffNameTb.TabIndex = 23;
            // 
            // staffIdTB
            // 
            staffIdTB.Location = new Point(440, 142);
            staffIdTB.Name = "staffIdTB";
            staffIdTB.PlaceholderText = "Staff Id";
            staffIdTB.ReadOnly = true;
            staffIdTB.Size = new Size(73, 23);
            staffIdTB.TabIndex = 22;
            // 
            // startLbl
            // 
            startLbl.AutoSize = true;
            startLbl.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            startLbl.Location = new Point(539, 204);
            startLbl.Name = "startLbl";
            startLbl.Size = new Size(53, 25);
            startLbl.TabIndex = 24;
            startLbl.Text = "start";
            // 
            // endLbl
            // 
            endLbl.AutoSize = true;
            endLbl.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            endLbl.Location = new Point(539, 237);
            endLbl.Name = "endLbl";
            endLbl.Size = new Size(46, 25);
            endLbl.TabIndex = 25;
            endLbl.Text = "end";
            // 
            // serviceSearchButton
            // 
            serviceSearchButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            serviceSearchButton.Location = new Point(438, 171);
            serviceSearchButton.Name = "serviceSearchButton";
            serviceSearchButton.Size = new Size(75, 26);
            serviceSearchButton.TabIndex = 27;
            serviceSearchButton.Text = "Search";
            serviceSearchButton.UseVisualStyleBackColor = true;
            serviceSearchButton.Click += serviceSearchButton_Click;
            // 
            // serviceSearchTB
            // 
            serviceSearchTB.Location = new Point(23, 174);
            serviceSearchTB.Name = "serviceSearchTB";
            serviceSearchTB.PlaceholderText = "Enter a service name or ID then click this button -->";
            serviceSearchTB.Size = new Size(409, 23);
            serviceSearchTB.TabIndex = 26;
            // 
            // serviceDescTb
            // 
            serviceDescTb.Location = new Point(22, 230);
            serviceDescTb.Name = "serviceDescTb";
            serviceDescTb.PlaceholderText = "Service Description";
            serviceDescTb.ReadOnly = true;
            serviceDescTb.Size = new Size(491, 23);
            serviceDescTb.TabIndex = 30;
            // 
            // serviceNameTb
            // 
            serviceNameTb.Location = new Point(22, 202);
            serviceNameTb.Name = "serviceNameTb";
            serviceNameTb.PlaceholderText = "Service Name";
            serviceNameTb.ReadOnly = true;
            serviceNameTb.Size = new Size(409, 23);
            serviceNameTb.TabIndex = 29;
            // 
            // serviceIdTB
            // 
            serviceIdTB.Location = new Point(439, 202);
            serviceIdTB.Name = "serviceIdTB";
            serviceIdTB.PlaceholderText = "Service Id";
            serviceIdTB.ReadOnly = true;
            serviceIdTB.Size = new Size(75, 23);
            serviceIdTB.TabIndex = 28;
            // 
            // officeNameTB
            // 
            officeNameTB.Location = new Point(22, 286);
            officeNameTB.Name = "officeNameTB";
            officeNameTB.PlaceholderText = "Office Name";
            officeNameTB.ReadOnly = true;
            officeNameTB.Size = new Size(409, 23);
            officeNameTB.TabIndex = 34;
            // 
            // officeIdTB
            // 
            officeIdTB.Location = new Point(443, 286);
            officeIdTB.Name = "officeIdTB";
            officeIdTB.PlaceholderText = "Office Id";
            officeIdTB.ReadOnly = true;
            officeIdTB.Size = new Size(71, 23);
            officeIdTB.TabIndex = 33;
            // 
            // officeSearchButton
            // 
            officeSearchButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            officeSearchButton.Location = new Point(440, 255);
            officeSearchButton.Name = "officeSearchButton";
            officeSearchButton.Size = new Size(74, 26);
            officeSearchButton.TabIndex = 32;
            officeSearchButton.Text = "Search";
            officeSearchButton.UseVisualStyleBackColor = true;
            officeSearchButton.Click += officeSearchButton_Click;
            // 
            // officeSearchTB
            // 
            officeSearchTB.Location = new Point(22, 259);
            officeSearchTB.Name = "officeSearchTB";
            officeSearchTB.PlaceholderText = "Enter an office name or ID then click this button -->";
            officeSearchTB.Size = new Size(409, 23);
            officeSearchTB.TabIndex = 31;
            // 
            // apptIdTB
            // 
            apptIdTB.Location = new Point(679, 282);
            apptIdTB.Name = "apptIdTB";
            apptIdTB.PlaceholderText = "Appt Id";
            apptIdTB.ReadOnly = true;
            apptIdTB.Size = new Size(71, 23);
            apptIdTB.TabIndex = 38;
            // 
            // officeRadioBtn
            // 
            officeRadioBtn.AutoSize = true;
            officeRadioBtn.Location = new Point(535, 282);
            officeRadioBtn.Name = "officeRadioBtn";
            officeRadioBtn.Size = new Size(131, 19);
            officeRadioBtn.TabIndex = 39;
            officeRadioBtn.TabStop = true;
            officeRadioBtn.Text = "Office Appointment";
            officeRadioBtn.UseVisualStyleBackColor = true;
            officeRadioBtn.CheckedChanged += CheckedChanged;
            // 
            // homeRadioBtn
            // 
            homeRadioBtn.AutoSize = true;
            homeRadioBtn.Location = new Point(535, 307);
            homeRadioBtn.Name = "homeRadioBtn";
            homeRadioBtn.Size = new Size(132, 19);
            homeRadioBtn.TabIndex = 40;
            homeRadioBtn.TabStop = true;
            homeRadioBtn.Text = "Home Appointment";
            homeRadioBtn.UseVisualStyleBackColor = true;
            homeRadioBtn.CheckedChanged += CheckedChanged;
            // 
            // cityTB
            // 
            cityTB.Location = new Point(23, 403);
            cityTB.Name = "cityTB";
            cityTB.PlaceholderText = "City";
            cityTB.Size = new Size(408, 23);
            cityTB.TabIndex = 52;
            // 
            // address2TB
            // 
            address2TB.Location = new Point(23, 376);
            address2TB.Name = "address2TB";
            address2TB.PlaceholderText = "Address Line 2 (Optional)";
            address2TB.Size = new Size(408, 23);
            address2TB.TabIndex = 51;
            // 
            // countryTB
            // 
            countryTB.Location = new Point(126, 430);
            countryTB.Name = "countryTB";
            countryTB.PlaceholderText = "Country";
            countryTB.Size = new Size(305, 23);
            countryTB.TabIndex = 50;
            // 
            // stateTB
            // 
            stateTB.Location = new Point(23, 430);
            stateTB.Name = "stateTB";
            stateTB.PlaceholderText = "State";
            stateTB.Size = new Size(94, 23);
            stateTB.TabIndex = 49;
            // 
            // address1TB
            // 
            address1TB.Location = new Point(23, 348);
            address1TB.Name = "address1TB";
            address1TB.PlaceholderText = "Address Line 1";
            address1TB.Size = new Size(408, 23);
            address1TB.TabIndex = 48;
            // 
            // addressIdTB
            // 
            addressIdTB.Location = new Point(440, 348);
            addressIdTB.Name = "addressIdTB";
            addressIdTB.PlaceholderText = "Address Id";
            addressIdTB.ReadOnly = true;
            addressIdTB.Size = new Size(76, 23);
            addressIdTB.TabIndex = 47;
            // 
            // homeSearchBtn
            // 
            homeSearchBtn.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            homeSearchBtn.Location = new Point(438, 316);
            homeSearchBtn.Name = "homeSearchBtn";
            homeSearchBtn.Size = new Size(75, 26);
            homeSearchBtn.TabIndex = 54;
            homeSearchBtn.Text = "Search";
            homeSearchBtn.UseVisualStyleBackColor = true;
            homeSearchBtn.Click += homeSearchBtn_Click;
            // 
            // saSearchTB
            // 
            saSearchTB.Location = new Point(23, 320);
            saSearchTB.Name = "saSearchTB";
            saSearchTB.PlaceholderText = "If Cx has previously had a home appt, search here";
            saSearchTB.Size = new Size(408, 23);
            saSearchTB.TabIndex = 53;
            // 
            // debugBtn
            // 
            debugBtn.BackColor = Color.LightSteelBlue;
            debugBtn.Location = new Point(601, 364);
            debugBtn.Name = "debugBtn";
            debugBtn.Size = new Size(100, 44);
            debugBtn.TabIndex = 55;
            debugBtn.Text = "Debug";
            debugBtn.UseVisualStyleBackColor = false;
            debugBtn.Click += debugBtn_Click;
            // 
            // FormAppointment
            // 
            AcceptButton = saveBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBtn;
            ClientSize = new Size(784, 495);
            Controls.Add(debugBtn);
            Controls.Add(homeSearchBtn);
            Controls.Add(saSearchTB);
            Controls.Add(cityTB);
            Controls.Add(address2TB);
            Controls.Add(countryTB);
            Controls.Add(stateTB);
            Controls.Add(address1TB);
            Controls.Add(addressIdTB);
            Controls.Add(homeRadioBtn);
            Controls.Add(officeRadioBtn);
            Controls.Add(apptIdTB);
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
        private TextBox officeNameTB;
        private TextBox officeIdTB;
        private Button officeSearchButton;
        private TextBox officeSearchTB;
        private TextBox apptIdTB;
        private RadioButton officeRadioBtn;
        private RadioButton homeRadioBtn;
        private TextBox cityTB;
        private TextBox address2TB;
        private TextBox countryTB;
        private TextBox stateTB;
        private TextBox address1TB;
        private TextBox addressIdTB;
        private Button homeSearchBtn;
        private TextBox saSearchTB;
        private Button debugBtn;
    }
}