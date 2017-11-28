using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace WalkingMaps.Services.ExportWalk
{
    public class PlacemarkCollectionSerializer
    {
        private const string KML_NAME_SPACE = "http://earth.google.com/kml/2.2";

        public void Serialize(string fileName, PlacemarkCollectionWrapper placemarks)
        {
            var serializer = new XmlSerializer(typeof(PlacemarkCollectionWrapper),
                KML_NAME_SPACE);
            using (var stream = new FileStream(fileName, FileMode.Create))
            {

                XmlWriterSettings settings = new XmlWriterSettings() { Encoding = Encoding.Unicode };              

                using (var writer = XmlWriter.Create(stream, settings))
                {
                    var namespaces = new XmlSerializerNamespaces();
                    namespaces.Add(string.Empty, KML_NAME_SPACE);
                    serializer.Serialize(writer, placemarks, namespaces);
                }
            }
        }
    }
}
