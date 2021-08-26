using System;
using System.Net;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Response;
using ETrafficViolationSystem.Service.Interface;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ETrafficViolationSystem.API.CustomMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IExceptionLogService exceptionLogService)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception, exceptionLogService);
            }
        }

        private async Task<Task> HandleExceptionAsync(HttpContext context, Exception exception, IExceptionLogService exceptionLogService)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = new BaseResponse<object>(HttpStatusCode.InternalServerError, "Internal Server Error", null);
            int logId = await exceptionLogService.AddLog(exception, context);
            response.ApiException = new ApiException(logId, "Internal Server Error Occurred.", exception.Message,
                exception.InnerException?.Message, exception.HelpLink);
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}