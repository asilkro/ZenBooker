using log4net;
using RepoDb;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes;

public class OfficeAppointment : Appointment
{
    #region Properties / Fields

    public int office_id { get; set; }
    public sbyte inhomeservice { get; set; }

    #endregion

    #region Constructors

    public OfficeAppointment()
    {
    }

    public OfficeAppointment(int appointmentId, int customerId, int staffId, int officeId, int serviceId,
        DateTime start, DateTime end, sbyte inhomeservice)
    {
        appointment_id = appointmentId;
        customer_id = customerId;
        staff_id = staffId;
        office_id = officeId;
        service_id = serviceId;
        this.start = start;
        this.end = end;
        this.inhomeservice = inhomeservice;
    }

    #endregion
}