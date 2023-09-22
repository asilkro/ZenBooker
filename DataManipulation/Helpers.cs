using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using RepoDb;
using RepoDb.Extensions;
using ZenoBook.DataManipulation;


namespace ZenoBook.DataManipulation
{
    internal class Helpers
    {
        public bool LoginIsValid(string username, string password, string encryptionPw)
        {
            if (username.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                return false;
            }
            byte[] userBytes = Encoding.Default.GetBytes(username);
            byte[] passBytes = Encoding.Default.GetBytes(password);
            byte[] encryptionBytes = Encoding.Default.GetBytes(encryptionPw);
            
            var checkUser = Security.AES_Encrypt(userBytes, encryptionBytes);
            var checkPass = Security.AES_Encrypt(passBytes, encryptionBytes);


            bool CheckLogin()
            {
                using (new Builder().Connect())
                {
                    string commandText = "SELECT * FROM users WHERE username = '@USER' AND password = '@PASS';";
                    var cmd = new MySqlCommand(commandText);
                    cmd.Parameters.AddWithValue("@USER", username);
                    cmd.Parameters.AddWithValue("@PASS", password);
                    if (cmd.ExecuteNonQuery() != 1)
                    {
                        return false;
                    }

                    return true;
                }
            }
            return true;
        }

        public void searchDataDGV(string valueToSearch, string tableToSearch, DataGridView dataGridViewToPop)
        {
            using (var connection = new Builder().Connect())
            {
                var query = connection.CreateCommand();
                query.CommandText = "SELECT * FROM @TABLE like '%\"+@SEARCHVALUE+\"%'";
                query.Parameters.AddWithValue("@TABLE", tableToSearch);
                query.Parameters.AddWithValue("@SEARCHVALUE", valueToSearch);
                var da = new MySqlDataAdapter(query);
                var dt = new DataTable("SearchResults");
                da.Fill(dt);
                dataGridViewToPop.DataSource = dt;
            }
        }
    }
}
