using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CuraMerge
{
    public partial class Form1 : BaseFrm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel00.Enabled = true;
            panel01.Enabled = false;
            panel02.Enabled = false;
        }

        private void oldcurafilebtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog frm = new FolderBrowserDialog();

            bool validDirectory = isValidCuraDirectory(oldcurapathtxt.Text);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //check if its a valid cura folder
                validDirectory = isValidCuraDirectory(frm.SelectedPath);
                fileerrorpic.BackgroundImage = validDirectory ? Properties.Resources.enable : Properties.Resources.exclamation;
                oldcurapathtxt.Text = frm.SelectedPath;
           
            }

            panel01.Enabled = validDirectory;
            loadin02.Visible = validDirectory;
            loading01.Visible = !validDirectory;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            fileerrorpic2.Visible = true;
            fileerrorpic3.Visible = false;
            fileerrorpic4.Visible = false;

            datafiletxt.Enabled = false;
            newdatalocationfilebtn.Enabled = false;

            checkBox1.Checked = false;
            panel02.Enabled = false;

            loadin02.Visible = false;
            loading03.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            fileerrorpic2.Visible = false;
            fileerrorpic3.Visible = true;
            fileerrorpic4.Visible = false;

            datafiletxt.Enabled = false;
            newdatalocationfilebtn.Enabled = false;

            panel02.Enabled = true;

            loadin02.Visible = false;
            loading03.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            fileerrorpic2.Visible = false;
            fileerrorpic3.Visible = false;
            fileerrorpic4.Visible = true;

            datafiletxt.Enabled = true;
            newdatalocationfilebtn.Enabled = true;


            panel02.Enabled = isValidCuraDirectory(datafiletxt.Text);

            loadin02.Visible = false;
            loading03.Visible = true;

            loading03.Visible = Directory.Exists(datafiletxt.Text);
            loadin02.Visible = !Directory.Exists(datafiletxt.Text);
        }

        private void newdatalocationfilebtn_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog frm = new FolderBrowserDialog();

            bool validDirectory = Directory.Exists(datafiletxt.Text);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //check if its a valid cura folder
                validDirectory = Directory.Exists(frm.SelectedPath);
                fileerrorpic4.BackgroundImage = validDirectory ? Properties.Resources.enable : Properties.Resources.exclamation;
                datafiletxt.Text = frm.SelectedPath;

            }

            panel02.Enabled = validDirectory;

            loading03.Visible = validDirectory;
            loadin02.Visible = !validDirectory;

        }

        private bool isValidFile(string filePath)
        {
            if (filePath.Trim().Length == 0)
                return false;

            if (!File.Exists(filePath))
                return false;

            if (!filePath.EndsWith("db"))
                return false;

            return true;
        }

        private bool isValidCuraDirectory(string curaPath)
        {
            if (curaPath.Trim().Length == 0)
                return false;

            if (!Directory.Exists(curaPath))
                return false;

            string[] directories = Directory.GetDirectories(curaPath);
            string[] files = Directory.GetFiles(curaPath);

            if (directories.SingleOrDefault(d => d.ToLower().EndsWith("data")) == null)
                return false;

            if (files.SingleOrDefault(d => d.ToLower().EndsWith("cura.exe")) == null)
                return false;

            return true;
        }

        private void mergeBtn_Click(object sender, EventArgs e)
        {
            mergeBtn.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                //ok lets get the cura directory
                string curaDirectory = oldcurapathtxt.Text;
                string settingsDirectory = curaDirectory + '\\' + "settings.cura";

                //get settings
                SettingsFileInfo inf = LoadSettingsFileInfo(settingsDirectory);
                int index = inf._datafilepath.LastIndexOf("\\") + 1;
                string datafilename = inf._datafilepath.Substring(index, inf._datafilepath.Length - index);

                string newlocation = null;
                //move data file?
                if (datakeepRadio.Checked)
                {
                    //keep data in the same place, dont really need to do anything.
                    newlocation = inf._datafilepath;
                }
                else if (newCuralocationRadio.Checked)
                {
                    newlocation = Environment.GetEnvironmentVariable("LocalAppData") + "\\Cura\\data\\" + datafilename;

                    //copy data file to current Cura data folder
                    File.Copy(inf._datafilepath, newlocation, true);
                }
                else if (newlocationRadio.Checked)
                {
                    //get the location for new cura data file location
                    newlocation = datafiletxt.Text + "\\" + datafilename;

                    //copy old data file to new location
                    File.Copy(inf._datafilepath, newlocation);

                }

                inf._datafilepath = newlocation;

                //save settings to new cura folder
                SaveSettingsFileInfo(inf);

                //delete old cura?
                if (checkBox1.Checked)
                    Directory.Delete(curaDirectory, true);

                MessageBox.Show("Merge Completed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occured During Merge : \r\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error ); ;
            }

            Cursor = Cursors.Default ;
            mergeBtn.Enabled = true;
        }

        /// <summary>
        /// Load Settings From A Cura Settings File
        /// </summary>
        /// <param name="settingsFilePath"></param>
        /// <returns></returns>
        public SettingsFileInfo LoadSettingsFileInfo(string settingsFilePath)
        {
            SettingsFileInfo sfi = new SettingsFileInfo();

            if (!File.Exists(settingsFilePath))
                return null;

            String fData = "";

            try
            {
            using (StreamReader infile = new StreamReader(settingsFilePath))
            {
                fData = infile.ReadToEnd();
            }
            }
            catch (Exception ex)
            {
                /* Couldnt log it, oh well just show the error message form */
                return null;
            }             

            XmlReader reader= XmlReader.Create(new StringReader(fData));

            #region ReadXML
            bool foundsettings = false;
            try
            {
                while (reader.Read())
                {

                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "settings":
                                foundsettings = true;
  
                                while (reader.Read())
                                {

                                    if (reader.IsStartElement())
                                    {
                                        switch (reader.Name)
                                        {

                                            case "datafilepath":
                                                if (reader.Read())
                                                {
                                                    sfi._datafilepath = reader.Value.Trim();
                                                }

                                                break;
                                            case "securitykey":
                                                if (reader.Read() )
                                                {
                                                    sfi._securitykey = reader.Value.Trim();
                                                }

                                                break;
                                            case "firstweek":
                                                if (reader.Read() )
                                                {
                                                   sfi._firstweek = DateTime.ParseExact(reader.Value.Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                                }

                                                break;
                                            case "rotarange":
                                                if (reader.Read())
                                                {
                                                    sfi._rotarange = Convert.ToInt16(reader.Value.Trim());
                                                }

                                                break;
                                            case "rotaweekcount":
                                                if (reader.Read() )
                                                {
                                                   sfi. _rotaweekcount = Convert.ToInt16(reader.Value.Trim());
                                                }

                                                break;

                                            case "displaycallwithtraveltime":
                                                if (reader.Read())
                                                {
                                                    sfi._displaycallwithtraveltime = Convert.ToBoolean(reader.Value.Trim());
                                                }

                                                break;
                                                
                                        }


                                    }
                                    else if (reader.Name == "settings")
                                    {
                                        break; // TODO: might not be correct. Was : Exit While
                                    }

                                }

                                break;
                        }

                    }
                }


            }
            catch (Exception e)
            { 
                //couldnt open the file, lets create it instead.
                return null;
            }
            #endregion

            return sfi;
        }

        public void SaveSettingsFileInfo(SettingsFileInfo info)
        {
            string settingspath = Environment.GetEnvironmentVariable("LocalAppData") + "\\Cura\\bin\\settings.cura";

            if (File.Exists(settingspath))
                File.Delete(settingspath);

            TextWriter fstream = File.CreateText(settingspath);

            fstream.WriteLine("<settings>");

            fstream.WriteLine("<datafilepath>" + info._datafilepath  + "</datafilepath>");
            fstream.WriteLine("<securitykey>" + info._securitykey + "</securitykey>");
            fstream.WriteLine("<firstweek>" + info._firstweek.ToString("yyyy-MM-dd") + "</firstweek>");
            fstream.WriteLine("<rotarange>" + info._rotarange.ToString() + "</rotarange>");
            fstream.WriteLine("<rotaweekcount>" + info._rotaweekcount.ToString() + "</rotaweekcount>");
            fstream.WriteLine("<displaycallwithtraveltime>" + info._displaycallwithtraveltime.ToString() + "</displaycallwithtraveltime>");


            fstream.WriteLine("</settings>");

            fstream.Close();
        }

    }

    public class SettingsFileInfo
    {
        public string _securitykey;
        public string _datafilepath;
        public DateTime _firstweek;
        public int _rotarange;
        public int _rotaweekcount;
        public bool _displaycallwithtraveltime;
    }
    
    
}
