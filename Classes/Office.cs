namespace ZenoBook.Classes;

public class Office
{
    #region Properties / Fields

    public int office_id { get; set; } // // PK, auto_increment, not_null
    public int address_id { get; set; }
    public string office_name { get; set; } // VARCHAR(32)

    #endregion

    #region Constructors

    public Office()
    {
    }

    public Office(int officeId, int addressId, string officeName)
    {
        office_id = officeId;
        address_id = addressId;
        office_name = officeName;
    }
    #endregion
}