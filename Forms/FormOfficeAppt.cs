﻿using log4net;
using RepoDb;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class FormOfficeAppt : Form
{
    private FormAppointment? form1;
    private readonly OfficeAppointment officeAppt;

    public FormOfficeAppt(OfficeAppointment appt)
    {
        InitializeComponent();
        officeAppt = appt;

        submitBtn.Enabled = false;
    }

    #region Other Methods

    private void FillOfficeFromSearch(Office? address)
    {
        if (address != null)
        {
            officeNameTB.Text = address.Office_Name;
            officeIdTB.Text = address.Office_Id.ToString();
        }
    }

    #endregion

    #region Event Handlers

    private void cancelBtn_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void validateBtn_Click(object sender, EventArgs e)
    {
        officeAppt.Office_Id = int.Parse(officeIdTB.Text);
        officeAppt.InHomeService = false;
    }

    private void SaveBtn_Click(object sender, EventArgs e)
    {
        if (OfficeAppointment.InsertOfficeAppt(officeAppt))
        {
            Close();
            form1?.Close();
        }
    }

    #endregion


    #region SQL

    private static Customer? ReturnCustomer(string searchTerm)
    {
        using var connection = new Builder().Connect();
        var space = ' ';
        var atSign = '@';

        if (searchTerm.Contains(space))
        {
            var searchTerms = searchTerm.Split(' ', 2);
            var first = searchTerms[0];
            var last = searchTerms[1];
            var sCustomer = connection.Query<Customer>("customer", e => e.First == first && e.Last == last)
                .FirstOrDefault();
            return sCustomer;
        }

        if (searchTerm.Contains(atSign))
        {
            var aCustomer = connection.Query<Customer>("customer", e => e.Email == searchTerm)
                .FirstOrDefault();
            return aCustomer;
        }

        if (int.TryParse(searchTerm, out var i))
        {
            var iCustomer = connection.Query<Customer>("customer", e => e.Customer_Id == i)
                .FirstOrDefault();
            return iCustomer;
        }

        return null;
    }

    #endregion
}