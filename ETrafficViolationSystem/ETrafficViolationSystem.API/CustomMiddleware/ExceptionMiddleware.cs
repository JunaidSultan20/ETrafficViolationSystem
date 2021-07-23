using System;
using System.Data.Common;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = new BaseResponse<object>(HttpStatusCode.InternalServerError, "Internal Server Error", null);
            if (exception is DbUpdateException)
            {
                response.ApiException =
                    new ApiException("Database Update Exception", exception.Message, exception.InnerException?.Message,
                        exception.HelpLink);
            }

            if (exception is DbException)
            {
                response.ApiException = new ApiException("Db Exception", exception.Message,
                    exception.InnerException?.Message, exception.HelpLink);
            }

            if (exception is DivideByZeroException)
            {
                response.ApiException =
                    new ApiException("Divide by zero exception", exception.Message, exception.InnerException?.Message,
                        exception.HelpLink);
            }

            if (exception is ArgumentException)
            {
                response.ApiException =
                    new ApiException("Argument exception", exception.Message, exception.InnerException?.Message,
                        exception.HelpLink);
            }

            if (exception is ArgumentNullException)
            {
                response.ApiException =
                    new ApiException("Argument can't be null", exception.Message, exception.InnerException?.Message,
                        exception.HelpLink);
            }

            if (exception is NotImplementedException)
            {
                response.ApiException =
                    new ApiException("This method is not implemented yet.", exception.Message,
                        exception.InnerException?.Message, exception.HelpLink);
            }

            if (exception is TimeoutException)
            {
                response.ApiException =
                    new ApiException("Request timeout occured.", exception.Message, exception.InnerException?.Message,
                        exception.HelpLink);
            }

            if (exception is AmbiguousMatchException)
            {
                response.ApiException =
                    new ApiException("Request is matching multiple endpoints.", exception.Message,
                        exception.InnerException?.Message, exception.HelpLink);
            }
            else
            {
                response.ApiException = new ApiException("Internal server error occurred.", exception.Message,
                    exception.InnerException?.Message, exception.HelpLink);
            }
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}