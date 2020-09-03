using Cura.Common;
using Cura.Controls.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;


namespace Cura
{
    public class Worker
        : Saveable, OldConstructable
    {
    
        #region Fields

        public string ENumber;

        public int id;
        public string firstname;
        public string surname;

        public Status idStatus;
        public string contactno_primary;
        public string contactno_secondary;

        public string postcode;
        public string add1;
        public string add2;

        public bool isDriver;
        public string notes;
    
        public LongLat LongLatCoords;

        private CallCollection _Calls;

        private Collection<ServiceUser> _KeyServiceUsers;
        private AvailabilityCollection _WorkingHours;

        private AbsenceCollection _holidays;
        private AbsenceCollection _sickdays;
        private AbsenceCollection _training;

        private Collection<DateTime> _Trainingdays;

        public Dictionary<string, object> Old;
        public List<ServiceUser> OldKeyServiceUsers;

        private WorkerGroupCollection _Groups;
        public List<Absence> OldAbsences;

        #endregion

        #region Properties

        public AbsenceCollection Training
        {
            get
            {
                if (_training == null)
                {
                    _training = new AbsenceCollection();
                }

                return _training;
            }
        }


        public AbsenceCollection Holidays
        {
            get
            {
                if (_holidays == null)
                {
                    _holidays = new AbsenceCollection();
                }

                return _holidays;
            }
        }

        public AbsenceCollection SickDays
        {
            get
            {
                if (_sickdays == null)
                {
                    _sickdays = new AbsenceCollection();
                }

                return _sickdays;
            }
        }

        public string Name
        {
            get
            {
                return firstname + " " + surname;
            }
        }

        public string ShortName
        {
            get
            {
                return firstname.Substring(0, 1) + ". " + surname;
            }
        }

        public string Enumber
        {
            get
            {
                return ENumber;
            }
            set
            {
                ENumber = value;
            }
        }

        public bool IsKeyWorker
        {
            get
            {
                return KeyServiceUsers.Count > 0;
            }
        }

        public Image GetStatusImage
        {
            get
            {
                switch (idStatus)
                {
                    case Status.Inactive:
                        {
                            return Cura.Properties.Resources.disable;
                        }
                    default:
                        return null;
                }
            }
        }

        public CallCollection Calls
        {
            get
            {
                if (_Calls == null)
                {
                    _Calls = new CallCollection();
                    this.Calls.ObjectAdded += new Collection<Call>.CollectionChangeEvent(this.CallsChanged);
                    this.Calls.ObjectRemoved += new Collection<Call>.CollectionChangeEvent(this.CallsChanged);
                }

                if (!CallManager.Instance.isLoaded)
                {
                    CallManager.Instance.LoadCalls(CallManager.Instance.CurrentRotaPeriodStart);
                }

                return _Calls;
            }
        }

        public IEnumerable<Call_Slim> CallHistory
        {
            get
            {
                List<Call_Slim> calls = new List<Call_Slim>();



                string query = "" +
                    "SELECT C.id, C.required_workers, S.Firstname || ' ' ||  S.Surname as serviceuser, " +
                    "C.timeOfCall, C.duration, " +
                    "replace(ifnull(Group_Concat(W.Firstname || ' ' ||  W.Surname), 'None'), ',', ', ') workers FROM tbl_Calls C " +
                    "INNER JOIN tbl_ServiceUser S on C.idServiceUser = S.id " +
                    "INNER JOIN tbl_Worker_Calls WC on WC.idCall = C.id " +
                    "INNER JOIN tbl_Worker W on W.id = WC.idWorker " +
                    "WHERE WC.idWorker = " + id.ToString() + " " +
                    "GROUP BY C.id ";//, C.required_workers, serviceuser, timeOfCall, duration, workers ";

                DataTable dt = Database.ExecuteDatabaseQuery(query);//"SELECT C.id, C.required_workers, S.Firstname || ' ' ||  S.Surname as serviceuser, C.timeOfCall, 'workerhereplz', C.duration FROM tbl_Calls C INNER JOIN tbl_ServiceUser S on C.idServiceUser = S.id WHERE idServiceUser = " + id.ToString());

                foreach (DataRow row in dt.Rows)
                {
                    calls.Add(new Call_Slim()
                    {
                        id = Convert.ToInt32(row[0]),
                        workers_required = Convert.ToInt32(row[1]),
                        serviceusername = row[2].ToString(),
                        time = row[3].ToString(),
                        duration_mins = Convert.ToInt32(row[4]),
                        workers = row[5].ToString()

                    });
                }
                return calls;

            }
        }


        public WorkerGroupCollection Groups
        {
            get
            {
                if (_Groups == null)
                {
                    _Groups = new WorkerGroupCollection();
                }

                if (!WorkerGroupManager.Instance.isLoaded)
                {
                    WorkerGroupManager.Instance.LoadWorkerGroups();
                }

                return _Groups;
            }
        }

        public Image PropertiesImage
        {
            get
            {
                ImageGenerator.WorkerImageGen gen = 0;

                if (WorkingHours.Count == 0)
                    gen = gen | ImageGenerator.WorkerImageGen.ClockError ;

                if (isDriver)
                    gen = gen | ImageGenerator.WorkerImageGen.Car;

                if (IsKeyWorker)
                    gen = gen | ImageGenerator.WorkerImageGen.Key;

                
                return ImageGenerator.Instance.GenerateWorkerImage(gen);
            }
        }

        public Collection<ServiceUser> KeyServiceUsers
        {
            get
            {
                if (_KeyServiceUsers == null)
                {
                    _KeyServiceUsers = new Collection<ServiceUser>();
                }

                return _KeyServiceUsers;
            }
        }

        /// <summary>
        /// Get the working hours information
        /// </summary>
        public AvailabilityCollection WorkingHours
        {
            get
            {
                if (_WorkingHours == null)
                {
                    this._WorkingHours = new AvailabilityCollection();
                    this._WorkingHours.ObjectAdded += new Collection<Availability>.CollectionChangeEvent(this.WorkingHoursChanged);
                    this._WorkingHours.ObjectRemoved += new Collection<Availability>.CollectionChangeEvent(this.WorkingHoursChanged);

                    //load hours here
                    string query = "SELECT dayno, timefrom, timeto FROM tbl_Worker_Availability WHERE idWorker = " + id.ToString();

                    DataTable dtavailability = Common.Database.ExecuteDatabaseQuery(query);
                    foreach (DataRow row in dtavailability.Rows)
                    {
                        string tFrom = row[1].ToString();
                        string tTo = row[2].ToString();

                        TimeSpan spanFrom = new TimeSpan(Convert.ToInt32(tFrom.Split(':')[0]), Convert.ToInt32(tFrom.Split(':')[1]), 0);
                        TimeSpan spanTo = new TimeSpan(Convert.ToInt32(tTo.Split(':')[0]), Convert.ToInt32(tTo.Split(':')[1]), 0);

                        Availability newavail = new Availability()
                        {
                            day = (System.DayOfWeek)Convert.ToInt16(row[0]),
                            timeFrom = spanFrom,
                            timeTo = spanTo
                        };

                        this._WorkingHours.Add(newavail);

                    }

                    //TODO : FIX IT
                    query = "SELECT rotaweek, dayofweek FROM tbl_Worker_DaysOff WHERE idWorker = " + id.ToString();
                    DataTable dtdaysoff = Common.Database.ExecuteDatabaseQuery(query);

                    foreach (DataRow row in dtdaysoff.Rows)
                    {
                        int rotaweek = Convert.ToInt32(row[0]);
                        System.DayOfWeek day = (System.DayOfWeek)Convert.ToInt16(row[1]);

                        if (_WorkingHours.daysOff.Where(d => (d.day == day && d.week == rotaweek)).Count() == 0)
                        {
                            _WorkingHours.daysOff.Add(new AvailabilityCollection.DayOff() { day = day, week = rotaweek });
                        }

                    }


                }

                return _WorkingHours;
            }
        }

        /// <summary>
        /// Get the total amount of time this working is working in a week
        /// </summary>
        public int TotalWorking_Mins_PerWeek
        {
            get
            {
                int res = 0;

                foreach (Availability avail in WorkingHours)
                {
                    DateTime t1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, avail.timeFrom.Hours, avail.timeFrom.Minutes, 0);
                    DateTime t2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, avail.timeTo.Hours, avail.timeTo.Minutes, 0);

                    TimeSpan ts = t2 - t1;

                    res += (int)ts.TotalMinutes;
                }

                return res;
            }
        }

        /// <summary>
        /// Get how much call time that this person is covering for a given weeek
        /// (for each call add up each calls duration)
        /// </summary>
        public int TotalCallTime_Mins_ForWeek(DateTime week)
        {

            DateTime startOfWeek = DateCalculations.GetStartOfWeek(week);

            int res = 0;
            foreach (Call call in Calls.Where(c => c.time >= startOfWeek && c.time <= startOfWeek.AddDays(7)))
            {
                res += call.duration_mins;
            }
            return res;
            
        }

        ///// <summary>
        ///// Get all the minutes of calls that are covered by the workers assigned hours
        ///// </summary>
        public int Assigned_Mins_ForWeek(DateTime week)
        {
                DateTime startOfWeek = DateCalculations.GetStartOfWeek(week);

                int assigned = 0;

                foreach (Call call in Calls.Where(c => c.time >= startOfWeek && c.time <= startOfWeek.AddDays(7)))
                {
                    foreach (Availability avail in WorkingHours.Where(w => w.day == call.time.DayOfWeek))
                    {
     
                        TimeSpan callTS = new TimeSpan(call.time.Hour, call.time.Minute, 0);
                        TimeSpan callTSEnd = new TimeSpan(call.time.Hour, call.time.Minute + call.duration_mins, 0);

                        //if call finishes before this avaialbility
                        if (callTSEnd.CompareTo(avail.timeFrom) == -1)
                            continue;

                        //if the call starts after this availability length
                        if (callTS.CompareTo(avail.timeTo) == 1)
                            continue;


                        //otherwise lets find out how much of the call time is coveed by working hours
                        double mins_from_end = avail.timeTo.TotalMinutes - callTSEnd.TotalMinutes;
                        double mins_from_start = callTS.TotalMinutes - avail.timeFrom.TotalMinutes;

                        if (mins_from_end < 0)
                            mins_from_end = 0;

                        if (mins_from_start < 0)
                            mins_from_start = 0;

                        double total = (avail.timeTo.TotalMinutes - avail.timeFrom.TotalMinutes) - (mins_from_end + mins_from_start);


                        //check how much of each call overlaps with each avail and add it here
                        assigned += (int) total;
                    }
                }

                return assigned;
            
        }

        /// <summary>
        /// get how many mins of available working hours are not assigned
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        public int Unassigned_Mins_ForWeek(DateTime week)
        {
            ///get how many minutes per week this worker works, then subtract the amount of mins this worker
            ///is coverring.
            return TotalWorking_Mins_PerWeek - Assigned_Mins_ForWeek(week);
        }

        /// <summary>
        /// get how many mins from calls that are covered with overtime.
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        public int Overtime_Mins_ForWeek(DateTime week)
        {
            return  TotalCallTime_Mins_ForWeek(week) - Assigned_Mins_ForWeek(week);
        }

        #endregion

        #region Enums
        public enum Status
        {
            Active = 1,
            Inactive = 2,
            Deleted = 3
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Worker()
        {
            this.idStatus = Status.Active;

            this._Calls = null;
            this._Groups = null;

            this._KeyServiceUsers = null;

            this._holidays =null;
            this._sickdays = null;

            this.MarkForSave = true;

            this.KeyServiceUsers.ObjectAdded += new Collection<ServiceUser>.CollectionChangeEvent(this.KeyServiceUsersChanged);
            this.KeyServiceUsers.ObjectRemoved  += new Collection<ServiceUser>.CollectionChangeEvent(this.KeyServiceUsersChanged);

            this.Old = new Dictionary<string, object>();
            this.OldKeyServiceUsers = new List<ServiceUser>();
            this.OldAbsences = new List<Absence>();

        }

        public void ConstructOld()
        {
            this.Old.Clear();

            this.Old.Add("id", id);
            this.Old.Add("ENumber", ENumber);
            this.Old.Add("firstname", firstname);
            this.Old.Add("surname", surname);

            this.Old.Add("idStatus", idStatus);
            this.Old.Add("contactno_primary", contactno_primary);
            this.Old.Add("contactno_secondary", contactno_secondary);

            this.Old.Add("postcode", postcode);
            this.Old.Add("add1", postcode);
            this.Old.Add("add2", postcode);

            this.Old.Add("isDriver", isDriver);
            this.Old.Add("notes", notes);

            this.Old.Add("LongLatCoords", LongLatCoords);

            this.OldKeyServiceUsers.Clear();
            this.OldKeyServiceUsers.AddRange(KeyServiceUsers);

            this.OldAbsences.Clear();

            this.OldAbsences.AddRange(Holidays );
            this.OldAbsences.AddRange(SickDays );
            this.OldAbsences.AddRange(Training);

        }

        #endregion

        #region Events
        private void KeyServiceUsersChanged(object sender, CollectionChangeEventArgs args)
        {
            //if  (WorkerManager.Instance.isLoading || ServiceUserManager.Instance.isLoading)
            //    return;

            //WorkerManager.Instance.RefreshLists(false);
        }

        private void WorkingHoursChanged(object sender, CollectionChangeEventArgs args)
        {
            WorkerManager.Instance.RefreshControls(false, false, false);
        }

        private void CallsChanged(object sender, CollectionChangeEventArgs args)
        {
            if (CallManager.Instance.isLoading)
                return;
        }
        #endregion

        /// <summary>
        /// Checke whether this worker is off on this date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool isDayOff(DateTime date)
        {
            if (date == DateTime.MinValue || _WorkingHours == null)
                return false;

            int weekOfPeriod = DateCalculations.GetWeekIndexOfRotaPeriod(date);

            return _WorkingHours.daysOff.Where(d => d.day == date.DayOfWeek && d.week == weekOfPeriod-1).Count() > 0 ;
        }

        /// <summary>
        /// Check whether the specified call is in side availability hours.
        /// </summary>
        /// <param name="call"></param>
        /// <returns></returns>
        public bool isCallInsideAvailabilityHours(Call call)
        {

            if (isDayOff(call.time))
                return false;
        
            foreach (Availability avail in _WorkingHours)
            {
                if (call.TimeFrom >= new DateTime(call.TimeFrom.Year, call.TimeFrom.Month, call.TimeFrom.Day, avail.timeFrom.Hours, avail.timeFrom.Minutes, avail.timeFrom.Seconds) &&
                    call.TimeTo <= new DateTime(call.TimeTo.Year, call.TimeTo.Month, call.TimeTo.Day, avail.timeTo.Hours, avail.timeTo.Minutes, avail.timeTo.Seconds))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Save this worker to the database.
        /// If this is the first save then id will be given a value.
        /// </summary>
        public void Save()
        {

            if (!MarkForSave)
            {
                return;
            }

            bool isInsert = id == 0;

            try
            {
                //do the save here to the database.
                string query = "";


                if (isInsert)
                {
                    query = "INSERT INTO tbl_Worker(Firstname, Surname, idStatus, contactno_primary, contactno_secondary, postcode, add1, add2, notes, isDriver, location_longitude, location_latitude, ENumber)";
                    query += " VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12)";


                    object[] prms = new object[] {
                        firstname, surname ,
                        Convert.ToInt32(idStatus),
                        contactno_primary, contactno_secondary,
                        postcode, add1 ,add2 , notes , isDriver,
                        LongLatCoords.Longatude, LongLatCoords.Latatude ,
                        ENumber
                    };

                    DataTable dt = Common.Database.ExecuteDatabaseQuery(query, prms, true);

                    if (dt.Rows.Count == 0)
                        throw new Exception("Failed To Insert Worker");

                    id = Convert.ToInt32(dt.Rows[0][0]);

                     ChangeTracker.InsertChange(System.Environment.UserName, DateTime.Now, "tbl_Worker", id, this, ChangeTracker.ChangeType.Insert);

                     ConstructOld();
                }
                else
                {

                    query += "UPDATE tbl_Worker SET";

                    query += " Firstname = @0";
                    query += ",Surname= @1";
                    query += ",idStatus= @2";
                    query += ",contactno_primary = @3";
                    query += ",contactno_secondary= @4";
                    query += ",postcode = @5";
                    query += ",add1 = @6";
                    query += ",add2 = @7";
                    query += ",notes = @8";
                    query += ",isDriver = @9";
                   
                    query += ",location_longitude = @10";
                    query += ",location_latitude = @11";

                    query += ",Enumber = @12";
                    query += " WHERE id = @13";

                    object[] prms = new object[] {
                        firstname, surname ,
                        Convert.ToInt32(idStatus),
                        contactno_primary, contactno_secondary,
                        postcode, add1 ,add2 , notes , isDriver,
                        LongLatCoords.Longatude, LongLatCoords.Latatude ,
                        ENumber, id 
                    };

                    Common.Database.ExecuteDatabaseStatement(query, prms);

                    if (idStatus == Status.Deleted)
                    {
                        ChangeTracker.InsertChange(System.Environment.UserName, DateTime.Now, "tbl_Worker", id, this, ChangeTracker.ChangeType.Delete);
                    }
                    else
                    {
                        ChangeTracker.InsertChange(System.Environment.UserName, DateTime.Now, "tbl_Worker", id, this, ChangeTracker.ChangeType.Update);
                    }


                    this.Old["id"] =  id;
                    this.Old["ENumber"] = ENumber;
                    this.Old["firstname"] = firstname;
                    this.Old["surname"] = surname;
                            
                    this.Old["idStatus"] =  idStatus;
                    this.Old["contactno_primary"] = contactno_primary;
                    this.Old["contactno_secondary"] =  contactno_secondary;
                    this.Old["postcode"] = postcode;
                    this.Old["add1"] = add1;
                    this.Old["add2"] = add2;   

                    this.Old["isDriver"] = isDriver;
                    this.Old["notes"] = notes;

                    this.Old["LongLatCoords"] = LongLatCoords;

                    this.OldKeyServiceUsers.Clear();
                    this.OldKeyServiceUsers.AddRange(KeyServiceUsers);
                }


                query = "DELETE FROM tbl_KeyWorkers WHERE idWorker = " + id.ToString();
                Common.Database.ExecuteDatabaseStatement(query);

                foreach (ServiceUser serviceuser in KeyServiceUsers )
                {
                    query = "INSERT INTO tbl_KeyWorkers(idServiceUser, idWorker)";
                    query += "VALUES (@0, @1)";

                    Common.Database.ExecuteDatabaseStatement(query, new object[] { serviceuser.id, id });
                }


                //now save the availability
                query = "DELETE FROM tbl_Worker_Availability";
                query += " WHERE idWorker = " + id.ToString();

                Common.Database.ExecuteDatabaseStatement(query);

                foreach (Availability avail in _WorkingHours)
                {
                    query = "INSERT INTO tbl_Worker_Availability(idWorker, dayno, timefrom, timeto)";
                    query += " VALUES (@0, @1, @2, @3)";

                    Common.Database.ExecuteDatabaseStatement(query, new object[] {id, ((int)avail.day), avail.timeFrom.Hours.ToString().PadLeft(2, '0') + ":" + avail.timeFrom.Minutes.ToString().PadLeft(2, '0'), avail.timeTo.Hours.ToString().PadLeft(2, '0') + ":" + avail.timeTo.Minutes.ToString().PadLeft(2, '0')});
                }


                query = "DELETE FROM tbl_Worker_DaysOff";
                query += " WHERE idWorker = " + id.ToString();

                Common.Database.ExecuteDatabaseStatement(query);

                
                foreach (AvailabilityCollection.DayOff dayoff in _WorkingHours.daysOff)
                {
                    query = "INSERT INTO tbl_Worker_DaysOff(idWorker, rotaweek, dayofweek)";
                    query += " VALUES (@0, @1, @2)";

                    Common.Database.ExecuteDatabaseStatement(query, new object[] {id, dayoff.week,((int)dayoff.day) });
                }
            

                //now save the holidays
                query = "DELETE FROM tbl_Worker_Holidays";
                query += " WHERE idWorker = " + id.ToString();

                Common.Database.ExecuteDatabaseStatement(query);

                foreach (Absence absence in _holidays )
                {
                    query = "INSERT INTO tbl_Worker_Holidays(idWorker, dateHoliday, duration_mins)";
                    query += " VALUES (@0, @1, @2)";

                    Common.Database.ExecuteDatabaseStatement(query, new object[] {id, absence.DateStart.ToString("yyyy-MM-dd HH:mm"), absence.Duration});
                }

                //now save the sickdays
                query = "DELETE FROM tbl_Worker_Sickness";
                query += " WHERE idWorker = " + id.ToString();

                Common.Database.ExecuteDatabaseStatement(query);

                foreach (Absence absence in _sickdays)
                {
                    query = "INSERT INTO tbl_Worker_Sickness(idWorker, dateSick, duration_mins)";
                    query += " VALUES (@0, @1, @2)";

                    Common.Database.ExecuteDatabaseStatement(query, new object[] {id,  absence.DateStart.ToString("yyyy-MM-dd HH:mm"), absence.Duration });
                }

                //now save the training
                query = "DELETE FROM tbl_Worker_Training";
                query += " WHERE idWorker = " + id.ToString();

                Common.Database.ExecuteDatabaseStatement(query);

                foreach (Absence absence in _training)
                {
                    query = "INSERT INTO tbl_Worker_Training(idWorker, dateTraining, duration_mins)";
                    query += " VALUES (@0, @1, @2)";

                    Common.Database.ExecuteDatabaseStatement(query, new object[] { id, absence.DateStart.ToString("yyyy-MM-dd HH:mm"), absence.Duration } );
                }
               

            }
            catch (Exception ex)
            {
                throw new Exception("Worker Save Failed", ex);
            }

            MarkForSave = false;

        }

        /// <summary>
        /// Duplicate this Worker
        /// </summary>
        /// <returns></returns>
        public Worker Duplicate(bool copyServiceUsers = false)
        {
            Worker dupeWorker = new Worker()
            {
                firstname = this.firstname,
                surname = this.surname,
                postcode = this.postcode,
                add1 = this.add1,
                add2 = this.add2,
                idStatus = this.idStatus,
                contactno_primary = this.contactno_primary,
                contactno_secondary = this.contactno_secondary,
                notes = this.notes,
                isDriver = this.isDriver
            };

            if (copyServiceUsers)
            {
                dupeWorker.KeyServiceUsers.AddRange(KeyServiceUsers);
            }

            dupeWorker.Groups.AddRange(Groups);

            WorkerManager.Instance.Workers.Add(dupeWorker);

            return dupeWorker;

        }

        /// <summary>
        /// Delete the service user by setting status to deleted, remove it from the manager too.
        /// </summary>
        public void Delete()
        {
            idStatus = Worker.Status.Deleted;
            WorkerManager.Instance.Workers.Remove(this);

            MarkForSave = true;
        }
    
    }

}
