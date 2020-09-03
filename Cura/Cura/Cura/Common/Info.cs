using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cura.Common
{
    public class Info
    {
        public static string APPNAME = "Cura";
        private static string _VERSION = "1.2";
        //Version - Release.Patch.Fix (affix b for beta)

        public static string VERSION
        {
            get
            {
                return _VERSION + (_VERSION.ToLower().EndsWith("b")? " (Beta)": "");
            }
        }
        
    }
}
