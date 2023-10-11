using log4net;
using RepoDb;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes;

public class HomeAppointment : Appointment
{
    #region Properties / Fields

    public bool InHomeService { get; set; } // TODO: update SQL schema to support these
    public int ServiceAddressId { get; set; }

    #endregion

    #region Constructors

    public HomeAppointment()
    {
    }

    public HomeAppointment(int appointmentId, int customerId, int staffId, int serviceId, DateTime start, DateTime end,
        bool inHomeService, int serviceAddressId)
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

    public static bool InsertHomeAppt(HomeAppointment homeAppointment)
    {
        using (var connection = new Builder().Connect())
        {
            try
            {
                {
                    var id = connection.Insert("[zth].[appointment]", homeAppointment);
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

    public bool RemoveHomeAppt(int homeApptId)
    {
        using (var connection = new Builder().Connect())
        {
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
    }

    public bool UpdateHomeAppt(HomeAppointment homeAppointment)
    {
        using (var connection = new Builder().Connect())
        {
            try
            {
                {
                    var updatedAppt = connection.Update("[zth].[appointment]", homeAppointment);
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
    }

    #endregion
}