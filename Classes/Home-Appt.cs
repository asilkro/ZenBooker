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
    public class HomeAppointment : Appointment
    {
        #region Properties / Fields
        public bool InHomeService { get; set; } // TODO: update SQL schema to support these
        public int ServiceAddressId { get; set; } // TODO: create table for Service Addresses

        #endregion

        #region Constructors

        public HomeAppointment()
        {

        }

        public HomeAppointment(int appointmentId, int customerId, int staffId, int serviceId, DateTime start, DateTime end, bool inHomeService, int serviceAddressId)
        {
            AppointmentId = appointmentId;
            CustomerId = customerId;
            StaffId = staffId;
            ServiceID = serviceId;
            Start = start;
            End = end;
            InHomeService = inHomeService;
            ServiceAddressId = serviceAddressId;
        }


        #endregion

        #region SQL

        public bool InsertHomeAppt(HomeAppointment homeAppointment)
        {
            using (var connection = new Builder().Connection())
                try
                {
                    {
                        var id = connection.Insert("[zth].[appointment]", entity: homeAppointment);
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

        public bool RemoveHomeAppt(int homeApptId)
        {
            using (var connection = new Builder().Connection())
                try
                {
                    var removedAppt = connection.Delete("[zth].[appointment]", homeApptId);
                    MessageBox.Show(+removedAppt + " removed.", "Appointment Removed");
                    return true;
                }
                catch (Exception e)
                {
                    LogManager.GetLogger("LoggingRepo").Warn(e, e);
                    return false;
                }
        }

        public bool UpdateHomeAppt(HomeAppointment homeAppointment)
        {
            using (var connection = new Builder().Connection())
                try
                {
                    {
                        var updatedAppt = connection.Update("[zth].[appointment]", entity: homeAppointment);
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
