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
    public class InfractionsService : IInfractionsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InfractionsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<InfractionsDto>>> GetInfractionsList()
        {
            IEnumerable<Infractions> result = await _unitOfWork.Repository<Infractions>().Get(x => x.IsActive);
            if (result == null && !result.Any())
                return new BaseResponse<IEnumerable<InfractionsDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<InfractionsDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<InfractionsDto>>(result), result.Count());
        }

        public async Task<BaseResponse<InfractionsDto>> GetInfractionById(int id)
        {
            Infractions result = await _unitOfWork.Repository<Infractions>().FindAsync(x => x.InfractionId == id);
            if (result == null)
                return new BaseResponse<InfractionsDto>(HttpStatusCode.NotFound, null);
            return new BaseResponse<InfractionsDto>(HttpStatusCode.OK, null, _mapper.Map<InfractionsDto>(result));
        }
    }
}