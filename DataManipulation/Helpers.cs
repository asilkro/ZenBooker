using System.Data;
using System.Security.Cryptography;
using System.Text;
using log4net;
using Microsoft.VisualBasic;
using MySqlConnector;
using RepoDb;
using RepoDb.Extensions;
using ZenoBook.Classes;

namespace ZenoBook.DataManipulation;

public class Helpers
{
    #region Constants
    private const char space = ' ';
    private const char atSign = '@';
    private const char slash = '/';
    private const char dash = '-';
    private const char semicolon = ';';
    private static readonly string _dropTable = "DROP table";
    #endregion
    
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
        if (!existing) return result;
        result = true;
        connection.Close();
        return result;

    }
    public static string HashedString(string input)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));

        StringBuilder builder = new();
        foreach (var t in bytes)
        {
            builder.Append(t.ToString("x2")); 
            // Format string to match DB; could be changed in future
            // if changes to the hashes in the DB is desired.
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
                                          " WHERE start >= DATE_SUB(CURRENT_TIMESTAMP, INTERVAL 3 DAY) ORDER BY start LIMIT 200;"; //within 3 days as default
                    var apptDataAdapter = new MySqlDataAdapter(apptSelectQuery, connection);
                    using (apptDataAdapter)
                    {
                        var appointments = ApptToDataTable(apptDataAdapter, out var appointmentsDataTable);
                        AddApptToRows(appointmentsDataTable, appointments);
                        dgv.DataSource = appointmentsDataTable;
                    }
                    break;

                case "customer":
                    var cxSelectQuery = "SELECT *, concat_ws(' ', first, last) AS Name FROM " + tableName + " ORDER BY customer_id, Name LIMIT 200;";
                    var cxDataAdapter = new MySqlDataAdapter(cxSelectQuery, connection);
                    using (cxDataAdapter)
                    {
                        var customers = CxToDataTable(cxDataAdapter, out var customerDataTable);
                        AddCxToRows(customerDataTable, customers);
                        dgv.DataSource = customerDataTable;
                    }
                    break;

                case "staff":
                    var staffSelectQuery = "SELECT * FROM " + tableName + " ORDER BY name LIMIT 200;"; //To avoid performance issues
                    var staffDataAdapter = new MySqlDataAdapter(staffSelectQuery, connection);
                    using (staffDataAdapter)
                    {
                        var staff = StaffToDataTable(staffDataAdapter, out var staffDataTable);
                        AddStaffToRows(staffDataTable, staff);
                        dgv.DataSource = staffDataTable;
                    }
                    break;

                case "service":
                    var serviceSelectQuery = "SELECT service_name, service_id, service_description FROM " + tableName + " ORDER BY service_name, service_id LIMIT 200;"; //To avoid performance issues
                    var serviceDataAdapter = new MySqlDataAdapter(serviceSelectQuery, connection);
                    using (serviceDataAdapter)
                    {
                        var services = ServiceToDataTable(serviceDataAdapter, out var serviceDataTable);
                        AddServiceToRows(serviceDataTable, services);
                        dgv.DataSource = serviceDataTable;
                    }
                    break;

                case "office":
                    var officeSelectQuery = "SELECT * FROM " + tableName + " ORDER BY office_name;";
                    var officeDataAdapter = new MySqlDataAdapter(officeSelectQuery, connection);
                    using (officeDataAdapter)
                    {
                        var offices = OfficeToDataTable(officeDataAdapter, out var officeDataTable);
                        AddOfficeToRows(officeDataTable, offices);
                        dgv.DataSource = officeDataTable;
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
                var searchType = WhatIsBeingSearched(searchQuery);
                if (searchType == "default")
                {
                    MessageBox.Show("Invalid search parameter.");
                    tableName = "discard";
                }
                var sql = "";
                MySqlDataAdapter? dataAdapter;
                switch (tableName)
                { 
                    case "appointment":
                    {
                        sql = searchType switch
                        {
                            "datetime" => "SELECT * FROM appointment WHERE DATE(start) like '%@VALUE%' order by start;",
                            "integer" => "SELECT * FROM appointment WHERE customer_id = '@VALUE' order by start;",
                            _ => sql
                        };
                        sql = sql.Replace("@VALUE", searchQuery);
                        dataAdapter = new MySqlDataAdapter(sql, connection);
                        using (dataAdapter)
                        {
                            var appointments = ApptToDataTable(dataAdapter, out var appointmentsDataTable);
                            AddApptToRows(appointmentsDataTable, appointments);
                            dgv.DataSource = appointmentsDataTable;
                        }
                        break;
                    }
                    case "customer":
                    {
                        sql = searchType switch
                        {
                            "email" => "SELECT * FROM customer WHERE email like '@VALUE' order by customer_id;",
                            "integer" => "SELECT * FROM customer WHERE phone like '@VALUE%' order by customer_id;",
                            "name" =>
                                "SELECT *, concat_ws(' ', first, last) AS Name FROM customer HAVING Name LIKE '@VALUE';",
                            _ => sql
                        };
                        sql = sql.Replace("@VALUE", searchQuery);
                        dataAdapter = new MySqlDataAdapter(sql, connection);
                        using (dataAdapter)
                        {
                            var customers = CxToDataTable(dataAdapter, out var customerDataTable);
                            AddCxToRows(customerDataTable, customers);
                            dgv.DataSource = customerDataTable;
                        }

                        break;
                    }
                    case "service":
                    {
                        sql = searchType switch
                        {
                            "name" => "SELECT * FROM service WHERE service_name LIKE '@VALUE%' ORDER BY service_name;",
                            "integer" => "SELECT * FROM service WHERE service_id LIKE '@VALUE';",
                            _ => sql
                        };
                        sql = sql.Replace("@VALUE", searchQuery);
                        dataAdapter = new MySqlDataAdapter(sql, connection);
                        using (dataAdapter)
                        {
                            var services = ServiceToDataTable(dataAdapter, out var serviceDataTable);
                            AddServiceToRows(serviceDataTable, services);
                            dgv.DataSource = serviceDataTable;
                        }

                        break;
                    }
                    case "staff":
                        sql = searchType switch
                        {
                            "email" => "SELECT * FROM staff WHERE email like '@VALUE%';",
                            "name" => "SELECT * FROM staff WHERE name like '@VALUE%';",
                            _ => sql
                        };

                        sql = sql.Replace("@VALUE", searchQuery);
                        dataAdapter = new MySqlDataAdapter(sql, connection);
                        using (dataAdapter)
                        {
                            var staff = StaffToDataTable(dataAdapter, out var staffDataTable);
                            AddStaffToRows(staffDataTable, staff);
                            dgv.DataSource = staffDataTable;
                        }
                        break;
                }
            }
        }
    }
    public static void GenerateApptReportInDgv(DataGridView dgv, string reportParams)
    {
        {
            var connection = Builder.SmartConnect(connection: new Builder().Connect());
            string selectQuery;
            switch (reportParams)
            {

                case "all":
                    selectQuery =
                        "SELECT * FROM appointment ORDER BY start, inhomeservice;"; // Would limit results if this was default behavior
                    break;
                case "today":
                    selectQuery =
                        "SELECT * FROM appointment WHERE DATE(start) = CURDATE() ORDER BY start, inhomeservice;";
                    break;
                case "tomorrow":
                    selectQuery =
                        "SELECT * FROM appointment WHERE DATE(start) = DATE_ADD(CURDATE(), interval 1 day) ORDER BY start, inhomeservice;";
                    break;
                case "week":
                    selectQuery =
                        "SELECT * FROM appointment WHERE YEARWEEK(start, 1) = YEARWEEK(CURDATE(), 1) ORDER BY start, inhomeservice;";
                    break;
                case "month":
                    selectQuery =
                        "SELECT * FROM appointment WHERE MONTH(start) = MONTH(CURDATE()) ORDER BY start, inhomeservice;";
                    break;

                default: // Easiest way to capture specific date
                    selectQuery =
                        "SELECT * FROM appointment WHERE DATE(start) like '@SEARCHVALUE%' ORDER BY start, inhomeservice;";
                    selectQuery = selectQuery.Replace("@SEARCHVALUE", reportParams);
                    break;
            }

            var apptDataAdapter = new MySqlDataAdapter(selectQuery, connection);
            using (apptDataAdapter)
            {
                var appointments = ApptToDataTable(apptDataAdapter, out var appointmentsDataTable);
                AddApptToRows(appointmentsDataTable, appointments);
                dgv.DataSource = appointmentsDataTable;
            }
        }
    }


    private static List<UnifiedApptData> ApptToDataTable(MySqlDataAdapter mySqlDataAdapter,
        out DataTable appointmentsDataTable1)
    {
        var list = new List<UnifiedApptData>();
        appointmentsDataTable1 = new DataTable();
        appointmentsDataTable1.Columns.Add("Appointment_id", typeof(int));
        appointmentsDataTable1.Columns.Add("Customer_id", typeof(int));
        appointmentsDataTable1.Columns.Add("Start", typeof(DateTime));
        appointmentsDataTable1.Columns.Add("End", typeof(DateTime));
        appointmentsDataTable1.Columns.Add("Service_id", typeof(int));
        appointmentsDataTable1.Columns.Add("Staff_id", typeof(int));
        appointmentsDataTable1.Columns.Add("Office_id", typeof(int));
        appointmentsDataTable1.Columns.Add("Service_address_id", typeof(int));
        appointmentsDataTable1.Columns.Add("Inhomeservice", typeof(int));
        mySqlDataAdapter.Fill(appointmentsDataTable1);
        return list;
    }

    private static void AddCxToRows(DataTable customerDataTable, List<Customer> customers)
    {
        customers.AddRange(customerDataTable.Rows.Cast<DataRow>()
            .Select(row => new Customer
            {
                customer_id = (int) row["Customer_Id"],
                first = row["First"].ToString() ?? string.Empty,
                last = row["Last"].ToString() ?? string.Empty,
                phone = row["Phone"].ToString() ?? string.Empty,
                email = row["Email"].ToString() ?? string.Empty,
                preferred_office = Convert.IsDBNull(row["Preferred_Office"]) ? 1 : (int) row["Preferred_Office"]
            }));
    }

    private static List<Customer> CxToDataTable(MySqlDataAdapter dataAdapter, out DataTable customerDataTable)
    {
        List<Customer> customers = new();
        customerDataTable = new DataTable();
        customerDataTable.Columns.Add("Name", typeof(string));
        customerDataTable.Columns.Add("Customer_id", typeof(int));
        customerDataTable.Columns.Add("Phone", typeof(string));
        customerDataTable.Columns.Add("Email", typeof(string));
        customerDataTable.Columns.Add("First", typeof(string));
        customerDataTable.Columns.Add("Last", typeof(string));
        customerDataTable.Columns.Add("Preferred_Office", typeof(int));
        dataAdapter.Fill(customerDataTable);
        return customers;
    }

    private static void AddApptToRows(DataTable dataTable, List<UnifiedApptData> unifiedApptDatas)
    {
        unifiedApptDatas.AddRange(from DataRow row in dataTable.Rows
            select new UnifiedApptData
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
            });
    }

    private static List<Staff> StaffToDataTable(MySqlDataAdapter dataAdapter, out DataTable staffDataTable)
    {
        List<Staff> staff = new();
        staffDataTable = new DataTable();
        //name, staff_id, email, office_id, phone
        staffDataTable.Columns.Add("staff_id", typeof(int));
        staffDataTable.Columns.Add("name", typeof(string));
        staffDataTable.Columns.Add("email", typeof(string));
        staffDataTable.Columns.Add("office_id", typeof(int));
        staffDataTable.Columns.Add("phone", typeof(string));
        staffDataTable.Columns.Add("user_id", typeof(int));
        dataAdapter.Fill(staffDataTable);
        return staff;
    }

    private static void AddStaffToRows(DataTable staffDataTable, List<Staff> staff)
    {
        //name, staff_id, email, office_id, phone
        staff.AddRange(from DataRow row in staffDataTable.Rows select new Staff
            {
                staff_id = (int) row["staff_id"],
                name = row["name"].ToString() ?? string.Empty,
                email = row["email"].ToString() ?? string.Empty,
                office_id = (int) row["office_id"],
                phone = row["phone"].ToString() ?? string.Empty,
                user_id = (int)row["user_id"],

        });
    }
    private static List<Service> ServiceToDataTable(MySqlDataAdapter dataAdapter, out DataTable serviceDataTable)
    {
        var services = new List<Service>();
        serviceDataTable = new DataTable();
        serviceDataTable.Columns.Add("service_id", typeof(int));
        serviceDataTable.Columns.Add("service_name", typeof(string));
        serviceDataTable.Columns.Add("service_description", typeof(string));
        dataAdapter.Fill(serviceDataTable);
        return services;
    }

    private static List<Office> OfficeToDataTable(MySqlDataAdapter dataAdapter, out DataTable officeDataTable)
    {
        var offices = new List<Office>();
        officeDataTable = new DataTable();
        officeDataTable.Columns.Add("office_id", typeof(int));
        officeDataTable.Columns.Add("address_id", typeof(int));
        officeDataTable.Columns.Add("office_name", typeof(string));
        dataAdapter.Fill(officeDataTable);
        return offices;
    }


    private static void AddServiceToRows(DataTable serviceDataTable, List<Service> services)
    {
        services.AddRange(serviceDataTable.Rows.Cast<DataRow>()
            .Select(row => new Service
            {
                service_id = (int) row["service_id"],
                service_name = row["service_name"].ToString() ?? string.Empty,
                service_description = row["service_description"].ToString() ?? string.Empty
            }));
    }

    private static void AddOfficeToRows(DataTable officeDataTable, List<Office> offices)
    {
        offices.AddRange(officeDataTable.Rows.Cast<DataRow>()
            .Select(row => new Office
            {
                office_id = (int)row["office_id"],
                address_id = (int)row["address_id"],
                office_name = row["office_name"].ToString() ?? string.Empty
            }));
    }

    #endregion

    public static string WhatIsBeingSearched(string valueToCheck)
    {
        var containsSlash = valueToCheck.Contains(slash);
        var containsDash = valueToCheck.Contains(dash);
        var chars = valueToCheck.ToCharArray();

        var result = "default";
        if (!NoProhibitedContent(valueToCheck)) return "error"; // Reject bad input

        if (containsDash || containsSlash)
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

        if (!valueToCheck.Contains(space) && !chars.All(char.IsAsciiLetter)) return result;
        result = "name";
        return result; // If it has a whitespace or is all letters, treat as a name
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
            case DialogResult.None:
                break;
            case DialogResult.OK:
                break;
            case DialogResult.Cancel:
                break;
            case DialogResult.Abort:
                break;
            case DialogResult.Retry:
                break;
            case DialogResult.Ignore:
                break;
            case DialogResult.TryAgain:
                break;
            case DialogResult.Continue:
                break;
        }

        return buttonPressed == "Yes";
    }

    public static string GetFromInputBox(string prompt, string title)
    {
        var input = Interaction.InputBox(prompt,
            title,
            null!,
            0,
            0);
        return input;
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
    public static Address? ReturnAddress(string? searchTerm)
    {
        using var connection = new Builder().Connect();
        if (searchTerm == null)
        {
            return null;
        }
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
            MessageBox.Show(deletedCount + " address with Address id " + addressId + " removed.", "Address Removed");
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
                MessageBox.Show(result + "address with Address id " + address.address_id + " updated.", "Address Updated");
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
    public static UnifiedApptData? GetAppointment(int apptId, out UnifiedApptData? appt)
    {
        appt = null;
        using var connection = new Builder().Connect();
        try
        {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var fields = Field.Parse<UnifiedApptData>(e => new
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
                var sql = "SELECT * FROM appointment WHERE appointment_id = @appt_id";
                sql = sql.Replace("@appt_id", apptId.ToString());
                appt = connection.ExecuteQuery<UnifiedApptData>(sql).FirstOrDefault();
                return appt;
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
                var id = connection.Insert(entity: appt,
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
                var count = connection.Update(entity:appt, fields: fields, where: e => e.appointment_id == appt.appointment_id);
                MessageBox.Show(count + " appointment with Id: " + appt.appointment_id + " updated.", "Appointment Updated");
            }
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    public static bool RawAppointmentInsert(UnifiedApptData appt)
    {

        var connection = Builder.SmartConnect(new Builder().Connect());
        using (connection)
        {
            var cmd = new MySqlCommand("", connection)
            {
                CommandText = "INSERT INTO appointment (`customer_id`,`staff_id`,`office_id`,`service_id`,`start`,`end`,`inhomeservice`,`service_address_id`) " +
                              "VALUES (@cxId, @staffId, @officeId, @svcId, @start, @end, @inhomesvc, @svcAddressId);"
            };
            cmd.Parameters.AddWithValue("@cxId", appt.customer_id);
            cmd.Parameters.AddWithValue("@staffId", appt.staff_id);
            cmd.Parameters.AddWithValue("@officeId", appt.office_id);
            cmd.Parameters.AddWithValue("@svcId", appt.service_id);
            cmd.Parameters.AddWithValue("@start", appt.start.ToString("yyyy-MM-dd H:mm:ss"));
            cmd.Parameters.AddWithValue("@end", appt.end.ToString("yyyy-MM-dd H:mm:ss"));
            cmd.Parameters.AddWithValue("@inhomesvc", appt.inhomeservice);
            cmd.Parameters.AddWithValue("@svcAddressId", appt.service_address_id);

            var success = cmd.ExecuteNonQuery() == 1;
            return success;
        }
    }

    public static bool RawAppointmentUpdate(UnifiedApptData appt)
    {

        var connection = Builder.SmartConnect(new Builder().Connect());
        using (connection)
        {
            var cmd = new MySqlCommand("", connection)
            {
                CommandText = "UPDATE appointment SET customer_id=@cxId, staff_id=@staffId, office_id=@officeId, service_id=@svcId, start=@start, end=@end, inhomeservice=@inhomesvc, service_address_id=@svcAddressId WHERE appointment_id=@apptId"
            };
            cmd.Parameters.AddWithValue("@cxId", appt.customer_id);
            cmd.Parameters.AddWithValue("@staffId", appt.staff_id);
            cmd.Parameters.AddWithValue("@officeId", appt.office_id);
            cmd.Parameters.AddWithValue("@svcId", appt.service_id);
            cmd.Parameters.AddWithValue("@start", appt.start.ToString("yyyy-MM-dd H:mm:ss"));
            cmd.Parameters.AddWithValue("@end", appt.end.ToString("yyyy-MM-dd H:mm:ss"));
            cmd.Parameters.AddWithValue("@inhomesvc", appt.inhomeservice);
            cmd.Parameters.AddWithValue("@svcAddressId", appt.service_address_id);
            cmd.Parameters.AddWithValue("@apptId", appt.appointment_id);

            var success = cmd.ExecuteNonQuery() == 1;
            return success;
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
            office_id = 1, // Home appt has no office ID but
                           // needs a value due to normalization constraints
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
        var serviceAddressId = ReturnAddress(appt.office_id.ToString())
                               != null ? appt.office_id : 1;
        // Use HQ as the service address to catch error

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
            service_address_id = serviceAddressId,
        };

        return convertedAppt;
    }
    #endregion

    #region Minimal Controls

    public static bool NoProhibitedContent(string content)
    {
        var result = true;

        if (!content.Contains(_dropTable) && !content.Contains(semicolon)) return result;
        result = false;
        MessageBox.Show("This entry is not permitted, please check your input and try again.", "Prohibited Operation");
        return result;
    }

    #endregion
}