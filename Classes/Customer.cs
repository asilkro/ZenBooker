namespace ZenoBook.Classes;

public class Customer
{
    #region Properties / Fields

    public int customer_id { get; set; } // PK, auto_increment
    public string first { get; set; } // VARCHAR(32), nn
    public string last { get; set; } // VARCHAR(32), nn
    public string phone { get; set; } // VARCHAR(12)
    public string email { get; set; } // VARCHAR(48)
    public int preferred_office { get; set; } // int, FK

    #endregion

    #region Constructors

    public Customer()
    {
    }

    public Customer(int customer_Id, string first, string last, string phone, string email, int preferred_Office)
    {
        customer_id = customer_Id;
        this.first = first;
        this.last = last;
        this.phone = phone;
        this.email = email;
        preferred_office = preferred_Office;
    }
    #endregion
}