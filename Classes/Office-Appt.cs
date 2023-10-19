using log4net;
using RepoDb;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes;

public class OfficeAppointment : Appointment
{
    #region Properties / Fields

    public int Office_Id { get; set; }
    public bool InHomeService { get; set; } // TODO: update SQL schema to support these

    #endregion

    #region Constructors

    public OfficeAppointment()
    {
    }

    public OfficeAppointment(int appointmentId, int customerId, int staffId, int officeId, int serviceId,
        DateTime start, DateTime end, bool inHomeService)
    {
        Appointment_Id = appointmentId;
        Customer_Id = customerId;
        Staff_Id = staffId;
        Office_Id = officeId;
        Service_Id = serviceId;
        Start = start;
        End = end;
        InHomeService = inHomeService;
    }

    #endregion

    #region SQL

    public static bool InsertOfficeAppt(OfficeAppointment officeAppointment)
    {
        using (var connection = new Builder().Connect())
        {
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
    }

    public static bool RemoveOfficeAppt(int officeApptId)
    {
        using (var connection = new Builder().Connect())
        {
            try
            {
                var removedAppt = connection.Delete("appointment", officeApptId);
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

    public static bool UpdateOfficeAppt(OfficeAppointment officeAppointment)
    {
        using (var connection = new Builder().Connect())
        {
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
    }

    #endregion
}