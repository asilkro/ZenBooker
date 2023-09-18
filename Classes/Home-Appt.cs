using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenoBook.Classes
{
    public class HomeAppointment : Appointment
    {
        #region Properties / Fields
        public bool InHomeService { get; set; } // TODO: update SQL schema to support these
        public int ServiceAddressId { get; set; } // TODO: create table for Service Addresses

        #endregion

        #region Constructors

        public HomeAppointment()
        {

        }

        public HomeAppointment(int appointmentId, int customerId, int staffId, int serviceId, DateTime start, DateTime end, bool inHomeService, int serviceAddressId)
        {
            AppointmentId = appointmentId;
            CustomerId = customerId;
            StaffId = staffId;
            ServiceID = serviceId;
            Start = start;
            End = end;
            InHomeService = inHomeService;
            ServiceAddressId = serviceAddressId;
        }


        #endregion

    }
}
