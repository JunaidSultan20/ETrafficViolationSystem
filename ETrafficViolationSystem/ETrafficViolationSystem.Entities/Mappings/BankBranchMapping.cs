using System;
using AutoMapper;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;

namespace ETrafficViolationSystem.Entities.Mappings
{
    public class BankBranchMapping : Profile
    {
        public BankBranchMapping()
        {
            CreateMap<BankBranch, BankBranchDto>();

            CreateMap<Tuple<BankBranchInsertDto, int>, BankBranch>()
                .ForMember(destination => destination.BranchCode,
                    source => 
                        source.MapFrom(x => x.Item1.BranchCode))
                
                .ForMember(destination => destination.BranchTitle,
                    source => 
                        source.MapFrom(x => x.Item1.BranchTitle))
                
                .ForMember(destination => destination.BankId,
                    source => 
                        source.MapFrom(x => x.Item1.BankId))
                
                .ForMember(destination => destination.CityId,
                    source => 
                        source.MapFrom(x => x.Item1.CityId))
                
                .ForMember(destination => destination.IsActive,
                    source => 
                        source.MapFrom(x => true))
                
                .ForMember(destination => destination.CreatedBy,
                    source => 
                        source.MapFrom(x => x.Item2))
                
                .ForMember(destination => destination.CreatedDate,
                    source => 
                        source.MapFrom(x => DateTime.Now));
        }
    }
}