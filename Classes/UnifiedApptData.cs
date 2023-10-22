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
        public int office_id { get; set; }
        public int service_address_id { get; set; }
        public byte inhomeservice { get; set; }
        #endregion

        #region Constructors

        public UnifiedApptData()
        {

        }

        public UnifiedApptData(int appointment_Id, int customer_Id, int staff_id, int office_Id, int service_Id, DateTime start, DateTime end,
             byte inhomeservice, int service_Address_Id)
        {
            base.appointment_id = appointment_Id;
            base.customer_id = customer_Id;
            base.staff_id = staff_id;
            this.office_id = office_Id;
            base.service_id = service_Id;
            base.start = start;
            base.end = end;
            this.inhomeservice = inhomeservice;
            this.service_address_id = service_Address_Id;
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
                            Appointment_Id = e.appointment_id,
                            Customer_Id = e.customer_id,
                            Staff_Id = e.staff_id,
                            Office_Id = e.office_id,
                            Service_Id = e.service_id,
                            Start = e.start,
                            End = e.end,
                            InHomeService = e.inhomeservice,
                            Service_Address_Id = e.service_address_id
                        });
                        UnifiedApptData appt = connection.Query<UnifiedApptData>(e => e.appointment_id == apptId, fields)
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
