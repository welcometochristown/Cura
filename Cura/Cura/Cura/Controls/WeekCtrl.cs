using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Cura.Controls
{
    public partial class WeekCtrl : UserControl
    {
        #region Fields
        private DateTime _PeriodStartDate;
        private DateTime _WeekStartDate;
        #endregion

        #region Constructor
        public WeekCtrl()
        {
            InitializeComponent();
        

            ////set references so that each control can reference each other directly (saves going through the main form)
            userCtrl1.WorkerCtrl = workerCtrl1;
            workerCtrl1.ServiceUserCtrl = userCtrl1;

            WorkerManager.Instance.WorkerCtrls.Add(workerCtrl1);
            ServiceUserManager.Instance.ServiceUserCtrls.Add(userCtrl1);

            //this recusivly sets any mose movement on any of the controls to fire event to here.
            TraverseControls(this, ctl => { 
                ctl.MouseMove += Form1_MouseMove; 
            });

            dragBox.MouseUp += DragBox_MouseUp;
        }

        #endregion

        #region MouseOverForm

        private void TraverseControls(Control control, Action<Control> f)
        {
            f(control);
            foreach (Control subControl in control.Controls)
                TraverseControls(subControl, f);
        }

        private Control _overControl;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            _overControl = (Control)sender;

            Point cursorPos = this.PointToClient(Cursor.Position);

            if (!dragBox.Visible) return;

            cursorPos.X -= dragBox.Width / 2;
            cursorPos.Y -= dragBox.Height / 2;

            dragBox.Location = cursorPos;
        }

        private void DragBox_MouseUp(object sender, MouseEventArgs e)
        {
            //make sure the drag  box dissapears when mouse up
            dragBox.Visible = false;
        }
        #endregion

        #region FormLoad
         private void WeekCtrl_Load(object sender, EventArgs e)
        {
            ///anthing?
           
        }
        #endregion

        #region Global Drag & Drop
        private void userCtrl1_ServiceUserGlobalMouseDown(object sender, MouseEventArgs e)
        {
            //mouse down.. draw something cool
            Point cursorPos = this.PointToClient(Cursor.Position);

            cursorPos.X -= dragBox.Width / 2;
            cursorPos.Y -= dragBox.Height / 2;

            dragBox.Location = cursorPos;

            //dragBox.BackgroundImage = userCtrl1.Calendar.SelectedItems.Count > 0 ? Properties.Resources.drag_multi : Properties.Resources.drag_single;
            dragBox.Visible = true;

        }

        private void userCtrl1_ServiceUserGlobalMouseUp(object sender, Call[] calls, MouseEventArgs e)
        {
            // mouse up.. is it over the worker calendar? then add it to the calendar.
            dragBox.Visible = false;

            Worker worker = workerCtrl1.SelectedWorker;

            if (worker == null) return;

            Rectangle rect = workerCtrl1.Calendar.CalendarLocationOnControl(this);
            Point cursorPos = this.PointToClient(Cursor.Position);

            if (rect.Contains(cursorPos))
            {

                foreach (Call call in calls)
                {
                    if (worker.Holidays.ContainsDate(call.time.Date))
                    {
                        MessageBox.Show(call.ToString() + "\r\nCant assign call on this day due to holday", "Call Assignment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        continue;
                    }

                    if (worker.SickDays.ContainsDate(call.time.Date))
                    {
                        if (MessageBox.Show(call.ToString() + "\r\nTrying to assign a call on a sick day, is this correct?", "Call Assignment", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                       {
                           continue;
                       }
                    }

                    if (call.Workers.Contains(worker))
                    {
                        MessageBox.Show(call.ToString() + "\r\nThis call is already covered by " + worker.Name, "Call Assignment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        continue ;
                    }
                    else if (call.HasFullWorkers)
                    {
                        MessageBox.Show(call.ToString() + "\r\nThis call already has the maximum amount of workers assigned", "Call Assignment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        continue;
                    }

                    //get every call from same service user and on the same date
                    IEnumerable<Call> conflictCalls = CallManager.Instance.Calls.Where(c => c.Workers.Contains(worker) && c.time.Date == call.time.Date);

                    //now check for time overlap
                    //TODO
                    foreach (Call c in conflictCalls)
                    {
                        if (call.time.AddMinutes(call.duration_mins) > c.time && call.time < c.time.AddMinutes(c.duration_mins))
                        {
                            MessageBox.Show(call.ToString() + "\r\nThis call will overlap with onother call", "Overlap", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                    }
    
                    if (!worker.isCallInsideAvailabilityHours(call))
                    {
                        DialogResult res = MessageBox.Show(call.ToString() + "\r\nThis would be outside assigned hours. Is that ok?", "Call Assignment", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                        if (res == DialogResult.No)
                        {
                            //continue with thte next one!
                            continue;
                        }
                        else if (res == DialogResult.Cancel)
                        {
                            //we are done with this loop coz the user wants to stop
                            break;
                        }
                    }

                    worker.Calls.Add(call);
                    call.Workers.Add(workerCtrl1.SelectedWorker);

                    call.MarkForSave = true;

                }

                
                WorkerManager.Instance.RefreshControls(false, false, false);
                ServiceUserManager.Instance.RefreshControls(false, false, false);

            }
        }

        #endregion

        #region Properties
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime PeriodStartDate
        {
            get
            {
                return _PeriodStartDate;
            }
            set
            {
                _PeriodStartDate = value;

                workerCtrl1.PeriodStartDate = _PeriodStartDate;
                userCtrl1.PeriodStartDate = _PeriodStartDate;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime WeekStartDate
        {
            get
            {
                return _WeekStartDate;
            }
            set
            {
                _WeekStartDate = value;

                workerCtrl1.StartDate = _WeekStartDate;
                userCtrl1.StartDate = _WeekStartDate;

                weeklabel.Text = _WeekStartDate.ToShortDateString();
            }
        }
        #endregion
       
    }
}
