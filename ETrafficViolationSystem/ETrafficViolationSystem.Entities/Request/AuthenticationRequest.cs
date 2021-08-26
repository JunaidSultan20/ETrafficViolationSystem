using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class AuthenticationRequest
    {
        public AuthenticationDto AuthenticationDto { get; set; }
    }

    public class RegistrationRequest
    {
        public RegistrationDto RegistrationDto { get; set; }
    }

    public class LogoutRequest
    {
        public string Token { get; set; }
    }
}