using WalkingMaps.Entities;
using WalkingMaps.Infrastructure.Repositories.Abstract;

namespace WalkingMaps.Infrastructure.Repositories.Concrete
{
    public class LoggingRepository : EntityBaseRepository<Error>, ILoggingRepository
    {
        public LoggingRepository(WalkingMapsDBContext context)
            : base(context)
        { }

        public override void Commit()
        {
            //we don’t want to get an exception when logging errors.
            try
            {
                base.Commit();
            }
            catch { }
        }
    }
}
