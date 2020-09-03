using BrightIdeasSoftware;
using Cura.Controls.Common;
using Cura.Forms;
using Cura.Forms.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cura.Controls
{
	public partial class WorkerFrm : BaseFrm
	{

		#region Fields
		AvailabilityCollection _availabilities;

		private LongLat _longLat;
		private int _id;

		ServiceUserCollection _keyServiceUsers;
		#endregion

		#region Constructor
		/// <summary>
		///   Constructor
		/// </summary>
		public WorkerFrm()
		{
			InitializeComponent();

			try
			{
				this._keyServiceUsers = new ServiceUserCollection();
				this._keyServiceUsers.ObjectAdded += new Cura.Common.Collection<ServiceUser>.CollectionChangeEvent(this.KeyServiceUsersChanged);
				this._keyServiceUsers.ObjectRemoved += new Cura.Common.Collection<ServiceUser>.CollectionChangeEvent(this.KeyServiceUsersChanged);

				this._availabilities = new AvailabilityCollection();

				this._availabilities.ObjectAdded += new Cura.Common.Collection<Availability>.CollectionChangeEvent(this.AvailabilitiesChanged);
				this._availabilities.ObjectRemoved += new Cura.Common.Collection<Availability>.CollectionChangeEvent(this.AvailabilitiesChanged);

                this._longLat = new LongLat();

				this.tabControl1.SelectedIndex = 0;

				int weeks = Settings.Instance.rotaweekcount;

				for (int i = 0; i < weeks; i++)
				{
					treeView1.Nodes.Add("Week " + (i + 1).ToString());
				}

				treeView1.MouseDown += (sender, args) => treeView1.SelectedNode = treeView1.GetNodeAt(args.X, args.Y);

				//show core hours first
				splitContainer5.Panel1Collapsed = false;
				splitContainer5.Panel2Collapsed = true;


                ((OLVColumn)callHistoryObjectListView.Columns[0]).GroupKeyGetter = delegate(object rowObject)
                {
                    Call_Slim model = rowObject as Call_Slim;

                    return model.Day;
                };

                numberLbl.Text = String.Format("{0} Number", Settings.Instance.WorkerNumberAlias).Trim();
                splitContainer8.SplitterDistance = pictureBox12.Width + numberLbl.Width + 5;
			

			}
			catch (Exception ex)
			{
				Cura.Common.Common.LogError("Failed To Initialise Worker Form", ex);
			}
	

		}
		#endregion

		#region Form Load

		private void WorkerFrm_Load(object sender, EventArgs e)
		{
			try
			{

				if (!_longLat.IsEmpty)
				{
					GoogleMapLocation location;

					if (!_longLat.HasLongLat)
					{
						//if there aint any long lat info, then try and get some
						location = new GoogleMapLocation(new GoogleMapAddress(_longLat.pCode, "UK"));
					}
					else if (_longLat.pCode == null && _longLat.HasLongLat)
					{
						//if there aint post code information then use this to get it
						location = new GoogleMapLocation(_longLat);

					}
					else
					{
						//if there is both then whoopdie do basil!
						location = new GoogleMapLocation(new GoogleMapAddress(_longLat.pCode, "UK"), _longLat);
					}

					//get the current long lat
					_longLat = location.LongLat;

					//set the postcode to match
					PostCode = _longLat.pCode;

					//try to add the marker location
					webBrowser1.AddLocationMarker(location);
				}

			}
			catch (Exception ex)
			{
				//ignore
			}

			if (_id != 0)
			{

				eNumberTxt.ReadOnly = true;
				eNumberTxt.BackColor = ColorTranslator.FromHtml("#FFEDE5");

			}


		}
		#endregion
  
		#region Properties

		public string Notes
		{
			get
			{
				return notestxt.Text.Trim();
			}
			set
			{
				notestxt.Text = value;
			}
		}

		private bool ENumberAvailable
		{
			get
			{
				Worker user = WorkerManager.Instance.Workers.SingleOrDefault(w => w.ENumber == eNumberTxt.Text.Trim());

				return (user == null);
			}
		}

		public ServiceUserCollection KeyServiceUsers
		{
			get
			{
				return _keyServiceUsers;
			}
		}

		public string ENumber
		{
			get
			{
				return eNumberTxt.Text.Trim();
			}
			set
			{
				eNumberTxt.Text = value;
			}
		}

		public int ID
		{
			set
			{
				_id = value;
			}
		}
		public string Firstname
		{
			get
			{
				return firstnametxt.Text.Trim();
			}
			set
			{
				firstnametxt.Text = value;
			}
		}

		public string Surname
		{
			get
			{
                return surnametxt.Text.Trim();
			}
			set
			{
				surnametxt.Text = value;
			}
		}

		public string ContactNoPrimary
		{
			get
			{
                return contactprimtxt.Text.Trim();
			}
			set
			{
				contactprimtxt.Text = value;
			}
		}

		public string ContactNoSecondary
		{
			get
			{
                return contactsectxt.Text.Trim();
			}
			set
			{
				contactsectxt.Text = value;
			}
		}

		public string Add1
		{
			get
			{
                return add1Txt.Text.Trim();
			}
			set
			{
				add1Txt.Text = value;
			}
		}

		public string Add2
		{
			get
			{
                return add2Txt.Text.Trim();
			}
			set
			{
				add2Txt.Text = value;
			}
		}

        public void SetLongLat(LongLat ll)
        {
            LongLat.Longatude = ll.Longatude;
            LongLat.Latatude = ll.Latatude;
            LongLat.pCode = ll.pCode;

            PostCode = ll.pCode;
        }

		private string PostCode
		{
            get
            {
                return (areafirsttxt.Text + " " + areasecondtxt.Text).Trim();
            }
			set
			{
				if (value == null || value.Trim().Length == 0 || value.Split(' ').Length != 2)
				{
					areafirsttxt.Text = "";
					areasecondtxt.Text = "";
					return;
				}

				areafirsttxt.Text = value.Split(' ')[0];
				areasecondtxt.Text = value.Split(' ')[1];
			}
		}

		public LongLat LongLat
		{
			get
			{
				return _longLat;
			}         
		}

		public bool IsDriver
		{
			get
			{
				return isdriverChk.Checked;
			}
			set
			{
				isdriverChk.Checked = value;
			}
		}

		public AvailabilityCollection Availabilities
		{
			get
			{
				_availabilities.daysOff.Clear();

				for (int i = 0; i < treeView1.Nodes.Count; i++)
				{
					foreach(TreeNode node in treeView1.Nodes[i].Nodes)
					{
						 System.DayOfWeek dayselected = (System.DayOfWeek)Enum.Parse(typeof(System.DayOfWeek), node.Text);
						 _availabilities.daysOff.Add(new AvailabilityCollection.DayOff() { week = i, day = dayselected });
					}
				}

			   return _availabilities;
			}
		}

		public void SetDaysOff(IEnumerable<AvailabilityCollection.DayOff> daysOff)
		{
			_availabilities.daysOff.Clear();
			_availabilities.daysOff.AddRange(daysOff);

			RefreshAvailabilityList();
		}
		
		public void SetWorkingHours(IEnumerable<Availability> workinghours)
		{
			_availabilities.Clear();
			_availabilities.AddRange(workinghours);

			RefreshAvailabilityList();
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public List<Worker> Workers
		{
			set
			{
				workerListCtrl1.Workers = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public List<ServiceUser> ServiceUsers
		{
			set
			{
				serviceUserListCtrl1.ServiceUsers = value;
			}
		}

		public IEnumerable<Call_Slim> CallHistory
		{
			set
			{
				callHistoryObjectListView.Objects = value;
                callCountLbl.Text = value.Count().ToString() + " Calls";
			}
		}
		#endregion

		#region Events

		private void listView2_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.KeyCode == Keys.Delete)
			{
				foreach (ListViewItem item in listView2.SelectedItems)
					KeyServiceUsers.Remove((ServiceUser)item.Tag);
			}

		}
		private void KeyServiceUsersChanged(object sender, Cura.Common.CollectionChangeEventArgs args)
		{
			RefreshKeyServiceUser();
		}

		private void eNumberTxt_TextChanged(object sender, EventArgs e)
		{
			//check database for matching 
			if (_id == 0)
			{
				bool errExists = !ENumberAvailable;

				pnumbererrorpic.Visible = errExists;

				pnumbererrodlbl.Text = "( Already Exists )";
				pnumbererrodlbl.Visible = errExists;
			}
		}

		private void WorkerFrm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				DialogResult = System.Windows.Forms.DialogResult.Cancel;
				Close();
			}
		}

		private void WorkerFrm_FormClosing(object sender, FormClosingEventArgs e)
		{

			if (DialogResult != System.Windows.Forms.DialogResult.OK)
				return;

			if (firstnametxt.Text.Trim().Length == 0)
			{
				firstnameerrorpic.Visible = true;
				e.Cancel = true;
			}

			if (surnametxt.Text.Trim().Length == 0)
			{
				surnameerrorpic.Visible = true;
				e.Cancel = true;
			}

			if (_id == 0 && !ENumberAvailable)
			{
				pnumbererrorpic.Visible = true;

				pnumbererrodlbl.Text = "( Already Exists )";
				pnumbererrodlbl.Visible = true;

				e.Cancel = true;
			}
			else if (eNumberTxt.Text.Trim().Length == 0)
			{

				pnumbererrorpic.Visible = true;

				pnumbererrodlbl.Text = "( Invalid PNumber )";
				pnumbererrodlbl.Visible = true;

				e.Cancel = true;
			}



			//all good, update the location stuff

			try
			{

                if (PostCode == "")
                {
                    _longLat.Empty() ;
                }
                else if (PostCode  != _longLat.pCode)
				{
					//if the postcode has changed
                    _longLat.Empty();

                    _longLat.pCode = PostCode;

                    
                    //get the google long lat locations (this will insert into pcodes.db)
                    GoogleMapLocation location;
                    location = new GoogleMapLocation(new GoogleMapAddress(PostCode, "UK"));

                    _longLat = location.LongLat;
                   
				}

			}
			catch (Exception ex)
			{
				//ignore
			}
		}

		private void showmapbtn_Click(object sender, EventArgs e)
		{
			map_splitcontainer.Panel1Collapsed = !map_splitcontainer.Panel1Collapsed;

			showmapbtn.Text = map_splitcontainer.Panel1Collapsed ? "Show Map" : "Hide Map";
		}

		
		private void firstnametxt_TextChanged(object sender, EventArgs e)
		{
			firstnameerrorpic.Visible = false;
		}

		private void surnametxt_TextChanged(object sender, EventArgs e)
		{
			surnameerrorpic.Visible = false;
		}

		private void manualAvailRadio_CheckedChanged(object sender, EventArgs e)
		{
			corehour_manualdupeSplit.Panel1Collapsed = !manualAvailRadio.Checked;
			corehour_manualdupeSplit.Panel2Collapsed = !duplicateAvailRadio.Checked;
		}

		private void duplicateAvailRadio_CheckedChanged(object sender, EventArgs e)
		{
			corehour_manualdupeSplit.Panel1Collapsed = !manualAvailRadio.Checked;
			corehour_manualdupeSplit.Panel2Collapsed = !duplicateAvailRadio.Checked;
		}

		private void AvailabilitiesChanged(object sender, Cura.Common.CollectionChangeEventArgs args)
		{
			RefreshAvailabilityList();
		}


		private void button1_Click(object sender, EventArgs e)
		{
		   //' Worker.
			List<Availability> availabilities = new List<Availability>();

			if (manualAvailRadio.Checked)
			{
				foreach (Object itemChecked in checkedListBox1.CheckedItems)
				{

					int index = checkedListBox1.Items.IndexOf(itemChecked);

					Availability availability = new Availability()
					{
						timeFrom = new TimeSpan(fromTime.Value.Hour, fromTime.Value.Minute, 0),
						timeTo = new TimeSpan(toTime.Value.Hour, toTime.Value.Minute, 0),
						day = (System.DayOfWeek) ((index + 1) % 7)
					};

					//add to the checklist
					availabilities.Add(availability);

				}
			}
			//else if (duplicateAvailRadio.Checked )
			//{
			//    if (workerListCtrl1.SelectedItem == null)
			//        return;

			//    availabilities.AddRange(workerListCtrl1.SelectedItem.WorkingHours);
			//}

			//do some error checking buddy!
			string errStr = "";
			foreach (Availability availability in availabilities)
			{
				//check its a valid time span
				if (availability.timeFrom > availability.timeTo)
				{
					errStr += "The time is invalid";
					continue;
				}

				bool dupeFound = false;
				//check for dupes!
				foreach ( Availability a in _availabilities)
				{
					//check for time match
					if (a.day == availability.day)
					{
						if ((availability.timeTo >= a.timeFrom) && (availability.timeFrom <= a.timeTo))
						{
							//check for time match
							dupeFound = true;
							break;
						}
					}

				}

				//if there is a dupe then exit
				if (dupeFound)
				{
					errStr += "There is already a time that conflicts with this one!\r\n";
					continue;
				}          

			}

			if (errStr.Trim().Length > 0)
			{
				MessageBox.Show("There were some errors adding these times : \r\n" + errStr, "Errors",  MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				_availabilities.AddRange(availabilities);
			}

			//refresh list
			RefreshAvailabilityList();

		}

		private void listView1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				foreach(ListViewItem item in listView1.SelectedItems)
					_availabilities.Remove((Availability)item.Tag);

			}
		}

		private void addKeyServiceUserBtn_Click(object sender, EventArgs e)
		{
			if (serviceUserListCtrl1.SelectedItem == null)
				return;

			if (KeyServiceUsers.Contains(serviceUserListCtrl1.SelectedItem))
				return;

			KeyServiceUsers.Add(serviceUserListCtrl1.SelectedItem);
		}

		private void corehoursbtn_Click(object sender, EventArgs e)
		{
			dayoff_manualdupeSplit.Panel1.Controls.Remove(workerListCtrl1);
			corehour_manualdupeSplit.Panel2.Controls.Add(workerListCtrl1);
	 
			splitContainer5.Panel1Collapsed = false;
			splitContainer5.Panel2Collapsed = true;

		  
		}

		private void daysoffbtn_Click(object sender, EventArgs e)
		{

			corehour_manualdupeSplit.Panel2.Controls.Remove(workerListCtrl1);
			dayoff_manualdupeSplit.Panel1.Controls.Add(workerListCtrl1);

			splitContainer5.Panel1Collapsed = true;
			splitContainer5.Panel2Collapsed = false;

		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			addDayOffToolStripMenuItem.Visible = true;

			if (treeView1.SelectedNode == null)
			{
				e.Cancel = true;
			}
			else if (!treeView1.SelectedNode.Text.ToLower().StartsWith("week"))
			{
				addDayOffToolStripMenuItem.Visible = false;
			}
		}
		#endregion

		/// <summary>
		/// Refresh the list of availabily for this worker!
		/// </summary>
		private void RefreshAvailabilityList()
		{
			//refresh the list
			listView1.Items.Clear();

			foreach (Availability a in _availabilities)
			{
				listView1.Items.Add(new ListViewItem(a.ToString()) { Tag = a });
			}

			for (int i = 0; i < treeView1.Nodes.Count; i++ )
			{
				TreeNode node = treeView1.Nodes[i]; //week i
				node.Nodes.Clear();

				foreach (AvailabilityCollection.DayOff dayoff in _availabilities.daysOff.Where(d => d.week == i))
				{
					node.Nodes.Add(dayoff.day.ToString());
				}

			}

			treeView1.ExpandAll();
		}

		/// <summary>
		/// Refresh the list of key service users to select from.
		/// </summary>
		private void RefreshKeyServiceUser()
		{
			listView2.Items.Clear();

			foreach (ServiceUser serviceuser in _keyServiceUsers )
			{
				listView2.Items.Add(new ListViewItem(serviceuser.Name) { Tag = serviceuser });
			}
		}

		private void addDayOffStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem item = sender as ToolStripMenuItem;

			int week = Convert.ToInt16(treeView1.SelectedNode.Text.ToLower().Replace("week", ""));
			System.DayOfWeek dayselected = (System.DayOfWeek)Enum.Parse(typeof(System.DayOfWeek), item.Text);

			if (!treeView1.SelectedNode.Nodes.ContainsKey(dayselected.ToString()))
			{
				treeView1.SelectedNode.Nodes.Add(new TreeNode() {Name = dayselected.ToString(), Text =dayselected.ToString()} );
				treeView1.SelectedNode.Expand();
			}
		}

		private void removeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool isWeekNode = treeView1.SelectedNode.Text.ToLower().StartsWith("week");

			if (isWeekNode)
			{
				treeView1.SelectedNode.Nodes.Clear();
			}
			else
			{
				treeView1.SelectedNode.Parent.Nodes.Remove(treeView1.SelectedNode);
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			dayoff_manualdupeSplit.Panel1Collapsed = true;
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			dayoff_manualdupeSplit.Panel1Collapsed = false;

            //show the splitter in the middle!
            dayoff_manualdupeSplit.SplitterDistance = dayoff_manualdupeSplit.Width / 2;
		}

		private void workerListCtrl1_WorkerSelectionChanged(object sender, EventArgs e)
		{
			if (workerListCtrl1.SelectedItem == null)
				return;

			//TODO
			if (!splitContainer5.Panel1Collapsed)
			{
				//core hours
				SetWorkingHours(workerListCtrl1.SelectedItem.WorkingHours)	;		
			}
			else
			{ 
				//days off
				SetDaysOff(workerListCtrl1.SelectedItem.WorkingHours.daysOff);

			}
		}

 
	}
}
