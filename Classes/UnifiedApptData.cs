namespace ZenoBook.Classes;

public class UnifiedApptData : Appointment
{
    #region Properties

    public int office_id { get; set; }
    public int service_address_id { get; set; }
    public sbyte inhomeservice { get; set; }

    #endregion

    #region Constructors

    public UnifiedApptData()
    {
    }

    public UnifiedApptData(int appointment_Id, int customer_Id, int staff_id, int office_Id, int service_Id,
        DateTime start, DateTime end,
        sbyte inhomeservice, int service_Address_Id)
    {
        appointment_id = appointment_Id;
        customer_id = customer_Id;
        this.staff_id = staff_id;
        office_id = office_Id;
        service_id = service_Id;
        this.start = start;
        this.end = end;
        this.inhomeservice = inhomeservice;
        service_address_id = service_Address_Id;
    }
    #endregion
}