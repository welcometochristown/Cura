using Cura.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cura
{

    public class AvailabilityCollection
        : Collection<Availability>
    {

        public Collection<DayOff> daysOff;

        //public List<List<System.DayOfWeek>> WeeklyDaysOff;

        public AvailabilityCollection()
        {
            daysOff = new Collection<DayOff>();

        //    this.WeeklyDaysOff = new List<List<System.DayOfWeek>>();

        //    for (int i = 0; i < Settings.Instance.rotaweekcount; i++)
        //    {
        //        this.WeeklyDaysOff.Add(new List<DayOfWeek>());
        //    }
        }


        public class DayOff
        {
           public int week;
           public System.DayOfWeek day;
        }
    }

}
