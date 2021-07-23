using AutoMapper;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;

namespace ETrafficViolationSystem.Entities.Mappings
{
    public class BanksMapping : Profile
    {
        public BanksMapping()
        {
            CreateMap<Banks, BanksDto>();

            CreateMap<BanksDto, Banks>()
                .ForMember(destination => destination.Title,
                    source => source.Condition(x => !string.IsNullOrEmpty(x.Title)))
                .ForMember(destination => destination.ShortCode,
                    source => source.Condition(x => !string.IsNullOrEmpty(x.ShortCode)))
                .ForMember(destination => destination.IsActive,
                    source => source.Condition(x => x.IsActive.HasValue))
                .ForMember(destination => destination.CreatedBy,
                    source => source.Condition(x => x.CreatedBy.HasValue))
                .ForMember(destination => destination.CreatedDate,
                    source => source.Condition(x => x.CreatedDate.HasValue))
                .ForMember(destination => destination.UpdatedBy,
                    source => source.Condition(x => x.UpdatedBy.HasValue))
                .ForMember(destination => destination.UpdatedDate,
                    source => source.Condition(x => x.UpdatedDate.HasValue));
        }
    }
}