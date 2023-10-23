using log4net;
using RepoDb;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes;

public class Service
{
    #region Properties / Fields

    public int Service_Id { get; set; } // PK, auto_increment, not_null, FK service_id on Appt
    public string Service_Name { get; set; } // VARCHAR(32)
    public string Service_Description { get; set; } // VARCHAR (64?)

    #endregion

    #region Constructors

    public Service(int service_Id, string service_Name, string service_Description)
    {
        Service_Id = service_Id;
        Service_Name = service_Name;
        Service_Description = service_Description;
    }

    #endregion

    #region SQL

    public bool InsertService(Service service)
    {
        using (var connection = new Builder().Connect())
        {
            try
            {
                var id = connection.Insert("service", service);
                MessageBox.Show("Service id: " + service.Service_Id + " created.", "Service Created");
                return true;
            }
            catch (Exception e)
            {
                LogManager.GetLogger("LoggingRepo").Warn(e, e);
                return false;
            }
        }
    }

    public bool DeleteService(int serviceId)
    {
        using (var connection = new Builder().Connect())
        {
            try
            {
                var id = connection.Delete("service", serviceId);
                MessageBox.Show("Service id: " + serviceId + " removed.", "Service Removed");
                return true;
            }
            catch (Exception e)
            {
                LogManager.GetLogger("LoggingRepo").Warn(e, e);
                return false;
            }
        }
    }

    public bool UpdateService(Service service)
    {
        using (var connection = new Builder().Connect())
        {
            try
            {
                {
                    var updatedService = connection.Update("service", service);
                    MessageBox.Show("Service id: " + service.Service_Id + " updated.", "Service Updated");
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