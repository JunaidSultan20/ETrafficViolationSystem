using System.Collections.Generic;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Models;

namespace ETrafficViolationSystem.Service.Interface
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountryList();

        Task<Country> GetById(int id);
    }
}