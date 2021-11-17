using System;
using System.Threading.Tasks;
using AutoMapper;
using ETrafficViolationSystem.Data.UnitOfWork.Interface;
using ETrafficViolationSystem.Entities.Models;
using ETrafficViolationSystem.Service.Interface;
using Microsoft.AspNetCore.Http;

namespace ETrafficViolationSystem.Service.Implementation
{
    public class ExceptionLogService : IExceptionLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExceptionLogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddLog(Exception exception, HttpContext httpContext)
        {
            Tuple<Exception, HttpContext> sourceTuple = Tuple.Create(exception, httpContext);
            ExceptionLog exceptionLog = new ExceptionLog();
            _mapper.Map<Tuple<Exception, HttpContext>, ExceptionLog>(sourceTuple, exceptionLog);
            await _unitOfWork.Repository<ExceptionLog>().Add(exceptionLog);
            await _unitOfWork.Commit();
            return exceptionLog.Id;
        }
    }
}