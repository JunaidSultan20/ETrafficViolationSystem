using AutoMapper;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;

namespace ETrafficViolationSystem.Entities.Mappings
{
    public class CountryMapping : Profile
    {
        public CountryMapping()
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
        }
    }
}