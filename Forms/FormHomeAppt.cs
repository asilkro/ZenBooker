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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms
{
    public partial class FormHomeAppt : Form
    {

        public FormHomeAppt()
        {
            InitializeComponent();
        }

        public FormHomeAppt(Appointment appt, int? cxId)
        {
            InitializeComponent();
            var output = new HomeAppointment(appt.AppointmentId, appt.CustomerId, appt.StaffId, appt.ServiceID, appt.Start, appt.End, true, -1);
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
            //TODO: IMPLEMENT
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //TODO
        }

        #endregion


    }
}
