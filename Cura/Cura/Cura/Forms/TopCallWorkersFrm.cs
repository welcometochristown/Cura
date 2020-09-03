using Cura.Common;
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
    public partial class TopCallWorkersFrm : BaseFrm
    {
        #region Fields
        public Call Call;
        public DateTime StartDate;
        #endregion

        #region Constructor
        public TopCallWorkersFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public Worker SelectedItem
        {
            get
            {
                if (listView1.SelectedItem == null)
                    return null;

                return (listView1.SelectedItem.RowObject as TopWorkersViewModel).worker;
            }
        }
        #endregion
        
        #region Form Load
        private void TopCallWorkersFrm_Load(object sender, EventArgs e)
        {
            if (Call == null)
                return;

            //show which call this is
            callLbl.Text = Call.ToString();

            //get the service user for this call
            ServiceUser serviceuser = Call.ServiceUser;

            ////this is the list of workers to add to the list
            List<TopWorkersViewModel> workersToAdd = new List<TopWorkersViewModel>();


            //Get infor for every active worker
            foreach (Worker worker in  WorkerManager.Instance.ActiveWorkers)
            {

                //first lets get distance
                double miles = -1;

                if (worker.LongLatCoords != null && worker.LongLatCoords.HasLongLat)
                {
                    try
                    {
                        miles = GoogleMaps.GetDistance(worker.LongLatCoords, serviceuser.LongLatCoords, "M");
                    }
                    catch (Exception ex) { }
                }

                //now whether they are a keyworker
                bool isKeyWorker = serviceuser.KeyWorkers.Contains(worker);

                //no 
                Image img = null;

                if (isKeyWorker)
                    img = Cura.Properties.Resources.key;

                //now get the time unassigned
                int minutes_unassinged = worker.Unassigned_Mins_ForWeek(StartDate);

                //ignore people without any of this information!
                if (minutes_unassinged == 0 && !isKeyWorker && miles < 0)
                    continue;

                workersToAdd.Add(
                    new TopWorkersViewModel() { 
                        worker = worker,
                        distance_miles = miles,
                        isKeyWorker = isKeyWorker,
                        image = img,
                        mins_workingtime_unassigned = minutes_unassinged
                    }
                );
            }


            IEnumerable<TopWorkersViewModel> res = workersToAdd.OrderByDescending(w => w.isKeyWorker).ThenBy(w => w.distance_miles).ThenByDescending(w => w.mins_workingtime_unassigned).Take(10);

            int index = 1;
            foreach (TopWorkersViewModel model in res)
            {
                model.index = index++;
            }

            ////hours remaining
           listView1.SetObjects(res);



            ////distance
            ////get the closest remaining who aren't key workers

            //Dictionary<Worker, double> WorkerMiles = new Dictionary<Worker, double>();

            //if (serviceuser.LongLatCoords != null && serviceuser.LongLatCoords.HasLongLat)
            //{
            //    foreach (Worker worker in WorkerManager.Instance.Workers.Where(w => !serviceuser.KeyWorkers.Contains(w)))
            //    {
            //        if (worker.LongLatCoords == null || !worker.LongLatCoords.HasLongLat)
            //            continue ;

            //        double miles = GoogleMaps.GetDistance(worker.LongLatCoords, serviceuser.LongLatCoords, "M");

            //        WorkerMiles.Add(worker, miles);
            //    }
            //}



            ////FIRST DO THE KEYWORKERS
            //foreach (Worker worker in serviceuser.KeyWorkers)
            //{ 
            //    if (remaining == 0)
            //        break;

            //    double miles = -1;

            //    if (worker.LongLatCoords != null && worker.LongLatCoords.HasLongLat)
            //    {
            //        try
            //        {
            //            miles = GoogleMaps.GetDistance(worker.LongLatCoords, serviceuser.LongLatCoords, "M");
            //        }catch(Exception ex){}
            //    }

            //    workersToAdd.Add(new TopWorkersViewModel() { worker = worker, distance_miles = miles, isKeyWorker = true, image = ImageGenerator.Instance.GenerateWorkerImage(ImageGenerator.WorkerImageGen.Key), mins_workingtime_unassigned = worker.Unassigned_Mins_ForWeek(StartDate) });
            //    remaining -= 1;
            //}


            ////NOW DO THE PEOPLE THAT ARE CLOSEST BUT NOT KEY WORKERS
            // foreach(KeyValuePair<Worker, double> pair in WorkerMiles)
            //{
            //    if (remaining == 0)
            //        break;

            //    workersToAdd.Add(new TopWorkersViewModel() { worker = pair.Key, distance_miles = pair.Value, isKeyWorker = false, mins_workingtime_unassigned = pair.Key.Unassigned_Mins_ForWeek(StartDate) });

            //    remaining -= 1;
            //}


            //IEnumerable<Worker> list1 = WorkerManager.Instance.Workers;
            //list1.OrderByDescending(w => w.Unassigned_Mins_ForWeek(StartDate));

            // foreach (Worker worker in list1)
            // {
            //     if (remaining == 0)
            //         break;

            //     workersToAdd.Add(new TopWorkersViewModel() { worker = worker, isKeyWorker = false, mins_workingtime_unassigned = worker.Unassigned_Mins_ForWeek(StartDate) });

            //     remaining -= 1;
            // }


           //  workersToAdd.OrderBy(w => w.isKeyWorker).ThenBy(w => w.distance_miles).ThenBy(w => w.mins_workingtime_unassigned);

            ////hours remaining
            //listView1.SetObjects(workersToAdd);

            
        } 
        #endregion

        #region Events
 
        private void TopCallWorkersFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != System.Windows.Forms.DialogResult.OK)
                return;

            Worker worker = SelectedItem;

            if (worker == null)
            {
                MessageBox.Show("You need to select a worker to cover this call");
                e.Cancel = true;
                return;
            }

            if (worker.Holidays.ContainsDate(Call.time.Date))
            {
                MessageBox.Show("Cant assign call on this day due to holday", "Call Assignment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }

            if (worker.SickDays.ContainsDate(Call.time.Date))
            {
                if (MessageBox.Show("Trying to assign a call on a sick day, is this correct?", "Call Assignment", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            if (Call.Workers.Contains(worker))
            {
                MessageBox.Show("This call is already covered by " + worker.Name, "Call Assignment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
            else if (Call.HasFullWorkers)
            {
                MessageBox.Show("This call already has the maximum amount of workers assigned", "Call Assignment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return; ;
            }

            //get every call from same service user and on the same date
            IEnumerable<Call> conflictCalls = CallManager.Instance.Calls.Where(c => c.Workers.Contains(worker) && c.time.Date == Call.time.Date);

            //now check for time overlap
            foreach (Call c in conflictCalls)
            {
                if (Call.time.AddMinutes(Call.duration_mins) > c.time && Call.time < c.time.AddMinutes(c.duration_mins))
                {
                    MessageBox.Show("This call will overlap with onother call", "Overlap", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return; ;
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            exButton1.Enabled = SelectedItem != null;
        }
        #endregion

    }
}
