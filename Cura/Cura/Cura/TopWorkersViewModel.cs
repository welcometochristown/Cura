
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Cura
{
    public class TopWorkersViewModel
    {
        #region Fields
        public int index;
        public Worker worker;
        public Image image;

        public double distance_miles;
        public bool isKeyWorker;
        public int mins_workingtime_unassigned;
        #endregion

        #region Properties
        public int WorkerIndex
        {
            get
            {
                return index;
            }
        }
        public string WorkerName
        {
            get
            {
                return worker.Name;
            }
        }

        public string Distance
        {
            get
            {
                return distance_miles < 0 ? "Unknown" : distance_miles.ToString("0.00") + " Miles";
            }
        }

        public Image WorkerImage
        {
            get
            {
                return image;
            }
        }

        public double HoursRemaining
        {
            get
            {
                return new TimeSpan(0, mins_workingtime_unassigned, 0).TotalHours; 
            }
        }
        #endregion


     
    }
}
