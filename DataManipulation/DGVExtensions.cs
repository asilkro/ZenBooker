using MySqlConnector;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZenoBook.Classes;

namespace ZenoBook.DataManipulation
{
    public static class DGVExtensions
    {
        public static List<T> dgvRowToList<T>(this DataGridViewSelectedRowCollection rows)
        {
            var list = new List<T>();
            for (int i = 0; i < rows.Count; i++)
                list.Add((T)rows[i].DataBoundItem);
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
                                cx.Preferred_Office = Convert.IsDBNull(row["Preferred_Office"]) ? 0 : (int)row["Preferred_Office"];
                                customers.Add(cx);
                            }
                            dgv.DataSource = customerDataTable;
                            break;

                        case "appointment":
                            var appointments = new List<UnifiedApptData>();
                            DataTable appointmentsDataTable = new DataTable();
                            appointmentsDataTable.Columns.Add("Appointment_Id", typeof(int));
                            appointmentsDataTable.Columns.Add("Customer_Id", typeof(int));
                            appointmentsDataTable.Columns.Add("Staff_Id", typeof(int));
                            appointmentsDataTable.Columns.Add("Service_Id", typeof(int));
                            appointmentsDataTable.Columns.Add("Start", typeof(DateTime));
                            appointmentsDataTable.Columns.Add("End", typeof(DateTime));
                            appointmentsDataTable.Columns.Add("Office_Id", typeof(int));
                            appointmentsDataTable.Columns.Add("Service_Address_Id", typeof(int));
                            appointmentsDataTable.Columns.Add("InHomeService", typeof(bool));
                            dataAdapter.Fill(appointmentsDataTable);

                            foreach (DataRow row in appointmentsDataTable.Rows)
                            {
                                UnifiedApptData uApptData = new UnifiedApptData();
                                uApptData.Appointment_Id = (int)row["Appointment_Id"]; // Set the correct property names
                                uApptData.Customer_Id = (int)row["Customer_Id"];
                                uApptData.Staff_Id = (int)row["Staff_Id"];
                                uApptData.Service_Id = (int)row["Service_Id"];
                                uApptData.Start = (DateTime)row["Start"];
                                uApptData.End = (DateTime)row["End"];
                                uApptData.Office_Id = (int)row["Office_Id"];
                                uApptData.Service_Address_Id = (int)row["Service_Address_Id"];
                                uApptData.InHomeService = (bool)row["InHomeService"];
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
}
