using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;
using ETrafficViolationSystem.Entities.Response;
using ETrafficViolationSystem.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ETrafficViolationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStatesService _statesService;
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public StatesController(IStatesService statesService, ICityService cityService, IMapper mapper)
        {
            _statesService = statesService;
            _cityService = cityService;
            _mapper = mapper;
        }

        /// <summary>
        /// Endpoint For Fetching The List Of States
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<StatesDto>>>> GetStatesList()
        {
            IEnumerable<States> result = await _statesService.GetStatesList();
            if (result == null)
                return NotFound(new BaseResponse<IEnumerable<StatesDto>>(HttpStatusCode.NotFound, null));
            return Ok(new BaseResponse<IEnumerable<StatesDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<StatesDto>>(result), result.Count()));
        }
        
        /// <summary>
        /// Endpoint For Fetching The List Of States By Country Id
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>

        [HttpGet("states/{countryId:int}")]
        public async Task<ActionResult<BaseResponse<IEnumerable<StatesDto>>>> GetByCountryId(
            [FromRoute] int countryId)
        {
            BaseResponse<IEnumerable<StatesDto>> response = await _statesService.GetByCountryId(countryId);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound(response);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint For Fetching The State By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<BaseResponse<StatesDto>>> GetStateById([FromRoute] int id)
        {
            BaseResponse<StatesDto> response = await _statesService.GetById(id);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound(response);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint For Fetching The City List By State Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}/cities")]
        public async Task<ActionResult<BaseResponse<IEnumerable<CityDto>>>> GetCitiesByStateId([FromRoute] int id)
        {
            BaseResponse<IEnumerable<CityDto>> response = await _cityService.GetByStateId(id);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound(response);
            return Ok(response);
        }
    }
}