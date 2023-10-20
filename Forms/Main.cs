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
        DGVExtensions.populateDGV(apptsDataGridView, "appointment");
        DGVExtensions.populateDGV(cxDataGridView, "customer");
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
            using (var connection = new Builder().Connect())
            {
                var result = UnifiedApptData.RemoveAppointment(selected);
                if (result)
                {
                    DGVExtensions.populateDGV(apptsDataGridView, "appointment");
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
        int selected = (int) cxDataGridView["customer_id", row].Value;
        if (selected != null)
        {
            var result = Customer.DeleteCustomer(selected);
            if (result)
            {
                DGVExtensions.populateDGV(cxDataGridView, "customer");
            }
        }
    }

    private void apptSearchBtn_Click(object sender, EventArgs e)
    {
        DGVExtensions.searchDGV(apptsDataGridView, "appointment", apptSearchTB.Text);
    } 
    private void cxSearchBtn_Click(object sender, EventArgs e) 
    { 
        DGVExtensions.searchDGV(cxDataGridView, "customer", cxSearchTB.Text);
    }
    #endregion
}