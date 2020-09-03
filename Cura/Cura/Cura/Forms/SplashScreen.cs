using Cura.Common;
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
    public partial class SplashScreen : Form
    {
        #region Fields
        public System.Threading.Thread ThrRef;
        public bool timeToDie;
        #endregion

        #region Constructor
        public SplashScreen()
        {
            InitializeComponent();
            timeToDie = false;
            versionlbl.Text = "Version " + Info.VERSION;
            trialLbl.Visible = Settings.IsTrial;
        }
        #endregion

        #region Form Load
        private void SplashScreen_Load(object sender, EventArgs e)
        {
        }
        #endregion
        
        /// <summary>
        /// clean up the splash screen plz
        /// </summary>
        public void Cleanup()
        {
            timeToDie = true;
        }

    }
}
