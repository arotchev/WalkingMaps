using System.Collections.Generic;
using WalkingMaps.Entities;

namespace WalkingMaps.Infrastructure.Repositories.Abstract
{
    public interface ISightRepository : IEntityBaseRepository<Sight> { }

    public interface ILoggingRepository : IEntityBaseRepository<Error> { }

    public interface IPointRepository : IEntityBaseRepository<Point> { }

    public interface IWalkRepository : IEntityBaseRepository<Walk> { }

    public interface IWalkSightRepository : IEntityBaseRepository<WalkSight> { }

    public interface IRouteRepository : IEntityBaseRepository<Route> { }
}
