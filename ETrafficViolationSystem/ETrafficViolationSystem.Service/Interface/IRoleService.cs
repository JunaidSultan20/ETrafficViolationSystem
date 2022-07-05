using System.Collections.Generic;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Response;

namespace ETrafficViolationSystem.Service.Interface
{
    public interface IRoleService
    {
        Task<BaseResponse<IEnumerable<RolesDto>>> Get();

        Task<BaseResponse<RolesDto>> GetById(int id);

        Task<BaseResponse<RolesDto>> Add(RoleInsertDto roleInsertDto);
    }
}