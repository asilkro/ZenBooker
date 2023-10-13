using System.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySqlConnector;
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

    public static void populateDGV(DataGridView dgv, string tableName)
    {
        {
            using var connection = new Builder().Connect();
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * from @TABLE");
                cmd.Parameters.AddWithValue("@TABLE", tableName);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = cmd;

                DataTable table = new DataTable();
                dataAdapter.Fill(table);

                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;

                dgv.DataSource = bSource;
            }
        }
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
            var apptForm = new FormAppointment((Appointment) selected.DataBoundItem);
            apptForm.ShowDialog();

        }


    }

    private void RemoveApptBtn_Click(object sender, EventArgs e)
    {
        var selected = apptsDataGridView.CurrentRow;
        if (selected != null)
        {
            int apptId = (int) selected.Cells[apptsDataGridView.Columns["appointment_id"].Index].Value;
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
            int cxId = (int) selected.Cells[apptsDataGridView.Columns["customer_id"].Index].Value;
            var result = Customer.DeleteCustomer(cxId);
            if (result)
            {
                MessageBox.Show("Customer with ID: " + cxId + "removed.");
            }

            populateDGV(cxDataGridView, "customer");
        }

        #endregion

    }
}