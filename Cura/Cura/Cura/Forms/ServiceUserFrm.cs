using BrightIdeasSoftware;
using Cura.Common;
using Cura.Controls.Common;
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
	public partial class ServiceUserFrm : BaseFrm
	{

		#region Fields
        private WorkerCollection _keyWorkers;
		private LongLat _longLat;
		private int _id;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public ServiceUserFrm()
		{
			InitializeComponent();

            this._keyWorkers = new WorkerCollection();

            this._keyWorkers.ObjectAdded += new Cura.Common.Collection<Worker>.CollectionChangeEvent(this.KeyWorkersChanged);
            this._keyWorkers.ObjectRemoved += new Cura.Common.Collection<Worker>.CollectionChangeEvent(this.KeyWorkersChanged);

            this._longLat = new LongLat();
			this.tabControl1.SelectedIndex = 0;

            ((OLVColumn)callHistoryObjectListView.Columns[0]).GroupKeyGetter = delegate(object rowObject)
            {

                Call_Slim model = rowObject as Call_Slim;
            
                return model.Day;
            };

            numberLbl.Text = String.Format("{0} Number", Settings.Instance.ServiceUserNumberAlias).Trim();
            splitContainer8.SplitterDistance = pictureBox12.Width + numberLbl.Width + 5;

		}
		#endregion

		#region Properties

		private bool PNumberAvailable
		{
			get
			{
				ServiceUser user = ServiceUserManager.Instance.ServiceUsers.SingleOrDefault(s => s.PNumber == pNumberTxt.Text.Trim());

				return (user == null);
			}
		}

		public WorkerCollection KeyWorkers
		{
			get
			{
				return _keyWorkers;
			}
		}

		public int ID
		{
			set
			{
				_id = value;
			}
		}

		public string PNumber
		{
			get
			{
                return pNumberTxt.Text.Trim();
			}
			set
			{
				pNumberTxt.Text = value;
			}
		}

		public string Firstname
		{
			get{
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

		public int Age
		{
			get
			{
                if (DOB == null)
                    return -1;

                DateTime today = DateTime.Today;
                int age = today.Year - DOB.Value.Year;
                if (DOB.Value > today.AddYears(-age)) age--;

                return age;
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


		public DateTime? DOB
		{
			get
			{
				if (unknownDOBChck.Checked)
					return null;

				return dobDate.Value;
			}
			set
			{
                unknownDOBChck.Checked = !value.HasValue;

                if (value.HasValue)
                {
                    dobDate.Value = value.Value;
                    agelbl.Text = "(Age: " + Age.ToString() + ")";
                }
                else
                {
                    agelbl.Text = "(Age: ?)";
                }

				

			}
		}

		public string MedicalInfo
		{
			get
			{
                return medicaltxt.Text.Trim();
			}
			set
			{
				medicaltxt.Text = value;
			}
		}


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

		public bool ImportantNotes
		{
			get
			{
				return importantChk.Checked;
			}
			set
			{
				importantChk.Checked = value;
			}
		}

		

		public DateTime PeriodStartDate
		{
			get
			{
				return new DateTime(servicePickerDateTime.Value.Year, servicePickerDateTime.Value.Month, servicePickerDateTime.Value.Day, 0,0,0);
			}
			set
			{
				servicePickerDateTime.Value = value;
			}
		}

		public int PeriodWeekCount
		{
			get
			{
				return Convert.ToInt32(serviceperiodweeksnum.Value); 
			}
			set
			{
				serviceperiodweeksnum.Value = value;
			}
		}

		public ServiceUser.Gender Gender
		{
			get
			{
				if (maleradio.Checked)
					return ServiceUser.Gender.Male;

				if (femaleradio.Checked)
					return ServiceUser.Gender.Female;

				return ServiceUser.Gender.Unknown;
			}
			set
			{
				maleradio.Checked = (value == ServiceUser.Gender.Male);
				femaleradio.Checked = (value == ServiceUser.Gender.Female);
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IEnumerable<Worker> Workers
		{
			set
			{
			   workerListCtrl1.Workers = value;
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
		private void KeyWorkersChanged(object sender, Cura.Common.CollectionChangeEventArgs args)
		{
			RefreshKeyWorkerList();
		}

		private void showmapbtn_Click(object sender, EventArgs e)
		{
			map_splitcontainer.Panel1Collapsed = !map_splitcontainer.Panel1Collapsed;

			showmapbtn.Text = map_splitcontainer.Panel1Collapsed ? "Show Map" : "Hide Map";
		}

		private void pNumberTxt_TextChanged(object sender, EventArgs e)
		{
			//check database for matching 
			if (_id == 0)
			{
				bool errExists = !PNumberAvailable;

				pnumbererrorpic.Visible = errExists;

				pnumbererrodlbl.Text = "( Already Exists )";
				pnumbererrodlbl.Visible = errExists;
			}

		}

		private void firstnametxt_TextChanged(object sender, EventArgs e)
		{
			firstnameerrorpic.Visible = false;
		}

		private void surnametxt_TextChanged(object sender, EventArgs e)
		{
			surnameerrorpic.Visible = false;
		}

		private void ServiceUserFrm_Load(object sender, EventArgs e)
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
					googleMap1.AddLocationMarker(location);
				}
			}
			catch (Exception ex)
			{

			}

			if (_id != 0)
			{

				pNumberTxt.ReadOnly = true;
				pNumberTxt.BackColor = ColorTranslator.FromHtml("#FFEDE5");

			}
		}

		private void ServiceUserFrm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				DialogResult = System.Windows.Forms.DialogResult.Cancel;
				Close();
			}

		}

		private void unknownDOBChck_CheckedChanged(object sender, EventArgs e)
		{
			dobDate.Enabled = !unknownDOBChck.Checked;
          
            if (!unknownDOBChck.Checked)
            {
                agelbl.Text = "(Age: " + Age.ToString() + ")";
            }
            else
            {
                agelbl.Text = "(Age: ?)";
            }


		}

		private void listView1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				foreach (ListViewItem item in listView1.SelectedItems)
					KeyWorkers.Remove((Worker)item.Tag);
			}
		}

		private void unknownDOBchk_CheckedChanged(object sender, EventArgs e)
		{
			dateTimePicker1.Enabled = !unknownDOBchk.Checked;
		}

		private void ServiceUserFrm_FormClosing(object sender, FormClosingEventArgs e)
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

			 if (_id == 0 && !PNumberAvailable)
			 {
				 pnumbererrorpic.Visible = true;

				 pnumbererrodlbl.Text = "( Already Exists )";
				 pnumbererrodlbl.Visible = true;

				 e.Cancel = true;
			 }else  if (pNumberTxt.Text.Trim().Length == 0)
			 {

				pnumbererrorpic.Visible = true;

				pnumbererrodlbl.Text = "( Invalid PNumber )";
				pnumbererrodlbl.Visible = true;

				e.Cancel = true;
			}

            //change this to use call history stuff instead
             //if (_id != 0)
             //{
             //    DateTime serviceStart = PeriodStartDate;
             //    DateTime serviceEnd = serviceStart.AddDays(PeriodWeekCount * 7);

             //    if (CallManager.Instance.Calls.Where(c => c.ServiceUser.id == _id && !c.HasFullWorkers &&
             //                                         !(c.TimeTo > serviceStart && c.TimeFrom < serviceEnd)).Count() > 0)
             //    {

             //        MessageBox.Show("There are still unassigned calls outside this service period.", "Unassigned Calls", MessageBoxButtons.OK);
             //        e.Cancel = true;
             //    }
             //}


			 //all good, update the location stuff




			 try
			 {

                 if (PostCode == "")
                 {
                     _longLat.Empty();
                 }else if (PostCode != _longLat.pCode)
				 {
					 //if the postcode has changed

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

		private void addKeyWorkerBtn_Click(object sender, EventArgs e)
		{
			if (workerListCtrl1.SelectedItem == null)
				return;

			if (KeyWorkers.Contains(workerListCtrl1.SelectedItem))
				return;

			KeyWorkers.Add(workerListCtrl1.SelectedItem);
		}
		#endregion

		/// <summary>
		/// Refresh the list of key workers to select from.
		/// </summary>
		private void RefreshKeyWorkerList()
		{
			listView1.Items.Clear();

			foreach (Worker worker in _keyWorkers)
			{
				listView1.Items.Add(new ListViewItem(worker.Name) { Tag = worker });
			}
		}

        private void dobDate_ValueChanged(object sender, EventArgs e)
        {
            agelbl.Text = "(Age: " + Age.ToString() + ")";
        }


	}
}
