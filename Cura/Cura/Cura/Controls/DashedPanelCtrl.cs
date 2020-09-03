using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cura.Controls
{
    public partial class DashedPanelCtrl : Panel
    {
        public DashedPanelCtrl()
        {
            InitializeComponent();

            this.Paint += DashedPanelCtrl_Paint;
        }

        //public DashedPanelCtrl(IContainer container)
        //{
        //    container.Add(this);

        //    InitializeComponent();

        //    this.Paint += DashedPanelCtrl_Paint;
        //}

        void DashedPanelCtrl_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Dashed);
        }

        private void DashedPanelCtrl_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }


    }
}
