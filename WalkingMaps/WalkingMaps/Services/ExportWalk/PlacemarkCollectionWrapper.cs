using System.Xml.Serialization;

namespace WalkingMaps.Services.ExportWalk
{
    [XmlRoot("kml")]
    public class PlacemarkCollectionWrapper
    {
        public PlacemarkCollectionWrapper()
        {           
        }        

        public PlacemarkCollection Document { get; set; }


    }
}
