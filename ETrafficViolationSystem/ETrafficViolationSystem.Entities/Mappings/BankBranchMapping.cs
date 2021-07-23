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

            CreateMap<BankBranchDto, BankBranch>()
                .ForMember(destination => destination.BranchCode,
                    source => source.Condition(x => x.BranchCode.HasValue))
                .ForMember(destination => destination.BranchTitle,
                    source => source.Condition(x => !string.IsNullOrEmpty(x.BranchTitle)))
                .ForMember(destination => destination.BankId,
                    source => source.Condition(x => x.BankId.HasValue))
                .ForMember(destination => destination.CityId,
                    source => source.Condition(x => x.CityId.HasValue))
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