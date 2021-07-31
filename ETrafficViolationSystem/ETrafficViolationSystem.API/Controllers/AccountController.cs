using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Request;
using ETrafficViolationSystem.Entities.Response;
using ETrafficViolationSystem.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ETrafficViolationSystem.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        
        /// <summary>
        /// Endpoint For Authenticating The User Credentials
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<BaseResponse<LoginDto>>> Login([FromBody] AuthenticationRequest request)
        {
            BaseResponse<LoginDto> response = await _accountService.Login(request.AuthenticationDto);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return Unauthorized(response);
            return Ok(response);
        }
        
        /// <summary>
        /// Endpoint For Registering The User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult<BaseResponse<UsersDto>>> Register([FromBody] RegistrationRequest request)
        {
            BaseResponse<UsersDto> response = await _accountService.Register(request.RegistrationDto);
            if (response.StatusCode == HttpStatusCode.BadRequest)
                return BadRequest(response);
            return Ok(response);
        }
        
        /// <summary>
        /// Endpoint For Refreshing The JWT
        /// </summary>
        /// <param name="refreshTokenDto"></param>
        /// <returns></returns>
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