using log4net;
using RepoDb;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes;

public class Address
{
    #region Properties

    public int AddressId { get; set; }
    public string Address1 { get; set; }
    public string? Address2 { get; set; }
    public string City { get; set; }
    public string? State { get; set; }
    public string Country { get; set; }

    #endregion

    #region Constructors

    public Address()
    {
    }

    public Address(int addressId, string address1, string? address2,
        string city, string? state, string country)
    {
        AddressId = addressId;
        Address1 = address1;
        Address2 = address2;
        City = city;
        State = state;
        Country = country;
    }

    #endregion

    #region SQL

    public static bool InsertAddress(Address address)
    {
        using var connection = new Builder().Connect();
        try
        {
            var id = connection.Insert("address", address);
            MessageBox.Show("Address id " + id + " created.", "Address Created");
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    public static bool DeleteAddress(int addressId)
    {
        using var connection = new Builder().Connect();
        try
        {
            var id = connection.Delete("address", addressId);
            MessageBox.Show("Address id " + id + " removed.", "Address Removed");
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    public static bool UpdateAddress(Address address)
    {
        using (var connection = new Builder().Connect())
        {
            try
            {
                {
                    var updatedCx = connection.Update("address", address);
                    MessageBox.Show("Address id " + updatedCx + " updated.", "Address Updated");
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