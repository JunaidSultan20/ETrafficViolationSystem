using System;
using System.Security.Claims;
using AutoMapper;
using ETrafficViolationSystem.Entities.Models;
using Microsoft.AspNetCore.Http;

namespace ETrafficViolationSystem.Entities.Mappings
{
    public class ExceptionLogMapping : Profile
    {
        public ExceptionLogMapping()
        {
            CreateMap<Tuple<Exception, HttpContext>, ExceptionLog>()
                .ForMember(destination => destination.ExceptionMessage, source
                    => source.MapFrom(x => x.Item1.Message))

                .ForMember(destination => destination.InnerException, source
                    => source.MapFrom(x => x.Item1.InnerException.Message))

                .ForMember(destination => destination.Url, source
                    => source.MapFrom(x => x.Item2.Request.Path.ToString()))

                .ForMember(destination => destination.Method, source
                    => source.MapFrom(x => x.Item2.Request.Method))

                .ForMember(destination => destination.Body, source
                    => source.MapFrom(x => x.Item2.Request.Body.ToString()))

                .ForMember(destination => destination.RemoteIp, source
                    => source.MapFrom(x => x.Item2.Connection.RemoteIpAddress.ToString()))

                .ForMember(destination => destination.CreatedBy, source
                    => source.MapFrom(x => x.Item2.User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }
    }
}