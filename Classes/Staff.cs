﻿using log4net;
using RepoDb;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes;

public class Staff
{
    #region Properties / Fields

    public int staff_id { get; set; } // PK, auto_increment, not_null
    public int user_id { get; set; } // FK, Users.UserId
    public int office_id { get; set; } // FK, Office.office_id
    public string name { get; set; } // VARCHAR(45), not_null
    public string phone { get; set; } // VARCHAR(12)
    public string email { get; set; } // VARCHAR(45)

    #endregion

    #region Constructors

    public Staff(int staff_Id, int user_Id, int office_Id, string name, string phone, string email)
    {
        staff_id = staff_Id;
        user_id = user_Id;
        office_id = office_Id;
        this.name = name;
        this.phone = phone;
        this.email = email;
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