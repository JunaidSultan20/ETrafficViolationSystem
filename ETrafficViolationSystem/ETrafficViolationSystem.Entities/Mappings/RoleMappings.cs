using System;
using AutoMapper;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;

namespace ETrafficViolationSystem.Entities.Mappings
{
    public class RoleMappings : Profile
    {
        public RoleMappings()
        {
            CreateMap<Tuple<RoleInsertDto, int>, Roles>()
                .ForMember(destination => destination.Name, source =>
                    source.Condition(x => !string.IsNullOrEmpty(x.Item1.Name)))

                .ForMember(destination => destination.NormalizedName, source =>
                    source.MapFrom(x => x.Item1.Name.ToUpper()))

                .ForMember(destination => destination.IsActive, source =>
                    source.MapFrom(x => true))

                .ForMember(destination => destination.CreatedBy, source =>
                    source.MapFrom(x => x.Item2))

                .ForMember(destination => destination.CreatedDate, source =>
                    source.MapFrom(x => DateTime.Now));
        }
    }
}