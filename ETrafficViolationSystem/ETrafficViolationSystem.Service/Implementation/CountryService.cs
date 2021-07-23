using System.Collections.Generic;
using System.Threading.Tasks;
using ETrafficViolationSystem.Data.UnitOfWork.Interface;
using ETrafficViolationSystem.Entities.Models;
using ETrafficViolationSystem.Service.Interface;

namespace ETrafficViolationSystem.Service.Implementation
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Country>> GetCountryList()
        {
            return await _unitOfWork.Repository<Country>().Get(null);
        }

        public async Task<Country> GetById(int id)
        {
            return await _unitOfWork.Repository<Country>().GetById(id);
        }
    }
}