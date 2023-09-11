using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenBooker.Classes
{
    internal class Staff
    {
        #region Properties / Fields

        public int StaffId { get; set; } //
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; } // can be null
        public int OfficeId { get; set; }
        private int LoginId { get; set; }
        // TODO: Do I want to use this?

        #endregion

        #region Constructors

        public Staff()
        {

        }

        #endregion
    }
}
