using MySqlConnector;

namespace ZenoBook.DataManipulation
{
    public class Builder
    {
        // These values should not be altered.
       private readonly string _username = "zthstaff";
       private readonly string _password = "Zenobook4zenobia";
       private readonly string _serveraddress = "localhost";
       private readonly string _database = "zth";

        public string ConnectionString()
        {
            MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder();
            csb.UserID = _username;
            csb.Password = _password;
            csb.Server = _serveraddress;
            csb.Database = _database;

            var connString = csb.ToString();

            return connString;
        }

        public MySqlConnection Connection()
        {
            return new MySqlConnection(ConnectionString());
        }
    }
}