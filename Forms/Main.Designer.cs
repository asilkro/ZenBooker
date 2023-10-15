namespace ZenoBook.Forms
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            logoutBtn = new Button();
            CxLabel = new Label();
            CxCreateBtn = new Button();
            UpdateCxBtn = new Button();
            RemoveCxBtn = new Button();
            RemoveApptBtn = new Button();
            UpdateApptBtn = new Button();
            CreateApptBtn = new Button();
            ApptsLbl = new Label();
            pictureBox1 = new PictureBox();
            apptsDataGridView = new DataGridView();
            cxDataGridView = new DataGridView();
            cxSearchTB = new TextBox();
            apptSearchTB = new TextBox();
            apptSearchBtn = new Button();
            cxSearchBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)apptsDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cxDataGridView).BeginInit();
            SuspendLayout();
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(1248, 939);
            logoutBtn.Margin = new Padding(6);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(186, 94);
            logoutBtn.TabIndex = 1;
            logoutBtn.Text = "Log Out";
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // CxLabel
            // 
            CxLabel.AutoSize = true;
            CxLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CxLabel.Location = new Point(59, 521);
            CxLabel.Margin = new Padding(6, 0, 6, 0);
            CxLabel.Name = "CxLabel";
            CxLabel.Size = new Size(172, 45);
            CxLabel.TabIndex = 2;
            CxLabel.Text = "Customers";
            // 
            // CxCreateBtn
            // 
            CxCreateBtn.Location = new Point(59, 939);
            CxCreateBtn.Margin = new Padding(6, 4, 6, 4);
            CxCreateBtn.Name = "CxCreateBtn";
            CxCreateBtn.Size = new Size(152, 47);
            CxCreateBtn.TabIndex = 3;
            CxCreateBtn.Text = "Create";
            CxCreateBtn.UseVisualStyleBackColor = true;
            CxCreateBtn.Click += CxCreateBtn_Click;
            // 
            // UpdateCxBtn
            // 
            UpdateCxBtn.Location = new Point(230, 939);
            UpdateCxBtn.Margin = new Padding(6, 4, 6, 4);
            UpdateCxBtn.Name = "UpdateCxBtn";
            UpdateCxBtn.Size = new Size(152, 47);
            UpdateCxBtn.TabIndex = 4;
            UpdateCxBtn.Text = "Update";
            UpdateCxBtn.UseVisualStyleBackColor = true;
            UpdateCxBtn.Click += UpdateCxBtn_Click;
            // 
            // RemoveCxBtn
            // 
            RemoveCxBtn.Location = new Point(394, 939);
            RemoveCxBtn.Margin = new Padding(6, 4, 6, 4);
            RemoveCxBtn.Name = "RemoveCxBtn";
            RemoveCxBtn.Size = new Size(152, 47);
            RemoveCxBtn.TabIndex = 5;
            RemoveCxBtn.Text = "Remove";
            RemoveCxBtn.UseVisualStyleBackColor = true;
            RemoveCxBtn.Click += RemoveCxBtn_Click;
            // 
            // RemoveApptBtn
            // 
            RemoveApptBtn.Location = new Point(394, 448);
            RemoveApptBtn.Margin = new Padding(6, 4, 6, 4);
            RemoveApptBtn.Name = "RemoveApptBtn";
            RemoveApptBtn.Size = new Size(152, 47);
            RemoveApptBtn.TabIndex = 9;
            RemoveApptBtn.Text = "Remove";
            RemoveApptBtn.UseVisualStyleBackColor = true;
            RemoveApptBtn.Click += RemoveApptBtn_Click;
            // 
            // UpdateApptBtn
            // 
            UpdateApptBtn.Location = new Point(223, 448);
            UpdateApptBtn.Margin = new Padding(6, 4, 6, 4);
            UpdateApptBtn.Name = "UpdateApptBtn";
            UpdateApptBtn.Size = new Size(152, 47);
            UpdateApptBtn.TabIndex = 8;
            UpdateApptBtn.Text = "Update";
            UpdateApptBtn.UseVisualStyleBackColor = true;
            UpdateApptBtn.Click += UpdateApptBtn_Click;
            // 
            // CreateApptBtn
            // 
            CreateApptBtn.Location = new Point(59, 448);
            CreateApptBtn.Margin = new Padding(6, 4, 6, 4);
            CreateApptBtn.Name = "CreateApptBtn";
            CreateApptBtn.Size = new Size(152, 47);
            CreateApptBtn.TabIndex = 7;
            CreateApptBtn.Text = "Create";
            CreateApptBtn.UseVisualStyleBackColor = true;
            CreateApptBtn.Click += CreateApptBtn_Click;
            // 
            // ApptsLbl
            // 
            ApptsLbl.AutoSize = true;
            ApptsLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ApptsLbl.Location = new Point(59, 19);
            ApptsLbl.Margin = new Padding(6, 0, 6, 0);
            ApptsLbl.Name = "ApptsLbl";
            ApptsLbl.Size = new Size(223, 45);
            ApptsLbl.TabIndex = 6;
            ApptsLbl.Text = "Appointments";
            // 
            // pictureBox1
            // 
            pictureBox1.Enabled = false;
            pictureBox1.Image = Properties.Resources.Zenobia_Transparent;
            pictureBox1.Location = new Point(1202, 23);
            pictureBox1.Margin = new Padding(6, 4, 6, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(240, 240);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // apptsDataGridView
            // 
            apptsDataGridView.AllowUserToAddRows = false;
            apptsDataGridView.AllowUserToDeleteRows = false;
            apptsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            apptsDataGridView.Location = new Point(59, 139);
            apptsDataGridView.Margin = new Padding(6, 4, 6, 4);
            apptsDataGridView.Name = "apptsDataGridView";
            apptsDataGridView.ReadOnly = true;
            apptsDataGridView.RowHeadersWidth = 51;
            apptsDataGridView.RowTemplate.Height = 29;
            apptsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            apptsDataGridView.Size = new Size(487, 301);
            apptsDataGridView.TabIndex = 11;
            // 
            // cxDataGridView
            // 
            cxDataGridView.AllowUserToAddRows = false;
            cxDataGridView.AllowUserToDeleteRows = false;
            cxDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cxDataGridView.Location = new Point(59, 625);
            cxDataGridView.Margin = new Padding(6, 4, 6, 4);
            cxDataGridView.Name = "cxDataGridView";
            cxDataGridView.ReadOnly = true;
            cxDataGridView.RowHeadersWidth = 51;
            cxDataGridView.RowTemplate.Height = 29;
            cxDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cxDataGridView.Size = new Size(487, 301);
            cxDataGridView.TabIndex = 12;
            // 
            // cxSearchTB
            // 
            cxSearchTB.Location = new Point(59, 576);
            cxSearchTB.Name = "cxSearchTB";
            cxSearchTB.PlaceholderText = "Search for customer (email, phone, or name)";
            cxSearchTB.Size = new Size(487, 39);
            cxSearchTB.TabIndex = 13;
            // 
            // apptSearchTB
            // 
            apptSearchTB.Location = new Point(59, 93);
            apptSearchTB.Name = "apptSearchTB";
            apptSearchTB.PlaceholderText = "Search for Appointment (date or cxId)";
            apptSearchTB.Size = new Size(487, 39);
            apptSearchTB.TabIndex = 14;
            // 
            // apptSearchBtn
            // 
            apptSearchBtn.Location = new Point(562, 93);
            apptSearchBtn.Margin = new Padding(0);
            apptSearchBtn.Name = "apptSearchBtn";
            apptSearchBtn.Size = new Size(150, 46);
            apptSearchBtn.TabIndex = 15;
            apptSearchBtn.Text = "Search";
            apptSearchBtn.UseVisualStyleBackColor = true;
            apptSearchBtn.Click += apptSearchBtn_Click;
            // 
            // cxSearchBtn
            // 
            cxSearchBtn.Location = new Point(571, 576);
            cxSearchBtn.Margin = new Padding(0);
            cxSearchBtn.Name = "cxSearchBtn";
            cxSearchBtn.Size = new Size(150, 46);
            cxSearchBtn.TabIndex = 16;
            cxSearchBtn.Text = "Search";
            cxSearchBtn.UseVisualStyleBackColor = true;
            cxSearchBtn.Click += cxSearchBtn_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = logoutBtn;
            ClientSize = new Size(1456, 1056);
            Controls.Add(cxSearchBtn);
            Controls.Add(apptSearchBtn);
            Controls.Add(apptSearchTB);
            Controls.Add(cxSearchTB);
            Controls.Add(cxDataGridView);
            Controls.Add(apptsDataGridView);
            Controls.Add(pictureBox1);
            Controls.Add(RemoveApptBtn);
            Controls.Add(UpdateApptBtn);
            Controls.Add(CreateApptBtn);
            Controls.Add(ApptsLbl);
            Controls.Add(RemoveCxBtn);
            Controls.Add(UpdateCxBtn);
            Controls.Add(CxCreateBtn);
            Controls.Add(CxLabel);
            Controls.Add(logoutBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(6);
            Name = "Main";
            Text = "ZTH - ZenoBook";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)apptsDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)cxDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button logoutBtn;
        private Label CxLabel;
        private Button CxCreateBtn;
        private Button UpdateCxBtn;
        private Button RemoveCxBtn;
        private Button RemoveApptBtn;
        private Button UpdateApptBtn;
        private Button CreateApptBtn;
        private Label ApptsLbl;
        private PictureBox pictureBox1;
        private DataGridView apptsDataGridView;
        private DataGridView cxDataGridView;
        private TextBox cxSearchTB;
        private TextBox apptSearchTB;
        private Button apptSearchBtn;
        private Button cxSearchBtn;
    }
}