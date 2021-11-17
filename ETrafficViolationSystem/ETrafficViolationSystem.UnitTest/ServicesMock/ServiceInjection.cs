using System;
using System.IO;
using ETrafficViolationSystem.Data.Context;
using ETrafficViolationSystem.Data.UnitOfWork.Implementation;
using ETrafficViolationSystem.Data.UnitOfWork.Interface;
using ETrafficViolationSystem.Service.Implementation;
using ETrafficViolationSystem.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ETrafficViolationSystem.UnitTest.ServicesMock
{
    public class ServiceInjection
    {
        private IConfiguration _configuration;

        public ServiceProvider GetServiceProvider()
        {
            ServiceCollection services = new ServiceCollection();
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            //configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName +
                                             "/ETrafficViolationSystem.API/appsettings.json");
            _configuration = configurationBuilder.Build();
            services.AddDbContext<ETrafficViolationSystemContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddHttpContextAccessor();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IPropertyMappingService, PropertyMappingService>();
            services.AddTransient<IInfractionsService, InfractionsService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            ServiceProvider serviceBuilder = services.BuildServiceProvider();
            return serviceBuilder;
        }
    }
}