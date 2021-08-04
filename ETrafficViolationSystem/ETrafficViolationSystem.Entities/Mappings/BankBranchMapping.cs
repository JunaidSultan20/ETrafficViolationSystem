using AutoMapper;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Mappings.InsertTuples;
using ETrafficViolationSystem.Entities.Models;

namespace ETrafficViolationSystem.Entities.Mappings
{
    public class BankBranchMapping : Profile
    {
        public BankBranchMapping()
        {
            CreateMap<BankBranch, BankBranchDto>();

            CreateMap<BankBranchInsertDtoTuple, BankBranch>()
                .ForMember(destination => destination.BranchCode,
                    source => 
                        source.MapFrom(x => x.BankBranchDto.BranchCode))
                
                .ForMember(destination => destination.BranchTitle,
                    source => 
                        source.MapFrom(x => x.BankBranchDto.BranchTitle))
                
                .ForMember(destination => destination.BankId,
                    source => 
                        source.MapFrom(x => x.BankBranchDto.BankId))
                
                .ForMember(destination => destination.CityId,
                    source => 
                        source.MapFrom(x => x.BankBranchDto.CityId))
                
                .ForMember(destination => destination.IsActive,
                    source => 
                        source.MapFrom(x => x.BankBranchDto.IsActive))
                
                .ForMember(destination => destination.CreatedBy,
                    source => 
                        source.MapFrom(x => x.BankBranchDto.CreatedBy))
                
                .ForMember(destination => destination.CreatedDate,
                    source => 
                        source.MapFrom(x => x.BankBranchDto.CreatedDate));
        }
    }
}