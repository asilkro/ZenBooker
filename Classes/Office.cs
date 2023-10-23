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

    public Office(int officeId, int addressId, string officeName)
    {
        Office_Id = officeId;
        Address_Id = addressId;
        Office_Name = officeName;
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