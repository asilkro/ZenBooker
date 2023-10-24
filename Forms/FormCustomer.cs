using System;
using System.Runtime.InteropServices;
using Accessibility;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class FormCustomer : Form
{
    private readonly Customer? _existingCx;

    public FormCustomer()
    {
        InitializeComponent();
        validToggle(false);
        // cxIdTB.Visible = false; // Simpler user experience without this visible when a Cx hasn't been created yet,
        // as it might not be known what the ID is.
        cxIdTB.Text = Helpers.AutoIncrementId("customer"); //TODO: RELIES ON AUTOINCREMENT WHICH MAY BE FLAKY
    }

    public FormCustomer(Customer customer)
    {
        _existingCx = customer;
        InitializeComponent();
        tbFirstName.Text = customer.first;
        tbLastName.Text = customer.last;
        tbPhone.Text = customer.phone;
        tbEmail.Text = customer.email;
        tbOffice.Text = customer.preferred_office.ToString();
        cxIdTB.Text = customer.customer_id.ToString();

        saveBtn.Enabled = false;
        saveBtn.Visible = false;
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

        if (int.TryParse(cxIdTB.Text, out _)) { problem = false; }

        if (int.TryParse(tbPhone.Text, out _)) { problem = false; }

        if (problem) return true;
        return false;
    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
        var result = _existingCx switch
        {
            null => Customer.InsertCustomer(new Customer(customer_Id: int.Parse(cxIdTB.Text), first: tbFirstName.Text,
                last: tbLastName.Text, phone: tbPhone.Text, email: tbEmail.Text, int.Parse(tbOffice.Text))),
            not null => Customer.UpdateCustomer(new Customer(customer_Id: int.Parse(cxIdTB.Text),
                first: tbFirstName.Text, last: tbLastName.Text, phone: tbPhone.Text, email: tbEmail.Text,
                int.Parse(tbOffice.Text)))
        };

        if (result)
        {
            this.Close();
        }
    }
}