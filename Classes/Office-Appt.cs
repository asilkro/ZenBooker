using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenoBook.Classes
{
    public class OfficeAppointment : Appointment
    {
        #region Properties / Fields
        public int OfficeId { get; set; }
        public bool InHomeService { get; set; } // TODO: update SQL schema to support these

        #endregion

        #region Constructors

        public OfficeAppointment()
        {

        }

        public OfficeAppointment(int appointmentId, int customerId, int staffId, int officeId, int serviceId, DateTime start, DateTime end, bool inHomeService)
        {
            AppointmentId = appointmentId;
            CustomerId = customerId;
            StaffId = staffId;
            OfficeId = officeId;
            ServiceID = serviceId;
            Start = start;
            End = end;
            InHomeService = inHomeService;
        }


        #endregion

    }
}
