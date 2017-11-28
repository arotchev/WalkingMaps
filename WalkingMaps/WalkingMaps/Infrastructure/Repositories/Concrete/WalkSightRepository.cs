using System.Collections.Generic;
using WalkingMaps.Entities;
using WalkingMaps.Infrastructure.Repositories.Abstract;

namespace WalkingMaps.Infrastructure.Repositories.Concrete
{
    public class WalkSightRepository : EntityBaseRepository<WalkSight>, IWalkSightRepository
    {
     
        public WalkSightRepository(WalkingMapsDBContext context, ISightRepository sightRepository)
            : base(context)
        {   }

      
    }
}
