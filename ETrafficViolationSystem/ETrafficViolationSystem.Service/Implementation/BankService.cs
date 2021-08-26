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
    public class BankService : IBankService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BankService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<BaseResponse<IEnumerable<BanksDto>>> GetBanksList()
        {
            IEnumerable<Banks> result = await _unitOfWork.Repository<Banks>().Get(x => x.IsActive == true);
            if (result == null && !result.Any())
                return new BaseResponse<IEnumerable<BanksDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<BanksDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<BanksDto>>(result), result.Count());
        }

        public async Task<BaseResponse<IEnumerable<BanksDto>>> GetBanksByCityId(int id)
        {
            IEnumerable<Banks> result = await (from banks in _unitOfWork.Context.Banks
                join bankBranch in _unitOfWork.Context.BankBranch on banks.BankId equals bankBranch.BankBranchId
                join city in _unitOfWork.Context.City on bankBranch.CityId equals city.CityId
                where city.CityId == id
                select banks).ToListAsync();
            if (result == null && !result.Any())
                return new BaseResponse<IEnumerable<BanksDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<BanksDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<BanksDto>>(result), result.Count());
        }

        public async Task<BaseResponse<BanksDto>> GetById(int id)
        {
            Banks result = await _unitOfWork.Repository<Banks>().FindAsync(x => x.BankId == id);
            if (result == null)
                return new BaseResponse<BanksDto>(HttpStatusCode.NotFound, null);
            return new BaseResponse<BanksDto>(HttpStatusCode.OK, null, _mapper.Map<BanksDto>(result), 1);
        }

        public async Task<BaseResponse<BanksDto>> GetByTitle(string title)
        {
            Banks result = await _unitOfWork.Repository<Banks>().FindAsync(x => x.Title == title);
            if (result == null)
                return new BaseResponse<BanksDto>(HttpStatusCode.NotFound, null);
            return new BaseResponse<BanksDto>(HttpStatusCode.OK, null, _mapper.Map<BanksDto>(result), 1);
        }

        public async Task<BaseResponse<BanksDto>> GetByShortCode(string code)
        {
            Banks result = await _unitOfWork.Repository<Banks>().FindAsync(x => x.ShortCode == code);
            if (result == null)
                return new BaseResponse<BanksDto>(HttpStatusCode.NotFound, null);
            return new BaseResponse<BanksDto>(HttpStatusCode.OK, null, _mapper.Map<BanksDto>(result), 1);
        }
    }
}