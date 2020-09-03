using Cura.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using System.Windows.Forms;

namespace Cura.Forms
{
    public partial class SettingsFrm : BaseFrm
    {

        #region Fields
        private int initial_RotaWeekCount;
        #endregion

        #region Constructor
        public SettingsFrm()
        {
            InitializeComponent();
        }
        #endregion
      
        #region Properties
         public bool isValidSettings
         {
             get
             {
                 return (Settings.isValidSecurityKey(securitykeyTxt.Text.Trim()) == Settings.SecurityKeyValidityEnum.VALID && DataFilePath.EndsWith(Settings.datafileextension) && File.Exists(DataFilePath));
             }
         }

        public bool DisplayCallsWithTravelTime
         {
            get
             {
                 return showtraveltime.Checked;
             }
            set
             {
                 showtraveltime.Checked = value;
             }
         }

        public int WeeksInRotaPeriod
        {
            get
            {
                return Convert.ToInt32(rotaWeekCount.Value);
            }
            set
            {
                if (value < rotaWeekCount.Minimum)
                    rotaWeekCount.Value = rotaWeekCount.Minimum;
                else if (value > rotaWeekCount.Maximum)
                    rotaWeekCount.Value = rotaWeekCount.Maximum;
                else
                    rotaWeekCount.Value = value;
            }
        }


        public int RotaRange
        {
            get
            {
                return Convert.ToInt32(rotaRangeNUm.Value);
            }
            set
            {
                if (value < rotaRangeNUm.Minimum)
                     rotaRangeNUm.Value = rotaRangeNUm.Minimum;
                else if (value > rotaRangeNUm.Maximum)
                    rotaRangeNUm.Value = rotaRangeNUm.Maximum;
                else
                    rotaRangeNUm.Value = value;
            }
        }

        public DateTime FirstWeek
        {
            get
            {
                return new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 0, 0, 0);
            }
            set
            {
                dateTimePicker1.Value = (value == DateTime.MinValue? DateTime.Now: value);
            }
        }
        public string SecurityKey
        {
            get
            {
                return securitykeyTxt.Text;
            }
            set
            {
                securitykeyTxt.Text = value;
                RefreshControls();
            }
        }

        public string DataFilePath
        {
            get
            {
                return dataPathTxt.Text;
            }
            set
            {
                dataPathTxt.Text = value;
                RefreshControls();
            }
        }
        #endregion

        #region Events
        private void SettingsFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != System.Windows.Forms.DialogResult.OK)
                return;

            if (!isValidSettings)
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = DataFilePath.Substring(0, DataFilePath.LastIndexOf("\\") + 1);
            openFileDialog1.Filter = "Data File(*" + Settings.datafileextension + ")|*" + Settings.datafileextension + "|All files (*.*)|*.*";
            //openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataFilePath = openFileDialog1.FileName;
            }

            RefreshControls();
        }


        private void securitykeyTxt_TextChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }
       #endregion

        #region Form Load
        private void SettingsFrm_Load(object sender, EventArgs e)
        {
            TopMost = true;
            Focus();
            BringToFront();
            TopMost = false;

            RefreshControls();

            
        }
        #endregion

        /// <summary>
        /// Refresh the controls etc
        /// </summary>
        public void RefreshControls()
        {
            securitykeyerrorpic.BackgroundImage = Settings.isValidSecurityKey(securitykeyTxt.Text.Trim()) == Settings.SecurityKeyValidityEnum.VALID ? Cura.Properties.Resources.enable : Cura.Properties.Resources.exclamation;
            fileerrorpic.BackgroundImage = DataFilePath.EndsWith(Settings.datafileextension) && File.Exists(DataFilePath) ? Cura.Properties.Resources.enable : Cura.Properties.Resources.exclamation;
            exButton1.Enabled = isValidSettings;

            Cura.Settings.SecurityKeyValidityEnum valid = Settings.isValidSecurityKey(securitykeyTxt.Text.Trim());

            switch (valid)
            {
                case Settings.SecurityKeyValidityEnum.EXPIRED:
                    {
                        remaining.ForeColor = Color.Red;
                        remaining.Text = "Security Key Expired";
                        return;
                    }
                case Settings.SecurityKeyValidityEnum.INVALID:
                    {
                        remaining.ForeColor = Color.Red;
                        remaining.Text = "Invalid Security Key";
                        return;
                    }
                case Settings.SecurityKeyValidityEnum.VALID:
                    {
                        remaining.ForeColor = Color.Green;
                        remaining.Text = String.Format("{0} - {1} Day(s) Remaining", Settings.IsTrial ? "Trial" : "Full", Math.Floor(Settings.DaysRemainingForKey(securitykeyTxt.Text)));
                        return;
                    }
                default:
                    {
                        remaining.Text = String.Empty;
                        return;
                    }
            }

           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void remaining_Click(object sender, EventArgs e)
        {

        }


    }
}
