using System.Collections.Generic;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Response;

namespace ETrafficViolationSystem.Service.Interface
{
    public interface IBankService
    {
        Task<BaseResponse<IEnumerable<BanksDto>>> GetBanksList();

        Task<BaseResponse<IEnumerable<BanksDto>>> GetBanksByCityId(int id);

        Task<BaseResponse<BanksDto>> GetById(int id);

        Task<BaseResponse<BanksDto>> GetByTitle(string title);

        Task<BaseResponse<BanksDto>> GetByShortCode(string code);
    }
}