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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Admin));
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
            OfficesLbl = new Label();
            officeCreateBtn = new Button();
            officeUpdateBtn = new Button();
            officeRemoveBtn = new Button();
            officeDGV = new DataGridView();
            officeSearchTB = new TextBox();
            officeSearchBtn = new Button();
            addressDGV = new DataGridView();
            removeAddressBtn = new Button();
            updateAddressBtn = new Button();
            createAddressBtn = new Button();
            searchAddressBtn = new Button();
            addressSearchTB = new TextBox();
            AddressesLbl = new Label();
            ((ISupportInitialize)serviceDGV).BeginInit();
            ((ISupportInitialize)staffDGV).BeginInit();
            ((ISupportInitialize)officeDGV).BeginInit();
            ((ISupportInitialize)addressDGV).BeginInit();
            SuspendLayout();
            // 
            // servicesSearchBtn
            // 
            servicesSearchBtn.Location = new Point(286, 265);
            servicesSearchBtn.Margin = new Padding(0);
            servicesSearchBtn.Name = "servicesSearchBtn";
            servicesSearchBtn.Size = new Size(81, 22);
            servicesSearchBtn.TabIndex = 30;
            servicesSearchBtn.Text = "Search";
            servicesSearchBtn.UseVisualStyleBackColor = true;
            servicesSearchBtn.Click += ServicesSearchBtn_Click;
            // 
            // staffSearchBtn
            // 
            staffSearchBtn.Location = new Point(288, 39);
            staffSearchBtn.Margin = new Padding(0);
            staffSearchBtn.Name = "staffSearchBtn";
            staffSearchBtn.Size = new Size(81, 22);
            staffSearchBtn.TabIndex = 29;
            staffSearchBtn.Text = "Search";
            staffSearchBtn.UseVisualStyleBackColor = true;
            staffSearchBtn.Click += StaffSearchBtn_Click;
            // 
            // staffSearchTB
            // 
            staffSearchTB.Location = new Point(16, 39);
            staffSearchTB.Margin = new Padding(2, 1, 2, 1);
            staffSearchTB.Name = "staffSearchTB";
            staffSearchTB.PlaceholderText = "Enter staff name or email";
            staffSearchTB.Size = new Size(264, 23);
            staffSearchTB.TabIndex = 1;
            // 
            // servicesSearchTB
            // 
            servicesSearchTB.Location = new Point(15, 264);
            servicesSearchTB.Margin = new Padding(2, 1, 2, 1);
            servicesSearchTB.Name = "servicesSearchTB";
            servicesSearchTB.PlaceholderText = "Search for services";
            servicesSearchTB.Size = new Size(264, 23);
            servicesSearchTB.TabIndex = 3;
            // 
            // serviceDGV
            // 
            serviceDGV.AllowUserToAddRows = false;
            serviceDGV.AllowUserToDeleteRows = false;
            serviceDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            serviceDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            serviceDGV.Location = new Point(15, 291);
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
            staffDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            staffDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            staffDGV.Location = new Point(16, 65);
            staffDGV.Margin = new Padding(3, 2, 3, 2);
            staffDGV.Name = "staffDGV";
            staffDGV.ReadOnly = true;
            staffDGV.RowHeadersVisible = false;
            staffDGV.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            staffDGV.RowTemplate.Height = 29;
            staffDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            staffDGV.ShowEditingIcon = false;
            staffDGV.Size = new Size(352, 141);
            staffDGV.TabIndex = 25;
            // 
            // RemoveStaffBtn
            // 
            RemoveStaffBtn.Location = new Point(287, 210);
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
            UpdateStaffBtn.Location = new Point(199, 210);
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
            CreateStaffBtn.Location = new Point(111, 210);
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
            StaffLbl.Location = new Point(16, 9);
            StaffLbl.Name = "StaffLbl";
            StaffLbl.Size = new Size(41, 21);
            StaffLbl.TabIndex = 21;
            StaffLbl.Text = "Staff";
            // 
            // RemoveServiceBtn
            // 
            RemoveServiceBtn.Location = new Point(286, 439);
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
            UpdateServiceBtn.Location = new Point(198, 439);
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
            CreateServiceBtn.Location = new Point(110, 439);
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
            ServicesLabel.Location = new Point(15, 232);
            ServicesLabel.Name = "ServicesLabel";
            ServicesLabel.Size = new Size(67, 21);
            ServicesLabel.TabIndex = 17;
            ServicesLabel.Text = "Services";
            // 
            // backBtn
            // 
            backBtn.Location = new Point(583, 477);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(170, 72);
            backBtn.TabIndex = 31;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += BackBtn_Click;
            // 
            // changePWbtn
            // 
            changePWbtn.BackColor = Color.LightSteelBlue;
            changePWbtn.Location = new Point(401, 477);
            changePWbtn.Name = "changePWbtn";
            changePWbtn.Size = new Size(142, 72);
            changePWbtn.TabIndex = 32;
            changePWbtn.Text = "Change Password";
            changePWbtn.UseVisualStyleBackColor = false;
            changePWbtn.Click += ChangePasswordBtn_Click;
            // 
            // OfficesLbl
            // 
            OfficesLbl.AutoSize = true;
            OfficesLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            OfficesLbl.Location = new Point(400, 9);
            OfficesLbl.Name = "OfficesLbl";
            OfficesLbl.Size = new Size(58, 21);
            OfficesLbl.TabIndex = 21;
            OfficesLbl.Text = "Offices";
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
            officeCreateBtn.Click += OfficeCreateBtn_Click;
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
            officeUpdateBtn.Click += OfficeUpdateBtn_Click;
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
            officeRemoveBtn.Click += OfficeRemoveBtn_Click;
            // 
            // officeDGV
            // 
            officeDGV.AllowUserToAddRows = false;
            officeDGV.AllowUserToDeleteRows = false;
            officeDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            officeSearchTB.TabIndex = 2;
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
            officeSearchBtn.Click += OfficeSearchBtn_Click;
            // 
            // addressDGV
            // 
            addressDGV.AllowUserToAddRows = false;
            addressDGV.AllowUserToDeleteRows = false;
            addressDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            addressDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            addressDGV.Location = new Point(400, 291);
            addressDGV.Margin = new Padding(3, 2, 3, 2);
            addressDGV.Name = "addressDGV";
            addressDGV.ReadOnly = true;
            addressDGV.RowHeadersVisible = false;
            addressDGV.RowHeadersWidth = 51;
            addressDGV.RowTemplate.Height = 29;
            addressDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            addressDGV.ShowEditingIcon = false;
            addressDGV.Size = new Size(352, 141);
            addressDGV.TabIndex = 33;
            // 
            // removeAddressBtn
            // 
            removeAddressBtn.Location = new Point(671, 436);
            removeAddressBtn.Margin = new Padding(3, 2, 3, 2);
            removeAddressBtn.Name = "removeAddressBtn";
            removeAddressBtn.Size = new Size(82, 22);
            removeAddressBtn.TabIndex = 36;
            removeAddressBtn.Text = "Remove";
            removeAddressBtn.UseVisualStyleBackColor = true;
            removeAddressBtn.Click += RemoveAddressBtn_Click;
            // 
            // updateAddressBtn
            // 
            updateAddressBtn.Location = new Point(583, 436);
            updateAddressBtn.Margin = new Padding(3, 2, 3, 2);
            updateAddressBtn.Name = "updateAddressBtn";
            updateAddressBtn.Size = new Size(82, 22);
            updateAddressBtn.TabIndex = 35;
            updateAddressBtn.Text = "Update";
            updateAddressBtn.UseVisualStyleBackColor = true;
            updateAddressBtn.Click += UpdateAddressBtn_Click;
            // 
            // createAddressBtn
            // 
            createAddressBtn.Location = new Point(495, 436);
            createAddressBtn.Margin = new Padding(3, 2, 3, 2);
            createAddressBtn.Name = "createAddressBtn";
            createAddressBtn.Size = new Size(82, 22);
            createAddressBtn.TabIndex = 34;
            createAddressBtn.Text = "Create";
            createAddressBtn.UseVisualStyleBackColor = true;
            createAddressBtn.Click += CreateAddressBtn_Click;
            // 
            // searchAddressBtn
            // 
            searchAddressBtn.Location = new Point(672, 265);
            searchAddressBtn.Margin = new Padding(0);
            searchAddressBtn.Name = "searchAddressBtn";
            searchAddressBtn.Size = new Size(81, 22);
            searchAddressBtn.TabIndex = 39;
            searchAddressBtn.Text = "Search";
            searchAddressBtn.UseVisualStyleBackColor = true;
            searchAddressBtn.Click += SearchAddressBtn_Click;
            // 
            // addressSearchTB
            // 
            addressSearchTB.Location = new Point(401, 264);
            addressSearchTB.Margin = new Padding(2, 1, 2, 1);
            addressSearchTB.Name = "addressSearchTB";
            addressSearchTB.PlaceholderText = "Search for addresses";
            addressSearchTB.Size = new Size(264, 23);
            addressSearchTB.TabIndex = 4;
            // 
            // AddressesLbl
            // 
            AddressesLbl.AutoSize = true;
            AddressesLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddressesLbl.Location = new Point(401, 232);
            AddressesLbl.Name = "AddressesLbl";
            AddressesLbl.Size = new Size(81, 21);
            AddressesLbl.TabIndex = 37;
            AddressesLbl.Text = "Addresses";
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = backBtn;
            ClientSize = new Size(784, 561);
            Controls.Add(searchAddressBtn);
            Controls.Add(addressSearchTB);
            Controls.Add(AddressesLbl);
            Controls.Add(removeAddressBtn);
            Controls.Add(updateAddressBtn);
            Controls.Add(createAddressBtn);
            Controls.Add(addressDGV);
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
            Controls.Add(OfficesLbl);
            Controls.Add(CreateStaffBtn);
            Controls.Add(StaffLbl);
            Controls.Add(RemoveServiceBtn);
            Controls.Add(UpdateServiceBtn);
            Controls.Add(CreateServiceBtn);
            Controls.Add(ServicesLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Admin";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "ZTH - Admin";
            ((ISupportInitialize)serviceDGV).EndInit();
            ((ISupportInitialize)staffDGV).EndInit();
            ((ISupportInitialize)officeDGV).EndInit();
            ((ISupportInitialize)addressDGV).EndInit();
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
        private Label OfficesLbl;
        private Button officeCreateBtn;
        private Button officeUpdateBtn;
        private Button officeRemoveBtn;
        private DataGridView officeDGV;
        private TextBox officeSearchTB;
        private Button officeSearchBtn;
        private DataGridView addressDGV;
        private Button removeAddressBtn;
        private Button updateAddressBtn;
        private Button createAddressBtn;
        private Button searchAddressBtn;
        private TextBox addressSearchTB;
        private Label AddressesLbl;
    }
}