using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cura
{

    public class Absence
        : IComparable

    {
        #region Fields
        private AbsenceReason _reason;
        private DateTime _dateStart;

        private int duration_minutes;
        #endregion

        #region Constructor
        public Absence()
        {
            this._reason = AbsenceReason.None;
            this._dateStart = DateTime.Now;
            this.duration_minutes = 0;
        }
        #endregion

        #region Enums
        public enum AbsenceReason
        {
            None,
            Holiday,
            Sickness,
            Training,
            DayOff
        }
        #endregion
     
        #region Properties
        public int Duration
        {
            get
            {
              
                //minutes
                return duration_minutes;
            }
            set
            {
                duration_minutes = value;
            }
        }
        public AbsenceReason Reason
        {
            get
            {
                return _reason;
            }
            set
            {
                _reason = value;
            }

        }

        public DateTime DateStart
        {
            get
            {
                return _dateStart;
            }
            set
            {
                _dateStart = value;
            }
        }

        public int DaysCount
        {
            get
            {
                return (int)Math.Floor(((double)duration_minutes / 60) / 24);
            }
            set
            {
                duration_minutes = ((value * 24) * 60);
            }
        }

        public DateTime DateEnd
        {
            get
            {
                return DateStart.AddMinutes(Duration).AddSeconds(-1);
            }
            set
            {
                duration_minutes = Convert.ToInt32((value - DateStart).TotalMinutes);
            }
        }
        #endregion

        /// <summary>
        /// To String of the abscence
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return DateStart.ToString("dd/MM/yyyy") + " for " + DaysCount.ToString() + " days ";
        }


        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Absence abs = (obj as Absence);

            return DateStart.CompareTo(abs.DateStart);
        }


    }
}
