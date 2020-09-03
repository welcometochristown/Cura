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
    public partial class BaseFrm : Form
    {
        #region Contructor
        public BaseFrm()
        {
            InitializeComponent();

            //Set Cura Icon
            Icon = Cura.Common.Common.CuraIcon;
        }
        #endregion

        #region Properties
        public Image Image
        {
            get
            {
                return pictureBox1.BackgroundImage;
            }
            set
            {
                pictureBox1.BackgroundImage = value;
                splitContainer1.Panel1.Font = new Font(FontFamily.GenericSansSerif, 8.25f);
            }
        }
     
        public ImageLayout ImageLayout
        {
            get
            {
                return pictureBox1.BackgroundImageLayout;
            }
            set
            {
                pictureBox1.BackgroundImageLayout = value;
            }
        }

        public string Title
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }
        #endregion

        #region Form Load
        private void BaseFrm_Load(object sender, EventArgs e)
        {

        }
        #endregion
       
    }
}
