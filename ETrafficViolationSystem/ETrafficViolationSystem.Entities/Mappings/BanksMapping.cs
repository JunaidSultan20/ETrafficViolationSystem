using System;
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

            CreateMap<Tuple<BanksInsertDto, int>, Banks>()
                .ForMember(destination => destination.Title, source =>
                    source.MapFrom(x => x.Item1.Title))

                .ForMember(destination => destination.ShortCode, source =>
                    source.MapFrom(x => x.Item1.ShortCode))

                .ForMember(destination => destination.IsActive, source =>
                    source.MapFrom(x => true))

                .ForMember(destination => destination.CreatedBy, source =>
                    source.MapFrom(x => x.Item2))

                .ForMember(destination => destination.CreatedDate, source =>
                    source.MapFrom(x => DateTime.Now));
        }
    }
}