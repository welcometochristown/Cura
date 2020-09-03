using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using BrightIdeasSoftware;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;
using Cura.Forms;
using Cura.Forms.Common;

namespace Cura.Controls
{
	public partial class WorkerListCtrl : UserControl
	{

		#region Fields
		private string _SearchText;
		private bool _showNewButton;
		private bool _showFilters;
		private bool _showContextMenu;
		private bool _showSimpleContextMenu;
		private bool _showByGroup;
		private bool _allowOpenWorker;

		private bool isChangingFilter;
		private bool isSolo;

		private bool isNameFilter;
		private DateTime _startDate;
		private DateTime _periodstartdate;

		bool isManagerSelectionChange;

		//public bool ignoreSelectionChange;
		//public bool ignoreFilterChange;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public WorkerListCtrl()
		{
			InitializeComponent();

			//load all workers and add them to the list
			this._showNewButton = true;
			this._showFilters = true;
			this._showContextMenu = true;
			this._showSimpleContextMenu = false;
			this.isChangingFilter = false;
			this.isSolo = false;
			this.isNameFilter = true;
			this._showByGroup = false;
			this._allowOpenWorker = true;

			//this.ignoreSelectionChange = false;
			//this.ignoreFilterChange = false;

		}

		public WorkerListCtrl(bool isSolo)
		{
			InitializeComponent();

			//load all workers and add them to the list
			this._showNewButton = true;
			this._showFilters = true;
			this._showContextMenu = true;
			this._showSimpleContextMenu = false;
			this.isChangingFilter = false;
			this.isSolo = isSolo;
			this.isNameFilter = true;
			this._showByGroup = false;
			this._allowOpenWorker = false;

			//this.ignoreSelectionChange = false;
			//this.ignoreFilterChange = false;
		}
		#endregion

		#region Control Load
		private void WorkerListCtrl_Load(object sender, EventArgs e)
		{
		//	UpdateFilter();
		}
		#endregion

		#region Properties

		public bool AllowOpenWorker
		{
			get
			{
				return _allowOpenWorker;
			}
			set
			{
				_allowOpenWorker = value;
			}
		}
		public bool GroupResults
		{
			get
			{
				return objectListView1.ShowGroups;
			}
			set
			{
				objectListView1.ShowGroups = value;
			}
		}

		public bool ShowByGroup
		{
			get
			{
				return _showByGroup;
			}
			set
			{

				if (_showByGroup == value)
					return;

				if (value)
				{

				   ((OLVColumn) objectListView1.Columns[0]).GroupKeyGetter = delegate (object rowObject) {

						WorkerGroupViewModel model = rowObject as WorkerGroupViewModel;
						Worker worker = rowObject as Worker;

							if (worker != null)
								return worker.Name;

							return model.GroupName;
				   };

				   List<WorkerGroupViewModel> modelList = WorkerGroupViewModel.GenerateModel(WorkerManager.Instance.Workers);

				   objectListView1.SetObjects(modelList);

				}
				else
				{
					((OLVColumn)objectListView1.Columns[0]).GroupKeyGetter = null;

					objectListView1.SetObjects(WorkerManager.Instance.Workers);
				}


				_showByGroup = value;
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

			}
		}

		public bool ShowSimpleContextMenu
		{
			get
			{
				return _showSimpleContextMenu;
			}
			set
			{
				_showSimpleContextMenu = value;
			}
		}

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
		public IEnumerable<Worker> Workers
		{
			get
			{
				if (objectListView1.Objects == null)
					return null;

				return objectListView1.Objects.Cast<Worker>();
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

	   [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Worker SelectedItem
		{
			get
			{
				return objectListView1.SelectedObject as Worker;
			}
			set
			{
			 //   isManagerSelectionChange = true;

				objectListView1.SelectedObject = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IEnumerable<Worker> SelectedItems
		{
			get
			{

				return objectListView1.SelectedObjects.Cast<Worker>();

			}
			set
			{
		   //     isManagerSelectionChange = true;

				objectListView1.SelectedObjects = value.ToList();
			}
		}

		public WorkerListSearchBarFilter Filter
		{
			get
			{
				return objectListView1.ModelFilter as WorkerListSearchBarFilter;
			}
			set
			{

				isChangingFilter = true;

				WorkerListSearchBarFilter filter = value; //((ServiceUserListSearchBarFilter)value).Clone();

				objectListView1.ModelFilter = filter;

				if (value != null)
				{
					filter1.Text = value.filterTxt;
					hideInactiveChk.Checked = value.hideInactive;
					isNameFilter = value.isNameFilter;
				}

				searchTypeBtn.Image = isNameFilter ? Cura.Properties.Resources.font : Cura.Properties.Resources.shield;
				isChangingFilter = false;
			}
		}
		#endregion

		#region ObjectListView Events
		private void objectListView1_SelectionChanged(object sender, EventArgs e)
		{
			//if (isManagerSelectionChange)
			//{
			//    isManagerSelectionChange = false;
			//    return;
			//}

			if (WorkerSelectionChanged != null)
			{
				WorkerSelectionChanged(sender, e);
			}

		}
		#endregion

		#region ContextMenuStrip Events
		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			if (SelectedItems.Count() == 0  || (!_showContextMenu && !_showSimpleContextMenu))
			{
				e.Cancel = true;
			}
			else
			{
				//disableToolStripMenuItem.Visible = SelectedItem.idStatus == Worker.Status.Active;
				//enableToolStripMenuItem.Visible = SelectedItem.idStatus == Worker.Status.Inactive;

				if (_showSimpleContextMenu)
				{
					editToolStripMenuItem.Visible = false;
					duplicateUserToolStripMenuItem.Visible = false;
					disableToolStripMenuItem.Visible = false;
					enableToolStripMenuItem.Visible = false;
					deleteToolStripMenuItem.Visible = false;
					emailRotaToolStripMenuItem.Visible = false;

					toolStripSeparator2.Visible = false;
					toolStripSeparator3.Visible = false;
				}
				else
				{
					editToolStripMenuItem.Visible = _allowOpenWorker;
				}

				// ok first load up all the groups
				List<WorkerGroup> groups = WorkerGroupManager.Instance.WorkerGroups;

				List<WorkerGroup> groupsToAdd = new List<WorkerGroup>(groups);
				List<WorkerGroup> groupsToRemove = new List<WorkerGroup>();

				// now remove all the groups to ADD except the <new group> one
				for (int i = addToGroupToolStripMenuItem.DropDownItems.Count - 1; i > 0; i--)
					addToGroupToolStripMenuItem.DropDownItems.RemoveAt(i);
				
				//now remove all the groups to REMOVE.
				removeFromGroupToolStripMenuItem.DropDownItems.Clear();

				//=========================================
				// Add Section
				//
				// Here we are going to be adding groups
				// that none of the selected workers are 
				// part of.
				//=========================================


				//first lets get all the groups that exist in all the selected items.
				  List<WorkerGroup> selectedItemsGroups = new List<WorkerGroup>();

			   // create a list of every group, some may occur multiple times. we can jsut use this to see if its for everyone
				foreach (Worker worker in SelectedItems)
				{
					foreach(WorkerGroup group in worker.Groups)
					{
						selectedItemsGroups.Add(group);
					}
				}


				while(selectedItemsGroups.Count() > 0)
				{
					//get the last group in the list
					WorkerGroup group = selectedItemsGroups[selectedItemsGroups.Count - 1];
					selectedItemsGroups.RemoveAt(selectedItemsGroups.Count - 1);

					int count = 1;

					//now find any dupes!
					for (int i=selectedItemsGroups.Count-1; i >= 0; i--)
					{
						if(selectedItemsGroups[i] == group)
						{
							count++;
							selectedItemsGroups.RemoveAt(i);
						}
					}

					if(count == SelectedItems.Count())
					{
						//everyone selected is in this group!
						groupsToAdd.Remove(group);

					}else{
						//only some people were in this group
						//leave it in
					}

					groupsToRemove.Add(group);

				}   

				foreach (WorkerGroup group in groupsToAdd)
				{

					ToolStripItem item = new ToolStripMenuItem() { Text = group.GroupName, Tag = group };
					item.Click += itemAdd_Click;

					addToGroupToolStripMenuItem.DropDownItems.Add(item);
				}


				foreach (WorkerGroup group in groupsToRemove)
				{
					ToolStripItem item = new ToolStripMenuItem() { Text = group.GroupName, Tag = group };
					item.Click += itemRemove_Click;

					removeFromGroupToolStripMenuItem.DropDownItems.Add(item);
				}

				//only show the remove menu if there are groups to remove!
				removeFromGroupToolStripMenuItem.Visible = removeFromGroupToolStripMenuItem.DropDownItems.Count != 0;

			}
			
		}

		private void itemAdd_Click(object sender, EventArgs args)
		{
			ToolStripDropDownItem item = sender as ToolStripDropDownItem;
			WorkerGroup group = item.Tag as WorkerGroup;

			foreach (Worker worker in SelectedItems)
			{
				if (worker.Groups.Contains(group))
					return;

			   worker.Groups.Add(group);
			}

			foreach (Worker worker in SelectedItems)
			{
				worker.MarkForSave = true;
				worker.Save();
			}
		 
		}

		private void itemRemove_Click(object sender, EventArgs args)
		{
			ToolStripDropDownItem item = sender as ToolStripDropDownItem;
			WorkerGroup group = item.Tag as WorkerGroup;

			foreach (Worker worker in SelectedItems)
			{
				if (!worker.Groups.Contains(group))
					return;

				worker.Groups.Remove(group);
			}

			foreach (Worker worker in SelectedItems)
			{
				worker.MarkForSave = true;
				worker.Save();
			}

			//check whether everyone has been removed from this group, if so get rid of it
			if (group.Workers.Count() == 0)
			{
				WorkerGroupManager.Instance.WorkerGroups.Remove(group);
			}

		}

		private void editToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (SelectedItem == null || !_allowOpenWorker)
				return;

			try
			{

				Cursor = Cursors.WaitCursor;

				Worker worker = SelectedItem;

				WorkerFrm frm = new WorkerFrm()
				{
					 ID = worker.id,
					Firstname = worker.firstname,
					Surname = worker.surname,
					ContactNoPrimary = worker.contactno_primary,
					ContactNoSecondary = worker.contactno_secondary,
					Add1 = worker.add1,
					Add2 = worker.add2,
					IsDriver = worker.isDriver,
					Title = "Edit Care Worker",
					ENumber = worker.ENumber,

					Notes = worker.notes
				};

				frm.CallHistory = worker.CallHistory;

				frm.SetWorkingHours(worker.WorkingHours);
				frm.SetDaysOff(worker.WorkingHours.daysOff);

				frm.SetLongLat(worker.LongLatCoords);

				frm.ServiceUsers = ServiceUserManager.Instance.ServiceUsers;
				frm.KeyServiceUsers.AddRange(worker.KeyServiceUsers);

				frm.Workers = WorkerManager.Instance.Workers.Where(w => w != worker).ToList();

				Cursor = Cursors.Default;

				if (frm.ShowDialog() == DialogResult.OK)
				{
					//add this user to the database
					worker.firstname = frm.Firstname;
					worker.surname = frm.Surname;
					worker.postcode = frm.LongLat.pCode;
					worker.add1 = frm.Add1;
					worker.add2 = frm.Add2;
					worker.contactno_primary = frm.ContactNoPrimary;
					worker.contactno_secondary = frm.ContactNoSecondary;
					worker.isDriver = frm.IsDriver;
					worker.LongLatCoords = frm.LongLat;

					worker.WorkingHours.Clear();
					worker.WorkingHours.AddRange(frm.Availabilities);

					worker.WorkingHours.daysOff.Clear();
					worker.WorkingHours.daysOff.AddRange(frm.Availabilities.daysOff);

					worker.notes = frm.Notes;

					////clear this service user from all its key workers
					foreach (ServiceUser serviceuser in worker.KeyServiceUsers)
					{
						serviceuser.KeyWorkers.Remove(worker);
					}

					////clear the service users key workers
					worker.KeyServiceUsers.Clear();

					//// add the new keyworkers
					worker.KeyServiceUsers.AddRange(frm.KeyServiceUsers);

					////add service user to key workers
					foreach (ServiceUser serviceuser in frm.KeyServiceUsers)
					{
						serviceuser.KeyWorkers.Add(worker);

						serviceuser.OldKeyWorkers.Clear();
						serviceuser.OldKeyWorkers.AddRange(serviceuser.KeyWorkers);
					}

					//attempt to save
					Cursor = Cursors.WaitCursor;
					try
					{ 
						worker.MarkForSave = true;
						worker.Save();

						
					}
					catch (Exception ex)
					{
						Cura.Common.Common.LogError("Error Occured While Trying To Save This Worker", ex);
					}

					WorkerManager.Instance.RefreshControls(false, false, false);

				}

				frm.Dispose();

			}
			catch (Exception ex)
			{
				Cura.Common.Common.LogError("Error Editing Worker", ex);
			}

			Cursor = Cursors.Default;
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
		//	Worker worker = SelectedItem;

			try
			{

				foreach (Worker worker in SelectedItems)
				{
					if (worker.Calls.Count > 0 && MessageBox.Show("Are you sure you want to delete " + worker.Name + "?\r\nAll calls they cover will become unassigned.", "Delete Worker", MessageBoxButtons.YesNo) == DialogResult.No)
					{
						return;
					}

					Cursor = Cursors.WaitCursor;

					List<Call> callstoremove = worker.Calls.ToList();

					WorkerManager.Instance.IgnoreControlRefresh = true;
					ServiceUserManager.Instance.IgnoreControlRefresh = true;

					foreach (Call call in callstoremove)
					{
						call.Workers.Remove(worker);
						worker.Calls.Remove(call);

						call.Save();
					}

					WorkerManager.Instance.IgnoreControlRefresh = false;
					ServiceUserManager.Instance.IgnoreControlRefresh = false;

					worker.Delete();
					worker.Save();

					objectListView1.RemoveObject(worker);

					Cursor = Cursors.Default;
				}
			}
			catch (Exception ex)
			{
				Cura.Common.Common.LogError("Error Deleting Worker", ex);
			}
			Cursor = Cursors.Default;
		}

		private void disableToolStripMenuItem_Click(object sender, EventArgs e)
		{
		//	Worker worker = SelectedItem;
			try{
				
				foreach (Worker worker in SelectedItems)
				{
					if (MessageBox.Show("Are you sure you want to deactivate " + worker.Name + "?\r\nAll future calls they cover will become unassigned.", "Delete Worker", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{

						Cursor = Cursors.WaitCursor;

						IEnumerable<Call> callstoremove = worker.Calls.Where(c => c.time >= DateTime.Now);


						WorkerManager.Instance.IgnoreControlRefresh = true;
						ServiceUserManager.Instance.IgnoreControlRefresh = true;

						foreach (Call call in callstoremove)
						{
							call.Workers.Remove(worker);
							worker.Calls.Remove(call);

							call.Save();
						}


						WorkerManager.Instance.IgnoreControlRefresh = false;
						ServiceUserManager.Instance.IgnoreControlRefresh = false;


						worker.idStatus = Worker.Status.Inactive;

						worker.MarkForSave = true;
						worker.Save();


						objectListView1.BuildList();

						Cursor = Cursors.Default;
					}
				}

		   }
			catch (Exception ex)
			{
				Cura.Common.Common.LogError("Error Deactivating Worker", ex);
			}
			Cursor = Cursors.Default;
		}

		private void enableToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				foreach (Worker worker in SelectedItems)
				{
					//Worker worker = SelectedItem;

					Cursor = Cursors.WaitCursor;


					worker.idStatus = Worker.Status.Active;
					worker.MarkForSave = true;
					worker.Save();

					objectListView1.BuildList();

					Cursor = Cursors.Default;
				}
			}
			catch (Exception ex)
			{
				Cura.Common.Common.LogError("Error Activating Worker", ex);
			}
			Cursor = Cursors.Default;
		}

		private void duplicateUserToolStripMenuItem_Click(object sender, EventArgs e)
		{

			if (SelectedItem == null)
				return;

			DialogResult res = MessageBox.Show("Would you like to duplicate key serviceusers?", "Key Service Users", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

			if(res== DialogResult.Cancel)
				return;

			try
			{
				Cursor = Cursors.WaitCursor;

				Worker worker = SelectedItem.Duplicate(res == DialogResult.Yes);

				worker.surname += " - Copy";

				worker.Save();

				//TODO - this
				objectListView1.AddObject(worker);
				objectListView1.BuildList();

				Cursor = Cursors.Default;
			}
			catch (Exception ex)
			{
				Cura.Common.Common.LogError("Error Duplicating Worker", ex);
			}
			Cursor = Cursors.Default;
		}


		#endregion

		#region RotaPdf

		private void printRotaToolStripMenuItem_Click(object sender, EventArgs e)
		{

			if (SelectedItems.Count() == 0)
				return;

			RotaPrintMenuFrm frm = new RotaPrintMenuFrm();

			if (frm.ShowDialog() != DialogResult.OK)
				return;

			int[] Weeks;

			//get an int array of week numbers
			if (frm.SelectedPrintSelection == RotaPrintMenuFrm.PrintSelection.AllWeeks)
			{
				Weeks = Enumerable.Range(1, Settings.Instance.rotaweekcount).ToArray();// new int[] { 1, 2, 3, 4, 5, 6 };
			}
			else
			{
				Weeks = frm.SelectedWeeks;
			}

			//get how many pages there will be (amount of weeks * amount of workers)
			int totalPages = SelectedItems.Count() * Weeks.Length;

			//if there are gunna be over a hundred give a warning!
			if (totalPages > 100)
			{
				if (MessageBox.Show("You are about to generate rather a large amount of rota pages (" + totalPages.ToString() + ").\r\nThis may take a little time. Press Yes to continue", "Rota Generation", MessageBoxButtons.YesNo) == DialogResult.No)
					return;
			}
			
			//sort the weeks lowest to highest
			Array.Sort<int>(Weeks,
					new Comparison<int>(
							(i1, i2) => i1.CompareTo(i2)
					));


			//create the document
			Document document = new Document(PageSize.A4.Rotate());


			PdfWriter writer;
			string filename = (SelectedItems.Count() > 1 ? "multiworker" : SelectedItems.ElementAt(0).Name) + "-" + _periodstartdate.ToString("yyyyMMdd") + ".pdf";

			try
			{

				writer = PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));
				document.Open();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Failed to Open Rota Pdf Document.\r\n\r\n" + ex.Message);
				return;
			}

			//create some font stuff
			BaseFont bfTimes = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, false);
			iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
			iTextSharp.text.Font times_bold = new iTextSharp.text.Font(bfTimes, 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
			iTextSharp.text.Font times_bold_underline = new iTextSharp.text.Font(bfTimes, 8, iTextSharp.text.Font.BOLD | iTextSharp.text.Font.UNDERLINE, iTextSharp.text.BaseColor.BLACK);

			//iterate over each worker
			foreach (Worker worker in SelectedItems)
			{

				//iterate over each week
				foreach (int week in Weeks)
				{

					DateTime currentWeek = _periodstartdate.AddDays(7 * (week - 1));

					document.Add(new Paragraph(worker.Name, times_bold));
					document.Add(new Paragraph("\r\n\r\n"));

					PdfPTable table = new PdfPTable(8);

					table.WidthPercentage = 100;
					PdfPCell cell = new PdfPCell(new Phrase("Week " + week.ToString() + "\r\n(" + currentWeek.ToString("dd/MM/yyyy") + ")\r\n", times));
					cell.Padding = 5;
					cell.Colspan = 8;
					cell.HorizontalAlignment = 1; //0=left, 1=centre, 2=right
					table.AddCell(cell);

					table.AddCell("");


					Dictionary<string, string[]> serviceUserText = new Dictionary<string, string[]>();

					DateTime startOfWeek = currentWeek;

					for (int day = 0; day < 7; day++)
					{
						string daytxt = ((System.DayOfWeek)((day + 1) % 7)).ToString();

						if (worker.isDayOff(startOfWeek.AddDays(day)))
						{
							daytxt += " (Day Off)";
						}
						table.AddCell(new Phrase(daytxt, times_bold));
					}


					//iterate over each day of this week
					for (int day = 0; day < 7; day++)
					{
						//get the current day
						DateTime currentDay = startOfWeek.AddDays(day);

						//now get all the calls that are on this day for this worker!
						foreach (Call call in worker.Calls.Where(c => c.time >= currentDay && c.time < currentDay.AddDays(1)))
						{
							string[] dayText;
							string serviceusertxt = call.ServiceUser.Name + "\r\n" + call.ServiceUser.add1 + "\r\n" + call.ServiceUser.postcode;

							//creeate a day text for a specific service user
							if (!serviceUserText.TryGetValue(serviceusertxt, out dayText))
							{
								dayText = new string [] { "", "", "", "", "", "", "" };
								serviceUserText.Add(serviceusertxt, dayText);
							}

							string doubleuptext = "";

							if (call.required_workers == 2)
							{
								doubleuptext = "[D: ";

								if (call.Workers.Count() == 1)
								{
									doubleuptext += "Unassigned";
								}
								else
								{
									Worker otherWorker = call.Workers.Single(w => w != worker);

									doubleuptext += otherWorker.ShortName;
								}

								doubleuptext += "]";
							}

							string calltxt = call.time.ToString("HH:mm") + " (" + call.duration_mins.ToString() + " min)\r\n" + doubleuptext;

							dayText[day] += calltxt;

						}

					}

			   
					if (serviceUserText.Count == 0)
					{
						Phrase phr = new Phrase("No Calls", times);

						phr.Font.SetStyle(1); //bold it for dramatic effect ;)

						PdfPCell nocallscell = new PdfPCell(phr);
						nocallscell.Padding = 5;
						nocallscell.Colspan = 8;
						nocallscell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
						table.AddCell(nocallscell);
					}
					else
					{
						foreach (KeyValuePair<string, string[]> entry in serviceUserText)
						{
							string serviceusername = entry.Key;
							string[] dayText = entry.Value;

							table.AddCell(new Phrase(serviceusername, times));

							foreach (string text in dayText)
							{
								table.AddCell(new Phrase(text.Trim(), times));
							}
						}
					}

					document.Add(table);

					if (week != Weeks[Weeks.Length - 1])
						document.NewPage();
				}
				document.NewPage();
			}

			document.Close();
			document.Dispose();

			System.Diagnostics.Process.Start(@filename);
		}

		#endregion

		#region Events
		public event  EventHandler WorkerSelectionChanged;

		private void newGroupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{


				NewGroupFrm frm = new NewGroupFrm();

				if (frm.ShowDialog() == DialogResult.OK)
				{
					foreach (Worker worker in SelectedItems)
					{
						//create a new one and add this worker to it!
						WorkerGroup group = new WorkerGroup() { GroupName = frm.GroupName };

						WorkerGroupManager.Instance.WorkerGroups.Add(group);
						worker.Groups.Add(group);

						worker.MarkForSave = true;
						worker.Save();
					}
				}
			}
			catch (Exception ex)
			{
				Cura.Common.Common.LogError("Failed To Create New Group", ex);
			}

		}       

		private void searchTypeBtn_Click_1(object sender, EventArgs e)
		{
			this.isNameFilter = !this.isNameFilter;
			UpdateFilter();
		}

		private void filter1_TextChanged(object sender, EventArgs e)
		{
			SearchText = filter1.Text;
		}

		private void hideInactiveChk_CheckedChanged(object sender, EventArgs e)
		{
			UpdateFilter();
		}
  
	 
		/// <summary>
		/// create a new worker!
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void newworkerbtn_Click_1(object sender, EventArgs e)
		{
			if (Settings.IsTrial && WorkerManager.Instance.Workers.Count >= 5)
			{
				MessageBox.Show("You can only create a maximum of 5 workers while using a trial version of this product.", "Trial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			try
			{
				WorkerFrm frm = new WorkerFrm()
				{
					Title = "Create Care Worker"
				};

				frm.Workers = WorkerManager.Instance.Workers;
				frm.ServiceUsers = ServiceUserManager.Instance.ServiceUsers;

				if (frm.ShowDialog() == DialogResult.OK)
				{
					//add this user to the database
					Worker new_worker = new Worker()
					{
						firstname = frm.Firstname,
						surname = frm.Surname,
						add1 = frm.Add1,
						add2 = frm.Add2,
						contactno_primary = frm.ContactNoPrimary,
						contactno_secondary = frm.ContactNoSecondary,
						isDriver = frm.IsDriver,
						ENumber = frm.ENumber,
						notes = frm.Notes
					};



					new_worker.LongLatCoords = frm.LongLat;
					new_worker.postcode = frm.LongLat.pCode;

					new_worker.WorkingHours.Clear();
					new_worker.WorkingHours.AddRange(frm.Availabilities);

					new_worker.WorkingHours.daysOff.Clear();
					new_worker.WorkingHours.daysOff.AddRange(frm.Availabilities.daysOff);

					////clear the service users key workers
					new_worker.KeyServiceUsers.Clear();

					//// add the new keyworkers
					new_worker.KeyServiceUsers.AddRange(frm.KeyServiceUsers);

					////add service user to key workers
					foreach (ServiceUser serviceuser in frm.KeyServiceUsers)
					{
						serviceuser.KeyWorkers.Add(new_worker);

						serviceuser.OldKeyWorkers.Clear();
						serviceuser.OldKeyWorkers.AddRange(serviceuser.KeyWorkers);
					}


					//attempt to save
					Cursor = Cursors.WaitCursor;
					try
					{
						//save the worker
						new_worker.Save();

						//add to the worker manager if it saved successfully
						WorkerManager.Instance.Workers.Add(new_worker);

					}
					catch (Exception ex)
					{
						Cura.Common.Common.LogError("Error Occured While Trying To Save This New Worker", ex);
					}
					Cursor = Cursors.Default;

				}

				frm.Dispose();
			}
			catch (Exception ex)
			{
				Cura.Common.Common.LogError("Error Creating New Worker", ex);
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
		/// Refresh the list display
		/// </summary>
		public override void Refresh()
		{
			base.Refresh();

			objectListView1.BuildList(true);
		}

		/// <summary>
		/// Update the filter
		/// </summary>
		private void UpdateFilter()
		{
			if (DesignMode)
				return;

			try
			{
				if (!isChangingFilter)
				{
					if (isSolo)
					{
						Filter = new WorkerListSearchBarFilter() { filterTxt = _SearchText, hideInactive = hideInactiveChk.Checked, isNameFilter = this.isNameFilter };
					}
					else
					{
						WorkerManager.Instance.WorkerListFilter = new WorkerListSearchBarFilter() { filterTxt = _SearchText, hideInactive = hideInactiveChk.Checked, isNameFilter = this.isNameFilter };
					}
				}
			}
			catch (Exception ex)
			{
				Cura.Common.Common.LogError("Failed To Update Filter", ex);
			}
		}

	}

	public class WorkerListSearchBarFilter : IModelFilter {
		 public string filterTxt;
		 public bool hideInactive;
		 public bool isNameFilter;

		 public WorkerListSearchBarFilter()
		{
			this.filterTxt = "";
			this.hideInactive = false;
			this.isNameFilter = true;
		}

		public bool Filter(object modelObject) {

			Worker worker = modelObject as Worker;
			WorkerGroupViewModel wgvModel = modelObject as WorkerGroupViewModel;

			if (wgvModel != null)  //do worker group view model comparison
			{
				worker = wgvModel.worker;
			}

			string txt = null;

			if (worker != null) //do worker comparision
			{
				if (worker.idStatus == Worker.Status.Inactive && hideInactive)
					return false;

				txt = (isNameFilter ? worker.Name : worker.ENumber).Trim().ToLower();
			}
		   
			return (txt != null) && (filterTxt == null || filterTxt == "" || txt.Contains(filterTxt.Trim().ToLower()));

		} 
	}

}


   