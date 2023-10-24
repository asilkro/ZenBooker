using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class FormAppointment : Form
{
    public FormAppointment()
    {
        InitializeComponent();
        apptIdTB.Text = Helpers.AutoIncrementId("appointment");
        startDtPicker.Format = DateTimePickerFormat.Time;
        endDtPicker.Format = DateTimePickerFormat.Time;
    }

    public FormAppointment(UnifiedApptData appt)
    {
        InitializeComponent();
        UpdateTbs(appt);
        if (appt is { inhomeservice: 1, office_id: 0 })
        {
            homeRadioBtn.Checked = true;
            HideOfficeStuff();
            ShowHomeStuff();
        }

        if (appt.inhomeservice == 0 && appt.office_id != 0)
        {
            officeRadioBtn.Checked = true;
            HideHomeStuff();
            ShowOfficeStuff();
        }
    }

    public void UpdateTbs(UnifiedApptData appt)
    {
        FillDt(appt);
        FillCxFields(appt);
        FillStaffFields(appt);
        FillServiceFields(appt);
        Helpers.ReturnOffice(officeSearchTB.Text);
    }

    private void FillDt(UnifiedApptData appt)
    {
        apptIdTB.Text = appt.appointment_id.ToString();
        dateCalendar.SetDate(appt.start.Date);
        startDtPicker.Value = appt.start;
        endDtPicker.Value = appt.end;
    }

    private void FillServiceFields(UnifiedApptData appt)
    {
        var service = Helpers.ReturnService(appt.service_id.ToString());
        serviceIdTB.Text = appt.service_id.ToString();
        serviceNameTb.Text = service?.Service_Name;
        serviceDescTb.Text = service?.Service_Description;
    }

    private void FillStaffFields(UnifiedApptData appt)
    {
        var staff = Helpers.ReturnStaff(appt.staff_id.ToString());
        staffIdTB.Text = appt.staff_id.ToString();
        staffNameTb.Text = staff?.name;
    }

    private void FillCxFields(Appointment appt)
    {
        var cx = Helpers.ReturnCustomer(appt.customer_id.ToString());
        cxIdTB.Text = appt.customer_id.ToString();
        var v = cx?.first + cx?.last;
        cxNameTb.Text = v;
        cxEmailTB.Text = cx?.email;
        cxPhoneTB.Text = cx?.phone;
        officeSearchTB.Text = cx?.preferred_office.ToString();
    }

    #region Logic for Radio Buttons / Visibility of Relevant Options
    private void HideOfficeStuff()
    {
        officeIdTB.Hide();
        officeNameTB.Hide();
        officeSearchButton.Hide();
        officeSearchTB.Hide();
    }

    private void HideHomeStuff()
    {
        addressIdTB.Hide();
        address1TB.Hide();
        address2TB.Hide();
        cityTB.Hide();
        stateTB.Hide();
        countryTB.Hide();
        homeSearchBtn.Hide();
        saSearchTB.Hide();
    }

    private void ShowOfficeStuff()
    {
        officeIdTB.Show();
        officeNameTB.Show();
        officeSearchButton.Show();
        officeSearchTB.Show();
    }

    private void ShowHomeStuff()
    {
        addressIdTB.Show();
        address1TB.Show();
        address2TB.Show();
        cityTB.Show();
        stateTB.Show();
        countryTB.Show();
        homeSearchBtn.Show();
        saSearchTB.Show();
    }

    private void CheckedChanged(object sender, EventArgs e)
    {
        if (sender.Equals(officeRadioBtn))
        {
            switch (officeRadioBtn.Checked)
            {
                case true:
                    homeRadioBtn.Checked = false;
                    HideHomeStuff();
                    ShowOfficeStuff();
                    break;
                case false:
                    homeRadioBtn.Checked = true;
                    HideOfficeStuff();
                    ShowHomeStuff();
                    break;
            }
        }

        if (!sender.Equals(homeRadioBtn)) return;
        switch (homeRadioBtn.Checked)
        {
            case true:
                officeRadioBtn.Checked = false;
                HideOfficeStuff();
                ShowHomeStuff();
                break;
            case false:
                officeRadioBtn.Checked = true;
                HideHomeStuff();
                ShowOfficeStuff();
                break;
        }
    }



    #endregion


    #region Event Handlers

    private void cxSearchButton_Click(object sender, EventArgs e)
    {
        var cx = Helpers.ReturnCustomer(cxSearchTB.Text);
        switch (cx == null)
        {
            case true:
                MessageBox.Show("No matching customer found. Check your entry and try again.", "No Customer Found");
                break;
            case false:
                cxIdTB.Text = cx.customer_id.ToString();
                cxNameTb.Text = cx.first + " " + cx.last;
                cxEmailTB.Text = cx.email;
                cxPhoneTB.Text = cx.phone;
                break;
        }
    }

    private void staffSearchButton_Click(object sender, EventArgs e)
    {
        var staff = Helpers.ReturnStaff(staffSearchTB.Text);
        switch (staff == null)
        {
            case true:
                MessageBox.Show("No matching staff found. Check your entry and try again.", "No Staff Found");
                break;
            case false:
                staffIdTB.Text = staff.staff_id.ToString();
                staffNameTb.Text = staff.name;
                break;
        }
    }

    private void serviceSearchButton_Click(object sender, EventArgs e)
    {
        var service = Helpers.ReturnService(serviceSearchTB.Text);
        switch (service == null)
        {
            case true:
                MessageBox.Show("Unable to match to service. Check your entry and try again.",
                    "Unable to match service");
                break;
            case false:
                serviceIdTB.Text = service.Service_Id.ToString();
                serviceNameTb.Text = service.Service_Name;
                serviceDescTb.Text = service.Service_Description;
                break;
        }
    }

    private void officeSearchButton_Click(object sender, EventArgs e)
    {
        var office = Helpers.ReturnOffice(officeSearchTB.Text);
        switch (office == null)
        {
            case true:
                MessageBox.Show("Unable to match to office. Check your entry and try again.", "Unable to match office");
                break;
            case false:
                officeIdTB.Text = office.office_id.ToString();
                officeNameTB.Text = office.office_name;
                break;
        }
    }

    private void homeSearchBtn_Click(object sender, EventArgs e)
    {
        var result = Helpers.ReturnAddress(saSearchTB.Text);
        if (result == null)
        {
            MessageBox.Show("Not found, try the address ID or the first line of the address again.", "Address not found");
        }
        if (result != null)
        {
            addressIdTB.Text = result.address_id.ToString();
            address1TB.Text = result.address1;
            address2TB.Text = result.address2;
            cityTB.Text = result.city;
            stateTB.Text = result.state;
            countryTB.Text = result.country;
        }
    }
    private void saveBtn_Click(object sender, EventArgs e)
    {
        if (homeRadioBtn.Checked == officeRadioBtn.Checked)
        {
            MessageBox.Show("Select an appointment type to continue", "Appointment type required.");
        }

        if (homeRadioBtn.Checked)
        {
            var homeAppt = new HomeAppointment();
            homeAppt.customer_id = int.Parse(cxIdTB.Text);
            homeAppt.staff_id = int.Parse(staffIdTB.Text);
            homeAppt.service_id = int.Parse(serviceIdTB.Text);
            homeAppt.start = dateCalendar.SelectionStart.Date + startDtPicker.Value.TimeOfDay;
            homeAppt.end = dateCalendar.SelectionStart.Date + endDtPicker.Value.TimeOfDay;
            homeAppt.inhomeservice = 1;
            var tempAddy = makeAddressFromTbs();
            
            if (!Helpers.DoesThisAddressExist(tempAddy))
            {
                Address.InsertAddress(tempAddy, out var tempSid);
                addressIdTB.Text = tempSid.ToString();
            }
            homeAppt.service_address_id = int.Parse(addressIdTB.Text);
            HomeAppointment.InsertHomeAppt(homeAppt);
        }

        if (officeRadioBtn.Checked)
        {
            var officeAppt = new OfficeAppointment();
            officeAppt.customer_id = int.Parse(cxIdTB.Text);
            officeAppt.staff_id = int.Parse(staffIdTB.Text);
            officeAppt.office_id = int.Parse(officeIdTB.Text);
            officeAppt.service_id = int.Parse(serviceIdTB.Text);
            officeAppt.start = dateCalendar.SelectionStart.Date + startDtPicker.Value.TimeOfDay;
            officeAppt.end = dateCalendar.SelectionStart.Date + endDtPicker.Value.TimeOfDay;
            officeAppt.inhomeservice = 0;
            OfficeAppointment.InsertOfficeAppt(officeAppt);
        }
    }

    internal virtual Address makeAddressFromTbs()
    {
        var tempAddy = new Address();
        tempAddy.address1 = address1TB.Text;
        tempAddy.address2 = address2TB.Text;
        tempAddy.city = cityTB.Text;
        tempAddy.state = stateTB.Text;
        tempAddy.country = countryTB.Text;
        return tempAddy;
    }

    #endregion
}