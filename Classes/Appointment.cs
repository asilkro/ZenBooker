using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenBooker.Classes
{
    internal class Appointment
    {
        #region Properties / Fields

        public int AppointmentId { get; set; } // PK, auto_increment, not_null
        public int CustomerId { get; set; } // FK, Customer.CustomerId
        public int StaffId { get; set; } // FK, Staff.StaffId
        public int OfficeId { get; set; } // FK
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Boolean InHomeService { get; set; }
        // TODO: Figure out how I want to use this

        #endregion

        #region Constructors

        public Appointment()
        {

        }

        #endregion

    }
}
