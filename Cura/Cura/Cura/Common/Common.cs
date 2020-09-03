using Cura.Forms.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Cura.Common
{
    public class Common
    {
        public static Icon CuraIcon
        {
            get
            {
                return Cura.Properties.Resources.cura;
            }
        }

        private static string errorfile = @"error.txt";

        public static void LogError(string message, string details, bool showErrorFrm = true)
        {
            try
            {
                using (StreamWriter outfile = new StreamWriter(errorfile, true))
                {
                    outfile.Write("[" + DateTime.Now.ToString() + "]\r\n" + message + "\r\n" + details + "\r\nVersion(" + Info.VERSION + ")\r\n\r\n");
                }
            }
            catch (Exception ex)
            {
                /* Couldnt log it, oh well just show the error message form */
            }

            if (showErrorFrm)
            {
               ErrorMsgFrm.Show(message, details);
            }
        }

        public static void LogError(string message, Exception ex, bool showErrorFrm = true)
        {
            LogError(message, ex.ToString(), showErrorFrm);
        }

        public static void LogError(Exception ex, bool showErrorFrm = true)
        {
            LogError(ex.Message, ex.ToString(), showErrorFrm);
        }
    }
}
