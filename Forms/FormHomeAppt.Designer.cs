namespace ZenoBook.Forms
{
    partial class FormHomeAppt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHomeAppt));
            validateBtn = new Button();
            cancelBtn = new Button();
            saveBtn = new Button();
            cxIdTB = new TextBox();
            SuspendLayout();
            // 
            // validateBtn
            // 
            validateBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            validateBtn.Location = new Point(186, 357);
            validateBtn.Name = "validateBtn";
            validateBtn.Size = new Size(76, 27);
            validateBtn.TabIndex = 0;
            validateBtn.Text = "Validate";
            validateBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            cancelBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cancelBtn.Location = new Point(26, 357);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(76, 27);
            cancelBtn.TabIndex = 1;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            saveBtn.Enabled = false;
            saveBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            saveBtn.Location = new Point(326, 357);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(76, 27);
            saveBtn.TabIndex = 2;
            saveBtn.Text = "Submit";
            saveBtn.UseVisualStyleBackColor = true;
            // 
            // cxIdTB
            // 
            cxIdTB.Location = new Point(26, 22);
            cxIdTB.Name = "cxIdTB";
            cxIdTB.PlaceholderText = "Customer Id";
            cxIdTB.Size = new Size(100, 25);
            cxIdTB.TabIndex = 18;
            // 
            // FormHomeAppt
            // 
            AcceptButton = saveBtn;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBtn;
            ClientSize = new Size(434, 411);
            Controls.Add(cxIdTB);
            Controls.Add(saveBtn);
            Controls.Add(cancelBtn);
            Controls.Add(validateBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormHomeAppt";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ZTH - Home Appointment Details";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button validateBtn;
        private Button cancelBtn;
        private Button saveBtn;
        private Button AddressSearchButton;
        private TextBox addressSearchTB;
        private TextBox cxIdTB;
    }
}