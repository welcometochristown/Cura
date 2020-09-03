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
    public partial class ServiceUserCtrl : UserControl
    {
        #region Fields
        public WorkerCtrl WorkerCtrl;
        private DateTime _PeriodStartDate;
        private DateTime _StartDate;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceUserCtrl()
        {
            InitializeComponent();


        }
        #endregion

        #region GlobalDrop Events
        public delegate void ServiceUserDropHandler(object sender, Call[] calls, MouseEventArgs e);

        public event ServiceUserDropHandler ServiceUserGlobalMouseUp;
        private void userCalendarCtrl1_GlobalMouseUp(object sender, Call[] calls, MouseEventArgs e)
        {
            if (ServiceUserGlobalMouseUp != null)
            {
                ServiceUserGlobalMouseUp(sender, calls, e);
            }
          
        }

        public event MouseEventHandler ServiceUserGlobalMouseDown;
        private void userCalendarCtrl1_GlobalMouseDown(object sender, MouseEventArgs e)
        {
            if (ServiceUserGlobalMouseDown != null)
            {
                ServiceUserGlobalMouseDown(sender, e);
            }
           
        }
        #endregion

        #region Properties

        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
                Calendar.StartDate = value;

                serviceUserHeaderCtrl1.StartDate = value;
                userListCtrl1.StartDate = value;

            }
        }

        public DateTime PeriodStartDate
        {
            set
            {
                _PeriodStartDate = value;
                userListCtrl1.PeriodStartDate = value;
                serviceUserHeaderCtrl1.CurrentPeriodStart = value;
            }
        }

        public IEnumerable<ServiceUser> ServiceUsers
        {
            get
            {
                return userListCtrl1.ServiceUsers;
            }
        }

        public ServiceUserCalendarCtrl Calendar
        {
            get
            {
                return userCalendarCtrl1;
            }
        }

        public ServiceUserListCtrl List
        {
            get
            {
                return userListCtrl1;
            }
        }

        public ServiceUserHeaderCtrl Header
        {
            get
            {
                return serviceUserHeaderCtrl1;
            }
        }

        #endregion

        #region Events
        /// <summary>
        /// When the service user that is selected changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userListCtrl1_ServiceUserSelectionChanged(object sender, EventArgs e)
        {
            //check if there has been any change or if the list is just deciding to fire off the selection change event!
            var DifferencesList = userListCtrl1.SelectedItems.Where(x => !ServiceUserManager.Instance.SelectedServiceUsers.Any(x1 => x1 == x))
                         .Union(ServiceUserManager.Instance.SelectedServiceUsers.Where(x => !userListCtrl1.SelectedItems.Any(x1 => x1 == x)));

            if (DifferencesList.Count() > 0)
            {
                Cursor = Cursors.WaitCursor;

                ServiceUserManager.Instance.SelectedServiceUsers.Clear();
                ServiceUserManager.Instance.SelectedServiceUsers.AddRange(userListCtrl1.SelectedItems);

                Cursor = Cursors.Default;
            }
        }


        private void userCalendarCtrl1_CallCoverDeleted(object sender, Call call)
        {
            WorkerCtrl.Calendar.RefreshItems();

            Refresh();
        }

        #endregion

        /// <summary>
        /// refresh everyhting yo
        /// </summary>
        public override void Refresh()
        {
            base.Refresh();

            userListCtrl1.Refresh();
            userCalendarCtrl1.Refresh();
            serviceUserHeaderCtrl1.RefreshStats();
        }


    }
}
