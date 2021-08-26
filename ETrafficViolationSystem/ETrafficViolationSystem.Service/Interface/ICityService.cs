using System.Collections.Generic;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Response;

namespace ETrafficViolationSystem.Service.Interface
{
    public interface ICityService
    {
        Task<BaseResponse<CityDto>> GetById(int id);

        Task<BaseResponse<CityDto>> GetByTitle(string title);

        Task<BaseResponse<IEnumerable<CityDto>>> GetByPostalCode(int postalCode);

        Task<BaseResponse<IEnumerable<CityDto>>> GetByStateId(int stateId);

        Task<BaseResponse<IEnumerable<CityDto>>> GetByCountryId(int countryId);
    }
}