using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZenoBook.DataManipulation
{
    public static class DGVExtensions
    {
        public static List<T> dgvRowToList<T>(this DataGridViewSelectedRowCollection rows)
        {
            var list = new List<T>();
            for (int i = 0; i < rows.Count; i++)
                list.Add((T)rows[i].DataBoundItem);
            return list;
        }
    }
}
