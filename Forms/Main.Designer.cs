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
            components = new System.ComponentModel.Container();
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
            dataGridView1 = new DataGridView();
            homeAppointmentBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)homeAppointmentBindingSource).BeginInit();
            SuspendLayout();
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(768, 587);
            logoutBtn.Margin = new Padding(3, 4, 3, 4);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(114, 59);
            logoutBtn.TabIndex = 1;
            logoutBtn.Text = "Log Out";
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // CxLabel
            // 
            CxLabel.AutoSize = true;
            CxLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CxLabel.Location = new Point(37, 434);
            CxLabel.Name = "CxLabel";
            CxLabel.Size = new Size(104, 28);
            CxLabel.TabIndex = 2;
            CxLabel.Text = "Customers";
            // 
            // CxCreateBtn
            // 
            CxCreateBtn.Location = new Point(37, 484);
            CxCreateBtn.Name = "CxCreateBtn";
            CxCreateBtn.Size = new Size(94, 29);
            CxCreateBtn.TabIndex = 3;
            CxCreateBtn.Text = "Create";
            CxCreateBtn.UseVisualStyleBackColor = true;
            // 
            // UpdateCxBtn
            // 
            UpdateCxBtn.Location = new Point(37, 531);
            UpdateCxBtn.Name = "UpdateCxBtn";
            UpdateCxBtn.Size = new Size(94, 29);
            UpdateCxBtn.TabIndex = 4;
            UpdateCxBtn.Text = "Update";
            UpdateCxBtn.UseVisualStyleBackColor = true;
            // 
            // RemoveCxBtn
            // 
            RemoveCxBtn.Location = new Point(37, 578);
            RemoveCxBtn.Name = "RemoveCxBtn";
            RemoveCxBtn.Size = new Size(94, 29);
            RemoveCxBtn.TabIndex = 5;
            RemoveCxBtn.Text = "Remove";
            RemoveCxBtn.UseVisualStyleBackColor = true;
            // 
            // RemoveApptBtn
            // 
            RemoveApptBtn.Location = new Point(137, 315);
            RemoveApptBtn.Name = "RemoveApptBtn";
            RemoveApptBtn.Size = new Size(94, 29);
            RemoveApptBtn.TabIndex = 9;
            RemoveApptBtn.Text = "Remove";
            RemoveApptBtn.UseVisualStyleBackColor = true;
            RemoveApptBtn.Click += RemoveApptBtn_Click;
            // 
            // UpdateApptBtn
            // 
            UpdateApptBtn.Location = new Point(37, 315);
            UpdateApptBtn.Name = "UpdateApptBtn";
            UpdateApptBtn.Size = new Size(94, 29);
            UpdateApptBtn.TabIndex = 8;
            UpdateApptBtn.Text = "Update";
            UpdateApptBtn.UseVisualStyleBackColor = true;
            UpdateApptBtn.Click += UpdateApptBtn_Click;
            // 
            // CreateApptBtn
            // 
            CreateApptBtn.Location = new Point(37, 280);
            CreateApptBtn.Name = "CreateApptBtn";
            CreateApptBtn.Size = new Size(94, 29);
            CreateApptBtn.TabIndex = 7;
            CreateApptBtn.Text = "Create";
            CreateApptBtn.UseVisualStyleBackColor = true;
            CreateApptBtn.Click += CreateApptBtn_Click;
            // 
            // ApptsLbl
            // 
            ApptsLbl.AutoSize = true;
            ApptsLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ApptsLbl.Location = new Point(37, 239);
            ApptsLbl.Name = "ApptsLbl";
            ApptsLbl.Size = new Size(137, 28);
            ApptsLbl.TabIndex = 6;
            ApptsLbl.Text = "Appointments";
            // 
            // pictureBox1
            // 
            pictureBox1.Enabled = false;
            pictureBox1.Image = Properties.Resources.Zenobia_Black;
            pictureBox1.Location = new Point(346, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 250);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(40, 29);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(300, 188);
            dataGridView1.TabIndex = 11;
            // 
            // homeAppointmentBindingSource
            // 
            homeAppointmentBindingSource.DataSource = typeof(Classes.HomeAppointment);
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 660);
            Controls.Add(dataGridView1);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "Main";
            Text = "ZTH - ZenoBook";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)homeAppointmentBindingSource).EndInit();
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
        private DataGridView dataGridView1;
        private BindingSource homeAppointmentBindingSource;
    }
}