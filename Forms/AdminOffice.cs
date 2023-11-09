using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms
{
    public partial class AdminOffice : Form
    {
        public AdminOffice()
        {
            InitializeComponent();
            officeIdTB.Text = Helpers.AutoIncrementId("office");
        }

        public AdminOffice(Office office)
        {
            InitializeComponent();
            FillOfficeDetails(office);
        }

        private void FillOfficeDetails(Office office)
        {
            officeIdTB.Text = office.office_id.ToString();
            officeAddressIdTB.Text = office.address_id.ToString();
            officeNameTB.Text = office.office_name;
        }
    }
}
