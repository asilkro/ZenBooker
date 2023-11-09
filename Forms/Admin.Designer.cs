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
            serviceDGV = new DataGridView();
            staffDGV = new DataGridView();
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
            officeLbl = new Label();
            officeCreateBtn = new Button();
            officeUpdateBtn = new Button();
            officeRemoveBtn = new Button();
            officeDGV = new DataGridView();
            officeSearchTB = new TextBox();
            officeSearchBtn = new Button();
            ((ISupportInitialize)serviceDGV).BeginInit();
            ((ISupportInitialize)staffDGV).BeginInit();
            ((ISupportInitialize)officeDGV).BeginInit();
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
            staffSearchBtn.Location = new Point(304, 39);
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
            staffSearchTB.PlaceholderText = "Enter staff name or email";
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
            // serviceDGV
            // 
            serviceDGV.AllowUserToAddRows = false;
            serviceDGV.AllowUserToDeleteRows = false;
            serviceDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            serviceDGV.Location = new Point(32, 291);
            serviceDGV.Margin = new Padding(3, 2, 3, 2);
            serviceDGV.Name = "serviceDGV";
            serviceDGV.ReadOnly = true;
            serviceDGV.RowHeadersVisible = false;
            serviceDGV.RowHeadersWidth = 51;
            serviceDGV.RowTemplate.Height = 29;
            serviceDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            serviceDGV.ShowEditingIcon = false;
            serviceDGV.Size = new Size(352, 141);
            serviceDGV.TabIndex = 26;
            // 
            // staffDGV
            // 
            staffDGV.AllowUserToAddRows = false;
            staffDGV.AllowUserToDeleteRows = false;
            staffDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            staffDGV.Location = new Point(32, 65);
            staffDGV.Margin = new Padding(3, 2, 3, 2);
            staffDGV.Name = "staffDGV";
            staffDGV.ReadOnly = true;
            staffDGV.RowHeadersVisible = false;
            staffDGV.RowHeadersWidth = 51;
            staffDGV.RowTemplate.Height = 29;
            staffDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            staffDGV.ShowEditingIcon = false;
            staffDGV.Size = new Size(352, 141);
            staffDGV.TabIndex = 25;
            // 
            // RemoveStaffBtn
            // 
            RemoveStaffBtn.Location = new Point(303, 210);
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
            UpdateStaffBtn.Location = new Point(215, 210);
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
            CreateStaffBtn.Location = new Point(127, 210);
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
            RemoveServiceBtn.Location = new Point(303, 439);
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
            UpdateServiceBtn.Location = new Point(215, 439);
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
            CreateServiceBtn.Location = new Point(127, 439);
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
            changePWbtn.Location = new Point(400, 439);
            changePWbtn.Name = "changePWbtn";
            changePWbtn.Size = new Size(164, 44);
            changePWbtn.TabIndex = 32;
            changePWbtn.Text = "Change Password";
            changePWbtn.UseVisualStyleBackColor = true;
            // 
            // officeLbl
            // 
            officeLbl.AutoSize = true;
            officeLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            officeLbl.Location = new Point(400, 9);
            officeLbl.Name = "officeLbl";
            officeLbl.Size = new Size(51, 21);
            officeLbl.TabIndex = 21;
            officeLbl.Text = "Office";
            // 
            // officeCreateBtn
            // 
            officeCreateBtn.Location = new Point(495, 210);
            officeCreateBtn.Margin = new Padding(3, 2, 3, 2);
            officeCreateBtn.Name = "officeCreateBtn";
            officeCreateBtn.Size = new Size(82, 22);
            officeCreateBtn.TabIndex = 22;
            officeCreateBtn.Text = "Create";
            officeCreateBtn.UseVisualStyleBackColor = true;
            officeCreateBtn.Click += officeCreateBtn_Click;
            // 
            // officeUpdateBtn
            // 
            officeUpdateBtn.Location = new Point(583, 210);
            officeUpdateBtn.Margin = new Padding(3, 2, 3, 2);
            officeUpdateBtn.Name = "officeUpdateBtn";
            officeUpdateBtn.Size = new Size(82, 22);
            officeUpdateBtn.TabIndex = 23;
            officeUpdateBtn.Text = "Update";
            officeUpdateBtn.UseVisualStyleBackColor = true;
            officeUpdateBtn.Click += officeUpdateBtn_Click;
            // 
            // officeRemoveBtn
            // 
            officeRemoveBtn.Location = new Point(671, 210);
            officeRemoveBtn.Margin = new Padding(3, 2, 3, 2);
            officeRemoveBtn.Name = "officeRemoveBtn";
            officeRemoveBtn.Size = new Size(82, 22);
            officeRemoveBtn.TabIndex = 24;
            officeRemoveBtn.Text = "Remove";
            officeRemoveBtn.UseVisualStyleBackColor = true;
            officeRemoveBtn.Click += officeRemoveBtn_Click;
            // 
            // officeDGV
            // 
            officeDGV.AllowUserToAddRows = false;
            officeDGV.AllowUserToDeleteRows = false;
            officeDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            officeDGV.Location = new Point(400, 65);
            officeDGV.Margin = new Padding(3, 2, 3, 2);
            officeDGV.Name = "officeDGV";
            officeDGV.ReadOnly = true;
            officeDGV.RowHeadersVisible = false;
            officeDGV.RowHeadersWidth = 51;
            officeDGV.RowTemplate.Height = 29;
            officeDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            officeDGV.ShowEditingIcon = false;
            officeDGV.Size = new Size(352, 141);
            officeDGV.TabIndex = 25;
            // 
            // officeSearchTB
            // 
            officeSearchTB.Location = new Point(400, 39);
            officeSearchTB.Margin = new Padding(2, 1, 2, 1);
            officeSearchTB.Name = "officeSearchTB";
            officeSearchTB.PlaceholderText = "Enter Office Search Here";
            officeSearchTB.Size = new Size(264, 23);
            officeSearchTB.TabIndex = 28;
            // 
            // officeSearchBtn
            // 
            officeSearchBtn.Location = new Point(672, 39);
            officeSearchBtn.Margin = new Padding(0);
            officeSearchBtn.Name = "officeSearchBtn";
            officeSearchBtn.Size = new Size(81, 22);
            officeSearchBtn.TabIndex = 29;
            officeSearchBtn.Text = "Search";
            officeSearchBtn.UseVisualStyleBackColor = true;
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
            Controls.Add(officeSearchBtn);
            Controls.Add(staffSearchBtn);
            Controls.Add(officeSearchTB);
            Controls.Add(staffSearchTB);
            Controls.Add(servicesSearchTB);
            Controls.Add(serviceDGV);
            Controls.Add(officeDGV);
            Controls.Add(officeRemoveBtn);
            Controls.Add(staffDGV);
            Controls.Add(officeUpdateBtn);
            Controls.Add(RemoveStaffBtn);
            Controls.Add(officeCreateBtn);
            Controls.Add(UpdateStaffBtn);
            Controls.Add(officeLbl);
            Controls.Add(CreateStaffBtn);
            Controls.Add(StaffLbl);
            Controls.Add(RemoveServiceBtn);
            Controls.Add(UpdateServiceBtn);
            Controls.Add(CreateServiceBtn);
            Controls.Add(ServicesLabel);
            Name = "Admin";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ZTH - Admin";
            ((ISupportInitialize)serviceDGV).EndInit();
            ((ISupportInitialize)staffDGV).EndInit();
            ((ISupportInitialize)officeDGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button servicesSearchBtn;
        private Button staffSearchBtn;
        private TextBox staffSearchTB;
        private TextBox servicesSearchTB;
        private DataGridView serviceDGV;
        private DataGridView staffDGV;
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
        private Label officeLbl;
        private Button officeCreateBtn;
        private Button officeUpdateBtn;
        private Button officeRemoveBtn;
        private DataGridView officeDGV;
        private TextBox officeSearchTB;
        private Button officeSearchBtn;
    }
}