using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Cura.Controls
{
    public partial class ServiceUserHeaderCtrl : UserControl
    {
        #region Fields
        private DateTime _startDate;
        private DateTime _currentPeriod;
        #endregion

        #region Constructor
        public ServiceUserHeaderCtrl()
        {
            InitializeComponent();
        }
        #endregion
     
        #region Control Load
        private void ServiceUserHeaderCtrl_Load(object sender, EventArgs e)
        {
            //nope dont refresh, this should be done by the manager at the appropriate time!
            //RefreshStats();
        }
        #endregion

        #region Properties
         public DateTime CurrentPeriodEnd
        {
             get
            {
                return _currentPeriod.AddDays(Settings.Instance.rotaweekcount * 7);
            }
        }

        public DateTime CurrentPeriodStart
        {
            get
            {
                return _currentPeriod;
            }
            set
            {
                _currentPeriod = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
            }
           
        }
        public DateTime EndDate
        {
            get
            {
                return StartDate.AddDays(7);
            }
        }
        #endregion

        public override void Refresh()
        {
            base.Refresh();

            RefreshStats();
        }

        public void RefreshStats()
        {
            //weekly
            int week_totalcount = CallManager.Instance.Calls.Where(d => !d.MarkedForDeletion).Where(c => c.time >= StartDate && c.time < EndDate).Count();
            int week_assigned = CallManager.Instance.AssignedCalls.ToList().Where(c => !c.MarkedForDeletion && (c.time >= StartDate && c.time < EndDate)).Count();
            int week_unassigned = week_totalcount - week_assigned;

            weekCntLbl.Text = week_assigned.ToString() + " / " + week_totalcount.ToString() + " calls";

            int week_val = (int)(week_assigned == 0 ? 0 : (float)week_assigned / (float)week_totalcount * 100);
            newProgressBar2.Value = week_val;

            if (newProgressBar2.Value == 100)
            {
                newProgressBar2.brush = new SolidBrush(Color.FromArgb(152, 203, 74));   //pastel green
            }
            else
            {
                newProgressBar2.brush = new SolidBrush(Color.FromArgb(255, 78, 68));
            }

            newProgressBar2.Invalidate();


            //all

            int all_totalcount = CallManager.Instance.Calls.Where(d => !d.MarkedForDeletion).Where(c => c.time >= CurrentPeriodStart && c.time <= CurrentPeriodEnd).Count();
            int all_assigned = CallManager.Instance.AssignedCalls.ToList().Where(c => !c.MarkedForDeletion && (c.time >= CurrentPeriodStart && c.time <= CurrentPeriodEnd)).Count();
            int all_unassigned = all_totalcount - all_assigned;

            allCountLbl.Text = all_assigned.ToString() + " / " + all_totalcount.ToString() + " calls";

            int all_val = (int)(all_assigned == 0 ? 0 : (float)all_assigned / (float)all_totalcount * 100);
            newProgressBar1.Value = all_val;

            if (newProgressBar1.Value == 100)
            {
                newProgressBar1.brush =  new SolidBrush(Color.FromArgb(152, 203, 74));   //pastel green
            }
            else
            {
                newProgressBar1.brush = new SolidBrush(Color.FromArgb(255, 78, 68)); 
            }

            newProgressBar1.Invalidate();





        }

    }
}
