using MySqlConnector;

namespace ZenoBook.DataManipulation;

public class Builder
{
    private const string _database = "zth";
    private const string _password = "Zenobook4zenobia";

    private const string _serveraddress = "localhost";

    // These values should not be altered.
    private const string _username = "zthstaff";

    public static string ConnectionString()
    {
        var csb = new MySqlConnectionStringBuilder
        {
            UserID = _username,
            Password = _password,
            Server = _serveraddress,
            Database = _database
        };

        var connString = csb.ToString();

        return connString;
    }

    public MySqlConnection Connect()
    {
        return new MySqlConnection(ConnectionString());
    }
}