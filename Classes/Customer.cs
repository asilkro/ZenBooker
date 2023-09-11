using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenBooker.Classes
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
    }
}
