using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cura
{
    public class Availability
    {
        public TimeSpan timeFrom;
        public TimeSpan timeTo;

        public System.DayOfWeek day;

         public override string ToString()
        {
            return day.ToString() + " " + timeFrom.Hours.ToString().PadLeft(2, '0') + ":" + timeFrom.Minutes.ToString().PadLeft(2, '0') + " to " + timeTo.Hours.ToString().PadLeft(2, '0') + ":" + timeTo.Minutes.ToString().PadLeft(2, '0');
        }
    }
}
