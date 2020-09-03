using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Cura.Controls.Common
{
    public partial class GoogleMap : WebBrowser
    {
        public GoogleMap()
        {
            InitializeComponent();

            ScriptErrorsSuppressed = true;
        }

        public GoogleMap(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            ScriptErrorsSuppressed = true;
        }

        public int Zoom = 10;
        public string CenterLongLat = "53.79984,-1.549072";

        List<GoogleMapMarker> MarkerList = new List<GoogleMapMarker>();

        protected bool _outputtoconsole;
        public bool OutputHTMLToConsole
        {
            get { return _outputtoconsole; }
            set { _outputtoconsole = value; }
        }

        private void GoogleMap_Load(System.Object sender, System.EventArgs e)
        {
            //reload the map

            Reload();
        }



        public void AddLocationMarkerRange(GoogleMapLocation[] locations, string markerImageURL = null, bool setascenter = true, bool bounce = true, Point markeranchor = new Point(), double radius = 0)
        {
            foreach (GoogleMapLocation l in locations)
            {
                MarkerList.Add(new GoogleMapMarker(l, l.Tag.ToString())
                {
                    IconBounce = bounce,
                    SetAsCenter = setascenter,
                    ImageUrl = markerImageURL,
                    MarkerAnchorPoint = markeranchor,
                    Radius = (int)radius
                });
            }

            //reload the map
            Reload();
        }


        public void AddLocationMarker(GoogleMapLocation location, string markerImageURL = null, string Description = null, bool setascenter = true, bool bounce = true, Point markeranchor = new Point(), double radius = 0)
        {
            MarkerList.Add(new GoogleMapMarker(location, Description)
            {
                IconBounce = bounce,
                SetAsCenter = setascenter,
                ImageUrl = markerImageURL,
                MarkerAnchorPoint = markeranchor,
                Radius = (int)radius
            });

            //reload the map
            Reload();
        }

        public void RemoveLocationMarker(int index)
        {
            MarkerList.RemoveAt(index);

            Reload();
        }

        public void RemoveAllLocationMarkers()
        {
            MarkerList.Clear();

            Reload();
        }


        public void SetLocationBounce(GoogleMapMarker marker, bool bounce)
        {
            marker.IconBounce = bounce;

            //reload the map
            Reload();
        }


        public override void Refresh()
        {
            base.Refresh();

            Reload();
        }


        private void Reload()
        {
            DocumentText = BuildGMapsHTML();

            // While WebBrowser1.ReadyState <> WebBrowserReadyState.Complete
            //need this to refresh the damn thing
            Application.DoEvents();
            //

            //       Application.DoEvents()
        }
        string BuildGMapsHTML()
        {

            //'create the header bit
            string retHTMLStr = "" +
            "<!DOCTYPE html>" +
            "<html dir=" + (char)(34) + "rtl" + (char)(34) + ">" +
            "<head>" +
            "<meta http-equiv=" + (char)(34) + "Content-Type" + (char)(34) + " content=" + (char)(34) + "text/html; charset=utf-8" + (char)(34) + "> " +
            "<link href=" + (char)(34) + "http://code.google.com/apis/maps/documentation/javascript/examples/default.css" + (char)(34) + " rel=" + (char)(34) + "stylesheet" + (char)(34) + " type=" + (char)(34) + "text/css" + (char)(34) + " /> " +
            "<script type=" + (char)(34) + "text/javascript" + (char)(34) + " src=" + (char)(34) + "http://maps.google.com/maps/api/js?sensor=true&language=en" + (char)(34) + "></script>" +
            "<script  type=" + (char)(34) + "text/javascript" + (char)(34) + "> " + "\r\n" +
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
                                        "strokeColor: " + (char)(34) + "#FF0000" + (char)(34) + ", \r\n" +
                                        "strokeOpacity: 0.8," + "\r\n" +
                                        "strokeWeight: 2," + "\r\n" +
                                        "fillColor: " + (char)(34) + "#FF0000" + (char)(34) + ",\r\n" +
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

            retHTMLStr += "" +
            "function init() {" +
              "var map = new google.maps.Map(document.getElementById(" + (char)(34) + "mapcanvas" + (char)(34) + "), {scaleControl: true, zoomControl: true}); " + "\r\n" +
               "var geocoder = new google.maps.Geocoder();" + "\r\n" +
               "map.setCenter(center);" + "\r\n" +
               "map.setZoom(" + (MarkerList.Count==0?0:Zoom).ToString().Trim() + ");" + "\r\n" +
               "map.setMapTypeId(google.maps.MapTypeId.ROADMAP);" + "\r\n";


            foreach( GoogleMapMarker marker in MarkerList)
            {
            
                if(marker.Location.LongLat != null )
                {
                   //'  retHTMLStr += "var loc = new google.maps.LatLng(" + marker.Location.LongLat.ToString(LongLat.Format.LatLong) + ")" + "\r\n"
                    retHTMLStr += "createmarker(map, new google.maps.LatLng(" + marker.Location.LongLat.ToString(LongLat.Format.LatLong) + ")" +
                        ", '" + marker.Description.Replace("'", "' + " + (char)(34) + "'" + (char)(34) + " + '") + "', " +
                        marker.IconBounce.ToString().ToLower() + ", " + marker.SetAsCenter.ToString().ToLower() + ", '" + 
                        marker.ImageUrl + "', new google.maps.Size(32, 37) , new google.maps.Point(0,0) " + 
                        (marker.MarkerAnchorPoint == null? "": ", new google.maps.Point(" + marker.MarkerAnchorPoint.X.ToString() +
                        "," + marker.MarkerAnchorPoint.Y.ToString() + ")") +
                        ", null," + (marker.Radius == 0? "null": (marker.Radius * 1609.344).ToString()) + " );" + "\r\n";

                }

            }



            retHTMLStr += "}" + "\r\n";

            //create the footer stuff
            retHTMLStr += "" +
            "</script>" +
            "</head>" +
            "<body onload=" + (char)(34) + "init()" + (char)(34) + ">" +
            "<div id=" + (char)(34) + "mapcanvas" + (char)(34) + " style=" + (char)(34) + "width: " + (Width-20).ToString() + "px; height: " + Height + "px;" + (char)(34) + "></div>" +
            "</body>" +
            "</html>";

           // Console.WriteLine(retHTMLStr);
            return retHTMLStr;
        }

        private void GoogleMap_Resize(object sender, EventArgs e)
        {
            //reload the map
            Reload();

        }

    }
}
