using ETrafficViolationSystem.Common.Configurations;
using ETrafficViolationSystem.Data.UnitOfWork.Implementation;
using ETrafficViolationSystem.Data.UnitOfWork.Interface;
using ETrafficViolationSystem.Entities.Models;
using ETrafficViolationSystem.Service.Implementation;
using ETrafficViolationSystem.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ETrafficViolationSystem.API.Configuration
{
    public class DependencyInjectionConfig
    {
        public static void AddScoped(IServiceCollection service)
        {
            service.AddScoped<IAccountService, AccountService>();
            service.AddScoped<ICountryService, CountryService>();
            service.AddTransient<IExceptionLogService, ExceptionLogService>();
            service.AddScoped<IInfractionsService, InfractionsService>();
            service.AddScoped<IRoleService, RoleService>();
            service.AddScoped<IStatesService, StatesService>();
            service.AddTransient<IUnitOfWork, UnitOfWork>();
            service.AddScoped<UserManager<Users>>();
            service.AddScoped<RoleManager<Roles>>();
            service.AddScoped<JwtConfig>();
            service.AddTransient<IPropertyMappingService, PropertyMappingService>();
        }
    }
}