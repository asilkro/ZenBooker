using log4net;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class AdminStaff : Form
{
    private readonly bool _existing;
    public AdminStaff()
    {
        _existing = false;
        InitializeComponent();
        staffIdTB.Text = Helpers.AutoIncrementId("staff");
    }

    public AdminStaff(Staff staff)
    {
        _existing = true;
        InitializeComponent();
        PopulateStaffDetails(staff);
    }

    #region Methods
    private Staff MakeStaffObject()
    {
        var staff = new Staff
        {
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
            if (c is not TextBox) continue;
            if (string.IsNullOrWhiteSpace(c.Text) ||
                string.IsNullOrEmpty(c.Text)) continue;
            problem = false;
            break;
        }

        if (!int.TryParse(staffIdTB.Text, out _)) return problem;
        if (!int.TryParse(officeIdTB.Text, out _)) return problem;
        if (!int.TryParse(userIdTB.Text, out _)) return problem;
        problem = false;

        return problem;
    }
    #endregion

    #region Event Handlers

    private void BackBtn_Click(object sender, EventArgs e) => Close();

    private void SaveBtn_Click(object sender, EventArgs e)
    {
        if (IsThereAProblem()) return;
        var staff = MakeStaffObject();
        try
        {
            switch (_existing)
            {
                case true:
                    staff.staff_id = int.Parse(staffIdTB.Text);
                    if (Helpers.UpdateStaff(staff))
                    {
                        Close();
                    }
                    break;
                case false:
                    if (Helpers.InsertStaff(staff))
                    {
                        Close();
                    }
                    break;

            } 
        }
        catch (Exception ex)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, ex);
        }
    }
    #endregion
}