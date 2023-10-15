using log4net;
using RepoDb;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes;

public class Customer
{
    #region Properties / Fields

    // All these are from the Database ERD
    public int Customer_Id { get; set; } // PK, auto_increment, not_null
    public string First { get; set; } // VARCHAR(32), PK, not_null
    public string Last { get; set; } // VARCHAR(32) PK, not_null
    public string Phone { get; set; } // VARCHAR(12), not_null
    public string Email { get; set; } // VARCHAR(48) PK, not_null
    public int PreferredOffice { get; set; } // int, FK

    #endregion

    #region Constructors

    public Customer()
    {
    }

    public Customer(int customerId, string first, string last, string phone, string email, int preferredOffice)
    {
        Customer_Id = customerId;
        First = first;
        Last = last;
        Phone = phone;
        Email = email;
        PreferredOffice = preferredOffice;
    }

    #endregion

    #region SQL

    public static bool InsertCustomer(Customer customer)
    {
        using (var connection = new Builder().Connect())
        {
            try
            {
                var id = connection.Insert("[zth].[customer]", customer);
                MessageBox.Show("Customer id " + id + " created.", "Customer Created");
                return true;
            }
            catch (Exception e)
            {
                LogManager.GetLogger("LoggingRepo").Warn(e, e);
                return false;
            }
        }
    }

    public static bool DeleteCustomer(int customerId)
    {
        using (var connection = new Builder().Connect())
        {
            try
            {
                var id = connection.Delete("[zth].[customer]", customerId);
                MessageBox.Show("Customer id " + id + " removed.", "Customer Removed");
                return true;
            }
            catch (Exception e)
            {
                LogManager.GetLogger("LoggingRepo").Warn(e, e);
                return false;
            }
        }
    }

    public static bool UpdateCustomer(Customer customer)
    {
        using (var connection = new Builder().Connect())
        {
            try
            {
                {
                    var updatedCx = connection.Update("[zth].[customer]", customer);
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
    }

    #endregion
}