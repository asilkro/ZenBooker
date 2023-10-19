using log4net;
using RepoDb;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes;

public class Staff
{
    #region Properties / Fields

    public int StaffId { get; set; } // PK, auto_increment, not_null
    public string Name { get; set; } // PK, VARCHAR(32), not_null
    public int Phone { get; set; } // PK, not_null
    public string Email { get; set; } // VARCHAR(32)
    public int OfficeId { get; set; } // FK, Office.Office_Id

    public int LoginId { get; set; } // FK, Users.UserId
    // TODO: Do I want to use this?

    #endregion

    #region Constructors

    public Staff()
    {
    }

    public Staff(int staffId, string name, int phone, string email, int officeId, int loginId)
    {
        StaffId = staffId;
        Name = name;
        Phone = phone;
        Email = email;
        OfficeId = officeId;
        LoginId = loginId;
    }

    #endregion

    #region SQL

    public bool InsertStaff(Staff staff)
    {
        using (var connection = new Builder().Connect())
        {
            try
            {
                var id = connection.Insert("staff", staff);
                MessageBox.Show("Staff id " + id + " created.", "Staff Created");
                return true;
            }
            catch (Exception e)
            {
                LogManager.GetLogger("LoggingRepo").Warn(e, e);
                return false;
            }
        }
    }

    public bool DeleteStaff(int staffId)
    {
        using (var connection = new Builder().Connect())
        {
            try
            {
                var id = connection.Delete("staff", staffId);
                MessageBox.Show("Staff id " + id + " removed.", "Staff Removed");
                return true;
            }
            catch (Exception e)
            {
                LogManager.GetLogger("LoggingRepo").Warn(e, e);
                return false;
            }
        }
    }

    public bool UpdateStaff(Staff staff)
    {
        using (var connection = new Builder().Connect())
        {
            try
            {
                {
                    var updatedStaff = connection.Update("staff", staff);
                    MessageBox.Show("Staff id " + updatedStaff + " updated.", "Staff Updated");
                }
                return true;
            }
            catch (Exception e)
            {
                LogManager.GetLogger("LoggingRepo").Warn(e, e);
                return false;
            }
        }
    }

    #endregion
}