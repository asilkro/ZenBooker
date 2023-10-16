using System.Data;
using log4net;
using MySqlConnector;
using RepoDb;
using ZenoBook.Classes;
using ZenoBook.Forms;

namespace ZenoBook.DataManipulation;

public class Helpers
{
    public bool LoginIsValid(string username, string password)
    {
        var result = false;
        using var connection = new Builder().Connect();
        var sqlcmd = connection.CreateCommand();
        {
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "zth.AuthenticateUser";
            sqlcmd.Parameters.Add(new MySqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@paramLogin",
                Value = username
            });

            sqlcmd.Parameters.Add(new MySqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@paramPassword",
                Value = password
            });

            sqlcmd.Parameters.Add(new MySqlParameter()
            {
                Direction = ParameterDirection.Output,
                ParameterName = "@isAuthenticated",
            });
            if (sqlcmd.ExecuteNonQuery() == 1)
            {
                result = true;
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
        var query = connection.Query<Appointment>("[zth].[appointment]", e => e.AppointmentId == i)
            .FirstOrDefault();
        if (query != null)
        {
            var formToReturn = new FormAppointment(query);
            formToReturn.Activate();
        }
    }

    public static Type WhatKindOfAppt(int ApptId)
    {
        using var connection = new Builder().Connect();
        var query = connection.Query<HomeAppointment>("[zth].[appointment]", e => e.AppointmentId == ApptId)
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