using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Cura
{
    /// <summary>
    /// just a class for viewing workers in groups
    /// </summary>
    public class WorkerGroupViewModel
    {
        #region Fields
        public Worker worker;
        public WorkerGroup group;
        #endregion

        #region Properties
        public Image StatusImage
        {
            get
            {
                return worker.GetStatusImage;
            }
        }

        public Image PropertiesImage
        {
            get
            {
                return worker.PropertiesImage;
            }
        }

        public string Name
        {
            get
            {
                return worker.Name;
            }
        }

        public string Enumber
        {
            get
            {
                return worker.Enumber;
            }
        }

        public string GroupName
        {
            get
            {
                return group.GroupName;
            }
        }
        #endregion

        private WorkerGroupViewModel()
        { /*...*/}

        public static List<WorkerGroupViewModel> GenerateModel(IEnumerable<Worker> workers)
        {
            List<WorkerGroupViewModel> list = new List<WorkerGroupViewModel>();

            foreach (Worker worker in workers)
            {
                foreach (WorkerGroup group in worker.Groups)
                {
                    list.Add(new WorkerGroupViewModel() { worker = worker, group = group });
                }
            }

            return list;
        }
    }
}
