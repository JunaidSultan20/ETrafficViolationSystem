using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Request.QueryParameters;
using ETrafficViolationSystem.Entities.Response;
using ETrafficViolationSystem.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ETrafficViolationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarMakeService _carMakeService;
        private readonly ICarModelService _carModelService;

        public CarsController(ICarMakeService carMakeService, ICarModelService carModelService)
        {
            _carMakeService = carMakeService;
            _carModelService = carModelService;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<CarMakeDto>>>> GetCarMakeList(
            [FromQuery] CarMakeQueryParameters parameters)
        {
            BaseResponse<IEnumerable<CarMakeDto>> response = await _carMakeService.GetCarMakeList();
            if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound(response);
            return Ok(response);
        }
    }
}