using System.Collections.Generic;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Request.QueryParameters;
using ETrafficViolationSystem.Entities.Response;

namespace ETrafficViolationSystem.Service.Interface
{
    public interface IInfractionsService
    {
        Task<BaseResponse<IEnumerable<InfractionsDto>>> GetInfractionsList(PaginationQueryParameters paginationQueryParameters);

        Task<BaseResponse<InfractionsDto>> GetInfractionById(int id);

        Task<BaseResponse<IEnumerable<InfractionsDto>>> GetByPenalty(int penalty);

        Task<BaseResponse<IEnumerable<InfractionsDto>>> GetByPoints(int points);

        Task<BaseResponse<InfractionsDto>> Add(InfractionsInsertDto infractionsInsertDto);

        Task<BaseResponse<InfractionsDto>> Update(InfractionsUpdateDto infractionsUpdateDto, int id);

        Task<BaseResponse<object>> Delete(int id);
    }
}