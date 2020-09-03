using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cura.Forms
{
    public partial class WorkerListFrm : BaseFrm
    {
        #region Constructor
        public WorkerListFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Load
        private void workerListCtrl1_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Properties
        public IEnumerable<Worker> Workers
        {
            set
            {
                workerListCtrl1.Workers = value;
            }
        }
        #endregion

        #region Events
        private void groupradio_CheckedChanged(object sender, EventArgs e)
        {
            workerListCtrl1.ShowByGroup = true;
        }

        private void individualradio_CheckedChanged(object sender, EventArgs e)
        {
            workerListCtrl1.ShowByGroup = false;
        }
        #endregion
       
    }
}
