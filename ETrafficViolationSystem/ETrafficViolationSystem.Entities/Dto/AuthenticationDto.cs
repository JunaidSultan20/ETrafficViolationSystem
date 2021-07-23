using System;
using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Dto
{
    public class AuthenticationDto
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class RegistrationDto
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<string> Roles { get; set; }
    }

    // public class LoginDto
    // {
    //     public int UserId { get; set; }
    //
    //     public string Username { get; set; }
    //
    //     public string Email { get; set; }
    //
    //     public List<string> Role { get; set; }
    //
    //     public string Token { get; set; }
    //
    //     public string RefreshToken { get; set; }
    //
    //     public DateTime ExpirationTime { get; set; }
    // }

    public class LoginDto
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiration { get; set; }
    }

    public class RefreshTokenDto
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}