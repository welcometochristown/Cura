using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cura.Common
{
    class DateCalculations
    {

        public static int GetWeekIndexOfRotaPeriod(DateTime date)
        {
            DateTime startOfPeriod = GetStartOfRotaPeriod(date);

            double days = (date - startOfPeriod).TotalDays;

            int week = (int)(days / 7) + 1;

            return week ;
        }

        public static DateTime GetStartOfWeek(DateTime date)
        {
            DateTime startDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);

            if (date.DayOfWeek == DayOfWeek.Monday)
                return startDate;

            int dayIndex = (int)startDate.DayOfWeek;

            if (dayIndex == 0)
                dayIndex = 7;

            int subt = dayIndex -1;

            return startDate.AddDays(-subt);
        }

        public static DateTime GetStartOfRotaPeriod(DateTime date)
        {

            if (date == DateTime.MinValue )
                return date;

            DateTime firstWeek = Settings.Instance.firstweek;

            //now check the time from now and the first week specified in  the settings
            TimeSpan span = date - firstWeek;

            //how many weeks has it been?
            double weeks = span.TotalDays / 7;


            double rotaPeriodsSince = Math.Floor(weeks) / Settings.Instance.rotaweekcount;

            DateTime currentPeriodStart = firstWeek.AddDays((Math.Floor(rotaPeriodsSince) * Settings.Instance.rotaweekcount) * 7);

            return currentPeriodStart;

        }

        public static DateTime GetEndOfRotaPeriod(DateTime date)
        {
            DateTime start = GetStartOfRotaPeriod(date);

            return start.AddDays(7 * Settings.Instance.rotaweekcount);
        }
    }
}
