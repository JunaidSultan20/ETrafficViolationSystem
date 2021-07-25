using ETrafficViolationSystem.Common.Configurations;
using ETrafficViolationSystem.Data.Repository.Implementation;
using ETrafficViolationSystem.Data.Repository.Interface;
using ETrafficViolationSystem.Data.UnitOfWork.Implementation;
using ETrafficViolationSystem.Data.UnitOfWork.Interface;
using ETrafficViolationSystem.Entities.Models;
using ETrafficViolationSystem.Service.Implementation;
using ETrafficViolationSystem.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace ETrafficViolationSystem.API.Configuration
{
    public class DependencyInjectionConfig
    {
        public static void AddScoped(IServiceCollection service)
        {
            service.AddScoped<IAccountService, AccountService>();
            service.AddScoped<ICountryService, CountryService>();
            service.AddScoped<IExceptionLogService, ExceptionLogService>();
            service.AddScoped<IStatesService, StatesService>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            service.AddScoped<UserManager<Users>>();
            service.AddSingleton<JwtConfig>();
            service.AddSingleton<ResponseMessages>();
        }
    }
}