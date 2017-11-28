using System;
using System.Collections.Generic;
using WalkingMaps.Entities;
using WalkingMaps.Services.Abstract;


namespace WalkingMaps.Services.ExportWalk
{
    public class ExportWalk : IExportWalk
    {
        private const string DEFAULT_OUTPUT_FILE = "sights-with-remote-pics.kml";

        public PlacemarkCollection CreatePlacemarkCollection(List<Sight> sights)
        {
            var collection = new PlacemarkCollection();
            //foreach (var sight in sights)
            //{
            //    collection.Add(new Placemark(sight));
            //}
            collection.WalkName = "All Moscow Sights (remote pics)";

            foreach (var sight in sights)
            {
                collection.Placemarks.Add(new Placemark(sight));
            }

            return collection;
        }

        public void SerializePlacemarkCollection(PlacemarkCollection placemarks)
        {
            var serializer = new PlacemarkCollectionSerializer();
            var wrapper = new PlacemarkCollectionWrapper() { Document = placemarks};
            serializer.Serialize(DEFAULT_OUTPUT_FILE, wrapper);
        }
    }
}
