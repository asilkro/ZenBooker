namespace ZenoBook.Classes;

public class Staff
{
    #region Properties / Fields

    public int staff_id { get; set; } // PK, auto_increment, not_null
    public string name { get; set; } // VARCHAR(45), not_null
    public string email { get; set; } // VARCHAR(45)
    public int office_id { get; set; } // FK, Office.office_id
    public string phone { get; set; } // VARCHAR(12)
    public int user_id { get; set; } // FK, User.user_id

    #endregion

    #region Constructors

    public Staff()
    {
    }

    public Staff(int staff_Id, string name, string email, int office_Id, string phone, int user_Id)
    {
        staff_id = staff_Id;
        this.name = name;
        this.email = email;
        office_id = office_Id;
        this.phone = phone;
        user_id = user_Id;
    }

    #endregion
}