namespace ZenoBook.Classes;

public class Service
{
    #region Properties / Fields

    public int service_id { get; set; } // PK, auto_increment, not_null, FK service_id on Appt
    public string service_name { get; set; } // VARCHAR(32)
    public string service_description { get; set; } // VARCHAR (64?)

    #endregion

    #region Constructor
    public Service(int service_Id, string service_Name, string service_Description)
    {
        service_id = service_Id;
        service_name = service_Name;
        service_description = service_Description;
    }
    #endregion
}