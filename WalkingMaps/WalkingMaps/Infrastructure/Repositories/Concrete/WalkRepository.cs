using System.Collections.Generic;
using WalkingMaps.Entities;
using WalkingMaps.Infrastructure.Repositories.Abstract;

namespace WalkingMaps.Infrastructure.Repositories.Concrete
{
    public class WalkRepository : EntityBaseRepository<Walk>, IWalkRepository
    {        
        public WalkRepository(WalkingMapsDBContext context, ISightRepository sightRepository)
            : base(context)
        {   }

       
    }
}
