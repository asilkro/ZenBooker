using System.Data;
using System.Text;
using log4net;
using MySqlConnector;
using RepoDb;
using RepoDb.Extensions;
using ZenoBook.Classes;
using ZenoBook.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ZenoBook.DataManipulation;

public class Helpers
{
    public bool LoginIsValid(string username, string password, string encryptionPw)
    {
        if (username.IsNullOrEmpty() || password.IsNullOrEmpty()) return false;
        var enteredLogin = EncryptLogin(username, encryptionPw);
        var enteredPass = EncryptPw(password, encryptionPw);

        using (var connection = new Builder().Connect())
        {
            var s1 = EncryptLogin(connection.Query<User>(e => e.Login == username).First().Login, encryptionPw);
            var s2 = EncryptPw(connection.Query<User>(e => e.Login == username).First().Password, encryptionPw);

            if (s2 != enteredPass) return false;
        }

        return true;
    }

    private static byte[] EncryptLogin(string username, string encryptionPw)
    {
        var userBytes = Encoding.Default.GetBytes(username);
        var encryptionBytes = Encoding.Default.GetBytes(encryptionPw);

        var checkUser = Security.AES_Encrypt(userBytes, encryptionBytes);
        return checkUser;
    }

    private static byte[] EncryptPw(string password, string encryptionPw)
    {
        var passBytes = Encoding.Default.GetBytes(password);
        var encryptionBytes = Encoding.Default.GetBytes(encryptionPw);

        var checkPass = Security.AES_Encrypt(passBytes, encryptionBytes);
        return checkPass;
    }

    public static void searchDataDGV(string valueToSearch, string tableToSearch, DataGridView dataGridViewToPop)
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
        int.TryParse(apptId, out var i);
        using (var connection = new Builder().Connect())
        {
            var query = connection.Query<Appointment>("[zth].[appointment]", e => e.AppointmentId == i)
                .FirstOrDefault();
            if (query != null)
            {
                var formToReturn = new FormAppointment(query);
                formToReturn.Activate();
            }
        }
    }

    public static Type WhatKindOfAppt(int ApptId)
    {
        using var connection = new Builder().Connect();
        var query = connection.Query<HomeAppointment>("[zth].[appointment]", e => e.AppointmentId == ApptId)
            .FirstOrDefault();
        switch (query.InHomeService)
        {
            case true:
                return typeof(HomeAppointment);
            case false:
                return typeof(OfficeAppointment);
        }
    }

    public static string? AutoIncrementId(string tableName) //TODO: TEST THE AUTOINCREMENT - if it's not playing ball, yeet it
    {
        using var connection = new Builder().Connect();
        try
        {
            connection.Open();
            var setupCommand = connection.CreateCommand();
            setupCommand.CommandText = "SET @@SESSION.information_schema_stats_expiry = 0;";
            setupCommand.ExecuteNonQuery(); //Makes sure autoincrement doesn't reset during this session

            var autoIncrement = connection.CreateCommand();
            autoIncrement.CommandText = "SELECT AUTO_INCREMENT FROM information_schema.tables " +
                                        "WHERE table_name = @TABLE AND table_schema = DATABASE();";
            autoIncrement.Parameters.AddWithValue("@TABLE", tableName);
            
            var intAiNumber = autoIncrement.ExecuteScalar()?.ToString();
            MessageBox.Show("Debug: Auto increment number is: " + intAiNumber);
            return intAiNumber;

        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return null;
        }
    }
}