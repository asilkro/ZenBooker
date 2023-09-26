using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using RepoDb;
using RepoDb.Extensions;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;
using ZenoBook.Forms;


namespace ZenoBook.DataManipulation
{
    public class Helpers
    {
        public bool LoginIsValid(string username, string password, string encryptionPw)
        {
            if (username.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                return false;
            }
            var enteredLogin = EncryptLogin(username, encryptionPw);
            var enteredPass = EncryptPw(password, encryptionPw);

            using (var connection = new Builder().Connect())
            {
                var s1 = EncryptLogin(connection.Query<User>(e => e.Login == username).First().Login, encryptionPw);
                var s2 = EncryptPw(connection.Query<User>(e => e.Login == username).First().Password, encryptionPw);

                if (s2 != enteredPass)
                {
                    return false;
                }
            }

            return true;
        }

        private static byte[] EncryptLogin(string username, string encryptionPw)
        {
            byte[] userBytes = Encoding.Default.GetBytes(username);
            byte[] encryptionBytes = Encoding.Default.GetBytes(encryptionPw);

            var checkUser = Security.AES_Encrypt(userBytes, encryptionBytes);
            return checkUser;
        }

        private static byte[] EncryptPw(string password, string encryptionPw)
        {
            byte[] passBytes = Encoding.Default.GetBytes(password);
            byte[] encryptionBytes = Encoding.Default.GetBytes(encryptionPw);

            var checkPass = Security.AES_Encrypt(passBytes, encryptionBytes);
            return checkPass;
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

        public void ExistingAppointment(string apptId)
        {
            int.TryParse(apptId, out int i);
            using (MySqlConnection connection = new Builder().Connect())
            {
                var query = connection.Query<Appointment>("[zth].[appointment]", e => e.AppointmentId == i).FirstOrDefault();
                if (query != null)
                {
                    var formToReturn = new FormAppointment(query);
                    formToReturn.Activate();
                }
            }
        }
    }
}
