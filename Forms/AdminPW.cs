using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms
{
    public partial class AdminPW : Form
    {
        public AdminPW()
        {
            InitializeComponent();
        }


        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!Helpers.DoTheyMatch(newPwTB1.Text, newPwTB2.Text)) return;
            if (!Helpers.ValidateLogin(userTb.Text, oldPwTB.Text)) return;
            var result = Helpers.PasswordUpdated(userTb.Text, Helpers.HashedString(newPwTB1.Text));
            if (!result) return;
            MessageBox.Show("Password updated.");
            Close();

        }
    }
}
