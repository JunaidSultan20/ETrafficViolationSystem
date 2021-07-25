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

        public async Task AddLog(Exception exception, HttpContext httpContext)
        {
            //ExceptionLog exceptionLog = new ExceptionLog
            //{
            //    ExceptionMessage = exception?.Message ?? "",
            //    InnerException = exception?.InnerException?.Message ?? "",
            //    Url = httpContext?.Request?.Path.ToString() ?? "",
            //    Method = httpContext?.Request?.Method ?? "",
            //    Body = httpContext?.Request?.Body.ToString(),
            //    RemoteIp = httpContext?.Connection?.RemoteIpAddress.ToString() ?? ""
            //};
            Tuple<HttpContext, Exception> sourceTuple = Tuple.Create(httpContext, exception);
            ExceptionLog exceptionLog = new ExceptionLog();
            _mapper.Map<Tuple<HttpContext, Exception>, ExceptionLog>(sourceTuple, exceptionLog);
            await _unitOfWork.Repository<ExceptionLog>().Add(exceptionLog);
            await _unitOfWork.Commit();
        }
    }
}