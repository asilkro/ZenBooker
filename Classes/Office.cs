using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenoBook.Classes
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

        public Office(int officeId, string officeName, string city, string state, string country)
        {
            OfficeId = officeId;
            OfficeName = officeName;
            City = city;
            State = state;
            Country = country;
        }

        #endregion
    }
}
