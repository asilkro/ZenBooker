using log4net;
using RepoDb;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes;

public class Address
{
    #region Properties

    public int address_id { get; set; }
    public string address1 { get; set; }
    public string? address2 { get; set; }
    public string city { get; set; }
    public string? state { get; set; }
    public string country { get; set; }

    #endregion

    #region Constructors

    public Address()
    {
    }

    public Address(int address_Id, string address1, string? address2,
        string city, string? state, string country)
    {
        address_id = address_Id;
        this.address1 = address1;
        this.address2 = address2;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    #endregion

    #region SQL

    public static bool InsertAddress(Address address, out int addressId)
    {
        using var connection = new Builder().Connect();
        try
        {
            var id = connection.Insert("address", address);
            MessageBox.Show("Address id " + id + " created.", "Address Created");
            addressId = (int)id;
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            addressId = -1;
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
        using var connection = new Builder().Connect();
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

    #endregion
}