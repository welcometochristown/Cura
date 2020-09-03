using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cura.Controls.Common
{

    public class LongLat
    {
 
        public string pCode;
        public string Longatude;
        public string Latatude;

        public LongLat EMPTY
        {
            get
            {
                return new LongLat();
            }
        }

        public bool IsEmpty
        {
            get
            {
                return !HasLongLat && !HasPCode;
            }
        }

        public bool HasPCode
        {
            get
            {
                return pCode != null;
            }
        }
        public bool HasLongLat
        {
            get
            {
                return (Longatude != null && Latatude != null);
            }
        }

        public void Empty()
        {
            pCode = null;
            Longatude = null;
            Latatude = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="llong"></param>
        /// <param name="llat"></param>
        /// <remarks></remarks>
        public LongLat(string llong, string llat, string pcode)
        {
            this.Longatude = llong;
            this.Latatude = llat;
            this.pCode = pcode;
        }

        public LongLat()
        {
            this.Longatude = null;
            this.Latatude = null;
            this.pCode = null;
        }


        public enum Format
        {
            LongLat,
            LatLong
        }

        public new string ToString(Format format = Format.LongLat)
        {
            switch (format)
            {
                case LongLat.Format.LongLat:
                    return Longatude + ", " + Latatude;
                case LongLat.Format.LatLong:
                    return Latatude + ", " + Longatude;
            }

            return ToString(Format.LongLat);
        }

    }

}
