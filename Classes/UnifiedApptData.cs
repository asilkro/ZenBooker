using log4net;
using System.Data;
using RepoDb;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes;

public class UnifiedApptData : Appointment
{
    #region Properties

    public int office_id { get; set; }
    public int service_address_id { get; set; }
    public sbyte inhomeservice { get; set; }

    #endregion

    #region Constructors

    public UnifiedApptData()
    {
    }

    public UnifiedApptData(int appointment_Id, int customer_Id, int staff_id, int office_Id, int service_Id,
        DateTime start, DateTime end,
        sbyte inhomeservice, int service_Address_Id)
    {
        appointment_id = appointment_Id;
        customer_id = customer_Id;
        this.staff_id = staff_id;
        office_id = office_Id;
        service_id = service_Id;
        this.start = start;
        this.end = end;
        this.inhomeservice = inhomeservice;
        service_address_id = service_Address_Id;
    }

    #endregion

    #region SQL

    public static UnifiedApptData? GetAppointment(int apptId)
    {
        using var connection = new Builder().Connect();
        try
        {
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var fields = Field.Parse<UnifiedApptData>(e => new
                {
                    e.appointment_id,
                    e.customer_id,
                    e.staff_id,
                    e.office_id,
                    e.service_id,
                    e.start,
                    e.end,
                    e.inhomeservice,
                    e.service_address_id
                });
                var appt = connection
                    .ExecuteQuery<UnifiedApptData>(
                        "SELECT * FROM appointment WHERE (appointment_id = @appointment_id);",
                        new {appointment_id = apptId}).FirstOrDefault();
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

    public static bool RemoveAppointment(int apptId)
    {
        using var connection = new Builder().Connect();
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

    #endregion
}