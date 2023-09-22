using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoDb;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes
{
    public class OfficeAppointment : Appointment
    {
        #region Properties / Fields
        public int OfficeId { get; set; }
        public bool InHomeService { get; set; } // TODO: update SQL schema to support these

        #endregion

        #region Constructors

        public OfficeAppointment()
        {

        }

        public OfficeAppointment(int appointmentId, int customerId, int staffId, int officeId, int serviceId, DateTime start, DateTime end, bool inHomeService)
        {
            AppointmentId = appointmentId;
            CustomerId = customerId;
            StaffId = staffId;
            OfficeId = officeId;
            ServiceID = serviceId;
            Start = start;
            End = end;
            InHomeService = inHomeService;
        }

        #endregion
        #region SQL

        public bool InsertOfficeAppt(OfficeAppointment officeAppointment)
        {
            using (var connection = new Builder().Connection())
                try
                {
                    {
                        var id = connection.Insert("[zth].[appointment]", entity: officeAppointment);
                        MessageBox.Show("Appointment with Id: " + id + " created.", "Appointment Created");
                    }
                    
                    return true;
                }
                catch (Exception e)
                {
                    LogManager.GetLogger("LoggingRepo").Warn(e, e);
                    return false;
                }

        }

        public bool RemoveOfficeAppt(int officeApptId)
        {
            using (var connection = new Builder().Connection())
                try
                {
                    var removedAppt = connection.Delete("[zth].[appointment]", officeApptId);
                    MessageBox.Show(+ removedAppt + " removed.", "Appointment Removed");
                    return true;
                }
                catch (Exception e)
                {
                    LogManager.GetLogger("LoggingRepo").Warn(e, e);
                    return false;
                }
        }

        public bool UpdateOfficeAppt(OfficeAppointment officeAppointment)
        {
            using (var connection = new Builder().Connection())
                try
                {
                    {
                        var updatedAppt = connection.Update("[zth].[appointment]", entity: officeAppointment);
                        MessageBox.Show(+updatedAppt + " removed.", "Appointment Removed");
                    }
                    return true;
                }
                catch (Exception e)
                {
                    LogManager.GetLogger("LoggingRepo").Warn(e, e);
                    return false;
                }
        }

        #endregion
    }
}
