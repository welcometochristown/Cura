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
    public partial class HelpFrm : Form
    {

        #region Constructor
        public HelpFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public string Caption
        {
            get
            {
                return titlelbl.Text;
            }
            set
            {
                if (value != null && value.Trim().Length > 0)
                {
                    titlelbl.Text = value;
                }
            }
        }

        public string Message
        {
            get
            {
                return infolbl.Text;
            }
            set
            {
                infolbl.Text = value;
            }
        }
        #endregion

        #region Events
        private void HelpFrm_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //frm = new HelpLibraryFrm();
            //frm.ShowDialog();

           // Help.ShowHelp(this, "cura.chm");

            LibraryHelpFrm frm = new LibraryHelpFrm();
            frm.ShowDialog();

          //  Close();
        }
        #endregion
      
    }
}
