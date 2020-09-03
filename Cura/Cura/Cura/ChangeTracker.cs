using Cura.Controls.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cura
{
    public class ChangeTracker
    {
        #region Enums
        public enum ChangeType
        {
            Insert,
            Update,
            Delete
        }
        #endregion

        public static void InsertChangeObject(string uid, DateTime dateupdate, string tablename, int tableId,
                                      string fieldname, object oldvalue, object newvalue)
        {
            
            string oldStr, newStr;

            if(oldvalue == null)
                oldStr = "NULL";
            else
                oldStr = oldvalue.ToString();

            if (newvalue == null)
                newStr = "NULL";
            else
                newStr = newvalue.ToString();

                InsertChange(uid, dateupdate, tablename, tableId, fieldname, oldStr, newStr);

        }

        public static void InsertChange(string uid, DateTime dateupdate, string tablename, int tableId, 
                                        string fieldname, string oldvalue, string newvalue)
        {
            string query = "INSERT INTO tbl_ChangeLog(UID, DateUpdate, TableName, ID, Fieldname, Oldvalue, Newvalue)";
            //query += " VALUES ('" + uid + "', '" + dateupdate.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + tablename + "', " + tableId.ToString() + ", '" + fieldname + "', '" + oldvalue + "', '" + newvalue + "')";
            query += " VALUES (@0, @1, @2, @3, @4, @5, @6)";

            Common.Database.ExecuteDatabaseQuery(query, new object[] {uid, dateupdate, tablename, tableId, fieldname, oldvalue, newvalue}, true);
        }

        public static void InsertBulkChange(string uid, DateTime dateupdate, string tablename, int tableId,
                                      IEnumerable<ChangeItem> changeItems)
        {
            string query = "INSERT INTO tbl_ChangeLog(UID, DateUpdate, TableName, ID, Fieldname, Oldvalue, Newvalue)";

            BulkInsertData data = new BulkInsertData();

            bool first = true;
            int param_index = 0;
            foreach (ChangeItem item in changeItems)
            {
                if (first)
                    first = false;
                else
                    query += " UNION ";

                data.prms.Add(uid);
                data.prms.Add(dateupdate);
                data.prms.Add(tablename);
                data.prms.Add(tableId);
                data.prms.Add(item.FieldName );
                data.prms.Add(item.OldValue);
                data.prms.Add(item.NewValue);
        
                query += " SELECT ";

                for (int j = 0; j < 7; j++)
                    query += (j == 0 ? "" : ",") + "@" + param_index++.ToString();

                // +uid + "', '" + dateupdate.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + tablename + "', " + tableId.ToString() + ", '" + item.FieldName + "', '" + item.OldValue + "', '" + item.NewValue + "' ";
            }

            data.query = query;

            Common.Database.ExecuteDatabaseQuery(query, data.prms.ToArray(), true);
        }

      

        public static void InsertChange(string uid, DateTime dateupdate, string tablename, int tableId, object obj, ChangeType type)
        {
            // insert a change into the changelog

            #region Call   
            if (obj is Call)
            {
                Call cObj  = obj as Call;

                switch(type)
                {
                    case ChangeType.Insert:

                        List<ChangeItem> items = new List<ChangeItem>();

                        items.Add(new ChangeItem("id", "NULL", cObj.ID));
                        items.Add(new ChangeItem("idServiceUser", "NULL", cObj.idServiceUser));
                        items.Add(new ChangeItem("duration", "NULL", cObj.duration_mins));
                        items.Add(new ChangeItem("required_workers", "NULL", cObj.required_workers));
                        items.Add(new ChangeItem("flagcode", "NULL", cObj.flag));
                        items.Add(new ChangeItem("notes", "NULL", cObj.notes));
                        items.Add(new ChangeItem("traveltime", "NULL", cObj.traveltime_mins));
                        items.Add(new ChangeItem("timeofcall", "NULL", cObj.time.ToString("yyyy-MM-dd HH:mm:00")));

                        InsertBulkChange(uid, dateupdate, tablename, tableId, items);
                       
                    break;
                    case ChangeType.Update:

                        if (cObj.idServiceUser != (int)cObj.Old["idServiceUser"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "idServiceUser", cObj.Old["idServiceUser"], cObj.idServiceUser);

                        if (cObj.duration_mins != (int)cObj.Old["duration_mins"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "duration", cObj.Old["duration_mins"], cObj.duration_mins);

                        if (cObj.required_workers != (int)cObj.Old["required_workers"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "required_workers", cObj.Old["required_workers"], cObj.required_workers);

                        if (cObj.time != (DateTime)(cObj.Old["time"]))
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "timeofcall", cObj.Old["time"], cObj.time);

                        if (cObj.flag != (Call.FlagCode)(cObj.Old["flagcode"]))
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "flagcode", cObj.Old["flagcode"], cObj.flag);

                        if (cObj.notes != (string)cObj.Old["notes"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "notes", cObj.Old["notes"], cObj.notes);

                        if (cObj.traveltime_mins != (int)cObj.Old["traveltime_mins"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "traveltime", cObj.Old["traveltime_mins"], cObj.traveltime_mins);


                    break;
                    case ChangeType.Delete:

                            //insert change
                        InsertChangeObject(uid, dateupdate, tablename, tableId, "id", cObj.ID, "DELETED");
                    break;
                }

                //now do the call assignement checks.
                // look at all the workers and check which ones have been added and which ones have been removed.

                foreach (Worker worker in cObj.Workers)
                {
                    if (!cObj.OldWorkers.Contains(worker))
                    {
                        //worker cover added!
                        InsertChange(uid, dateupdate, "tbl_Worker_Assignment", tableId, "Call " + cObj.ID.ToString(), "Uncovered", "Covered By " + worker.Name);      //WRONG NEEDS FIXING!
                    }
                }

                foreach (Worker worker in cObj.OldWorkers)
                {
                    if (!cObj.Workers.Contains(worker))
                    {
                        //worker cover removed!
                        InsertChange(uid, dateupdate, "tbl_Worker_Assignment", tableId, "Call " + cObj.ID.ToString(), "Covered By " + worker.Name, "Uncovered");
                    }
                }

            }
            #endregion

            #region Worker
            if (obj is Worker)
            {
                Worker wObj = obj as Worker;

                switch(type)
                {
                    case ChangeType.Insert:

                        List<ChangeItem> items = new List<ChangeItem>();

                        items.Add(new ChangeItem("id", "NULL", wObj.id));
                        items.Add(new ChangeItem("ENumber", "NULL", wObj.ENumber));
                        items.Add(new ChangeItem("firstname", "NULL", wObj.firstname));
                        items.Add(new ChangeItem("surname", "NULL", wObj.surname));
                        items.Add(new ChangeItem("idStatus", "NULL", ((int) wObj.idStatus)));
                        items.Add(new ChangeItem("contactno_primary", "NULL", wObj.contactno_primary ));
                        items.Add(new ChangeItem("contactno_secondary", "NULL", wObj.contactno_secondary));
                        items.Add(new ChangeItem("postcode", "NULL", wObj.postcode));
                        items.Add(new ChangeItem("add1", "NULL", wObj.add1));
                        items.Add(new ChangeItem("add2", "NULL", wObj.add2));
                        items.Add(new ChangeItem("isDriver", "NULL", wObj.isDriver));
                        items.Add(new ChangeItem("notes", "NULL", wObj.notes));
                        items.Add(new ChangeItem("location_longitude", "NULL", wObj.LongLatCoords.Longatude ));
                        items.Add(new ChangeItem("location_latitude", "NULL", wObj.LongLatCoords.Latatude ));

                        InsertBulkChange(uid, dateupdate, tablename, tableId, items);


                        break;

                    case ChangeType.Update:

                        if (wObj.ENumber != (string)wObj.Old["ENumber"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "ENumber", wObj.Old["ENumber"], wObj.ENumber);

                        if (wObj.firstname != (string)wObj.Old["firstname"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "firstname", wObj.Old["firstname"], wObj.firstname);

                        if (wObj.surname != (string)wObj.Old["surname"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "surname", wObj.Old["surname"], wObj.surname);

                        if (wObj.idStatus !=(Worker.Status)wObj.Old["idStatus"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "idStatus", wObj.Old["idStatus"], wObj.idStatus);

                        if (wObj.contactno_primary != (string)wObj.Old["contactno_primary"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "contactno_primary", wObj.Old["contactno_primary"], wObj.contactno_primary);

                        if (wObj.contactno_secondary != (string)wObj.Old["contactno_secondary"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "contactno_secondary", wObj.Old["contactno_secondary"], wObj.contactno_secondary);

                        if (wObj.postcode != (string)wObj.Old["postcode"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "postcode", wObj.Old["postcode"], wObj.postcode);

                        if (wObj.postcode != (string)wObj.Old["add1"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "add1", wObj.Old["add1"], wObj.add1);

                        if (wObj.postcode != (string)wObj.Old["add2"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "add2", wObj.Old["add2"], wObj.add2);

                        if (wObj.isDriver != (bool)wObj.Old["isDriver"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "isDriver", wObj.Old["isDriver"], wObj.isDriver);

                        if (wObj.notes != (string)wObj.Old["notes"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "notes", wObj.Old["notes"], wObj.notes);

                        if (wObj.LongLatCoords.Longatude != ((LongLat)wObj.Old["LongLatCoords"]).Longatude)
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "location_longitude", ((LongLat)wObj.Old["LongLatCoords"]).Longatude, wObj.LongLatCoords.Longatude);

                        if (wObj.LongLatCoords.Latatude != ((LongLat)wObj.Old["LongLatCoords"]).Latatude)
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "location_latitude", ((LongLat)wObj.Old["LongLatCoords"]).Latatude, wObj.LongLatCoords.Latatude);

                        break;

                    case ChangeType.Delete:
                        InsertChangeObject(uid, dateupdate, tablename, tableId, "id", wObj.id, "DELETED");
                        break;
                }

                foreach (ServiceUser serviceuser in wObj.KeyServiceUsers)
                {
                    if (!wObj.OldKeyServiceUsers.Contains(serviceuser))
                    {
                        //key  serviceuser added!
                        InsertChange(uid, dateupdate, tablename, tableId, wObj.Name, "None", serviceuser.Name + " added as KeyService User");      //WRONG NEEDS FIXING!
                    }
                }

                foreach (ServiceUser serviceuser in wObj.OldKeyServiceUsers)
                {
                    if (!wObj.KeyServiceUsers.Contains(serviceuser))
                    {
                        //key serviceuser removed!
                        InsertChange(uid, dateupdate, tablename, tableId, wObj.Name, serviceuser.Name + " is KeyServiceUser", "Removed");
                    }
                }

                List<Absence> currentAbsences = new List<Absence>();

                currentAbsences.AddRange(wObj.Holidays);
                currentAbsences.AddRange(wObj.SickDays);
                currentAbsences.AddRange(wObj.Training);


            }
            #endregion

            #region Service User
            if (obj is ServiceUser)
            {
                ServiceUser oObj = obj as ServiceUser;

                switch (type)
                {
                    case ChangeType.Insert:

                       List<ChangeItem> items = new List<ChangeItem>();

                       items.Add(new ChangeItem("id", "NULL", oObj.id));
                       items.Add(new ChangeItem("PNumber", "NULL", oObj.PNumber));
                       items.Add(new ChangeItem("firstname", "NULL", oObj.firstname));
                       items.Add(new ChangeItem("surname", "NULL", oObj.surname));
                       items.Add(new ChangeItem("idStatus", "NULL", ((int)oObj.idStatus)));
                       items.Add(new ChangeItem("idGender", "NULL", ((int)oObj.idGender)));
                       items.Add(new ChangeItem("contactno_primary", "NULL", oObj.contactno_primary));
                       items.Add(new ChangeItem("contactno_secondary", "NULL", oObj.contactno_secondary));
                       items.Add(new ChangeItem("postcode", "NULL", oObj.postcode));
                       items.Add(new ChangeItem("add1", "NULL", oObj.add1));
                       items.Add(new ChangeItem("add2", "NULL", oObj.add2));
                       items.Add(new ChangeItem("medicalinfo", "NULL", oObj.medicalinfo));
                       items.Add(new ChangeItem("notes", "NULL", oObj.notes));
                       items.Add(new ChangeItem("periodweekcount", "NULL", ((int)oObj.PeriodWeekCount)));
                       items.Add(new ChangeItem("location_longatude", "NULL", oObj.LongLatCoords.Longatude));
                       items.Add(new ChangeItem("location_latitude", "NULL", oObj.LongLatCoords.Latatude));
                       items.Add(new ChangeItem("isNotesImportant", "NULL", oObj.isNotesImportant));
                       items.Add(new ChangeItem("dob", "NULL", oObj.dob));
                       items.Add(new ChangeItem("servicebegins", "NULL", oObj.ServiceBegins.ToString("yyyy-MM-dd")));

                        InsertBulkChange(uid, dateupdate, tablename, tableId, items);

                        break;
                    case ChangeType.Update:

                        if (oObj.PNumber != (string)oObj.Old["pnumber"])
                              InsertChangeObject(uid, dateupdate, tablename, tableId, "PNumber", oObj.Old["pnumber"], oObj.PNumber);

                        if (oObj.firstname != (string)oObj.Old["firstname"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "firstname", oObj.Old["firstname"], oObj.firstname);

                        if (oObj.surname != (string)oObj.Old["surname"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "surname", oObj.Old["surname"], oObj.surname);

                        if (oObj.idStatus != (ServiceUser.Status)oObj.Old["idstatus"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "idStatus", ((int)oObj.Old["idstatus"]), ((int)oObj.idStatus));

                        if (oObj.idGender != (ServiceUser.Gender)oObj.Old["idgender"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "idGender", ((int)oObj.Old["idgender"]), ((int)oObj.idGender));

                        if (oObj.contactno_primary != (string)oObj.Old["contactno_primary"])
                              InsertChangeObject(uid, dateupdate, tablename, tableId, "contactno_primary", oObj.Old["contactno_primary"], oObj.contactno_primary);

                        if (oObj.contactno_secondary != (string)oObj.Old["contactno_secondary"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "contactno_secondary", oObj.Old["contactno_secondary"], oObj.contactno_secondary);

                        if (oObj.postcode != (string)oObj.Old["postcode"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "postcode", (string)oObj.Old["postcode"], oObj.postcode);

                        if (oObj.add1 != (string)oObj.Old["add1"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "add1", (string)oObj.Old["add1"], oObj.add1);

                        if (oObj.add2 != (string)oObj.Old["add2"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "add2", (string)oObj.Old["add2"], oObj.add2);

                        if (oObj.medicalinfo != (string)oObj.Old["medicalinfo"])
                             InsertChangeObject(uid, dateupdate, tablename, tableId, "medicalinfo", (string)oObj.Old["medicalinfo"], oObj.medicalinfo);

                        if (oObj.notes != (string)oObj.Old["notes"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "notes", (string)oObj.Old["notes"], oObj.notes);

                        if (oObj.PeriodWeekCount != (int)oObj.Old["periodweekcount"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "periodweekcount", ((int)oObj.Old["periodweekcount"]), ((int)oObj.PeriodWeekCount));

                        if (oObj.LongLatCoords.Longatude != ((LongLat)oObj.Old["LongLatCoords"]).Longatude )
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "location_longatude", ((LongLat)oObj.Old["LongLatCoords"]).Longatude, oObj.LongLatCoords.Longatude);

                        if (oObj.LongLatCoords.Latatude != ((LongLat)oObj.Old["LongLatCoords"]).Latatude)
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "location_latitude", ((LongLat)oObj.Old["LongLatCoords"]).Latatude, oObj.LongLatCoords.Latatude);

                        if (oObj.isNotesImportant !=(bool)oObj.Old["isNotesImportant"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "isNotesImportant", ((bool)oObj.Old["isNotesImportant"]), oObj.isNotesImportant);

                        if (oObj.ServiceBegins != (DateTime)oObj.Old["servicebegins"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "servicebegins", (DateTime)oObj.Old["servicebegins"], oObj.ServiceBegins);

                        if (oObj.dob != (DateTime?)oObj.Old["dob"])
                            InsertChangeObject(uid, dateupdate, tablename, tableId, "dob", (DateTime?)oObj.Old["dob"], oObj.dob);

                        break;
                    case ChangeType.Delete:
                        InsertChangeObject(uid, dateupdate, tablename, tableId, "id", oObj.id, "DELETED");
                        break;
                }

                foreach (Worker worker in oObj.KeyWorkers)
                {
                    if (!oObj.OldKeyWorkers.Contains(worker))
                    {
                        //key worker added!
                        InsertChange(uid, dateupdate, tablename, tableId, oObj.Name, "None", worker.Name + " added as KeyWorker");      //WRONG NEEDS FIXING!
                    }
                }

                foreach (Worker worker in oObj.OldKeyWorkers)
                {
                    if (!oObj.KeyWorkers.Contains(worker))
                    {
                        //key worker removed!
                        InsertChange(uid, dateupdate, tablename, tableId, oObj.Name, worker.Name + " is KeyWorker", "Removed");
                    }
                }
            }
            #endregion
        }


        public class ChangeItem
        {
            string _fieldname;
            object _oldvalue, _newvalue;

            public ChangeItem(string fieldname, object oldvalue, object newvalue)
            {
                this._fieldname = fieldname;
                this._oldvalue = oldvalue;
                this._newvalue = newvalue;
            }

            public string FieldName
            {
                get
                {
                    return _fieldname;
                }
            }

            public string OldValue
            {
                get
                {
                    if (_oldvalue == null)
                        return "NULL";
                    else
                        return _oldvalue.ToString();
                }
            }

            public string NewValue
            {
                get
                {
                    if (_newvalue == null)
                        return "NULL";
                    else
                        return _newvalue.ToString();
                }
            }
        }
    }
}
