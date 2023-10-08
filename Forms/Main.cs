using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZenoBook.Forms
{
    public partial class Main : Form
    {
        private Login login;
        public Main(Login login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
            {
                ActiveForm.Close();
            }

        }
    }
}
