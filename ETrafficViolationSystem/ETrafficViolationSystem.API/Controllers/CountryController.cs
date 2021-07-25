using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Response;
using ETrafficViolationSystem.Service.Interface;
using Microsoft.AspNetCore.Authorization;

namespace ETrafficViolationSystem.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<CountryDto>>>> GetCountryList()
        {
            BaseResponse<IEnumerable<CountryDto>> response = await _countryService.GetCountryList();
            if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound(response);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BaseResponse<CountryDto>>> GetById([FromRoute] int id)
        {
            BaseResponse<CountryDto> response = await _countryService.GetById(id);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound(response);
            return Ok(response);
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            int a = 110;
            a = a / 0;
            return Ok();
        }
    }
}