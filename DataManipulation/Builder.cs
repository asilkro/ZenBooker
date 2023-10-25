using MySqlConnector;

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
}