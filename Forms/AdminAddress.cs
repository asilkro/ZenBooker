using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms
{
    public partial class AdminAddress : Form
    {
        private readonly bool _existing;
        public AdminAddress()
        {
            _existing = false;
            InitializeComponent();
            addressIdTB.Text = Helpers.AutoIncrementId("address");
        }

        public AdminAddress(Address addy)
        {
            _existing = true;
            InitializeComponent();
            FillAddressTbs(addy);
        }

        private void FillAddressTbs(Address addy)
        {
            addressIdTB.Text = addy.address_id.ToString();
            address1Tb.Text = addy.address1;
            address2Tb.Text = addy.address2;
            cityTb.Text = addy.city;
            stateTb.Text = addy.state;
            countryTb.Text = addy.country;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            var addyToSave = Helpers.MakeAddress(address1Tb.Text, address2Tb.Text,
                cityTb.Text, stateTb.Text, countryTb.Text);

            switch (_existing)
            {
                case true:
                    addyToSave.address_id = int.Parse(addressIdTB.Text);
                    if (Helpers.UpdateAddress(addyToSave))
                    {
                        Close();
                    }

                    break;
                case false:
                    if (Helpers.InsertAddress(addyToSave, out int _))
                    {
                        Close();
                    }

                    break;
            }
        }

        private void BackBtn_Click(object sender, EventArgs e) => Close();
    }
}