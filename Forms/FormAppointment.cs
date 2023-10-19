using RepoDb;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class FormAppointment : Form
{
    public FormAppointment()
    {
        InitializeComponent();
    }

    public FormAppointment(Appointment appt)
    {
        UpdateTbs(appt);
    }

    public void UpdateTbs(Appointment appt)
    {
        FillDt(appt);
        FillCxFields(appt);
        FillStaffFields(appt);
        FillServiceFields(appt);
        ReturnOffice(officeSearchTB.Text);
    }

    private void FillDt(Appointment appt)
    {
        apptIdTB.Text = appt.Appointment_Id.ToString();
        dateCalendar.SetDate(appt.Start.Date);
        startDtPicker.Value = appt.Start.ToLocalTime();
        endDtPicker.Value = appt.End.ToLocalTime();
    }

    private void FillServiceFields(Appointment appt)
    {
        var service = ReturnService(appt.Service_Id.ToString());
        serviceIdTB.Text = appt.Service_Id.ToString();
        serviceNameTb.Text = service?.ServiceName;
        serviceDescTb.Text = service?.ServiceDesc;
    }

    private void FillStaffFields(Appointment appt)
    {
        var staff = ReturnStaff(appt.Staff_Id.ToString());
        staffIdTB.Text = appt.Staff_Id.ToString();
        staffNameTb.Text = staff?.Name;
    }

    private void FillCxFields(Appointment appt)
    {
        var cx = ReturnCustomer(appt.Customer_Id.ToString());
        cxIdTB.Text = appt.Customer_Id.ToString();
        string v = cx?.First + cx?.Last;
        cxNameTb.Text = v;
        cxEmailTB.Text = cx?.Email;
        cxPhoneTB.Text = cx?.Phone.ToString();
        officeSearchTB.Text = cx?.Preferred_Office.ToString();
    }

    #region SQL

    public Customer? ReturnCustomer(string searchTerm)
    {
        using var connection = new Builder().Connect();
        var space = ' ';
        var atSign = '@';

        if (searchTerm.Contains(space))
        {
            var searchTerms = searchTerm.Split(' ', 2);
            var first = searchTerms[0];
            var last = searchTerms[1];
            var sCustomer = connection.Query<Customer>("[zth].[customer]", e => e.First == first && e.Last == last)
                .FirstOrDefault();
            return sCustomer;
        }

        if (searchTerm.Contains(atSign))
        {
            var aCustomer = connection.Query<Customer>("[zth].[customer]", e => e.Email == searchTerm)
                .FirstOrDefault();
            return aCustomer;
        }

        if (int.TryParse(searchTerm, out var i))
        {
            var iCustomer = connection.Query<Customer>("[zth].[customer]", e => e.Customer_Id == i)
                .FirstOrDefault();
            return iCustomer;
        }

        return null;
    }

    public Staff? ReturnStaff(string searchTerm)
    {
        using var connection = new Builder().Connect();
        var atSign = '@';
        if (searchTerm.Contains(atSign))
        {
            var eStaff = connection.Query<Staff>("[zth].[staff]", e => e.Email == searchTerm).FirstOrDefault();
            return eStaff;
        }

        var staff = connection.Query<Staff>("[zth].[staff]", e => e.Name == searchTerm).FirstOrDefault();
        return staff;
    }

    public Service? ReturnService(string searchTerm)
    {
        using var connection = new Builder().Connect();
        if (int.TryParse(searchTerm, out var i))
        {
            var iService = connection.Query<Service>("[zth].[service]", e => e.Service_Id == int.Parse(searchTerm))
                .FirstOrDefault();
            return iService;
        }

        var service = connection.Query<Service>("[zth].[service]", e => e.ServiceName.Contains(searchTerm))
            .FirstOrDefault();
        return service;
    }

    public Office? ReturnOffice(string searchTerm)
    {
        using var connection = new Builder().Connect();
        if (int.TryParse(searchTerm, out var i))
        {
            var iOffice = connection.Query<Office>("[zth].[office]", e => e.Office_Id == int.Parse(searchTerm))
                .FirstOrDefault();
            return iOffice;
        }

        var cOffice = connection.Query<Office>("[zth].[office]", e => e.City.Contains(searchTerm)).FirstOrDefault();
        var nOffice = connection.Query<Office>("[zth].[office]", e => e.Office_Name.Contains(searchTerm))
            .FirstOrDefault();
        if (cOffice != nOffice)
        {
            MessageBox.Show("Refine your query and try again.", "Ambiguous office entry");
            return null;
        }

        return cOffice;
    }

    #endregion


    #region Event Handlers

    private void cxSearchButton_Click(object sender, EventArgs e)
    {
        var cx = ReturnCustomer(cxSearchTB.Text);
        switch (cx == null)
        {
            case true:
                MessageBox.Show("No matching customer found. Check your entry and try again.", "No Customer Found");
                break;
            case false:
                cxIdTB.Text = cx.Customer_Id.ToString();
                cxNameTb.Text = cx.First + cx.Last;
                cxEmailTB.Text = cx.Email;
                cxPhoneTB.Text = cx.Phone.ToString();
                break;
        }
    }

    private void staffSearchButton_Click(object sender, EventArgs e)
    {
        var staff = ReturnStaff(staffSearchTB.Text);
        switch (staff == null)
        {
            case true:
                MessageBox.Show("No matching staff found. Check your entry and try again.", "No Staff Found");
                break;
            case false:
                staffIdTB.Text = staff.StaffId.ToString();
                staffNameTb.Text = staff.Name;
                break;
        }
    }

    private void serviceSearchButton_Click(object sender, EventArgs e)
    {
        var service = ReturnService(serviceSearchTB.Text);
        switch (service == null)
        {
            case true:
                MessageBox.Show("Unable to match to service. Check your entry and try again.",
                    "Unable to match service");
                break;
            case false:
                serviceIdTB.Text = service.Service_Id.ToString();
                serviceNameTb.Text = service.ServiceName;
                serviceDescTb.Text = service.ServiceDesc;
                break;
        }
    }

    private void officeSearchButton_Click(object sender, EventArgs e)
    {
        var office = ReturnOffice(officeSearchTB.Text);
        switch (office == null)
        {
            case true:
                MessageBox.Show("Unable to match to office. Check your entry and try again.", "Unable to match office");
                break;
            case false:
                officeIdTB.Text = office.Office_Id.ToString();
                officeNameTB.Text = office.Office_Name;
                officeCityTB.Text = office.City;
                officeStateTB.Text = office.State;
                officeCountryTB.Text = office.Country;
                break;
        }
    }

    #endregion
}