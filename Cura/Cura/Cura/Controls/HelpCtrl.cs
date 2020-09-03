using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Cura.Forms;
using System.Drawing.Design;
using Cura.Common;

namespace Cura.Controls
{
    public partial class HelpCtrl : UserControl
    {
        #region Fields
            private string _caption;
            private string _message;
            private bool _openleft;
            private bool _openup;
        #endregion

        #region Constructor
            public HelpCtrl()
            {
                InitializeComponent();

                helpImg.BackgroundImage = ImageManager.Instance.GetImage("information");

                this._openleft = false;
                this._openup = false;
            }
        #endregion

        #region Events
      
            private void helpImg_MouseEnter(object sender, EventArgs e)
            {
              //  helpImg.BackgroundImage = Cura.Properties.Resources.questionmark_16_blue;
                Cursor = Cursors.Help;

            }

            private void helpImg_MouseLeave(object sender, EventArgs e)
            {
              //  helpImg.BackgroundImage = Cura.Properties.Resources.questionmark_16;
                Cursor = Cursors.Default;
            }

            private void helpImg_Click(object sender, EventArgs e)
            {
                if (_message == null)
                    return;

                HelpFrm frm = new HelpFrm();

                frm.Message = _message;
                frm.Caption = _caption;
               
                frm.Show();

                Point p = Cursor.Position;

                if (OpenLeft)
                {
                    p.X -= frm.Width;
                }

                if (OpenUp)
                {
                    p.Y -= frm.Height;
                }
                

                frm.Location = p;

               

            }
            #endregion

        #region Properties
        public string Caption 
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
            }
        }

       [Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(UITypeEditor))]
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
            }
        }

        public bool OpenLeft
        {
            get
            {
                return _openleft;
            }
            set
            {
                _openleft = value;
            }
        }

        public bool OpenUp
        {
            get
            {
                return _openup;
            }
            set
            {
                _openup = value;
            }
        }
        #endregion
    }
}
