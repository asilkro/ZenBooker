using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
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
                using (new Builder().Connection())
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

        public void WriteSuccessful(string command, string table)
        {
            //TODO: scaffold out SQL commands to do the work
        }
    }
}
