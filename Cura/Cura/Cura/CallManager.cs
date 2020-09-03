using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

using Cura.Controls;
using System.Data;

namespace Cura
{
    class CallManager
        : ObjectManager<Call>
    {
        #region Fields
         private CallCollection _Calls;

         //public WorkerCtrl WorkerCtrl;
         //public ServiceUserCtrl UserCtrl;

         private DateTime _CurrentRotaPeriodStart;

         private bool _isUndoingPendingChanges;
        #endregion

        #region Constructor
        /// <summary>
       /// Consructor
       /// </summary>
        private CallManager()
        {
            this._Calls = null;

       
        }
        #endregion

        #region Events

        public event EventHandler CallChange;

        private void CallsAdded(object sender, Cura.Common.CollectionChangeEventArgs args)
        {
            foreach (Call call in args.added)
            {
                call.CallChanged += CallChangedEvent;
            }

            CallChangedEvent(this, null);
        }
        private void CallsRemoved(object sender, Cura.Common.CollectionChangeEventArgs args)
        {
            foreach (Call call in args.removed)
            {
                call.CallChanged -= CallChangedEvent;
            }

            CallChangedEvent(this, null);
        }

        private void CallChangedEvent(object sender, EventArgs args)
        {
            if (isLoading || _isUndoingPendingChanges)
                return;

            //no this is bad.. too much refreshing makes jack a dull boy
            //WorkerManager.Instance.RefreshControls();
            //ServiceUserManager.Instance.RefreshControls();

            if (CallChange != null)
                CallChange(this, args);
        }
       
#endregion

        #region Singleton Stuff
        private static CallManager instance;

        public static CallManager Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new CallManager();
                }
                return instance;
            }
        }
        #endregion

        #region Properties
        public IEnumerable<Call> CallsThisPeriod
        {
            get
            {
                DateTime periodStart = CallManager.Instance.CurrentRotaPeriodStart;
                DateTime periodEnd = periodStart.AddDays(7 * Settings.Instance.rotaweekcount);

                return CallManager.Instance.Calls.Where(c => (c.TimeTo >= periodStart && c.TimeFrom < periodEnd));

            }
        }

        public IEnumerable<Call> UnassignedCallsThisPeriod
        {
            get
            {
                return CallsThisPeriod.Where(c => c.required_workers > c.Workers.Count && !c.MarkedForDeletion);

            }
        }

        public IEnumerable<Call> AssignedCallsThisPeriod
        {
            get
            {
                return CallsThisPeriod.Where(c => c.required_workers == c.Workers.Count && !c.MarkedForDeletion);

            }
        }

        public DateTime CurrentRotaPeriodStart
        {
            get
            {
                return _CurrentRotaPeriodStart;
            }
            set
            {
                if (_CurrentRotaPeriodStart != value)
                {
                    LoadCalls(value);
                }

                _CurrentRotaPeriodStart = value;

            }
        }

        public bool HasChanges
        {
            get
            {
                foreach (Call c in Calls)
                {
                    if (c.MarkForSave && c.HasChanges)
                        return true;
                }

                return false;
            }
        }

        public CallCollection Calls
        {
            get
            {
                if (_Calls == null)
                {
                    isLoaded = false;

                    //create the call collection
                    _Calls = new CallCollection();

                    //add event handlers
                    _Calls.ObjectAdded += new Common.Collection<Call>.CollectionChangeEvent(this.CallsAdded);
                    _Calls.ObjectRemoved += new Common.Collection<Call>.CollectionChangeEvent(this.CallsRemoved);
    
                }

                if (!isLoaded && !isLoading)
                {
                    //load the calls
                    LoadCalls(_CurrentRotaPeriodStart);

                    isLoaded = true;
                }

                return _Calls;
            }
        }

        public IEnumerable<Call> UnassignedCalls
        {
            get
            {
                return Calls.Where(c => c.required_workers > c.Workers.Count && !c.MarkedForDeletion);

            }
        }

        public IEnumerable<Call> AssignedCalls
        {
            get
            {
                return Calls.Where(c => c.required_workers == c.Workers.Count && !c.MarkedForDeletion);

            }
        }
        #endregion

        /// <summary>
        /// Undo pending changes for each call!
        /// </summary>
        public void UndoPendingChanges()
        {
            //mark that we are doing some undoing of pending changes, need to stop constant refreshing 
            _isUndoingPendingChanges = true;

            foreach (Call c in Calls)
            {
                //check that this call is marked for saving and that there are actually changes to save.
                if (c.MarkForSave && c.HasChanges)
                {
                    c.UndoPendingChanges();
                }
            }

            _isUndoingPendingChanges = false;

            //fire this back up to the MainForm
            CallChangedEvent(this, null);
        }

        /// <summary>
        /// Unload all the data
        /// </summary>
        public void Unload()
        {

            ClearAllCalls();

            isLoaded = false;
        }

        /// <summary>
        /// Clear the calls
        /// </summary>
        private void ClearAllCalls()
        {

            foreach (Worker worker in WorkerManager.Instance.Workers.Where(w => w.Calls.Count > 0))
            {
                worker.Calls.Clear();
            }

            foreach (ServiceUser serviceuser in ServiceUserManager.Instance.ServiceUsers.Where(s => s.Calls.Count > 0))
            {
                serviceuser.Calls.Clear();
            }

            Calls.Clear();

        }

        /// <summary>
        /// Load all the calls in the database
        /// </summary>
        public void LoadCalls(DateTime periodStart)
        {

            if (isLoading)
                return;

            //Console.WriteLine("[" + DateTime.Now.ToString() + "] Loading Calls");
            //Console.WriteLine("\tStackTrace: '{0}'", Environment.StackTrace);
            isLoading = true;


            ClearAllCalls();


            if (periodStart != null && periodStart != DateTime.MinValue )
            {
                DateTime start = periodStart;
                DateTime end = start.AddDays(7 * Settings.Instance.rotaweekcount);

                //load all calls here
                DataTable dt = Common.Database.ExecuteDatabaseQuery("SELECT  C.id, C.idServiceUser, C.timeOfCall, C.duration, C.required_workers, C.notes, C.flagcode, C.traveltime FROM tbl_Calls C WHERE C.timeOfCall >= '" + start.ToString("yyyy-MM-dd") + "' and C.timeOfCall < '" + end.ToString("yyyy-MM-dd") + "'");

                //try and assign id
                try
                {

                 //   Console.WriteLine("Loaded [" + dt.Rows.Count.ToString() + "] Calls");

                    foreach (DataRow row in dt.Rows)
                    {
                        Call call = new Call();

                        call.ID = Convert.ToInt32(row[0]);
                        call.idServiceUser = Convert.ToInt32(row[1]);
                        call.time = (DateTime)row[2];
                        call.duration_mins = Convert.ToInt32(row[3]);
                        call.required_workers = Convert.ToInt32(row[4]);
                        call.notes = row[5].ToString();
                        call.flag = (Call.FlagCode)Convert.ToInt32(row[6]);
                        call.MarkForSave = false;
                        call.traveltime_mins = Convert.ToInt32(row[7]);

                        //set service user reference
                        ServiceUser user = ServiceUserManager.Instance.ServiceUsers.SingleOrDefault(s => s.id == call.idServiceUser);
                        user.Calls.Add(call);
                        call.ServiceUser = user;

                        //now the workers
                        dt = Common.Database.ExecuteDatabaseQuery("SELECT idCall, idWorker FROM tbl_Worker_Calls WHERE idCall = " + call.ID.ToString());

                        foreach (DataRow w_row in dt.Rows)
                        {
                            Worker worker = WorkerManager.Instance.Workers.SingleOrDefault(w => w.id == Convert.ToInt32(w_row[1]));
                            worker.Calls.Add(call);
                            call.Workers.Add(worker);

                        }

                        //IMPORTANT FOR DATABASE!
                        call.ConstructOld();

                        Calls.Add(call);
                    }


                   // Console.WriteLine("Calls Now Contains [" + Calls.Count.ToString() + "] Calls");
                    isLoaded = true;

                }
                catch (Exception ex)
                {
                    throw new Exception("Failed To Load Calls", ex);
                }
            }

            isLoading = false;

            if (CallChange != null)
                CallChange(this, null);


            WorkerManager.Instance.RefreshCalendars();
            ServiceUserManager.Instance.RefreshControls(false, false, false);
        }

        /// <summary>
        /// Create a new call (also add it to the call list)
        /// </summary>
        /// <returns></returns>
        public Call NewCall()
        {
            return new Call();
        }

    }
}
