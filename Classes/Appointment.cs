namespace ZenoBook.Classes;

public class Appointment
{
    #region Properties / Fields

    public int Appointment_Id { get; set; } // PK, auto_increment, not_null
    public int Customer_Id { get; set; } // FK, Customer.Customer_Id
    public int Staff_Id { get; set; } // FK, Staff.Staff_Id
    public int Service_Id { get; set; } // FK, Service.Service_Id
    public DateTime Start { get; set; } //
    public DateTime End { get; set; } //

    #endregion

    #region Constructors

    public Appointment()
    {
    }

    protected Appointment(int appointmentId, int customerId, int serviceId, DateTime start, DateTime end)
    {
        Appointment_Id = appointmentId;
        Customer_Id = customerId;
        Service_Id = serviceId;
        Start = start;
        End = end;
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