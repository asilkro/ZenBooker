using log4net;
using RepoDb;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes;

public class Office
{
    #region Properties / Fields

    public int Office_Id { get; set; } // // PK, auto_increment, not_null
    public int Address_Id { get; set; }
    public string Office_Name { get; set; } // VARCHAR(32)

    #endregion

    #region Constructors

    public Office()
    {
    }

    public Office(int officeId, string officeName, string city, string state, string country)
    {
        Office_Id = officeId;
        Office_Name = officeName;
        City = city;
        State = state;
        Country = country;
    }

    #endregion

    #region SQL

    public bool InsertOffice(Office office)
    {
        using (var connection = new Builder().Connect())
        {
            try
            {
                var id = connection.Insert("office", office);
                MessageBox.Show("Office id " + id + " created.", "Office Created");
                return true;
            }
            catch (Exception e)
            {
                LogManager.GetLogger("LoggingRepo").Warn(e, e);
                return false;
            }
        }
    }

    public bool DeleteOffice(int officeId)
    {
        using (var connection = new Builder().Connect())
        {
            try
            {
                var id = connection.Delete("office", officeId);
                MessageBox.Show("Office id " + id + " removed.", "Office Removed");
                return true;
            }
            catch (Exception e)
            {
                LogManager.GetLogger("LoggingRepo").Warn(e, e);
                return false;
            }
        }
    }

    public bool UpdateOffice(Office office)
    {
        using (var connection = new Builder().Connect())
        {
            try
            {
                {
                    var updatedOffice = connection.Update("office", office);
                    MessageBox.Show("Office id " + updatedOffice + " updated.", "Office Updated");
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