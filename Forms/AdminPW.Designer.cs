namespace ZenoBook.Forms
{
    partial class AdminPW
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
            userTb = new TextBox();
            oldPwTB = new MaskedTextBox();
            currentPwLBL = new Label();
            userLBL = new Label();
            newPwLBL = new Label();
            newPwTB1 = new MaskedTextBox();
            confirmPwLBL = new Label();
            newPwTB2 = new MaskedTextBox();
            backBtn = new Button();
            saveBtn = new Button();
            SuspendLayout();
            // 
            // userTb
            // 
            userTb.Location = new Point(66, 34);
            userTb.Name = "userTb";
            userTb.PlaceholderText = "userName";
            userTb.Size = new Size(160, 23);
            userTb.TabIndex = 0;
            // 
            // oldPwTB
            // 
            oldPwTB.Location = new Point(66, 78);
            oldPwTB.Name = "oldPwTB";
            oldPwTB.PasswordChar = '*';
            oldPwTB.Size = new Size(159, 23);
            oldPwTB.TabIndex = 1;
            // 
            // currentPwLBL
            // 
            currentPwLBL.AutoSize = true;
            currentPwLBL.Enabled = false;
            currentPwLBL.Location = new Point(66, 60);
            currentPwLBL.Name = "currentPwLBL";
            currentPwLBL.Size = new Size(100, 15);
            currentPwLBL.TabIndex = 2;
            currentPwLBL.Text = "Current Password";
            // 
            // userLBL
            // 
            userLBL.AutoSize = true;
            userLBL.Enabled = false;
            userLBL.Location = new Point(66, 16);
            userLBL.Name = "userLBL";
            userLBL.Size = new Size(62, 15);
            userLBL.TabIndex = 3;
            userLBL.Text = "UserName";
            // 
            // newPwLBL
            // 
            newPwLBL.AutoSize = true;
            newPwLBL.Enabled = false;
            newPwLBL.Location = new Point(63, 129);
            newPwLBL.Name = "newPwLBL";
            newPwLBL.Size = new Size(84, 15);
            newPwLBL.TabIndex = 5;
            newPwLBL.Text = "New Password";
            // 
            // newPwTB1
            // 
            newPwTB1.Location = new Point(63, 147);
            newPwTB1.Name = "newPwTB1";
            newPwTB1.PasswordChar = '*';
            newPwTB1.Size = new Size(159, 23);
            newPwTB1.TabIndex = 4;
            // 
            // confirmPwLBL
            // 
            confirmPwLBL.AutoSize = true;
            confirmPwLBL.Enabled = false;
            confirmPwLBL.Location = new Point(63, 173);
            confirmPwLBL.Name = "confirmPwLBL";
            confirmPwLBL.Size = new Size(104, 15);
            confirmPwLBL.TabIndex = 7;
            confirmPwLBL.Text = "Confirm Password";
            // 
            // newPwTB2
            // 
            newPwTB2.Location = new Point(63, 191);
            newPwTB2.Name = "newPwTB2";
            newPwTB2.PasswordChar = '*';
            newPwTB2.Size = new Size(159, 23);
            newPwTB2.TabIndex = 6;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(28, 305);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(100, 44);
            backBtn.TabIndex = 32;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(157, 305);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(100, 44);
            saveBtn.TabIndex = 33;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // AdminPW
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = backBtn;
            ClientSize = new Size(284, 361);
            Controls.Add(saveBtn);
            Controls.Add(backBtn);
            Controls.Add(confirmPwLBL);
            Controls.Add(newPwTB2);
            Controls.Add(newPwLBL);
            Controls.Add(newPwTB1);
            Controls.Add(userLBL);
            Controls.Add(currentPwLBL);
            Controls.Add(oldPwTB);
            Controls.Add(userTb);
            Name = "AdminPW";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AdminPW";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox userTb;
        private MaskedTextBox oldPwTB;
        private Label currentPwLBL;
        private Label userLBL;
        private Label newPwLBL;
        private MaskedTextBox newPwTB1;
        private Label confirmPwLBL;
        private MaskedTextBox newPwTB2;
        private Button backBtn;
        private Button saveBtn;
    }
}