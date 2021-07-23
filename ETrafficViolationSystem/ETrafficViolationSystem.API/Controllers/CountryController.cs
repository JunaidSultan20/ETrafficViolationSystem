using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;
using ETrafficViolationSystem.Entities.Response;
using ETrafficViolationSystem.Service.Interface;

namespace ETrafficViolationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<CountryDto>>>> GetCountryList()
        {
            IEnumerable<Country> result = await _countryService.GetCountryList();
            if (result == null)
                return Ok(new BaseResponse<IEnumerable<CountryDto>>(HttpStatusCode.NotFound, null));
            return Ok(new BaseResponse<IEnumerable<CountryDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<CountryDto>>(result), result.Count()));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BaseResponse<CountryDto>>> GetById([FromRoute] int id)
        {
            Country result = await _countryService.GetById(id);
            if (result == null)
                return NotFound(new BaseResponse<CountryDto>(HttpStatusCode.NotFound, null));
            return Ok(new BaseResponse<CountryDto>(HttpStatusCode.OK, null, _mapper.Map<CountryDto>(result), 1));
        }
    }
}