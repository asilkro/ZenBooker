using RepoDb;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class Main : Form
{
    public Main()
    {
        InitializeComponent();
        ApptSearchTip();
        Helpers.PopulateDgv(apptsDataGridView, "appointment");
        Helpers.PopulateDgv(cxDataGridView, "customer");
    }

    private void ApptSearchTip()
    {
        var apptTip = new ToolTip
        {
            ToolTipTitle = "Appt Search Tip",
            Active = true,
            AutomaticDelay = 700,
            AutoPopDelay = 7000,
            InitialDelay = 500,
            IsBalloon = true,
            Tag = apptsDataGridView
        };
        apptsDataGridView.ShowCellToolTips = true;
        apptTip.SetToolTip(apptSearchTB, "Use the customer search section to find a customer Id for this search.");
        apptTip.SetToolTip(apptsDataGridView, "Use the customer search section to find a customer Id for this search.");
    }


    #region Event Handlers

    private void LogoutBtn_Click(object sender, EventArgs e)
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
        var selected = (int)apptsDataGridView["Appointment_id", row].Value;
        using var connection = new Builder().Connect();
        {
            connection.Open();

            Helpers.GetAppointment(selected, out var uAppt);
            if (uAppt == null) return;
            new FormAppointment(uAppt).ShowDialog();
        }
        connection.Close();
    }

    private void RemoveApptBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = apptsDataGridView.CurrentRow;
        if (selectedRow == null) return;
        var row = apptsDataGridView.Rows.IndexOf(selectedRow);

        var selected = (int)apptsDataGridView["Appointment_id", row].Value;
        if (!Helpers.ConfirmedAction()) return;
        var result = Helpers.RemoveAppointment(selected);
        if (result)
        {
            Helpers.PopulateDgv(apptsDataGridView, "appointment");
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
        if (selectedRow == null) return;
        var row = cxDataGridView.Rows.IndexOf(selectedRow);
        var selected = (int)cxDataGridView["customer_id", row].Value;
        if (!Helpers.ConfirmedAction()) return;
        var result = Helpers.DeleteCustomer(selected);
        if (result)
        {
            Helpers.PopulateDgv(cxDataGridView, "customer");
        }
    }

    private void ApptSearchBtn_Click(object sender, EventArgs e)
    {
        if (Helpers.NoProhibitedContent(apptSearchTB.Text))
        {
            Helpers.SearchDgv(apptsDataGridView, "appointment", apptSearchTB.Text);
        }
    }

    private void CxSearchBtn_Click(object sender, EventArgs e)
    {
        if (Helpers.NoProhibitedContent(cxSearchTB.Text))
        {
            Helpers.SearchDgv(cxDataGridView, "customer", cxSearchTB.Text);
        }
    }

    private void Logo_Click(object sender, EventArgs e)
    {
        var adminForm = new Admin();
        adminForm.ShowDialog();
    }
    #endregion

    #region Reporting

    private void TodayApptsBtn_Click(object sender, EventArgs e)
    {
        Helpers.GenerateApptReportInDgv(apptsDataGridView, "today");
    }

    private void TomorrowApptsBtn_Click(object sender, EventArgs e)
    {
        Helpers.GenerateApptReportInDgv(apptsDataGridView, "tomorrow");
    }

    private void WeekApptsBtn_Click(object sender, EventArgs e)
    {
        Helpers.GenerateApptReportInDgv(apptsDataGridView, "week");
    }

    private void MonthApptsBtn_Click(object sender, EventArgs e)
    {
        Helpers.GenerateApptReportInDgv(apptsDataGridView, "month");
    }

    private void SpecificDateBtn_Click(object sender, EventArgs e)
    {
        var searchParams = Helpers.GetFromInputBox("Enter a date to view just those results: YYYY-MM-DD format",
            "Enter a date to search");
        if (!Helpers.NoProhibitedContent(searchParams)) return;
        if (searchParams != "error")
        {
            Helpers.GenerateApptReportInDgv(apptsDataGridView, searchParams);
        }
    }

    private void FormPulledFocus(object sender, EventArgs e)
    {
        Helpers.PopulateDgv(apptsDataGridView, "appointment");
        Helpers.PopulateDgv(cxDataGridView, "customer");
    }

    #endregion
}

