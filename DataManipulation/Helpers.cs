using log4net;
using MySqlConnector;
using RepoDb;
using System.Data;
using System.Windows;
using System.Security.Cryptography;
using System.Text;
using ZenoBook.Classes;
using System;
using System.Data.Common;

namespace ZenoBook.DataManipulation;

public class Helpers
{
    #region Login Related
    public static bool ValidateLogin(string login, string password)
    {
        var result = false;
        using var connection = new Builder().Connect();
        if (connection.State == ConnectionState.Open) return result;
        connection.Open();
        var fields = new[]
        {
            new QueryField("login", login),
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
    public static bool DoTheyMatch(string one, string two)
    {
        var result = HashedString(one) == HashedString(two);
        return result;
    }
    #endregion

    #region DataGridView

    public static void PopulateDgv(DataGridView dgv, string tableName)
    {
        {
            var connection = Builder.SmartConnect(connection: new Builder().Connect());
            switch (tableName)
            {
                case "appointment":
                    var apptSelectQuery = "SELECT * FROM " + tableName +
                                          " WHERE start >= DATE_SUB(CURRENT_TIMESTAMP, INTERVAL 1 DAY) ORDER BY start LIMIT 200;";
                    var apptDataAdapter = new MySqlDataAdapter(apptSelectQuery, connection);
                    using (apptDataAdapter)
                    {
                        var appointments = apptToDataTable(apptDataAdapter, out var appointmentsDataTable);
                        addApptToRows(appointmentsDataTable, appointments);
                        dgv.DataSource = appointmentsDataTable;
                    }
                    break;

                case "customer":
                    var cxSelectQuery = "SELECT * FROM " + tableName + " ORDER BY last, first, customer_id LIMIT 200;";
                    var cxDataAdapter = new MySqlDataAdapter(cxSelectQuery, connection);
                    using (cxDataAdapter)
                    {
                        var customers = cxToDataTable(cxDataAdapter, out var customerDataTable);
                        addCxToRows(customerDataTable, customers);
                        dgv.DataSource = customerDataTable;
                    }
                    break;

                case "staff":
                    var staffSelectQuery = "SELECT * FROM " + tableName + " ORDER BY name, staff_id LIMIT 200;";
                    var staffDataAdapter = new MySqlDataAdapter(staffSelectQuery, connection);
                    using (staffDataAdapter)
                    {
                        var staff = staffToDataTable(staffDataAdapter, out var staffDataTable);
                        addStaffToRows(staffDataTable, staff);
                        dgv.DataSource = staffDataTable;
                    }
                    break;

                case "service":
                    var serviceSelectQuery = "SELECT * FROM " + tableName + " ORDER BY name, service_id LIMIT 200;";
                    var serviceDataAdapter = new MySqlDataAdapter(serviceSelectQuery, connection);
                    using (serviceDataAdapter)
                    {
                        var services = serviceToDataTable(serviceDataAdapter, out var serviceDataTable);
                        addServiceToRows(serviceDataTable, services);
                        dgv.DataSource = serviceDataTable;
                    }
                    break;
            }
        }
    }

    public static void SearchDgv(DataGridView dgv, string tableName, string searchQuery)
    {
        {
            using var connection = new Builder().Connect();

            {
                var searchType = WhatIsThisThing(searchQuery);
                if (searchType == "default")
                {
                    MessageBox.Show("Invalid search parameter.");
                    tableName = "discard";
                }

                switch (tableName)
                {
                    case "appointment":
                    {
                        if (searchType == "datetime")
                        {
                            var sql = "SELECT * FROM appointment WHERE start like '%@VALUE%';";
                            sql = sql.Replace("@VALUE", searchQuery);
                            var dataAdapter = new MySqlDataAdapter(sql, connection);
                            using (dataAdapter)
                            {
                                var appointments = apptToDataTable(dataAdapter, out var appointmentsDataTable);
                                addApptToRows(appointmentsDataTable, appointments);
                                dgv.DataSource = appointmentsDataTable;
                            }
                        }

                        if (searchType == "integer")
                        {
                            var sql = "SELECT * FROM appointment WHERE customer_id like '@VALUE' order by start;";
                            sql = sql.Replace("@VALUE", searchQuery);
                            var dataAdapter = new MySqlDataAdapter(sql, connection);
                            using (dataAdapter)
                            {
                                var appointments = apptToDataTable(dataAdapter, out var appointmentsDataTable);
                                addApptToRows(appointmentsDataTable, appointments);
                                dgv.DataSource = appointmentsDataTable;
                            }
                        }

                        break;
                    }
                    case "customer":
                    {
                        if (searchType == "email")
                        {
                            var sql = "SELECT * FROM customer WHERE email like '@VALUE%';";
                            sql = sql.Replace("@VALUE", searchQuery);
                            var dataAdapter = new MySqlDataAdapter(sql, connection);
                            using (dataAdapter)
                            {
                                var customers = cxToDataTable(dataAdapter, out var customerDataTable);
                                addCxToRows(customerDataTable, customers);
                                dgv.DataSource = customerDataTable;
                            }
                        }

                        if (searchType == "integer")
                        {
                            var sql = "SELECT * FROM customer WHERE phone like '@VALUE%';";
                            sql = sql.Replace("@VALUE", searchQuery);
                            var dataAdapter = new MySqlDataAdapter(sql, connection);
                            using (dataAdapter)
                            {
                                var customers = cxToDataTable(dataAdapter, out var customerDataTable);
                                addCxToRows(customerDataTable, customers);
                                dgv.DataSource = customerDataTable;
                            }
                        }

                        if (searchType == "name")
                        {
                            var sql =
                                "SELECT *, concat_ws(' ', first, last) AS Name FROM customer HAVING Name LIKE '@VALUE%';";
                            sql = sql.Replace("@VALUE", searchQuery);
                            var dataAdapter = new MySqlDataAdapter(sql, connection);
                                using (dataAdapter)
                            {
                                var customers = cxToDataTable(dataAdapter, out var customerDataTable);
                                addCxToRows(customerDataTable, customers);
                                dgv.DataSource = customerDataTable;
                            }
                        }

                        break;
                    }
                    case "service":
                    {
                        if (searchType == "name")
                        {
                            var sql = "SELECT * FROM service WHERE service_name LIKE '@VALUE%';";
                            sql = sql.Replace("@VALUE", searchQuery);
                            var dataAdapter = new MySqlDataAdapter(sql, connection);
                            using (dataAdapter)
                            {
                                var services = serviceToDataTable(dataAdapter, out var serviceDataTable);
                                addServiceToRows(serviceDataTable, services);
                                dgv.DataSource = serviceDataTable;
                            }
                        }

                        if (searchType == "integer")
                        {
                            var sql = "SELECT * FROM service WHERE service_id LIKE '@VALUE%';";
                            sql = sql.Replace("@VALUE", searchQuery);
                            var dataAdapter = new MySqlDataAdapter(sql, connection);
                            using (dataAdapter)
                            {
                                var services = serviceToDataTable(dataAdapter, out var serviceDataTable);
                                addServiceToRows(serviceDataTable, services);
                                dgv.DataSource = serviceDataTable;
                            }
                        }

                        break;
                    }
                    case "staff":
                        if (searchType == "email")
                        {
                            var sql = "SELECT * FROM 'staff' WHERE CONTAINS(email,'@VALUE');";
                            sql = sql.Replace("@VALUE", searchQuery);
                            var dataAdapter = new MySqlDataAdapter(sql, connection);
                            using (dataAdapter)
                            {
                                var staff = staffToDataTable(dataAdapter, out var staffDataTable);
                                addStaffToRows(staffDataTable, staff);
                                dgv.DataSource = staffDataTable;
                            }
                        }

                        if (searchType == "name")
                        {
                            var sql = "SELECT * FROM 'staff' WHERE CONTAINS(name,'@VALUE');";
                            sql = sql.Replace("@VALUE", searchQuery);
                            var dataAdapter = new MySqlDataAdapter(sql, connection);
                            using (dataAdapter)
                            {
                                var staff = staffToDataTable(dataAdapter, out var staffDataTable);
                                addStaffToRows(staffDataTable, staff);
                                dgv.DataSource = staffDataTable;
                            }
                        }

                        break;
                }
            }
        }
    }
    private static List<UnifiedApptData> apptToDataTable(MySqlDataAdapter mySqlDataAdapter,
    out DataTable appointmentsDataTable1) 
    {
    var list = new List<UnifiedApptData>();
    appointmentsDataTable1 = new DataTable();
    appointmentsDataTable1.Columns.Add("appointment_id", typeof(int));
    appointmentsDataTable1.Columns.Add("customer_id", typeof(int));
    appointmentsDataTable1.Columns.Add("staff_id", typeof(int));
    appointmentsDataTable1.Columns.Add("service_id", typeof(int));
    appointmentsDataTable1.Columns.Add("start", typeof(DateTime));
    appointmentsDataTable1.Columns.Add("end", typeof(DateTime));
    appointmentsDataTable1.Columns.Add("office_id", typeof(int));
    appointmentsDataTable1.Columns.Add("service_address_id", typeof(int));
    appointmentsDataTable1.Columns.Add("inhomeservice", typeof(int));
    mySqlDataAdapter.Fill(appointmentsDataTable1);
    return list;
} 
    private static void addCxToRows(DataTable customerDataTable, List<Customer> customers)
{
    foreach (DataRow row in customerDataTable.Rows)
    {
        var cx = new Customer
        {
            customer_id = (int)row["customer_id"],
            first = row["first"].ToString(),
            last = row["last"].ToString(),
            phone = row["phone"].ToString(),
            email = row["email"].ToString(),
            preferred_office = Convert.IsDBNull(row["preferred_office"])
                ? 0
                : (int)row["preferred_office"]
        };
        customers.Add(cx);
    }
} 
    private static List<Customer> cxToDataTable(MySqlDataAdapter dataAdapter, out DataTable customerDataTable)
{
    List<Customer> customers;
    customers = new List<Customer>();
    customerDataTable = new DataTable();
    customerDataTable.Columns.Add("customer_id", typeof(int));
    customerDataTable.Columns.Add("first", typeof(string));
    customerDataTable.Columns.Add("last", typeof(string));
    customerDataTable.Columns.Add("phone", typeof(string));
    customerDataTable.Columns.Add("email", typeof(string));
    customerDataTable.Columns.Add("preferred_office", typeof(int));
    dataAdapter.Fill(customerDataTable);
    return customers;
} 
    private static void addApptToRows(DataTable dataTable, List<UnifiedApptData> unifiedApptDatas)
{
    foreach (DataRow row in dataTable.Rows)
    {
        
        var uApptData = new UnifiedApptData
        {
            appointment_id = (int)row["appointment_id"], // Set the correct property names
            customer_id = (int)row["customer_id"],
            staff_id = (int)row["staff_id"],
            service_id = (int)row["service_id"],
            start = (DateTime)row["start"],
            end = (DateTime)row["end"],
            office_id = (int)row["office_id"],
            service_address_id = (int)row["service_address_id"],
            inhomeservice = (sbyte)(int)row["inhomeservice"]
        };
        unifiedApptDatas.Add(uApptData);
    }
}
    private static List<Staff> staffToDataTable(MySqlDataAdapter dataAdapter, out DataTable staffDataTable)
{
    var staffList = new List<Staff>();
    staffDataTable = new DataTable();
    staffDataTable.Columns.Add("staff_id", typeof(int));
    staffDataTable.Columns.Add("user_id", typeof(int));
    staffDataTable.Columns.Add("office_id", typeof(int));
    staffDataTable.Columns.Add("name", typeof(string));
    staffDataTable.Columns.Add("phone", typeof(string));
    staffDataTable.Columns.Add("email", typeof(string));
    dataAdapter.Fill(staffDataTable);

    addStaffToRows(staffDataTable, staffList);
    return staffList;
}
    private static void addStaffToRows(DataTable staffDataTable, List<Staff> staffList)
{
    foreach (DataRow row in staffDataTable.Rows)
    {
        var staff = new Staff
        {
            staff_id = (int) row["staff_id"],
            user_id = (int) row["user_id"],
            office_id = (int) row["office_id"],
            name = row["name"].ToString(),
            phone = row["phone"].ToString(),
            email = row["email"].ToString()
        };
        staffList.Add(staff);
    }
}
    private static List<Service> serviceToDataTable(MySqlDataAdapter dataAdapter, out DataTable serviceDataTable)
{
    var services = new List<Service>();
    serviceDataTable = new DataTable();
    serviceDataTable.Columns.Add("service_id", typeof(int));
    serviceDataTable.Columns.Add("service_name", typeof(string));
    serviceDataTable.Columns.Add("service_description", typeof(string));
    dataAdapter.Fill(serviceDataTable);
    return services;
}
    private static void addServiceToRows(DataTable serviceDataTable, List<Service> services)
{
    foreach (DataRow row in serviceDataTable.Rows)
    {
        var svc = new Service
        {
            service_id = (int) row["service_id"],
            service_name = row["service_name"].ToString(),
            service_description = row["service_description"].ToString()
        };
        services.Add(svc);
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
            result = "datetime";
            return result; // If it parses as a date, treat as date
        }

        if (int.TryParse(valueToCheck, out _))
        {
            result = "integer";
            return result; // If it parses as a number, treat as an ID
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
    public static Address MakeAddress(string address1, string address2, string city, string state, string country)
    {
        var tempAddy = new Address
        {
            address1 = address1,
            address2 = address2,
            city = city,
            state = state,
            country = country
        };
        return tempAddy;
    }

    public static bool RawAddressInsert(UnifiedApptData appt)
    {
        
        var connection = Builder.SmartConnect(new Builder().Connect());
        using(connection)
        {
            var success = false;
            var cmd = new MySqlCommand("",connection);
            //cmd.CommandText = cmd.CommandText = "INSERT INTO appointment (`appointment_id`,`customer_id`,`staff_id`,`office_id`,`service_id`,`start`,`end`,`inhomeservice`,`service_address_id`) " + "VALUES (<{ appointment_id: }>, @cxId, @staffId, @officeId, @svcId, @start, @end, @inhomesvc, @svcAddressId);";
            cmd.CommandText = "INSERT INTO appointment (`customer_id`,`staff_id`,`office_id`,`service_id`,`start`,`end`,`inhomeservice`,`service_address_id`) " +
                              "VALUES (@cxId, @staffId, @officeId, @svcId, @start, @end, @inhomesvc, @svcAddressId);";
            cmd.Parameters.AddWithValue("@cxId", appt.customer_id);
            cmd.Parameters.AddWithValue("@staffId", appt.staff_id);
            cmd.Parameters.AddWithValue("@officeId", appt.office_id);
            cmd.Parameters.AddWithValue("@svcId", appt.service_id);
            cmd.Parameters.AddWithValue("@start", appt.start.ToString("yyyy-MM-dd H:mm:ss"));
            cmd.Parameters.AddWithValue("@end", appt.end.ToString("yyyy-MM-dd H:mm:ss"));
            cmd.Parameters.AddWithValue("@inhomesvc", appt.inhomeservice);
            cmd.Parameters.AddWithValue("@svcAddressId", appt.service_address_id);

            if (cmd.ExecuteNonQuery() == 1)
            {
                success = true;
                MessageBox.Show("Should have worked?", "DEBUG: SUCCESS");
            }
            else
            {
                success = false;
                MessageBox.Show("Did not work", "DEBUG: FAILURE");
            }
            return success;
        }
    }

    public static bool ConfirmedAction()
    {
        var buttonPressed = "No";
        DialogResult confirmResult = MessageBox.Show("Click yes to confirm your action.", "Confirmation Required", MessageBoxButtons.YesNo,MessageBoxIcon.None,MessageBoxDefaultButton.Button2);
        switch (confirmResult)
        {
            case DialogResult.Yes:
                buttonPressed = "Yes";
                break;
            case DialogResult.No:
                buttonPressed = "No";
                MessageBox.Show("Aborting action.");
                break;
        }

        if (buttonPressed == "Yes")
        {
            return true;
        }
        return false;
    }

    #region SQL - Misc
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
    public static bool PasswordUpdated(string userName, string maskedPassword)
    {
        using var connection = new Builder().Connect();
        var param = new
        {
            login = userName,
            password = maskedPassword
        };
        try
        {
            var commandText = "UPDATE password = @password FROM user WHERE ([login] = @login);";
            var affectedRows = connection.ExecuteNonQuery(commandText, param);
            if (affectedRows > 0)
            {
                return true;
            }
            return false;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }
    #endregion

    #region SQL - Service
    public static bool DoesThisServiceExist(Service svc)
    {
        using var connection = new Builder().Connect();
        var fields = new[]
        {
            new QueryField("service_name", svc.service_name),
            new QueryField("service_description", svc.service_description)
        };

        var result = connection.Exists("service", fields);
        return result;
    }
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
    #endregion

    #region SQL - Staff
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

        if (int.TryParse(searchTerm, out int i))
        {
            var eStaff = connection.Query<Staff>("staff", e => e.staff_id == i).FirstOrDefault();
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
    public static bool InsertStaff(Staff staff)
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
    public static bool DeleteStaff(int staffId)
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
    public static bool UpdateStaff(Staff staff)
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
    #endregion

    #region SQL - Customer
    public static bool DoesThisCxExist(Customer cx)
    {
        using var connection = new Builder().Connect();
        var fields = new[]
        {
            new QueryField("customer_id", cx.customer_id)
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
            connection.Delete("customer", customerId);
            MessageBox.Show("Customer id " + customerId + " removed.", "Customer Removed");
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
                connection.Update("customer", customer);
                MessageBox.Show("Customer id " + customer.customer_id + " updated.", "Customer Updated");
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

    #region SQL - Office
    public static Office? ReturnOffice(string searchTerm)
    {
        using var connection = new Builder().Connect();
        if (int.TryParse(searchTerm, out int i))
        {
            var iOffice = connection.Query<Office>("office", e => e.office_id == i)
                .FirstOrDefault();
            return iOffice;
        }

        var nOffice = connection.Query<Office>("office", e => e.office_name.Contains(searchTerm))
            .FirstOrDefault();
        return nOffice;
    }
    public static bool InsertOffice(Office office)
    {
        using var connection = new Builder().Connect();
        try
        {
            var id = connection.Insert("office", office);
            MessageBox.Show("Office" + " created.", "Office Created");
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }
    public static bool DeleteOffice(int officeId)
    {
        using var connection = new Builder().Connect();
        try
        {
            var id = connection.Delete("office", officeId);
            MessageBox.Show("Office id " + officeId + " removed.", "Office Removed");
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }
    public static bool UpdateOffice(Office office)
    {
        using var connection = new Builder().Connect();
        try
        {
            {
                var updatedOffice = connection.Update("office", office);
                MessageBox.Show("Office id " + office.office_id + " updated.", "Office Updated");
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

    #region SQL - Address
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
            var officeById = connection.Query<Address>("address", e => e.address_id == i).FirstOrDefault();
            return officeById;
        }

        var officeByAddress1 = connection.Query<Address>("address", e => e.address1.Contains(searchTerm))
            .FirstOrDefault();
        return officeByAddress1 ?? null;
    }
    public static bool InsertAddress(Address address, out int addressId)
    {
        using var connection = new Builder().Connect();
        try
        {
            var id = connection.Insert("address", address);
            MessageBox.Show("Address id " + id + " created.", "Address Created");
            addressId = (int)id;
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
            var deletedCount = connection.Delete("address", addressId);
            MessageBox.Show("Address id " + addressId + " removed.", "Address Removed");
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
                var result = connection.Update("address", address);
                MessageBox.Show("Address id " + address.address_id + " updated.", "Address Updated");
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

    #region SQL - Appt
    public static UnifiedApptData? GetAppointment(int apptId)
    {
        using var connection = new Builder().Connect();
        try
        {
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                Field.Parse<UnifiedApptData>(e => new
                {
                    e.appointment_id,
                    e.customer_id,
                    e.staff_id,
                    e.office_id,
                    e.service_id,
                    e.start,
                    e.end,
                    e.inhomeservice,
                    e.service_address_id
                });
                var appt = connection
                    .ExecuteQuery<UnifiedApptData>(
                        "SELECT * FROM appointment WHERE (appointment_id = @appointment_id);",
                        new { appointment_id = apptId }).FirstOrDefault();
                connection.Close();
                return appt;
            }
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return null;
        }
    }
    public static bool ApptExists(UnifiedApptData appt)
    {
        using var connection = new Builder().Connect();
        var result = connection.Exists("appointment", appt.appointment_id);
        return result;
    }
    public static bool RemoveAppointment(int apptId)
    {
        using var connection = new Builder().Connect();
        try
        {
            {
                connection.Delete("appointment", apptId);
                MessageBox.Show("Appt id " + apptId + " removed.", "Appointment Removed");
                return true;
            }
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }
    public static bool InsertAppt(UnifiedApptData appt)
    {
        using var connection = new Builder().Connect();
        var fields = Field.Parse<UnifiedApptData>(e => new
        {
            appt.appointment_id,
            appt.customer_id,
            appt.staff_id,
            appt.office_id,
            appt.service_id,
            appt.start,
            appt.end,
            appt.inhomeservice,
            appt.service_address_id
        });
        try
        {
            {
                var id = connection.Insert<UnifiedApptData>(entity: appt,
                    fields: fields,tableName:"appointment");
                MessageBox.Show("Appointment with Id: " + appt.appointment_id + " created.", "Appointment Created");
            }
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }
    public static bool UpdateAppt(UnifiedApptData appt)
    {
        using var connection = new Builder().Connect();
        
        var fields = Field.Parse<UnifiedApptData>(e => new
        {
            appt.appointment_id,
            appt.customer_id,
            appt.staff_id,
            appt.office_id,
            appt.service_id,
            appt.start,
            appt.end,
            appt.inhomeservice,
            appt.service_address_id
        });
        try
        {
            {
                var apptId = connection.Update<UnifiedApptData>(entity:appt, fields: fields, where: e => e.appointment_id == appt.appointment_id);
                MessageBox.Show("Appointment with Id: " + appt.appointment_id + " updated.", "Appointment Updated");
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

    #region Conversions
    public static string DateTimeAsString(DateTime value)
    {
        return value.ToString("yyyy/MM/dd HH:mm:ss:ffff");
    }


    public static UnifiedApptData HomeToUnified(HomeAppointment appt)
    {
        var convertedAppt = new UnifiedApptData
        {
            appointment_id = appt.appointment_id,
            customer_id = appt.customer_id,
            staff_id = appt.staff_id,
            office_id = 0, // Home appt has no office ID
            service_id = appt.service_id,
            start = appt.start,
            end = appt.end,
            inhomeservice = 1,
            service_address_id = appt.service_address_id
        };

        return convertedAppt;
    }

    public static UnifiedApptData OfficeToUnified(OfficeAppointment appt)
    {
        var convertedAppt = new UnifiedApptData
        {
            appointment_id = appt.appointment_id,
            customer_id = appt.customer_id,
            staff_id = appt.staff_id,
            office_id = appt.office_id,
            service_id = appt.service_id,
            start = appt.start,
            end = appt.end,
            inhomeservice = 0, // Corresponds to binary
            service_address_id = ReturnAddress(appt.office_id.ToString())?.address_id
        };

        return convertedAppt;
    }
    #endregion

}