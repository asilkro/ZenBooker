using log4net;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RepoDb;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;
using ZenoBook.Forms;
using static System.Windows.Forms.AxHost;

namespace ZenoBook.Forms
{
    public partial class FormOfficeAppt : Form
    {
        //   public FormOfficeAppt()
        //   {
        //       InitializeComponent();
        //   }

        private OfficeAppointment officeAppt;
        private FormAppointment form1;

        public FormOfficeAppt(Appointment appt, FormAppointment form1)
        {
            InitializeComponent();
            form1 = (FormAppointment)this.ParentForm;
            var cx = ReturnCustomer(appt.CustomerId.ToString());
            ReturnOfficeAddress(cx.PreferredOffice.ToString());
            officeAppt = new OfficeAppointment(appt.AppointmentId, appt.CustomerId, appt.StaffId,-1, appt.ServiceID, appt.Start,
                appt.End, false);
            saveBtn.Enabled = false;
        }

        #region Event Handlers

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void validateBtn_Click(object sender, EventArgs e)
        {
            officeAppt.OfficeId = int.Parse(officeIdTB.Text);
            officeAppt.InHomeService = false;
            
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (OfficeAppointment.InsertOfficeAppt(officeAppt))
            {
                this.Close();
                form1.Close();
            }

        }

        #endregion


        #region SQL

        public void ReturnOfficeAddress(string searchTerm)
        {
            using (MySqlConnection connection = new Builder().Connect())
            {
                try
                {
                    int i;
                    int.TryParse(searchTerm, out i);
                    var officeAddress = connection.Query<Office>("[zth].[office]", e => e.OfficeId == i);
                    FillOfficeFromSearch(officeAddress.GetEnumerator().Current);
                }
                catch (Exception e)
                {
                    LogManager.GetLogger("LoggingRepo").Warn(e, e);

                }
            }
        }

        private Customer? ReturnCustomer(string searchTerm)
        {
            using (MySqlConnection connection = new Builder().Connect())
            {
                char space = ' ';
                char atSign = '@';

                if (searchTerm.Contains(space))
                {
                    string[] searchTerms = searchTerm.Split(' ', 2);
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
                    var iCustomer = connection.Query<Customer>("[zth].[customer]", e => e.Customer_Id == i).FirstOrDefault();
                    return iCustomer;
                }
                return null;
            }
        }

        #endregion

        #region Other Methods

        private void FillOfficeFromSearch(Office? address)
        {
            officeNameTB.Text = address.OfficeName;
            officeCityTB.Text = address.City;
            officeCountryTB.Text = address.Country;
            officeStateTB.Text = address.State;
            officeIdTB.Text = address.OfficeId.ToString();
        }

        #endregion
    }
}
