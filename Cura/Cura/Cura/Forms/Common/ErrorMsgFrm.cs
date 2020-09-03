using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Cura.Forms.Common
{
    public partial class ErrorMsgFrm : Form
    {
        #region Constructor
        private ErrorMsgFrm()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties
        protected string Message
        {
            get
            {
                return errTxt.Text;
            }
            set
            {
                errTxt.Text = value;
            }
        }

        protected string Details
        {
            get
            {
                return detailsTxt.Text;
            }
            set
            {
                detailsTxt.Text = value;
            }

        }

        #endregion

        #region Events
        private void showdetailslbl_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed)
            {
                splitContainer1.Panel1Collapsed = false;
                splitContainer1.Panel2Collapsed = true;
            }
            else
            {
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel1Collapsed = true; ;
            }

            showdetailslbl.Text = (splitContainer1.Panel2Collapsed ? "Show" : "Hide") + " Details";
        }

        private void showdetailslbl_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void showdetailslbl_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        #endregion
     
        /// <summary>
        /// Show with message and details
        /// </summary>
        /// <param name="message"></param>
        /// <param name="details"></param>
        public static void Show(string message, string details)
        {
            ErrorMsgFrm frm = new ErrorMsgFrm()
            {
                Details = details,
                Message = message
            };
            frm.ShowDialog();
        }

        /// <summary>
        /// show with message and exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public static void Show(string message, Exception e)
        {
            Show(message, e.ToString());
        }

        /// <summary>
        /// show with exception (e.Message is used as error message)
        /// </summary>
        /// <param name="e"></param>
        public static void Show(Exception e)
        {
            Show(e.Message, e.ToString());
        }


    }
}
