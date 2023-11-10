using ZenoBook.Classes;

namespace ZenoBook.Forms
{
    public partial class AdminAddress : Form
    {
        public AdminAddress()
        {
            InitializeComponent();
        }

        public AdminAddress(Address addy)
        {
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

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void backBtn_Click(object sender, EventArgs e) => Close();
    }
}
