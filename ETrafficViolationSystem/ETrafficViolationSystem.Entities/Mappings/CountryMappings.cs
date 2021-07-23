using System;
using AutoMapper;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;

namespace ETrafficViolationSystem.Entities.Mappings
{
    public class CountryMappings : Profile
    {
        public CountryMappings()
        {
            // Maps Country -> CountryDto
            CreateMap<Country, CountryDto>()
                .ForMember(destination => destination.Id,
                    source => source.MapFrom(x => x.CountryId))
                .ForMember(destination => destination.Title,
                    source => source.MapFrom(x => x.CountryTitle))
                .ForMember(destination => destination.ShortCode,
                    source => source.MapFrom(x => x.ShortCode))
                .ForMember(destination => destination.CountryCode,
                    source => source.MapFrom(x => x.CountryCode))
                .ForMember(destination => destination.DialingCode,
                    source => source.MapFrom(x => x.DialingCode));

            CreateMap<CountryUpdateDto, Country>()
                .ForMember(destination => destination.CountryTitle,
                    source => source.Condition(x =>
                        !string.IsNullOrEmpty(x.Title)))
                .ForMember(destination => destination.ShortCode, source =>
                    source.Condition(x => !string.IsNullOrEmpty(x.ShortCode)))
                .ForMember(destination => destination.CountryCode, source =>
                    source.Condition(x => !string.IsNullOrEmpty(x.CountryCode)))
                .ForMember(destination => destination.DialingCode, source =>
                    source.Condition(x => !string.IsNullOrEmpty(x.DialingCode)))
                .ForMember(destination => destination.IsActive, source =>
                    source.Condition(x => x.IsActive != null))
                .ForMember(destination => destination.UpdatedBy, source => 
                    source.Condition(x => x.UpdatedBy != null || x.UpdatedBy > 0))
                .ForMember(destination => destination.UpdatedDate, source =>
                    source.Condition(x => x.UpdatedDate != null));
        }
    }
}