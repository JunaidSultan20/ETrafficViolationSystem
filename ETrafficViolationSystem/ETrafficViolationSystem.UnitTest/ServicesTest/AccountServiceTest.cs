using System.Net;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Service.Interface;
using ETrafficViolationSystem.UnitTest.ServicesMock;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace ETrafficViolationSystem.UnitTest.ServicesTest
{
    public class AccountServiceTest
    {
        private readonly IAccountService _accountService;

        public AccountServiceTest()
        {
            ServiceInjection serviceInjection = new ServiceInjection();
            _accountService = serviceInjection.GetServiceProvider().GetService<IAccountService>();
        }
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoginTest()
        {
            var result = _accountService.Login(new AuthenticationDto { Email = "admin@etvs.com", Password = "admin" }).Result;
            Assert.Equals(HttpStatusCode.Unauthorized, result.StatusCode);
        }
    }
}