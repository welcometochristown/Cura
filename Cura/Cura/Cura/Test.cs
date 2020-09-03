using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cura
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();

            objectListView1.Objects = new TestObjectClass[] { new TestObjectClass(), new TestObjectClass() };
        }

        private void objectListView1_SelectionChanged(object sender, EventArgs e)
        {
            Console.WriteLine("changed");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Refresh();
            objectListView1.BuildList(true);
        }
    }

    public class TestObjectClass
    {
        public string field1
        {
            get
            {
               return "blah";
            }
        }
    }
}
