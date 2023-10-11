using MySqlConnector;

namespace ZenoBook.DataManipulation;

public class Builder
{
    private readonly string _database = "zth";
    private readonly string _password = "Zenobook4zenobia";

    private readonly string _serveraddress = "localhost";

    // These values should not be altered.
    private readonly string _username = "zthstaff";

    public string ConnectionString()
    {
        var csb = new MySqlConnectionStringBuilder();
        csb.UserID = _username;
        csb.Password = _password;
        csb.Server = _serveraddress;
        csb.Database = _database;

        var connString = csb.ToString();

        return connString;
    }

    public MySqlConnection Connect()
    {
        return new MySqlConnection(ConnectionString());
    }
}