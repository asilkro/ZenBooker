namespace ZenoBook.Classes;

public class User
{
    #region Properties / Fields

    public int user_id { get; set; } // PK, Users.user_id
    public string login { get; set; } // VARCHAR(32)
    public string password { get; set; } // VARCHAR(64) - Hashed PW
    #endregion

    #region Constructors

    public User()
    {

    }

    public User(int user_id, string login, string password)
    {
        this.user_id = user_id;
        this.login = login;
        this.password = password;
    }

    #endregion
}