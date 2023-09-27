using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenoBook.DataManipulation;

namespace ZenoBook.Classes
{
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

        public ServiceAddress(int addressId, int? relatedCx, string address1, string? address2, string city, string? state, string country)
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
    }
}
