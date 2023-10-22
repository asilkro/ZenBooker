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

    #region Constructors

    public Appointment()
    {
    }

    public Appointment(int appointment_Id, int customer_Id, int staff_id, int service_Id, DateTime start, DateTime end)
    {
        appointment_id = appointment_Id;
        customer_id = customer_Id;
        this.staff_id = staff_id;
        this.service_id = service_Id;
        this.start = start;
        this.end = end;
    }
    public static DateTime CheckDbNull(object dateTime)
    {
        if (dateTime == DBNull.Value)
        {
            return DateTime.MinValue;
        }
        return (DateTime)dateTime;
    }

    #endregion
}