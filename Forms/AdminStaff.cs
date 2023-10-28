using log4net;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class AdminStaff : Form
{
    public AdminStaff()
    {
        InitializeComponent();
        staffIdTB.Text = Helpers.AutoIncrementId("staff");
    }

    public AdminStaff(Staff staff)
    {
        InitializeComponent();
        PopulateStaffDetails(staff);
    }

    #region Methods
    private Staff MakeStaffObject()
    {
        var staff = new Staff
        {
            staff_id = int.Parse(staffIdTB.Text),
            user_id = int.Parse(userIdTB.Text),
            office_id = int.Parse(officeIdTB.Text),
            name = staffNameTB.Text,
            email = staffEmailTB.Text,
            phone = staffPhoneTB.Text
        };
        return staff;
    }
    private void PopulateStaffDetails(Staff staff)
    {
        staffIdTB.Text = staff.staff_id.ToString();
        userIdTB.Text = staff.user_id.ToString();
        officeIdTB.Text = staff.office_id.ToString();
        staffNameTB.Text = staff.name;
        staffEmailTB.Text = staff.email;
        staffPhoneTB.Text = staff.phone;
    }

    private bool IsThereAProblem()
    {
        var problem = true;
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

        if (int.TryParse(staffIdTB.Text, out _))
        {
            if (int.TryParse(officeIdTB.Text, out _))
            {
                if (int.TryParse(userIdTB.Text, out _))
                {
                    problem = false;
                }
            }
        }

        return problem;
    }
    #endregion

    #region Event Handlers

    private void backBtn_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
        if (!IsThereAProblem())
        {
            var staff = MakeStaffObject();
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

    #endregion

}