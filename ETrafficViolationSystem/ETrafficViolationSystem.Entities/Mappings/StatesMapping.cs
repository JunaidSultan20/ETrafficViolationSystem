using AutoMapper;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;

namespace ETrafficViolationSystem.Entities.Mappings
{
    public class StatesMapping : Profile
    {
        public StatesMapping()
        {
            CreateMap<States, StatesDto>();
        }
    }
}