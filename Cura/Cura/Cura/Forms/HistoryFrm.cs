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
    public partial class HistoryFrm : BaseFrm
    {
        #region Fields
        private string FilterText;
        #endregion

        #region Constructor
        public HistoryFrm()
        {
            InitializeComponent();

            FilterText = "";

            this.olvColumn4.GroupKeyGetter = delegate(object rowObject)
            {
                ChangeItem item = (ChangeItem)rowObject;
                return item.DateUpdate.ToString("dd/MM/yyyy");
            };

            this.olvColumn4.AspectGetter = delegate(object rowObject)
            {
                ChangeItem item = (ChangeItem)rowObject;
                return item.DateUpdate.ToString("HH:mm:ss tt");
            };

            fullviewRadio.Checked = true;
            simpleViewRadio.Checked = false;
        }


        #endregion

        #region Events
        private void filter1_TextChanged(object sender, EventArgs e)
        {
            FilterText = filter1.Text;
            RefreshChangeList();
        }

        private void HistoryFrm_Load(object sender, EventArgs e)
        {
            RefreshChangeList();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RefreshChangeList();
        }

        private void callRadio_CheckedChanged(object sender, EventArgs e)
        {
            RefreshChangeList();
        }

        private void workerRadio_CheckedChanged(object sender, EventArgs e)
        {
            RefreshChangeList();
        }

        private void servicerRadio_CheckedChanged(object sender, EventArgs e)
        {
            RefreshChangeList();
        }
        #endregion
      
        /// <summary>
        /// Refresh the change list depending on whats been selected
        /// </summary>
        private void RefreshChangeList()
        {
            string query = null;

            objectListView1.ClearObjects();

            if (callRadio.Checked)
            {
                //update call changes
                query = "SELECT idChange, dateupdate, uid, tablename, id, fieldname, oldvalue, newvalue FROM tbl_ChangeLog" +
                        " WHERE TableName = 'tbl_Calls'";
            }
            else if (workerRadio.Checked)
            {
                //update worker changes
                query = "SELECT idChange, dateupdate, uid, tablename, id, fieldname, oldvalue, newvalue FROM tbl_ChangeLog" +
                     " WHERE TableName = 'tbl_Worker'";
            }
            else if (servicerRadio.Checked)
            {
                //update service user changes
                query = "SELECT idChange, dateupdate, uid, tablename, id, fieldname, oldvalue, newvalue FROM tbl_ChangeLog" +
                  " WHERE TableName = 'tbl_ServiceUser'";
            }
            else if (callassignmentradio.Checked)
            {
                query = "SELECT idChange, dateupdate, uid, tablename, id, fieldname, oldvalue, newvalue FROM tbl_ChangeLog" +
                   " WHERE TableName = 'tbl_Worker_Assignment'";                  
            }

            if (query == null)
                return;

            if (FilterText.Trim() != "")
                query += " and (fieldname like '%" + FilterText + "%' or oldvalue like '%" + FilterText + "%' or newvalue like '%" + FilterText + "%')";

            query += " ORDER BY idChange DESC";

            try
            {
                DataTable dt = Cura.Common.Database.ExecuteDatabaseQuery(query);

                List<ChangeItem> changes = new List<ChangeItem>();

                foreach (DataRow row in dt.Rows)
                {
                    changes.Add(new ChangeItem()
                    {
                        ID = Convert.ToInt32(row[0]),
                        DateUpdate = (DateTime)row[1],
                        UID = row[2].ToString(),
                        TableName = row[3].ToString(),
                        TableID = Convert.ToInt32(row[4]),
                        FieldName = row[5].ToString(),
                        OldValue = row[6].ToString(),
                        NewValue = row[7].ToString()
                    });
                }

                objectListView1.Objects = changes;
            }
            catch (Exception ex)
            {

            }
        }
       
    }
}

