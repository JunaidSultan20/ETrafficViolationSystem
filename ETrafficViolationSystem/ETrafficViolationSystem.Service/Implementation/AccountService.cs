using AutoMapper;
using ETrafficViolationSystem.Common.Configurations;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;
using ETrafficViolationSystem.Entities.Response;
using ETrafficViolationSystem.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ETrafficViolationSystem.Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<Roles> _roleManager;
        private readonly JwtConfig _jwtConfig;
        private readonly IMapper _mapper;

        public AccountService(UserManager<Users> userManager, RoleManager<Roles> roleManager, JwtConfig jwtConfig, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtConfig = jwtConfig;
            _mapper = mapper;
        }

        public async Task<LoginDto> Login(AuthenticationDto authenticationDto)
        {
            Users user = await _userManager.FindByEmailAsync(authenticationDto.Email);
            if (user != null)
            {
                bool isAuthenticUser = await _userManager.CheckPasswordAsync(user, authenticationDto.Password);
                if (isAuthenticUser)
                {
                    List<string> roles = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().ToList();
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };
                    roles.ForEach(x =>
                    {
                        claims.Add(new Claim(ClaimTypes.Role, x));
                    });
                    var authenticationSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF32.GetBytes(_jwtConfig.Secret));
                    var token = new JwtSecurityToken(
                        issuer: _jwtConfig.Issuer,
                        audience: _jwtConfig.Audience,
                        expires: DateTime.Now.AddMinutes(_jwtConfig.ExpirationMinutes),
                        claims: claims,
                        signingCredentials: new SigningCredentials(authenticationSigningKey,
                            SecurityAlgorithms.HmacSha256Signature));
                    string refreshToken = await _userManager
                        .GetAuthenticationTokenAsync(user, "ETrafficViolationSystem.API", "RefreshToken");
                    if (!string.IsNullOrEmpty(refreshToken))
                    {
                        IdentityResult result = await _userManager
                            .RemoveAuthenticationTokenAsync(user, "ETrafficViolationSystem.API", "RefreshToken");
                        await _userManager.RemoveAuthenticationTokenAsync(user, "ETrafficViolationSystem.API", "RefreshToken");
                        refreshToken = await _userManager
                            .GenerateUserTokenAsync(user, "ETrafficViolationSystem.API", "RefreshToken");
                        await _userManager.SetAuthenticationTokenAsync(user, "JwtTutorial", "RefreshToken",
                            refreshToken);
                    }
                    else
                    {
                        refreshToken = await _userManager.GenerateUserTokenAsync(user, "JwtTutorial", "RefreshToken");
                        await _userManager.SetAuthenticationTokenAsync(user, "JwtTutorial", "RefreshToken", refreshToken);
                    }

                    LoginDto loginDto = new LoginDto()
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo,
                        RefreshToken = refreshToken,
                        RefreshTokenExpiration = DateTime.Now.AddDays(1)
                    };
                    return loginDto;
                }
            }
            return null;
        }

        public async Task<BaseResponse<UsersDto>> Register(RegistrationDto registrationDto)
        {
            Users user = await _userManager.FindByEmailAsync(registrationDto.Email);
            if (user != null)
            {
                return new BaseResponse<UsersDto>(HttpStatusCode.BadRequest, "User already exists.");
            }

            user = _mapper.Map<Users>(registrationDto);
            IdentityResult result = _userManager.CreateAsync(user, registrationDto.Password).GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                foreach (string role in registrationDto.Roles)
                {
                    bool roleExists = await _roleManager.RoleExistsAsync(role);
                    if (!roleExists)
                    {
                        Roles newRole = new Roles
                        {
                            Name = role,
                            NormalizedName = role.ToUpper(),
                            IsActive = true,
                            CreatedDate = DateTime.Now
                        };
                        await _roleManager.CreateAsync(newRole);
                    }
                    result = await _userManager.AddToRoleAsync(user, role);
                    if (!result.Succeeded)
                        return new BaseResponse<UsersDto>(HttpStatusCode.BadRequest, "Unable to create new user")
                        { Errors = result.Errors.Select(x => x.Description).ToList() };
                }
                return new BaseResponse<UsersDto>(HttpStatusCode.OK, "User Created Successfully.", _mapper.Map<UsersDto>(user));
            }
            return new BaseResponse<UsersDto>(HttpStatusCode.BadRequest, "Unable To Create New User.")
            { Errors = result.Errors.Select(x => x.Description).ToList() };
        }

        public async Task<BaseResponse<RefreshTokenDto>> RefreshToken(RefreshTokenDto refreshTokenDto)
        {
            ClaimsPrincipal principal = GetPrincipalFromExpiredToken(refreshTokenDto.Token);
            string username = principal?.Identity?.Name;
            Users user = await _userManager.FindByNameAsync(username);
            string userToken;
            if (user != null)
            {
                userToken = await _userManager.GetAuthenticationTokenAsync(user, "ETrafficViolationSystem.API", "RefreshToken");
                if (string.IsNullOrEmpty(userToken))
                {
                    return new BaseResponse<RefreshTokenDto>(HttpStatusCode.BadRequest, "Invalid Token Model", refreshTokenDto);
                }
            }
            string newAccessToken = GenerateAccessToken(principal.Claims);
            string newRefreshToken = await _userManager.GenerateUserTokenAsync(user, "ETrafficViolationSystem.API", "RefreshToken");
            await _userManager.SetAuthenticationTokenAsync(user, "ETrafficViolationSystem.API", "RefreshToken", newRefreshToken);
            return new BaseResponse<RefreshTokenDto>(HttpStatusCode.OK, "Token Refreshed Successfully", new RefreshTokenDto
            {
                Token = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(_jwtConfig.Secret)),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature,
                StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid access token provided.");
            return principal;
        }

        private string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(_jwtConfig.Secret));
            SigningCredentials signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken tokeOptions = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                audience: "http://localhost:4200",
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
    }
}