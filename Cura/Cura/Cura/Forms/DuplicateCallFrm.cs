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
    public partial class DuplicateCallFrm : Form
    {
        #region Constructor 
        public DuplicateCallFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region Enums
        public enum DuplicationMode
        {
            None,
            Days,
            Weekly
        }
        #endregion

        #region Properties

        public bool ExcludeWeekends
        {
            get
            {
                return excludeweekendCk.Checked;
            }
        }

        public DuplicationMode Duplication
        {
            get
            {
                if (duplicateDayRadio.Checked)
                    return DuplicationMode.Days;

                if (duplicateWeekradio.Checked)
                    return DuplicationMode.Weekly;

                return DuplicationMode.None;
            }
        }


        public int DuplicateDays
        {
            get
            {
                return Convert.ToInt32(dupliateDayNum.Value);
            }
        }

        public int DuplicateWeeks
        {
            get
            {
                return Convert.ToInt32(duplicateWeekNum.Value);
            }
        }
        #endregion

        #region Events
 
        private void duplicateDayRadio_CheckedChanged(object sender, EventArgs e)
        {
            dupliateDayNum.Enabled = true;
            duplicateWeekNum.Enabled = false;
            excludeweekendCk.Enabled = true;
        }

        private void duplicateWeekradio_CheckedChanged(object sender, EventArgs e)
        {
            dupliateDayNum.Enabled = false;
            duplicateWeekNum.Enabled = true;
            excludeweekendCk.Enabled = false;
        }

        private void onetimeRadio_CheckedChanged(object sender, EventArgs e)
        {
            dupliateDayNum.Enabled = false;
            duplicateWeekNum.Enabled = false;
            excludeweekendCk.Enabled = false;
        }

        #endregion

    }
}
