using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;
using System.Drawing;
using System.Data;
using Cura.Common;
using System.Data.SQLite;

namespace Cura
{
    public class Call
        : Saveable, OldConstructable
    {

        #region Fields
        private int _id;

        public int idServiceUser;
        public int duration_mins;
        public int required_workers;
        public string notes;

        public FlagCode flag;
        public DateTime time;
        public int traveltime_mins;

        public const int TOTAL_DB_FIELD_COUNT = 8;

        public ServiceUser ServiceUser;
        private WorkerCollection _workers;

        private bool _markedForDeletion;
        public Dictionary<string, object> Old;
        public List<Worker> OldWorkers;

        public int idBatchIndex;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Call()
        {
            this.required_workers = 1;
            this.traveltime_mins = 0;
            this._workers = null;

            this.flag = FlagCode.None;

            this._markedForDeletion = false;
            this._MarkForSave = true;

            this.Old = new Dictionary<string, object>();
            this.OldWorkers = new List<Worker>();

            this.SaveMarkerChanged += Call_SaveMarkerChanged;
            this.SaveMarkerChanging += Call_SaveMarkerChanging;
        }


        public void ConstructOld()
        {
            this.Old.Clear();

            this.Old.Add("id", _id);
            this.Old.Add("idServiceUser", idServiceUser);
            this.Old.Add("duration_mins", duration_mins);
            this.Old.Add("required_workers", required_workers);
            this.Old.Add("time", time);
            this.Old.Add("flagcode", flag);
            this.Old.Add("notes", notes);
            this.Old.Add("traveltime_mins", traveltime_mins);

            this.OldWorkers.Clear();
            this.OldWorkers.AddRange(Workers);
        }

#endregion

        #region Properties
        public string Duration
        {
            get
            {
                TimeSpan time = new TimeSpan(0, duration_mins, 0);

                string timeduration = time.Minutes + "m";

                if (time.Hours > 0)
                {
                    timeduration = time.Hours + "h " + timeduration;
                }

                return timeduration;
            }
        }

        public Timezone CallTimeZone
        {
            get
            {

                if (time.Hour >= 18)
                {
                    //after 6pm
                    return Timezone.Evening;
                }
                else if (time.Hour >= 15)
                {
                    //after 3pm
                    return Timezone.Tea;
                }
                else if (time.Hour >= 12)
                {
                    //after 12
                    return Timezone.Lunch;
                }

                return Timezone.Morning;
            }
        }

        public string CoveredBy
        {
            get
            {
                string coveredby = "";

                foreach (Worker worker in Workers)
                {
                    if (coveredby.Length > 0)
                        coveredby += ", ";

                    coveredby += worker.Name;

                }

                return coveredby;
            }
        }

        public WorkerCollection Workers
        {
            get
            {
                if (_workers == null)
                {
                    _workers = new WorkerCollection();
                    this._workers.ObjectAdded += new Collection<Worker>.CollectionChangeEvent(WorkersChanged);
                    this._workers.ObjectRemoved += new Collection<Worker>.CollectionChangeEvent(WorkersChanged);
                }

                return _workers;
            }
        }

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Changes
        {
            get
            {
                string retStr = (HasChanges ? "Call Edited" :  "No Changes" );

                if (MarkedForDeletion)
                {
                    //its been marked for deletion
                    retStr = "Has Been Marked For Deleted";
                }
                else
                {
                    if (ID == 0)
                    {
                        //its a new call!
                        retStr = "New Call Created";
                    }

                    if (HasWorkerAssignmentChanges)
                    {
                        //Is been assigned / unassigned
                        if (retStr.Length > 0) retStr += " / ";

                        retStr += "Has Had Assignment Changed";
                    }

                    
                }

                return retStr + " (" + ToString() + ")";

            }
        }

        public bool HasWorkerAssignmentChanges
        {
            get
            {
                if (Workers.Count != OldWorkers.Count)
                    return true;

                foreach (Worker worker in Workers)
                {
                    if (!OldWorkers.Contains(worker))
                        return true;
                }

                return false;

            }
        }

        public bool HasChanges
        {
            get
            {
                if (MarkedForDeletion)
                {
                    return _id != 0;
                }

                if (_id == 0)
                    return true;

                if (idServiceUser != (int)this.Old["idServiceUser"])
                    return true;

                if (duration_mins != (int)this.Old["duration_mins"])
                    return true;

                if (required_workers != (int)this.Old["required_workers"])
                    return true;

                if (time != (DateTime)this.Old["time"])
                    return true;

                if (flag != (FlagCode)this.Old["flagcode"])
                    return true;

                if (traveltime_mins  !=(int)this.Old["traveltime_mins"])
                    return true;


                if (HasWorkerAssignmentChanges)
                    return true;

                return false;

            }
        }
        public DateTime TimeFrom
        {
            get
            {
                return time;
            }
        }
        public DateTime TimeTo
        {
            get
            {
                return time.AddMinutes(duration_mins);
            }
        }
        public string ServiceUserName
        {
            get
            {
                return ServiceUser.Name;
            }
         
        }
        public bool HasFullWorkers
        {
            get
            {
                return Workers.Count == required_workers;
            }
        }

        public Image Image
        {
            get
            {
                int height = 0;
                int width = 0;

                Image workerImg = WorkerImage;
                Image flagImg = FlagImage;

                height += workerImg.Height;
                if (flagImg != null)
                {
                    height += flagImg.Height;
                }

                if (flagImg == null || workerImg.Width > flagImg.Width)
                    width = workerImg.Width;
                else
                    width = flagImg.Width;

                Image img = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(img);

                g.DrawImage(workerImg, new Point(0, 0));

                if (flagImg != null)
                    g.DrawImage(flagImg, new Point(0, workerImg.Height));

                return img;
            }
        }

        public Image FlagImage
        {
            get{
                switch (flag)
                {
                    case FlagCode.None: return null;
                    case FlagCode.Blue: return Properties.Resources.flag_blue;
                    case FlagCode.Green: return Properties.Resources.flag_green;
                    case FlagCode.Orange: return Properties.Resources.flag_orange;
                    case FlagCode.Pink: return Properties.Resources.flag_pink;
                    case FlagCode.Purple: return Properties.Resources.flag_purple;
                    case FlagCode.Red: return Properties.Resources.flag_red;
                    case FlagCode.Yellow: return Properties.Resources.flag_yellow;
                    default: return null;
                }

            }
       
        }
        public Image WorkerImage
        {
            get
            {
            
                switch (required_workers)
                {

                    case 2:
                        {
                            switch (Workers.Count)
                            {
                                case 0:
                                    return Cura.Properties.Resources.double_user_bw;
                                case 1:
                                    return Cura.Properties.Resources.double_user_bwhalf;
                                case 2:
                                default:
                                    return Cura.Properties.Resources.double_user;

                            }

                        }

                    case 1:
                    default:
                        {
                            switch (Workers.Count)
                            {
                                case 0:
                                    return Cura.Properties.Resources.user_bw;
                                case 1:
                                default:
                                    return Cura.Properties.Resources.user;

                            }
                        }

                }

            }
        }

        public bool MarkedForDeletion
        {
            get
            {
                return _markedForDeletion;
            }
        }

        #endregion

        #region Events
        public void WorkersChanged(object sender, CollectionChangeEventArgs args)
        {
            ///need to set a needing a save coz save is where the worker calls are saved"!
            MarkForSave = true;

        }

        public event EventHandler CallChanged;

        void Call_SaveMarkerChanging(object sender, bool oldValue, bool newValue, out bool cancel)
        {
            //call is being marked as needing saving? ok lets let everyone know!

            cancel = false;

            ////only fire the event if the old and newvalue arent false, every other combination requires updating.
            //if (!(!oldValue && !newValue) && CallChanged != null)
            //    CallChanged(this, null);

        }

        private void Call_SaveMarkerChanged(object sender, bool oldValue, bool newValue)
        {
            /*anything*/
            if (!(!oldValue && !newValue) && CallChanged != null)
                CallChanged(this, null);
        }

        #endregion

        #region Enums

        public enum FlagCode
        {
            None = 0,
            Red = 1,
            Blue = 2,
            Green = 3,
            Orange = 4,
            Pink = 5,
            Purple = 6,
            Yellow = 7
        }

        public enum Timezone
        {
            Morning,
            Lunch,
            Tea,
            Evening
        }
        #endregion

        /// <summary>
        /// Undo any pending changes and revert back fields to the old ones.
        /// </summary>
        public void UndoPendingChanges()
        {

            foreach (Worker worker in Workers)
            {
                worker.Calls.Remove(this);
            }

            //THIS NEEDS WORK!
            if (_id == 0)
            {
                //its new so lets delete it!

                ServiceUser.Calls.Remove(this);

                CallManager.Instance.Calls.Remove(this);
            }
            else
            {

                idServiceUser = (int)this.Old["idServiceUser"];
                duration_mins = (int)this.Old["duration_mins"];
                required_workers = (int)this.Old["required_workers"];
                time = (DateTime)this.Old["time"];
                flag = (FlagCode)this.Old["flagcode"];
                notes = (string)this.Old["notes"];
                traveltime_mins = (int)this.Old["traveltime_mins"];

                Workers.Clear();
                Workers.AddRange(OldWorkers);

            }

            _markedForDeletion = false;

            _MarkForSave = false;
        }

        /// <summary>
        /// Save the Call
        /// </summary>
        public override void Save()
        {
            if (!MarkForSave && !_markedForDeletion)
                return;

            string query = "";

            if (_markedForDeletion)
            {
                //now properly delete it
                ServiceUser.Calls.Remove(this);

                foreach (Worker worker in Workers)
                {
                    worker.Calls.Remove(this);
                }

                Workers.Clear();

                CallManager.Instance.Calls.Remove(this);

                //first delete all current coverage
                query = "DELETE FROM tbl_Worker_Calls WHERE idCall = " + _id.ToString();
                Common.Database.ExecuteDatabaseStatement(query);

                //now delete the call
                query = "DELETE FROM tbl_Calls WHERE id = " + _id.ToString();
                Common.Database.ExecuteDatabaseStatement(query);


                //insert change
                ChangeTracker.InsertChange(System.Environment.UserName, DateTime.Now, "tbl_Calls", _id, this, ChangeTracker.ChangeType.Delete);

                return;
            }
           
            //save it here!
            bool isInsert = _id == 0;

            try
            {
                //do the save here to the database.
                if (isInsert)
                {

                    query = "INSERT INTO tbl_Calls(idServiceUser, timeofCall, duration, required_workers, flagcode, notes, traveltime)";
                    query += " VALUES (@0, @1, @2, @3, @4, @5, @6)";

                    object[] prms = new object [] { ServiceUser.id,
                                                time, 
                                                duration_mins,                        
                                                required_workers,
                                                ((int)flag),
                                                notes,
                                                traveltime_mins};

                    DataTable dt = Common.Database.ExecuteDatabaseQuery(query, prms, true);

                    if (dt.Rows.Count == 0)
                        throw new Exception("Failed To Insert Call");

                    _id = Convert.ToInt32(dt.Rows[0][0]);

                    //insert change
                    ChangeTracker.InsertChange(System.Environment.UserName, DateTime.Now, "tbl_Calls", _id, this, ChangeTracker.ChangeType.Insert);

                    ConstructOld();
                
                }
                else
                {

                    query = "UPDATE tbl_Calls SET";

                    query += " timeofCall= @0";
                    query += ",duration= @1";
                    query += ",required_workers = @2";
                    query += ",flagcode = @3";
                    query += ",notes = @4";
                    query += ",traveltime= @5";
                    query += " WHERE id = @6";

                    object[] prms = new object[] {  time, 
                                                duration_mins,                        
                                                required_workers,
                                                ((int)flag),
                                                notes,
                                                traveltime_mins,
                                                _id};
                    
                    Common.Database.ExecuteDatabaseStatement(query, prms);

                    ChangeTracker.InsertChange(System.Environment.UserName, DateTime.Now, "tbl_Calls", _id, this, ChangeTracker.ChangeType.Update);

                    //update the olds!
                    this.Old["id"] = _id;
                    this.Old["idServiceUser"] = idServiceUser;
                    this.Old["duration_mins"] = duration_mins;
                    this.Old["required_workers"] = required_workers;
                    this.Old["time"] = time;
                    this.Old["flagcode"] = flag;
                    this.Old["notes"] = notes;
                    this.Old["traveltime_mins"] = traveltime_mins;

                    this.OldWorkers.Clear();
                    this.OldWorkers.AddRange(Workers);

                }


            }
            catch (Exception ex)
            {
                throw new Exception("Call Save Failed", ex);
            }


            //Now do the worker cover saves
            try
            {
                //do the save here to the database.

                query = "DELETE FROM tbl_Worker_Calls";
                query += " WHERE idCall = " + _id.ToString();

                Common.Database.ExecuteDatabaseStatement(query);

                foreach (Worker worker in Workers)
                {

                    query = "INSERT INTO tbl_Worker_Calls(idCall, idWorker)";
                    query += " VALUES (@0, @1)";

                    Common.Database.ExecuteDatabaseStatement(query, new object[] {_id, worker.id});
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Save All The Worker Calls", ex);
            }

            MarkForSave = false;
        }

        /// <summary>
        /// Duplicate this call
        /// </summary>
        /// <param name="incWorkers">determine whether to include workers!</param>
        /// <returns></returns>
        public Call Duplicate(bool incWorkers = false)
        {
            Call dupeCall = new Call()
            {
                time = this.time,
                idServiceUser = this.idServiceUser,
                duration_mins = this.duration_mins,
                required_workers = this.required_workers,
                ServiceUser = this.ServiceUser,
                flag = this.flag,
                notes = this.notes,
                traveltime_mins = this.traveltime_mins
            };

            if (incWorkers)
                dupeCall.Workers.AddRange(Workers);

            return dupeCall;
        }

        /// <summary>
        /// Just mark the call as deleted, when it is saved it will permantly remove it!
        /// </summary>
        public void Delete()
        {
            //mark this call as needing deletion
            _markedForDeletion = true;

            //mark for save
            MarkForSave = true;
        }

        /// <summary>
        /// Unassign all workers or just a given worker. 
        /// If worker is null all workers are removed.
        /// </summary>
        /// <param name="worker"></param>
        public void UnassignWorkers(Worker worker = null)
        {
            if (worker == null)
            {
                for (int i = Workers.Count - 1; i >= 0; i--)
                {
                    Workers[i].Calls.Remove(this);
                    Workers.Remove(Workers[i]);
                }
            }
            else
            {
               worker.Calls.Remove(this);
               Workers.Remove(worker);
            }
        }

        /// <summary>
        /// creatae nice readable to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Call for " + ServiceUser.Name + " at " + time.ToString("HH:mm") + " on " + time.ToString("dd/MM/yyyy");
        }

    }

    /// <summary>
    /// This class is a slim version of a call for efficency.
    /// </summary>
    public class Call_Slim
    {
        #region Fields
        public int id;
        public int workers_required;
        public int duration_mins;
        public string time;
        public string serviceusername;
        public string workers;
        #endregion

        #region Properties
        public string Day
        {
            get
            {
               return time.Split(' ')[0];
            }
        }

        public string TimeOfDay
        {
            get
            {
                return time.Split(' ')[1].Substring(0, 5);
            }
        }

        #endregion

    }
}
