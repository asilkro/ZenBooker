using log4net;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class FormAppointment : Form
{
    private DateTime _current = DateTime.Now;

    public FormAppointment()
    {
        InitializeComponent();
        apptIdTB.Text = Helpers.AutoIncrementId("appointment");
        cxIdTB.Text = Helpers.AutoIncrementId("customer");
        startDtPicker.Format = DateTimePickerFormat.Time;
        endDtPicker.Format = DateTimePickerFormat.Time;
        startDtPicker.Value = _current + TimeSpan.FromMinutes(00);
        endDtPicker.Value = startDtPicker.Value.AddHours(1);
    }

    public FormAppointment(UnifiedApptData appt)
    {
        InitializeComponent();
        UpdateTbs(appt);
        if (appt is {inhomeservice: 1, office_id: 0})
        {
            homeRadioBtn.Checked = true;
            HideOfficeStuff();
            ShowHomeStuff();
        }

        if (appt.inhomeservice != 0 || appt.office_id == 0) return;
        officeRadioBtn.Checked = true;
        HideHomeStuff();
        ShowOfficeStuff();
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
        startDtPicker.Value = appt.start.ToLocalTime();
        endDtPicker.Value = appt.end.ToLocalTime();
    }

    private void FillServiceFields(UnifiedApptData appt)
    {
        var service = Helpers.ReturnService(appt.service_id.ToString());
        serviceIdTB.Text = appt.service_id.ToString();
        serviceNameTb.Text = service?.service_name;
        serviceDescTb.Text = service?.service_description;
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
                serviceIdTB.Text = service.service_id.ToString();
                serviceNameTb.Text = service.service_name;
                serviceDescTb.Text = service.service_description;
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
            MessageBox.Show("Not found, try the address ID or the first line of the address again.",
                "Address not found");
            return;
        }

        addressIdTB.Text = result.address_id.ToString();
        address1TB.Text = result.address1;
        address2TB.Text = result.address2;
        cityTB.Text = result.city;
        stateTB.Text = result.state;
        countryTB.Text = result.country;
    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
        if (homeRadioBtn.Checked == officeRadioBtn.Checked)
        {
            MessageBox.Show("Select an appointment type to continue", "Appointment type required.");
        }

        try
        {
            if (homeRadioBtn.Checked)
            {
                var homeAppt = new HomeAppointment
                {
                    appointment_id = int.Parse(apptIdTB.Text),
                    customer_id = int.Parse(cxIdTB.Text),
                    staff_id = int.Parse(staffIdTB.Text),
                    service_id = int.Parse(serviceIdTB.Text),
                    start = dateCalendar.SelectionStart.Date + startDtPicker.Value.TimeOfDay,
                    end = dateCalendar.SelectionStart.Date + endDtPicker.Value.TimeOfDay,
                    inhomeservice = 1
                };

                var tempAddy = Helpers.MakeAddress
                (address1TB.Text, address2TB.Text,
                    cityTB.Text, stateTB.Text, countryTB.Text);

                if (!Helpers.DoesThisAddressExist(tempAddy))
                {
                    Helpers.InsertAddress(tempAddy, out var tempSid);
                    addressIdTB.Text = tempSid.ToString();
                }

                homeAppt.service_address_id = int.Parse(addressIdTB.Text);
                if (Helpers.HomeApptExists(homeAppt))
                {
                    if (HomeAppointment.UpdateHomeAppt(homeAppt))
                    {
                        Close();
                    }
                }

                if (HomeAppointment.InsertHomeAppt(homeAppt))
                {
                    Close();
                }

            }

            if (officeRadioBtn.Checked)
            {
                var officeAppt = new OfficeAppointment
                {
                    appointment_id = int.Parse(apptIdTB.Text),
                    customer_id = int.Parse(cxIdTB.Text),
                    staff_id = int.Parse(staffIdTB.Text),
                    office_id = int.Parse(officeIdTB.Text),
                    service_id = int.Parse(serviceIdTB.Text),
                    start = dateCalendar.SelectionStart.Date + startDtPicker.Value.TimeOfDay,
                    end = dateCalendar.SelectionStart.Date + endDtPicker.Value.TimeOfDay,
                    inhomeservice = 0
                };

                if (Helpers.OfficeApptExists(officeAppt))
                {
                    if (OfficeAppointment.UpdateOfficeAppt(officeAppt))
                    {
                        Close();
                    }
                }

                if (OfficeAppointment.InsertOfficeAppt(officeAppt))
                {
                    Close();
                }
            }
        }
        catch (Exception exception)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, exception);
        }

    }

#endregion
}