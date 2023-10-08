using log4net;
using MySqlConnector;
using RepoDb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms
{
    public partial class FormHomeAppt : Form
    {
        private HomeAppointment homeAppt;
        private FormAppointment form1;

     //   public FormHomeAppt()
     //   {
     //       InitializeComponent();
     //   }


        public FormHomeAppt(Appointment appt, int? cxId, FormAppointment form1)
        {
            InitializeComponent();
            form1 = (FormAppointment) this.ParentForm;
            homeAppt = new HomeAppointment(appt.AppointmentId, appt.CustomerId, appt.StaffId, appt.ServiceID,
                appt.Start, appt.End, true, -1);
            if (appt.CustomerId != cxId)
            {
                if (cxId.HasValue)
                {
                    cxIdTB.Text = cxId.ToString();
                    cxIdTB.BackColor = Color.CadetBlue;
                }
                cxIdTB.Text = appt.CustomerId.ToString();
                cxIdTB.BackColor = Color.PaleVioletRed; //Indicates mismatch
            }
            ReturnServiceAddress(cxIdTB.Text);
            saveBtn.Enabled = false;
        }

        #region SQL
        public void ReturnServiceAddress(string searchTerm)
        {
            using (MySqlConnection connection = new Builder().Connect())
            {
                try
                {
                    int i;
                    int.TryParse(searchTerm, out i);
                    var serviceAddress = connection.Query<ServiceAddress>("[zth].[address]", e => e.RelatedCx == i);
                    FillCxFromSearch(serviceAddress.GetEnumerator().Current);
                }
                catch (Exception e)
                {
                    LogManager.GetLogger("LoggingRepo").Warn(e, e);

                }
            }
        }

        public int? ReturnServiceAddyId(string searchTerm)
        {
            using (MySqlConnection connection = new Builder().Connect())
            {
                int sd;
                try
                {
                    var serviceAddress = connection.Query<ServiceAddress>("[zth].[address]", e => e.AddressId == int.Parse(searchTerm));
                    sd =  serviceAddress.GetEnumerator().Current.AddressId;
                    return sd;
                }
                catch (Exception e)
                {
                    LogManager.GetLogger("LoggingRepo").Warn(e, e);

                }
                return null;
            }
        }

        #endregion

        #region Additional Methods

        private void FillCxFromSearch(ServiceAddress? address)
        {
            address1TB.Text = address.Address1;
            address2TB.Text = address.Address2;
            cityTB.Text = address.City;
            stateTB.Text = address.State;
            countryTB.Text = address.Country;
        }

        #endregion

        #region Event Handlers

        private void SearchButton_Click(object sender, EventArgs e)
        {
            ReturnServiceAddress(saSearchTB.Text);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void validateBtn_Click(object sender, EventArgs e)
        {
            homeAppt.ServiceAddressId = (int)ReturnServiceAddyId(homeAppt.CustomerId.ToString());
            saveBtn.Enabled = true;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (HomeAppointment.InsertHomeAppt(homeAppt))
            {
                this.Close();
                form1.Close();
            }
        }

        #endregion


    }
}
