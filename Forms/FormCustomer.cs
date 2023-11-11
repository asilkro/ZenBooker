using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class FormCustomer : Form
{
    private readonly bool _existing;
    public FormCustomer()
    {
        _existing = false;
        InitializeComponent();
        ValidToggle(false);
        cxIdTB.Text = Helpers.AutoIncrementId("customer");
    }

    public FormCustomer(Customer customer)
    {
        _existing = true;
        InitializeComponent();
        tbFirstName.Text = customer.first;
        tbLastName.Text = customer.last;
        tbPhone.Text = customer.phone;
        tbEmail.Text = customer.email;
        tbOffice.Text = customer.preferred_office.ToString();
        cxIdTB.Text = customer.customer_id.ToString();
        ValidToggle(false);
    }

    private void ValidToggle(bool valid)
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

    private void ValidateBtn_Click(object sender, EventArgs e)
    {
        if (!IsThereAProblem())
        {
            ValidToggle(true);
            return;
        }
        if (IsThereAProblem())
        {
            ValidToggle(false);
        }
    }

    private bool IsThereAProblem()
    {
        var result = true;
        for (var index = 0; index < Controls.Count; index++)
        {
            var c = Controls[index];
            if (c is TextBox)
                if (!string.IsNullOrWhiteSpace(c.Text) &&
                    !string.IsNullOrEmpty(c.Text))
                {
                    result = false;
                }

            if (c is not TextBox) continue;
            if (Helpers.NoProhibitedContent(c.Text))
            {
                result = false;
            }
        }

        if (int.TryParse(tbPhone.Text, out _))
        {
            result = false;
        }

        return result;
    }

    private void SaveBtn_Click(object sender, EventArgs e)
    {
        var cx = new Customer
        {
            first = tbFirstName.Text,
            last = tbLastName.Text,
            phone = tbPhone.Text,
            email = tbEmail.Text,
            preferred_office = int.Parse(tbOffice.Text)
        };
        switch (_existing)
        {
            case true:
                cx.customer_id = int.Parse(cxIdTB.Text);
                if (Helpers.UpdateCustomer(cx))
                {
                    Close();
                }
                break;
            case false:
                if (Helpers.InsertCustomer(cx))
                {
                    Close();
                }
                break;
        }
    }
}