namespace ZenoBook.Classes;

public class User
{
    #region Properties

    public int User_id { get; set; } // PK, auto_increment, not_null
    public string Login { get; set; } // VARCHAR(32), PK, not_null
    public string Password { get; set; } // VARCHAR(64)

    #endregion
}