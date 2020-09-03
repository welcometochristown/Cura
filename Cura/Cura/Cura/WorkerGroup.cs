using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Cura
{
    public class WorkerGroup
    {
        #region Fields
        private string _groupName;
        private WorkerCollection _workers;

        public Dictionary<string, object> Old;
        public List<Worker> OldWorkers;
        #endregion

        #region Constructor
        public WorkerGroup()
        {

        }

        public void ConstructOld()
        {
            //this.Old.Add("id", id);
            //this.Old.Add("ENumber", ENumber);
            //this.Old.Add("firstname", firstname);
            //this.Old.Add("surname", surname);

        }
        #endregion

        #region Properties
        public string GroupName
        {
            get
            {
                return _groupName;
            }
            set
            {
                _groupName = value;
            }
        }

        public WorkerCollection Workers
        {
            get
            {
                if (_workers == null)
                {
                    _workers = new WorkerCollection();
                //    this._workers.ObjectAdded += new Collection<Worker>.CollectionChangeEvent(WorkersChanged);
                //    this._workers.ObjectRemoved += new Collection<Worker>.CollectionChangeEvent(WorkersChanged);
                }

                return _workers;
            }
        }

        #endregion

    }

   
}
