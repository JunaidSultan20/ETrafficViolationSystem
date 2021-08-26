using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Response;

namespace ETrafficViolationSystem.Service.Interface
{
    public interface IDriverDetailsService
    {
        Task<BaseResponse<DriverDetailsDto>> GetById(int id);

        Task<BaseResponse<DriverDetailsDto>> GetByCnic(string cnic);

        Task<BaseResponse<DriverDetailsDto>> GetByEmail(string email);

        Task<BaseResponse<DriverDetailsDto>> GetByMobileNumber(string mobileNumber);

        Task<BaseResponse<IEnumerable<DriverDetailsDto>>> GetDriversList();

        Task<BaseResponse<IEnumerable<DriverDetailsDto>>> GetByDob(DateTime dob);

        Task<BaseResponse<IEnumerable<DriverDetailsDto>>> GetByGender(int gender);

        Task<BaseResponse<IEnumerable<DriverDetailsDto>>> GetByCityId(int cityId);

        Task<BaseResponse<IEnumerable<DriverDetailsDto>>> GetByBloodGroup(int bloodGroup);

        Task<BaseResponse<IEnumerable<DriverDetailsDto>>> GetByDisability(bool disability);
    }
}