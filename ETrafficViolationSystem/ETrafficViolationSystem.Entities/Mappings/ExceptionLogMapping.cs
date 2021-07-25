using System;
using System.Linq;
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
            CreateMap<Tuple<HttpContext, Exception>, ExceptionLog>()
                .ForMember(destination => destination.ExceptionMessage, source
                    => source.MapFrom(x => x.Item2.Message))

                .ForMember(destination => destination.InnerException, source
                    => source.Condition(x => !string.IsNullOrEmpty(x.Item2?.InnerException?.Message)))

                .ForMember(destination => destination.Url, source
                    => source.Condition(x => !string.IsNullOrEmpty(x.Item1?.Request?.Path.ToString())))

                .ForMember(destination => destination.Method, source
                    => source.Condition(x => !string.IsNullOrEmpty(x.Item1?.Request?.Method)))

                .ForMember(destination => destination.Body, source
                    => source.Condition(x => !string.IsNullOrEmpty(x.Item1?.Request?.Body.ToString())))

                .ForMember(destination => destination.RemoteIp, source
                    => source.Condition(x => !string.IsNullOrEmpty(x.Item1?.Connection?.RemoteIpAddress.ToString())))

                .ForMember(destination => destination.CreatedBy, source
                    => source.Condition(x => !string.IsNullOrEmpty(x.Item1?.User?.FindFirstValue(ClaimTypes.NameIdentifier))));
        }
    }
}