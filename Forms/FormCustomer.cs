using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class FormCustomer : Form
{
    public FormCustomer()
    {
        InitializeComponent();
        validToggle(false);
        cxIdTB.Text = Helpers.AutoIncrementId("customer"); //TODO: RELIES ON AUTOINCREMENT WHICH MAY BE FLAKY
    }

    public FormCustomer(Customer customer)
    {
        InitializeComponent();
        tbFirstName.Text = customer.first;
        tbLastName.Text = customer.last;
        tbPhone.Text = customer.phone;
        tbEmail.Text = customer.email;
        tbOffice.Text = customer.preferred_office.ToString();
        cxIdTB.Text = customer.customer_id.ToString();
        validToggle(false);
    }

    private void validToggle(bool valid)
    {
        switch (valid)
        {
            case true:
                validateBtn.Enabled = false;
                validateBtn.Visible = false;
                saveBtn.Enabled = true;
                saveBtn.Visible = true;
                break;
            case false:
                validateBtn.Enabled = true;
                validateBtn.Visible = true;
                saveBtn.Enabled = false;
                saveBtn.Visible = false;
                break;
        }
    }

    private void validateBtn_Click(object sender, EventArgs e)
    {
        isThereAProblem(out var valid);
        validToggle(valid);
    }

    public bool isThereAProblem(out bool problem)
    {
        problem = true;
        for (var index = 0; index < Controls.Count; index++)
        {
            var c = Controls[index];
            if (c is TextBox)
                if (!string.IsNullOrWhiteSpace(c.Text) &&
                    !string.IsNullOrEmpty(c.Text))
                {
                    problem = false;
                    break;
                }
        }

        if (int.TryParse(cxIdTB.Text, out _))
        {
            problem = false;
        }

        if (int.TryParse(tbPhone.Text, out _))
        {
            problem = false;
        }

        return problem;
    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
        var cx = new Customer
        {
            first = tbFirstName.Text,
            last = tbLastName.Text,
            phone = tbPhone.Text,
            email = tbEmail.Text,
            preferred_office = int.Parse(tbOffice.Text)
        };
        if (!Helpers.DoesThisCxExist(cx))
        {
            if (Helpers.InsertCustomer(cx))
            {
                Close();
            }
        }
        else
        {
            cx.customer_id = int.Parse(cxIdTB.Text);
            if (Helpers.UpdateCustomer(cx))
            {
                Close();
            }
        }
    }
}