using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cura.Controls;

namespace Cura.Forms
{
    public partial class Test2 : Form
    {
        public Test2()
        {
            InitializeComponent();
        }

        private void Test2_Load(object sender, EventArgs e)
        {
            colourCombo1.Items.Add(new ComboItem() {obj ="hello", color = Color.Red});

        }
    }
}
