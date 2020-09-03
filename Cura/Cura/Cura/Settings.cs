using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace Cura
{
    class Settings
    {

        #region Fields
        private string _securitykey;
        private string _datafilepath;
        private DateTime _firstweek;
        private int _rotarange;
        private int _rotaweekcount;
        private bool _displaycallwithtraveltime;
        private string _workerNumberAlias;
        private string _serviceNumberAlias;



        public const bool IsTrial = true;

        public static string datafileextension = ".db";

        private static readonly string[] Hashes = { 
                                            "DFA9265DA882FDEB9144DB3D4B784718",
                                            "118F117624CC2659D2EB4FC91B3D5C24",
                                            "32CB6B463CF67DE6BB5B995391A341F8",
                                            "2AB00E1976CD838948339C6415538130"
                                           };


        //DELETE THESE BEFORE RELEASE!
        //KEYS
        private static readonly string[] Keys = {
                "748AC0CB285E672B29C4BBEC3DE82AXXXX",   //Full
                "32CB58395B9320228ACA637F61207514XX",   //2014
                "BF3DC4B3EB28984E07E913981DE91C1410",    //2014 October
                "947BAB94B5F7146198B89341C64F041409"    //2014 September
 
         };


        #endregion

        #region Singleton Stuff
        private static Settings instance;

        public static Settings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Settings();
                    instance.LoadSettings();
                }
                return instance;
            }
        }
#endregion

        public event SettingsEventHandler SettingsChanged;
        public delegate void SettingsEventHandler(object sender, SettingsEventArgs e);

        #region Properties
        public string WorkerNumberAlias
        {
            get
            {
                return _workerNumberAlias;
            }
        }

        public string ServiceUserNumberAlias
        {
            get
            {
                return _serviceNumberAlias;
            }
        }


        public bool IsValid
        {
            get
            {
                if (isValidSecurityKey(securitykey) == SecurityKeyValidityEnum.VALID && datafilepath.EndsWith(datafileextension) && File.Exists(datafilepath) && firstweek != DateTime.MinValue && rotarange != 0 && rotaweekcount != 0)
                {
                    return true;
                }

                return false;
            }
        }

        public string securitykey
        {
            get
            {
                return _securitykey;
            }
            set
            {
                bool changed = (_securitykey != value);
                _securitykey = value;

                if (changed && SettingsChanged != null)
                    SettingsChanged(this, new SettingsEventArgs() { DataReloadRequired = false }); ;

            }
        }

        public string datafilepath
        {
            get
            {
                return _datafilepath;
            }
            set
            {
                bool changed = (_datafilepath != value);
                _datafilepath = value;

                if (changed && SettingsChanged != null)
                    SettingsChanged(this, new SettingsEventArgs() { DataReloadRequired = true }); ;
            }
        }

        public DateTime firstweek
        {
            get
            {
                return _firstweek;
            }
            set
            {
                bool changed = (_firstweek != value);
                _firstweek = value;

                if (changed && SettingsChanged != null)
                    SettingsChanged(this, new SettingsEventArgs() { DataReloadRequired = true }); ;
            }
        }


        public int rotarange
        {
            get
            {
                return _rotarange;
            }
            set
            {
                bool changed = (_rotarange != value);
                _rotarange = value;

                if (changed && SettingsChanged != null)
                    SettingsChanged(this, new SettingsEventArgs() { DataReloadRequired = true }); ;
            }
        }

        public int rotaweekcount
        {
            get
            {
                return _rotaweekcount;
            }
            set
            {
                bool changed = (_rotaweekcount != value);
                _rotaweekcount = value;

                if (changed && SettingsChanged != null)
                    SettingsChanged(this, new SettingsEventArgs() { DataReloadRequired = true }); ;
            }
        }

        public bool displaycallwithtraveltime
        {
            get
            {
                return _displaycallwithtraveltime;
            }
            set
            {
                bool changed = (_displaycallwithtraveltime != value);
                _displaycallwithtraveltime = value;

                if (changed && SettingsChanged != null)
                    SettingsChanged(this, new SettingsEventArgs() { DataReloadRequired = false }); ;
            }
        }
        #endregion

        #region Constructor
        private Settings()
        {
            //private.. what are you looking at??
        }
        #endregion

        #region Enums
        public enum SecurityKeyValidityEnum
        {
            VALID, INVALID, EXPIRED
        }
        #endregion

        public static double DaysRemainingForKey(string key)
        {
            if (isValidSecurityKey(key) != SecurityKeyValidityEnum.VALID)
                return 0;

            if (key.EndsWith("XXXX"))
                return double.PositiveInfinity;

            if (key.EndsWith("XX"))
            {
                return ((new DateTime(DateTime.Now.Year, 12, 31)) - DateTime.Now).TotalDays;
            }
            else
            {
                //month
                return ((new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).AddMonths(1).AddDays(-1) - DateTime.Now).TotalDays;
            }
        }


        /// <summary>
        /// Check A Security Key For Validity
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static SecurityKeyValidityEnum isValidSecurityKey(string key)
        {
            //foreach (string keyX in Keys)
            //{
            //    MD5 md5 = System.Security.Cryptography.MD5.Create();
            //    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(keyX.Trim());
            //    byte[] hash = md5.ComputeHash(inputBytes);

            //    // step 2, convert byte array to hex string
            //    StringBuilder sb = new StringBuilder();
            //    for (int i = 0; i < hash.Length; i++)
            //    {
            //        sb.Append(hash[i].ToString("X2"));
            //    }

            //    Console.WriteLine(sb.ToString().ToUpper());
            //}

            if (key == null || key.Trim().Length == 0)
                return SecurityKeyValidityEnum.INVALID;

            //create hash string from given key
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(key.Trim());
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            string hashString = sb.ToString().ToUpper();

            if (!Hashes.Contains(hashString))
                return SecurityKeyValidityEnum.INVALID;

            //if the key given ends with XXXX and its not contained withing the history of keys
            if (key.EndsWith("XXXX"))
            {
                //ignore
            }else if (key.EndsWith("XX"))
            {
                //year
                if (key.Substring(key.Length - 4, 2) != DateTime.Now.ToString("yy"))
                    return SecurityKeyValidityEnum.EXPIRED;
            }
            else
            {
                //year
                if (key.Substring(key.Length - 4, 2) != DateTime.Now.ToString("yy"))
                    return SecurityKeyValidityEnum.EXPIRED;

                //and month
                if (key.Substring(key.Length - 2, 2) != DateTime.Now.ToString("MM"))
                    return SecurityKeyValidityEnum.EXPIRED;
            }


            return SecurityKeyValidityEnum.VALID;
          
        }

            /// <summary>
        /// Change Bulk Settings
        /// </summary>
        /// <param name="_securitykey"></param>
        /// <param name="_datafilepath"></param>
        /// <param name="_firstweek"></param>
        /// <param name="_rotarange"></param>
        /// <param name="_rotaweekcount"></param>
        /// <param name="_displaycallwithtraveltime"></param>
        /// <param name="dontFireEvent"></param>
        public void ChangeSettings(string _securitykey
                                    , string _datafilepath
                                    , DateTime _firstweek
                                    , int _rotarange
                                    , int _rotaweekcount
                                    , bool _displaycallwithtraveltime
                                    , bool dontFireEvent = false)
        {
            bool changed = (
                this._securitykey != _securitykey ||
                this._datafilepath != _datafilepath ||
                this._firstweek != _firstweek ||
                this._rotarange != _rotarange ||
                this._rotaweekcount != _rotaweekcount ||
                this._displaycallwithtraveltime != _displaycallwithtraveltime
            );

            bool dataneedsrefreshing = (this._datafilepath != _datafilepath ||
                                        this._rotaweekcount != _rotaweekcount ||
                                        this._firstweek != _firstweek);

            this._securitykey = _securitykey;
            this._datafilepath = _datafilepath;
            this._firstweek = _firstweek;
            this._rotarange = _rotarange;
            this._rotaweekcount = _rotaweekcount;
            this._displaycallwithtraveltime = _displaycallwithtraveltime;

            if (!changed || dontFireEvent)
                return;


            SettingsChanged(this, new SettingsEventArgs() { DataReloadRequired = dataneedsrefreshing });

        }

        /// <summary>
        /// Save Settings
        /// </summary>
        public void Save()
        {
            if (File.Exists("./settings.cura"))
                File.Delete("./settings.cura");

            TextWriter fstream = File.CreateText("./settings.cura");

            fstream.WriteLine("<settings>");

            fstream.WriteLine("<datafilepath>" + datafilepath + "</datafilepath>");
            fstream.WriteLine("<securitykey>" + securitykey + "</securitykey>");
            fstream.WriteLine("<firstweek>" + firstweek.ToString("yyyy-MM-dd") + "</firstweek>");
            fstream.WriteLine("<rotarange>" + rotarange.ToString() + "</rotarange>");
            fstream.WriteLine("<rotaweekcount>" + rotaweekcount.ToString() + "</rotaweekcount>");
            fstream.WriteLine("<displaycallwithtraveltime>" + displaycallwithtraveltime.ToString() + "</displaycallwithtraveltime>");
            fstream.WriteLine("<workernumberalias>" + _workerNumberAlias.ToString() + "</workernumberalias>");
            fstream.WriteLine("<servicenumberalias>" + _serviceNumberAlias.ToString() + "</servicenumberalias>");


            fstream.WriteLine("</settings>");

            fstream.Close();
        }

        /// <summary>
        /// Load Settings
        /// </summary>
        public void LoadSettings()
        {
            try
            {

                if (!File.Exists("./settings.cura"))
                    return;

                String fData = "";

                try
                {
                    using (StreamReader infile = new StreamReader("./settings.cura"))
                    {
                        fData = infile.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    /* Couldnt log it, oh well just show the error message form */
                    Cura.Common.Common.LogError("Failed to Load Cura Settings File", ex);
                    return;
                }             

                XmlReader reader= XmlReader.Create(new StringReader(fData));

                bool foundsettings = false;

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
                                                if (reader.Read() & datafilepath == null)
                                                {
                                                    _datafilepath = reader.Value.Trim();
                                                }

                                                break;
                                            case "securitykey":
                                                if (reader.Read() & securitykey == null)
                                                {
                                                    _securitykey = reader.Value.Trim();
                                                }

                                                break;
                                            case "firstweek":
                                                if (reader.Read() && firstweek == DateTime.MinValue)
                                                {
                                                    _firstweek = DateTime.ParseExact(reader.Value.Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                                }

                                                break;
                                            case "rotarange":
                                                if (reader.Read() && rotarange == 0)
                                                {
                                                    _rotarange = Convert.ToInt16(reader.Value.Trim());
                                                }

                                                break;
                                            case "rotaweekcount":
                                                if (reader.Read() && rotaweekcount == 0)
                                                {
                                                    _rotaweekcount = Convert.ToInt16(reader.Value.Trim());
                                                }

                                                break;

                                            case "displaycallwithtraveltime":
                                                if (reader.Read())
                                                {
                                                    _displaycallwithtraveltime = Convert.ToBoolean(reader.Value.Trim());
                                                }

                                                break;
                                            case "servicenumberalias":
                                                if (reader.Read())
                                                {
                                                    _serviceNumberAlias  = reader.Value.Trim();
                                                }
                                                break;
                                            case "workernumberalias":
                                                if (reader.Read())
                                                {
                                                    _workerNumberAlias = reader.Value.Trim();
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

                if (foundsettings)
                {
                    if (SettingsChanged != null)
                    {
                        SettingsChanged(this, null);
                    }
                }

            }
            catch (Exception e)
            { 
                //couldnt open the file, lets create it instead.
               
            }
        }

        public class SettingsEventArgs : EventArgs 
        {
            public bool DataReloadRequired;

            public SettingsEventArgs()
            {

            }
        }
    }
}
