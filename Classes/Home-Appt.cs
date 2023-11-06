namespace ZenoBook.Classes;

public class HomeAppointment : Appointment
{
    #region Properties / Fields

    public sbyte inhomeservice { get; set; }
    public int? service_address_id { get; set; }

    #endregion

    #region Constructors

    public HomeAppointment()
    {
    }

    public HomeAppointment(int appointmentId, int customerId, int staffId, int serviceId, DateTime start, DateTime end,
        sbyte inhomeservice, int service_Address_Id)
    {
        appointment_id = appointmentId;
        customer_id = customerId;
        staff_id = staffId;
        service_id = serviceId;
        this.start = start;
        this.end = end;
        this.inhomeservice = inhomeservice;
        service_address_id = service_Address_Id;
    }

    #endregion
}