using MySqlConnector;
using RepoDb;
using System.Data;
using ZenoBook.Classes;

namespace ZenoBook.DataManipulation;

public static class DGVExtensions
{
    public static List<T> dgvRowToList<T>(this DataGridViewSelectedRowCollection rows)
    {
        var list = new List<T>();
        for (var i = 0; i < rows.Count; i++)
            list.Add((T) rows[i].DataBoundItem);
        return list;
    }

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


    public static void
        populateDGV(DataGridView dgv, string tableName) //, string? where) //Maybe expand to include clauses?
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
}