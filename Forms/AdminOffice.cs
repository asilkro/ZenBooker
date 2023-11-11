using log4net;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class AdminOffice : Form
{
    private readonly bool _existing;
    public AdminOffice()
    {
        _existing = false;
        InitializeComponent();
        officeIdTB.Text = Helpers.AutoIncrementId("office");
    }

    public AdminOffice(Office office)
    {
        _existing = true;
        InitializeComponent();
        FillOfficeDetails(office);
    }

    private void FillOfficeDetails(Office office)
    {
        officeIdTB.Text = office.office_id.ToString();
        officeAddressIdTB.Text = office.address_id.ToString();
        officeNameTB.Text = office.office_name;
    }

    private void BackBtn_Click(object sender, EventArgs e) => Close();

    private void SaveBtn_Click(object sender, EventArgs e)
    {
        var office = new Office
        {
            office_name = officeNameTB.Text,
            address_id = int.Parse(officeAddressIdTB.Text)
        };
        try
        {
            switch (_existing)
            {
                case true:
                    office.office_id = int.Parse(officeIdTB.Text);
                    if (Helpers.UpdateOffice(office))
                    {
                        Close();
                    }
                    break;
                case false:
                    if (Helpers.InsertOffice(office))
                    {
                        Close(); 
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, ex);
        }
    }
}