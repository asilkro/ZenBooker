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
    public class UnifiedApptData : Appointment
    {
        #region Properties
        public int Office_Id { get; set; }
        public int Service_Address_Id { get; set; }
        public bool InHomeService { get; set; }
        #endregion

        #region Constructors

        public UnifiedApptData()
        {

        }

        public UnifiedApptData(int appointment_Id, int customer_Id, int staff_id, int service_Id, DateTime start, DateTime end,
            int office_Id, int service_Address_Id, bool inHomeService)
        {
            Appointment_Id = appointment_Id;
            Customer_Id = customer_Id;
            Staff_Id = staff_id;
            Service_Id = service_Id;
            Start = start;
            End = end;
            Office_Id = office_Id;
            Service_Address_Id = service_Address_Id;
            InHomeService = inHomeService;
        }
        #endregion

        #region SQL

        public static UnifiedApptData? GetAppointment(int apptId)
        {
            using (var connection = new Builder().Connect())
            {
                try
                {
                    {
                        var appt = connection.Query<UnifiedApptData>(e => e.Appointment_Id == apptId).GetEnumerator().Current;
                        return appt;
                    }

                }
                catch (Exception e)
                {
                    LogManager.GetLogger("LoggingRepo").Warn(e, e);
                    return null;
                }
            }
        }

        public static bool RemoveAppointment(int apptId)
        {
            using (var connection = new Builder().Connect())
            {
                try
                {
                    { 
                        connection.Delete("appointment", apptId);
                        MessageBox.Show("Appt id " + apptId + " removed.", "Appointment Removed");
                        return true;
                    }

                }
                catch (Exception e)
                {
                    LogManager.GetLogger("LoggingRepo").Warn(e, e);
                    return false;
                }
            }
        }

        #endregion

    }


}
