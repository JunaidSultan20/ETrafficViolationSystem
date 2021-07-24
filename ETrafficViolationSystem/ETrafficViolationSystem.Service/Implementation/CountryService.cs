using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using ETrafficViolationSystem.Data.UnitOfWork.Interface;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;
using ETrafficViolationSystem.Entities.Response;
using ETrafficViolationSystem.Service.Interface;

namespace ETrafficViolationSystem.Service.Implementation
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<CountryDto>>> GetCountryList()
        {
            IEnumerable<Country> result = await _unitOfWork.Repository<Country>().Get(x => x.IsActive);
            if (result == null && !result.Any())
                return new BaseResponse<IEnumerable<CountryDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<CountryDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<CountryDto>>(result));
        }

        public async Task<BaseResponse<CountryDto>> GetById(int id)
        {
            Country result = await _unitOfWork.Repository<Country>().FindAsync(x => x.CountryId == id);
            return result == null
                ? new BaseResponse<CountryDto>(HttpStatusCode.NotFound, null)
                : new BaseResponse<CountryDto>(HttpStatusCode.OK, null, _mapper.Map<CountryDto>(result));
        }
    }
}