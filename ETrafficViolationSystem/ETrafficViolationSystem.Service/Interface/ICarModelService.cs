using System.Collections.Generic;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Response;

namespace ETrafficViolationSystem.Service.Interface
{
    public interface ICarModelService
    {
        Task<BaseResponse<IEnumerable<CarModelDto>>> GetModelsList();

        Task<BaseResponse<IEnumerable<CarModelDto>>> GetByTitle(string title);

        Task<BaseResponse<IEnumerable<CarModelDto>>> GetByYear(int year);

        Task<BaseResponse<IEnumerable<CarModelDto>>> GetByMakeId(short id);

        Task<BaseResponse<CarModelDto>> GetById(string id);
    }
}