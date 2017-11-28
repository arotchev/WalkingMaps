using System.Collections.Generic;
using System.Xml.Serialization;

namespace WalkingMaps.Services.ExportWalk
{
   
    public class PlacemarkCollection
    {
        public PlacemarkCollection()
        {           
            Placemarks = new List<Placemark>();
        }

        [XmlElement("name")]
        public string WalkName { get; set; }

        [XmlArrayItem("Placemark")]
        public List<Placemark> Placemarks { get; set; }

        public void Add(Placemark toAdd)
        {
            Placemarks.Add(toAdd);
        }

    }
}
