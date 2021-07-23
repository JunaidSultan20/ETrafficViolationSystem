using AutoMapper;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;

namespace ETrafficViolationSystem.Entities.Mappings
{
    public class RoleMappings : Profile
    {
        public RoleMappings()
        {
            CreateMap<RoleInsertDto, Roles>()
                .ForMember(destination => destination.Name, source =>
                    source.Condition(x => !string.IsNullOrEmpty(x.Name)));

            CreateMap<string, Roles>()
                .ForMember(destination => destination.Name, source => 
                    source.Condition(x => !string.IsNullOrEmpty(x)))
                .ForMember(destination => destination.NormalizedName, source => 
                    source.Condition(x => !string.IsNullOrEmpty(x.ToUpper())));
        }
    }
}