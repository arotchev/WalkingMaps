using AutoMapper;
using WalkingMaps.Entities;
using WalkingMaps.ViewModels;

namespace WalkingMaps.Infrastructure.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public DomainToViewModelMappingProfile()
        {
            //CreateMap<Sight, SightViewModel>()
            //   .ForMember(vm => vm.PhotoUri, map => map.MapFrom(s => "/images/" + s.PhotoUri));

    

            CreateMap<Walk, WalkViewModel>()
                    .ForMember(vm => vm.TotalSights, map => map.MapFrom(a => a.WalkSights.Count));


            CreateMap<WalkSight, WalkSightViewModel>()
             .ForMember(vm => vm.WalkName, map => map.MapFrom(s => s.Walk.Name))
             .ForMember(vm => vm.Address, map => map.MapFrom(s => s.Sight.Address))
             .ForMember(vm => vm.Name, map => map.MapFrom(s => s.Sight.Name))
             .ForMember(vm => vm.Description, map => map.MapFrom(s => s.Sight.Description))
             .ForMember(vm => vm.PhotoUri, map => map.MapFrom(p => "/images/" + p.Sight.PhotoUri));
        }        
    }
}
