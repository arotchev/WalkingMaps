using WalkingMaps.Entities;
using WalkingMaps.Infrastructure.Repositories.Abstract;

namespace WalkingMaps.Infrastructure.Repositories.Concrete
{
    public class SightRepository : EntityBaseRepository<Sight>, ISightRepository
    {
        public SightRepository(WalkingMapsDBContext context)
            : base(context)
        { }
    }
}