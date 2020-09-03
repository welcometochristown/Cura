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
    public partial class DayCountFrm : Form
    {
        #region Constructor
        public DayCountFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Load
        private void DayCountFrm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Properties
        public int DayCount
        {
            get
            {
                return Convert.ToInt32(dayCountTxt.Value);
            }
            set
            {
                dayCountTxt.Value = Convert.ToInt32(value);
            }
        }

        public bool ExcludeWeekends
        {
            get
            {
                return excludeweekendChk.Checked;
            }
            set
            {
                excludeweekendChk.Checked = value;
            }
        }
        #endregion
    
    }
}
