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
            CreateMap<Infractions, InfractionsDto>()
                .ForMember(destination => destination.Id, source =>
                    source.MapFrom(x => x.InfractionId))

                .ForMember(destination => destination.Description, source =>
                    source.MapFrom(x => x.Description))

                .ForMember(destination => destination.Penalty, source =>
                    source.MapFrom(x => x.Penalty))

                .ForMember(destination => destination.Points, source =>
                    source.MapFrom(x => x.Points));

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

            //Mapping For InfractionsUpdateDto -> Infractions
            CreateMap<Tuple<InfractionsUpdateDto, int>, Infractions>()
                .ForMember(destination => destination.Description, 
                    source => 
                        source.Condition(x => x.Item1.Description is { } or ""))

                .ForMember(destination => destination.Penalty, 
                    source =>
                    source.Condition(x => x.Item1.Penalty is { } or > 0))

                .ForMember(destination => destination.Points, 
                    source =>
                    source.Condition(x => x.Item1.Points is { } or > 0))

                .ForMember(destination => destination.IsActive, 
                    source => source.Ignore())

                .ForMember(destination => destination.CreatedBy, 
                    source => source.Ignore())

                .ForMember(destination => destination.CreatedDate, 
                    source => source.Ignore())

                .ForMember(destination => destination.UpdatedBy, 
                    source => 
                        source.MapFrom(x => x.Item2))

                .ForMember(destination => destination.UpdatedDate, 
                    source =>
                    source.MapFrom(x => DateTime.Now));
        }
    }
}