using Cura.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Cura.Controls.Common
{
	public class GoogleMapLocation
	{


	protected string[] GoogleError;
	public GoogleMapAddress Add = null;

	public LongLat LongLat = null;

	public string Tag;
	public string GoogleStatusCodeText(int code)
	{
		switch (code) {

			case 200:
				return "Success";
			case 400:
				return "A directions request could not be successfully parsed. For example, the request may have been rejected if it contained more than the maximum number of waypoints allowed.";
			case 500:
				return "A geocoding, directions or maximum zoom level request could not be successfully processed, yet the exact reason for the failure is not known.";
			case 601:
				return "The HTTP q parameter was either missing or had no value. For geocoding requests, this means that an empty address was specified as input. For directions requests, this means that no query was specified in the input.";
			case 602:
				return "No corresponding geographic location could be found for the specified address. This may be due to the fact that the address is relatively new, or it may be incorrect.";
			case 603:
				return "The geocode for the given address or the route for the given directions query cannot be returned due to legal or contractual reasons.";
			case 604:
				return "The GDirections object could not compute directions between the points mentioned in the query. This is usually because there is no route available between the two points, or because we do not have data for routing in that region.";
			case 610:
				return "The given key is either invalid or does not match the domain for which it was given.";
			case 620:
				return "The given key has gone over the requests limit in the 24 hour period or has submitted too many requests in too short a period of time. If you're sending multiple requests in parallel or in a tight loop, use a timer or pause in your code to make sure you don't send the requests too quickly.";
			default:
				return "Unknown Error";
		}
	}

	public GoogleMapLocation(GoogleMapAddress add, LongLat longlat, string tag = null)
	{
		this.Add = add;
		this.LongLat = longlat;
		this.Tag = tag;
	}

	public GoogleMapLocation(GoogleMapAddress add, string tag = null)
	{
		this.Add = add;
		this.LongLat = QueryGoogleForLongLat(@add);
		this.Tag = tag;
	}

	public GoogleMapLocation(LongLat longlat, string tag = null)
	{
		this.LongLat = longlat;
		this.Add = QueryGoogleForAddress(longlat);
		this.Tag = tag;
	}

	public LongLat QueryGoogleForLongLat(GoogleMapAddress add)
	{
		if (add == null)
			throw new NullReferenceException("Invalid LongLat Object. Cannot Load PostCode");

		if (add.PostCode.Split(' ').Count() > 2)
			throw new Exception("Invalid Postcode Format");

		LongLat retVal;

		try
		{
			retVal = QueryLocalSourceForLongLat(add);
		}
		catch (Exception e) { retVal = null;}
	   

		if(retVal == null)
		{
			try
			{
				LocationDetailsQuery qr = QueryGoogleForLocation(add.ToString());

				if (qr.ErrorCode != null)
				{
					throw new Exception("Error Loading Location Details : " + qr.ErrorCode);
				}
				else if (qr.LongLat == null)
				{
					throw new PostCodeNotFoundException("Post Code Not Found For (" + add.PostCode + "," + add.Country + ")");
				}

				retVal = new LongLat(qr.LongLat.Split(',')[0], qr.LongLat.Split(',')[1], add.PostCode );
			}
			catch (Exception ex)
			{
				throw new Exception("Failed to get location details");
			}
		
		}

	   return retVal;
	}

	public GoogleMapAddress QueryGoogleForAddress(LongLat ll)
	{
	//	if (Add == null)
		//	throw new NullReferenceException("Invalid Address Object. Cannot Load LongLat");

		GoogleMapAddress retVal;

		try
		{

		   retVal= QueryLocalSourceForAddress(ll);
		}
		catch (Exception ex) { retVal = null; }

		if (retVal == null)
		{
			try
			{
				LocationDetailsQuery qr = QueryGoogleForLocation(ll.ToString());


				if (qr.ErrorCode != null)
				{
					throw new Exception("Error Loading Location Details : " + qr.ErrorCode);
				}
				else if (qr.PCode == null)
				{
					throw new PostCodeNotFoundException("Post Code Not Found For (" + ll.Longatude + ", " + ll.Latatude + ")");
				}
				else if (qr.Country == null)
				{
					throw new CountryNotFoundException("Country Not Found For (" + ll.Longatude + ", " + ll.Latatude + ")");
				}

				retVal = new GoogleMapAddress(qr.PCode, qr.Country);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed to get location details");
			}
		

			
		}

		return retVal;
	}


	public GoogleMapAddress QueryLocalSourceForAddress(LongLat ll)
	{
		DataTable tb = Database.ExecutePCodeDatabaseQuery("SELECT postcode FROM tbl_postcodes WHERE latitude = " + ll.Latatude.ToString() + " and longitude = " + ll.Longatude.ToString());

		if (tb.Rows.Count != 1)
			return null;

		string pcode = tb.Rows[0][0].ToString();

		pcode = pcode.Insert(pcode.Length -3, " ");

		return new GoogleMapAddress(pcode, "UK");
	}

	public LongLat QueryLocalSourceForLongLat(GoogleMapAddress add)
	{
		DataTable tb = Database.ExecutePCodeDatabaseQuery("SELECT longitude, latitude FROM tbl_postcodes WHERE postcode = '" + add.PostCode.Replace(" ", "") + "'");

		if (tb.Rows.Count != 1)
			return null;

		return new LongLat(tb.Rows[0][0].ToString(), tb.Rows[0][1].ToString(), add.PostCode ); ;
	}


	public class LocationDetailsQuery
	{
		public string PCode;
		public string Country;

		public string LongLat;
		public string ErrorCode = null;
	}

	private string ReadResult(string xmlStr)
	{
		XmlReader reader = XmlReader.Create(new StringReader(xmlStr));

		while (reader.Read()) {
			if (reader.IsStartElement() & reader.Name == "GeocodeResponse") {
				reader.Read();


				if (reader.IsStartElement() & reader.Name == "status") {
					reader.Read();
					return reader.Value.Trim();

				}

			}
		}

		return null;
	}

	private string ReadLat(string xmlStr)
	{
		XmlReader reader = XmlReader.Create(new StringReader(xmlStr));

		while (reader.Read()) {
			if (reader.IsStartElement() & reader.Name == "geometry") {
				reader.Read();


				if (reader.IsStartElement() & reader.Name == "location") {
					while (reader.Read()) {
						if (reader.IsStartElement() & reader.Name == "lat") {
							reader.Read();

							return reader.Value.Trim();
						}

					}

				}

			}
		}

		return null;
	}

	private string ReadLong(string xmlStr)
	{
		XmlReader reader = XmlReader.Create(new StringReader(xmlStr));

		while (reader.Read()) {
			if (reader.IsStartElement() & reader.Name == "geometry") {
				reader.Read();


				if (reader.IsStartElement() & reader.Name == "location") {
					while (reader.Read()) {
						if (reader.IsStartElement() & reader.Name == "lng") {
							reader.Read();

							return reader.Value.Trim();
						}

					}

				}

			}
		}

		return null;
	}

	private string ReadAddressComponent(string xmlStr, string ComponentName, bool useShortName = false)
	{
		XmlReader reader = XmlReader.Create(new StringReader(xmlStr));

		while (reader.Read()) {

			if (reader.IsStartElement()) {
				switch (reader.Name) {
					case "address_component":

						string lName = null;
						string sName = null;
						string type = null;

						while (reader.Read()) {

							if (reader.IsStartElement()) {
								switch (reader.Name) {

									case "long_name":
										if (reader.Read() & type == null) {
											lName = reader.Value.Trim();
										}

										break;
									case "short_name":
										if (reader.Read() & type == null) {
											sName = reader.Value.Trim();
										}

										break;
									case "type":
										// read the value
										if (reader.Read() & type == null) {
											type = reader.Value.Trim();
										}
										break;
								}


							} else if (reader.Name == "address_component") {
								break; // TODO: might not be correct. Was : Exit While
							}

						}

						if (type != null && type.Trim().ToLower() == ComponentName.Trim().ToLower()) {
							return useShortName ? sName : lName;
						}

						break;
				}

			}
		}
		return null;
	}


	protected LocationDetailsQuery QueryGoogleForLocation(string locstr)
	{

		System.IO.Stream Str = null;
		System.IO.StreamReader srRead = null;

		string retStr = null;

		try {
			// make a Web request
			System.Type t = this.GetType();
			string s = "http://maps.google.com/maps/api/geocode/xml?address=" + locstr.Replace(" ", "%20") + "&sensor=false";
			System.Net.WebRequest req = System.Net.WebRequest.Create(s);
			System.Net.WebResponse resp = req.GetResponse();
			Str = resp.GetResponseStream();
			srRead = new System.IO.StreamReader(Str);
			// read all the text 
			retStr = srRead.ReadToEnd();
		} catch (Exception ex) {
			throw new Exception("Couldnt Load Data From Google : " + ex.ToString());
			retStr = null;
		} finally {
			//  Close Stream and StreamReader when done
			if (srRead != null)
				srRead.Close();
			if (Str != null)
				Str.Close();
		}

		LocationDetailsQuery details = new LocationDetailsQuery();


		if (!(ReadResult(retStr) == "OK")) {
			details.ErrorCode = "Error Getting Status Code";

		} else {
			details.LongLat = ReadLong(retStr) + ", " + ReadLat(retStr);
			details.PCode = ReadAddressComponent(retStr, "postal_code");
			details.Country = ReadAddressComponent(retStr, "country", true);

		}
	

		return details;
	}

	public override string ToString()
	{
		string retStr = Add.ToString();
		if (LongLat != null) {
			retStr += " [ " + LongLat.ToString() + " ] ";
		}

		return retStr;
	}

}


public class LongLatNotFoundException : Exception
{

	public LongLatNotFoundException(string str) : base(str)
	{
	}

}

public class PostCodeNotFoundException : Exception
{

	public PostCodeNotFoundException(string str) : base(str)
	{
	}

}

public class CountryNotFoundException : Exception
{

	public CountryNotFoundException(string str) : base(str)
	{
	}

}

}
