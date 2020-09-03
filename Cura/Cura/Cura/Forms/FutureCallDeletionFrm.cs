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
    public partial class FutureCallDeletionFrm : Form
    {
        #region Constructor
        public FutureCallDeletionFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void addRadio_CheckedChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void picknchooseradio_CheckedChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        public DeletionResult Result
        {
            get
            {
                DeletionResult res = 0;

                if (addRadio.Checked)
                    res = DeletionResult.All;
                else
                {

                    if (otherdayschk.Checked && othertimeschk.Checked && samedaychk.Checked && sametimechk.Checked)
                    {
                       res = DeletionResult.All;
                    }
                    else if (otherdayschk.Checked && samedaychk.Checked && (!othertimeschk.Checked && !sametimechk.Checked))
                    {
                        res = DeletionResult.All;
                    }
                    else
                    {
                        if (otherdayschk.Checked)
                            res = res | DeletionResult.OtherDay;

                        if (othertimeschk.Checked)
                            res = res | DeletionResult.OtherTimes;

                        if (samedaychk.Checked)
                            res = res | DeletionResult.SameDay;

                        if (sametimechk.Checked)
                            res = res | DeletionResult.SameTime;
                    }
                    
                }

                return res;
            }
        }
        #endregion

        #region Enums
        public enum DeletionResult
        {
            All = 1,
            OtherDay = 2,
            OtherTimes = 4,
            SameDay = 8,
            SameTime = 16
        }
        #endregion

        /// <summary>
        /// Refresh all the controls on the screen
        /// </summary>
        private void RefreshControls()
        {
            bool pnc = picknchooseradio.Checked;

            otherdayschk.Enabled = pnc;
            othertimeschk.Enabled = pnc;
            samedaychk.Enabled = pnc;
            sametimechk.Enabled = pnc;
        }

   
    }
}
