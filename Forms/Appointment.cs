using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using RepoDb;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms
{
    public partial class formAppointment : Form
    {
        public formAppointment()
        {
            InitializeComponent();
        }

        public formAppointment(Appointment appointment)
        {
            //TODO: POPULATE FORM WITH DATA FROM QUERIES
            cxIdTB.Text = appointment.CustomerId.ToString();
            cxSearchTB.Text = appointment.CustomerId.ToString();

            staffIdTB.Text = appointment.StaffId.ToString();
            staffSearchTB.Text = appointment.StaffId.ToString();

            serviceIdTB.Text = appointment.ServiceID.ToString();
            serviceSearchTB.Text = appointment.ServiceID.ToString();


        }

        public void updateTbs(Appointment appt)
        {

        }

        #region SQL
        //TODO: MAKE ROBUST
//      public object returnCxFromSQL(TextBox textBox, string tableName)
//      {
//          string columnBeingChecked = null;
//          char atSign = '@';
//          using (MySqlConnection connection = new Builder().Connect())
//          {
//              var thing = textBox.Text;
//              switch (thing)
//              {
//                  case var intThing when int.TryParse(thing, out var number):
//                      columnBeingChecked = tableName +"_id";
//                      break;
//
//                  case var probablyEmail when thing.Contains(atSign):
//                      columnBeingChecked = "email";
//                      break;
//
//                  Default:
//                      columnBeingChecked = "";
//                      break;
//              }
//              connection.
//              var otherCmd = connection.CreateCommand(
//                  "SELECT CONCAT(first, ' ', last) AS Name, customer_id, email, phone, preferred_office from customer where CONCAT(first, ' ', last) like '%\"+@SEARCHVALUE+\"%'");
//              ;
//              MySqlCommand? nameCmd = connection.CreateCommand("SELECT CONCAT(first, ' ', last) AS Name, customer_id, email, phone, preferred_office from customer where CONCAT(first, ' ', last) like \"@SEARCHCONTENTS\";") as MySqlCommand;
//
//          }
//      }

        public object returnCustomer(string searchTerm)
        {
            using (MySqlConnection connection = new Builder().Connect())
            {
                var customer = connection.Query<Customer>("[zth].[customer]",)
            }

        }

        #endregion


        #region Event Handlers
        private void cxSearchButton_Click(object sender, EventArgs e)
        {

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
