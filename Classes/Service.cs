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
    public class Service
    {
        #region Properties / Fields

        public int Service_Id { get; set; } // PK, auto_increment, not_null, FK Service_Id on Appt
        public string ServiceName { get; set; } // VARCHAR(32)
        public string ServiceDesc { get; set; } // VARCHAR (64?)
        public bool HomeVisitService { get; set; }

        #endregion

        #region Constructors

        public Service()
        {

        }

        public Service(int serviceId, string serviceName, string serviceDesc, bool homeVisitService)
        {
        Service_Id = serviceId;
        ServiceName = serviceName;
        ServiceDesc = serviceDesc;
        HomeVisitService = homeVisitService;
        }

        #endregion

        #region SQL

        public bool InsertService(Service service)
        {
            using (var connection = new Builder().Connect())
                try
                {
                    var id = connection.Insert("[zth].[services]", entity: service);
                    MessageBox.Show("Service " + id + " created.", "Service Created");
                    return true;
                }
                catch (Exception e)
                {
                    LogManager.GetLogger("LoggingRepo").Warn(e, e);
                    return false;
                }

        }

        public bool DeleteService(int serviceId)
        {
            using (var connection = new Builder().Connect())
                try
                {
                    var id = connection.Delete("[zth].[services]", serviceId);
                    MessageBox.Show("Service id " + id + " removed.", "Service Removed");
                    return true;
                }
                catch (Exception e)
                {
                    LogManager.GetLogger("LoggingRepo").Warn(e, e);
                    return false;
                }
        }

        public bool UpdateService(Service service)
        {
            using (var connection = new Builder().Connect())
                try
                {
                    {
                        var updatedCx = connection.Update("[zth].[services]", entity: service);
                        MessageBox.Show("Service id " + updatedCx + " updated.", "Customer Updated");
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
}
