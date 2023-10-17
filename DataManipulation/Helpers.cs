using System.Data;
using System.Security.Cryptography;
using System.Text;
using log4net;
using MySqlConnector;
using RepoDb;
using RepoDb.Extensions;
using ZenoBook.Classes;
using ZenoBook.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ZenoBook.DataManipulation;

public class Helpers
{
    public bool LoginIsValid(string username, string password)
    {
        var result = false;
        using (var connection = new Builder().Connect())
        {
            WakeUpSQL(connection);
            MySqlCommand sqlcmd = connection.CreateCommand();
            sqlcmd.CommandText = "call zth.AuthenticateUser";
            sqlcmd.Parameters.AddWithValue("@paramLogin", username);
            sqlcmd.Parameters.AddWithValue("@paramPassword", password);
            sqlcmd.Parameters.AddWithValue("@isAuthenticated", null).Direction = ParameterDirection.ReturnValue;
            sqlcmd.CommandType = CommandType.StoredProcedure;


            var outcome = (int) sqlcmd.ExecuteScalar();
            if (outcome == 1)
            {
                result = true;
            }

            connection.Close();
        }

        return result;
    }

    public bool ValidateLogin(string username, string password)
    {
        var result = false;
        using (var connection = new Builder().Connect())
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                var fields = new[]
                {
                    new QueryField("login", username),
                    new QueryField("password", HashedString(password))
                };
                var existing = connection.Exists("user", fields);
                if (existing)
                {
                    result = true;
                    connection.Close();
                    return result;
                }
            }

            return result;
        }
    }

    public static void searchDataDGV(string valueToSearch, string tableToSearch, DataGridView dataGridViewToPop)
    {
        using var connection = new Builder().Connect();
        var query = connection.CreateCommand();
        query.CommandText = "SELECT * FROM @TABLE like '%\"+@SEARCHVALUE+\"%'";
        query.Parameters.AddWithValue("@TABLE", tableToSearch);
        query.Parameters.AddWithValue("@SEARCHVALUE", valueToSearch);
        var da = new MySqlDataAdapter(query);
        var dt = new DataTable("SearchResults");
        da.Fill(dt);
        dataGridViewToPop.DataSource = dt;
    }

    public void ExistingAppointment(string apptId)
    {
        int.TryParse(apptId, out var i);
        using var connection = new Builder().Connect();
        var query = connection.Query<Appointment>("[zth].[appointment]", e => e.Appointment_Id == i)
            .FirstOrDefault();
        if (query != null)
        {
            var formToReturn = new FormAppointment(query);
            formToReturn.Activate();
        }
    }

    public static void WakeUpSQL(MySqlConnector.MySqlConnection conn)
    {
        if (conn.State != ConnectionState.Open)
        {
            conn.Open();
        }
    }

    public static Type WhatKindOfAppt(int ApptId)
    {
        using var connection = new Builder().Connect();
        var query = connection.Query<HomeAppointment>("[zth].[appointment]", e => e.Appointment_Id == ApptId)
            .FirstOrDefault();
        var returnType = typeof(Appointment);
        switch (query?.InHomeService)
        {
            case true:
                returnType = typeof(HomeAppointment);
                break;
            case false:
                returnType = typeof(OfficeAppointment);
                break;
        }

        return returnType;
    }

    public static string?
        AutoIncrementId(string tableName) //TODO: TEST THE AUTOINCREMENT - if it's not playing ball, yeet it
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

    public static string HashedString(string input)
    {
        // First, make a new hash
        using SHA256 sha256Hash = SHA256.Create();
        // This will need an array of bytes
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Convert byte array to a string
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2")); //format string to match format in DB; could be changed
            //if updated formatting of the hashes in the DB is desired
        }

        return builder.ToString();
    }
}