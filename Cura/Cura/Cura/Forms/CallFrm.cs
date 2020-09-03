using ComboxExtended;
using Cura.Forms;
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
    public partial class CallFrm : BaseFrm
    {
        #region Fields
        private int _id;
        public ServiceUser ServiceUser;
        #endregion

        #region Constructor

        public CallFrm()
        {
            InitializeComponent();

            PopulateFlagCombo();

        }
        #endregion

        #region Properties
        public int TravelTime
        {
            get
            {
                return Convert.ToInt32(traveltimenum.Value);
            }
            set
            {
                traveltimenum.Value = value;
            }

        }
        public int ID
        {
            set
            {
                _id = value;
            }
        }

        public string Notes
        {
            get
            {
                return noteTxt.Text;
            }
            set
            {
                noteTxt.Text = value;
            }
        }

        public Call.FlagCode Flag
        {
            get
            {
                return (Call.FlagCode)imagedComboBox1.SelectedIndex;
            }
            set
            {
                imagedComboBox1.SelectedIndex = (int)value;
            }
        }

        public DateTime Date
        {
            set
            {
                dateTimePicker2.Value = value;
            }
        }

        public DateTime Time
        {
            get
            {
                return dateTimePicker1.Value;
            }
            set
            {
                dateTimePicker1.Value = value;
            }
        }

        public int Duration
        {
            get
            {
                return Convert.ToInt32(numericUpDown1.Value);
            }
            set
            {
                numericUpDown1.Value = value;
            }
        }


        public int WorkerCount
        {
            get
            {
                return radioButton1.Checked ? 1 : 2;
            }
            set
            {
                switch (value)
                {
                    case 2:
                        radioButton2.Checked = true;
                        break;
                    default:
                        radioButton1.Checked = true;
                        break;
                }
            }
        }

 

        #endregion

        #region Form Load
        private void NewSlotFrm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Events
        private void CallFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
  

        private void CallFrm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (Duration == 0)
                {
                    if (MessageBox.Show("You Have Specified a 0 Minute Call, Is This Correct?", "Duration", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                }

                //get every call from same service user and on the same date
                IEnumerable<Call> conflictCalls = CallManager.Instance.Calls.Where(c => c.ServiceUser == ServiceUser && c.time.Date == Time.Date );

                //now check for time overlap
                int conflictcount = conflictCalls.Where(c => c.ID != _id && Time.AddMinutes(Duration) > c.time && Time < c.time.AddMinutes(c.duration_mins)).Count();
                if (conflictcount > 0)
                {

                    string conflictString = "This call will overlap with " + conflictcount ;

                    conflictString += (conflictcount > 1 ? "other calls" : "another call");

                    //check whther any are marked for deletion.
                    if (conflictCalls.Where(c => c.MarkedForDeletion).Count() > 0)
                    {
                        conflictString += (conflictcount > 1 ? ", some of which are pending for deletion" : " which is pending for deletion");
                    }

                    if (MessageBox.Show(conflictString + ". Is this ok?", "Overlap", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Populate the flag combo box
        /// </summary>
        private void PopulateFlagCombo()
        {
            imagedComboBox1.Items.Add(new ComboBoxItem("No Flag"));

            imagedComboBox1.Items.Add(new ComboBoxItem("Red Flag", Properties.Resources.flag_red));
            imagedComboBox1.Items.Add(new ComboBoxItem("Blue Flag", Properties.Resources.flag_blue));
            imagedComboBox1.Items.Add(new ComboBoxItem("Green Flag", Properties.Resources.flag_green));
            imagedComboBox1.Items.Add(new ComboBoxItem("Orange Flag", Properties.Resources.flag_orange));
            imagedComboBox1.Items.Add(new ComboBoxItem("Pink Flag", Properties.Resources.flag_pink));
            imagedComboBox1.Items.Add(new ComboBoxItem("Purple Flag", Properties.Resources.flag_purple));
            imagedComboBox1.Items.Add(new ComboBoxItem("Yellow Flag", Properties.Resources.flag_yellow));

            imagedComboBox1.SelectedIndex = 0;
        }
  
    }
}
