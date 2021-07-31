using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Request;
using ETrafficViolationSystem.Entities.Response;
using ETrafficViolationSystem.Service.Interface;

namespace ETrafficViolationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Endpoint For Adding The New Role
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BaseResponse<RolesDto>>> Add([FromBody] RoleInsertRequest request)
        {
            await _roleService.Add(request.Role);
            return Ok();
        }
    }
}
