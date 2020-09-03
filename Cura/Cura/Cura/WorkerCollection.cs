using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cura
{
    public class WorkerCollection
       : Cura.Common.Collection<Worker>
    {

        #region Constructor
        public WorkerCollection()
        {
        //ctor
        }
        #endregion

        /// <summary>
        /// Save The Collection
        /// </summary>
        public void Save()
        {
            foreach (Worker w in this)
            {
                w.Save();
            }
        }

    }
}
