using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Cura.Controls
{
    public partial class SoloWorkerListCtrl : WorkerListCtrl 
    {
        public SoloWorkerListCtrl()
            :base(true)
        {
            InitializeComponent();
        }

    }
}
