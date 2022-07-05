using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;
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
        /// Endpoint For Getting The List of Roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<RolesDto>>>> GetRoles()
        {
            BaseResponse<IEnumerable<RolesDto>> response = await _roleService.Get();
            if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound(response);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint For Fetching The Role By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetById")]
        public async Task<ActionResult<BaseResponse<RolesDto>>> GetById([FromRoute] int id)
        {
            BaseResponse<RolesDto> response = await _roleService.GetById(id);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound(response);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint For Adding The New Role
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BaseResponse<RolesDto>>> Add([FromBody] RoleInsertRequest request)
        {
            BaseResponse<RolesDto> response = await _roleService.Add(request.Role);
            if (response.StatusCode == HttpStatusCode.Created)
                return CreatedAtRoute("GetById", new { id = response.Result.RoleId }, response);
            return Ok();
        }
    }
}
