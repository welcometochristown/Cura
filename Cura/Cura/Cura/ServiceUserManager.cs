using Cura.Common;
using Cura.Controls;
using Cura.Controls.Common;
using Cura.Forms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;


namespace Cura
{
    public class ServiceUserManager
        :ObjectManager<ServiceUser>
    {

        #region Fields
        private ServiceUserCollection  _selectedServiceUsers;

        private ServiceUserCollection _ServiceUsers;

        private List<ServiceUserCtrl> _serviceUserCtrls;
        
        private ServiceUserListSearchBarFilter _ServiceUserListFilter;

        private bool _isRefreshingControls;
        private bool _isUpdatingSelectedServiceUser;

        public bool IgnoreControlRefresh;

       #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        ServiceUserManager()
        {
            this._ServiceUsers = null;

            _serviceUserCtrls = new List<ServiceUserCtrl>();

            this._isRefreshingControls = false;
            this._isUpdatingSelectedServiceUser = false;

            this._ServiceUserListFilter = null;

            this.IgnoreControlRefresh = false;

        }
        #endregion

        #region Singleton Stuff
        private static ServiceUserManager instance;

        public static ServiceUserManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceUserManager();
                }
                return instance;
            }
        }
        #endregion

        #region Properties
        public bool IsRefreshing
        {
            get{
                return _isRefreshingControls;
            }
        }

        public bool IsUpdatingSelectedServiceUser
        {
            get
            {
                return _isUpdatingSelectedServiceUser;
            }
        }


        public ServiceUserCollection SelectedServiceUsers
        {
            get
            {
                if (_selectedServiceUsers == null)
                {
                    _selectedServiceUsers = new ServiceUserCollection();

                    _selectedServiceUsers.ObjectAdded += _selectedServiceUsers_Changed;
                    _selectedServiceUsers.ObjectRemoved += _selectedServiceUsers_Changed;
                }

                return _selectedServiceUsers;
            }
        }


        void _selectedServiceUsers_Changed(object sender, Common.CollectionChangeEventArgs args)
        {
            if (ServiceUserSelectedChangedEvent  != null)
            {
                ServiceUserSelectedChangedEvent(this, null);
            }

            if (isLoading)
                return;

            RefreshControls(false,true, false);
        }


        public List<ServiceUserCtrl> ServiceUserCtrls
        {
            get
            {
                return _serviceUserCtrls;
            }
        }
   
        public ServiceUserCollection ServiceUsers
        {
            get
            {
                if (_ServiceUsers == null)
                {
                    isLoaded = false;

                    //create the collection of service users
                    _ServiceUsers = new ServiceUserCollection();

                    //add event handlers
                    ServiceUsers.ObjectAdded += new Cura.Common.Collection<ServiceUser>.CollectionChangeEvent(this.ServiceUsersAdded);
                    ServiceUsers.ObjectRemoved += new Cura.Common.Collection<ServiceUser>.CollectionChangeEvent(this.ServiceUsersRemoved);
                }

                if (!isLoaded)
                {
                    //load service users
                    LoadServiceUsers();

                    isLoaded = true;
                }

                return _ServiceUsers;
            }
        }

        public ServiceUserListSearchBarFilter ServiceUserListFilter
        {
            get
            {
                return _ServiceUserListFilter;
            }
            set
            {
                _ServiceUserListFilter = value;

                if (!isLoading)
                    RefreshControls(false, true, true);
            }
        }

        #endregion

        #region Events

        public delegate void ServiceUserEventHandler(ServiceUser[] worker);

        public event ServiceUserEventHandler ServiceUsersAddedEvent;
        public event ServiceUserEventHandler ServiceUsersRemovedEvent;
        public event EventHandler ServiceUserSelectedChangedEvent;

        private void ServiceUsersAdded(object sender, Cura.Common.CollectionChangeEventArgs args)
        {
            if (ServiceUsersAddedEvent != null)
                ServiceUsersAddedEvent(args.added.Cast<ServiceUser>().ToArray());

            if (isLoading)
                return;

            RefreshControls(true);
        }
        private void ServiceUsersRemoved(object sender, Cura.Common.CollectionChangeEventArgs args)
        {
            if (ServiceUsersRemovedEvent != null)
                ServiceUsersRemovedEvent(args.removed.Cast<ServiceUser>().ToArray());

            if (isLoading)
                return;

            RefreshControls(true);
        }

        #endregion

        //Clear all the data
        public void Unload()
        {
            SelectedServiceUsers.Clear();
            ServiceUsers.Clear();

            isLoaded = false;
        }

        /// <summary>
        /// Refresh all the service user lists
        /// </summary>
        public void RefreshLists(bool ServiceUsersChanged, bool SelectedServiceuserChanged, bool ServiceUserFilterChanged)
        {
            if (_isRefreshingControls || IgnoreControlRefresh)
                return;

            Console.WriteLine("["+DateTime.Now.ToString() + "] Refrehing Service User Lists");
            _isRefreshingControls = true;

            foreach (ServiceUserCtrl ctrl in _serviceUserCtrls)
            {
                bool ChangeMade = false;

                //update service users in list
                if (ServiceUsersChanged)
                {
                    ctrl.List.ServiceUsers = ServiceUsers;
                    ChangeMade = true;
                }

                if (SelectedServiceuserChanged)
                {

                    //<DEP> THis is not needed as only one service user can be selected!
                    //bool containsSelectedItems = !SelectedServiceUsers.Except(ctrl.List.FilteredObjects).Any();

                    //if(containsSelectedItems)
                    //{
                        //var DifferencesList = ctrl.List.SelectedItems.Where(x => !SelectedServiceUsers.Any(x1 => x1 == x))
                        //             .Union(SelectedServiceUsers.Where(x => !ctrl.List.SelectedItems.Any(x1 => x1 == x)));

                        //if (DifferencesList.Count() > 0)
                        //{
                        //    ctrl.List.SelectedItem = SelectedServiceUsers[0];
                        //    ChangeMade = true;
                        //}
                    //}

                    if (SelectedServiceUsers.Count() > 0 && ctrl.List.SelectedItem != SelectedServiceUsers[0])  
                    {
                        
                        ctrl.List.SelectedItem = SelectedServiceUsers[0];
                        ChangeMade = true;
                        
                    }else if(SelectedServiceUsers.Count() == 0 && ctrl.List.SelectedItem != null)
                    {
                        ctrl.List.SelectedItem = null;
                        ChangeMade = true;
                    }

                }


                //update the filter
                if (ServiceUserFilterChanged)
                {
                    if (ctrl.List.Filter != _ServiceUserListFilter)
                        ctrl.List.Filter = _ServiceUserListFilter;
                }


                //refresh the control
                if (ChangeMade || (!ServiceUsersChanged && !SelectedServiceuserChanged && !ServiceUserFilterChanged))
                    ctrl.List.Refresh();

            }

            _isRefreshingControls = false;
        }

        /// <summary>
        /// Refresh all the service user calendars
        /// </summary>
        public void RefreshCalendars(DateTime? thisDateOnly = null)
        {
            if (_isRefreshingControls || IgnoreControlRefresh)
                return;

            DateTime calendarRefreshStart = DateTime.Now;

            Console.WriteLine("[" + calendarRefreshStart.ToString() + "] Refrehing Service User Calendars");
            _isRefreshingControls = true;

            foreach (ServiceUserCtrl ctrl in _serviceUserCtrls)
            {
                if (thisDateOnly != null &&
                       !(ctrl.Calendar.StartDate >= thisDateOnly.Value && ctrl.Calendar.StartDate < thisDateOnly.Value.AddDays(7)))
                {
                    continue;
                }

                //now the calendar
                if (ctrl.List.SelectedItems.Count() != 1)
                    ctrl.Calendar.ServiceUser = null;
                else
                    ctrl.Calendar.ServiceUser = ctrl.List.SelectedItem;

                ctrl.Calendar.Refresh();
            }

            Console.WriteLine("Refreshing Calendars Took " + (DateTime.Now - calendarRefreshStart).TotalMilliseconds.ToString());
            _isRefreshingControls = false;
        }

        /// <summary>
        /// Refresh all the services user headers
        /// </summary>
        public void RefreshHeaders()
        {
            if (_isRefreshingControls || IgnoreControlRefresh)
                return;

            Console.WriteLine("[" + DateTime.Now.ToString() + "] Refrehing Service User Headers");
            _isRefreshingControls = true;

            foreach (ServiceUserCtrl ctrl in _serviceUserCtrls)
            {
                //now the header
                ctrl.Header.Refresh();
            }

            _isRefreshingControls = false;
        }

        /// <summary>
        /// Refresh all the service users list controls
        /// </summary>
        public void RefreshControls(bool ServiceUsersChanged = false, bool SelectedServiceuserChanged = false, bool ServiceUserFilterChanged = false)
        {
            if (_isRefreshingControls || IgnoreControlRefresh)
                return;

            Console.WriteLine("[" + DateTime.Now.ToString() + "] Refrehing Service User Controls");
            //Console.WriteLine("StackTrace: '{0}'", Environment.StackTrace);

            RefreshLists(ServiceUsersChanged, SelectedServiceuserChanged, ServiceUserFilterChanged);
            RefreshCalendars();
            RefreshHeaders();

        }

        /// <summary>
        /// Load all the service users
        /// </summary>
        /// <param name="ignoreDeleted"></param>
        public void LoadServiceUsers(bool ignoreDeleted = true)
        {

            if (isLoading)
                return;

            isLoading = true;

            //load here
            if (_ServiceUsers == null)
            {
                _ServiceUsers = new ServiceUserCollection();
            }
            else
            {
                _ServiceUsers.Clear();
            }

            try
            {

                string query = "SELECT id, Firstname, Surname, PNumber, Notes, contactno_primary, contactno_secondary, datetime(dob), idStatus, idGender, location_longitude, location_latitude, medicalinfo, datetime(serviceperiodstart), serviceperiodweeks, postcode, add1, add2 FROM tbl_ServiceUser";

                if (ignoreDeleted)
                    query += " WHERE idStatus <> 3";

                DataTable dt = Common.Database.ExecuteDatabaseQuery(query);

                foreach (DataRow row in dt.Rows)
                {
                    DateTime? dob;

                    if (row[7] == DBNull.Value)
                    {
                        dob = null;
                    }
                    else
                    {
                        try
                        {

                            dob = DateTime.ParseExact(row[7].ToString(), "yyyy-MM-dd 00:00:00", CultureInfo.InvariantCulture);
                        }
                        catch (FormatException ex)
                        {
                            dob = null;
                        }
                    }

                    DateTime periodstart;

                    if (row[13] == DBNull.Value)
                    {
                       /*this should never happen!*/
                        ErrorMsgFrm.Show("oh dear failed to load a service user", "bad period start date");
                        continue;
                    }
                    else
                    {
                        try
                        {
                            periodstart = DateTime.ParseExact(row[13].ToString(), "yyyy-MM-dd 00:00:00", CultureInfo.InvariantCulture);
                        }
                        catch (FormatException ex)
                        {
                            /*this should never happen!*/
                            ErrorMsgFrm.Show("oh dear failed to load service user", "bad period start date");
                            continue;
                        }
                    }
                 

                    ServiceUser s = new ServiceUser()
                    {
                        id = Convert.ToInt32(row[0]),
                        firstname = row[1].ToString(),
                        surname = row[2].ToString(),
                        PNumber = row[3].ToString(),
                        notes = row[4].ToString(),
                        contactno_primary = row[5].ToString(),
                        contactno_secondary = row[6].ToString(),
                        dob = dob,
                        idStatus = (ServiceUser.Status)Convert.ToInt16(row[8]),
                        idGender = (ServiceUser.Gender)Convert.ToInt16(row[9]),
                        LongLatCoords = new LongLat((row[10] == DBNull.Value ? null : row[10].ToString()), (row[11] == DBNull.Value ? null : row[11].ToString()), (row[15] == DBNull.Value ? null : row[15].ToString())),
                        medicalinfo = row[12].ToString(),
                        ServiceBegins = periodstart,
                        PeriodWeekCount = Convert.ToInt32(row[14]),
                        postcode = row[15].ToString(),
                        add1 = row[16].ToString(),
                        add2 = row[17].ToString()
                    };

                    s.ConstructOld();

                    _ServiceUsers.Add(s);

                }

                //load all the key workers and refresh their old list
                List<OldConstructable> listModified= LoadKeyWorkers();
                foreach (OldConstructable obj in listModified)
                    obj.ConstructOld();

            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load all service users", ex);
            }

            isLoading = false;

        }

        /// <summary>
        /// Load the key workers
        /// this is called when the service users are loaded.
        /// </summary>
        public List<OldConstructable> LoadKeyWorkers()
        {
            List<OldConstructable> list = new List<OldConstructable>();

            //load the key workers in here
            string query = "SELECT idServiceUser, idWorker FROM tbl_KeyWorkers ORDER BY idServiceUser";

            DataTable dt = Common.Database.ExecuteDatabaseQuery(query, null, false);

            ServiceUser sUser=null;
            Worker worker = null;

            foreach (DataRow row in dt.Rows)
            {
                //first try and get service user
                if (sUser == null || sUser.id != Convert.ToInt32(row[0]))
                    sUser = ServiceUsers.SingleOrDefault(s => s.id == Convert.ToInt32(row[0]));

                if (sUser == null)
                    continue;

                //now try and get worker
                if (worker == null || worker.id != Convert.ToInt32(row[1]))
                   worker = WorkerManager.Instance.Workers.SingleOrDefault(w => w.id == Convert.ToInt32(row[1]));

                if (worker == null)
                    continue;

                //set the key people
                sUser.KeyWorkers.Add(worker);
                worker.KeyServiceUsers.Add(sUser);

                if (!list.Contains(worker))
                    list.Add(worker);

                if (!list.Contains(sUser))
                    list.Add(sUser);

            }

            return list;

        }

        /// <summary>
        /// Create a new service users. Automatically addes to the manager.
        /// </summary>
        /// <returns></returns>
        public ServiceUser NewServiceUser()
        {
            ServiceUser user = new ServiceUser();

            ServiceUsers.Add(user);

            return user;
        }

        /// <summary>
        /// Return which service users are in a rota period
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public IEnumerable<ServiceUser> ServiceUsersInRotaPeriod(DateTime date)
        {
            DateTime rotaPeriodStart = DateCalculations.GetStartOfRotaPeriod(date);
            DateTime rotaPeriodEnd = DateCalculations.GetEndOfRotaPeriod(date);

            return ServiceUsers.Where(s => s.ServiceEnds > rotaPeriodStart && s.ServiceBegins < rotaPeriodEnd);
        }
    }
}
