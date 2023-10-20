using System;
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

    public static void WakeUpSQL(MySqlConnection conn)
    {
        if (conn.State != ConnectionState.Open)
        {
            conn.Open();
        }
    }

    public static string WhatIsThisThing(string valueToCheck)
    {
        var space = ' ';
        var atSign = '@';
        string result = "default";

        if (DateTime.TryParse(valueToCheck, out _))
        {
            result = "date";
            return result; // If it parses as a date, treat as date
        }

        if (long.TryParse(valueToCheck, out _))
        {
            result = "integer";
            return result; // If it parses as a number, treat as ID or a phone number
        }

        if (valueToCheck.Contains(atSign))
        {
            result = "email";
            return result; // If it has an @ sign, treat as an email address
        }

        if (valueToCheck.Contains(space))
        {
            result = "name";
            return result; // If it has a whitespace, treat as a name
        }


        return result;
    }
    
    public static string HashedString(string input)
    {
        using SHA256 sha256Hash = SHA256.Create();
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2")); //format string to match format in DB; could be changed
            //if updated formatting of the hashes in the DB is desired
        }

        return builder.ToString();
    }

    #region SQL

    public static string?
        AutoIncrementId(string tableName)
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
            return intAiNumber;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return null;
        }
    }

    public static Customer? ReturnCustomer(string searchTerm)
    {
        using var connection = new Builder().Connect();
        var space = ' ';
        var atSign = '@';

        if (searchTerm.Contains(space))
        {
            var searchTerms = searchTerm.Split(' ', 2);
            var first = searchTerms[0];
            var last = searchTerms[1];
            var sCustomer = connection.Query<Customer>("customer", e => e.First == first && e.Last == last)
                .FirstOrDefault();
            if (sCustomer != null)
            {
                return sCustomer;
            }
        }

        if (searchTerm.Contains(atSign))
        {
            var aCustomer = connection.Query<Customer>("customer", e => e.Email == searchTerm)
                .FirstOrDefault();
            if (aCustomer != null)
            {
                return aCustomer;
            }
        }

        if (int.TryParse(searchTerm, out var i))
        {
            var iCustomer = connection.Query<Customer>("customer", e => e.Customer_Id == i)
                .FirstOrDefault();
            if (iCustomer != null)
            {
                return iCustomer;
            }
        }
        return null;
    }

    public static Staff? ReturnStaff(string searchTerm)
    {
        using var connection = new Builder().Connect();
        var atSign = '@'; 
        if (searchTerm.Contains(atSign))
        {
            var eStaff = connection.Query<Staff>("staff", e => e.Email == searchTerm).FirstOrDefault();
            if (eStaff == null)
            {
                return null;
            }
            return eStaff;
        }

        var staff = connection.Query<Staff>("staff", e => e.Name == searchTerm).FirstOrDefault();
        if (staff == null)
        {
            return null;
        }
        return staff;
    }

    public static Service? ReturnService(string searchTerm)
    {
        using var connection = new Builder().Connect();
        if (int.TryParse(searchTerm, out var i))
        {
            var iService = connection.Query<Service>("service", e => e.Service_Id == int.Parse(searchTerm))
                .GetEnumerator().Current;
            return iService;
        }

        var service = connection.Query<Service>("service", e => e.Service_Name.Contains(searchTerm))
            .GetEnumerator().Current;
        return service;
    }

    public static Office? ReturnOffice(string searchTerm)
    {
        using var connection = new Builder().Connect();
        if (int.TryParse(searchTerm, out var i))
        {
            var iOffice = connection.Query<Office>("office", e => e.Office_Id == int.Parse(searchTerm))
                .GetEnumerator().Current;
            return iOffice;
        }

        var nOffice = connection.Query<Office>("office", e => e.Office_Name.Contains(searchTerm))
            .GetEnumerator().Current;
        if (nOffice == null)
        {
            return null;
        }
        return nOffice;
    }
    #endregion
}