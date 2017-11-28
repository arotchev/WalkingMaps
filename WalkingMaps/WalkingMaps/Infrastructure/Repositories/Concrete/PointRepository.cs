using WalkingMaps.Entities;
using WalkingMaps.Infrastructure.Repositories.Abstract;

namespace WalkingMaps.Infrastructure.Repositories.Concrete
{
    public class PointRepository : EntityBaseRepository<Point>, IPointRepository
    {
        public PointRepository(WalkingMapsDBContext context)
            : base(context)
        { }
    }
}