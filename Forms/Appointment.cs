using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using RepoDb;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms
{
    public partial class FormAppointment : Form
    {
        public FormAppointment()
        {
            InitializeComponent();
        }

        public FormAppointment(Appointment appointment)
        {
            //TODO: POPULATE FORM WITH DATA FROM QUERIES
            cxIdTB.Text = appointment.CustomerId.ToString();
            cxSearchTB.Text = appointment.CustomerId.ToString();

            staffIdTB.Text = appointment.StaffId.ToString();
            staffSearchTB.Text = appointment.StaffId.ToString();

            serviceIdTB.Text = appointment.ServiceID.ToString();
            serviceSearchTB.Text = appointment.ServiceID.ToString();


        }

        public void UpdateTbs(Appointment appt)
        {

        }

        #region SQL

        public Customer? ReturnCustomer(string searchTerm)
        {
            using (MySqlConnection connection = new Builder().Connect())
            {
                char space = ' ';
                char atSign = '@';

                if (searchTerm.Contains(space))
                {
                    string[] searchTerms = searchTerm.Split(' ',2);
                    var first = searchTerms[0];
                    var last = searchTerms[1];
                    var sCustomer = connection.Query<Customer>("[zth].[customer]", e => e.First == first && e.Last == last).FirstOrDefault();
                    return sCustomer;
                }

                if (searchTerm.Contains(atSign))
                {
                    var aCustomer = connection.Query<Customer>("[zth].[customer]", e => e.Email == searchTerm).FirstOrDefault();
                    return aCustomer;
                }

                if (int.TryParse(searchTerm, out var i))
                {
                    var iCustomer = connection.Query<Customer>("[zth].[customer]",searchTerm).FirstOrDefault();
                    return iCustomer;
                }
                return null;
            }
        }

        #endregion


        #region Event Handlers
        private void cxSearchButton_Click(object sender, EventArgs e)
        {
            var cx = ReturnCustomer(cxSearchTB.Text);
            if (cx == null)
            {
                
            }
        }

        private void staffSearchButton_Click(object sender, EventArgs e)
        {

        }

        private void serviceSearchButton_Click(object sender, EventArgs e)
        {

        }
        private void officeSearchButton_Click(object sender, EventArgs e)
        {

        }


        #endregion


    }
}
