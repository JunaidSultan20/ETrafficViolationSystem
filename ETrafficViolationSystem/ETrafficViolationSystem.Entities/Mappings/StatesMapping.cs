using System;
using AutoMapper;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Mappings.InsertTuples;
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
            CreateMap<States, StatesDto>();

            //Mapping For StatesInsertDto -> States
            CreateMap<StateInsertMappingTuple, States>()
                .ForMember(destination => destination.StateTitle, source =>
                    source.MapFrom(x => x.StatesInsertDto.StateTitle))

                .ForMember(destination => destination.CountryId, source =>
                    source.MapFrom(x => x.StatesInsertDto.StateTitle))

                .ForMember(destination => destination.IsActive, source =>
                    source.MapFrom(x => true))

                .ForMember(destination => destination.CreatedBy, source =>
                    source.MapFrom(x => x.UserId))

                .ForMember(destination => destination.CreatedDate, source =>
                    source.MapFrom(x => DateTime.Now));
        }
    }
}