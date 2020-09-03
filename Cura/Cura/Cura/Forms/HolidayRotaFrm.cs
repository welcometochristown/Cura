using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;

namespace Cura.Forms
{
    public partial class HolidayRotaFrm : BaseFrm
    {

        #region Fields
        private DateTime _currentMonth;
        #endregion

        #region Constructor
        public HolidayRotaFrm()
        {
            InitializeComponent();

            CurrentMonth = DateTime.Now;

            RefreshItems();
        }
        #endregion

        #region Properties
        private DateTime CurrentMonth
        {
            get
            {
                return _currentMonth;
            }
            set
            {
                _currentMonth = new DateTime(value.Year, value.Month, 1);;

                dateLbl.Text = _currentMonth.ToString("MMMM yyyy");

                holiday_calendar.SetViewRange(_currentMonth, _currentMonth.AddMonths(1).AddDays(-1));

                RefreshItems();
            }
        }
        #endregion

        #region Form Load
        private void HolidayRotaFrm_Load(object sender, EventArgs e)
        {
           
        }
        #endregion

        #region Events
        private void decMonthBtn_Click(object sender, EventArgs e)
        {
            CurrentMonth = CurrentMonth.AddMonths(-1);
        }

        private void incMonthBtn_Click(object sender, EventArgs e)
        {
            CurrentMonth = CurrentMonth.AddMonths(1);
        }

        private void holiday_calendar_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            //show worker calendar
            WorkerManager.Instance.SelectedWorker = e.Item.Tag as Worker;

        }
        #endregion

        /// <summary>
        /// Refresh Items
        /// </summary>
        public void RefreshItems()
        {
            //clear any holidays
            holiday_calendar.Items.Clear();

            List<CalendarItem> items = new List<CalendarItem>();

            foreach (Worker worker in WorkerManager.Instance.Workers.Where(w => w.idStatus != Worker.Status.Inactive && w.idStatus != Worker.Status.Deleted ))
            {
                
                foreach(Absence holiday in  worker.Holidays)
                {
                    items.Add(new CalendarItem(holiday_calendar, holiday.DateStart, holiday.DateEnd, worker.Name) 
                        { 
                            Tag = worker,
                            BackgroundColor = Color.Blue
                        }
                    );
                }

               //DateTime startofperiod = CallManager.Instance.CurrentRotaPeriodStart;

               //for (int i = 0; i < Settings.Instance.rotaweekcount; i++)
               //{
               //    foreach (System.DayOfWeek dayOff in worker.WorkingHours.WeeklyDaysOff[i])
               //    {

               //        int dayid = (int)dayOff;
               //        dayid = dayid==0?7:dayid;

               //        DateTime dayoff = startofperiod.AddDays((7 * i) + dayid);

               //        items.Add(new CalendarItem(holiday_calendar, dayoff, dayoff.AddDays(1).AddSeconds(-1), worker.Name)
               //        {
               //            Tag = worker,
               //            BackgroundColor = Color.Green
               //        }
               //    );

               //    }
               //}
            }

            holiday_calendar.Items.AddRange(items);
        }

    }
}
