using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace Cura.Controls.Common
{
    public  class GoogleMapMarker
	{
		public GoogleMapLocation Location;

		public string Description;
		internal bool IconBounce;
		internal bool NeedGeoCoder;

		internal bool SetAsCenter;

		public string ImageUrl = null;

		public Point MarkerAnchorPoint;

		public Int32 Radius;

		public GoogleMapMarker(GoogleMapLocation loc, string description = null)
		{
			this.Location = loc;

			if (description != null) {
				this.Description = description;
			} else if (loc == null) {
				this.Description = loc.ToString();
			} else {
				this.Description = "";
			}

		}

	}
}
