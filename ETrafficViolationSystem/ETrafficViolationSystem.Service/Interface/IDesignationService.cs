using System.Collections.Generic;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Response;

namespace ETrafficViolationSystem.Service.Interface
{
    public interface IDesignationService
    {
        Task<BaseResponse<DesignationDto>> GetByTitle(string title);

        Task<BaseResponse<IEnumerable<DesignationDto>>> GetDesignationList();

        Task<BaseResponse<IEnumerable<DesignationDto>>> GetReportingDesignation(int reportsTo);
    }
}