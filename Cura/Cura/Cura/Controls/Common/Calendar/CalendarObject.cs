using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cura.Controls.Common.Calendar
{
    class CalendarObject
    {

    public int Day;
    public int Month;

    public int Year;

    public object Item;

    public CalendarObject(int day, int month, int year, object item)
    {
        this.Day = day;
        this.Month = month;
        this.Year = year;

        this.Item = item;
    }

    }
}
