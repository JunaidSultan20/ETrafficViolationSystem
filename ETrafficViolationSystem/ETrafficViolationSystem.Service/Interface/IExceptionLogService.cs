using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ETrafficViolationSystem.Service.Interface
{
    public interface IExceptionLogService
    {
        Task AddLog(Exception exception, HttpContext httpContext);
    }
}