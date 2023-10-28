using log4net;
using RepoDb;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes;

public class HomeAppointment : Appointment
{
    #region Properties / Fields

    public sbyte inhomeservice { get; set; }
    public int service_address_id { get; set; }

    #endregion

    #region Constructors

    public HomeAppointment()
    {
    }

    public HomeAppointment(int appointmentId, int customerId, int staffId, int serviceId, DateTime start, DateTime end,
        sbyte inhomeservice, int service_Address_Id)
    {
        appointment_id = appointmentId;
        customer_id = customerId;
        staff_id = staffId;
        service_id = serviceId;
        this.start = start;
        this.end = end;
        this.inhomeservice = inhomeservice;
        service_address_id = service_Address_Id;
    }

    #endregion

    #region SQL

    public static bool InsertHomeAppt(HomeAppointment homeAppointment)
    {
        using var connection = new Builder().Connect();
        try
        {
            {
                var id = connection.Insert("appointment", homeAppointment);
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
    public static bool UpdateHomeAppt(HomeAppointment homeAppointment)
    {
        using var connection = new Builder().Connect();
        try
        {
            {
                var updatedAppt = connection.Update("appointment", homeAppointment);
                MessageBox.Show(+updatedAppt + " updated.", "Appointment Update");
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