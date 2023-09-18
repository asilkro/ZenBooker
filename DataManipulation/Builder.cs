using MySqlConnector;

namespace ZenoBook.DataManipulation
{
    public class Builder
    {
        // These values should not be altered.
       private string _username = "zthstaff";
       private string _password = "Zenobook4zenobia";
       private string _serveraddress = "localhost";
       private string _database = "zth";

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