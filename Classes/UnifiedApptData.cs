using log4net;
using System;
using System.Collections.Generic;
using System.Data;
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
        public byte InHomeService { get; set; }
        #endregion

        #region Constructors

        public UnifiedApptData()
        {

        }

        public UnifiedApptData(int appointment_Id, int customer_Id, int staff_id, int office_Id, int service_Id, DateTime start, DateTime end,
             byte inHomeService, int service_Address_Id)
        {
            Appointment_Id = appointment_Id;
            Customer_Id = customer_Id;
            Staff_Id = staff_id;
            Office_Id = office_Id;
            Service_Id = service_Id;
            Start = start;
            End = end;
            InHomeService = inHomeService;
            Service_Address_Id = service_Address_Id;
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
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        var fields = Field.Parse<UnifiedApptData>(e => new
                        {
                            e.Appointment_Id,
                            e.Customer_Id,
                            e.Staff_Id,
                            e.Office_Id,
                            e.Service_Id,
                            e.Start,
                            e.End,
                            e.InHomeService,
                            e.Service_Address_Id
                        });
                        UnifiedApptData appt = connection.Query<UnifiedApptData>(e => e.Appointment_Id == apptId, fields)
                            .FirstOrDefault();
                        connection.Close();
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
