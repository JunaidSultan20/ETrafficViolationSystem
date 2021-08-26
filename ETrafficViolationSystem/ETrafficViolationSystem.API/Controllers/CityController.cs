using System.Net;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Response;
using ETrafficViolationSystem.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ETrafficViolationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BaseResponse<CityDto>>> GetById([FromRoute] int id)
        {
            BaseResponse<CityDto> response = await _cityService.GetById(id);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound(response);
            return Ok(response);
        }

        [HttpGet("{title:alpha}")]
        public async Task<ActionResult<BaseResponse<CityDto>>> GetByTitle([FromRoute] string title)
        {
            BaseResponse<CityDto> response = await _cityService.GetByTitle(title);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound(response);
            return Ok(response);
        }
    }
}