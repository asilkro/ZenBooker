using System.ComponentModel;

namespace ZenoBook.Forms
{
    partial class Admin
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
            servicesSearchBtn = new Button();
            staffSearchBtn = new Button();
            staffSearchTB = new TextBox();
            servicesSearchTB = new TextBox();
            serviceDataGridView = new DataGridView();
            staffDataGridView = new DataGridView();
            RemoveStaffBtn = new Button();
            UpdateStaffBtn = new Button();
            CreateStaffBtn = new Button();
            StaffLbl = new Label();
            RemoveServiceBtn = new Button();
            UpdateServiceBtn = new Button();
            CreateServiceBtn = new Button();
            ServicesLabel = new Label();
            backBtn = new Button();
            changePWbtn = new Button();
            ((System.ComponentModel.ISupportInitialize)serviceDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)staffDataGridView).BeginInit();
            SuspendLayout();
            // 
            // servicesSearchBtn
            // 
            servicesSearchBtn.Location = new Point(303, 265);
            servicesSearchBtn.Margin = new Padding(0);
            servicesSearchBtn.Name = "servicesSearchBtn";
            servicesSearchBtn.Size = new Size(81, 22);
            servicesSearchBtn.TabIndex = 30;
            servicesSearchBtn.Text = "Search";
            servicesSearchBtn.UseVisualStyleBackColor = true;
            servicesSearchBtn.Click += servicesSearchBtn_Click;
            // 
            // staffSearchBtn
            // 
            staffSearchBtn.Location = new Point(303, 41);
            staffSearchBtn.Margin = new Padding(0);
            staffSearchBtn.Name = "staffSearchBtn";
            staffSearchBtn.Size = new Size(81, 22);
            staffSearchBtn.TabIndex = 29;
            staffSearchBtn.Text = "Search";
            staffSearchBtn.UseVisualStyleBackColor = true;
            staffSearchBtn.Click += staffSearchBtn_Click;
            // 
            // staffSearchTB
            // 
            staffSearchTB.Location = new Point(32, 39);
            staffSearchTB.Margin = new Padding(2, 1, 2, 1);
            staffSearchTB.Name = "staffSearchTB";
            staffSearchTB.PlaceholderText = "Search for staff";
            staffSearchTB.Size = new Size(264, 23);
            staffSearchTB.TabIndex = 28;
            // 
            // servicesSearchTB
            // 
            servicesSearchTB.Location = new Point(32, 264);
            servicesSearchTB.Margin = new Padding(2, 1, 2, 1);
            servicesSearchTB.Name = "servicesSearchTB";
            servicesSearchTB.PlaceholderText = "Search for services";
            servicesSearchTB.Size = new Size(264, 23);
            servicesSearchTB.TabIndex = 27;
            // 
            // serviceDataGridView
            // 
            serviceDataGridView.AllowUserToAddRows = false;
            serviceDataGridView.AllowUserToDeleteRows = false;
            serviceDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            serviceDataGridView.Location = new Point(32, 291);
            serviceDataGridView.Margin = new Padding(3, 2, 3, 2);
            serviceDataGridView.Name = "serviceDataGridView";
            serviceDataGridView.ReadOnly = true;
            serviceDataGridView.RowHeadersVisible = false;
            serviceDataGridView.RowHeadersWidth = 51;
            serviceDataGridView.RowTemplate.Height = 29;
            serviceDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            serviceDataGridView.ShowEditingIcon = false;
            serviceDataGridView.Size = new Size(475, 141);
            serviceDataGridView.TabIndex = 26;
            // 
            // staffDataGridView
            // 
            staffDataGridView.AllowUserToAddRows = false;
            staffDataGridView.AllowUserToDeleteRows = false;
            staffDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            staffDataGridView.Location = new Point(32, 65);
            staffDataGridView.Margin = new Padding(3, 2, 3, 2);
            staffDataGridView.Name = "staffDataGridView";
            staffDataGridView.ReadOnly = true;
            staffDataGridView.RowHeadersVisible = false;
            staffDataGridView.RowHeadersWidth = 51;
            staffDataGridView.RowTemplate.Height = 29;
            staffDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            staffDataGridView.ShowEditingIcon = false;
            staffDataGridView.Size = new Size(475, 141);
            staffDataGridView.TabIndex = 25;
            // 
            // RemoveStaffBtn
            // 
            RemoveStaffBtn.Location = new Point(425, 210);
            RemoveStaffBtn.Margin = new Padding(3, 2, 3, 2);
            RemoveStaffBtn.Name = "RemoveStaffBtn";
            RemoveStaffBtn.Size = new Size(82, 22);
            RemoveStaffBtn.TabIndex = 24;
            RemoveStaffBtn.Text = "Remove";
            RemoveStaffBtn.UseVisualStyleBackColor = true;
            RemoveStaffBtn.Click += RemoveStaffBtn_Click;
            // 
            // UpdateStaffBtn
            // 
            UpdateStaffBtn.Location = new Point(337, 212);
            UpdateStaffBtn.Margin = new Padding(3, 2, 3, 2);
            UpdateStaffBtn.Name = "UpdateStaffBtn";
            UpdateStaffBtn.Size = new Size(82, 22);
            UpdateStaffBtn.TabIndex = 23;
            UpdateStaffBtn.Text = "Update";
            UpdateStaffBtn.UseVisualStyleBackColor = true;
            UpdateStaffBtn.Click += UpdateStaffBtn_Click;
            // 
            // CreateStaffBtn
            // 
            CreateStaffBtn.Location = new Point(249, 212);
            CreateStaffBtn.Margin = new Padding(3, 2, 3, 2);
            CreateStaffBtn.Name = "CreateStaffBtn";
            CreateStaffBtn.Size = new Size(82, 22);
            CreateStaffBtn.TabIndex = 22;
            CreateStaffBtn.Text = "Create";
            CreateStaffBtn.UseVisualStyleBackColor = true;
            CreateStaffBtn.Click += CreateStaffBtn_Click;
            // 
            // StaffLbl
            // 
            StaffLbl.AutoSize = true;
            StaffLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            StaffLbl.Location = new Point(32, 9);
            StaffLbl.Name = "StaffLbl";
            StaffLbl.Size = new Size(41, 21);
            StaffLbl.TabIndex = 21;
            StaffLbl.Text = "Staff";
            // 
            // RemoveServiceBtn
            // 
            RemoveServiceBtn.Location = new Point(425, 439);
            RemoveServiceBtn.Margin = new Padding(3, 2, 3, 2);
            RemoveServiceBtn.Name = "RemoveServiceBtn";
            RemoveServiceBtn.Size = new Size(82, 22);
            RemoveServiceBtn.TabIndex = 20;
            RemoveServiceBtn.Text = "Remove";
            RemoveServiceBtn.UseVisualStyleBackColor = true;
            RemoveServiceBtn.Click += RemoveServiceBtn_Click;
            // 
            // UpdateServiceBtn
            // 
            UpdateServiceBtn.Location = new Point(336, 440);
            UpdateServiceBtn.Margin = new Padding(3, 2, 3, 2);
            UpdateServiceBtn.Name = "UpdateServiceBtn";
            UpdateServiceBtn.Size = new Size(82, 22);
            UpdateServiceBtn.TabIndex = 19;
            UpdateServiceBtn.Text = "Update";
            UpdateServiceBtn.UseVisualStyleBackColor = true;
            UpdateServiceBtn.Click += UpdateServiceBtn_Click;
            // 
            // CreateServiceBtn
            // 
            CreateServiceBtn.Location = new Point(248, 440);
            CreateServiceBtn.Margin = new Padding(3, 2, 3, 2);
            CreateServiceBtn.Name = "CreateServiceBtn";
            CreateServiceBtn.Size = new Size(82, 22);
            CreateServiceBtn.TabIndex = 18;
            CreateServiceBtn.Text = "Create";
            CreateServiceBtn.UseVisualStyleBackColor = true;
            CreateServiceBtn.Click += CreateServiceBtn_Click;
            // 
            // ServicesLabel
            // 
            ServicesLabel.AutoSize = true;
            ServicesLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ServicesLabel.Location = new Point(32, 232);
            ServicesLabel.Name = "ServicesLabel";
            ServicesLabel.Size = new Size(67, 21);
            ServicesLabel.TabIndex = 17;
            ServicesLabel.Text = "Services";
            // 
            // backBtn
            // 
            backBtn.Location = new Point(672, 439);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(100, 44);
            backBtn.TabIndex = 31;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // changePWbtn
            // 
            changePWbtn.Location = new Point(672, 65);
            changePWbtn.Name = "changePWbtn";
            changePWbtn.Size = new Size(100, 44);
            changePWbtn.TabIndex = 32;
            changePWbtn.Text = "Change Password";
            changePWbtn.UseVisualStyleBackColor = true;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = backBtn;
            ClientSize = new Size(784, 495);
            Controls.Add(changePWbtn);
            Controls.Add(backBtn);
            Controls.Add(servicesSearchBtn);
            Controls.Add(staffSearchBtn);
            Controls.Add(staffSearchTB);
            Controls.Add(servicesSearchTB);
            Controls.Add(serviceDataGridView);
            Controls.Add(staffDataGridView);
            Controls.Add(RemoveStaffBtn);
            Controls.Add(UpdateStaffBtn);
            Controls.Add(CreateStaffBtn);
            Controls.Add(StaffLbl);
            Controls.Add(RemoveServiceBtn);
            Controls.Add(UpdateServiceBtn);
            Controls.Add(CreateServiceBtn);
            Controls.Add(ServicesLabel);
            Name = "Admin";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ZTH - Admin";
            ((System.ComponentModel.ISupportInitialize)serviceDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)staffDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button servicesSearchBtn;
        private Button staffSearchBtn;
        private TextBox staffSearchTB;
        private TextBox servicesSearchTB;
        private DataGridView serviceDataGridView;
        private DataGridView staffDataGridView;
        private Button RemoveStaffBtn;
        private Button UpdateStaffBtn;
        private Button CreateStaffBtn;
        private Label StaffLbl;
        private Button RemoveServiceBtn;
        private Button UpdateServiceBtn;
        private Button CreateServiceBtn;
        private Label ServicesLabel;
        private Button backBtn;
        private Button changePWbtn;
    }
}