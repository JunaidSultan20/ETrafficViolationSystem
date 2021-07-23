using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Request;
using ETrafficViolationSystem.Entities.Response;
using ETrafficViolationSystem.Service.Implementation;
using ETrafficViolationSystem.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace ETrafficViolationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<BaseResponse<LoginDto>>> Login(AuthenticationRequest request)
        {
            LoginDto loginDto = await _accountService.Login(request.AuthenticationDto);
            if (loginDto == null)
                return Unauthorized(new BaseResponse<LoginDto>(HttpStatusCode.Unauthorized, "Unauthorized Attempt."));
            return Ok(new BaseResponse<LoginDto>(HttpStatusCode.OK, "Access Token Generated.", loginDto));
        }

        [HttpPost("register")]
        public async Task<ActionResult<BaseResponse<UsersDto>>> Register([FromBody] RegistrationRequest request)
        {
            BaseResponse<UsersDto> response = await _accountService.Register(request.RegistrationDto);
            if (response.StatusCode == HttpStatusCode.BadRequest)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<BaseResponse<RefreshTokenDto>>> RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
        {
            BaseResponse<RefreshTokenDto> response = await _accountService.RefreshToken(refreshTokenDto);
            if (response.StatusCode == HttpStatusCode.BadRequest)
                return BadRequest(response);
            return Ok(response);
        }
    }
}