using System.Collections.Generic;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Response;

namespace ETrafficViolationSystem.Service.Interface
{
    public interface IBankBranchService
    {
        Task<BaseResponse<IEnumerable<BankBranchDto>>> GetBranchesByBankId(int id);

        Task<BaseResponse<IEnumerable<BankBranchDto>>> GetByBankShortCode(string code);

        Task<BaseResponse<IEnumerable<BankBranchDto>>> GetByCityId(int id);

        Task<BaseResponse<BankBranchDto>> GetByTitle(string title);

        Task<BaseResponse<BankBranchDto>> GetByBranchCode(int code);
    }
}