using System.Runtime.InteropServices;
using Accessibility;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class FormCustomer : Form
{
    private Customer? _existingCx;
    public FormCustomer()
    {

        InitializeComponent();
        saveBtn.Enabled = false;
        saveBtn.Visible = false;
       // cxIdTB.Visible = false; // Simpler user experience without this visible when a Cx hasn't been created yet,
                                // as it might not be known what the ID is.
        cxIdTB.Text = Helpers.AutoIncrementId("customer"); //TODO: RELIES ON AUTOINCREMENT WHICH MAY BE FLAKY

    }

    public FormCustomer(Customer customer)
    {
        _existingCx = customer;
        InitializeComponent();
        tbFirstName.Text = customer.First;
        tbLastName.Text = customer.Last;
        tbPhone.Text = customer.Phone.ToString();
        tbEmail.Text = customer.Email;
        tbOffice.Text = customer.PreferredOffice.ToString();
        cxIdTB.Text = customer.Customer_Id.ToString();

        saveBtn.Enabled = false;
        saveBtn.Visible = false;
    }


    private void validateBtn_Click(object sender, EventArgs e)
    {
        var isThereAProblem = true;
        foreach (Control c in Controls)
            if (c is TextBox)
                if (!string.IsNullOrWhiteSpace(c.Text) &&
                    !string.IsNullOrEmpty(c.Text))
                {
                    isThereAProblem = false;
                    break;
                }
        if (Int32.TryParse(cxIdTB.Text, out int cxId))
        {
            isThereAProblem = false;
        }

        if (!isThereAProblem)
        {
            validateBtn.Enabled = false;
            validateBtn.Visible = false;
            saveBtn.Enabled = true;
            saveBtn.Visible = true;
        }
    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
        bool result;
        switch (_existingCx)
        {
            case null: 
                result = Customer.InsertCustomer(new Customer(
                    int.Parse(cxIdTB.Text),
                    tbFirstName.Text,
                    tbLastName.Text,
                    int.Parse(tbPhone.Text),
                    tbEmail.Text,
                    int.Parse(tbOffice.Text)));
                break;
            case not null:
                result = Customer.UpdateCustomer((new Customer(
                    int.Parse(cxIdTB.Text),
                    tbFirstName.Text,
                    tbLastName.Text,
                    int.Parse(tbPhone.Text),
                    tbEmail.Text,
                    int.Parse(tbOffice.Text))));
                break;
        }

        if (result)
        {
            this.Close();
        }
        
    }
}