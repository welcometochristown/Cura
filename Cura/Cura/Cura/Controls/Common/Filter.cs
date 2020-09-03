using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Cura.Controls.Common
{
  //  public delegate void TextChangedEventHandler(object sender, EventArgs e);

    public partial class Filter : UserControl
    {
        public Filter()
        {
            InitializeComponent();
        }

        public event EventHandler TextChanged;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged != null)
            {
                TextChanged(sender, e);
            }
        }

        public string Text
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }

        private void exButton1_Click(object sender, EventArgs e)
        {
            Text = "";
        }
    }
}
