using AutoMapper;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;

namespace ETrafficViolationSystem.Entities.Mappings
{
    public class InfractionMapping : Profile
    {
        public InfractionMapping()
        {
            CreateMap<Infractions, InfractionsDto>();

            CreateMap<InfractionsInsertDto, Infractions>()
                .ForMember(destination => destination.Description,
                    source => source.Condition(x =>
                        !string.IsNullOrEmpty(x.Description)))
                .ForMember(destination => destination.Penalty,
                    source => source.Condition(x =>
                        x.Penalty.HasValue))
                .ForMember(destination => destination.Points,
                    source => source.Condition(x =>
                        x.Penalty.HasValue));
        }
    }
}