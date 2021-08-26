using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ETrafficViolationSystem.Data.UnitOfWork.Interface;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;
using ETrafficViolationSystem.Entities.Response;
using ETrafficViolationSystem.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ETrafficViolationSystem.Service.Implementation
{
    public class InfractionsService : IInfractionsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InfractionsService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseResponse<IEnumerable<InfractionsDto>>> GetInfractionsList()
        {
            IEnumerable<Infractions> result = await _unitOfWork.Repository<Infractions>().Get(x => x.IsActive);
            if (result == null)
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

        public async Task<BaseResponse<IEnumerable<InfractionsDto>>> GetByPenalty(int penalty)
        {
            IEnumerable<Infractions>
                result = await _unitOfWork.Repository<Infractions>().Get(x => x.Penalty == penalty);
            if (result == null)
                return new BaseResponse<IEnumerable<InfractionsDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<InfractionsDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<InfractionsDto>>(result), result.Count());
        }

        public async Task<BaseResponse<IEnumerable<InfractionsDto>>> GetByPoints(int points)
        {
            IEnumerable<Infractions>
                result = await _unitOfWork.Repository<Infractions>().Get(x => x.Points == points);
            if (result == null)
                return new BaseResponse<IEnumerable<InfractionsDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<InfractionsDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<InfractionsDto>>(result), result.Count());
        }

        public async Task<BaseResponse<InfractionsDto>> Add(InfractionsInsertDto infractionsInsertDto)
        {
            Tuple<InfractionsInsertDto, int> sourceTuple = Tuple.Create(infractionsInsertDto,
                Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
            Infractions infraction = _mapper.Map<Infractions>(sourceTuple);
            await _unitOfWork.Repository<Infractions>().Add(infraction);
            int result = await _unitOfWork.Commit();
            if (result <= 0)
                return new BaseResponse<InfractionsDto>(HttpStatusCode.BadRequest, null);
            return new BaseResponse<InfractionsDto>(HttpStatusCode.Created, null,
                _mapper.Map<InfractionsDto>(infraction), 1);
        }

        public async Task<BaseResponse<InfractionsDto>> Update(InfractionsUpdateDto infractionsUpdateDto, int id)
        {
            Infractions entity = await _unitOfWork.Repository<Infractions>().FindAsync(x => x.InfractionId == id);
            if (entity == null)
                return new BaseResponse<InfractionsDto>(HttpStatusCode.NotFound, null);
            _mapper.Map<InfractionsUpdateDto, Infractions>(infractionsUpdateDto, entity);
            await _unitOfWork.Repository<Infractions>().Update(entity);
            await _unitOfWork.Commit();
            return new BaseResponse<InfractionsDto>(HttpStatusCode.NoContent, "Resource Updated Successfully.",
                _mapper.Map<InfractionsDto>(entity), 1);
        }

        public async Task<BaseResponse<object>> Delete(int id)
        {
            Infractions infraction = await _unitOfWork.Repository<Infractions>().FindAsync(x => x.InfractionId == id);
            if (infraction == null)
            {
                return new BaseResponse<object>(HttpStatusCode.NotFound, null);
            }
            await _unitOfWork.Repository<Infractions>().Delete(infraction);
            int result = await _unitOfWork.Commit();
            if (result <= 0)
                return new BaseResponse<object>(HttpStatusCode.BadRequest, "Unable To Delete Record.");
            return new BaseResponse<object>(HttpStatusCode.NoContent, null);
        }
    }
}