using System;
using AutoMapper;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;

namespace ETrafficViolationSystem.Entities.Mappings
{
    public class StatesMapping : Profile
    {
        /// <summary>
        /// States & StatesDto Mapping
        /// </summary>
        public StatesMapping()
        {
            //Mapping For States -> StatesDto
            CreateMap<States, StatesDto>()
                .ForMember(destination => destination.StateId,
                    source => source.MapFrom(x => x.StateId))

                .ForMember(destination => destination.StateTitle,
                    source => source.MapFrom(x => x.StateTitle))

                ;

            //Mapping For StatesInsertDto -> States
            CreateMap<Tuple<StatesInsertDto, int>, States>()
                .ForMember(destination => destination.StateTitle, source =>
                    source.MapFrom(x => x.Item1.StateTitle))

                .ForMember(destination => destination.CountryId, source =>
                    source.MapFrom(x => x.Item1.StateTitle))

                .ForMember(destination => destination.IsActive, source =>
                    source.MapFrom(x => true))

                .ForMember(destination => destination.CreatedBy, source =>
                    source.MapFrom(x => x.Item2))

                .ForMember(destination => destination.CreatedDate, source =>
                    source.MapFrom(x => DateTime.Now));
        }
    }
}