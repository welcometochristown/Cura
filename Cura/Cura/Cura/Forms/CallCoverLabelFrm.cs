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
    public partial class CallCoverLabelFrm : Form
    {
        #region Fields
        private Worker _worker1;
        private Worker _worker2;
        private ServiceUser _serviceuser;

        private int initialheight;
        private string _startime;
        private string _duration;
        #endregion
    
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CallCoverLabelFrm()
        {
            InitializeComponent();

            initialheight = 85;

            Worker1 = null;
            Worker2 = null;
        }
        #endregion

        #region Properties
        public string StartTime
        {
            get
            {
                return _startime;
            }
            set
            {
                _startime = value;
                calldurationLbl.Text = _startime + " for " + _duration;
            }
        }

        public string Duration
        {
            set
            {
                _duration = value;
                calldurationLbl.Text = _startime + " for " + _duration;
            }
        }

        public ServiceUser ServiceUser
        {
            get
            {
                return _serviceuser;
            }
            set
            {
                _worker1 = null;
                _worker2 = null;

                label1.Text = "Call For";

                _serviceuser = value;

                label2.Visible = true;
                pictureBox1.Visible = false;

                label3.Visible = false;
                pictureBox2.Visible = false;

                label2.Text = _serviceuser.Name;

                RefreshBorder();
            }
        }

        public Worker Worker1
        {
            get
            {
                return _worker1;
            }
            set
            {
                _serviceuser = null;

                label1.Text = "Covered By";

                _worker1 = value;

                label2.Visible = _worker1 != null;
                pictureBox1.Visible = _worker1 != null;

                if (_worker1 != null)
                {
                    label2.Text = _worker1.Name;
                }
                RefreshBorder();
            }
        }

        public Worker Worker2
        {
            get
            {
                return _worker2;
            }
            set
            {
                _worker2 = value;

                label3.Visible = _worker2 != null;
                pictureBox2.Visible = _worker2 != null;

                if (_worker2 != null)
                {
                    label3.Text = _worker2.Name;
                }

                RefreshBorder();
            }
        }
        #endregion

        public void RefreshBorder()
        {
            this.Height = initialheight + (Worker2 == null ? 0 : 20);
        }
    }
}
