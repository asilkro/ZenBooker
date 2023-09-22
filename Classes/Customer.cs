using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Core;
using MySqlConnector.Logging;
using RepoDb;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes
{
    internal class Customer
    {

        #region Properties / Fields

        // All these are from the Database ERD
        public int CustomerId { get; set; } // PK, auto_increment, not_null
        public string First { get; set; } // VARCHAR(32), PK, not_null
        public string Last { get; set; } // VARCHAR(32) PK, not_null
        public int Phone { get; set; } // int, not_null
        public string Email { get; set; } // VARCHAR(48) PK, not_null
        public int PreferredOffice { get; set; } // int, FK

        #endregion

        #region Constructors

        public Customer()
        {

        }

        public Customer(int customerId, string first, string last, int phone, string email, int preferredOffice)
        {
            CustomerId = customerId;
            First = first;
            Last = last;
            Phone = phone;
            Email = email;
            PreferredOffice = preferredOffice;
        }

        #endregion

        #region SQL

        public bool InsertCustomer(Customer customer)
        { 
            using (var connection = new Builder().Connection()) 
                try 
                { 
                    { 
                        var cxToAdd = new 
                        {
                        First = customer.First,
                        Last = customer.Last,
                        Phone = customer.Phone,
                        Email = customer.Email,
                        PreferredOffice = customer.PreferredOffice,
                    };
                    var id = connection.Insert("[zth].[customer]", entity: cxToAdd);
                    }
                    return true;
                }
                catch (Exception e) 
                { 
                    LogManager.GetLogger("LoggingRepo").Warn(e, e);
                    return false;
                }

        }

        public bool DeleteCustomer(int customerId)
        {
            using (var connection = new Builder().Connection())
                try
                {
                    var deletedRow = connection.Delete("[zth].[customer]", customerId);
                    return true;
                }
                catch (Exception e)
                {
                    LogManager.GetLogger("LoggingRepo").Warn(e, e);
                    return false;
                }
        }

        public bool UpdateCustomer(Customer customer)
        {
            using (var connection = new Builder().Connection())
                try
                {
                    {
                        var cxToEdit = new
                        {
                            customer.CustomerId,
                            customer.First, 
                            customer.Last,
                            customer.Phone,
                            customer.Email, 
                            customer.PreferredOffice,
                        };
                        var updatedCx = connection.Update("[zth].[customer]", entity: cxToEdit);
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
}
