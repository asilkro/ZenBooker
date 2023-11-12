using log4net;
using RepoDb.Extensions;
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
            staff_id = int.Parse(staffIdTB.Text),
            office_id = int.Parse(officeIdTB.Text),
            name = staffNameTB.Text,
            email = staffEmailTB.Text,
            phone = staffPhoneTB.Text
        };
        return staff;
    }
    private void PopulateStaffDetails(Staff staff)
    {
        int.TryParse(staff.office_id.ToString(),out var officeId);
        if (officeIdTB.Text.IsNullOrEmpty())
        {
            officeId = 1;
        }
        staffIdTB.Text = staff.staff_id.ToString();
        userIdTB.Text = staff.user_id.ToString();
        officeIdTB.Text = officeId.ToString();
        staffNameTB.Text = staff.name;
        staffEmailTB.Text = staff.email;
        staffPhoneTB.Text = staff.phone;
    }

    private bool IsThereAProblem()
    {
        var problem = true;
        var strings = new List<string>();
        var staffId = staffIdTB.Text;
        var officeId = officeIdTB.Text;
        var userId = userIdTB.Text;
        strings.AddIfNotNull(staffId);
        strings.AddIfNotNull(officeId);
        strings.AddIfNotNull(userId);

        if (strings.Any(s => !Helpers.NoProhibitedContent(s)))
        {
            return problem;
        }

        switch (userIdTB.Text)
        {
            case null:
                break;
            default:
                if (!userIdTB.Text.IsNullOrEmpty())
                {
                    if (!int.TryParse(userIdTB.Text, out _))
                    {
                        return problem;
                    }
                }
                break;
        }
        switch (officeIdTB.Text)
        {
            case null:
                officeIdTB.Text = 1.ToString();
                break;
            default:
                if (!officeIdTB.Text.IsNullOrEmpty())
                {
                    if (!int.TryParse(officeIdTB.Text, out _))
                    {
                        return problem;
                    }
                }
                break;
        }
        problem = false;
        return problem;
    }
    #endregion

    #region Event Handlers

    private void BackBtn_Click(object sender, EventArgs e) => Close();

    private void SaveBtn_Click(object sender, EventArgs e)
    {
        if (IsThereAProblem()) return;
        
        var staffObject = new Staff
        {
            name = staffNameTB.Text,
            email = staffEmailTB.Text,
            phone = staffPhoneTB.Text,
            staff_id = int.Parse(staffIdTB.Text),
        };
        staffObject.user_id = !int.TryParse(userIdTB.Text, out _) ? 1 : int.Parse(userIdTB.Text);
        staffObject.office_id = !int.TryParse(officeIdTB.Text, out _) ? 1 : int.Parse(officeIdTB.Text);

        try
        {
            if (_existing)
            {
                if (Helpers.UpdateStaff(staffObject))
                {
                    Close();
                }
            }
            else
            {
                if (Helpers.InsertStaff(staffObject))
                {
                    Close();
                }
            }
        }
        catch (Exception ex)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, ex);
        }
    }
    #endregion
}