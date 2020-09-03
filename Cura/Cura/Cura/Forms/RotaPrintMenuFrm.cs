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
    public partial class RotaPrintMenuFrm : Form
    {
        #region Constructor
        public RotaPrintMenuFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Load
        private void RotaPrintMenuFrm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Enums
        public enum PrintSelection
        {
            AllWeeks,
            WeekSelection
        }

        #endregion

        #region Properties
        public PrintSelection SelectedPrintSelection
        {
            get
            {
                if (selectionweekradio.Checked)
                    return PrintSelection.WeekSelection;

                return PrintSelection.AllWeeks;
            }
        }

        public int[] SelectedWeeks
        {
            get
            {

                string[] weeks = weekstxt.Text.Trim(new char[] { ' ', ',' }).Split(',');

                List<int> selected = new List<int>();

                foreach (string s in weeks)
                {
                    int i;
                    if (int.TryParse(s, out i))
                    {
                        if (i > 0)
                            selected.Add(i);
                    }
                }

                return selected.ToArray();
            }
        }
        #endregion

        #region Events
        private void selectionweekradio_CheckedChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void allweekradio_CheckedChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void weekstxt_TextChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }
        #endregion
      
        /// <summary>
        /// Refresh the controls on the form
        /// </summary>
        private void RefreshControls()
        {
            weekstxt.Enabled = selectionweekradio.Checked;
            exButton1.Enabled = allweekradio.Checked || SelectedWeeks.Length > 0;
        }
    }
}
