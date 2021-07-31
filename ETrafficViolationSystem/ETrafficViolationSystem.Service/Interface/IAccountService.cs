using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Response;
using System.Threading.Tasks;

namespace ETrafficViolationSystem.Service.Interface
{
    public interface IAccountService
    {
        Task<BaseResponse<LoginDto>> Login(AuthenticationDto authenticationDto);

        Task<BaseResponse<UsersDto>> Register(RegistrationDto registrationDto);

        Task<BaseResponse<RefreshTokenDto>> RefreshToken(RefreshTokenDto refreshTokenDto);
    }
}