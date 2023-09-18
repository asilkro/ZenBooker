using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenoBook.Classes
{
    public abstract class Appointment
    {
        #region Properties / Fields

        public int AppointmentId { get; set; } // PK, auto_increment, not_null
        public int CustomerId { get; set; } // FK, Customer.CustomerId
        public int StaffId { get; set; } // FK, Staff.StaffId
        public int ServiceID { get; set; } // FK, Services.ServiceId
        public DateTime Start { get; set; } //
        public DateTime End { get; set; } //

        #endregion

        #region Constructors

        public Appointment()
        {

        }

        public Appointment(int appointmentId, int customerId, int serviceId, DateTime start, DateTime end)
        {
            AppointmentId = appointmentId;
            CustomerId = customerId;
            ServiceID = serviceId;
            Start = start;
            End = end;
        }
        #endregion
        
    }
    
}
