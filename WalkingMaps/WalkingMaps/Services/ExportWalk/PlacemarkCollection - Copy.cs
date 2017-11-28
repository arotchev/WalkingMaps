using System.Collections.Generic;
using System.Xml.Serialization;

namespace WalkingMaps.Services.ExportWalk
{
    [XmlRoot("kml")]
    public class PlacemarkCollection
    {
        public PlacemarkCollection()
        {
            Document = new List<Placemark>();
            Name = "All Sights";
        }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlArrayItem("Placemark")]
        public List<Placemark> Document { get; set; }

        public void Add(Placemark toAdd)
        {
            Document.Add(toAdd);
        }
    }
}
