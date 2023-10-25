namespace ZenoBook.Classes;

public class Address
{
    #region Properties

    public int address_id { get; set; }
    public string address1 { get; set; }
    public string? address2 { get; set; }
    public string city { get; set; }
    public string? state { get; set; }
    public string country { get; set; }

    #endregion

    #region Constructors

    public Address()
    {
    }

    public Address(int address_Id, string address1, string? address2,
        string city, string? state, string country)
    {
        address_id = address_Id;
        this.address1 = address1;
        this.address2 = address2;
        this.city = city;
        this.state = state;
        this.country = country;
    }
    #endregion
}