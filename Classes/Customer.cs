using log4net;
using RepoDb;
using System.Collections.Generic;
using System.Windows.Forms;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes;

public class Customer
{
    #region Properties / Fields

    public int Customer_Id { get; set; } // PK, auto_increment
    public string First { get; set; } // VARCHAR(32), nn
    public string Last { get; set; } // VARCHAR(32), nn
    public string Phone { get; set; } // VARCHAR(12)
    public string Email { get; set; } // VARCHAR(48)
    public int Preferred_Office { get; set; } // int, FK

    #endregion

    #region Constructors

    public Customer()
    {
    }

    public Customer(int customer_Id, string first, string last, string phone, string email, int preferred_Office)
    {
        Customer_Id = customer_Id;
        First = first;
        Last = last;
        Phone = phone;
        Email = email;
        Preferred_Office = preferred_Office;
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