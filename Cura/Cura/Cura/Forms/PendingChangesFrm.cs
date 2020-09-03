using BrightIdeasSoftware;
using Cura.Common;
using Cura.Forms.Common;
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
    public partial class PendingChangesFrm : BaseFrm
    {

        #region Constructor

        public PendingChangesFrm()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Load

        private void PendingChangesFrm_Load(object sender, EventArgs e)
        {
          
            RefreshPendingItems();
        }

        #endregion

        #region Events

        private void objectListView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            RefreshToolBar();
        }

        private void selectAllbtn_Click(object sender, EventArgs e)
        {
            //foreach (OLVListItem item in objectListView1.Items)
            //{
            //    item.Checked = true;
            //}
            //foreach (OLVListItem item in objectListView1.Objects)
            //{
            //    item.Checked = true;
            //}

            this.objectListView1.CheckedObjectsEnumerable = this.objectListView1.Objects;

            RefreshToolBar();
        }

        private void unselectallbtn_Click(object sender, EventArgs e)
        {
            //foreach (OLVListItem item in objectListView1.Items)
            //{
            //    item.Checked = false;
            //}
            this.objectListView1.CheckedObjects = null;

            RefreshToolBar();
        }

        private void saveTSbtn_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("This will save " + objectListView1.CheckedObjects.Count.ToString() + " changes. Is that correct?", "Change Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
                return;

            Cursor = Cursors.WaitCursor;

            try
            {

                //Get all the checked objects
                IEnumerable<Call> toSave = objectListView1.CheckedObjects.Cast<Call>();

                //Divide them up into Insert and Update
                IEnumerable<Call> toInsert = toSave.Where(c => c.ID == 0);
                IEnumerable<Call> toUpdate = toSave.Where(c => c.ID != 0);

                //Start the Loading Form.
                Loading.Instance.Start(toSave.Count());

                //First lets get all the updates out of the way
                foreach (Call call in toUpdate)
                {
                    call.Save();
                    Loading.Instance.Value++;
                }

                int batchIndex = 0;
                if (toInsert.Count() > 0)
                {
                    //First things first, lets get the current max id from tbl_Calls
                    int highestCallId = Convert.ToInt32(Database.ExecuteDatabaseQuery("SELECT ifnull(max(id), 0) FROM tbl_Calls").Rows[0][0]);

                    //do a batch insert
                    while (toInsert.Count() > 0)
                    {
                        //try to get the max amount of calls (MAX_PARAMETER_COUNT / 8 fields that a call has)

                        int callFieldQueryCount = Call.TOTAL_DB_FIELD_COUNT - 1; //ignore geting id

                        callFieldQueryCount += 1; // add 1 for the idBatchIndex

                        //take a batch from the calls left to insert. this should hopefully not break any sqlite rules
                        Call[] newcalls = toInsert.Take((int)Math.Floor((double)(Database.MAX_PARAMETER_COUNT / callFieldQueryCount))).ToArray();

                        //create a batch index for all call, so we can find it later
                        int batchStartIndex = batchIndex;

                        //iterate over each call
                        foreach(Call call in newcalls)
                        {
                           call.idBatchIndex = batchIndex++;
                        }

                        //create the bulkquery statement and execute it
                        BulkInsertData data = CallCollection.GenerateBulkInsertQuery(newcalls);
                        Database.ExecuteDatabaseStatement(data.query, data.prms.ToArray());

                        //now get all the ids that have been inserted
                        DataTable dt = Database.ExecuteDatabaseQuery("SELECT id, idBatchIndex FROM tbl_Calls WHERE id > " + highestCallId.ToString());

                        //now we can iterate over each call we just inserted
                        for (int i = 0; i < newcalls.Length; i++)
                        {
                            //get this call from the list
                            Call call = newcalls.SingleOrDefault(c => c.idBatchIndex == Convert.ToInt32(dt.Rows[i][1]));

                            if (call == null)
                                continue;

                            //set the new id
                            call.ID = Convert.ToInt32(dt.Rows[i][0]);

                            //keep highestCallId up to date
                            if(call.ID > highestCallId)
                                highestCallId = call.ID;

                            //insert change in change tracker
                            ChangeTracker.InsertChange(System.Environment.UserName, DateTime.Now, "tbl_Calls", call.ID, call, ChangeTracker.ChangeType.Insert);

                            call.ConstructOld();
                        }

                        //add how many new calls have just been added!
                        Loading.Instance.Value += newcalls.Length;
                    }
                }

                Loading.Instance.Stop();

                MessageBox.Show("Successfully Saved Selected Items", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("There was an error saving some of the pending changes", ex);
            }

            try
            {
                RefreshPendingItems();
            }
            catch (Exception ex) { }

            ServiceUserManager.Instance.RefreshControls(false, false, false);

            Cursor = Cursors.Default;
        }

        private void undoTSbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will undo " + objectListView1.CheckedObjects.Count.ToString() + " changes. Is that correct?", "Change Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
                return;


            foreach (Call call in objectListView1.CheckedObjects)
            {
              //  Call call = item.RowObject as Call;
                call.UndoPendingChanges();
            }

            try
            {
                RefreshPendingItems();
            }
            catch (Exception ex) { }

            ServiceUserManager.Instance.RefreshControls(false, false, false);
        }

        #endregion 

        /// <summary>
        /// Refresh the pending items 
        /// </summary>
        private void RefreshPendingItems()
        {
           IEnumerable<Call> callsWithChanges =  CallManager.Instance.Calls.Where(c => c.HasChanges);

           objectListView1.Objects = callsWithChanges;

            RefreshToolBar();
        }

        /// <summary>
        /// refresh the controls
        /// </summary>
        private void RefreshToolBar()
        {
            undoTSbtn.Enabled = objectListView1.CheckedObjects.Count > 0;
            saveTSbtn.Enabled = objectListView1.CheckedObjects.Count > 0;
        }

    }
}
