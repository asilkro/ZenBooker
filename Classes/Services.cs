using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenoBook.Classes
{
    internal class Services
    {
        #region Properties / Fields

        public int ServiceId { get; set; } // PK, auto_increment, not_null, FK ServiceId on Appt
        public string ServiceName { get; set; } // VARCHAR(32)
        public string ServiceDesc { get; set; } // VARCHAR (64?)

        #endregion

        #region Constructors

        public Services()
        {

        }

        public Services(int serviceId, string serviceName, string serviceDesc)
        {
        ServiceId = serviceId;
        ServiceName = serviceName;
        ServiceDesc = serviceDesc;
        }
        #endregion
    }
}
