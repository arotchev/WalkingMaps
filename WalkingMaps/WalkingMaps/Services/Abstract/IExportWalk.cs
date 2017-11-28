using System.Collections.Generic;
using WalkingMaps.Entities;
using WalkingMaps.Services.ExportWalk;

namespace WalkingMaps.Services.Abstract
{
    public interface IExportWalk
    {
        PlacemarkCollection CreatePlacemarkCollection(List<Sight> sights);
        void SerializePlacemarkCollection(PlacemarkCollection placemarks);
    }
}
