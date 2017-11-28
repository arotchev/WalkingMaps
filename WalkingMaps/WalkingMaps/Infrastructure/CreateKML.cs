using System;
using System.Linq;
using WalkingMaps.Services.Abstract;
using WalkingMaps.Services.ExportWalk;


namespace WalkingMaps.Infrastructure
{
    public static class CreateKML
    {
       
        private static WalkingMapsDBContext _context;


        public static void Create(IServiceProvider serviceProvider)
        {
            IExportWalk iExportWalk = new ExportWalk();

            _context = (WalkingMapsDBContext)serviceProvider.GetService(typeof(WalkingMapsDBContext));

            var data = iExportWalk.CreatePlacemarkCollection(_context.Sights.ToList());
            iExportWalk.SerializePlacemarkCollection(data);
          
        }
        
    }
}
