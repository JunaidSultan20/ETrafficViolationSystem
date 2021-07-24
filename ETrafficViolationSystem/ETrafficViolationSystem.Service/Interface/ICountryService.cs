using System.Collections.Generic;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Response;

namespace ETrafficViolationSystem.Service.Interface
{
    public interface ICountryService
    {
        Task<BaseResponse<IEnumerable<CountryDto>>> GetCountryList();

        Task<BaseResponse<CountryDto>> GetById(int id);
    }
}