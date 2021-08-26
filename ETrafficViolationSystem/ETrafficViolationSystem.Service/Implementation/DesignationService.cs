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
    public class DesignationService : IDesignationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DesignationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<DesignationDto>> GetByTitle(string title)
        {
            Designation result = await _unitOfWork.Repository<Designation>().FindAsync(x => x.Title == title);
            if (result == null)
                return new BaseResponse<DesignationDto>(HttpStatusCode.NotFound, null);
            return new BaseResponse<DesignationDto>(HttpStatusCode.OK, null, _mapper.Map<DesignationDto>(result), 1);
        }

        public async Task<BaseResponse<IEnumerable<DesignationDto>>> GetDesignationList()
        {
            IEnumerable<Designation> result = await _unitOfWork.Repository<Designation>().Get(x => x.IsActive);
            if (result == null && !result.Any())
                return new BaseResponse<IEnumerable<DesignationDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<DesignationDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<DesignationDto>>(result), result.Count());
        }

        public async Task<BaseResponse<IEnumerable<DesignationDto>>> GetReportingDesignation(int reportsTo)
        {
            IEnumerable<Designation> result = await _unitOfWork.Repository<Designation>().Get(x => x.ReportsTo == reportsTo);
            if (result == null && !result.Any())
                return new BaseResponse<IEnumerable<DesignationDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<DesignationDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<DesignationDto>>(result), result.Count());
        }
    }
}