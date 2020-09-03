using Cura.Common;
using Cura.CuraEgg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cura.Forms
{
    public partial class About : Form
    {
        #region Constructor
        public About()
        {
            InitializeComponent();

            versionlbl.Text =  "Version " + Info.VERSION;
        }
        #endregion

        #region Events
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > 56 && e.X < 71)
            {
                if (e.Y > 53 && e.Y < 68)
                {
                  //  SnakeFrm frm = new SnakeFrm();
                 //   frm.ShowDialog();
                }
            }
        }
      
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"http://www.curamanage.com");
        }
       
    }
}
