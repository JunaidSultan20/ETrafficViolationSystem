using AutoMapper;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;

namespace ETrafficViolationSystem.Entities.Mappings
{
    public class CityMapping : Profile
    {
        public CityMapping()
        {
            CreateMap<City, CityDto>();
        }
    }
}