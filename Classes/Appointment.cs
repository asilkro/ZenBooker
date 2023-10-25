namespace ZenoBook.Classes;

public class Appointment
{
    #region Properties / Fields

    public int appointment_id { get; set; } // PK, auto_increment, not_null
    public int customer_id { get; set; } // FK, Customer.customer_id
    public int staff_id { get; set; } // FK, Staff.staff_id
    public int service_id { get; set; } // FK, Service.service_id
    public DateTime start { get; set; } //
    public DateTime end { get; set; } //

    #endregion
}