﻿using System.Net;
using ETrafficViolationSystem.Entities.Response;
using ETrafficViolationSystem.API.CustomMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace ETrafficViolationSystem.API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        //logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(
                            new ApiException("Internal Server Error from the custom middleware.", null, null, null)
                                .ToString());
                    }
                });
            });
        }

        public static void ConfigureCustomMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}