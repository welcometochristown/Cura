using Cura.Forms.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cura.Forms
{
    public partial class BackupRestoreFrm : BaseFrm
    {
        #region Fields
        private static string backupextension = ".crbk";
        #endregion

        #region Constructor
        public BackupRestoreFrm()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Load
        private void BackupRestoreFrm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Events
        private void backupRadio_CheckedChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }


        private void restoreRadio_CheckedChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Cura Backup File(*" + backupextension + ")|*" + backupextension + "|All files (*.*)|*.*";
            //openFileDialog1.FilterIndex = 1;

            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                backupTxt.Text = saveFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Cura Backup File(*" + backupextension + ")|*" + backupextension + "|All files (*.*)|*.*";
            //openFileDialog1.FilterIndex = 1;

            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                restoreTxt.Text = openFileDialog1.FileName;
            }
        }

        private void exButton1_Click(object sender, EventArgs e)
        {
            if (backupRadio.Checked)
            {
                //just do a copy
                try
                {
                    File.Copy(Settings.Instance.datafilepath, backupTxt.Text.Trim());
                    MessageBox.Show("Backup Completed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Cura.Common.Common.LogError("There was a problem creating the backup : " + ex.Message, ex);
                }
            }
            else if (restoreRadio.Checked)
            {
                //little bit more complicated
                try
                {
                    string path = restoreTxt.Text;
                    string[] data = path.Split('\\');
                    string newfilename = data[data.Length - 1];

                    string datadir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "..\\data";

                    string newpath = datadir + "\\" + newfilename;


                    int count = 1;

                    string finalpath = newpath.Replace(backupextension, Settings.datafileextension);

                    while (File.Exists(finalpath))
                    {
                        finalpath = newpath.Replace(Settings.datafileextension, "(" + count.ToString() + ")" + Settings.datafileextension);
                        count++;
                    }

                    if (!Directory.Exists(datadir))
                    {
                        Directory.CreateDirectory(datadir);
                    }

                    File.Copy(path, finalpath);

                    Settings.Instance.datafilepath = finalpath;

                    Settings.Instance.Save();

                    MessageBox.Show("Restore Completed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    Cura.Common.Common.LogError("There was a problem restoring from backup file : " + ex.Message, ex);
                }

            }

        }

        #endregion

        #region Properties
        public bool IsValid
        {
            get
            {
                if (backupRadio.Checked)
                {
                    return backupTxt.Text.Trim().EndsWith(backupextension) && backupTxt.Text.Trim().Length > 3;
                }
                else if (restoreRadio.Checked)
                {
                    return File.Exists(restoreTxt.Text.Trim());
                }

                return false;
            }
        }
        #endregion
   
        /// <summary>
        /// Refresh Controls On The Page
        /// </summary>
        private void RefreshControls()
        {
            backuppanel.Enabled = backupRadio.Checked;
            restorepanel.Enabled = restoreRadio.Checked;

            backuperrorpic.BackgroundImage = (backupTxt.Text.Trim().EndsWith(backupextension) && backupTxt.Text.Trim().Length > 3) ? Cura.Properties.Resources.enable : Cura.Properties.Resources.exclamation;
            restoreerrorpic.BackgroundImage = restoreTxt.Text.EndsWith(backupextension) ? Cura.Properties.Resources.enable : Cura.Properties.Resources.exclamation;
         
            exButton1.Enabled = IsValid;
        }
        
    }
}
