using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using Cura.Forms;
using Cura.Forms.Common;

namespace Cura.Controls
{
    public partial class WorkerCalendarCtrl : UserControl
    {
        #region Fields
        private Worker _Worker;

        private bool isConstructed;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public WorkerCalendarCtrl()
        {
            InitializeComponent();

            vScrollBar1.Minimum = Math.Abs(worker_calendar.TimeUnitOffSetMin);
            vScrollBar1.Maximum = Math.Abs(worker_calendar.TimeUnitOffSetMax)+1;

            StartDate  = DateTime.Now;

            isConstructed = true;
        }
        #endregion

        #region Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime StartDate
        {
            get
            {
                return worker_calendar.ViewStart;
            }
            set
            {
                //DateTime startOfWeek = DateTime.Now.AddDays(-1 * (((int)DateTime.Now.DayOfWeek) - 1));
                worker_calendar.SetViewRange(value,  value.AddDays(6));

                Refresh();
            }
        }

        public Worker Worker
        {
            get
            {
                return _Worker;
            }
            set
            {
                _Worker = value;

                splitContainer1.Panel1Collapsed = value == null;
                splitContainer1.Panel2Collapsed = value != null;

                workernamelbl.Text = value == null ? "" : value.Name ;

            }
        }


        public Call SelectedItem
        {
            get
            {
                if (worker_calendar.SelectedItems.Count() == 0)
                    return null;

                return worker_calendar.SelectedItems[0].Tag as Call;
            }
        }

        public List<Call> SelectedItems
        {
            get
            {
                List<Call> calls = new List<Call>();

                foreach (CalendarItem item in worker_calendar.SelectedItems)
                    calls.Add(item.Tag as Call);

                return calls;
            }
        }
#endregion

        #region Control Load
        private void WorkerCalendarCtrl_Load(object sender, EventArgs e)
        {

            worker_calendar.Renderer.PerformLayout();

           // splitContainer1.Panel1Collapsed = (Worker != null);

        }
        #endregion

        #region Call Tooltip

        CallCoverLabelFrm frm;
        private void worker_calendar_ItemMouseHover(object sender, CalendarItemEventArgs e)
        {
            Call c = e.Item.Tag as Call;

            if (c.Workers.Count == 0)
                return;

            if (frm == null)
            {
                frm = new CallCoverLabelFrm();
            }

            
            frm.ServiceUser = c.ServiceUser;

            frm.StartTime = c.time.ToString("HH:mm");
            frm.Duration = c.Duration;

            Point loc = Cursor.Position;

            loc.X += 10;
            loc.Y += 10;

            frm.Location = loc;

            frm.Show();

        }

        private void worker_calendar_ItemMouseLeave(object sender, CalendarItemEventArgs e)
        {
            if (frm != null)
            {
                frm.Hide();
            }
        }
        #endregion

        #region Events
    
        /// <summary>
        /// Event when an item is deleted, just remove it from the worker calls, and remove the worker 
        /// from the call workers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_calendar_ItemDeleted(object sender, CalendarItemEventArgs e)
        {
            Call call = (Call)e.Item.Tag;

            Worker.Calls.Remove(call);
            call.Workers.Remove(Worker);

            call.MarkForSave = true;

            //only need to refresh this calendar, not all of them or the worker list
            Refresh();

            ServiceUserManager.Instance.RefreshControls(false, false, false);
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            worker_calendar.TimeUnitsOffset = -e.NewValue;
        }
        #endregion

        #region ContextMenuStrip Events

        private void unassignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //rmeove the current worker from all calls
            foreach (Call call in SelectedItems)
            {
                Worker.Calls.Remove(call);
                call.Workers.Remove(Worker);
            }

            RefreshItems();

            
            ServiceUserManager.Instance.RefreshCalendars(StartDate);            //only need to refresh this date!
            ServiceUserManager.Instance.RefreshLists(false, false, false);
            ServiceUserManager.Instance.RefreshHeaders();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
       //clear everything first
            setAsHolidayToolStripMenuItem.Visible = false;
            removeHolidayToolStripMenuItem.Visible = false;

            setAsSickDayToolStripMenuItem.Visible = false;
            removeSickDayToolStripMenuItem.Visible = false;

            setAsTrainingToolStripMenuItem.Visible = false;
            removeTrainingToolStripMenuItem.Visible = false;
            
            oneWeekToolStripMenuItem.Visible = false;
            twoWeeksToolStripMenuItem.Visible = false;
            otherToolStripMenuItem2.Visible = false;

            unassignToolStripMenuItem.Visible = false;

            if (SelectedItems.Count > 0)
            {
                unassignToolStripMenuItem.Visible = true;
                return;
            }


            ICalendarSelectableElement start =  worker_calendar.SelectedElementStart;
            ICalendarSelectableElement end = worker_calendar.SelectedElementEnd;

            CalendarDayTop start_day = start as CalendarDayTop;
            CalendarDayTop end_day = end as CalendarDayTop;

            CalendarTimeScaleUnit start_timeunit = start as CalendarTimeScaleUnit;
            CalendarTimeScaleUnit end_timeunit = end as CalendarTimeScaleUnit;

          
            oneWeekToolStripMenuItem.Visible = true;
            twoWeeksToolStripMenuItem.Visible = true;
            otherToolStripMenuItem2.Visible = true;

            if (start_day != null && end_day != null)
            {
                //day top clicked

                if (start_day.Date > end_day.Date)
                {
                    //swap em ;)
                    CalendarDayTop tmp = start_day;
                    start_day = end_day;
                    end_day = tmp;
                }

                if (start_day == null || end_day == null)
                {
                    //only allow training to be set if we arent selecting the whole day
                    removeTrainingToolStripMenuItem.Visible = true;
                    setAsTrainingToolStripMenuItem.Visible = true;
                }
                else
                {
                    IEnumerable<CalendarDay> daysSelected = worker_calendar.Days.Where(d => d.Date >= start_day.Date && d.Date <= end_day.Date);

                    int holidayCount = daysSelected.Where(d => d.Disabled && d.Image != null && d.Image.Tag.ToString() == "holiday").Count();
                    int sickCount = daysSelected.Where(d => d.Disabled && d.Image != null && d.Image.Tag.ToString() == "sick").Count();
                    int trainingCount = daysSelected.Where(d => d.Disabled && d.Image != null && d.Image.Tag.ToString() == "training").Count();
                    
                    if (holidayCount < daysSelected.Count())
                        setAsHolidayToolStripMenuItem.Visible = true;      //not all are holiday

                    if (sickCount < daysSelected.Count())
                        setAsSickDayToolStripMenuItem.Visible = true;       //not all are sick

                    if (trainingCount < daysSelected.Count())
                        setAsTrainingToolStripMenuItem.Visible = true;       //not all are training

                    if (holidayCount > 0)
                        removeHolidayToolStripMenuItem.Visible = true;

                    if (sickCount > 0)
                        removeSickDayToolStripMenuItem.Visible = true;

                    if (trainingCount > 0)
                        removeTrainingToolStripMenuItem.Visible = true;

                }
            }
            else if (start_timeunit != null && end_timeunit != null && !start_timeunit.Day.Disabled)
            {
                //timescaleunit clicked

                //dont need these for individual hour training
                oneWeekToolStripMenuItem.Visible = false;
                twoWeeksToolStripMenuItem.Visible = false;
                otherToolStripMenuItem2.Visible = false;



                start_day = start_timeunit.Day.DayTop;
                end_day = end_timeunit.Day.DayTop;

                IEnumerable<CalendarDay> daysSelected = worker_calendar.Days.Where(d => d.Date >= start_day.Date && d.Date <= end_day.Date);

                List<CalendarTimeScaleUnit> timeunitSelected = new List<CalendarTimeScaleUnit>();

                foreach (CalendarDay day in daysSelected)
                {
                    timeunitSelected.AddRange(day.TimeUnits.Where(t => t.Day == day && (t.Date >= start_timeunit.Date && t.Date <= end_timeunit.Date)));
                }

                int trainingCount = timeunitSelected.Where(t => t.Disabled && t.Image != null && t.Image.Tag.ToString() == "training").Count();

                if (trainingCount < timeunitSelected.Count())
                    setAsTrainingToolStripMenuItem.Visible = true;       //not all are training

                if (trainingCount > 0)
                    removeTrainingToolStripMenuItem.Visible = true;
     
            }
            else
            {
                e.Cancel = true;
                return;
            }

        }

    
        #endregion

        /// <summary>
        /// Ensure that this time is visible
        /// </summary>
        /// <param name="time"></param>
        public void EnsureVisible(DateTime time)
        {
            int h = (time.Hour > vScrollBar1.Maximum ? vScrollBar1.Maximum : time.Hour);
            vScrollBar1.Value = h;
            worker_calendar.TimeUnitsOffset = -h;
       
        }

        /// <summary>
        /// Refresh the control
        /// </summary>
        public override void Refresh()
        {
            base.Refresh();

            RefreshHolidaysAndSickDaysAndTraining();

            RefreshItems();
        }

        /// <summary>
        /// Refresh all the holiday and sick days on the calendar
        /// </summary>
        public void RefreshHolidaysAndSickDaysAndTraining()
        {
            if(Worker == null)
                return ;

            foreach (CalendarDay day in worker_calendar.Days)
            {
                day.Disabled = false;
                day.Image = null;

                foreach (CalendarTimeScaleUnit unit in day.TimeUnits)
                {
                    unit.Disabled = false;
                    unit.Image = null;
                }
            }

            foreach (CalendarDay day in worker_calendar.Days)
            {
                //check for this day in holiday and sickdays
                if(Worker.SickDays.ContainsDate(day.Date))
                {
                    day.Disabled = true;
                    day.Image = Properties.Resources.thermometer_go_icon;
                    day.Image.Tag = "sick";

                    continue;
                }else if (Worker.isDayOff(day.Date))
                {
                    day.Disabled = true;
                    day.Image = Properties.Resources.dayoff;
                    day.Image.Tag = "dayoff";

                    continue;
                }else if (Worker.Holidays.ContainsDate(day.Date))
                {
                    day.Disabled = true;
                    day.Image = Properties.Resources.transmit_go;
                    day.Image.Tag = "holiday";

                    continue;

                }else if (Worker.Training.ContainsDate(day.Date))
                {
                    day.Disabled = true;
                    day.Image = Properties.Resources.training ;
                    day.Image.Tag = "training";

                    continue;
                }
 
                foreach (CalendarTimeScaleUnit unit in day.TimeUnits)
                {
                    if (Worker.Holidays.ContainsDate(unit.Date))
                    {
                        unit.Disabled = true;
                        unit.Image = Properties.Resources.transmit_go;
                        unit.Image.Tag = "holiday";

                    }
                    else if (Worker.SickDays.ContainsDate(unit.Date))
                    {
                        unit.Disabled = true;
                        unit.Image = Properties.Resources.thermometer_go_icon;
                        unit.Image.Tag = "sick";
                    }
                    else if (Worker.Training.ContainsDate(unit.Date))
                    {
                        unit.Disabled = true;
                        unit.Image = Properties.Resources.training;
                        unit.Image.Tag = "training";
                    }
                }
            }
        }

        /// <summary>
        /// Refresh the calendar items
        /// </summary>
        public void RefreshItems()
        {
            if (DesignMode)
                return;

            worker_calendar.Items.Clear();

            if (Worker == null)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                int EarliestHour = 7;

                bool displaytraveltime = Settings.Instance.displaycallwithtraveltime;
                foreach (Call c in Worker.Calls.Where(c => !c.MarkedForDeletion))
                {
                    //add to the calendar!
                    worker_calendar.Items.Add(
                     new System.Windows.Forms.Calendar.CalendarItem(
                         worker_calendar,
                         c.time.AddMinutes(displaytraveltime?-c.traveltime_mins:0),
                         c.time.AddMinutes(c.duration_mins +( displaytraveltime ? c.traveltime_mins : 0)),
                         c.time.ToString("HH:mm") + " (" + c.duration_mins.ToString() + " min)\r\n" + c.ServiceUser.Name)
                     {
                         Tag = c,
                         Image = c.Image,
                         ImageAlign = System.Windows.Forms.Calendar.CalendarItemImageAlign.East
                     });

                    if (c.time.Hour < EarliestHour)
                    {
                        EarliestHour = c.time.Hour;
                    }
                }

                if (Math.Abs(worker_calendar.TimeUnitOffSetMin) != EarliestHour)
                {
                    worker_calendar.TimeUnitOffSetMin = -EarliestHour;
                    vScrollBar1.Minimum = Math.Abs(worker_calendar.TimeUnitOffSetMin);
                }


                //assignedTxt.Text = (Worker.Assigned_Mins_ForWeek(StartDate) / 60).ToString("0.00");
                //unassignedTxt.Text = (Worker.Unassigned_Mins_ForWeek(StartDate) / 60).ToString("0.00");
                //overtimeTxt.Text = (Worker.Overtime_Mins_ForWeek(StartDate) / 60).ToString("0.00");

            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("There was an error refreshing worker call items", ex);
            }

            Cursor = Cursors.Default;

        }

        /// <summary>
        /// Get the location of a control on the calendar
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public Rectangle CalendarLocationOnControl(Control ctrl)
        {
            Point cursorPos = ctrl.PointToClient(PointToScreen(worker_calendar.Location));

            Rectangle rect = new Rectangle(cursorPos, worker_calendar.Size);

            return rect;
        }

        /// <summary>
        /// Add business days to this date
        /// </summary>
        /// <param name="date"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        private DateTime AddBusinessDays(DateTime date, int days)
        {

            for (int i = 0; i < days; i++)
            {
                days += (date.DayOfWeek == DayOfWeek.Friday ? 2 : 0);
                date = date.AddDays(1);
            }

            return date;
        }

        #region Holiday Stuff
        private void AddHoliday(DateTime startDate, int dayCount, bool excludeweekends = false)
        {

            if (dayCount == 0)
                return;

            DateTime endDate;

            if (excludeweekends)
            {
                endDate = AddBusinessDays(startDate, dayCount);
            }
            else
            {
                endDate = startDate.AddDays(dayCount);
            }


            IEnumerable<Call> calls = Worker.Calls.Where(c => c.time >= startDate && c.time <= endDate);

            if (calls.Count() > 0)
            {
                if (MessageBox.Show("There Are Calls Assigned On This Selection. Would You Like to Unassign Them All?", "Holiday", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            foreach (Call call in calls)
            {
                call.UnassignWorkers(Worker);
            }

            //remove any of these days from teh sick days
            Worker.SickDays.RemoveDays(startDate, dayCount);
            Worker.Training.RemoveDays(startDate, dayCount);

            //add a new absence to holidays
            Worker.Holidays.Add(new Absence() { DateStart = startDate, DaysCount = dayCount, Reason = Absence.AbsenceReason.Holiday });

            if (excludeweekends)
            {
                DateTime date = startDate;

                while (date.Date < endDate.Date)
                {
                    //remove all the weekend days
                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        Worker.Holidays.RemoveDay(date.Date);
                    }

                    date = date.AddDays(1);
                }
            }

            Cursor = Cursors.WaitCursor;
            Worker.MarkForSave = true;
            Worker.Save();
            Cursor = Cursors.Default;

            WorkerManager.Instance.RefreshControls(false, false, false);
            ServiceUserManager.Instance.RefreshControls(false, false, false);
        }

        private void removeHolidayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICalendarSelectableElement start = worker_calendar.SelectedElementStart;
            ICalendarSelectableElement end = worker_calendar.SelectedElementEnd;

            CalendarDayTop start_day = start as CalendarDayTop;
            CalendarDayTop end_day = end as CalendarDayTop;

            if (start_day == null || end_day == null)
                return;

            if (start_day.Date > end_day.Date)
            {
                //swap em ;)
                CalendarDayTop tmp = start_day;
                start_day = end_day;
                end_day = tmp;
            }

            IEnumerable<CalendarDay> days = worker_calendar.Days.Where(d => d.Date >= start_day.Date && d.Date <= end_day.Date);

            Worker.Holidays.RemoveDays(days.ElementAt(0).Date, days.Count());

            Cursor = Cursors.WaitCursor;
            Worker.MarkForSave = true;
            Worker.Save();
            Cursor = Cursors.Default;

            Refresh();
        }

        
        private void selectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICalendarSelectableElement start = worker_calendar.SelectedElementStart;
            ICalendarSelectableElement end = worker_calendar.SelectedElementEnd;

            CalendarDayTop start_day = start as CalendarDayTop;
            CalendarDayTop end_day = end as CalendarDayTop;

            if (start_day == null || end_day == null)
                return;

            if (start_day.Date > end_day.Date)
            {
                //swap em ;)
                CalendarDayTop tmp = start_day;
                start_day = end_day;
                end_day = tmp;
            }

            AddHoliday(start_day.Date, (int)(end_day.Date - start_day.Date).TotalDays +1);

        }

        private void weekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICalendarSelectableElement start = worker_calendar.SelectedElementStart;
            ICalendarSelectableElement end = worker_calendar.SelectedElementEnd;

            CalendarDayTop start_day = start as CalendarDayTop;
            CalendarDayTop end_day = end as CalendarDayTop;

            if (start_day == null || end_day == null)
                return;

            if (start_day.Date > end_day.Date)
            {
                //swap em ;)
                CalendarDayTop tmp = start_day;
                start_day = end_day;
                end_day = tmp;
            }
            AddHoliday(start_day.Date, 7);

        }

        private void weeksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICalendarSelectableElement start = worker_calendar.SelectedElementStart;
            ICalendarSelectableElement end = worker_calendar.SelectedElementEnd;

            CalendarDayTop start_day = start as CalendarDayTop;
            CalendarDayTop end_day = end as CalendarDayTop;

            if (start_day == null || end_day == null)
                return;

            if (start_day.Date > end_day.Date)
            {
                //swap em ;)
                CalendarDayTop tmp = start_day;
                start_day = end_day;
                end_day = tmp;
            }
            AddHoliday(start_day.Date, 14);
        }

        private void otherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DayCountFrm frm = new DayCountFrm();
            
            if (frm.ShowDialog() != DialogResult.OK)
                return;

            ICalendarSelectableElement start = worker_calendar.SelectedElementStart;
            ICalendarSelectableElement end = worker_calendar.SelectedElementEnd;

            CalendarDayTop start_day = start as CalendarDayTop;
            CalendarDayTop end_day = end as CalendarDayTop;

            if (start_day == null || end_day == null)
                return;

            if (start_day.Date > end_day.Date)
            {
                //swap em ;)
                CalendarDayTop tmp = start_day;
                start_day = end_day;
                end_day = tmp;
            }

            AddHoliday(start_day.Date, frm.DayCount, frm.ExcludeWeekends);
           
        }

        #endregion

        #region SickDay Stuff
        private void AddSickDay(DateTime startDate, int dayCount, bool excludeweekends = false)
        {
            if (dayCount == 0)
                return;

            DateTime endDate;

            if (excludeweekends)
            {
                endDate = AddBusinessDays(startDate, dayCount);
            }
            else
            {
                endDate = startDate.AddDays(dayCount);
            }


            IEnumerable<Call> calls = Worker.Calls.Where(c => c.time >= startDate && c.time <= endDate);

            if (calls.Count() > 0)
            {
                DialogResult res = MessageBox.Show("There Are Calls Assigned On This Selection. Would You Like to Unassign Them All?", "Holiday", MessageBoxButtons.YesNoCancel);
              
                if (res == DialogResult.Cancel)
                {
                    return;
                }

                if(res == DialogResult.Yes)
                {
                    foreach (Call call in calls)
                    {
                        call.UnassignWorkers(Worker);
                    }
                }
            }

            Worker.Holidays.RemoveDays(startDate, dayCount);
            Worker.Training.RemoveDays(startDate, dayCount);

            Worker.SickDays.Add(new Absence() { DateStart = startDate, DaysCount = dayCount, Reason = Absence.AbsenceReason.Sickness });

            if (excludeweekends)
            {
                DateTime date = startDate;

                while (date.Date < endDate.Date)
                {
                    //remove all the weekend days
                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        Worker.SickDays.RemoveDay(date.Date);
                    }

                    date = date.AddDays(1);
                }
            }

            Cursor = Cursors.WaitCursor;
            Worker.MarkForSave = true;
            Worker.Save();
            Cursor = Cursors.Default;

            WorkerManager.Instance.RefreshControls(false, false, false);
            ServiceUserManager.Instance.RefreshControls(false, false, false);

        }

        private void removeSickDayToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ICalendarSelectableElement start = worker_calendar.SelectedElementStart;
            ICalendarSelectableElement end = worker_calendar.SelectedElementEnd;

            CalendarDayTop start_day = start as CalendarDayTop;
            CalendarDayTop end_day = end as CalendarDayTop;

            if (start_day == null || end_day == null)
                return;

            if (start_day.Date > end_day.Date)
            {
                //swap em ;)
                CalendarDayTop tmp = start_day;
                start_day = end_day;
                end_day = tmp;
            }

            IEnumerable<CalendarDay> days = worker_calendar.Days.Where(d => d.Date >= start_day.Date && d.Date <= end_day.Date);

            Worker.SickDays.RemoveDays(days.ElementAt(0).Date, days.Count());

            Cursor = Cursors.WaitCursor;
            Worker.MarkForSave = true;
            Worker.Save();
            Cursor = Cursors.Default;

            Refresh();

        }

        private void selectionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ICalendarSelectableElement start = worker_calendar.SelectedElementStart;
            ICalendarSelectableElement end = worker_calendar.SelectedElementEnd;

            CalendarDayTop start_day = start as CalendarDayTop;
            CalendarDayTop end_day = end as CalendarDayTop;

            if (start_day == null || end_day == null)
                return;

            if (start_day.Date > end_day.Date)
            {
                //swap em ;)
                CalendarDayTop tmp = start_day;
                start_day = end_day;
                end_day = tmp;
            }

            AddSickDay(start_day.Date, (int)(end_day.Date - start_day.Date).TotalDays+1);
        }

        private void weekToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ICalendarSelectableElement start = worker_calendar.SelectedElementStart;
            ICalendarSelectableElement end = worker_calendar.SelectedElementEnd;

            CalendarDayTop start_day = start as CalendarDayTop;
            CalendarDayTop end_day = end as CalendarDayTop;

            if (start_day == null || end_day == null)
                return;

            if (start_day.Date > end_day.Date)
            {
                //swap em ;)
                CalendarDayTop tmp = start_day;
                start_day = end_day;
                end_day = tmp;
            }
            AddSickDay(start_day.Date, 7);
        }

        private void weeksToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ICalendarSelectableElement start = worker_calendar.SelectedElementStart;
            ICalendarSelectableElement end = worker_calendar.SelectedElementEnd;

            CalendarDayTop start_day = start as CalendarDayTop;
            CalendarDayTop end_day = end as CalendarDayTop;

            if (start_day == null || end_day == null)
                return;

            if (start_day.Date > end_day.Date)
            {
                //swap em ;)
                CalendarDayTop tmp = start_day;
                start_day = end_day;
                end_day = tmp;
            }
            AddSickDay(start_day.Date, 14);
        }

        private void otherToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DayCountFrm frm = new DayCountFrm();

            if (frm.ShowDialog() != DialogResult.OK)
                return;

            ICalendarSelectableElement start = worker_calendar.SelectedElementStart;
            ICalendarSelectableElement end = worker_calendar.SelectedElementEnd;

            CalendarDayTop start_day = start as CalendarDayTop;
            CalendarDayTop end_day = end as CalendarDayTop;

            if (start_day == null || end_day == null)
                return;

            if (start_day.Date > end_day.Date)
            {
                //swap em ;)
                CalendarDayTop tmp = start_day;
                start_day = end_day;
                end_day = tmp;
            }

            AddSickDay(start_day.Date, frm.DayCount, frm.ExcludeWeekends);
        }

        #endregion

        #region Training Stuff
        private void AddTraining(DateTime startDate, int dayCount, int minuteCount = 0, bool excludeweekends = false)
        {
            if (dayCount == 0 && minuteCount == 0)
                return;

            DateTime endDate;


            if (excludeweekends)
            {
                endDate = AddBusinessDays(startDate, dayCount);
            }
            else
            {
                endDate = startDate.AddDays(dayCount);
            }

            endDate = endDate.AddMinutes(minuteCount);


            IEnumerable<Call> calls = Worker.Calls.Where(c => c.time >= startDate && c.time <= endDate);

            if (calls.Count() > 0)
            {
                if (MessageBox.Show("There Are Calls Assigned On This Selection. Would You Like to Unassign Them All?", "Training", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            foreach (Call call in calls)
            {
                call.UnassignWorkers(Worker);
            }


            Absence period = new Absence() { DateStart = startDate, DateEnd = endDate, Reason = Absence.AbsenceReason.Training };

            //remove any of these days from teh sick days
            Worker.SickDays.RemoveAbsence(period);
            Worker.Holidays.RemoveAbsence(period);

            //add a new absence to holidays
            Worker.Training.Add(period);

            if (excludeweekends)
            {
                DateTime date = startDate;

                while (date.Date < endDate.Date)
                {
                    //remove all the weekend days
                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        Worker.Training.RemoveDay(date.Date);
                    }

                    date = date.AddDays(1);
                }
            }

            Cursor = Cursors.WaitCursor;
            Worker.MarkForSave = true;
            Worker.Save();
            Cursor = Cursors.Default;

            WorkerManager.Instance.RefreshControls(false, false, false);
            ServiceUserManager.Instance.RefreshControls(false, false, false);

        }

        private void selectionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ICalendarSelectableElement start = worker_calendar.SelectedElementStart;
            ICalendarSelectableElement end = worker_calendar.SelectedElementEnd;

            CalendarDayTop start_day = start as CalendarDayTop;
            CalendarDayTop end_day = end as CalendarDayTop;

            CalendarTimeScaleUnit start_timeunit = start as CalendarTimeScaleUnit;
            CalendarTimeScaleUnit end_timeunit = end as CalendarTimeScaleUnit;


              if (start_day == null && end_day == null && start_timeunit == null && end_timeunit == null)
            {
                return;
            }else if (start_day != null && end_day != null)
            {
                //whole day selection

                if (start_day.Date > end_day.Date)
                {
                    //swap em ;)
                    CalendarDayTop tmp = start_day;
                    start_day = end_day;
                    end_day = tmp;
                }

                AddTraining(start_day.Date, (int)(end_day.Date - start_day.Date).TotalDays + 1);

            }
            else if (start_timeunit != null && end_timeunit != null)
            {
                //time unit selection

                if (start_timeunit.Date > end_timeunit.Date)
                {
                    //swap em ;)
                    CalendarTimeScaleUnit tmp = start_timeunit;
                    start_timeunit = end_timeunit;
                    end_timeunit = tmp;
                }


                AddTraining(start_timeunit.Date, 0, (int)(end_timeunit.Date - start_timeunit.Date).TotalMinutes + 60);

            }
             
        }

        private void oneWeekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICalendarSelectableElement start = worker_calendar.SelectedElementStart;
            ICalendarSelectableElement end = worker_calendar.SelectedElementEnd;

            CalendarDayTop start_day = start as CalendarDayTop;
            CalendarDayTop end_day = end as CalendarDayTop;

            if (start_day == null || end_day == null)
                return;

            if (start_day.Date > end_day.Date)
            {
                //swap em ;)
                CalendarDayTop tmp = start_day;
                start_day = end_day;
                end_day = tmp;
            }
            AddTraining(start_day.Date, 7);
        }

        private void twoWeeksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICalendarSelectableElement start = worker_calendar.SelectedElementStart;
            ICalendarSelectableElement end = worker_calendar.SelectedElementEnd;

            CalendarDayTop start_day = start as CalendarDayTop;
            CalendarDayTop end_day = end as CalendarDayTop;

            if (start_day == null || end_day == null)
                return;

            if (start_day.Date > end_day.Date)
            {
                //swap em ;)
                CalendarDayTop tmp = start_day;
                start_day = end_day;
                end_day = tmp;
            }
            AddTraining(start_day.Date, 14);
        }

        private void otherToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DayCountFrm frm = new DayCountFrm();

            if (frm.ShowDialog() != DialogResult.OK)
                return;

            ICalendarSelectableElement start = worker_calendar.SelectedElementStart;
            ICalendarSelectableElement end = worker_calendar.SelectedElementEnd;

            CalendarDayTop start_day = start as CalendarDayTop;
            CalendarDayTop end_day = end as CalendarDayTop;

            if (start_day == null || end_day == null)
                return;

            if (start_day.Date > end_day.Date)
            {
                //swap em ;)
                CalendarDayTop tmp = start_day;
                start_day = end_day;
                end_day = tmp;
            }

            AddTraining(start_day.Date, frm.DayCount, 0, frm.ExcludeWeekends);
        }

        private void removeTrainingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICalendarSelectableElement start = worker_calendar.SelectedElementStart;
            ICalendarSelectableElement end = worker_calendar.SelectedElementEnd;

            CalendarDayTop start_day = start as CalendarDayTop;
            CalendarDayTop end_day = end as CalendarDayTop;

            CalendarTimeScaleUnit start_timeunit = start as CalendarTimeScaleUnit;
            CalendarTimeScaleUnit end_timeunit = end as CalendarTimeScaleUnit;

            if (start_day == null && end_day == null && start_timeunit == null && end_timeunit == null)
            {
                return;
            }else if (start_day != null && end_day != null)
            {

                if (start_day.Date > end_day.Date)
                {
                    //swap em ;)
                    CalendarDayTop tmp = start_day;
                    start_day = end_day;
                    end_day = tmp;
                }

                IEnumerable<CalendarDay> days = worker_calendar.Days.Where(d => d.Date >= start_day.Date && d.Date <= end_day.Date);

                Worker.Training.RemoveDays(days.ElementAt(0).Date, days.Count());

            }else if (start_timeunit != null && end_timeunit != null && !start_timeunit.Day.Disabled)
            {
                //timescaleunit clicked

                start_day = start_timeunit.Day.DayTop;
                end_day = end_timeunit.Day.DayTop;

                IEnumerable<CalendarDay> daysSelected = worker_calendar.Days.Where(d => d.Date >= start_day.Date && d.Date <= end_day.Date);

                List<CalendarTimeScaleUnit> timeunitSelected = new List<CalendarTimeScaleUnit>();

                foreach (CalendarDay day in daysSelected)
                {
                    timeunitSelected.AddRange(day.TimeUnits.Where(t => t.Day == day && (t.Date >= start_timeunit.Date && t.Date <= end_timeunit.Date)));                  
                }

                foreach(CalendarTimeScaleUnit unit in timeunitSelected)
                {
                    Worker.Training.RemoveTime(unit.Date, 60);
                }
           
            
            }

            Cursor = Cursors.WaitCursor;
            Worker.MarkForSave = true;
            Worker.Save();
            Cursor = Cursors.Default;

            Refresh();
        }
        #endregion

        CalendarDayTop _tooltipShowing = null;
        private void worker_calendar_MouseEnterDayTop(object sender, CalendarDayTopEventArgs e)
        {
            //Console.WriteLine("Over Day Top");
            if (e.CalendarDayTop.Day.Image != null && e.CalendarDayTop.Day.Image.Tag != null)
            {
                switch (e.CalendarDayTop.Day.Image.Tag as string)
                {
                    case "dayoff":
                        {
                           Point p = e.CalendarDayTop.Calendar.PointToClient(MousePosition);

                           if (_tooltipShowing == e.CalendarDayTop)
                           {
                       //        dayHeaderTooltip.
                           }
                           else
                           {
                               _tooltipShowing = e.CalendarDayTop;
                               dayHeaderTooltip.IsBalloon = true;
                               dayHeaderTooltip.Hide(e.CalendarDayTop.Calendar);
                               dayHeaderTooltip.Show("day off", e.CalendarDayTop.Calendar, e.CalendarDayTop.Bounds.Left + 10, e.CalendarDayTop.Bounds.Top - (e.CalendarDayTop.Bounds.Height / 2) - 10);
                           }
                            break;
                        }

                }
            }
        }

        private void worker_calendar_MouseLeaveDayTop(object sender, CalendarDayTopEventArgs e)
        {
            dayHeaderTooltip.Hide(e.CalendarDayTop.Calendar);
            _tooltipShowing = null;
        }


  

     

    }
}
