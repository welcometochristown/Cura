using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using BrightIdeasSoftware;
using Cura.Forms;
using Cura.Forms.Common;

namespace Cura.Controls
{
    public partial class ServiceUserListCtrl : UserControl
    {
        #region Fields
        private string _SearchText;
        private bool isChangingFilter;
        private bool isNameFilter;
        private bool _showNewButton;
        private bool _showFilters;
        private bool _allowOpenServiceUser;
        private bool _showContextMenu;

        private DateTime _startDate;
        private DateTime _periodstartdate;

        public bool isManagerSelectionChange = false;

        private bool isSolo;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceUserListCtrl()
        {
            InitializeComponent();

            this.isNameFilter = true;
            this.isSolo = false;
            this._showNewButton = true;
            this._showFilters = true;
            this._showContextMenu = true;
            this._allowOpenServiceUser = true;

        }
        public ServiceUserListCtrl(bool isSolo)
        {
            InitializeComponent();

            this.isNameFilter = true;
            this.isSolo = isSolo;
            this._showNewButton = true;
            this._showFilters = true;
            this._allowOpenServiceUser = true;
            this._showContextMenu = true;

        }
        #endregion

        #region Control Load
        /// <summary>
        /// Load The Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServiceUserListCtrl_Load(object sender, EventArgs e)
        {
           // UpdateFilter();
            
        }
        #endregion
        
        #region Properties
        public bool ShowContextMenu
        {
            get
            {
                return _showContextMenu;
            }
            set
            {
                _showContextMenu = value;
            }
        }
        public bool AllowOpenServiceUser
        {
            get
            {
                return _allowOpenServiceUser;
            }
            set
            {
                _allowOpenServiceUser = value;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime PeriodStartDate
        {
            get
            {
                return _periodstartdate;
            }
            set
            {

                _periodstartdate = value;

            }
        }

        public bool ShowFilters
        {
            get
            {
                return _showFilters;
            }
            set
            {
                _showFilters = value;
                panel1.Visible = _showFilters;
            }
        }

        public bool ShowNewButton
        {
            get
            {
                return _showNewButton;
            }
            set
            {
                _showNewButton = value;
                splitContainer1.Panel1Collapsed = !_showNewButton;
            }
        }

        public string SearchText
        {
            get
            {
                return _SearchText;
            }
            set
            {
                _SearchText = value;

                UpdateFilter();
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ServiceUser SelectedItem
        {
            get
            {
                return objectListView1.SelectedObject as ServiceUser;
            }
            set
            {

                //we need to do this check because some lists might have different service users due to period start dates

              //  ServiceUser oldSelected = objectListView1.SelectedObject as ServiceUser;

                objectListView1.SelectedObject = value;

            //    isManagerSelectionChange = (oldSelected != objectListView1.SelectedObject);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEnumerable<ServiceUser> SelectedItems
        {
            get
            {
                return objectListView1.SelectedObjects.Cast<ServiceUser>();

            }
            //only need to set individual selectitems for service users
            //set
            //{
            //    isManagerSelectionChange = true;

            //    objectListView1.SelectedObjects = value.ToList();
            //}
        }

        public IEnumerable<ServiceUser> ServiceUsers
        {
            get
            {
                if (objectListView1.Objects == null)
                    return null;

                return objectListView1.Objects.Cast<ServiceUser>();
            }
            set
            {
                if (value == null)
                {
                    objectListView1.ClearObjects();
                }
                else
                {
                    objectListView1.SetObjects(value);
                }
            }
        }

        public ServiceUserListSearchBarFilter Filter
        {
            get
            {
                return objectListView1.ModelFilter as ServiceUserListSearchBarFilter;
            }
            set
            {

                isChangingFilter = true;

                ServiceUserListSearchBarFilter filter = value; //((ServiceUserListSearchBarFilter)value).Clone();
                objectListView1.ModelFilter = filter;

                if (filter != null)
                {

                    filter.startDate = this._startDate;
                    filter2.Text = filter.filterTxt;
                    hideFullAssignedChk.Checked = filter.hideFullAssigned;
                    hideEmptyChk.Checked = filter.hideEmpty;
                    isNameFilter = filter.isNameFilter;

                }
        
                searchTypeBtn.Image = isNameFilter ? Cura.Properties.Resources.font : Cura.Properties.Resources.shield;
                isChangingFilter = false;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {

                _startDate = value;

                UpdateFilter();
            }
        }

        #endregion

        #region Filter Events
        public event EventHandler ServiceUserSelectionChanged;

        private void filter1_TextChanged(object sender, EventArgs e)
        {
            SearchText = filter2.Text;
        }

        #endregion

        #region Object List Events

        private void objectListView1_SelectionChanged_1(object sender, EventArgs e)
        {
            ////check whether this selection change was caused by the manager setting the selected items, if so then just ignore.
            //if (isManagerSelectionChange)
            //{
            //    isManagerSelectionChange = false;
            //    return;
            //}

            //fire off event when someone has clicked a new selected
            if (ServiceUserSelectionChanged != null)
            {
                ServiceUserSelectionChanged(sender, e);
            }
        }
        #endregion

        #region ContextMenuStrip Events

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (SelectedItem == null || !_showContextMenu)
                e.Cancel = true;

            editToolStripMenuItem.Visible = _allowOpenServiceUser;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedItem == null || !_allowOpenServiceUser)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                ServiceUser serviceuser = SelectedItem;

                ServiceUserFrm frm = new ServiceUserFrm()
                {
                    ID = serviceuser.id,
                    PNumber = serviceuser.PNumber,
                    Firstname = serviceuser.firstname,
                    Surname = serviceuser.surname,
                    ContactNoPrimary = serviceuser.contactno_primary,
                    ContactNoSecondary = serviceuser.contactno_secondary,
                    Title = "Edit Service User",
                    Gender = serviceuser.idGender,
                    MedicalInfo = serviceuser.medicalinfo,
                    Notes = serviceuser.notes,
                    PeriodStartDate = serviceuser.ServiceBegins,
                    PeriodWeekCount = serviceuser.PeriodWeekCount,
                    ImportantNotes = serviceuser.isNotesImportant,
                    DOB = serviceuser.dob,
                    Add1 = serviceuser.add1,
                    Add2 = serviceuser.add2,
                };

                frm.CallHistory = serviceuser.CallHistory;
               
                frm.SetLongLat(serviceuser.LongLatCoords);

                frm.Workers = WorkerManager.Instance.ActiveWorkers;
                frm.KeyWorkers.AddRange(serviceuser.KeyWorkers);

                Cursor = Cursors.Default;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //add this user to the database

                    serviceuser.firstname = frm.Firstname;
                    serviceuser.surname = frm.Surname;
                    serviceuser.dob = frm.DOB;
                    serviceuser.contactno_primary = frm.ContactNoPrimary;
                    serviceuser.contactno_secondary = frm.ContactNoSecondary;
                    serviceuser.postcode = frm.LongLat.pCode;
                    serviceuser.add1 = frm.Add1;
                    serviceuser.add2 = frm.Add2;
                    serviceuser.idGender = frm.Gender;
                    serviceuser.LongLatCoords = frm.LongLat;
                    serviceuser.medicalinfo = frm.MedicalInfo;
                    serviceuser.notes = frm.Notes;
                    serviceuser.ServiceBegins = frm.PeriodStartDate;
                    serviceuser.PeriodWeekCount = frm.PeriodWeekCount;
                    serviceuser.isNotesImportant = frm.ImportantNotes;
                    serviceuser.notes = frm.Notes;

                    //clear this service user from all its key workers
                    foreach (Worker worker in serviceuser.KeyWorkers)
                    {
                        worker.KeyServiceUsers.Remove(serviceuser);
                    }

                    //clear the service users key workers
                    serviceuser.KeyWorkers.Clear();

                    // add the new keyworkers
                    serviceuser.KeyWorkers.AddRange(frm.KeyWorkers);

                    //add service user to key workers
                    foreach (Worker worker in frm.KeyWorkers)
                    {
                        worker.KeyServiceUsers.Add(serviceuser);

                        //refresh the old key service users here so the change of service user on teh worker isnt
                        //seen as a change
                        worker.OldKeyServiceUsers.Clear();
                        worker.OldKeyServiceUsers.AddRange(worker.KeyServiceUsers);
                    }

                    //attempt to save
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        serviceuser.MarkForSave = true;
                        serviceuser.Save();
                    }
                    catch (Exception ex)
                    {
                        Cura.Common.Common.LogError("Error Occured While Trying To Save This Service User", ex);
                    }

                    //rebuild the list
                    ServiceUserManager.Instance.RefreshControls(false, false , false);
                    WorkerManager.Instance.RefreshControls(false, false, false);

                }

                frm.Dispose();
            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("Error Editing Service User", ex);
            }

            Cursor = Cursors.Default;
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedItem == null)
                return;

            DialogResult res = MessageBox.Show("Would you like to duplicate key workers?", "Key Workers", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (res == DialogResult.Cancel)
                return;

            ServiceUser serviceuser = SelectedItem.Duplicate(res==DialogResult.Yes);

            serviceuser.surname += " - Copy";

            serviceuser.Save();

            objectListView1.AddObject(serviceuser);
            objectListView1.BuildList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (ServiceUser serviceuser in SelectedItems)
                {
                    if (serviceuser.Calls.Count > 0)
                    {
                        MessageBox.Show("This service user still has calls assigned to this service user.\r\nYou need to delete these first", "Delete Service User", MessageBoxButtons.OK);
                        return;
                    }

                    Cursor = Cursors.WaitCursor;

                    //delete the service user
                    serviceuser.Delete();

                    //save the change
                    serviceuser.Save();

                    //remove from the list
                    objectListView1.RemoveObject(serviceuser);

                    Cursor = Cursors.Default;
                }

            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("Error Deleteing Service User", ex);
            }

            Cursor = Cursors.Default;
          
        }

        #endregion

        #region Events

        private void searchTypeBtn_Click(object sender, EventArgs e)
        {
            this.isNameFilter = !this.isNameFilter;

            UpdateFilter();
        }

        private void hideFullAssignedChk_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFilter();

        }

        private void addServiceUserBtn_Click(object sender, EventArgs e)
        {
            if (Settings.IsTrial && ServiceUserManager.Instance.ServiceUsers.Count >= 5)
            {
                MessageBox.Show("You can only create a maximum of 5 service users while using a trial version of this product.", "Trial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            try
            {
                ServiceUserFrm frm = new ServiceUserFrm()
                {
                    Title = "Create Service User",
                    Workers = WorkerManager.Instance.ActiveWorkers
                };

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //add this user to the database
                    ServiceUser new_serviceuser = new ServiceUser()
                    {
                        firstname = frm.Firstname,
                        surname = frm.Surname,
                        dob = frm.DOB,
                        ServiceBegins = frm.PeriodStartDate,
                        PeriodWeekCount = frm.PeriodWeekCount,
                        contactno_primary = frm.ContactNoPrimary,
                        contactno_secondary = frm.ContactNoSecondary,
                        postcode = frm.LongLat.pCode,
                        PNumber = frm.PNumber,
                        idGender = frm.Gender,
                        LongLatCoords = frm.LongLat,
                        medicalinfo = frm.MedicalInfo,
                        notes = frm.Notes,
                        isNotesImportant = frm.ImportantNotes,
                        add1 = frm.Add1,
                        add2 = frm.Add2
                    };

                    //clear the service users key workers
                    new_serviceuser.KeyWorkers.Clear();

                    // add the new keyworkers
                    new_serviceuser.KeyWorkers.AddRange(frm.KeyWorkers);

                    //add service user to key workers
                    foreach (Worker worker in frm.KeyWorkers)
                    {
                        worker.KeyServiceUsers.Add(new_serviceuser);

                        //refresh the old key service users here so the change of service user on teh worker isnt
                        //seen as a change
                        worker.OldKeyServiceUsers.Clear();
                        worker.OldKeyServiceUsers.AddRange(worker.KeyServiceUsers);
                    }

                    //attempt to save
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        new_serviceuser.Save();

                        //add to the ServiceUserManager
                        ServiceUserManager.Instance.ServiceUsers.Add(new_serviceuser);

                    }
                    catch (Exception ex)
                    {
                        Cura.Common.Common.LogError("Error Occured While Trying To Save This New Service User", ex);
                    }

                    if (new_serviceuser.KeyWorkers.Count() > 0)
                    {
                        WorkerManager.Instance.RefreshLists(false, false, false);
                    }

                }

                frm.Dispose();
            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("Error Creating New Service User", ex);
            }
            Cursor = Cursors.Default;
        }

        private void objectListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                editToolStripMenuItem_Click(this, null);
            }
        }

  

 #endregion

        /// <summary>
        /// Refresh the control and items
        /// </summary>
        public override void Refresh()
        {
            base.Refresh();

            //isManagerSelectionChange = true;
            objectListView1.BuildList(true);

        }

        /// <summary>
        /// Update the filter
        /// </summary>
        private void UpdateFilter()
        {
           try
            {

                if (!isChangingFilter)
                {
                    if (isSolo)
                    {
                        Filter = new ServiceUserListSearchBarFilter() { filterTxt = _SearchText, hideFullAssigned = hideFullAssignedChk.Checked, hideEmpty = hideEmptyChk.Checked, isNameFilter = this.isNameFilter };

                    }
                    else
                    {
                        ServiceUserManager.Instance.ServiceUserListFilter = new ServiceUserListSearchBarFilter() { filterTxt = _SearchText, hideFullAssigned = hideFullAssignedChk.Checked, hideEmpty = hideEmptyChk.Checked, isNameFilter = this.isNameFilter };
                    }
                }
            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("Error Updating Filter", ex);
            }
        }
        
    }

    public class ServiceUserListSearchBarFilter : IModelFilter
    {
        public string filterTxt;
        public bool hideFullAssigned;
        public bool hideEmpty;
        public bool isNameFilter;
        public DateTime startDate;


        public ServiceUserListSearchBarFilter Clone()
        {
            ServiceUserListSearchBarFilter filter = new ServiceUserListSearchBarFilter();

            filter.filterTxt = filterTxt;
            filter.hideFullAssigned = hideFullAssigned;
            filter.hideEmpty = hideEmpty;
            filter.isNameFilter = isNameFilter;
            filter.startDate = startDate;

            return filter;
        }

        public ServiceUserListSearchBarFilter()
        {
            this.filterTxt = "";
            this.hideFullAssigned = false;
            this.hideEmpty = false;
            this.isNameFilter = true;
        }

        public bool Filter(object modelObject)
        {
            //first lets check the service users service period
            ServiceUser serviceuser = modelObject as ServiceUser;

            bool retVal = false;

            DateTime thisWeekStartDate = startDate;
            DateTime thisWeekEndDate = thisWeekStartDate.AddDays(7);

            //if the service begins before the end of the week and after the beginning of the week then show it!
            bool a1 = serviceuser.ServiceBegins < thisWeekEndDate && serviceuser.ServiceBegins >= thisWeekStartDate;

            //if the service begins before this weekstart and ends after this week start then show it
            bool a2 = thisWeekStartDate > serviceuser.ServiceBegins && thisWeekStartDate < serviceuser.ServiceEnds;
         
         
            if (startDate != DateTime.MinValue && !(a1 || a2))
            {
                retVal = false;
            }

            else if (hideEmpty && serviceuser.Calls.Count == 0)
            {
                retVal = false;
            }

            else if (hideFullAssigned && serviceuser.Calls.Count > 0 && serviceuser.IsFullyAssigned)
            {
                retVal = false;
            }

            else if (filterTxt == null || filterTxt == "")
            {
                retVal = true;
            }

            else
            {
                string txt = (isNameFilter ? serviceuser.Name : serviceuser.PNumber).Trim().ToLower();

                if (txt == null)
                    retVal = false;
                else
                    retVal = txt.Contains(filterTxt.Trim().ToLower());
            }

       
            return retVal;
        }
    }
}
