using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ETrafficViolationSystem.Common.ExtensionMethods;
using ETrafficViolationSystem.Data.UnitOfWork.Interface;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;
using ETrafficViolationSystem.Entities.Response;
using ETrafficViolationSystem.Service.Interface;
using Microsoft.AspNetCore.Http;

namespace ETrafficViolationSystem.Service.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<BaseResponse<IEnumerable<RolesDto>>> Get()
        {
            IEnumerable<Roles> result = await _unitOfWork.Repository<Roles>().Get(x => x.IsActive);
            if (result == null && !result.Any())
                return new BaseResponse<IEnumerable<RolesDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<RolesDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<RolesDto>>(result), result.Count());
        }

        public async Task<BaseResponse<RolesDto>> GetById(int id)
        {
            Roles result = await _unitOfWork.Repository<Roles>().FindAsync(x => x.Id == id);
            if (result == null)
                return new BaseResponse<RolesDto>(HttpStatusCode.NotFound, null);
            return new BaseResponse<RolesDto>(HttpStatusCode.OK, null, _mapper.Map<RolesDto>(result));
        }

        public async Task Add(RoleInsertDto roleInsertDto)
        {
            Roles role = _mapper.Map<Roles>(Tuple.Create(roleInsertDto,
                _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToInt()));
            await _unitOfWork.Repository<Roles>().Add(role);
            await _unitOfWork.Commit();
        }
    }
}