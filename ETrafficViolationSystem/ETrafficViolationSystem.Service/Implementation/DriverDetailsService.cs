using System;
using System.Collections.Generic;
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
    public class DriverDetailsService : IDriverDetailsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DriverDetailsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<DriverDetailsDto>> GetById(int id)
        {
            DriverDetails result = await _unitOfWork.Repository<DriverDetails>().FindAsync(x => x.DriverId == id);
            if (result == null)
                return new BaseResponse<DriverDetailsDto>(HttpStatusCode.NotFound, null);
            return new BaseResponse<DriverDetailsDto>(HttpStatusCode.OK, null, _mapper.Map<DriverDetailsDto>(result), 1);
        }

        public Task<BaseResponse<DriverDetailsDto>> GetByCnic(string cnic)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<DriverDetailsDto>> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<DriverDetailsDto>> GetByMobileNumber(string mobileNumber)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<DriverDetailsDto>>> GetDriversList()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<DriverDetailsDto>>> GetByDob(DateTime dob)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<DriverDetailsDto>>> GetByGender(int gender)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<DriverDetailsDto>>> GetByCityId(int cityId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<DriverDetailsDto>>> GetByBloodGroup(int bloodGroup)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<DriverDetailsDto>>> GetByDisability(bool disability)
        {
            throw new NotImplementedException();
        }
    }
}