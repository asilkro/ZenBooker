using log4net;
using RepoDb;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes;

public class ServiceAddress
{
    #region Properties

    public int AddressId { get; set; }
    public int? RelatedCx { get; set; }
    public string Address1 { get; set; }
    public string? Address2 { get; set; }
    public string City { get; set; }
    public string? State { get; set; }
    public string Country { get; set; }

    #endregion

    #region Constructors

    public ServiceAddress()
    {
    }

    public ServiceAddress(int addressId, int? relatedCx, string address1, string? address2,
        string city, string? state, string country)
    {
        AddressId = addressId;
        RelatedCx = relatedCx;
        Address1 = address1;
        Address2 = address2;
        City = city;
        State = state;
        Country = country;
    }

    #endregion

    #region SQL

    public static void AssociateAddress(ServiceAddress address, int customerId)
    {
        using var connection = new Builder().Connect();
        try
        {
            if (address.RelatedCx == customerId)
            {
                MessageBox.Show("Customer already has a service address attached for home service.", "Not required");
            }
            ;
            if (address.RelatedCx == null)
            {
                address.RelatedCx = customerId;
                UpdateAddress(address);
            }
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
        }
    }

    public static bool InsertAddress(ServiceAddress address)
    {
        using var connection = new Builder().Connect();
        try
        {
            var id = connection.Insert("[zth].[address]", address);
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
            var id = connection.Delete("[zth].[address]", addressId);
            MessageBox.Show("Address id " + id + " removed.", "Address Removed");
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    public static bool UpdateAddress(ServiceAddress address)
    {
        using (var connection = new Builder().Connect())
        {
            try
            {
                {
                    var updatedCx = connection.Update("[zth].[address]", address);
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