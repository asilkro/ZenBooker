using RepoDb;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class FormAppointment : Form
{
    public FormAppointment()
    {
        InitializeComponent();
        apptIdTB.Text = Helpers.AutoIncrementId("appointment");
    }

    public FormAppointment(Appointment appt)
    {
        UpdateTbs(appt);
    }
    public FormAppointment(HomeAppointment hAppt)
    {
        UpdateTbs(hAppt);
    }
    public FormAppointment(OfficeAppointment oAppt)
    {
        UpdateTbs(oAppt);
    }


    public void UpdateTbs(Appointment appt)
    {
        FillDt(appt);
        FillCxFields(appt);
        FillStaffFields(appt);
        FillServiceFields(appt);
        Helpers.ReturnOffice(officeSearchTB.Text);
    }

    private void FillDt(Appointment appt)
    {
        apptIdTB.Text = appt.appointment_id.ToString();
        dateCalendar.SetDate(appt.start.Date);
        startDtPicker.Value = appt.start.ToLocalTime();
        endDtPicker.Value = appt.end.ToLocalTime();
    }

    private void FillServiceFields(Appointment appt)
    {
        var service = Helpers.ReturnService(appt.service_id.ToString());
        serviceIdTB.Text = appt.service_id.ToString();
        serviceNameTb.Text = service?.Service_Name;
        serviceDescTb.Text = service?.Service_Description;
    }

    private void FillStaffFields(Appointment appt)
    {
        var staff = Helpers.ReturnStaff(appt.staff_id.ToString());
        staffIdTB.Text = appt.staff_id.ToString();
        staffNameTb.Text = staff?.Name;
    }

    private void FillCxFields(Appointment appt)
    {
        var cx = Helpers.ReturnCustomer(appt.customer_id.ToString());
        cxIdTB.Text = appt.customer_id.ToString();
        string v = cx?.First + cx?.Last;
        cxNameTb.Text = v;
        cxEmailTB.Text = cx?.Email;
        cxPhoneTB.Text = cx?.Phone.ToString();
        officeSearchTB.Text = cx?.Preferred_Office.ToString();
    }



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
                cxIdTB.Text = cx.Customer_Id.ToString();
                cxNameTb.Text = cx.First + cx.Last;
                cxEmailTB.Text = cx.Email;
                cxPhoneTB.Text = cx.Phone;
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
                staffIdTB.Text = staff.Staff_Id.ToString();
                staffNameTb.Text = staff.Name;
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
                officeIdTB.Text = office.Office_Id.ToString();
                officeNameTB.Text = office.Office_Name;
                break;
        }
    }

    #endregion
}