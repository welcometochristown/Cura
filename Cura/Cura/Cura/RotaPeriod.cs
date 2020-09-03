using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cura
{
    public class RotaPeriod
    {
        public DateTime dateFrom;
        public DateTime dateTo;

        public override string ToString()
        {
            return dateFrom.ToString("dd/MM/yyyy") + "   to   " + dateTo.ToString("dd/MM/yyyy");
        }
    }
}
