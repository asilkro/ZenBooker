using log4net;
using RepoDb;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes;

public class Office
{
    #region Properties / Fields

    public int OfficeId { get; set; } // // PK, auto_increment, not_null
    public string OfficeName { get; set; } // VARCHAR(32)
    public string City { get; set; } // VARCHAR(32)
    public string State { get; set; } // VARCHAR(32)
    public string Country { get; set; } // VARCHAR(32)

    #endregion

    #region Constructors

    public Office()
    {
    }

    public Office(int officeId, string officeName, string city, string state, string country)
    {
        OfficeId = officeId;
        OfficeName = officeName;
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
                var id = connection.Insert("[zth].[office]", office);
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
                var id = connection.Delete("[zth].[office]", officeId);
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
                    var updatedOffice = connection.Update("[zth].[office]", office);
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