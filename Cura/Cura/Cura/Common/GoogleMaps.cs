using Cura.Controls.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cura.Common
{
    class GoogleMaps
    {

        private static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public static double GetDistance(LongLat l1, LongLat l2, string unit)
        {           
            if(l1 == null || l2 == null)
                return -1;

            if(l1.IsEmpty || l2.IsEmpty)
                return -1;

           if(!l1.HasLongLat || !l2.HasLongLat)
                return -1;

           #region Haversine Formula

           double lat1 = Convert.ToDouble(l1.Latatude);
           double lon1 = Convert.ToDouble(l1.Longatude);

           double lat2 = Convert.ToDouble(l2.Latatude);
           double lon2 = Convert.ToDouble(l2.Longatude);


           double R = 6371; // Radius of the earth in km
           double dLat = DegreeToRadian(lat2 - lat1);  // deg2rad below
           double dLon = DegreeToRadian(lon2 - lon1);
           double a =
             Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
             Math.Cos(DegreeToRadian(lat1)) * Math.Cos(DegreeToRadian(lat2)) *
             Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
             ;
           double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
           double dKM = R * c; // Distance in km

           #endregion

            //switch between units
           switch (unit.ToLower())
           {
               case "m":
                   return (dKM * 0.62137);
               default:
                   return dKM;
           }

        }

        string BuildGMapsHTML(string pcode, int width, int height)
        {
            return BuildGMapsHTML(0, 0, width, height);
        }

        string BuildGMapsHTML(long longitude, long latitude, int width, int height)
        {

           string CenterLongLat = "53.79984,-1.549072";

            //'create the header bit
            string retHTMLStr = "" + 
            "<!DOCTYPE html>" + 
            "<html dir=" + (char)(34) + "rtl" +  (char)(34) + ">" + 
            "<head>" + 
            "<meta http-equiv=" +  (char)(34) + "Content-Type" +  (char)(34) + " content=" +  (char)(34) + "text/html; charset=utf-8" +  (char)(34) + "> " + 
            "<link href=" +  (char)(34) + "http://code.google.com/apis/maps/documentation/javascript/examples/default.css" +  (char)(34) + " rel=" +  (char)(34) + "stylesheet" +  (char)(34) + " type=" +  (char)(34) + "text/css" +  (char)(34) + " /> " + 
            "<script type=" +  (char)(34) + "text/javascript" +  (char)(34) + " src=" +  (char)(34) + "http://maps.google.com/maps/api/js?sensor=false+language=en" +  (char)(34) + "></script>" + 
            "<script  type=" +  (char)(34) + "text/javascript" +  (char)(34) + "> " + "\r\n" + 
            "var newcastleuk = new google.maps.LatLng(54.991797,-1.609497);" + "\r\n" + 
            "var centeruk = new google.maps.LatLng(54.952386,-3.120117);" + "\r\n" + 
            "var center = new google.maps.LatLng(" + CenterLongLat + ");" + "\r\n";

            //create the javascript body bit
            retHTMLStr += "" + 
            "function createmarker(map, location, desc, bounce, setascenter, imageurl, size, origin, anchor, radius) {" + "\r\n" + 
                "var image;" + "\r\n" + 
                "if (imageurl)" + "\r\n" + 
                "{" + "\r\n" + 
                     "if (anchor)" + "\r\n" + 
                     "{" + "\r\n" + 
                        "image= new google.maps.MarkerImage(imageurl," + "\r\n" + 
                        "// This marker is 20 pixels wide by 32 pixels tall." + "\r\n" + 
                        "size," + "\r\n" + 
                        "// The origin for this image is 0,0." + "\r\n" + 
                        "origin, anchor);" + 
                    "} else {" + "\r\n" + 
                            "image= new google.maps.MarkerImage(imageurl," + "\r\n" + 
                            "// This marker is 20 pixels wide by 32 pixels tall." + "\r\n" + 
                            "size," + "\r\n" + 
                            "// The origin for this image is 0,0." + "\r\n" + 
                            "origin);" + 
                    "}" + "\r\n" + 
                "}" + "\r\n" + 
                "if (radius)" + "\r\n" + 
                "{" + "\r\n" + 
                 "var populationOptions = {" + "\r\n" + 
                                        "strokeColor: #FF0000, \r\n" + 
                                        "strokeOpacity: 0.8," + "\r\n" + 
                                        "strokeWeight: 2," + "\r\n" + 
                                        "fillColor: #FF0000,\r\n" + 
                                        "fillOpacity: 0.35," + "\r\n" + 
                                        "map:    map," + "\r\n" + 
                                        "center: location," + "\r\n" + 
                                        "radius : radius" + "\r\n" + 
                                        "};" + "\r\n" + 
                "var cityCircle = new google.maps.Circle(populationOptions);" + "\r\n" + 
                "}" + "\r\n" + 
                "var marker = new google.maps.Marker({map: map, position: location, title : desc, icon:image});" + "\r\n" + 
                "if(bounce == true){marker.setAnimation(google.maps.Animation.BOUNCE);}" + "\r\n" + 
                "var infowindow = new google.maps.InfoWindow();" + "\r\n" + 
                "google.maps.event.addListener(marker, 'click'," + "\r\n" + 
                    " function() {" + "\r\n" + 
                    "     infowindow.open(map, marker);" + "\r\n" + 
                    "}" + "\r\n" + 
                ");" + "\r\n" + 
                "if(setascenter == true){map.setCenter(location);}" + "\r\n" + 
            "};" + "\r\n";


            int Zoom = 5;

            retHTMLStr += "" + 
            "function init() {" + 
              "var map = new google.maps.Map(document.getElementById(" + (char)(34) + "mapcanvas" + (char)(34) + "), {scaleControl: true}); " + "\r\n" + 
               "var geocoder = new google.maps.Geocoder();" + "\r\n" + 
               "map.setCenter(center);" + "\r\n" + 
               "map.setZoom(" + Zoom.ToString().Trim() + ");" + "\r\n" + 
               "map.setMapTypeId(google.maps.MapTypeId.ROADMAP);" + "\r\n";
           


            //For Each marker As MapMarker In MarkerList

            //    If marker.Location.LongLat IsNot Nothing Then
            //        '  retHTMLStr += "var loc = new google.maps.LatLng(" + marker.Location.LongLat.ToString(LongLat.Format.LatLong) + ")" + "\r\n"
            //        retHTMLStr += "createmarker(map, new google.maps.LatLng(" + marker.Location.LongLat.ToString(LongLat.Format.LatLong) + ")" + ", '" + marker.Description.Replace("'", "' + " + Chr(34) + "'" + Chr(34) + " + '") + "', " + marker.IconBounce.ToString.ToLower() + ", " + marker.SetAsCenter.ToString.ToLower() + ", '" + marker.ImageUrl + "', new google.maps.Size(32, 37) , new google.maps.Point(0,0) " + If(marker.MarkerAnchorPoint = Nothing, "", ", new google.maps.Point(" + marker.MarkerAnchorPoint.X.ToString() + "," + marker.MarkerAnchorPoint.Y.ToString + ")") + ", null," + If(marker.Radius = Nothing, "null", (marker.Radius * 1609.344).ToString()) + " );" + "\r\n"

            //    End If

            //Next

            retHTMLStr += "}" + "\r\n";

           //create the footer stuff
            retHTMLStr += "" +
            "</script>" +
            "</head>" +
            "<body onload=" + (char)(34) + "init()" + (char)(34) + ">" +
            "<div id=" + (char)(34) + "mapcanvas" + (char)(34) + " style=" + (char)(34) + "width: " + width + "px; height: " + height + "px;" + (char)(34) + "></div>" +
            "</body>" +
            "</html>";

            return retHTMLStr;
        }
    }
}
