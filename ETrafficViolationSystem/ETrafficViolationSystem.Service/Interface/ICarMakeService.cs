using System.Collections.Generic;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Response;

namespace ETrafficViolationSystem.Service.Interface
{
    public interface ICarMakeService
    {
        Task<BaseResponse<IEnumerable<CarMakeDto>>> GetCarMakeList();

        Task<BaseResponse<IEnumerable<CarMakeDto>>> GetByOriginCountry(int id);
    }
}