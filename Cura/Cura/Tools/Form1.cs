using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string file in Directory.GetFiles(@"E:\Code\C-Sharp\Cura\Cura\Help").Where(f => f.ToLower().EndsWith(".html")))
            {
                string data = null;

                using (StreamReader r = new StreamReader(file))
                {
                    data = r.ReadToEnd();
                }

                //data = data.Replace("<span class=\"rvts7\">Created with the Personal Edition of HelpNDoc: </span>", "");

                int start = data.IndexOf("<p class=\"rvps3\">");

                if (start == -1)
                    continue;

                int end = data.IndexOf("</p>", start) + "</p>".Length;

                string newdata = data.Substring(0, start) + data.Substring(end, data.Length - end);

                File.Delete(file);

                using (StreamWriter w = new StreamWriter(file))
                {
                    w.Write(newdata);
                }
            }

        }
    }
}
