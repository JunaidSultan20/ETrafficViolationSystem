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
using Microsoft.EntityFrameworkCore;

namespace ETrafficViolationSystem.Service.Implementation
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CityDto>> GetById(int id)
        {
            City result = await _unitOfWork.Repository<City>().FindAsync(x => x.CityId == id);
            if (result == null)
                return new BaseResponse<CityDto>(HttpStatusCode.NotFound, null);
            return new BaseResponse<CityDto>(HttpStatusCode.OK, null, _mapper.Map<CityDto>(result), 1);
        }

        public async Task<BaseResponse<CityDto>> GetByTitle(string title)
        {
            City result = await _unitOfWork.Repository<City>().FindAsync(x => x.CityTitle.Contains(title));
            if (result == null)
                return new BaseResponse<CityDto>(HttpStatusCode.NotFound, null);
            return new BaseResponse<CityDto>(HttpStatusCode.OK, null, _mapper.Map<CityDto>(result), 1);
        }

        public async Task<BaseResponse<IEnumerable<CityDto>>> GetByPostalCode(int postalCode)
        {
            IEnumerable<City> result = await _unitOfWork.Repository<City>().Get(x => x.PostalCode == postalCode);
            if (result == null && !result.Any())
                return new BaseResponse<IEnumerable<CityDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<CityDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<CityDto>>(result), result.Count());
        }

        public async Task<BaseResponse<IEnumerable<CityDto>>> GetByStateId(int stateId)
        {
            IEnumerable<City> result = await _unitOfWork.Repository<City>().Get(x => x.StateId == stateId);
            if (result == null && !result.Any())
                return new BaseResponse<IEnumerable<CityDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<CityDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<CityDto>>(result), result.Count());
        }

        public async Task<BaseResponse<IEnumerable<CityDto>>> GetByCountryId(int countryId)
        {
            IEnumerable<City> result = await (from city in _unitOfWork.Context.City
                join states in _unitOfWork.Context.States on city.StateId equals states.StateId
                join country in _unitOfWork.Context.Country on states.CountryId equals country.CountryId
                where country.CountryId == countryId
                select city).ToListAsync();
            if (result == null && !result.Any())
                return new BaseResponse<IEnumerable<CityDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<CityDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<CityDto>>(result), result.Count());
        }
    }
}