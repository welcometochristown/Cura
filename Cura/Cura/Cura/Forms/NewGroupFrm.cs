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
    public partial class NewGroupFrm : Form
    {
        #region Constructor
        public NewGroupFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Load
        private void NewGroupFrm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Properties
        public string GroupName
        {
            get
            {
                return newGroupNameTxt.Text.Trim();
            }
            set
            {
                newGroupNameTxt.Text = value;
            }
        }
        #endregion

        #region Events
        private void newGroupNameTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void NewGroupFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (WorkerGroupManager.Instance.WorkerGroups.Where(g => g.GroupName == GroupName).Count() > 0)
                {
                    MessageBox.Show("There is already a group with this name!", "Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }
        #endregion
       
    }
}
