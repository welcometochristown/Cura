using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cura.Controls
{
    public partial class SoloServiceUserListCtrl : ServiceUserListCtrl
    {
        public SoloServiceUserListCtrl()
            :base(true)
        {
            InitializeComponent();
        }
    }
}
