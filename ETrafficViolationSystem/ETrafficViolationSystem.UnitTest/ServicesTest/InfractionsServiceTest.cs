using System.Linq;
using System.Net;
using ETrafficViolationSystem.Entities.Request.QueryParameters;
using ETrafficViolationSystem.Service.Interface;
using ETrafficViolationSystem.UnitTest.ServicesMock;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace ETrafficViolationSystem.UnitTest.ServicesTest
{
    public class InfractionsServiceTest
    {
        private readonly IInfractionsService _infractionsService;

        public InfractionsServiceTest()
        {
            ServiceInjection serviceInjection = new ServiceInjection();
            _infractionsService = serviceInjection.GetServiceProvider().GetService<IInfractionsService>();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetInfractionsListTest()
        {
            var result = _infractionsService.GetInfractionsList(new BaseQueryParameters
                { OrderBy = "id asc", PageNumber = 1, PageSize = 10 }).Result;
            Assert.AreEqual(200, result.Result.FirstOrDefault().Penalty);
        }

        [Test]
        public void GetInfractionByIdTest()
        {
            var result = _infractionsService.GetInfractionById(20).Result;
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual("Failing to dip head light for other traffic.", result.Result.Description);
            Assert.AreNotSame(false, result.IsSuccessful);
        }

        [Test]
        public void GetByPenaltyTest()
        {
            var result = _infractionsService.GetByPenalty(100).Result;
            Assert.AreEqual(11, result.Result.Count());

            result = _infractionsService.GetByPenalty(200).Result;
            Assert.AreEqual(26, result.Result.Count());
        }

        [Test]
        public void GetByPointsTest()
        {
            var result = _infractionsService.GetByPoints(5).Result;
            Assert.AreEqual(15, result.Result.Count());

            result = _infractionsService.GetByPoints(10).Result;
            Assert.AreNotEqual(6, result.Result.Count());
        }
    }
}