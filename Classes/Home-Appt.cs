using log4net;
using RepoDb;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes;

public class HomeAppointment : Appointment
{
    #region Properties / Fields

    public bool InHomeService { get; set; }
    public int Service_Address_Id { get; set; }

    #endregion

    #region Constructors

    public HomeAppointment()
    {
    }

    public HomeAppointment(int appointmentId, int customerId, int staffId, int serviceId, DateTime start, DateTime end,
        bool inHomeService, int serviceAddressId)
    {
        Appointment_Id = appointmentId;
        Customer_Id = customerId;
        Staff_Id = staffId;
        Service_Id = serviceId;
        Start = start;
        End = end;
        InHomeService = inHomeService;
        Service_Address_Id = serviceAddressId;
    }

    #endregion

    #region SQL

    public static bool InsertHomeAppt(HomeAppointment homeAppointment)
    {
        using (var connection = new Builder().Connect())
        {
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
    }

    public static bool RemoveHomeAppt(int homeApptId)
    {
        using (var connection = new Builder().Connect())
        {
            try
            {
                var removedAppt = connection.Delete("appointment", homeApptId);
                MessageBox.Show(+removedAppt + " removed.", "Appointment Removed");
                return true;
            }
            catch (Exception e)
            {
                LogManager.GetLogger("LoggingRepo").Warn(e, e);
                return false;
            }
        }
    }

    public static bool UpdateHomeAppt(HomeAppointment homeAppointment)
    {
        using (var connection = new Builder().Connect())
        {
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
    }

    #endregion
}