using log4net;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class FormAppointment : Form
{
    private static DateTime _tomorrowDate = DateTime.Now.Date.AddDays(1);
    private static int _nowHours = DateTime.Now.TimeOfDay.Hours;
    private static DateTime _defaultStart = new(_tomorrowDate.Year, _tomorrowDate.Month, _tomorrowDate.Day, _nowHours, 00, 0);
    private static DateTime _defaultEnd = _defaultStart.AddHours(1);

    public FormAppointment()
    {
        InitializeComponent();
        apptIdTB.Text = Helpers.AutoIncrementId("appointment");
        cxIdTB.Text = Helpers.AutoIncrementId("customer");

    }

    public FormAppointment(UnifiedApptData appt)
    {
        InitializeComponent();
        dateTimeSetup(appt);

        switch (appt.inhomeservice)
        {
            case 1:
                homeRadioBtn.Checked = true;
                HideOfficeStuff();
                ShowHomeStuff();
                Helpers.ReturnAddress(appt.service_address_id.ToString());
                break;
            case 0:
                officeRadioBtn.Checked = true;
                HideHomeStuff();
                ShowOfficeStuff();
                Helpers.ReturnOffice(appt.office_id.ToString());
                break;
            default:
                MessageBox.Show("There was an issue loading appointment data.", "Error.");
                break;
        }
        UpdateTbs(appt);
    }

    private void dateTimeSetup(UnifiedApptData? appt)
    {
        if (appt == null)
        {
            startDtPicker.Format = DateTimePickerFormat.Time;
            endDtPicker.Format = DateTimePickerFormat.Time;
            startDtPicker.Value = _defaultStart.ToLocalTime();
            endDtPicker.Value = _defaultEnd.ToLocalTime();
        }
        else
        {
            startDtPicker.Format = DateTimePickerFormat.Time;
            endDtPicker.Format = DateTimePickerFormat.Time;
            startDtPicker.Value = appt.start.ToLocalTime();
            endDtPicker.Value = appt.end.ToLocalTime();
        }
    }

    public void UpdateTbs(UnifiedApptData appt)
    {
        FillDt(appt);
        FillCxFields(appt);
        FillStaffFields(appt);
        FillServiceFields(appt);
        Helpers.ReturnOffice(appt.office_id.ToString());
        Helpers.ReturnAddress(appt.service_address_id.ToString());
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

    private void FillCxFields(UnifiedApptData appt)
    {
        var cx = Helpers.ReturnCustomer(appt.customer_id.ToString());
        cxIdTB.Text = appt.customer_id.ToString();
        var v = cx?.first + cx?.last;
        cxNameTb.Text = v;
        cxEmailTB.Text = cx?.email;
        cxPhoneTB.Text = cx?.phone;
        officeSearchTB.Text = cx?.preferred_office.ToString();
    }
    private void populateCxTb()
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
    private void populateOfficeTb()
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
    private void populateAddressTb()
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
    private void populateServiceTb()
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
    private void populateStaffTb()
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
        populateCxTb();
    }

    private void staffSearchButton_Click(object sender, EventArgs e)
    {
        populateStaffTb();
    }

    private void serviceSearchButton_Click(object sender, EventArgs e)
    {
        populateServiceTb();
    }

    private void officeSearchButton_Click(object sender, EventArgs e)
    {
        populateOfficeTb();
    }

    private void homeSearchBtn_Click(object sender, EventArgs e)
    {
        populateAddressTb();
    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
        if (!(homeRadioBtn.Checked) && !(officeRadioBtn.Checked))
        {
            MessageBox.Show("Select an appointment type to continue", "Appointment type required.");
        }

        try
        {
            saveAppointmentData();
        }
        catch (Exception exception)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, exception);
        }

    }

    private Address addressFromTBs()
    {
        return Helpers.MakeAddress
         (address1TB.Text, address2TB.Text,
             cityTB.Text, stateTB.Text, countryTB.Text);
    }

    private void saveAppointmentData()
    {
        switch (homeRadioBtn.Checked)
        {
            case true:
                var homeAppt = MakeHomeAppt();

                var tempAddy = addressFromTBs();
                switch (Helpers.DoesThisAddressExist(tempAddy))
                {
                    case false:
                        Helpers.InsertAddress(tempAddy, out var tempSid);
                        addressIdTB.Text = tempSid.ToString();
                        populateAddressTb();
                        break;
                    case true:
                        populateAddressTb();
                        break;
                }

                var cHomeAppt = Helpers.HomeToUnified(homeAppt);
                cHomeAppt.service_address_id = int.Parse(addressIdTB.Text);
                switch (Helpers.ApptExists(cHomeAppt))
                {
                    case true:
                        switch (Helpers.RawAppointmentUpdate(cHomeAppt))
                        {
                            case false:
                                MessageBox.Show("There was a problem updating this appointment.",
                                    "Appointment not saved");
                                break;
                            case true:
                                Close();
                                break;
                        }

                        break;

                    case false:
                        switch (Helpers.RawAppointmentInsert(cHomeAppt))
                        {
                            case false:
                                MessageBox.Show("There was a problem adding this appointment.",
                                    "Appointment not saved");
                                break;
                            case true:
                                Close();
                                break;
                        }

                        break;
                }
                break;

            case false:
                var officeAppt = MakeOfficeAppt();
                var cOfficeAppt = Helpers.OfficeToUnified(officeAppt);
                switch (Helpers.ApptExists(cOfficeAppt))
                {
                    case true:
                        switch (Helpers.RawAppointmentUpdate(cOfficeAppt))
                        {
                            case false:
                                MessageBox.Show("There was a problem updating this appointment.",
                                    "Appointment not saved");
                                break;
                            case true:
                                Close();
                                break;
                        }

                        break;
                    case false:
                        switch (Helpers.RawAppointmentInsert(cOfficeAppt))
                        {
                            case false:
                                MessageBox.Show("There was a problem adding this appointment.",
                                    "Appointment not saved");
                                break;
                            case true:
                                Close();
                                break;
                        }

                        break;
                }

                break;
        }
    }

    private OfficeAppointment MakeOfficeAppt()
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
        return officeAppt;
    }

    private HomeAppointment MakeHomeAppt()
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
        return homeAppt;
    }

    #endregion

}