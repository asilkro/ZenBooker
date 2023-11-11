using MySqlConnector;
using System.Data;

namespace ZenoBook.DataManipulation;

internal partial class Builder
{
    protected static string ConnectionString()
    {
        var csb = new MySqlConnectionStringBuilder
        {
            UserID = _username,
            Password = _password,
            Server = _serveraddress,
            Database = _database,
            SslMode = MySqlSslMode.Required
        };
        var connString = csb.ToString();

        return connString;
    }

    public MySqlConnection Connect()
    {
        return new MySqlConnection(ConnectionString());
    }

    public static MySqlConnection SmartConnect(MySqlConnection connection)
    {
        switch (connection.State)
        {
            case ConnectionState.Open:
                break;
            case ConnectionState.Closed:
                connection.Open();
                break;
            case ConnectionState.Broken:
                connection.Dispose();
                break;
            case ConnectionState.Connecting:
            case ConnectionState.Executing:
            case ConnectionState.Fetching:
            default:
                connection.Open();
                break;
        }

        return connection;
    }
}