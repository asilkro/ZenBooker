using log4net;
using RepoDb;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class FormHomeAppt : Form
{
    private FormAppointment form1;
    private readonly HomeAppointment homeAppt;

    public FormHomeAppt(HomeAppointment appt)
    {
        {
            InitializeComponent();
            homeAppt = appt;

            ReturnServiceAddress(cxIdTB.Text);
            saveBtn.Enabled = false;
        }
    }

    #region Additional Methods

    private void FillCxFromSearch(Address? address)
    {
        address1TB.Text = address?.Address1;
        address2TB.Text = address?.Address2;
        cityTB.Text = address?.City;
        stateTB.Text = address?.State;
        countryTB.Text = address?.Country;
    }

    #endregion

    #region SQL

    public void ReturnServiceAddress(string searchTerm)
    {
        using var connection = new Builder().Connect();
        try
        {
            if (int.TryParse(searchTerm, out int i))
            {
                var serviceAddress = connection.Query<Address>("address", e => e.AddressId == i);
                FillCxFromSearch(serviceAddress.GetEnumerator().Current);
            }
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
        }
    }

    public int? ReturnServiceAddyId(string searchTerm)
    {
        using var connection = new Builder().Connect();

        try
        {
            var serviceAddress =
                connection.Query<Address>("address", e => e.AddressId == int.Parse(searchTerm));
            var sd = serviceAddress.GetEnumerator().Current.AddressId;
            return sd;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
        }

        return null;
    }

    #endregion

    #region Event Handlers

    private void SearchButton_Click(object sender, EventArgs e)
    {
        ReturnServiceAddress(saSearchTB.Text);
    }

    private void cancelBtn_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void validateBtn_Click(object sender, EventArgs e)
    {
        homeAppt.service_address_id = (int) ReturnServiceAddyId(homeAppt.customer_id.ToString())!;
        saveBtn.Enabled = true;
    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
        if (HomeAppointment.InsertHomeAppt(homeAppt))
        {
            Close();
            form1.Close();
        }
    }

    #endregion
}