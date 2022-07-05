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
            CreateMap<Roles, RolesDto>()
                .ForMember(destination => destination.RoleId, source =>
                    source.MapFrom(x => x.Id))

                .ForMember(destination => destination.RoleName, source =>
                    source.MapFrom(x => x.Name))

                .ForMember(destination => destination.IsActive, source =>
                    source.MapFrom(x => x.IsActive))

                .ForMember(destination => destination.CreatedBy, source =>
                    source.MapFrom(x => x.CreatedBy))

                .ForMember(destination => destination.CreatedDate, source =>
                    source.MapFrom(x => x.CreatedDate))

                .ForMember(destination => destination.UpdatedBy, source =>
                    source.MapFrom(x => x.UpdatedBy))

                .ForMember(destination => destination.UpdatedDate, source =>
                    source.MapFrom(x => x.UpdatedDate));

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