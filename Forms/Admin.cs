using RepoDb;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class Admin : Form
{
    public Admin()
    {
        InitializeComponent();
        Helpers.populateDGV(staffDataGridView, "staff");
        Helpers.populateDGV(serviceDataGridView, "service");
    }

    private void backBtn_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void RemoveStaffBtn_Click(object sender, EventArgs e)
    {
        {
            var selectedRow = staffDataGridView.CurrentRow;
            var row = staffDataGridView.Rows.IndexOf(selectedRow);
            var selected = (int)staffDataGridView["staff_id", row].Value;
            if (selectedRow == null) return;
            var result = Helpers.DeleteStaff(selected);
            if (result)
            {
                Helpers.populateDGV(staffDataGridView, "staff");
            }
        }
    }

    private void RemoveServiceBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = serviceDataGridView.CurrentRow;
        var row = serviceDataGridView.Rows.IndexOf(selectedRow);
        var selected = (int)serviceDataGridView["service_id", row].Value;
        if (selectedRow == null) return;
        var result = Helpers.DeleteService(selected);
        if (result)
        {
            Helpers.populateDGV(serviceDataGridView, "service");
        }
    }

    private void CreateStaffBtn_Click(object sender, EventArgs e)
    {
        var form = new AdminStaff();
        form.ShowDialog();
    }

    private void CreateServiceBtn_Click(object sender, EventArgs e)
    {
        var form = new AdminService();
        form.ShowDialog();
    }

    private void UpdateStaffBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = staffDataGridView.CurrentRow;
        if (selectedRow == null) return;
        var row = staffDataGridView.Rows.IndexOf(selectedRow);
        var selected = (int)staffDataGridView["staff_id", row].Value;
        {
            using var connection = new Builder().Connect();
            var staff = connection.Query<Staff>("staff", selected).FirstOrDefault();
            if (staff == null) return;
            var staffForm = new AdminStaff(staff);
            staffForm.ShowDialog();
        }
    }

    private void UpdateServiceBtn_Click(object sender, EventArgs e)
    {
        var selectedRow = serviceDataGridView.CurrentRow;
        if (selectedRow == null) return;
        var row = serviceDataGridView.Rows.IndexOf(selectedRow);
        var selected = (int)serviceDataGridView["service_id", row].Value;
        {
            using var connection = new Builder().Connect();
            var service = connection.Query<Service>("service", selected).FirstOrDefault();
            if (service == null) return;
            var serviceForm = new AdminService(service);
            serviceForm.ShowDialog();
        }
    }

    private void staffSearchBtn_Click(object sender, EventArgs e)
    {
        Helpers.SearchDgv(staffDataGridView, "staff", staffSearchTB.Text);
    }

    private void servicesSearchBtn_Click(object sender, EventArgs e)
    {
        Helpers.SearchDgv(serviceDataGridView, "services", servicesSearchTB.Text);
    }
}