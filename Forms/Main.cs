using System;
using System.Data;
using MySqlConnector;
using RepoDb;
using RepoDb.Extensions;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class Main : Form
{
    public Main()
    {
        InitializeComponent();
        populateDGV(apptsDataGridView, "appointment");
        populateDGV(cxDataGridView, "customer");
    }

    public static void populateDGV(DataGridView dgv, string tableName) //, string? where) //Maybe expand to include clauses?
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
                        DataTable customerDataTable = new DataTable();
                        customerDataTable.Columns.Add("Customer_Id", typeof(int));
                        customerDataTable.Columns.Add("First", typeof(string));
                        customerDataTable.Columns.Add("Last", typeof(string));
                        customerDataTable.Columns.Add("Phone", typeof(string));
                        customerDataTable.Columns.Add("Email", typeof(string));
                        customerDataTable.Columns.Add("Preferred_Office", typeof(int));
                        dataAdapter.Fill(customerDataTable);

                        foreach (DataRow row in customerDataTable.Rows)
                        {
                            Customer cx = new Customer();
                            cx.Customer_Id = (int)row["Customer_Id"];
                            cx.First = row["First"].ToString();
                            cx.Last = row["Last"].ToString();
                            cx.Phone = row["Phone"].ToString();
                            cx.Email = row["Email"].ToString();
                            cx.Preferred_Office = Convert.IsDBNull(row["Preferred_Office"])? 0 : (int)row["Preferred_Office"];
                            customers.Add(cx);
                        }
                        dgv.DataSource = customerDataTable;
                        break;

                    case "appointment":
                        var appointments = new List<Appointment>();
                        DataTable appointmentsDataTable = new DataTable();
                        appointmentsDataTable.Columns.Add("Appointment_Id", typeof(int));
                        appointmentsDataTable.Columns.Add("Customer_Id", typeof(int));
                        appointmentsDataTable.Columns.Add("Staff_Id", typeof(int));
                        appointmentsDataTable.Columns.Add("Service_Id", typeof(int));
                        appointmentsDataTable.Columns.Add("Start", typeof(DateTime));
                        appointmentsDataTable.Columns.Add("End", typeof(DateTime));
                        dataAdapter.Fill(appointmentsDataTable);

                        foreach (DataRow row in appointmentsDataTable.Rows)
                        {
                            Appointment appt = new Appointment();
                            appt.Appointment_Id = (int)row["Appointment_Id"]; // Set the correct property names
                            appt.Customer_Id = (int)row["Customer_Id"];
                            appt.Staff_Id = (int)row["Staff_Id"];
                            appt.Service_Id = (int)row["Service_Id"];
                            appt.Start = Appointment.CheckDbNull(row["Start"]);
                            appt.End = Appointment.CheckDbNull(row["End"]);
                            appointments.Add(appt);
                        }
                        dgv.DataSource = appointmentsDataTable;
                        break;
                }
            }


            connection.Close();
        }
    }
    public static void searchDGV(DataGridView dgv, string tableName, string searchQuery)
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

                if (tableName == "appointment")
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
                }

                if (tableName == "customer")
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
                }

                if (tableName == "service")
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
                }
            }
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

        if (Int64.TryParse(valueToCheck, out _))
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

    #region Event Handlers

    private void logoutBtn_Click(object sender, EventArgs e)
    {
        var newLogin = new Login();
        newLogin.ShowDialog();
        this.Close();
    }

    private void CreateApptBtn_Click(object sender, EventArgs e)
    {
        var apptForm = new FormAppointment();
        apptForm.ShowDialog();
    }

    private void UpdateApptBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = apptsDataGridView.CurrentRow;
        if (selectedRow != null)
        {
            var row = apptsDataGridView.Rows.IndexOf(selectedRow);
            var selected = (int) apptsDataGridView["appointment_id", row].Value;
            using (var connection = new Builder().Connect())
            {
                var uAppt = UnifiedApptData.GetAppointment(selected);
                switch (uAppt.Office_Id != 0 && !uAppt.InHomeService)
                {
                    case true:
                        //This should be the case for a OfficeAppt
                        OfficeAppointment officeAppt = new OfficeAppointment()
                        {
                            Appointment_Id = uAppt.Appointment_Id,
                            Customer_Id = uAppt.Customer_Id,
                            Staff_Id = uAppt.Staff_Id,
                            Office_Id = uAppt.Office_Id,
                            Service_Id = uAppt.Service_Id,
                            Start = uAppt.Start,
                            End = uAppt.End,
                            InHomeService = false,
                        };
                        var apptOForm = new FormAppointment(officeAppt);
                        var officeForm = new FormOfficeAppt(officeAppt);
                        apptOForm.ShowDialog();
                        officeForm.ShowDialog();
                        break;
                    case false:
                        HomeAppointment homeAppt = new HomeAppointment()
                        {
                            Appointment_Id = uAppt.Appointment_Id,
                            Customer_Id = uAppt.Customer_Id,
                            Staff_Id = uAppt.Staff_Id,
                            Service_Id = uAppt.Service_Id,
                            Start = uAppt.Start,
                            End = uAppt.End,
                            Service_Address_Id = uAppt.Service_Address_Id,
                            InHomeService = true,
                        };
                        var apptHForm = new FormAppointment(homeAppt);
                        var homeForm = new FormHomeAppt(homeAppt);
                        apptHForm.ShowDialog();
                        homeForm.ShowDialog();
                        break;
                }
            }
        }
    }

    private void RemoveApptBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = apptsDataGridView.CurrentRow;
        if (selectedRow != null)
        {
            var row = apptsDataGridView.Rows.IndexOf(selectedRow);
            var selected = (int)apptsDataGridView["appointment_id", row].Value;
            if (selected != null)
            {
                var result = Helpers.WhatKindOfAppt(selected);
                switch (result)
                {
                    case "HomeAppointment":
                        if (HomeAppointment.RemoveHomeAppt(selected))
                        {
                            populateDGV(apptsDataGridView, "appointment");
                        }
                        break;
                    case "OfficeAppointment":
                        if (OfficeAppointment.RemoveOfficeAppt(selected))
                        {
                            populateDGV(apptsDataGridView, "appointment");
                        }
                        break;
                }
            }
            
        }
    }

    private void CxCreateBtn_Click(object sender, EventArgs e)
    {
        var cxForm = new FormCustomer();
        cxForm.ShowDialog();
    }

    private void UpdateCxBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = cxDataGridView.CurrentRow;
        if (selectedRow != null)
        {
            var row = cxDataGridView.Rows.IndexOf(selectedRow);
            var selected = (int)cxDataGridView["customer_id", row].Value;
            {
                using (var connection = new Builder().Connect())
                {
                    var customer = connection.Query<Customer>("customer", selected).FirstOrDefault();
                    if (customer != null)
                    {
                        var cxForm = new FormCustomer(customer);
                        cxForm.ShowDialog();
                    }
                }
            }
        }
    }

    private void RemoveCxBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = cxDataGridView.CurrentRow;
        var row = cxDataGridView.Rows.IndexOf(selectedRow);
        int selected = (int)cxDataGridView["customer_id", row].Value;
        if (selected != null)
        {
            var result = Customer.DeleteCustomer(selected);
            if (result)
            {
                populateDGV(cxDataGridView, "customer");
            }
        }

        #endregion
    }

    private void apptSearchBtn_Click(object sender, EventArgs e)
    {
        searchDGV(apptsDataGridView, "appointment", apptSearchTB.Text);
    }

    private void cxSearchBtn_Click(object sender, EventArgs e)
    {
        searchDGV(cxDataGridView, "customer", cxSearchTB.Text);
    }
}