using System.ComponentModel;

namespace ZenoBook.Forms
{
    partial class Main
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Main));
            logoutBtn = new Button();
            CxLabel = new Label();
            CreateCxBtn = new Button();
            UpdateCxBtn = new Button();
            RemoveCxBtn = new Button();
            RemoveApptBtn = new Button();
            UpdateApptBtn = new Button();
            CreateApptBtn = new Button();
            ApptsLbl = new Label();
            Logo = new PictureBox();
            apptsDataGridView = new DataGridView();
            cxDataGridView = new DataGridView();
            cxSearchTB = new TextBox();
            apptSearchTB = new TextBox();
            apptSearchBtn = new Button();
            cxSearchBtn = new Button();
            otherBtn = new Button();
            todayApptsBtn = new Button();
            tomorrowApptsBtn = new Button();
            weekApptsBtn = new Button();
            monthApptsBtn = new Button();
            ((ISupportInitialize)Logo).BeginInit();
            ((ISupportInitialize)apptsDataGridView).BeginInit();
            ((ISupportInitialize)cxDataGridView).BeginInit();
            SuspendLayout();
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(672, 440);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(100, 44);
            logoutBtn.TabIndex = 1;
            logoutBtn.Text = "Log Out";
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += LogoutBtn_Click;
            // 
            // CxLabel
            // 
            CxLabel.AutoSize = true;
            CxLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CxLabel.Location = new Point(32, 244);
            CxLabel.Name = "CxLabel";
            CxLabel.Size = new Size(85, 21);
            CxLabel.TabIndex = 2;
            CxLabel.Text = "Customers";
            // 
            // CreateCxBtn
            // 
            CreateCxBtn.Location = new Point(266, 438);
            CreateCxBtn.Margin = new Padding(3, 2, 3, 2);
            CreateCxBtn.Name = "CreateCxBtn";
            CreateCxBtn.Size = new Size(82, 22);
            CreateCxBtn.TabIndex = 3;
            CreateCxBtn.Text = "Create";
            CreateCxBtn.UseVisualStyleBackColor = true;
            CreateCxBtn.Click += CreateCxBtnClick;
            // 
            // UpdateCxBtn
            // 
            UpdateCxBtn.Location = new Point(350, 438);
            UpdateCxBtn.Margin = new Padding(3, 2, 3, 2);
            UpdateCxBtn.Name = "UpdateCxBtn";
            UpdateCxBtn.Size = new Size(82, 22);
            UpdateCxBtn.TabIndex = 4;
            UpdateCxBtn.Text = "Update";
            UpdateCxBtn.UseVisualStyleBackColor = true;
            UpdateCxBtn.Click += UpdateCxBtn_Click;
            // 
            // RemoveCxBtn
            // 
            RemoveCxBtn.Location = new Point(435, 438);
            RemoveCxBtn.Margin = new Padding(3, 2, 3, 2);
            RemoveCxBtn.Name = "RemoveCxBtn";
            RemoveCxBtn.Size = new Size(82, 22);
            RemoveCxBtn.TabIndex = 5;
            RemoveCxBtn.Text = "Remove";
            RemoveCxBtn.UseVisualStyleBackColor = true;
            RemoveCxBtn.Click += RemoveCxBtn_Click;
            // 
            // RemoveApptBtn
            // 
            RemoveApptBtn.Location = new Point(435, 210);
            RemoveApptBtn.Margin = new Padding(3, 2, 3, 2);
            RemoveApptBtn.Name = "RemoveApptBtn";
            RemoveApptBtn.Size = new Size(82, 22);
            RemoveApptBtn.TabIndex = 9;
            RemoveApptBtn.Text = "Remove";
            RemoveApptBtn.UseVisualStyleBackColor = true;
            RemoveApptBtn.Click += RemoveApptBtn_Click;
            // 
            // UpdateApptBtn
            // 
            UpdateApptBtn.Location = new Point(350, 210);
            UpdateApptBtn.Margin = new Padding(3, 2, 3, 2);
            UpdateApptBtn.Name = "UpdateApptBtn";
            UpdateApptBtn.Size = new Size(82, 22);
            UpdateApptBtn.TabIndex = 8;
            UpdateApptBtn.Text = "Update";
            UpdateApptBtn.UseVisualStyleBackColor = true;
            UpdateApptBtn.Click += UpdateApptBtn_Click;
            // 
            // CreateApptBtn
            // 
            CreateApptBtn.Location = new Point(266, 210);
            CreateApptBtn.Margin = new Padding(3, 2, 3, 2);
            CreateApptBtn.Name = "CreateApptBtn";
            CreateApptBtn.Size = new Size(82, 22);
            CreateApptBtn.TabIndex = 7;
            CreateApptBtn.Text = "Create";
            CreateApptBtn.UseVisualStyleBackColor = true;
            CreateApptBtn.Click += CreateApptBtn_Click;
            // 
            // ApptsLbl
            // 
            ApptsLbl.AutoSize = true;
            ApptsLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ApptsLbl.Location = new Point(32, 9);
            ApptsLbl.Name = "ApptsLbl";
            ApptsLbl.Size = new Size(108, 21);
            ApptsLbl.TabIndex = 6;
            ApptsLbl.Text = "Appointments";
            // 
            // Logo
            // 
            Logo.Image = Properties.Resources.Zenobia_Transparent;
            Logo.Location = new Point(684, 0);
            Logo.Margin = new Padding(3, 2, 3, 2);
            Logo.Name = "Logo";
            Logo.Size = new Size(100, 100);
            Logo.SizeMode = PictureBoxSizeMode.StretchImage;
            Logo.TabIndex = 10;
            Logo.TabStop = false;
            Logo.Click += Logo_Click;
            // 
            // apptsDataGridView
            // 
            apptsDataGridView.AllowUserToAddRows = false;
            apptsDataGridView.AllowUserToDeleteRows = false;
            apptsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            apptsDataGridView.Location = new Point(32, 65);
            apptsDataGridView.Margin = new Padding(3, 2, 3, 2);
            apptsDataGridView.Name = "apptsDataGridView";
            apptsDataGridView.ReadOnly = true;
            apptsDataGridView.RowHeadersVisible = false;
            apptsDataGridView.RowHeadersWidth = 51;
            apptsDataGridView.RowTemplate.Height = 29;
            apptsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            apptsDataGridView.ShowEditingIcon = false;
            apptsDataGridView.Size = new Size(485, 141);
            apptsDataGridView.TabIndex = 11;
            // 
            // cxDataGridView
            // 
            cxDataGridView.AllowUserToAddRows = false;
            cxDataGridView.AllowUserToDeleteRows = false;
            cxDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cxDataGridView.Location = new Point(32, 293);
            cxDataGridView.Margin = new Padding(3, 2, 3, 2);
            cxDataGridView.Name = "cxDataGridView";
            cxDataGridView.ReadOnly = true;
            cxDataGridView.RowHeadersVisible = false;
            cxDataGridView.RowHeadersWidth = 51;
            cxDataGridView.RowTemplate.Height = 29;
            cxDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cxDataGridView.ShowCellErrors = false;
            cxDataGridView.Size = new Size(485, 141);
            cxDataGridView.TabIndex = 12;
            // 
            // cxSearchTB
            // 
            cxSearchTB.Location = new Point(32, 267);
            cxSearchTB.Margin = new Padding(2, 1, 2, 1);
            cxSearchTB.MaxLength = 64;
            cxSearchTB.Name = "cxSearchTB";
            cxSearchTB.PlaceholderText = "Search by Name, Email or Phone #";
            cxSearchTB.Size = new Size(264, 23);
            cxSearchTB.TabIndex = 13;
            // 
            // apptSearchTB
            // 
            apptSearchTB.Location = new Point(32, 39);
            apptSearchTB.Margin = new Padding(2, 1, 2, 1);
            apptSearchTB.MaxLength = 64;
            apptSearchTB.Name = "apptSearchTB";
            apptSearchTB.PlaceholderText = "Search by Date (MM-DD) or Customer_Id";
            apptSearchTB.Size = new Size(264, 23);
            apptSearchTB.TabIndex = 14;
            // 
            // apptSearchBtn
            // 
            apptSearchBtn.Location = new Point(303, 39);
            apptSearchBtn.Margin = new Padding(0);
            apptSearchBtn.Name = "apptSearchBtn";
            apptSearchBtn.Size = new Size(81, 22);
            apptSearchBtn.TabIndex = 15;
            apptSearchBtn.Text = "Search";
            apptSearchBtn.UseVisualStyleBackColor = true;
            apptSearchBtn.Click += ApptSearchBtn_Click;
            // 
            // cxSearchBtn
            // 
            cxSearchBtn.Location = new Point(305, 267);
            cxSearchBtn.Margin = new Padding(0);
            cxSearchBtn.Name = "cxSearchBtn";
            cxSearchBtn.Size = new Size(81, 22);
            cxSearchBtn.TabIndex = 16;
            cxSearchBtn.Text = "Search";
            cxSearchBtn.UseVisualStyleBackColor = true;
            cxSearchBtn.Click += CxSearchBtn_Click;
            // 
            // otherBtn
            // 
            otherBtn.Location = new Point(523, 181);
            otherBtn.Name = "otherBtn";
            otherBtn.Size = new Size(75, 51);
            otherBtn.TabIndex = 17;
            otherBtn.Text = "Specific Date";
            otherBtn.UseVisualStyleBackColor = true;
            otherBtn.Click += AllApptsBtn_Click;
            // 
            // todayApptsBtn
            // 
            todayApptsBtn.Location = new Point(523, 65);
            todayApptsBtn.Name = "todayApptsBtn";
            todayApptsBtn.Size = new Size(75, 23);
            todayApptsBtn.TabIndex = 18;
            todayApptsBtn.Text = "Today";
            todayApptsBtn.UseVisualStyleBackColor = true;
            todayApptsBtn.Click += TodayApptsBtn_Click;
            // 
            // tomorrowApptsBtn
            // 
            tomorrowApptsBtn.Location = new Point(523, 94);
            tomorrowApptsBtn.Name = "tomorrowApptsBtn";
            tomorrowApptsBtn.Size = new Size(75, 23);
            tomorrowApptsBtn.TabIndex = 18;
            tomorrowApptsBtn.Text = "Tomorrow";
            tomorrowApptsBtn.UseVisualStyleBackColor = true;
            tomorrowApptsBtn.Click += TomorrowApptsBtn_Click;
            // 
            // weekApptsBtn
            // 
            weekApptsBtn.Location = new Point(523, 123);
            weekApptsBtn.Name = "weekApptsBtn";
            weekApptsBtn.Size = new Size(75, 23);
            weekApptsBtn.TabIndex = 18;
            weekApptsBtn.Text = "This Week";
            weekApptsBtn.UseVisualStyleBackColor = true;
            weekApptsBtn.Click += WeekApptsBtn_Click;
            // 
            // monthApptsBtn
            // 
            monthApptsBtn.Location = new Point(523, 152);
            monthApptsBtn.Name = "monthApptsBtn";
            monthApptsBtn.Size = new Size(75, 23);
            monthApptsBtn.TabIndex = 19;
            monthApptsBtn.Text = "This Month";
            monthApptsBtn.UseVisualStyleBackColor = true;
            monthApptsBtn.Click += MonthApptsBtn_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = logoutBtn;
            ClientSize = new Size(784, 495);
            Controls.Add(monthApptsBtn);
            Controls.Add(weekApptsBtn);
            Controls.Add(tomorrowApptsBtn);
            Controls.Add(todayApptsBtn);
            Controls.Add(otherBtn);
            Controls.Add(cxSearchBtn);
            Controls.Add(apptSearchBtn);
            Controls.Add(apptSearchTB);
            Controls.Add(cxSearchTB);
            Controls.Add(cxDataGridView);
            Controls.Add(apptsDataGridView);
            Controls.Add(Logo);
            Controls.Add(RemoveApptBtn);
            Controls.Add(UpdateApptBtn);
            Controls.Add(CreateApptBtn);
            Controls.Add(ApptsLbl);
            Controls.Add(RemoveCxBtn);
            Controls.Add(UpdateCxBtn);
            Controls.Add(CreateCxBtn);
            Controls.Add(CxLabel);
            Controls.Add(logoutBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            Text = "ZTH - ZenoBook";
            ((ISupportInitialize)Logo).EndInit();
            ((ISupportInitialize)apptsDataGridView).EndInit();
            ((ISupportInitialize)cxDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button logoutBtn;
        private Label CxLabel;
        private Button CreateCxBtn;
        private Button UpdateCxBtn;
        private Button RemoveCxBtn;
        private Button RemoveApptBtn;
        private Button UpdateApptBtn;
        private Button CreateApptBtn;
        private Label ApptsLbl;
        private PictureBox Logo;
        private DataGridView apptsDataGridView;
        private DataGridView cxDataGridView;
        private TextBox cxSearchTB;
        private TextBox apptSearchTB;
        private Button apptSearchBtn;
        private Button cxSearchBtn;
        private Button otherBtn;
        private Button todayApptsBtn;
        private Button tomorrowApptsBtn;
        private Button weekApptsBtn;
        private Button monthApptsBtn;
    }
}