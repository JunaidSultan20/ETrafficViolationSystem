using System;
using AutoMapper;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Mappings.Tuples;
using ETrafficViolationSystem.Entities.Models;

namespace ETrafficViolationSystem.Entities.Mappings
{
    public class RoleMappings : Profile
    {
        public RoleMappings()
        {
            CreateMap<RoleInsertDtoTuple, Roles>()
                .ForMember(destination => destination.Name, source =>
                    source.Condition(x => !string.IsNullOrEmpty(x.RoleInsertDto.Name)))

                .ForMember(destination => destination.NormalizedName, source =>
                    source.MapFrom(x => x.RoleInsertDto.Name.ToUpper()))

                .ForMember(destination => destination.IsActive, source =>
                    source.MapFrom(x => true))

                .ForMember(destination => destination.CreatedBy, source =>
                    source.MapFrom(x => x.UserId))

                .ForMember(destination => destination.CreatedDate, source =>
                    source.MapFrom(x => DateTime.Now))

                .IncludeBase<RoleInsertDtoTuple, BaseInsertDto>();
        }
    }
}