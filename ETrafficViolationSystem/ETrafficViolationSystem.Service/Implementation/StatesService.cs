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
    public class StatesService : IStatesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public StatesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<States>> GetStatesList()
        {
            return await _unitOfWork.Repository<States>().Get(x => x.IsActive);
        }

        public async Task<BaseResponse<IEnumerable<StatesDto>>> GetByCountryId(int countryId)
        {
            IEnumerable<States> result = await _unitOfWork.Repository<States>().Get(x => x.CountryId == countryId);
            if (result == null && !result.Any())
                return new BaseResponse<IEnumerable<StatesDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<StatesDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<StatesDto>>(result), result.Count());
        }

        public async Task<BaseResponse<StatesDto>> GetById(int id)
        {
            States result = await _unitOfWork.Repository<States>().FindAsync(x => x.StateId == id);
            return result == null
                ? new BaseResponse<StatesDto>(HttpStatusCode.NotFound, null)
                : new BaseResponse<StatesDto>(HttpStatusCode.OK, null, _mapper.Map<StatesDto>(result));
        }
    }
}