using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using RepoDb;
using RepoDb.Extensions;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ZenoBook.Forms;

public partial class Main : Form
{
    public Main()
    {
        InitializeComponent();
        populateDGV(apptsDataGridView, "appointment");
        populateDGV(cxDataGridView, "customer");
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
           var workingDataTable = new DataTable();
           var dataAdapter = new MySqlDataAdapter(selectQuery, connection);
            dataAdapter.Fill(workingDataTable);
            var bSource = new BindingSource();
            bSource.DataSource = workingDataTable;
            dgv.DataSource = bSource;
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
        newLogin.Activate();
        Close();
    }

    private void CreateApptBtn_Click(object sender, EventArgs e)
    {
        var apptForm = new FormAppointment();
        apptForm.ShowDialog();
    }

    private void UpdateApptBtn_Click(object sender, EventArgs e)
    {
        var selected = apptsDataGridView.CurrentRow;
        if (selected != null)
        {
            var apptForm = new FormAppointment((Appointment)selected.DataBoundItem);
            apptForm.ShowDialog();

        }
    }

    private void RemoveApptBtn_Click(object sender, EventArgs e)
    {
        var selected = apptsDataGridView.CurrentRow;
        if (selected != null)
        {
            int apptId = (int)selected.Cells[apptsDataGridView.Columns["appointment_id"].Index].Value;
            var result = Helpers.WhatKindOfAppt(apptId);

            if (result == typeof(HomeAppointment))
            {
                HomeAppointment.RemoveHomeAppt(apptId);
                populateDGV(apptsDataGridView, "appointment");
            }

            if (result == typeof(OfficeAppointment))
            {
                OfficeAppointment.RemoveOfficeAppt(apptId);
                populateDGV(apptsDataGridView, "appointment");
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
        var selected = cxDataGridView.CurrentRow;
        if (selected != null)
        {
            var cxForm = new FormCustomer((Customer)selected.DataBoundItem);
            cxForm.ShowDialog(); //TODO: finish
        }
    }

    private void RemoveCxBtn_Click(object sender, EventArgs e)
    {
        var selected = cxDataGridView.CurrentRow;
        if (selected != null)
        {
            int cxId = (int)selected.Cells[apptsDataGridView.Columns["customer_id"].Index].Value;
            var result = Customer.DeleteCustomer(cxId);
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
        searchDGV(cxDataGridView,"customer",cxSearchTB.Text);
    }
}