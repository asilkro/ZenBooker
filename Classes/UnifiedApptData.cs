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
        public UnifiedApptData(int appointment_Id, int customer_Id, int service_Id, DateTime start, DateTime end,
            int office_Id, int service_Address_Id, bool inHomeService)
        {
            Appointment_Id = appointment_Id;
            Customer_Id = customer_Id;
            Service_Id = service_Id;
            Start = start;
            End = end;
            Office_Id = office_Id;
            Service_Address_Id = service_Address_Id;
            InHomeService = inHomeService;
        }
        #endregion

        #region SQL

        public static UnifiedApptData GetAppointment(int apptId)
        {
            using (var connection = new Builder().Connect())
            {
                try
                {
                    {
                        var id = connection.Insert("appointment", homeAppointment);
                        MessageBox.Show("Appointment with Id: " + id + " created.", "Appointment Created");
                    }

                }
                catch (Exception e)
                {
                    LogManager.GetLogger("LoggingRepo").Warn(e, e);
                }
            }
        }

        #endregion

    }


}
