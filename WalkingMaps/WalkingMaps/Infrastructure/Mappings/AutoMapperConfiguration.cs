using AutoMapper;
using WalkingMaps.Entities;

namespace WalkingMaps.Infrastructure.Mappings
{
    public class AutoMapperConfiguration
    {

        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<DomainToViewModelMappingProfile>();
            });

        }
    }
}
