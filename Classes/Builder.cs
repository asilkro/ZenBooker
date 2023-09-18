using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using RepoDb;

namespace ZenoBook.Classes
{
    public class Builder
    {
        // These values should not be altered.
       private string username = "zthstaff";
       private string password = "Zenobook4zenobia";
       private string serveraddress = "localhost";
       private string database = "zth";

        public string ConnectionString()
        {
            string connString = null;

            MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder();
            csb.UserID = username;
            csb.Password = password;
            csb.Server = serveraddress;
            csb.Database = database;

            connString = csb.ToString();

            return connString;
        }
    }
}