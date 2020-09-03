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
using Cura.Common;

namespace Cura.Controls
{
    public partial class ServiceUserCalendarCtrl : UserControl
    {

        #region Fields
        private ServiceUser _ServiceUser;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceUserCalendarCtrl()
        {
            InitializeComponent();

        }
        #endregion

        #region Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime StartDate
        {
            get
            {
                return serviceuser_calendar.ViewStart;
            }
            set
            {

                //DateTime startOfWeek = DateTime.Now.AddDays(-1 * (((int)DateTime.Now.DayOfWeek) - 1));
                serviceuser_calendar.SetViewRange(value, value.AddDays(6));

                serviceuser_calendar.UseTOD = true;

                Refresh();

            }
        }

        public ServiceUser ServiceUser
        {
            get
            {
                return _ServiceUser;
            }
            set
            {
                if (_ServiceUser != value)
                {
                    _ServiceUser = value;
                }
   
                splitContainer1.Panel1Collapsed = value == null;
                splitContainer1.Panel2Collapsed = value != null;

                serviceusernamelbl.Text = value == null ? "" : value.Name;
            }
        }

        public Call SelectedItem
        {
            get
            {
                if( serviceuser_calendar.SelectedItems.Count() == 0)
                    return null;

                return serviceuser_calendar.SelectedItems[0].Tag as Call;
            }
        }

        public List<Call> SelectedItems
        {
            get
            {
                List<Call> calls = new List<Call>();

                foreach (CalendarItem item in serviceuser_calendar.SelectedItems)
                    calls.Add(item.Tag as Call);

                return calls;
            }
        }
        #endregion

        #region Form Load
        private void UserCalendarCtrl_Load(object sender, EventArgs e)
        {
            serviceuser_calendar.Renderer.PerformLayout();
        }
        #endregion

        #region Global Drag & Drop
        public delegate void ServiceUserDropHandler(object sender, Call [] calls, MouseEventArgs e);

        public event ServiceUserDropHandler GlobalMouseUp;
        private void calendar_GlobalMouseUp(object sender, MouseEventArgs e)
        {
            //fire an event to show that the item has been dragged using the global method. 
            //pass the service user slot.
           
            if (GlobalMouseUp != null && serviceuser_calendar.SelectedItems.Length > 0)
            {
                List<Call> selCalls = new List<Call>();

                foreach (CalendarItem item in serviceuser_calendar.SelectedItems)
                {
                    selCalls.Add(item.Tag as Call);
                }

                GlobalMouseUp(sender, selCalls.ToArray(), e);
            }
        }


       // private Call SelectedCall;
    
        public event MouseEventHandler GlobalMouseDown;
        private void calendar_GlobalMouseDown(object sender, CalendarItemEventArgs e)
        {
            if (GlobalMouseDown != null)
            {
                GlobalMouseDown(sender, null);
            }
          
        }
        #endregion

        #region Tooltip Hover
        private void singleWorkerImg_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.singleWorkerImg, "Single Worker : Assigned");
        }

        private void doubleworkerImg_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.doubleworkerImg, "Double Worker : Assigned");
        }

        private void singleworker_unassignedImg_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.singleworker_unassignedImg, "Single Worker : Unassigned");
        }

        private void doubleworker_halfunassignedImg_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.doubleworker_halfunassignedImg, "Double Worker : Half Assigned");
        }

        private void doubleworker_unassignedImg_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.doubleworker_unassignedImg, "Double Worker : Unassigned");
        }
        #endregion

        #region Call Tooltip

        CallCoverLabelFrm frm;
        private void serviceuser_calendar_ItemMouseHover(object sender, CalendarItemEventArgs e)
        {
            Call c = e.Item.Tag as Call;

            if (c.Workers.Count == 0)
                return;

            if (frm == null)
            {
                frm = new CallCoverLabelFrm();
            }


            for (int i = 0; i < c.Workers.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        frm.Worker1 = c.Workers[0];
                        break;
                    case 1:
                        frm.Worker2 = c.Workers[1];
                        break;
                }
            }

            if (c.Workers.Count < 2)
                frm.Worker2 = null;


            frm.StartTime = c.time.ToString("HH:mm");
            frm.Duration = c.Duration;

            Point loc = Cursor.Position;

            loc.X += 10;
            loc.Y += 10;

            frm.Location = loc;

            frm.Show();

        }

        private void serviceuser_calendar_ItemMouseLeave(object sender, CalendarItemEventArgs e)
        {
            if (frm != null)
            {
                frm.Hide();
            }
        }
        #endregion

        #region Call Filter Events

        private bool ValidFiltered(Call call)
        {

            switch(call.required_workers)
            {
                case 2:
                {
                    if (checkBox2.Checked && call.Workers.Count > 1)
                    {
                        //assigned double user
                        return true;
                    }

                    if (checkBox4.Checked && call.Workers.Count == 1)
                    {
                        //half unassagined double user
                        return true;
                    }

                    if (checkBox5.Checked && call.Workers.Count == 0)
                    {
                        //unassigned double user
                        return true;
                    }

                   break;
                }
                case 1:
                default:
                {
                    if (checkBox1.Checked && call.Workers.Count > 0)
                    {
                        //assigned user
                        return true;      
                    }
                     if (checkBox3.Checked && call.Workers.Count == 0)
                    {
                        //unassigned user
                        return true;   
                    }
                    break;
                }

            }
           
            return false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            RefreshItems();
        }
        #endregion

        #region Call Creation / Deletion

        public delegate void CallCoverEvent(object sender, Call call);
        //public event CallCoverEvent CallDeleted;
        //public event CallCoverEvent CallAdded;

        private void serviceuser_calendar_ItemDeleted(object sender, CalendarItemEventArgs e)
        {
            Call call = (Call)e.Item.Tag;

            call.Delete();

            //refresh the items on this calendar
            RefreshItems();


            //refresh the items on the worker calendar that has this call
            WorkerManager.Instance.RefreshCalendars(call.time);

            //refresh lists and headers
            ServiceUserManager.Instance.RefreshLists(false, false, false);
            ServiceUserManager.Instance.RefreshHeaders();

        }

        private void calendar_ItemCreating(object sender, System.Windows.Forms.Calendar.CalendarItemCancelEventArgs e)
        {

            if (e.Item.IsOnDayTop)
            {
                e.Cancel = true;
                return;
            }


            try
            {
                CallFrm frm = new CallFrm();

                frm.Date = e.Item.StartDate;
                frm.Time = e.Item.StartDate;

                switch (e.Item.StartDate.Hour)
                {
                    case 0:
                        frm.Time = frm.Time.AddHours(6);
                        break;
                    case 1:
                        frm.Time = frm.Time.AddHours(11);
                        break;
                    case 2:
                        frm.Time = frm.Time.AddHours(13);
                        break;
                    case 3:
                        frm.Time = frm.Time.AddHours(15);
                        break;
                }

                frm.ServiceUser = ServiceUser;

                if (frm.ShowDialog() == DialogResult.OK)
                {

                    Call call = CallManager.Instance.NewCall();

                    call.duration_mins = frm.Duration;
                    call.time = frm.Time;
                    call.required_workers = frm.WorkerCount;
                    call.ServiceUser = ServiceUser;
                    call.flag = frm.Flag;
                    call.notes = frm.Notes;
                    call.traveltime_mins = frm.TravelTime;

                    CallManager.Instance.Calls.Add(call);

                    ServiceUser.Calls.Add(call);

                    //now refresh the calendar items on this calendar only
                    Refresh();

                    //refresh the lists and headers
                    ServiceUserManager.Instance.RefreshLists(false, false, false);
                    ServiceUserManager.Instance.RefreshHeaders();

                    //<DEP>refresh worker calendar that has this call on
                    //WorkerManager.Instance.RefreshCalendars(call.time);

                }

                frm.Dispose();

            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("Error Creating New Call", ex);
            }

            e.Cancel = true;

        }
        #endregion

        #region Events
        private void serviceuser_calendar_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            editToolStripMenuItem_Click(this, null);
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedItem == null)
                return;

            try
            {
                Call basecall = SelectedItem;

                DuplicateCallFrm frm = new DuplicateCallFrm();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    List<Call> calls = new List<Call>();

                    DateTime d = basecall.time;

                    switch (frm.Duplication)
                    {
                        case DuplicateCallFrm.DuplicationMode.Days:

                            if (frm.DuplicateDays > 100)
                            {
                                if (MessageBox.Show("You have selected to duplicate rather a lot of calls. This may take some time. Click OK to continue", "Duplicate", MessageBoxButtons.OKCancel) != DialogResult.OK)
                                {
                                    return;
                                }
                            }

                            Loading.Instance.Start(frm.DuplicateDays);

                            for (int i = 0; i < frm.DuplicateDays; i++)
                            {
                                //set day to next day
                                d = d.AddDays(1);

                                if (frm.ExcludeWeekends && (d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday))
                                {
                                    i--;
                                    continue;
                                }

                                Call c = basecall.Duplicate();

                                c.time = d;

                                calls.Add(c);

                                Loading.Instance.Value = i;
                            }

           
                            break;
                        case DuplicateCallFrm.DuplicationMode.Weekly:

                            if (frm.DuplicateWeeks > 100)
                            {
                                if (MessageBox.Show("You have selected to duplicate rather a lot of calls. This may take some time. Click OK to continue", "Duplicate", MessageBoxButtons.OKCancel) != DialogResult.OK)
                                {
                                    return;
                                }
                            }

                            Loading.Instance.Start(frm.DuplicateWeeks);

                            for (int i = 0; i < frm.DuplicateWeeks; i++)
                            {
                                //add a week
                                d = d.AddDays(7);

                                Call c = basecall.Duplicate();

                                c.time = d;

                                calls.Add(c);

                                Loading.Instance.Value = i;
                            }

                            break;
                    }

                    CallManager.Instance.Calls.AddRange(calls);

                    ServiceUser.Calls.AddRange(calls);

                    //just refresh all the service user controls
                    ServiceUserManager.Instance.RefreshControls(false, false, false);

                    Loading.Instance.Stop();


                }
            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("Error Duplicating Call", ex);
            }

            Loading.Instance.Stop();
        }

        private void viewTop10WorkersForThisCallToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (serviceuser_calendar.SelectedItems.Count() == 0)
                return;


            Call selectedCall = serviceuser_calendar.SelectedItems[0].Tag as Call;
          
            TopCallWorkersFrm frm = new TopCallWorkersFrm()
            {
                Call = selectedCall,
                StartDate = StartDate
            };

            if (frm.ShowDialog() == DialogResult.OK)
            {
                Worker worker = frm.SelectedItem;

                worker.Calls.Add(selectedCall);
                selectedCall.Workers.Add(worker);

                selectedCall.MarkForSave = true;

                WorkerManager.Instance.RefreshCalendars(StartDate);
                ServiceUserManager.Instance.RefreshCalendars(StartDate);

            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (SelectedItems.Count() == 0)
            {
                e.Cancel = true;
            }

            bool singleselection = (SelectedItems.Count() > 1);

            duplicateToolStripMenuItem.Visible = !singleselection;
            viewTop10WorkersForThisCallToolStripMenuItem.Visible = !singleselection;
            toolStripSeparator1.Visible = !singleselection;
            cancelFutureCallsToolStripMenuItem.Visible = !singleselection;
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Call call in SelectedItems)
            {
                call.Delete();
            }

            RefreshItems();

            WorkerManager.Instance.RefreshCalendars(StartDate);                 //only refresh this date

            ServiceUserManager.Instance.RefreshLists(false, false, false);
            ServiceUserManager.Instance.RefreshHeaders();
        }

        private void flagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ts_item = sender as ToolStripMenuItem;

            if (ts_item == null)
                return;

            Call.FlagCode flagCode;

            switch (ts_item.Text)
            {
                case "Blue":
                    flagCode = Call.FlagCode.Blue;
                    break;
                case "Green":
                    flagCode = Call.FlagCode.Green;
                    break;
                case "Orange":
                    flagCode = Call.FlagCode.Orange;
                    break;
                case "Pink":
                    flagCode = Call.FlagCode.Pink;
                    break;
                case "Purple":
                    flagCode = Call.FlagCode.Purple;
                    break;
                case "Red":
                    flagCode = Call.FlagCode.Red;
                    break;
                case "Yellow":
                    flagCode = Call.FlagCode.Yellow;
                    break;
                default:
                    flagCode = Call.FlagCode.None;
                    break;
            }

            bool changed = false;

            foreach (Call call in SelectedItems)
            {
                if (call.flag == flagCode)
                    continue;

                changed = true;
                call.flag = flagCode;
                call.MarkForSave = true;     
            }

            if (changed)
                RefreshItems();
        }

        private void cancelFutureCallsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FutureCallDeletionFrm frm = new FutureCallDeletionFrm();
            if (frm.ShowDialog() == DialogResult.OK)
            {

                CalendarItem item = serviceuser_calendar.SelectedItems[serviceuser_calendar.SelectedItems.Count() - 1] as CalendarItem;
                Call call = item.Tag as Call;

                //get all future calls
                IEnumerable<Call> futurecalls = CallManager.Instance.Calls.Where(c => c.time > call.time);
                List<Call> callstodelete = new List<Call>();

                if ((frm.Result & FutureCallDeletionFrm.DeletionResult.All) == FutureCallDeletionFrm.DeletionResult.All)
                {
                    //delete all
                    //foreach (Call c in futurecalls)
                    //    c.Delete();
                    callstodelete.AddRange(futurecalls);
                }
                else
                {
                    //if neither are checked then just focus on times
                    if (((frm.Result & FutureCallDeletionFrm.DeletionResult.SameDay) != FutureCallDeletionFrm.DeletionResult.SameDay) &&
                        ((frm.Result & FutureCallDeletionFrm.DeletionResult.OtherDay) != FutureCallDeletionFrm.DeletionResult.OtherDay))
                    {
                        #region !SameDay && !OtherDay
                        //gunna be one of the other
                        if ((frm.Result & FutureCallDeletionFrm.DeletionResult.SameTime) == FutureCallDeletionFrm.DeletionResult.SameTime)
                        {
                            //foreach (Call c in futurecalls.Where(c => c.time.Hour == call.time.Hour && c.time.Minute == call.time.Minute))
                            //    c.Delete();
                            callstodelete.AddRange(futurecalls.Where(c => c.time.Hour == call.time.Hour && c.time.Minute == call.time.Minute));
                        }

                        if ((frm.Result & FutureCallDeletionFrm.DeletionResult.OtherTimes) == FutureCallDeletionFrm.DeletionResult.OtherTimes)
                        {
                            //foreach (Call c in futurecalls.Where(c => c.time.Hour != call.time.Hour && c.time.Minute != call.time.Minute))
                            //    c.Delete();

                            callstodelete.AddRange(futurecalls.Where(c => c.time.Hour != call.time.Hour && c.time.Minute != call.time.Minute));
                        }
                        #endregion
                    }
                    else
                    {
                        #region SameDay
                        if ((frm.Result & FutureCallDeletionFrm.DeletionResult.SameDay) == FutureCallDeletionFrm.DeletionResult.SameDay)
                        {
                            //delete 

                            if (((frm.Result & FutureCallDeletionFrm.DeletionResult.SameTime) != FutureCallDeletionFrm.DeletionResult.SameTime) &&
                                ((frm.Result & FutureCallDeletionFrm.DeletionResult.OtherTimes) != FutureCallDeletionFrm.DeletionResult.OtherTimes))
                            {
                                //foreach (Call c in futurecalls.Where(c => c.time.DayOfWeek == call.time.DayOfWeek))
                                //    c.Delete();
                                callstodelete.AddRange(futurecalls.Where(c => c.time.DayOfWeek == call.time.DayOfWeek));
                            }
                            else
                            {
                                if ((frm.Result & FutureCallDeletionFrm.DeletionResult.SameTime) == FutureCallDeletionFrm.DeletionResult.SameTime)
                                {
                                    //foreach (Call c in futurecalls.Where(c => c.time.DayOfWeek == call.time.DayOfWeek && c.time.Hour == call.time.Hour && c.time.Minute == call.time.Minute))
                                    //    c.Delete();

                                    callstodelete.AddRange( futurecalls.Where(c => c.time.DayOfWeek == call.time.DayOfWeek && c.time.Hour == call.time.Hour && c.time.Minute == call.time.Minute));
                                }

                                if ((frm.Result & FutureCallDeletionFrm.DeletionResult.OtherTimes) == FutureCallDeletionFrm.DeletionResult.OtherTimes)
                                {
                                    //foreach (Call c in futurecalls.Where(c => c.time.DayOfWeek == call.time.DayOfWeek && c.time.Hour != call.time.Hour && c.time.Minute != call.time.Minute))
                                    //    c.Delete();

                                    callstodelete.AddRange(futurecalls.Where(c => c.time.DayOfWeek == call.time.DayOfWeek && c.time.Hour != call.time.Hour && c.time.Minute != call.time.Minute));
                                }

                            }

                        }
                        #endregion

                        #region OtherDay
                        if ((frm.Result & FutureCallDeletionFrm.DeletionResult.OtherDay) == FutureCallDeletionFrm.DeletionResult.OtherDay)
                        {

                            if (((frm.Result & FutureCallDeletionFrm.DeletionResult.SameTime) != FutureCallDeletionFrm.DeletionResult.SameTime) &&
                                ((frm.Result & FutureCallDeletionFrm.DeletionResult.OtherTimes) != FutureCallDeletionFrm.DeletionResult.OtherTimes))
                            {
                                //foreach (Call c in futurecalls.Where(c => c.time.DayOfWeek != call.time.DayOfWeek))
                                //    c.Delete();

                                callstodelete.AddRange(futurecalls.Where(c => c.time.DayOfWeek != call.time.DayOfWeek));
                            }
                            else
                            {
                                //delete 
                                if ((frm.Result & FutureCallDeletionFrm.DeletionResult.SameTime) == FutureCallDeletionFrm.DeletionResult.SameTime)
                                {
                                    //foreach (Call c in futurecalls.Where(c => c.time.DayOfWeek != call.time.DayOfWeek && c.time.Hour == call.time.Hour && c.time.Minute == call.time.Minute))
                                    //    c.Delete();

                                    callstodelete.AddRange(futurecalls.Where(c => c.time.DayOfWeek != call.time.DayOfWeek && c.time.Hour == call.time.Hour && c.time.Minute == call.time.Minute));
                                }

                                if ((frm.Result & FutureCallDeletionFrm.DeletionResult.OtherTimes) == FutureCallDeletionFrm.DeletionResult.OtherTimes)
                                {
                                    //foreach (Call c in futurecalls.Where(c => c.time.DayOfWeek != call.time.DayOfWeek && c.time.Hour != call.time.Hour && c.time.Minute != call.time.Minute))
                                    //    c.Delete();

                                    callstodelete.AddRange(futurecalls.Where(c => c.time.DayOfWeek != call.time.DayOfWeek && c.time.Hour != call.time.Hour && c.time.Minute != call.time.Minute));
                                }
                            }


                        }
                        #endregion

                    }
                }

                if(callstodelete.Count > 0)
                {
                    if(callstodelete.Count > 100)
                    {
                        if(MessageBox.Show("There are rather a lot of calls to delete [" + callstodelete.Count.ToString() + "]. Press OK to continue", "Delete Calls", MessageBoxButtons.OKCancel) !=DialogResult.OK)
                            return;
                    }

                    Loading.Instance.Start(callstodelete.Count);

                    for(int i = 0; i < callstodelete.Count; i++)
                    {
                        Call c = callstodelete[i] as Call;
                        c.Delete();
                    }

                    Loading.Instance.Stop();

                    //refresh all the service user controls
                    ServiceUserManager.Instance.RefreshControls(false, false ,false);
                    

                    //just update the worker calendars
                    WorkerManager.Instance.RefreshCalendars();
                }

            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedItem == null)
                return;

            Cursor = Cursors.WaitCursor;

            Call call = SelectedItem;

            try
            {

                CallFrm frm = new CallFrm()
                {
                    ID = call.ID,
                    Flag = call.flag,
                    Notes = call.notes,
                    Date = call.time,
                    Duration = call.duration_mins,
                    Time = call.time,
                    WorkerCount = call.required_workers,
                    ServiceUser = ServiceUser,
                    TravelTime = call.traveltime_mins,
                    Title = "Edit Call"
                };

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //add this user to the database

                    call.flag = frm.Flag;
                    call.notes = frm.Notes;
                    call.time = frm.Time;
                    call.duration_mins = frm.Duration;
                    call.traveltime_mins = frm.TravelTime;

                    //attempt to save
                    try
                    {
                        call.MarkForSave = true;

                    }
                    catch (Exception ex)
                    {
                        Cura.Common.Common.LogError("Error Occured While Trying To Save This Call", ex);
                    }

                    //refresh items on this calendar
                    RefreshItems();

                    //refresh items on the worker calendar
                    WorkerManager.Instance.RefreshCalendars(call.time);
                }
                frm.Dispose();
            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("Error Creating New Worker", ex);
            }
        }

        #endregion

        /// <summary>
        /// Refresh this control
        /// </summary>
        public override void Refresh()
        {
            base.Refresh();

            RefreshItems();
        }

        /// <summary>
        /// Refresh the items on the calendar
        /// </summary>
        public void RefreshItems()
        {
       
            if (DesignMode)
                return;

            serviceuser_calendar.Items.Clear();

            if (_ServiceUser == null)
                return;

            Cursor = Cursors.WaitCursor;
  
            foreach (CalendarDay day in serviceuser_calendar.Days)
            {
                day.Image = null;

                if (day.Date > _ServiceUser.ServiceBegins_Clean && day.Date < _ServiceUser.ServiceEnds)
                {
                    day.Image = Properties.Resources.lightning_go;
                    day.Image.Tag = "service period";

                }
            }

            try
            {
                foreach (Call call in _ServiceUser.Calls.Where(c => !c.MarkedForDeletion))
                {

                    if (!ValidFiltered(call))
                        continue;

                    DateTime fakeTime;

                    int hoursToRemove = call.time.Hour;
                    int minutesToRemove = call.time.Minute;

                    int addition = 1;

                    if (call.time.Hour >= 18)
                    {
                        //evening
                        fakeTime = call.time.AddHours(-hoursToRemove + 3).AddMinutes(-minutesToRemove);
                    }
                    else if (call.time.Hour >= 15)
                    {
                        if (call.TimeTo.Hour >= 18)
                            addition += 1;
                        //afternoon
                        fakeTime = call.time.AddHours(-hoursToRemove + 2).AddMinutes(-minutesToRemove);
                    }
                    else if (call.time.Hour >= 12)
                    {
                        if (call.TimeTo.Hour >= 15)
                            addition += 1;
                        if (call.TimeTo.Hour >= 18)
                            addition += 1;
                        //lunch
                        fakeTime = call.time.AddHours(-hoursToRemove + 1).AddMinutes(-minutesToRemove);
                    }
                    else
                    {
                        if (call.TimeTo.Hour >= 12)
                            addition += 1;
                        if (call.TimeTo.Hour >= 15)
                            addition += 1;
                        if (call.TimeTo.Hour >= 18)
                            addition += 1;
                        //morning
                        fakeTime = call.time.AddHours(-hoursToRemove + 0).AddMinutes(-minutesToRemove);
                    }

                    string covertxt;

                    if (call.Workers.Count == 0)
                    {
                        covertxt = "Uncovered";
                    }
                    else
                    {
                        covertxt = "";

                        foreach (Worker worker in call.Workers)
                            covertxt += worker.Name + ",";

                        covertxt = covertxt.Trim(new char[] { ',' });

                    }

                    CalendarItem newitem = new System.Windows.Forms.Calendar.CalendarItem(
                              serviceuser_calendar,
                              fakeTime,
                              fakeTime.AddHours(addition),
                              call.time.ToString("HH:mm") + "\r\n" + call.Duration)
                          {
                              Tag = call,
                              Image = call.Image,
                              ImageAlign = System.Windows.Forms.Calendar.CalendarItemImageAlign.East
                          };


                    if (!call.HasFullWorkers)
                    {
                        newitem.BackgroundColor = Color.White;
                        newitem.BackgroundColorLighter = Color.White;
                    }

                    serviceuser_calendar.Items.Add(newitem);
                }

                //callsTxt.Text = (ServiceUser.TotalCallTime_Mins_ForWeek(StartDate) / 60).ToString("0.00");
                //assignedTxt.Text = (ServiceUser.TotalCallTimeCovered_Mins_ForWeek(StartDate) / 60).ToString("0.00");
                //unassignedTxt.Text = (ServiceUser.TotalCallTimeUnCovered_Mins_ForWeek(StartDate) / 60).ToString("0.00");
            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("There was an error refreshing service user call items", ex);
            }
            Cursor = Cursors.Default;
        }

    }
}
