using System.Collections.Generic;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;
using ETrafficViolationSystem.Entities.Response;

namespace ETrafficViolationSystem.Service.Interface
{
    public interface IStatesService
    {
        Task<IEnumerable<States>> GetStatesList();

        Task<BaseResponse<IEnumerable<StatesDto>>> GetByCountryId(int countryId);
        
        Task<BaseResponse<StatesDto>> GetById(int id);
    }
}