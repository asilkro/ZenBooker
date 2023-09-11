using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenBooker.Classes
{
    internal class Office
    {
        #region Properties / Fields
        public int OfficeId { get; set; } // // PK, auto_increment, not_null
        public string OfficeName { get; set; } // VARCHAR(32)
        public string City { get; set; } // VARCHAR(32)
        public string State { get; set; } // VARCHAR(32)
        public string Country { get; set; } // VARCHAR(32)

        #endregion

        #region Constructors

        public Office()
        {

        }

        #endregion
    }
}
