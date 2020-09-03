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
    public partial class WorkerCtrl : UserControl
    {
        #region Fields
        public ServiceUserCtrl ServiceUserCtrl;

        private DateTime _StartDate;
        private DateTime _PeriodStartDate;
        #endregion

        #region Constructor
        public WorkerCtrl()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void workerListCtrl1_WorkerSelectionChanged(object sender, EventArgs e)
        {
              //check if there has been any change or if the list is just deciding to fire off the selection change event!
            var DifferencesList = workerListCtrl1.SelectedItems.Where(x => !WorkerManager.Instance.SelectedWorkers.Any(x1 => x1 == x))
                         .Union(WorkerManager.Instance.SelectedWorkers.Where(x => !workerListCtrl1.SelectedItems.Any(x1 => x1 == x)));

            if (DifferencesList.Count() > 0)
            {
                Cursor = Cursors.WaitCursor;

                WorkerManager.Instance.SelectedWorkers.Clear();
                WorkerManager.Instance.SelectedWorkers.AddRange(workerListCtrl1.SelectedItems);

                Cursor = Cursors.Default;
            }
        }

        private void workerCalendarCtrl1_CallCoverDeleted(object sender, Call call)
        {
            ServiceUserCtrl.Calendar.RefreshItems();
        }
        #endregion

        #region Properties
        public DateTime PeriodStartDate
        {
            set
            {
                _PeriodStartDate = value;
                workerListCtrl1.PeriodStartDate = value;
            }
        }

        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
                Calendar.StartDate = value;
                workerListCtrl1.StartDate = value;
            }
        }

        public WorkerListCtrl List
        {
            get
            {
                return workerListCtrl1 ;
            }
        }
        public WorkerCalendarCtrl Calendar
        {
            get
            {
                return workerCalendarCtrl1 ;
            }
        }

        public Worker SelectedWorker
        {
            get
            {
                return workerListCtrl1.SelectedItem;
            }

        }

        public IEnumerable<Worker> Workers
        {
            get
            {
                return workerListCtrl1.Workers;
            }
        }
        #endregion

        /// g<summary>
        /// refresh the control
        /// </summary>
        public override void Refresh()
        {
 	         base.Refresh();

             workerCalendarCtrl1.Refresh();
             workerListCtrl1.Refresh();
        }

    }
}
