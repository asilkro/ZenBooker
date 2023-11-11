using RepoDb;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class Admin : Form
{
    public Admin()
    {
        InitializeComponent();
        Helpers.PopulateDgv(staffDGV, "staff");
        Helpers.PopulateDgv(serviceDGV, "service");
        Helpers.PopulateDgv(officeDGV, "office");
        Helpers.PopulateDgv(addressDGV, "address");
    }

    #region Staff Buttons
    private void CreateStaffBtn_Click(object sender, EventArgs e)
    {
        var form = new AdminStaff();
        form.ShowDialog();
    }
    private void RemoveStaffBtn_Click(object sender, EventArgs e)
    {
        {
            var selectedRow = staffDGV.CurrentRow;
            if (selectedRow == null) return;
            var row = staffDGV.Rows.IndexOf(selectedRow);
            var selected = (int)staffDGV["staff_id", row].Value;
            if (!Helpers.ConfirmedAction()) return;
            var result = Helpers.DeleteStaff(selected);
            if (result)
            {
                Helpers.PopulateDgv(staffDGV, "staff");
            }
        }
    }
    private void UpdateStaffBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = staffDGV.CurrentRow;
        if (selectedRow == null) return;
        var row = staffDGV.Rows.IndexOf(selectedRow);
        var selected = (int)staffDGV["staff_id", row].Value;
        {
            using var connection = new Builder().Connect();
            var staff = connection.Query<Staff>("staff", selected).FirstOrDefault();
            if (staff == null) return;
            var staffForm = new AdminStaff(staff);
            staffForm.ShowDialog();
        }
    }
    #endregion

    #region Service Buttons
    private void CreateServiceBtn_Click(object sender, EventArgs e)
    {
        var form = new AdminService();
        form.ShowDialog();
    }
    private void RemoveServiceBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = serviceDGV.CurrentRow;
        if (selectedRow == null) return;
        var row = serviceDGV.Rows.IndexOf(selectedRow);
        var selected = (int)serviceDGV["service_id", row].Value;
        if (!Helpers.ConfirmedAction()) return;
        var result = Helpers.DeleteService(selected);
        if (result)
        {
            Helpers.PopulateDgv(serviceDGV, "service");
        }
    }
    private void UpdateServiceBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = serviceDGV.CurrentRow;
        if (selectedRow == null) return;
        var row = serviceDGV.Rows.IndexOf(selectedRow);
        var selected = (int)serviceDGV["service_id", row].Value;
        {
            using var connection = new Builder().Connect();
            var service = connection.Query<Service>("service", selected).FirstOrDefault();
            if (service == null) return;
            var serviceForm = new AdminService(service);
            serviceForm.ShowDialog();
        }
    }
    #endregion

    #region Office Buttons
    private void OfficeCreateBtn_Click(object sender, EventArgs e)
    {
        var form = new AdminOffice();
        form.ShowDialog();
    }
    private void OfficeRemoveBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = officeDGV.CurrentRow;
        if (selectedRow == null) return;
        var row = officeDGV.Rows.IndexOf(selectedRow);
        var selected = (int)officeDGV["office_id", row].Value;
        if (!Helpers.ConfirmedAction()) return;
        var result = Helpers.DeleteOffice(selected);
        if (result)
        {
            Helpers.PopulateDgv(officeDGV, "office");
        }
    }
    private void OfficeUpdateBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = officeDGV.CurrentRow;
        if (selectedRow == null) return;
        var row = officeDGV.Rows.IndexOf(selectedRow);
        var selected = (int)officeDGV["office_id", row].Value;
        {
            using var connection = new Builder().Connect();
            var office = connection.Query<Office>("office", selected).FirstOrDefault();
            if (office == null) return;
            var officeForm = new AdminOffice(office);
            officeForm.ShowDialog();
        }
    }
    #endregion

    #region Address Buttons
    private void CreateAddressBtn_Click(object sender, EventArgs e)
    {
        var addressForm = new AdminAddress();
        addressForm.ShowDialog();
    }
    private void RemoveAddressBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = addressDGV.CurrentRow;
        if (selectedRow == null) return;
        var row = addressDGV.Rows.IndexOf(selectedRow);
        var selected = (int)addressDGV["address_id", row].Value;
        if (!Helpers.ConfirmedAction()) return;
        var result = Helpers.DeleteAddress(selected);
        if (result)
        {
            Helpers.PopulateDgv(addressDGV, "address");
        }
    }
    private void UpdateAddressBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = addressDGV.CurrentRow;
        if (selectedRow == null) return;
        var row = addressDGV.Rows.IndexOf(selectedRow);
        var selected = (int)addressDGV["address_id", row].Value;
        {
            using var connection = new Builder().Connect();
            var address = connection.Query<Address>("address", selected).FirstOrDefault();
            if (address == null) return;
            var addressForm = new AdminAddress(address);
            addressForm.ShowDialog();
        }
    }
    #endregion

    #region Search Buttons
    private void StaffSearchBtn_Click(object sender, EventArgs e) =>
        Helpers.SearchDgv(staffDGV, "staff", staffSearchTB.Text);
    private void ServicesSearchBtn_Click(object sender, EventArgs e) =>
        Helpers.SearchDgv(serviceDGV, "service", servicesSearchTB.Text);
    private void OfficeSearchBtn_Click(object sender, EventArgs e) =>
        Helpers.SearchDgv(officeDGV, "office", officeSearchTB.Text);
    private void SearchAddressBtn_Click(object sender, EventArgs e) =>
        Helpers.SearchDgv(addressDGV, "address", addressSearchTB.Text);
    #endregion

    #region Other Buttons
    private void ChangePWbtn_Click(object sender, EventArgs e)
    {
        var pwForm = new AdminPw();
        pwForm.ShowDialog();
    }
    private void BackBtn_Click(object sender, EventArgs e) => Close();

    #endregion

}