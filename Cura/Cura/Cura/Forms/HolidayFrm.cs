using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cura.Forms
{
    public partial class HolidayFrm : BaseFrm
    {
        #region Fields
        private DateTime currentMonth;
        #endregion

        #region Constructor
        public HolidayFrm()
        {
            InitializeComponent();

            SetMonth(DateTime.Now);
        }

        #endregion

        #region Events
        private void nextMonth_Click(object sender, EventArgs e)
        {
            SetMonth(currentMonth.AddMonths(1));
        }

        private void prevMonth_Click(object sender, EventArgs e)
        {
            SetMonth(currentMonth.AddMonths(-1));
        }
        #endregion

        /// <summary>
        /// Set the month being viewed
        /// </summary>
        /// <param name="date"></param>
        public void SetMonth(DateTime date)
        {
            DateTime firstofmonth = new DateTime(date.Year, date.Month, 1);

            currentMonth = firstofmonth;

            holidayCtrl1.StartDate = firstofmonth;

            holidayCtrl1.days = firstofmonth.AddMonths(1).AddDays(-1).Day;

            holidayCtrl1.Workers = WorkerManager.Instance.Workers;

            monthLbl.Text = date.ToString("MMMM yyyy");

            holidayCtrl1.RedrawDays();
        }

        
    }
}
