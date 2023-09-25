using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using RepoDb;
using RepoDb.Attributes.Parameter;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms
{
    public partial class FormAppointment : Form
    {
        public FormAppointment()
        {
            InitializeComponent();
        }

        public FormAppointment(Appointment appointment)
        {


        }

        public void UpdateTbs(Appointment appt)
        {

        }

        #region SQL

        public Customer? ReturnCustomer(string searchTerm)
        {
            using (MySqlConnection connection = new Builder().Connect())
            {
                char space = ' ';
                char atSign = '@';

                if (searchTerm.Contains(space))
                {
                    string[] searchTerms = searchTerm.Split(' ', 2);
                    var first = searchTerms[0];
                    var last = searchTerms[1];
                    var sCustomer = connection.Query<Customer>("[zth].[customer]", e => e.First == first && e.Last == last).FirstOrDefault();
                    return sCustomer;
                }

                if (searchTerm.Contains(atSign))
                {
                    var aCustomer = connection.Query<Customer>("[zth].[customer]", e => e.Email == searchTerm).FirstOrDefault();
                    return aCustomer;
                }

                if (int.TryParse(searchTerm, out var i))
                {
                    var iCustomer = connection.Query<Customer>("[zth].[customer]", e => e.Customer_Id == i).FirstOrDefault();
                    return iCustomer;
                }
                return null;
            }
        }

        public Staff? ReturnStaff(string searchTerm)
        {
            using (MySqlConnection connection = new Builder().Connect())
            {
                char atSign = '@';
                if (searchTerm.Contains(atSign))
                {
                    var eStaff = connection.Query<Staff>("[zth].[staff]", e => e.Email == searchTerm).FirstOrDefault();
                    return eStaff;
                } 
                var staff = connection.Query<Staff>("[zth].[staff]", e => e.Name == searchTerm).FirstOrDefault();
                return staff;
                
            }
        }

        public Service? ReturnService(string searchTerm)
        {
            using (MySqlConnection connection = new Builder().Connect())
            {
                if (int.TryParse(searchTerm, out var i))
                {
                    var iService = connection.Query<Service>("[zth].[service]", e => e.Service_Id == int.Parse(searchTerm)).FirstOrDefault();
                    return iService;
                }

                var service = connection.Query<Service>("[zth].[service]", e => e.ServiceName.Contains(searchTerm)).FirstOrDefault();
                return service;
            }
        }

        public Office? ReturnOffice(string searchTerm)
        {
            using (MySqlConnection connection = new Builder().Connect())
            {
                if (int.TryParse(searchTerm, out var i))
                {
                    var iOffice = connection.Query<Office>("[zth].[office]", e => e.OfficeId == int.Parse(searchTerm)).FirstOrDefault();
                    return iOffice;
                } 
                var cOffice = connection.Query<Office>("[zth].[office]", e => e.City.Contains(searchTerm)).FirstOrDefault();
                var nOffice = connection.Query<Office>("[zth].[office]", e => e.OfficeName.Contains(searchTerm)).FirstOrDefault();
                if (cOffice != nOffice) 
                { 
                    MessageBox.Show("Refine your query and try again.", "Ambiguous office entry");
                    return null;
                }
                return cOffice;
            }
        }

        #endregion


        #region Event Handlers
        private void cxSearchButton_Click(object sender, EventArgs e)
        {
            var cx = ReturnCustomer(cxSearchTB.Text);
            switch (cx == null)
            {
                case true:
                    MessageBox.Show("No matching customer found. Check your entry and try again.", "No Customer Found");
                    break;
                case false:
                    cxIdTB.Text = cx.Customer_Id.ToString();
                    cxNameTb.Text = cx.First + cx.Last;
                    cxEmailTB.Text = cx.Email;
                    cxPhoneTB.Text = cx.Phone.ToString();
                    break;
            }
        }

        private void staffSearchButton_Click(object sender, EventArgs e)
        {
            var staff = ReturnStaff(staffSearchTB.Text);
            switch (staff == null)
            {
                case true:
                    MessageBox.Show("No matching staff found. Check your entry and try again.", "No Staff Found");
                    break;
                case false:
                    staffIdTB.Text = staff.StaffId.ToString();
                    staffNameTb.Text = staff.Name;
                    break;
            }
        }

        private void serviceSearchButton_Click(object sender, EventArgs e)
        {
            var service = ReturnService(serviceSearchTB.Text);
            switch (service == null)
            {
                case true:
                    MessageBox.Show("Unable to match to service. Check your entry and try again.", "Unable to match service");
                    break;
                case false:
                    serviceIdTB.Text = service.Service_Id.ToString();
                    serviceNameTb.Text = service.ServiceName;
                    serviceDescTb.Text = service.ServiceDesc;
                    break;
            }
        }

        private void officeSearchButton_Click(object sender, EventArgs e)
        {
            var office = ReturnOffice(officeSearchTB.Text);
            switch (office == null)
            {
                case true:
                    MessageBox.Show("Unable to match to office. Check your entry and try again.", "Unable to match office");
                    break;
                case false:
                    officeIdTB.Text = office.OfficeId.ToString();
                    officeNameTB.Text = office.OfficeName;
                    officeCityTB.Text = office.City;
                    officeStateTB.Text = office.State;
                    officeCountryTB.Text = office.Country;
                    break;
            }
        }


        #endregion


    }
}
