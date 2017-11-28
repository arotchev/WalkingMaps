using WalkingMaps.Entities;
using WalkingMaps.Infrastructure.Repositories.Abstract;

namespace WalkingMaps.Infrastructure.Repositories.Concrete
{
    public class RouteRepository : EntityBaseRepository<Route>, IRouteRepository
    {
        public RouteRepository(WalkingMapsDBContext context)
            : base(context)
        { }
    }
}
