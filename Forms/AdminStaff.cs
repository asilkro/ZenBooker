using log4net;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms
{
    public partial class AdminStaff : Form
    {
        public AdminStaff()
        {
            InitializeComponent();
        }

        public AdminStaff(Staff staff)
        {
            InitializeComponent();
            staffIdTB.Text = staff.staff_id.ToString();
            userIdTB.Text = staff.user_id.ToString();
            officeIdTB.Text = staff.office_id.ToString();
            staffNameTB.Text = staff.name;
            staffEmailTB.Text = staff.email;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var staff = new Staff();
            staff.staff_id = int.Parse(staffIdTB.Text);
            staff.user_id = int.Parse(userIdTB.Text);
            staff.office_id = int.Parse(officeIdTB.Text);
            staff.name = staffNameTB.Text;
            staff.email = staffEmailTB.Text;
            staff.phone = staffPhoneTB.Text;
            try
            {
                if (Helpers.ReturnStaff(staffNameTB.Text) != null || Helpers.ReturnStaff(staffEmailTB.Text) != null)
                {
                    Helpers.UpdateStaff(staff);
                    Close();
                }
                else
                {
                    Helpers.InsertStaff(staff);
                    Close();
                }
            }
            catch (Exception ex)
            {

                LogManager.GetLogger("LoggingRepo").Warn(e, ex);

            }
        }
    }
}
