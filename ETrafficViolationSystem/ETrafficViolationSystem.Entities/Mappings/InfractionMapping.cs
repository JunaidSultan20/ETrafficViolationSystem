using System;
using AutoMapper;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;

namespace ETrafficViolationSystem.Entities.Mappings
{
    public class InfractionMapping : Profile
    {
        public InfractionMapping()
        {
            //Mapping For Infractions -> InfractionsDto
            CreateMap<Infractions, InfractionsDto>();

            //Mapping For InfractionsInsertDto -> Infractions
            CreateMap<Tuple<InfractionsInsertDto, int>, Infractions>()
                .ForMember(destination => destination.Description, source => 
                    source.MapFrom(x => x.Item1.Description))
                
                .ForMember(destination => destination.Penalty, source => 
                    source.MapFrom(x => x.Item1.Penalty))
                
                .ForMember(destination => destination.Points, source => 
                    source.MapFrom(x => x.Item1.Points))
                
                .ForMember(destination => destination.IsActive, source => 
                    source.MapFrom(x => true))
                
                .ForMember(destination => destination.CreatedBy, source => 
                    source.MapFrom(x => x.Item2))
                
                .ForMember(destination => destination.CreatedDate, source => 
                    source.MapFrom(x => DateTime.Now));
        }
    }
}