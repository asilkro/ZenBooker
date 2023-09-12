using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenoBook.Classes
{
    public abstract class BaseModel
    {
        public abstract string GetPrimaryKeyColumnName();
        public abstract int GetPrimaryKeyValue();
    }
}
