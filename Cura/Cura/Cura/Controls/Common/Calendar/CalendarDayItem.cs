using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cura.Controls.Common.Calendar
{

    public class CalendarDayItem
    {
        public object Item;
        public System.DateTime _Date;
        public string _Time;
        public string Tag;
        public System.Drawing.Color Color;
        public bool ShowTime;
        public bool IgnoreYear;
    }

    public class CalendarDayItemCollection : Cura.Common.Collection<CalendarDayItem>
    {
        /**/
    }

    public class CalendarDayItemComparer : IComparer<CalendarDayItem>
    {

        public int Compare(CalendarDayItem x, CalendarDayItem y)
        {
            if ((x._Date < y._Date))
            {
                return -1;

            }
            else if ((x._Date > y._Date))
            {
            }

            return 0;
        }
    }

}
