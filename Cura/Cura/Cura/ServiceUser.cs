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
    public class ServiceUser
        : Saveable, OldConstructable
    {

        #region Fields

        public int id;

        public string firstname;
        public string surname;

        public Status idStatus;
        public Gender idGender;

        public string PNumber;

        public string contactno_primary;
        public string contactno_secondary;

        public string postcode;
        public string add1;
        public string add2;

        public DateTime? dob;

        public string medicalinfo;
        public string notes;
        public bool isNotesImportant;

        public DateTime ServiceBegins;
        public int PeriodWeekCount;

        public LongLat LongLatCoords;

        private Collection<Worker> _KeyWorkers;
        private CallCollection _Calls;

        public Dictionary<string, object> Old;
        public List<Worker> OldKeyWorkers;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceUser()
        {
            this.idStatus = Status.Active;
            this._Calls = null;
            this._KeyWorkers = null;
            this.MarkForSave = true;

            this.Old = new Dictionary<string, object>();
            this.OldKeyWorkers = new List<Worker>();

        }

        public void ConstructOld()
        {

            this.Old.Clear();

            this.Old.Add("id", id);
            this.Old.Add("pnumber", PNumber);

            this.Old.Add("firstname", firstname);
            this.Old.Add("surname", surname);
            this.Old.Add("idstatus", idStatus);
            this.Old.Add("idgender", idGender);

            this.Old.Add("contactno_primary", contactno_primary);
            this.Old.Add("contactno_secondary", contactno_secondary);

            this.Old.Add("dob", dob);
            this.Old.Add("medicalinfo", medicalinfo);
            this.Old.Add("notes", notes);
            this.Old.Add("servicebegins", ServiceBegins);
            this.Old.Add("periodweekcount", PeriodWeekCount);
            this.Old.Add("LongLatCoords", LongLatCoords);
            this.Old.Add("isNotesImportant", isNotesImportant);

            this.Old.Add("add1", add1);
            this.Old.Add("add2", add2);
            this.Old.Add("postcode", postcode);

            this.OldKeyWorkers.Clear();
            this.OldKeyWorkers.AddRange(KeyWorkers);

        }

        #endregion

        #region Properties
        public DateTime? dob_Clean
        {
            get
            {
                if (dob == null || !dob.HasValue)
                    return null;

                return new DateTime(dob.Value.Year, dob.Value.Month, dob.Value.Day);
            }
        }

        public DateTime ServiceBegins_Clean
        {
            get
            {

                return new DateTime(ServiceBegins.Year, ServiceBegins.Month, ServiceBegins.Day);
            }
        }

        public int Age
        {
            get
            {
                if (dob_Clean == null || !dob_Clean.HasValue )
                    return -1;

                int age = DateTime.Now.Year - dob.Value.Year;

                if (dob.Value > DateTime.Now.AddYears(-age))
                    age--;

                return age;
            }

        }
        public DateTime ServiceEnds
        {

            get
            {
                return ServiceBegins.AddDays(PeriodWeekCount * 7);
            }
        }
        public string Name
        {
            get
            {
                return firstname + " " + surname;
            }
        }

        public bool IsFullyAssigned
        {
            get
            {
                foreach (Call c in Calls)
                {
                    if (!c.HasFullWorkers)
                    {
                        return false;
                    }
                }
                return true;
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
                    "LEFT JOIN tbl_Worker_Calls WC on WC.idCall = C.id " +
                    "LEFT JOIN tbl_Worker W on W.id = WC.idWorker " + 
                    "WHERE idServiceUser = " + id.ToString() + " " + 
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

        public Image PropertiesImage
        {
            get
            {
                ImageGenerator.ServiceUserImageGen gen = 0;

                if (Calls.Where(c => !c.MarkedForDeletion).Where(c => !c.HasFullWorkers).ToList().Count > 0)
                {
                    gen |= ImageGenerator.ServiceUserImageGen.Exclamation;
                }

                if (medicalinfo != null && medicalinfo.Trim().Length > 0)
                {
                    gen |= ImageGenerator.ServiceUserImageGen.Medical;
                }

                if (notes != null && isNotesImportant && notes.Trim().Length > 0)
                {
                    gen |= ImageGenerator.ServiceUserImageGen.ImportantNotes ;
                }

                return ImageGenerator.Instance.GenerateServiceUserImage(gen);
            }
        }


       

        public Collection<Worker> KeyWorkers
        {
            get
            {
               
                if (_KeyWorkers == null)
                {
                    _KeyWorkers = new Collection<Worker>();

                    this.KeyWorkers.ObjectAdded += new Collection<Worker>.CollectionChangeEvent(this.KeyWorkersChanged);
                    this.KeyWorkers.ObjectRemoved += new Collection<Worker>.CollectionChangeEvent(this.KeyWorkersChanged);
                }


                return _KeyWorkers;
            }

        }


        /// <summary>
        /// Get how much call time that this person is covering for a given weeek
        /// (for each call add up each calls duration)
        /// </summary>
        public double TotalCallTime_Mins_ForWeek(DateTime week)
        {

            DateTime startOfWeek = DateCalculations.GetStartOfWeek(week);

            double res = 0;
            foreach (Call call in Calls.Where(c => c.time >= startOfWeek && c.time <= startOfWeek.AddDays(7)))
            {
                res += call.duration_mins;
            }
            return res;

        }


        /// <summary>
        /// Get how much call time that this person has covered for a given weeek
        /// (for each call add up each calls duration)
        /// </summary>
        public double TotalCallTimeCovered_Mins_ForWeek(DateTime week)
        {

            DateTime startOfWeek = DateCalculations.GetStartOfWeek(week);

            double res = 0;
            foreach (Call call in Calls.Where(c => c.HasFullWorkers && c.time >= startOfWeek && c.time <= startOfWeek.AddDays(7)))
            {
                res += call.duration_mins;
            }
            return res;

        }

        /// <summary>
        /// Get how much call time that this person  has uncovered for a given weeek
        /// (for each call add up each calls duration)
        /// </summary>
        public double TotalCallTimeUnCovered_Mins_ForWeek(DateTime week)
        {

            DateTime startOfWeek = DateCalculations.GetStartOfWeek(week);

            double res = 0;
            foreach (Call call in Calls.Where(c => !c.HasFullWorkers && c.time >= startOfWeek && c.time <= startOfWeek.AddDays(7)))
            {
                res += call.duration_mins;
            }
            return res;

        }

        #endregion

        #region Enums
        public enum Status
        {
            Active = 1,
            Inactive = 2,
            Deleted = 3
        }

        public enum Gender
        {
            Unknown = 0,
            Male = 1,
            Female = 2
        }
        #endregion

        #region Events
        private void KeyWorkersChanged(object sender, CollectionChangeEventArgs args)
        {
            //if (WorkerManager.Instance.isLoading || ServiceUserManager.Instance.isLoading)
            //    return;

            ////refresh the worker controls to show the key worker symbol
            //WorkerManager.Instance.RefreshLists(false);
        }

        private void CallsChanged(object sender, CollectionChangeEventArgs args)
        {
            if (CallManager.Instance.isLoading)
                return;

        }
        #endregion

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
                    query = "INSERT INTO tbl_ServiceUser(Firstname, Surname, idStatus, PNumber, dob, postcode, add1, add2, Notes, contactno_primary, " +
                            "contactno_secondary, idGender, location_longitude, location_latitude, medicalinfo, serviceperiodstart, serviceperiodweeks, isNotesImportant)";

                    query += " VALUES(@0, @1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17)";

                    object[] prms = new object[] { firstname,  surname,
                                                    Convert.ToInt32(idStatus), PNumber,
                                                    dob_Clean,
                                                    postcode, add1, add2,
                                                    notes,
                                                    contactno_primary, contactno_secondary,
                                                    Convert.ToInt32(idGender),
                                                    LongLatCoords.Longatude, LongLatCoords.Latatude,
                                                    medicalinfo,
                                                    ServiceBegins_Clean, PeriodWeekCount,
                                                    isNotesImportant };

                    DataTable dt = Common.Database.ExecuteDatabaseQuery(query, prms, true);

                    if (dt.Rows.Count == 0)
                        throw new Exception("Failed To Insert Service User");

                    id = Convert.ToInt32(dt.Rows[0][0]);

                    ChangeTracker.InsertChange(System.Environment.UserName, DateTime.Now, "tbl_ServiceUser", id, this, ChangeTracker.ChangeType.Insert);

                    ConstructOld();
                }
                else
                {


                    query += "UPDATE tbl_ServiceUser SET";

                    query += " Firstname = @0";
                    query += ",Surname= @1";
                    query += ",idStatus= @2";
                    query += ",PNumber = @3";
                    query += ",dob = @4";
                    query += ",postcode = @5";
                    query += ",add1 = @6";
                    query += ",add2 = @7";

                    query += ",Notes = @8";
                    query += ",contactno_primary = @9";
                    query += ",contactno_secondary = @10";

                    query += ",idGender= @11";

                    query += ",location_longitude = @12";
                    query += ",location_latitude = @13";

                    query += ",medicalinfo = @14";

                    query += ",serviceperiodstart = @15";
                    query += ",serviceperiodweeks = @16";

                    query += ",isNotesImportant = @17";
                    query += " WHERE id = @18";


                    object[] prms = new object[] { firstname,  surname,
                                                    Convert.ToInt32(idStatus), PNumber,
                                                    dob_Clean,
                                                    postcode, add1, add2,
                                                    notes,
                                                    contactno_primary, contactno_secondary,
                                                    Convert.ToInt32(idGender),
                                                    LongLatCoords.Longatude, LongLatCoords.Latatude,
                                                    medicalinfo,
                                                    ServiceBegins_Clean, PeriodWeekCount,
                                                    isNotesImportant,
                                                    id};


                    Common.Database.ExecuteDatabaseStatement(query, prms);

                    if (idStatus == Status.Deleted)
                    {
                        ChangeTracker.InsertChange(System.Environment.UserName, DateTime.Now, "tbl_ServiceUser", id, this, ChangeTracker.ChangeType.Delete);
                    }
                    else
                    {
                        ChangeTracker.InsertChange(System.Environment.UserName, DateTime.Now, "tbl_ServiceUser", id, this, ChangeTracker.ChangeType.Update);
                    }

                    this.Old["id"] = id;
                    this.Old["pnumber"] = PNumber;
                            
                    this.Old["firstname"] = firstname;
                    this.Old["surname"] = surname;

                    this.Old["idstatus"] = idStatus;
                    this.Old["idgender"] = idGender;
                    this.Old["dob"] = dob;
                    this.Old["contactno_primary"] = contactno_primary;
                    this.Old["contactno_secondary"] = contactno_secondary;

                    this.Old["postcode"] = postcode;
                    this.Old["add1"] = add1;
                    this.Old["add2"] = add2;

                    this.Old["medicalinfo"] = medicalinfo;
                    this.Old["notes"] = notes;
                    this.Old["servicebegins"] = ServiceBegins;
                    this.Old["periodweekcount"] = PeriodWeekCount;
                    this.Old["LongLatCoords"] = LongLatCoords;


                    this.OldKeyWorkers.Clear();
                    this.OldKeyWorkers.AddRange(KeyWorkers);
                }


                //Now do the key workers

                query = "DELETE FROM tbl_KeyWorkers WHERE idServiceUser = " + id.ToString();
                Common.Database.ExecuteDatabaseStatement(query);

                foreach (Worker worker in KeyWorkers)
                {
                    query = "INSERT INTO tbl_KeyWorkers(idServiceUser, idWorker)";
                    query += "VALUES (@0, @1)";

                     Common.Database.ExecuteDatabaseStatement(query, new object[] {id, worker.id});
                }
             
                 
            }
            catch (Exception ex)
            {
                throw new Exception("Service User Save Failed", ex);
            }


             MarkForSave = false;

        }

        /// <summary>
        /// Duplicate this service user
        /// </summary>
        /// <returns></returns>
        public ServiceUser Duplicate(bool copyKeyWorkers = false)
        {
            ServiceUser dupeServiceUser = new ServiceUser()
            {
                firstname = this.firstname,
                surname = this.surname,
                //age = this.age,
                postcode = this.postcode,
                add1 = this.add1,
                add2 = this.add2,
                idStatus = this.idStatus,
                notes = this.notes
            };

            if (copyKeyWorkers)
            {
                dupeServiceUser.KeyWorkers.AddRange(KeyWorkers);
            }


            return dupeServiceUser;

        }

        /// <summary>
        /// Delete the service user by setting status to deleted, remove it from the manager too.
        /// </summary>
        public void Delete()
        {
            idStatus = ServiceUser.Status.Deleted;
            ServiceUserManager.Instance.ServiceUsers.Remove(this);

            MarkForSave = true;
        }

    }
}
