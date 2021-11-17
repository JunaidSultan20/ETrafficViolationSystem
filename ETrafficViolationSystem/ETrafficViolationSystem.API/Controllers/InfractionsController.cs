using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Request;
using ETrafficViolationSystem.Entities.Request.QueryParameters;
using ETrafficViolationSystem.Entities.Response;
using ETrafficViolationSystem.Service.Interface;
using Microsoft.AspNetCore.Authorization;

namespace ETrafficViolationSystem.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class InfractionsController : ControllerBase
    {
        private readonly IInfractionsService _infractionsService;

        public InfractionsController(IInfractionsService infractionsService)
        {
            _infractionsService = infractionsService;
        }

        [ResponseCache(NoStore = false, Duration = 10, Location = ResponseCacheLocation.Any)]
        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<InfractionsDto>>>> GetInfractionsList([FromQuery] BaseQueryParameters queryParameters)
        {
            BaseResponse<IEnumerable<InfractionsDto>> response = await _infractionsService.GetInfractionsList(queryParameters);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound(response);
            return Ok(response);
        }

        [HttpGet("{id:int}", Name = "GetInfractionById")]
        public async Task<ActionResult<BaseResponse<InfractionsDto>>> GetById([FromRoute] int id)
        {
            BaseResponse<InfractionsDto> response = await _infractionsService.GetInfractionById(id);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<InfractionsDto>>> Add([FromBody] InfractionsInsertRequest request)
        {
            BaseResponse<InfractionsDto> response = await _infractionsService.Add(request.Infraction);
            if (response.StatusCode == HttpStatusCode.BadRequest)
                return BadRequest(response);
            return CreatedAtRoute("GetInfractionById", new { id = response.Result.Id }, response);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<BaseResponse<InfractionsDto>>> Update([FromRoute] int id,
            [FromBody] InfractionsUpdateRequest request)
        {
            BaseResponse<InfractionsDto> response = await _infractionsService.Update(request.Infraction, id);
            if (response.StatusCode == HttpStatusCode.BadRequest)
                return BadRequest(response);
            return StatusCode((int)HttpStatusCode.NoContent, response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<BaseResponse<object>>> Delete([FromRoute] int id)
        {
            BaseResponse<object> response = await _infractionsService.Delete(id);
            if (response.StatusCode == HttpStatusCode.BadRequest)
                return BadRequest(response);
            return StatusCode((int)HttpStatusCode.NoContent, response);
        }
    }
}