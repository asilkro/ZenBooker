using RepoDb;
using System.Data;
using System.Windows;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class Main : Form
{
    public Main()
    {
        InitializeComponent();
        Helpers.populateDGV(apptsDataGridView, "appointment");
        Helpers.populateDGV(cxDataGridView, "customer");
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

            var apptFill = new UnifiedApptData();
            if (uAppt == null) return;
            apptFill.appointment_id = uAppt.appointment_id;
            apptFill.customer_id = uAppt.customer_id;
            apptFill.service_id = uAppt.service_id;
            apptFill.staff_id = uAppt.staff_id;
            apptFill.start = uAppt.start;
            apptFill.end = uAppt.end;

            switch (uAppt.office_id != 0 && uAppt.inhomeservice != 1)
            {
                case true:
                    //This should be the case for a OfficeAppt
                    var officeAppt = new OfficeAppointment
                    {
                        appointment_id = uAppt.appointment_id,
                        customer_id = uAppt.customer_id,
                        staff_id = uAppt.staff_id,
                        office_id = uAppt.office_id,
                        service_id = uAppt.service_id,
                        start = uAppt.start,
                        end = uAppt.end,
                        inhomeservice = uAppt.inhomeservice
                    };
                    var apptOForm = new FormAppointment(apptFill);
                    apptOForm.ShowDialog();
                    break;
                case false:
                    var homeAppt = new HomeAppointment
                    {
                        appointment_id = uAppt.appointment_id,
                        customer_id = uAppt.customer_id,
                        staff_id = uAppt.staff_id,
                        service_id = uAppt.service_id,
                        start = uAppt.start,
                        end = uAppt.end,
                        service_address_id = uAppt.service_address_id,
                        inhomeservice = uAppt.inhomeservice
                    };
                    var apptHForm = new FormAppointment(apptFill);
                    apptHForm.ShowDialog();
                    break;
            }

            connection.Close();
        }
    }

    private void RemoveApptBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = apptsDataGridView.CurrentRow;
        if (selectedRow == null) return;
        var row = apptsDataGridView.Rows.IndexOf(selectedRow);
        var selected = (int)apptsDataGridView["appointment_id", row].Value;
        var result = Helpers.RemoveAppointment(selected);
        if (result)
        {
            Helpers.populateDGV(apptsDataGridView, "appointment");
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
                Helpers.populateDGV(cxDataGridView, "customer");
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
}