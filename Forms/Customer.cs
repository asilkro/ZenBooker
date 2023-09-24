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
using ZenoBook.Classes;

namespace ZenoBook.Forms
{
    public partial class FormCustomer : Form
    {
        public FormCustomer()
        {
            InitializeComponent();
            saveBtn.Enabled = false;
            saveBtn.Visible = false;
        }

        public FormCustomer(Customer customer)
        {
            InitializeComponent();
            tbFirstName.Text = customer.First;
            tbLastName.Text = customer.Last;
            tbPhone.Text = customer.Phone.ToString();
            tbEmail.Text = customer.Email;
            tbOffice.Text = customer.PreferredOffice.ToString();

            saveBtn.Enabled = false;
            saveBtn.Visible = false;
        }

        // TODO: BETTER VERSION OF THIS
        private void validateBtn_Click(object sender, EventArgs e)
        {
            var isThereAProblem = true;
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    if (!String.IsNullOrWhiteSpace(c.Text) &&
                     !String.IsNullOrEmpty(c.Text))
                    {
                        isThereAProblem = false;
                        break;
                    }
                }
            }

            if (!isThereAProblem)
            {
                validateBtn.Enabled = false;
                validateBtn.Visible = false;
                saveBtn.Enabled = true;
                saveBtn.Visible = true;
            }
        }


    }
}
