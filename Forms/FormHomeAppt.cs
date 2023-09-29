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
            var output = new HomeAppointment(appt.AppointmentId,appt.CustomerId,appt.StaffId,appt.ServiceID,appt.Start,appt.End,true,-1);
            if (appt.CustomerId != cxId)
            {
                if (cxId.HasValue)
                {
                    cxIdTB.Text = cxId.ToString();
                    cxIdTB.BackColor = Color.CadetBlue;
                }
                cxIdTB.Text = appt.AppointmentId.ToString();
                cxIdTB.BackColor = Color.PaleVioletRed; //Indicates mismatch
            }
            cxIdTB.Focus();
        }

        #region SQL
        public ServiceAddress? ReturnServiceAddress(string searchTerm)
        {
            using (MySqlConnection connection = new Builder().Connect())
            {
                try
                {
                    int i;
                    int.TryParse(searchTerm, out i);
                    var serviceAddress = connection.Query<ServiceAddress>("[zth].[address]",e => e.RelatedCx == i);
                    return (ServiceAddress?) serviceAddress;
                }
                catch (Exception e)
                {
                    LogManager.GetLogger("LoggingRepo").Warn(e, e);
                    return null;
                }
            }
        }


        #endregion
    }
}
