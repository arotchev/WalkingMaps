using System.Text;
using System.Xml.Serialization;

namespace WalkingMaps.Services.ExportWalk
{
    public class Location
    {
        private const string TOKEN = ",";

        public Location()
        {
            
        }

        [XmlIgnore()]
        public double Latitude { get; set; }

        [XmlIgnore()]
        public double Longitude { get; set; }
       

        [XmlElement("coordinates")]
        public string Coordinates
        {
            get
            {
                var sCoordinates = new StringBuilder();
                sCoordinates.Append(Longitude.ToString() + TOKEN);
                sCoordinates.Append(Latitude.ToString() + TOKEN);
                return sCoordinates.ToString();
            }
            set { }
        }
    }
}
