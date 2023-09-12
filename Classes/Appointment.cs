using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenoBook.Classes
{
    internal class Appointment
    {
        #region Properties / Fields

        public int AppointmentId { get; set; } // PK, auto_increment, not_null
        public int CustomerId { get; set; } // FK, Customer.CustomerId, not_null
        public int StaffId { get; set; } // FK, Staff.StaffId, not_null
        public int OfficeId { get; set; } // FK, Office.OfficeId, not_null
        public DateTime Start { get; set; } // not_null
        public DateTime End { get; set; } // not_null

        public Boolean InHomeService { get; set; } // Not in use in SQL
        // TODO: Figure out how I want to use this

        #endregion

        #region Constructors

        public Appointment()
        {

        }

        public Appointment(int appointmentId, int customerId, int staffId, int officeId, DateTime start, DateTime end, bool inHomeService)
        {
            AppointmentId = appointmentId;
            CustomerId = customerId;
            StaffId = staffId;
            OfficeId = officeId;
            Start = start;
            End = end;
            InHomeService = inHomeService;
        }


        #endregion

    }
}
