using log4net;
using MySqlConnector;
using RepoDb;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using ZenoBook.Classes;

namespace ZenoBook.DataManipulation;

public class Helpers
{
    #region Login Related

    public static bool ValidateLogin(string username, string password)
    {
        var result = false;
        using var connection = new Builder().Connect();
        if (connection.State == ConnectionState.Open) return result;
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

        return result;
    }

    public static string HashedString(string input)
    {
        using var sha256Hash = SHA256.Create();
        var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));


        StringBuilder builder = new();
        for (var i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2")); //format string to match format in DB; could be changed
            //if updated formatting of the hashes in the DB is desired
        }

        return builder.ToString();
    }

    #endregion

    #region Misc

    public static void searchDGV(DataGridView dgv, string tableName, string searchQuery)
    {
        {
            using var connection = new Builder().Connect();
            {
                var searchType = Helpers.WhatIsThisThing(searchQuery);
                if (searchType == "default")
                {
                    MessageBox.Show("Invalid search parameter.");
                    tableName = "discard";
                }

                switch (tableName)
                {
                    case "appointment":
                    {
                        if (searchType == "date")
                        {
                            var sql = "SELECT * FROM 'appointment' WHERE CONTAINS(start,'@VALUE');";
                            sql = sql.Replace("@VALUE", searchQuery);
                            var results = connection.ExecuteQuery<Appointment>(sql);
                            var appointments = results.ToList();
                            BindingSource bs = new(appointments, tableName);
                            dgv.DataSource = bs;
                        }

                        if (searchType == "integer")
                        {
                            var sql = "SELECT * FROM 'appointment' WHERE CONTAINS(customer_id,'@VALUE');";
                            sql = sql.Replace("@VALUE", searchQuery);
                            var results = connection.ExecuteQuery<Appointment>(sql);
                            var appointments = results.ToList();
                            BindingSource bs = new(appointments, tableName);
                            dgv.DataSource = bs;
                        }

                        break;
                    }
                    case "customer":
                    {
                        if (searchType == "email")
                        {
                            var sql = "SELECT * FROM 'customer' WHERE CONTAINS(email,'@VALUE');";
                            sql = sql.Replace("@VALUE", searchQuery);
                            var results = connection.ExecuteQuery<Customer>(sql);
                            var customers = results.ToList();
                            BindingSource bs = new(customers, tableName);
                            dgv.DataSource = bs;
                        }

                        if (searchType == "integer")
                        {
                            var sql = "SELECT * FROM 'customer' WHERE CONTAINS(phone,'@VALUE');";
                            sql = sql.Replace("@VALUE", searchQuery);
                            var results = connection.ExecuteQuery<Customer>(sql);
                            var customers = results.ToList();
                            BindingSource bs = new(customers, tableName);
                            dgv.DataSource = bs;
                        }

                        if (searchType == "name")
                        {
                            var sql =
                                "SELECT *, concat_ws(' ', 'first', 'last') AS Name FROM 'customer' HAVING Name LIKE '@VALUE'";
                            sql = sql.Replace("@VALUE", searchQuery);
                            var results = connection.ExecuteQuery<Customer>(sql);
                            var customers = results.ToList();
                            BindingSource bs = new(customers, tableName);
                            dgv.DataSource = bs;
                        }

                        break;
                    }
                    case "service":
                    {
                        if (searchType == "name")
                        {
                            var sql = "SELECT * FROM 'service' WHERE CONTAINS(service_name,'@VALUE');";
                            sql = sql.Replace("@VALUE", searchQuery);
                            var results = connection.ExecuteQuery<Service>(sql);
                            var services = results.ToList();
                            BindingSource bs = new(services, tableName);
                            dgv.DataSource = bs;
                        }

                        break;
                    }
                }
            }
        }
    }

    public static void populateDGV(DataGridView dgv, string tableName)
    {
        {
            var selectQuery = "SELECT * FROM " + tableName + ";";
            var connection = new Builder().Connect();
            switch (connection.State)
            {
                case ConnectionState.Open:
                    break;
                case ConnectionState.Closed:
                    connection.Open();
                    break;
                case ConnectionState.Broken:
                    connection.Dispose();
                    break;
                default:
                    connection.Open();
                    break;
            }

            var dataAdapter = new MySqlDataAdapter(selectQuery, connection);
            using (dataAdapter)
            {
                switch (tableName)
                {
                    case "customer":
                        var customers = new List<Customer>();
                        var customerDataTable = new DataTable();
                        customerDataTable.Columns.Add("customer_id", typeof(int));
                        customerDataTable.Columns.Add("First", typeof(string));
                        customerDataTable.Columns.Add("Last", typeof(string));
                        customerDataTable.Columns.Add("Phone", typeof(string));
                        customerDataTable.Columns.Add("Email", typeof(string));
                        customerDataTable.Columns.Add("Preferred_Office", typeof(int));
                        dataAdapter.Fill(customerDataTable);

                        foreach (DataRow row in customerDataTable.Rows)
                        {
                            var cx = new Customer
                            {
                                customer_id = (int) row["customer_id"],
                                first = row["First"].ToString(),
                                last = row["Last"].ToString(),
                                phone = row["Phone"].ToString(),
                                email = row["Email"].ToString(),
                                preferred_office = Convert.IsDBNull(row["Preferred_Office"])
                                    ? 0
                                    : (int) row["Preferred_Office"]
                            };
                            customers.Add(cx);
                        }

                        dgv.DataSource = customerDataTable;
                        break;

                    case "appointment":
                        var appointments = new List<UnifiedApptData>();
                        var appointmentsDataTable = new DataTable();
                        appointmentsDataTable.Columns.Add("appointment_id", typeof(int));
                        appointmentsDataTable.Columns.Add("customer_id", typeof(int));
                        appointmentsDataTable.Columns.Add("staff_id", typeof(int));
                        appointmentsDataTable.Columns.Add("service_id", typeof(int));
                        appointmentsDataTable.Columns.Add("start", typeof(DateTime));
                        appointmentsDataTable.Columns.Add("end", typeof(DateTime));
                        appointmentsDataTable.Columns.Add("office_id", typeof(int));
                        appointmentsDataTable.Columns.Add("service_address_id", typeof(int));
                        appointmentsDataTable.Columns.Add("inhomeservice", typeof(int));
                        dataAdapter.Fill(appointmentsDataTable);

                        foreach (DataRow row in appointmentsDataTable.Rows)
                        {
                            var uApptData = new UnifiedApptData
                            {
                                appointment_id = (int) row["appointment_id"], // Set the correct property names
                                customer_id = (int) row["customer_id"],
                                staff_id = (int) row["staff_id"],
                                service_id = (int) row["service_id"],
                                start = (DateTime) row["start"],
                                end = (DateTime) row["end"],
                                office_id = (int) row["office_id"],
                                service_address_id = (int) row["service_address_id"],
                                inhomeservice = (sbyte) (int) row["inhomeservice"]
                            };
                            appointments.Add(uApptData);
                        }

                        dgv.DataSource = appointmentsDataTable;
                        break;
                }
            }

            connection.Close();
        }
    }

    #endregion

    public static string WhatIsThisThing(string valueToCheck)
    {
        const char space = ' ';
        const char atSign = '@';
        var result = "default";

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

        if (!valueToCheck.Contains(space)) return result;
        result = "name";
        return result; // If it has a whitespace, treat as a name
    }


    #region SQL

    public static string? AutoIncrementId(string tableName)
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

    //Service
    public static Service? ReturnService(string searchTerm)
    {
        using var connection = new Builder().Connect();
        if (int.TryParse(searchTerm, out var i))
        {
            var iService = connection.Query<Service>("service", e => e.service_id == i).FirstOrDefault();

            return iService;
        }

        var service = connection.Query<Service>("service", e => e.service_name == searchTerm)
            .FirstOrDefault();

        return service;
    }

    public static bool InsertService(Service service)
    {
        using var connection = new Builder().Connect();
        try
        {
            var result = connection.Insert("service", service);
            MessageBox.Show("Service id: " + service.service_id + " created.", "Service Created");
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    public static bool DeleteService(int serviceId)
    {
        using var connection = new Builder().Connect();
        try
        {
            var id = connection.Delete("service", serviceId);
            MessageBox.Show("Service id: " + serviceId + " removed.", "Service Removed");
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    public static bool UpdateService(Service service)
    {
        using var connection = new Builder().Connect();
        try
        {
            {
                var updatedService = connection.Update("service", service);
                MessageBox.Show("Service id: " + service.service_id + " updated.", "Service Updated");
            }
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    //Staff
    public static Staff? ReturnStaff(string searchTerm)
    {
        using var connection = new Builder().Connect();
        const char atSign = '@';
        if (searchTerm.Contains(atSign))
        {
            var eStaff = connection.Query<Staff>("staff", e => e.email == searchTerm).FirstOrDefault();
            if (eStaff == null)
            {
                return null;
            }

            return eStaff;
        }

        var staff = connection.Query<Staff>("staff", e => e.name == searchTerm).FirstOrDefault();
        if (staff == null)
        {
            return null;
        }

        return staff;
    }

    public bool InsertStaff(Staff staff)
    {
        using var connection = new Builder().Connect();
        try
        {
            var id = connection.Insert("staff", staff);
            MessageBox.Show("Staff id " + id + " created.", "Staff Created");
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    public bool DeleteStaff(int staffId)
    {
        using var connection = new Builder().Connect();
        try
        {
            var id = connection.Delete("staff", staffId);
            MessageBox.Show("Staff id " + id + " removed.", "Staff Removed");
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    public bool UpdateStaff(Staff staff)
    {
        using var connection = new Builder().Connect();
        try
        {
            {
                var updatedStaff = connection.Update("staff", staff);
                MessageBox.Show("Staff id " + updatedStaff + " updated.", "Staff Updated");
            }
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    //Customer
    public static bool DoesThisCxExist(Customer cx)
    {
        using var connection = new Builder().Connect();
        var fields = new[]
        {
            new QueryField("first", cx.first),
            new QueryField("last", cx.last),
            new QueryField("phone", cx.phone),
            new QueryField("state", cx.email)
        };

        var result = connection.Exists("customer", fields);
        return result;
    }

    public static Customer? ReturnCustomer(string searchTerm)
    {
        using var connection = new Builder().Connect();
        const char space = ' ';
        const char atSign = '@';

        if (searchTerm.Contains(space))
        {
            var searchTerms = searchTerm.Split(' ', 2);
            var first = searchTerms[0];
            var last = searchTerms[1];
            var sCustomer = connection.Query<Customer>("customer", e => e.first == first && e.last == last)
                .FirstOrDefault();
            if (sCustomer != null)
            {
                return sCustomer;
            }
        }

        if (searchTerm.Contains(atSign))
        {
            var aCustomer = connection.Query<Customer>("customer", e => e.email == searchTerm)
                .FirstOrDefault();
            if (aCustomer != null)
            {
                return aCustomer;
            }
        }

        if (int.TryParse(searchTerm, out var i))
        {
            var iCustomer = connection.Query<Customer>("customer", e => e.customer_id == i)
                .FirstOrDefault();
            if (iCustomer != null)
            {
                return iCustomer;
            }
        }

        return null;
    }

    public static bool InsertCustomer(Customer customer)
    {
        using var connection = new Builder().Connect();
        try
        {
            var id = connection.Insert("customer", customer);
            MessageBox.Show("Customer id " + id + " created.", "Customer Created");
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    public static bool DeleteCustomer(int customerId)
    {
        using var connection = new Builder().Connect();
        try
        {
            var id = connection.Delete("customer", customerId);
            MessageBox.Show("Customer id " + id + " removed.", "Customer Removed");
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    public static bool UpdateCustomer(Customer customer)
    {
        using var connection = new Builder().Connect();
        try
        {
            {
                var updatedCx = connection.Update("customer", customer);
                MessageBox.Show("Customer id " + updatedCx + " updated.", "Customer Updated");
            }
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    //Office
    public static Office? ReturnOffice(string searchTerm)
    {
        using var connection = new Builder().Connect();
        if (int.TryParse(searchTerm, out _))
        {
            var iOffice = connection.Query<Office>("office", e => e.office_id == int.Parse(searchTerm))
                .GetEnumerator().Current;
            return iOffice;
        }

        var nOffice = connection.Query<Office>("office", e => e.office_name.Contains(searchTerm))
            .GetEnumerator().Current;

        return nOffice;
    }

    public bool InsertOffice(Office office)
    {
        using var connection = new Builder().Connect();
        try
        {
            var id = connection.Insert("office", office);
            MessageBox.Show("Office id " + id + " created.", "Office Created");
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    public bool DeleteOffice(int officeId)
    {
        using var connection = new Builder().Connect();
        try
        {
            var id = connection.Delete("office", officeId);
            MessageBox.Show("Office id " + id + " removed.", "Office Removed");
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    public bool UpdateOffice(Office office)
    {
        using var connection = new Builder().Connect();
        try
        {
            {
                var updatedOffice = connection.Update("office", office);
                MessageBox.Show("Office id " + updatedOffice + " updated.", "Office Updated");
            }
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    //Address
    public static bool DoesThisAddressExist(Address addy)
    {
        using var connection = new Builder().Connect();
        var fields = new[]
        {
            new QueryField("address1", addy.address1),
            new QueryField("address2", addy.address2),
            new QueryField("city", addy.city),
            new QueryField("state", addy.state),
            new QueryField("country", addy.country)
        };
        var result = connection.Exists("address", fields);
        return result;
    }

    public static Address? ReturnAddress(string searchTerm)
    {
        using var connection = new Builder().Connect();
        if (int.TryParse(searchTerm, out var i))
        {
            var officeById = connection.Query<Address>("address", e => e.address_id == i).GetEnumerator().Current;
            return officeById;
        }

        var officeByAddress1 = connection.Query<Address>("address", e => e.address1.Contains(searchTerm))
            .GetEnumerator().Current;
        return officeByAddress1 ?? null;
    }

    public static bool InsertAddress(Address address, out int addressId)
    {
        using var connection = new Builder().Connect();
        try
        {
            var id = connection.Insert("address", address);
            MessageBox.Show("Address id " + id + " created.", "Address Created");
            addressId = (int) id;
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            addressId = -1;
            return false;
        }
    }

    public static bool DeleteAddress(int addressId)
    {
        using var connection = new Builder().Connect();
        try
        {
            var id = connection.Delete("address", addressId);
            MessageBox.Show("Address id " + id + " removed.", "Address Removed");
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    public static bool UpdateAddress(Address address)
    {
        using var connection = new Builder().Connect();
        try
        {
            {
                var updatedCx = connection.Update("address", address);
                MessageBox.Show("Address id " + updatedCx + " updated.", "Address Updated");
            }
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    #endregion
}