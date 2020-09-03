using Cura.CuraEgg;
using Cura.Forms;
using Cura.Forms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cura
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                bool result;
                var mutex = new System.Threading.Mutex(true, "Cura", out result);

                if (!result)
                {
                    MessageBox.Show("Another instance is already running.", "Cura already running");
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new MainFrm() );

                GC.KeepAlive(mutex); 
            }
            catch (Exception e)
            {
                //oh dear
                Cura.Common.Common.LogError(e);
            }
        }

  
    }
}
