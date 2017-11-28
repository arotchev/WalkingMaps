using Chilkat;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WalkingMaps.Entities;

namespace WalkingMaps.Services.ExportWalk
{
    public class Placemark
    {
        public Placemark(Sight sight)
        {
            //string _image = "<img src=\"http://192.168.1.5/" + sight.PhotoUri + "\"/><br><br>";
            string _image = "<img src=\"https://uwalks.000webhostapp.com/photos/" + sight.PhotoUri + "\"/><br><br>";
            
            string _description = sight.Description != null ? PrepDescription(sight.Description) : sight.Description;

            XmlDocument doc = new XmlDocument();           

            //Create a CData section.
            XmlCDataSection CData;
            CData = doc.CreateCDataSection(_image + _description);

            Name = sight.Name;
            //Description = "<![CDATA[" + _image + _description + "]]>";
            Description = CData;
            Point = new Location()
            {
                Longitude = Double.Parse(sight.Longitude.ToString(),
                    CultureInfo.InvariantCulture),
                Latitude = Double.Parse(sight.Latitude.ToString(),
                    CultureInfo.InvariantCulture),
            };
        }

        private string PrepDescription(string _temp)
        {

            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            return regex.Replace(_temp, " ").Replace("\r\n", "").Replace("\"", "'").Replace("\t","").Replace("&nbsp","");

        }

        public Placemark()
        { }

        [XmlElement("name")]
        public string Name { get; set; }

        //[XmlElement("description")]
        //public string Description { get; set; }

        [XmlElement("description", typeof(XmlCDataSection))]
        public XmlCDataSection Description { get; set; }

        [XmlElement("Point")]
        public Location Point { get; set; }
    }
}
