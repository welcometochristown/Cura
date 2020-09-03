using Cura.Controls;
using Cura.Controls.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Cura
{
    public class WorkerManager
         : ObjectManager<Worker>
    {
        #region Fields
      //  private Worker _selectedWorker;
        private WorkerCollection  _selectedWorkers;

        private WorkerCollection _Workers;

        private List<WorkerCtrl> _WorkerCtrls;

        private WorkerListSearchBarFilter _WorkerListFilter;

        bool _isRefreshingControls;

        public bool InactiveWorkersLoaded;

        public bool IgnoreControlRefresh;

       #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        WorkerManager()
        {

            this._Workers = null;
            this._WorkerCtrls = new List<WorkerCtrl>();

            this._isRefreshingControls = false;
            this._WorkerListFilter = null;
            this.InactiveWorkersLoaded = false;

            this._selectedWorkers = null;

            this.IgnoreControlRefresh = false;

        }
        #endregion

        #region Singleton Stuff
        private static WorkerManager instance;

        public static WorkerManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WorkerManager();
                }
                return instance;
            }
        }
        #endregion

        #region Properties

        public List<WorkerCtrl> WorkerCtrls
        {
            get
            {
                return _WorkerCtrls;
            }
        }


        public WorkerCollection SelectedWorkers
        {
            get
            {
                if (_selectedWorkers == null)
                {
                    _selectedWorkers = new WorkerCollection();

                    _selectedWorkers.ObjectAdded += _selectedWorkers_Changed;
                    _selectedWorkers.ObjectRemoved += _selectedWorkers_Changed;
                }

                return _selectedWorkers;
            }
        }

     
    
        public Worker SelectedWorker
        {
            get
            {
                if (SelectedWorkers.Count == 0)
                    return null;

                return SelectedWorkers[0];
            }
            set
            {
                SelectedWorkers.Clear();
                SelectedWorkers.Add(value);
            }

        }

        public WorkerListSearchBarFilter WorkerListFilter
        {
            get
            {
                return _WorkerListFilter;
            }
            set
            {
                _WorkerListFilter = value;

                if (!isLoading)
                     RefreshControls(false, true, true);
            }
        }

        public void Unload()
        {
            SelectedWorkers.Clear();
            Workers.Clear();
           
            isLoaded = false;
        }



        public WorkerCollection Workers
        {
            get
            {
                if (_Workers == null)
                {
                    isLoaded = false;

                    //create worker collection
                    _Workers = new WorkerCollection();

                    //create event handlers
                    _Workers.ObjectAdded += new Cura.Common.Collection<Worker>.CollectionChangeEvent(this.WorkersAdded);
                    _Workers.ObjectRemoved += new Cura.Common.Collection<Worker>.CollectionChangeEvent(this.WorkersRemoved);
                }


                //load workers
                if (!isLoaded)
                {
                    LoadWorkers();

                    isLoaded = true;
                }
         

                return _Workers;
            }
        }

        public IEnumerable<Worker> ActiveWorkers
        {
            get
            {
                return Workers.Where(w => w.idStatus == Worker.Status.Active);
            }
        }

        public IEnumerable<Worker> InWorkers
        {
            get
            {
                return Workers.Where(w => w.idStatus == Worker.Status.Inactive);
            }
        }


        #endregion

        #region Enums
        public enum LoadOptions
        {
            All = 1,
            IgnoreDeleted = 2,
            IgnoreInactive = 4,
            OnlyInactive = 8
        }
        #endregion

        #region Events
        public delegate void WorkerEventHandler(Worker[] worker);

        public event WorkerEventHandler WorkersAddedEvent;
        public event WorkerEventHandler WorkersRemovedEvent;
        public event EventHandler WorkerSelectedChangedEvent;

        void _selectedWorkers_Changed(object sender, Common.CollectionChangeEventArgs args)
        {
            if (WorkerSelectedChangedEvent != null)
            {
                WorkerSelectedChangedEvent(this, null);
            }

            if (isLoading)
                return;

            RefreshControls(false, true, false);
        }


        private void WorkersAdded(object sender, Cura.Common.CollectionChangeEventArgs args) 
        { 
            if (WorkersAddedEvent != null) 
                WorkersAddedEvent(args.added.Cast<Worker>().ToArray());

            if (isLoading)
                return;

            RefreshControls(true, false, false);
        }

        private void WorkersRemoved(object sender, Cura.Common.CollectionChangeEventArgs args) 
        {
            if (WorkersRemovedEvent != null) 
                WorkersRemovedEvent(args.removed.Cast<Worker>().ToArray());

            if (isLoading)
                return;

            RefreshControls(true, false, false); 
        }
       
        #endregion

        /// <summary>
        /// Make this call visible on whatever worker calendare control its on
        /// </summary>
        /// <param name="call"></param>
        public void EnsureCallVisible(Call call)
        {

            WorkerCtrl ctrl = WorkerCtrls.SingleOrDefault(wc => wc.Calendar.StartDate <= call.time && wc.Calendar.StartDate.AddDays(7) > call.time);

            if (ctrl == null)
                return;

            ctrl.Calendar.EnsureVisible(call.time);
        }

        /// <summary>
        /// Refresh all the worker lists
        /// </summary>
        public void RefreshLists(bool WorkersChanged, bool SelectedWorkerChanged, bool WorkerFilterChanged)
        {
            if (_isRefreshingControls || IgnoreControlRefresh)
                return;

            _isRefreshingControls = true;

           // Console.WriteLine("[" + DateTime.Now.ToString() + "] Refreshing Worker Lists");
          //  Console.WriteLine("\tStackTrace: '{0}'", Environment.StackTrace);

            foreach (WorkerCtrl ctrl in _WorkerCtrls)
            {
                bool ChangeMade = false;

                //if the workers have changed then update them
                if (WorkersChanged)
                {
                    ctrl.List.Workers = Workers;
                    ChangeMade = true;
                }

                //now check whether selected workers has changed on this ctrl
                if (SelectedWorkerChanged)
                {
                    var DifferencesList = ctrl.List.SelectedItems.Where(x => !SelectedWorkers.Any(x1 => x1 == x))
                                 .Union(SelectedWorkers.Where(x => !ctrl.List.SelectedItems.Any(x1 => x1 == x)));

                    if (DifferencesList.Count() > 0)
                    {
                        ctrl.List.SelectedItems = SelectedWorkers;
                        ChangeMade = true;
                    }
                }

                //update the filter
                if (WorkerFilterChanged)
                {
                    if (ctrl.List.Filter != _WorkerListFilter)
                        ctrl.List.Filter = _WorkerListFilter;
                }

                //refresh the control
                if(ChangeMade || (!WorkersChanged && !SelectedWorkerChanged && !WorkerFilterChanged))
                    ctrl.List.Refresh();

            }

            _isRefreshingControls = false;
        }

        /// <summary>
        /// Refresh all the worker calendars
        /// </summary>
        public void RefreshCalendars(DateTime? thisDateOnly = null)
        {
            if (_isRefreshingControls || IgnoreControlRefresh)
                return;

            _isRefreshingControls = true;
        //    Console.WriteLine("[" + DateTime.Now.ToString() + "] Refreshing Worker Calendars");
         //   Console.WriteLine("\tStackTrace: '{0}'", Environment.StackTrace);


            foreach (WorkerCtrl ctrl in _WorkerCtrls)
            {

                //check if we are only updating one calendar?
                if (thisDateOnly != null &&
                         !(ctrl.Calendar.StartDate >= thisDateOnly.Value && ctrl.Calendar.StartDate < thisDateOnly.Value.AddDays(7)))
                {
                    continue;
                }

                //this will also refresh the items
                if (ctrl.List.SelectedItems.Count() != 1)
                    ctrl.Calendar.Worker = null;
                else
                    ctrl.Calendar.Worker = ctrl.List.SelectedItem;

                ctrl.Calendar.Refresh();

            }

            _isRefreshingControls = false;

        }

        /// <summary>
        /// Refresh all the worker headers
        /// </summary>
        public void RefreshHeaders()
        {
            /* anything? */
        }
        
        /// <summary>
        /// refresh all the controls
        /// </summary>
        public void RefreshControls(bool WorkersChanged = false, bool SelectedWorkerChanged = false, bool WorkerFilterChanged = false)
        {
            if (_isRefreshingControls || IgnoreControlRefresh)
                return;

            //Console.WriteLine("Refrehing Worker Controls");
            //Console.WriteLine("StackTrace: '{0}'", Environment.StackTrace);

            RefreshLists(WorkersChanged, SelectedWorkerChanged, WorkerFilterChanged);
            RefreshCalendars();
            RefreshHeaders();

        }

        /// <summary>
        /// load all the workers
        /// </summary>
        /// <param name="ignoreDeleted"></param>
        public void LoadWorkers(LoadOptions options = LoadOptions.All | LoadOptions.IgnoreDeleted )//bool ignoreDeleted = true, bool ignoreInactive = true)
        {

            if (isLoading)
                return;

            isLoading = true;

            //load here
            if (_Workers == null)
            {
                _Workers = new WorkerCollection();
            }
            else if ((options & LoadOptions.OnlyInactive) != LoadOptions.OnlyInactive)
            {
                _Workers.Clear();
            }

            InactiveWorkersLoaded = true;

            try
            {
                string query = "SELECT id, Firstname, Surname, idStatus, contactno_primary, contactno_secondary, postcode, notes, isDriver, location_longitude, location_latitude, ENumber, add1, add2 FROM tbl_Worker";

                string whereclause = "";


                if ((options & LoadOptions.OnlyInactive) == LoadOptions.OnlyInactive)
                {
                    //only load inactive workers
                    whereclause += " idStatus == " + ((int)Worker.Status.Inactive).ToString();

                }else{
                    
                    if ((options & LoadOptions.IgnoreDeleted) == LoadOptions.IgnoreDeleted)
                    {
                        if (whereclause.Length > 0)
                            whereclause += " and ";

                        whereclause += " idStatus <> " + ((int)Worker.Status.Deleted).ToString();
                    }

                    if ((options & LoadOptions.IgnoreInactive) == LoadOptions.IgnoreInactive)
                    {
                        if (whereclause.Length > 0)
                            whereclause += " and ";

                        whereclause += " idStatus <> " + ((int)Worker.Status.Inactive).ToString();

                        InactiveWorkersLoaded = false;
                    }

                }


                query += " WHERE " + whereclause;

                DataTable dt = Common.Database.ExecuteDatabaseQuery(query);

                foreach (DataRow row in dt.Rows)
                {
                    Worker w = new Worker()
                    {
                        id = Convert.ToInt32(row[0]),
                        firstname = row[1].ToString(),
                        surname = row[2].ToString(),
                        idStatus = (Worker.Status)Convert.ToInt16(row[3]),
                        contactno_primary = row[4].ToString(),
                        contactno_secondary = row[5].ToString(),
                        postcode = row[6].ToString(),
                        notes = row[7].ToString(),
                        isDriver = Convert.ToBoolean(row[8]),
                        MarkForSave = false,
                        LongLatCoords = new LongLat((row[9] == DBNull.Value ? null : row[9].ToString()), (row[10] == DBNull.Value ? null : row[10].ToString()), (row[6] == DBNull.Value ? null : row[6].ToString())),
                        ENumber = row[11].ToString(),
                        add1 = row[12].ToString(),
                        add2 = row[13].ToString()
                    };

                    //now load the holidays
                    query = "SELECT dateHoliday, duration_mins FROM tbl_Worker_Holidays WHERE idWorker = " + w.id.ToString();
                    DataTable dt_hols = Common.Database.ExecuteDatabaseQuery(query);

                    foreach (DataRow holiday_row in dt_hols.Rows)
                    {
                        w.Holidays.Add(new Absence() { 
                            DateStart = (DateTime)holiday_row[0], 
                            Duration = Convert.ToInt32(holiday_row[1]), 
                            Reason = Absence.AbsenceReason.Holiday 
                        });
                    }

                    //now load the sickdays
                    query = "SELECT dateSick, duration_mins FROM tbl_Worker_Sickness WHERE idWorker = " + w.id.ToString();
                    DataTable dt_sick = Common.Database.ExecuteDatabaseQuery(query);

                    foreach (DataRow sickness_row in dt_sick.Rows)
                    {
                        w.SickDays.Add(new Absence() { 
                            DateStart = (DateTime)sickness_row[0],
                            Duration = Convert.ToInt32(sickness_row[1]), 
                            Reason = Absence.AbsenceReason.Sickness 
                        });
                    }

                    //now load the training
                    query = "SELECT dateTraining, duration_mins FROM tbl_Worker_Training WHERE idWorker = " + w.id.ToString();
                    DataTable dt_training = Common.Database.ExecuteDatabaseQuery(query);

                    foreach (DataRow training_row in dt_training.Rows)
                    {
                        w.Training.Add(new Absence()
                        {
                            DateStart = (DateTime)training_row[0],
                            Duration = Convert.ToInt32(training_row[1]),
                            Reason = Absence.AbsenceReason.Training
                        });
                    }

                    w.ConstructOld();
                    
                    _Workers.Add(w);
               
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load all workers", ex);
            }


            isLoading = false;

        }

        /// <summary>
        /// create a new worker and addes it to the manager
        /// </summary>
        /// <returns></returns>
        public Worker NewWorker()
        {
            Worker worker = new Worker();

            Workers.Add(worker);

            return worker;
        }

    }
}
