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
    public class BankBranchService : IBankBranchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BankBranchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<BankBranchDto>>> GetBranchesByBankId(int id)
        {
            IEnumerable<BankBranch> result = await _unitOfWork.Repository<BankBranch>().Get(x => x.BankId == id);
            if (result == null && !result.Any())
                return new BaseResponse<IEnumerable<BankBranchDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<BankBranchDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<BankBranchDto>>(result), result.Count());
        }

        public async Task<BaseResponse<IEnumerable<BankBranchDto>>> GetByBankShortCode(string code)
        {
            IEnumerable<BankBranch> result = await _unitOfWork.Context.BankBranch
                .Join(_unitOfWork.Context.Banks, bankBranch => bankBranch.BankId, bank => bank.BankId,
                    (bankBranch, bank) => new { BankBranch = bankBranch, Banks = bank })
                .Where(x => x.Banks.ShortCode.Contains(code))
                .Select(x => x.BankBranch).ToListAsync();

            //IEnumerable<BankBranch> result = await _unitOfWork.Repository<BankBranch>().Get(x => x.Bank.ShortCode == code);
            if (result == null)
                return new BaseResponse<IEnumerable<BankBranchDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<BankBranchDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<BankBranchDto>>(result), result.Count());
        }

        public async Task<BaseResponse<IEnumerable<BankBranchDto>>> GetByCityId(int id)
        {
            IEnumerable<BankBranch> result = await _unitOfWork.Repository<BankBranch>().Get(x => x.CityId == id);
            if (result == null)
                return new BaseResponse<IEnumerable<BankBranchDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<BankBranchDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<BankBranchDto>>(result), result.Count());
        }

        public async Task<BaseResponse<BankBranchDto>> GetByTitle(string title)
        {
            BankBranch result = await _unitOfWork.Repository<BankBranch>().FindAsync(x => x.BranchTitle == title);
            if (result == null)
                return new BaseResponse<BankBranchDto>(HttpStatusCode.NotFound, null);
            return new BaseResponse<BankBranchDto>(HttpStatusCode.OK, null, _mapper.Map<BankBranchDto>(result));
        }

        public async Task<BaseResponse<BankBranchDto>> GetByBranchCode(int code)
        {
            BankBranch result = await _unitOfWork.Repository<BankBranch>().FindAsync(x => x.BranchCode == code);
            if (result == null)
                return new BaseResponse<BankBranchDto>(HttpStatusCode.NotFound, null);
            return new BaseResponse<BankBranchDto>(HttpStatusCode.OK, null, _mapper.Map<BankBranchDto>(result));
        }
    }
}