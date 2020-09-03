using Cura.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Cura.Controls;
using Cura.Forms.Common;
using Cura.Common;
using System.Runtime.InteropServices;

namespace Cura
{
    public partial class MainFrm : Form
    {
        [DllImport("User32.dll")]
        internal static extern Int32 SetForegroundWindow(int hWnd);   

        #region Fields
        private DateTime? lastDateTime = null;
        private bool closethisbabydown;
        private List<WeekCtrl> weekctrls;
        private SplashScreen _splashy;
        private Call nextUnAssignedCall = null;
        private DateTime CurrentPeriodDateStart;
        #endregion

        #region Constructor

        System.Threading.Thread thread;
        static void thread_func(object obj)
        {
            SplashScreen splashy = obj as SplashScreen;
            splashy.ShowDialog();
        }

        private delegate void CloseSplashyDelegate();
        private void CloseSplashy()
        {
            if (_splashy == null)
                return;

            if (_splashy.InvokeRequired)
            {
                _splashy.Invoke(new CloseSplashyDelegate(CloseSplashy));
                return;

            }
            _splashy.Close();
        }


        /// <summary>
        /// Main Form Constructor
        /// </summary>
        public MainFrm()
        {

            _splashy = new SplashScreen();
            thread = new System.Threading.Thread(thread_func);
            thread.Start(_splashy);

            WorkerManager.Instance.IgnoreControlRefresh = true;
            ServiceUserManager.Instance.IgnoreControlRefresh = true;

            try
            {

                #region SettingsCheck
                if (!PerformSettingsCheck())
                {
                    closethisbabydown = true;
                    this.Load += new System.EventHandler(this.Form1_Load);
                    return;
                }
                #endregion

                //Initialise the form
                InitializeComponent();

                tabcontrl.AllowDrop = false;

                weekctrls = new List<WeekCtrl>();
  
            }
            catch (Exception e)
            {
                closethisbabydown = true;
                Cura.Common.Common.LogError("Error Loading Cura", e);
            }

            Settings.Instance.SettingsChanged += Instance_SettingsChanged;
            //forsophie
            //for (int i = 0; i < 13; i++) Console.Write((char)(((int)'a') + new int[] { 8, -65, 11, 14, 21, 4, -65, 18, 14, 15, 7, 8, 4 }[i]));
      
            Opacity = 0;
        }

        void Instance_SettingsChanged(object sender, Cura.Settings.SettingsEventArgs e)
        {
            //check whether we need to reload the data 
            if (e.DataReloadRequired)
            {
                CallManager.Instance.Unload();
                WorkerManager.Instance.Unload();
                ServiceUserManager.Instance.Unload();

                RefreshTabs();
                RefreshDateWeekCombo();

            }
          
            WorkerManager.Instance.RefreshControls(true, false, false);
            ServiceUserManager.Instance.RefreshControls(true, false, false);  

        }


        #endregion

        #region FormLoad
        /// <summary>
        /// Load the main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //check whether something went wrong before the form can load .. probably a settings erro
                if (closethisbabydown)
                {
                    Close();
                }
                else
                {

                    RefreshTabs();
                    RefreshDateWeekCombo();

                    //<dep> is done when week combo is selected
                    //WorkerManager.Instance.RefreshControls();
                    //ServiceUserManager.Instance.RefreshControls();

                    CallManager.Instance.CallChange += new EventHandler(this.CallChange);

                    RefreshToolBar();
                    
                    // this is the mess to get the splash screen and main form to properly show
                    //ShowInTaskbar = true;
                    Opacity = 100;
                    SetForegroundWindow(Handle.ToInt32());

                }

         
            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("Failed to Load Cura Main View", ex);
                Close();
            }

            CloseSplashy();

        }
        #endregion
     
        #region Events

        private void tabcontrl_TabPageClosing(object sender, KRBTabControl.KRBTabControl.SelectedIndexChangingEventArgs e)
        {
            //temporary fix
            e.Cancel = true;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            BackupRestoreFrm frm = new BackupRestoreFrm();
            frm.ShowDialog();
        }


        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CallManager.Instance.HasChanges)
            {
                if (MessageBox.Show("There are still pending changes, are you sure you want to close?\r\nAny unsaved changes will be lost.", "Pending Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void CallChange(object sender, EventArgs args)
        {
            RefreshToolBar();
        }

        /// <summary>
        /// Pending changes menu button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                PendingChangesFrm frm = new PendingChangesFrm();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("Error Loading Pending Changes", ex);
            }
            
            //calls changed, refresh what we need to.
            CallChange(this, null);
        }

       
        private void weekSelectionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                RotaPeriod rp = (weekSelectionCombo.SelectedItem as ComboItem).obj as RotaPeriod;

                DateTime first = rp.dateFrom;

                WorkerManager.Instance.IgnoreControlRefresh = true;
                ServiceUserManager.Instance.IgnoreControlRefresh = true;


                CallManager.Instance.CurrentRotaPeriodStart = first;

                CurrentPeriodDateStart = first;

                for (int i = 0; i < weekctrls.Count; i++)
                {
                    WeekCtrl weekCtrl = weekctrls[i];

                    //set the date the period starts
                    weekCtrl.PeriodStartDate = first;

                    //set which week of the period this is
                    weekCtrl.WeekStartDate = first.AddDays(i * 7);
                }

                ((PeriodOverviewCtrl)overviewTabPage.Controls[0]).PeriodStartDate = first;

                WorkerManager.Instance.IgnoreControlRefresh = false;
                ServiceUserManager.Instance.IgnoreControlRefresh = false;



                WorkerManager.Instance.RefreshControls(true, false, false);
                ServiceUserManager.Instance.RefreshControls(true, false, false);
            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("Error Selecting Rota Period", ex);
            }
        }


        private void helptoolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
               // Help.ShowHelp(this, "cura.chm");

                Cura.Forms.LibraryHelpFrm frm = new Cura.Forms.LibraryHelpFrm();
                frm.ShowDialog();

            } catch (Exception ex)
            {
                Cura.Common.Common.LogError("Error Loading Cura Help", ex);
            }
        }

        #endregion

        #region ToolStrip Menu Events
        private void tabcontrl_SelectedIndexChanging(object sender, KRBTabControl.KRBTabControl.SelectedIndexChangingEventArgs e)
        {
            try
            {


                if (e.TabPageIndex == tabcontrl.TabPages.Count - 1)
                {
                    PeriodOverviewCtrl ctrl = overviewTabPage.Controls[0] as PeriodOverviewCtrl;

                    if (ctrl == null)
                        return;

                    ctrl.RefreshData();
                }
            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("Failed To Load Data In This Tab", ex);
            }

        }

        HolidayFrm holidayFrm;
        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (holidayFrm == null || holidayFrm.IsDisposed)
                {
                    holidayFrm = new HolidayFrm();
                }

                holidayFrm.Show();
            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("Failed To Load The Holiday Rota", ex);
            }
        }

        private void nextunassigndcallbtn_Click(object sender, EventArgs e)
        {

            try
            {

                IEnumerable<Call> unassignedcalls = CallManager.Instance.UnassignedCallsThisPeriod.OrderBy(c => c.ServiceUserName);

                if (unassignedcalls.Count() == 0)
                    return;

                if (nextUnAssignedCall == null || unassignedcalls.Count() == 1)
                {
                    nextUnAssignedCall = unassignedcalls.ElementAt(0);
                }
                else
                {
                    int index = unassignedcalls.ToList().IndexOf(nextUnAssignedCall);

                    if (index == unassignedcalls.Count() - 1)
                    {
                        nextUnAssignedCall = unassignedcalls.ElementAt(0);
                    }
                    else
                    {
                        nextUnAssignedCall = unassignedcalls.ElementAt(index + 1);
                    }
                }

                Console.WriteLine(nextUnAssignedCall.ServiceUserName + " " + nextUnAssignedCall.time.ToString());

                ShowCall(nextUnAssignedCall);
            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("Failed To Find Next Unassigned Call", ex);
            }

        }

        private void settingsToolStripBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Settings settings = Settings.Instance;

                SettingsFrm frm = new SettingsFrm()
                {
                    SecurityKey = settings.securitykey,
                    DataFilePath = settings.datafilepath,
                    FirstWeek = settings.firstweek,
                    RotaRange = settings.rotarange,
                    WeeksInRotaPeriod = settings.rotaweekcount,
                    DisplayCallsWithTravelTime = settings.displaycallwithtraveltime
                };


                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    Cursor = Cursors.WaitCursor;

                    Loading.Instance.Start();

                    if (settings.datafilepath != frm.DataFilePath ||
                        settings.firstweek != frm.FirstWeek ||
                        settings.rotaweekcount != frm.WeeksInRotaPeriod)
                    {
                        if (CallManager.Instance.Calls.Where(c => c.HasChanges).Count() > 0)
                        {
                            MessageBox.Show("These changes can't be saved until all pending changes have been dealt with.", "Changes Pending", MessageBoxButtons.OK);
                            return;
                        }
                    }

                    settings.ChangeSettings(frm.SecurityKey, 
                                            frm.DataFilePath, 
                                            frm.FirstWeek, 
                                            frm.RotaRange, 
                                            frm.WeeksInRotaPeriod, 
                                            frm.DisplayCallsWithTravelTime);

                    try
                    {
                        settings.Save();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to save settings");
                    }

                }
            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("Failed to Load Cura Settings", ex);
            }

            Loading.Instance.Stop();

            Cursor = Cursors.Default;


        }

        private void historyToolstripButton_Click(object sender, EventArgs e)
        {

            try
            {
                HistoryFrm frm = new HistoryFrm();
                frm.Show();
            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("Failed to Load Historical Changes", ex);
            }
        }

        private void careWorkerListtoolStripBtn_Click(object sender, EventArgs e)
        {
            WorkerListFrm frm = null;

            try
            {
                frm = new WorkerListFrm();
                frm.Workers = WorkerManager.Instance.Workers;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("Failed to Load Worker List", ex);
            }

            if (frm != null)
                frm.Dispose();
        }

        private void allserviceuserbtn_Click(object sender, EventArgs e)
        {
            ServiceUserListFrm frm = null;
            try
            {

                frm = new ServiceUserListFrm();
                frm.ServiceUsers = ServiceUserManager.Instance.ServiceUsers;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError("Failed to Load Service User List", ex);
            }

            if (frm != null)
                frm.Dispose();
        }


        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                About frm = new About();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
              //just ignore 
            }
       
        }

        #endregion

        #region Icon Red / White Heart Hover

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Cura.Properties.Resources.header_red_short;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Cura.Properties.Resources.header_short;
        }

        #endregion

        /// <summary>
        /// Perform the initial settings check
        /// </summary>
        /// <returns></returns>
        private bool PerformSettingsCheck()
        {
            Settings settings = Settings.Instance;

            if (!settings.IsValid)
            {
                SettingsFrm frm = new SettingsFrm();

                frm.DataFilePath = settings.datafilepath;
                frm.SecurityKey = settings.securitykey;
                frm.FirstWeek = settings.firstweek;
                frm.RotaRange = settings.rotarange;
                frm.WeeksInRotaPeriod = settings.rotaweekcount;
                frm.DisplayCallsWithTravelTime = settings.displaycallwithtraveltime;

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //save the settings
                    settings.datafilepath = frm.DataFilePath;
                    settings.securitykey = frm.SecurityKey;
                    settings.firstweek = frm.FirstWeek;
                    settings.rotarange = frm.RotaRange;
                    settings.rotaweekcount = frm.WeeksInRotaPeriod;
                    settings.displaycallwithtraveltime = frm.DisplayCallsWithTravelTime;

                    try
                    {
                        settings.Save();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to save settings");
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }


            return true;
        }

        /// <summary>
        /// Refresh the dates in the period selection combo
        /// </summary>
        private void RefreshDateWeekCombo()
        {

            weekSelectionCombo.Items.Clear();

            DateTime currentPeriodStart = DateCalculations.GetStartOfRotaPeriod(DateTime.Now);

            Color pastCol = ColorTranslator.FromHtml("#FFA8A8");
            Color currCol = ColorTranslator.FromHtml("#72FE95");
            Color futrCol = ColorTranslator.FromHtml("#75ECFD");

            int range = Settings.Instance.rotarange;

            DateTime dateFrom = currentPeriodStart.AddDays(-(7 * Settings.Instance.rotaweekcount * range));
            DateTime dateTo = dateFrom.AddDays((Settings.Instance.rotaweekcount * 7) - 1);

            for (int i = 0; i < (range * 2) + 1; i++)
            {
                Color col = currCol;

                if (i < range)
                    col = pastCol;
                else if (i > range)
                    col = futrCol;

                weekSelectionCombo.Items.Add(new ComboItem() { obj = new RotaPeriod() { dateFrom = dateFrom, dateTo = dateTo }, color = col });

                dateFrom = dateFrom.AddDays(7 * Settings.Instance.rotaweekcount);
                dateTo = dateTo.AddDays(7 * Settings.Instance.rotaweekcount);
            }

            //select the current period as being start one
            weekSelectionCombo.SelectedIndex = range;

            //also select current week tab
            int weeksgone = (int)((DateTime.Now - currentPeriodStart).TotalDays / 7);
            KRBTabControl.TabPageEx tab = weekctrls[weeksgone].Parent as KRBTabControl.TabPageEx;
            tabcontrl.SelectedTab = tab;

        }

        /// <summary>
        /// Refresh any changes in the toolbar
        /// </summary>
        private void RefreshToolBar()
        {
            pendingchangesbtn.Image = (CallManager.Instance.HasChanges ? Properties.Resources.star_16 : Properties.Resources.star_bw_16);
            pendingchangesbtn.Invalidate();
            nextunassigndcallbtn.Enabled = CallManager.Instance.UnassignedCallsThisPeriod.Count() > 0;
        }

        /// <summary>
        /// Refresh which tabs are showing
        /// </summary>
        private void RefreshTabs()
        {
       
            tabcontrl.TabPages.Clear();
            weekctrls.Clear();


            for (int i = 0; i < Settings.Instance.rotaweekcount; i++)
            {
                //create a new work control
                WeekCtrl newone = new WeekCtrl();

                //create a tab page for it
                KRBTabControl.TabPageEx page = new KRBTabControl.TabPageEx("Week " + (i + 1).ToString()) { IsClosable = false };

                //add the new week contrl to the tabpage
                page.Controls.Add(newone);

                //set the week control to be fill docked
                newone.Dock = System.Windows.Forms.DockStyle.Fill;

                //add the tab page to the control
                tabcontrl.TabPages.Add(page);

                //add the week control to our list of em
                weekctrls.Add(newone);
            }

            tabcontrl.TabPages.Add(overviewTabPage);

        }

        /// <summary>
        /// Make a specific call visible.
        /// </summary>
        /// <param name="call"></param>
        public void ShowCall(Call call)
        {

            try
            {
                int weeksgone = (int)(call.time - CurrentPeriodDateStart).TotalDays / 7;
                KRBTabControl.TabPageEx tab = weekctrls[weeksgone].Parent as KRBTabControl.TabPageEx;
                tabcontrl.SelectedTab = tab;

                ServiceUserManager.Instance.SelectedServiceUsers.Clear();
                ServiceUserManager.Instance.SelectedServiceUsers.Add(call.ServiceUser);
            }
            catch (Exception ex)
            {
                Cura.Common.Common.LogError(ex);
            }
            

        }
       
    }
}
