using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cura
{
    public class CallCollection
        : Cura.Common.Collection<Call>
    {
  
        #region Constructor
        public CallCollection()
        {
        //ctor
        }
        #endregion

        public static BulkInsertData GenerateBulkInsertQuery(IEnumerable<Call> callsToInsert)
        {
            string query = "INSERT INTO tbl_Calls (idServiceUser, timeofCall, duration, required_workers, flagcode, notes, traveltime, idBatchIndex)";

            BulkInsertData data = new BulkInsertData();

            bool first = true;
            int param_index = 0;

            foreach (Call c in callsToInsert)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    query += " UNION ";
                }

                query += " SELECT ";

                data.prms.Add(c.ServiceUser.id);
                data.prms.Add(c.time.ToString("yyyy-MM-dd HH:mm:00"));
                data.prms.Add(c.duration_mins);
                data.prms.Add(c.required_workers);
                data.prms.Add((int)c.flag);
                data.prms.Add(c.notes);
                data.prms.Add(c.traveltime_mins);
                data.prms.Add(c.idBatchIndex);

                for (int j = 0; j < 8; j++)
                    query += (j==0?"":",") + "@" + param_index++.ToString();
                
                
            }

            data.query = query;

            return data;
        }

        public BulkInsertData BulkInsertQuery
        {
            get
            {
                return GenerateBulkInsertQuery(this.Where(c => c.ID == 0));
            }
        }

        /// <summary>
        /// Save The Collection
        /// </summary>
        public void Save()
        {
            for(int i=this.Count-1; i >= 0; i--) 
            {
                Call c = this[i];
                c.Save();
            }
        }


    }

}
