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
    public partial class LoadingFrm : Form
    {

        #region Constructor
        public LoadingFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public int Value
        {
            set
            {
                if (value > progressBar1.Maximum)
                    value = progressBar1.Maximum;

                progressBar1.Value = value;
            }
        }


        public int MaxValue
        {
            set
            {
                progressBar1.Maximum = value;
            }
        }
        #endregion
     
    }
}
