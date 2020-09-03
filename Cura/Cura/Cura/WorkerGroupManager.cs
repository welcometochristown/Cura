using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Cura
{

    class WorkerGroupManager
           : ObjectManager<WorkerGroup>
    {
        #region Fields
        private WorkerGroupCollection _workerGroups;
        #endregion

        #region Singleton Stuff
        private static WorkerGroupManager instance;

        public static WorkerGroupManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WorkerGroupManager();
                }
                return instance;
            }
        }
        #endregion

        #region Properties
        public WorkerGroupCollection WorkerGroups
        {
            get
            {
                if (_workerGroups == null)
                {
                    isLoaded = false;

                    //create worker collection
                    _workerGroups = new WorkerGroupCollection();

                    //create event handlers
                    //_workerGroups.ObjectAdded += new Cura.Common.Collection<WorkerGroup>.CollectionChangeEvent(this.WorkerGroupAdded);
                    //_workerGroups.ObjectRemoved += new Cura.Common.Collection<WorkerGroup>.CollectionChangeEvent(this.WorkerGroupRemoved);

                    //load workers
                    LoadWorkerGroups();

                    isLoaded = true;
                }

                return _workerGroups;
            }
        }
        #endregion

        /// <summary>
        /// Load the groups
        /// </summary>
        public void LoadWorkerGroups()
        {
            if (isLoading)
                return;

            isLoading = true;

            string query = "SELECT groupname FROM tbl_Worker_Group GROUP BY groupname";

            DataTable dt = Common.Database.ExecuteDatabaseQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                WorkerGroup group = new WorkerGroup() { GroupName = row[0].ToString() };

                query = "SELECT idWorker FROM tbl_Worker_Group WHERE groupname = '" + group.GroupName + "'";
                DataTable groupdt = Common.Database.ExecuteDatabaseQuery(query);
                
                foreach(DataRow grouprow in groupdt.Rows)
                {
                    Worker worker = WorkerManager.Instance.Workers.SingleOrDefault(w => w.id == Convert.ToInt32(grouprow[0]));

                    worker.Groups.Add(group);
                    group.Workers.Add(worker);
               
                }

                group.ConstructOld();

                WorkerGroups.Add(group);

            }

            isLoading = false;
    
        }
    }
}
