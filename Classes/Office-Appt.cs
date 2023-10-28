using log4net;
using RepoDb;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes;

public class OfficeAppointment : Appointment
{
    #region Properties / Fields

    public int office_id { get; set; }
    public sbyte inhomeservice { get; set; }

    #endregion

    #region Constructors

    public OfficeAppointment()
    {
    }

    public OfficeAppointment(int appointmentId, int customerId, int staffId, int officeId, int serviceId,
        DateTime start, DateTime end, sbyte inhomeservice)
    {
        appointment_id = appointmentId;
        customer_id = customerId;
        staff_id = staffId;
        office_id = officeId;
        service_id = serviceId;
        this.start = start;
        this.end = end;
        this.inhomeservice = inhomeservice;
    }

    #endregion

    #region SQL

    public static bool InsertOfficeAppt(OfficeAppointment officeAppointment)
    {
        using var connection = new Builder().Connect();
        try
        {
            {
                var id = connection.Insert("appointment", officeAppointment);
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

    public static bool UpdateOfficeAppt(OfficeAppointment officeAppointment)
    {
        using var connection = new Builder().Connect();
        try
        {
            {
                var updatedAppt = connection.Update("appointment", officeAppointment);
                MessageBox.Show(updatedAppt + " updated.", "Appointment Updated");
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