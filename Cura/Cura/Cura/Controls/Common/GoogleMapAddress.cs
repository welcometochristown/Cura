using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cura.Controls.Common
{
    public  class GoogleMapAddress
    {

        public string PostCode;

        public string Country;
        public GoogleMapAddress(string postcode, string country)
        {
	        this.PostCode = postcode.Trim().ToUpper();
	        this.Country = country.Trim();
        }

        public override string ToString()
        {
	        if (Country == null & PostCode == null)
		        return "";
	        if (PostCode == null & Country != null)
		        return Country.Trim();
	        if (Country == null & PostCode != null)
		        return PostCode.Trim();


	        if (PostCode.Trim().Length == 0 & Country.Trim().Length == 0)
		        return "";

	        if (PostCode.Trim().Length == 0)
		        return Country.Trim();
	        if (Country.Trim().Length == 0)
		        return PostCode.Trim();

	        return PostCode.Trim() + ", " + Country.Trim();
        }

    }
}
