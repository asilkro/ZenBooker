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
            removeBtn = new Button();
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
            SuspendLayout();
            // 
            // removeBtn
            // 
            removeBtn.BackColor = Color.RosyBrown;
            removeBtn.Location = new Point(50, 475);
            removeBtn.Name = "removeBtn";
            removeBtn.Size = new Size(100, 50);
            removeBtn.TabIndex = 6;
            removeBtn.Text = "Remove";
            removeBtn.UseVisualStyleBackColor = false;
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.LightSteelBlue;
            saveBtn.Location = new Point(525, 475);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(100, 50);
            saveBtn.TabIndex = 5;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = false;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(650, 475);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(100, 50);
            cancelBtn.TabIndex = 4;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // dateCalendar
            // 
            dateCalendar.FirstDayOfWeek = Day.Saturday;
            dateCalendar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dateCalendar.Location = new Point(539, 38);
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
            startDtPicker.Location = new Point(675, 202);
            startDtPicker.Name = "startDtPicker";
            startDtPicker.Size = new Size(75, 29);
            startDtPicker.TabIndex = 8;
            startDtPicker.Value = new DateTime(2023, 9, 17, 14, 0, 0, 0);
            // 
            // endDtPicker
            // 
            endDtPicker.Checked = false;
            endDtPicker.CustomFormat = "HH:mm";
            endDtPicker.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            endDtPicker.Format = DateTimePickerFormat.Custom;
            endDtPicker.Location = new Point(675, 237);
            endDtPicker.Name = "endDtPicker";
            endDtPicker.Size = new Size(75, 29);
            endDtPicker.TabIndex = 9;
            endDtPicker.Value = new DateTime(2023, 9, 17, 15, 0, 0, 0);
            // 
            // cxSearchTB
            // 
            cxSearchTB.Location = new Point(23, 38);
            cxSearchTB.Name = "cxSearchTB";
            cxSearchTB.PlaceholderText = "Enter a customer name, email, and/or ID then click this button -->";
            cxSearchTB.Size = new Size(409, 25);
            cxSearchTB.TabIndex = 14;
            // 
            // cxSearchButton
            // 
            cxSearchButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cxSearchButton.Location = new Point(438, 35);
            cxSearchButton.Name = "cxSearchButton";
            cxSearchButton.Size = new Size(75, 29);
            cxSearchButton.TabIndex = 15;
            cxSearchButton.Text = "Search";
            cxSearchButton.UseVisualStyleBackColor = true;
            cxSearchButton.Click += cxSearchButton_Click;
            // 
            // cxIdTB
            // 
            cxIdTB.Location = new Point(440, 68);
            cxIdTB.Name = "cxIdTB";
            cxIdTB.PlaceholderText = "Cust. Id";
            cxIdTB.ReadOnly = true;
            cxIdTB.Size = new Size(73, 25);
            cxIdTB.TabIndex = 16;
            // 
            // cxNameTb
            // 
            cxNameTb.Location = new Point(23, 68);
            cxNameTb.Name = "cxNameTb";
            cxNameTb.PlaceholderText = "Customer Name";
            cxNameTb.ReadOnly = true;
            cxNameTb.Size = new Size(409, 25);
            cxNameTb.TabIndex = 17;
            // 
            // cxEmailTB
            // 
            cxEmailTB.Location = new Point(23, 99);
            cxEmailTB.Name = "cxEmailTB";
            cxEmailTB.PlaceholderText = "Customer Email";
            cxEmailTB.ReadOnly = true;
            cxEmailTB.Size = new Size(409, 25);
            cxEmailTB.TabIndex = 18;
            // 
            // cxPhoneTB
            // 
            cxPhoneTB.Location = new Point(23, 130);
            cxPhoneTB.Name = "cxPhoneTB";
            cxPhoneTB.PlaceholderText = "Customer Phone";
            cxPhoneTB.ReadOnly = true;
            cxPhoneTB.Size = new Size(409, 25);
            cxPhoneTB.TabIndex = 19;
            // 
            // staffSearchButton
            // 
            staffSearchButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            staffSearchButton.Location = new Point(438, 167);
            staffSearchButton.Name = "staffSearchButton";
            staffSearchButton.Size = new Size(75, 29);
            staffSearchButton.TabIndex = 21;
            staffSearchButton.Text = "Search";
            staffSearchButton.UseVisualStyleBackColor = true;
            staffSearchButton.Click += staffSearchButton_Click;
            // 
            // staffSearchTB
            // 
            staffSearchTB.Location = new Point(23, 170);
            staffSearchTB.Name = "staffSearchTB";
            staffSearchTB.PlaceholderText = "Enter the staff member's name, email then click this button -->";
            staffSearchTB.Size = new Size(409, 25);
            staffSearchTB.TabIndex = 20;
            // 
            // staffNameTb
            // 
            staffNameTb.Location = new Point(23, 201);
            staffNameTb.Name = "staffNameTb";
            staffNameTb.PlaceholderText = "Staff Member";
            staffNameTb.ReadOnly = true;
            staffNameTb.Size = new Size(409, 25);
            staffNameTb.TabIndex = 23;
            // 
            // staffIdTB
            // 
            staffIdTB.Location = new Point(440, 201);
            staffIdTB.Name = "staffIdTB";
            staffIdTB.PlaceholderText = "Staff Id";
            staffIdTB.ReadOnly = true;
            staffIdTB.Size = new Size(73, 25);
            staffIdTB.TabIndex = 22;
            // 
            // startLbl
            // 
            startLbl.AutoSize = true;
            startLbl.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            startLbl.Location = new Point(613, 204);
            startLbl.Name = "startLbl";
            startLbl.Size = new Size(56, 25);
            startLbl.TabIndex = 24;
            startLbl.Text = "Start";
            // 
            // endLbl
            // 
            endLbl.AutoSize = true;
            endLbl.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            endLbl.Location = new Point(623, 241);
            endLbl.Name = "endLbl";
            endLbl.Size = new Size(46, 25);
            endLbl.TabIndex = 25;
            endLbl.Text = "End";
            // 
            // serviceSearchButton
            // 
            serviceSearchButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            serviceSearchButton.Location = new Point(440, 233);
            serviceSearchButton.Name = "serviceSearchButton";
            serviceSearchButton.Size = new Size(75, 29);
            serviceSearchButton.TabIndex = 27;
            serviceSearchButton.Text = "Search";
            serviceSearchButton.UseVisualStyleBackColor = true;
            serviceSearchButton.Click += serviceSearchButton_Click;
            // 
            // serviceSearchTB
            // 
            serviceSearchTB.Location = new Point(23, 237);
            serviceSearchTB.Name = "serviceSearchTB";
            serviceSearchTB.PlaceholderText = "Enter a service name and/or ID then click this button -->";
            serviceSearchTB.Size = new Size(409, 25);
            serviceSearchTB.TabIndex = 26;
            // 
            // serviceDescTb
            // 
            serviceDescTb.Location = new Point(23, 299);
            serviceDescTb.Name = "serviceDescTb";
            serviceDescTb.PlaceholderText = "Service Description";
            serviceDescTb.ReadOnly = true;
            serviceDescTb.Size = new Size(490, 25);
            serviceDescTb.TabIndex = 30;
            // 
            // serviceNameTb
            // 
            serviceNameTb.Location = new Point(23, 268);
            serviceNameTb.Name = "serviceNameTb";
            serviceNameTb.PlaceholderText = "Service Name";
            serviceNameTb.ReadOnly = true;
            serviceNameTb.Size = new Size(409, 25);
            serviceNameTb.TabIndex = 29;
            // 
            // serviceIdTB
            // 
            serviceIdTB.Location = new Point(440, 268);
            serviceIdTB.Name = "serviceIdTB";
            serviceIdTB.PlaceholderText = "Service Id";
            serviceIdTB.ReadOnly = true;
            serviceIdTB.Size = new Size(75, 25);
            serviceIdTB.TabIndex = 28;
            // 
            // officeCityTB
            // 
            officeCityTB.Location = new Point(23, 404);
            officeCityTB.Name = "officeCityTB";
            officeCityTB.PlaceholderText = "Office City";
            officeCityTB.ReadOnly = true;
            officeCityTB.Size = new Size(220, 25);
            officeCityTB.TabIndex = 35;
            // 
            // officeNameTB
            // 
            officeNameTB.Location = new Point(23, 373);
            officeNameTB.Name = "officeNameTB";
            officeNameTB.PlaceholderText = "Office Name";
            officeNameTB.ReadOnly = true;
            officeNameTB.Size = new Size(409, 25);
            officeNameTB.TabIndex = 34;
            // 
            // officeIdTB
            // 
            officeIdTB.Location = new Point(444, 373);
            officeIdTB.Name = "officeIdTB";
            officeIdTB.PlaceholderText = "Office Id";
            officeIdTB.ReadOnly = true;
            officeIdTB.Size = new Size(71, 25);
            officeIdTB.TabIndex = 33;
            // 
            // officeSearchButton
            // 
            officeSearchButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            officeSearchButton.Location = new Point(440, 338);
            officeSearchButton.Name = "officeSearchButton";
            officeSearchButton.Size = new Size(75, 29);
            officeSearchButton.TabIndex = 32;
            officeSearchButton.Text = "Search";
            officeSearchButton.UseVisualStyleBackColor = true;
            officeSearchButton.Click += officeSearchButton_Click;
            // 
            // officeSearchTB
            // 
            officeSearchTB.Location = new Point(23, 342);
            officeSearchTB.Name = "officeSearchTB";
            officeSearchTB.PlaceholderText = "Enter an office name, city, or ID then click this button -->";
            officeSearchTB.Size = new Size(409, 25);
            officeSearchTB.TabIndex = 31;
            // 
            // officeStateTB
            // 
            officeStateTB.Location = new Point(249, 404);
            officeStateTB.Name = "officeStateTB";
            officeStateTB.PlaceholderText = "Office State";
            officeStateTB.ReadOnly = true;
            officeStateTB.Size = new Size(95, 25);
            officeStateTB.TabIndex = 36;
            // 
            // officeCountryTB
            // 
            officeCountryTB.Location = new Point(350, 404);
            officeCountryTB.Name = "officeCountryTB";
            officeCountryTB.PlaceholderText = "Office Country";
            officeCountryTB.ReadOnly = true;
            officeCountryTB.Size = new Size(165, 25);
            officeCountryTB.TabIndex = 37;
            // 
            // apptIdTB
            // 
            apptIdTB.Location = new Point(525, 206);
            apptIdTB.Name = "apptIdTB";
            apptIdTB.PlaceholderText = "Appt Id";
            apptIdTB.ReadOnly = true;
            apptIdTB.Size = new Size(71, 25);
            apptIdTB.TabIndex = 38;
            // 
            // FormAppointment
            // 
            AcceptButton = saveBtn;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBtn;
            ClientSize = new Size(784, 561);
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
            Controls.Add(removeBtn);
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

        private Button removeBtn;
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
    }
}