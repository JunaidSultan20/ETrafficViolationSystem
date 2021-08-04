using System.Collections.Generic;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Response;

namespace ETrafficViolationSystem.Service.Interface
{
    public interface IInfractionsService
    {
        Task<BaseResponse<IEnumerable<InfractionsDto>>> GetInfractionsList();

        Task<BaseResponse<InfractionsDto>> GetInfractionById(int id);
    }
}