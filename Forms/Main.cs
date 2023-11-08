using System.Data;
using RepoDb;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class Main : Form
{
    public Main()
    {
        InitializeComponent();
        Helpers.PopulateDgv(apptsDataGridView, "appointment");
        Helpers.PopulateDgv(cxDataGridView, "customer");
    }


    #region Event Handlers

    private void logoutBtn_Click(object sender, EventArgs e)
    {
        var newLogin = new Login();
        newLogin.Show();
        Close();
    }

    private void CreateApptBtn_Click(object sender, EventArgs e)
    {
        var apptForm = new FormAppointment();
        apptForm.ShowDialog();
    }

    private void UpdateApptBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = apptsDataGridView.CurrentRow;
        if (selectedRow == null) return;
        var row = apptsDataGridView.Rows.IndexOf(selectedRow);
        var selected = (int)apptsDataGridView["appointment_id", row].Value;
        using var connection = new Builder().Connect();
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            var uAppt = Helpers.GetAppointment(selected);

            if (uAppt == null) return;

            var apptForm = new FormAppointment(uAppt);
            apptForm.ShowDialog();
            connection.Close();
        }
    }

    private void RemoveApptBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = apptsDataGridView.CurrentRow;
        if (selectedRow == null) return;
        var row = apptsDataGridView.Rows.IndexOf(selectedRow);

        var selected = (int)apptsDataGridView["appointment_id", row].Value;
        if (Helpers.ConfirmedAction())
        {
            var result = Helpers.RemoveAppointment(selected);
            if (result)
            {
                Helpers.PopulateDgv(apptsDataGridView, "appointment");
            }
        }

    }

    private void CreateCxBtnClick(object sender, EventArgs e)
    {
        var cxForm = new FormCustomer();
        cxForm.ShowDialog();
    }

    private void UpdateCxBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = cxDataGridView.CurrentRow;
        if (selectedRow == null) return;
        var row = cxDataGridView.Rows.IndexOf(selectedRow);
        var selected = (int)cxDataGridView["customer_id", row].Value;
        {
            using var connection = new Builder().Connect();
            var customer = connection.Query<Customer>("customer", selected).FirstOrDefault();
            if (customer == null) return;
            var cxForm = new FormCustomer(customer);
            cxForm.ShowDialog();
        }
    }

    private void RemoveCxBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = cxDataGridView.CurrentRow;
        var row = cxDataGridView.Rows.IndexOf(selectedRow);
        var selected = (int)cxDataGridView["customer_id", row].Value;
        if (selectedRow == null) return;
        if (Helpers.ConfirmedAction())
        {
            var result = Helpers.DeleteCustomer(selected);
            if (result)
            {
                Helpers.PopulateDgv(cxDataGridView, "customer");
            }
        }
    }

    private void apptSearchBtn_Click(object sender, EventArgs e)
    {
        Helpers.SearchDgv(apptsDataGridView, "appointment", apptSearchTB.Text);
    }

    private void cxSearchBtn_Click(object sender, EventArgs e)
    {
        Helpers.SearchDgv(cxDataGridView, "customer", cxSearchTB.Text);
    }

    #endregion

    private void Logo_Click(object sender, EventArgs e)
    {
        var adminForm = new Admin();
        adminForm.ShowDialog();
    }

    #region Reporting



    #endregion
    private void allApptsBtn_Click(object sender, EventArgs e)
    {
        var searchParams = Helpers.GetFromInputBox("Enter a date to view just those results: YYYY-MM-DD format",
            "Enter a date to search");
        if (searchParams != "error")
        {
            Helpers.GenerateApptReportInDGV(apptsDataGridView, searchParams);
        }
    }

    private void todayApptsBtn_Click(object sender, EventArgs e)
    {
        Helpers.GenerateApptReportInDGV(apptsDataGridView, "today");
    }

    private void tomorrowApptsBtn_Click(object sender, EventArgs e)
    {
        Helpers.GenerateApptReportInDGV(apptsDataGridView, "tomorrow");
    }

    private void weekApptsBtn_Click(object sender, EventArgs e)
    {
        Helpers.GenerateApptReportInDGV(apptsDataGridView, "week");
    }

    private void monthApptsBtn_Click(object sender, EventArgs e)
    {
        Helpers.GenerateApptReportInDGV(apptsDataGridView, "month");
    }
}