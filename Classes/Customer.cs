using log4net;
using RepoDb;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes;

public class Customer
{
    #region Properties / Fields

    public int customer_id { get; set; } // PK, auto_increment
    public string first { get; set; } // VARCHAR(32), nn
    public string last { get; set; } // VARCHAR(32), nn
    public string phone { get; set; } // VARCHAR(12)
    public string email { get; set; } // VARCHAR(48)
    public int preferred_office { get; set; } // int, FK

    #endregion

    #region Constructors

    public Customer()
    {
    }

    public Customer(int customer_Id, string first, string last, string phone, string email, int preferred_Office)
    {
        customer_id = customer_Id;
        this.first = first;
        this.last = last;
        this.phone = phone;
        this.email = email;
        preferred_office = preferred_Office;
    }

    #endregion

    #region SQL

    public static bool InsertCustomer(Customer customer)
    {
        using var connection = new Builder().Connect();
        try
        {
            var id = connection.Insert("customer", customer);
            MessageBox.Show("Customer id " + id + " created.", "Customer Created");
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    public static bool DeleteCustomer(int customerId)
    {
        using var connection = new Builder().Connect();
        try
        {
            var id = connection.Delete("customer", customerId);
            MessageBox.Show("Customer id " + id + " removed.", "Customer Removed");
            return true;
        }
        catch (Exception e)
        {
            LogManager.GetLogger("LoggingRepo").Warn(e, e);
            return false;
        }
    }

    public static bool UpdateCustomer(Customer customer)
    {
        using var connection = new Builder().Connect();
        try
        {
            {
                var updatedCx = connection.Update("customer", customer);
                MessageBox.Show("Customer id " + updatedCx + " updated.", "Customer Updated");
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