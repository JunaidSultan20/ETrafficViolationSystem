using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using ETrafficViolationSystem.Common.Enumerators;
using ETrafficViolationSystem.Common.ExtensionMethods;
using ETrafficViolationSystem.Entities.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ETrafficViolationSystem.API.Filters
{
    public class AuthorizationFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        private readonly IList<string> _roles;

        public AuthorizationFilter()
        { }

        //public AuthorizationFilter(Roles[] roles)
        //{
        //    roles.ToList().ForEach(item =>
        //    {
        //        _roles.Add(item.GetDescription());
        //    });
        //}

        public AuthorizationFilter(string role)
        {
            _roles = role.Split(',');
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
                context.Result = new UnauthorizedObjectResult(new BaseResponse<object>(HttpStatusCode.Unauthorized, "Authorization Header Missing."));

            if (string.IsNullOrEmpty(context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value))
                context.Result = new UnauthorizedObjectResult(new BaseResponse<object>(HttpStatusCode.Unauthorized, "Authorization Token Missing"));

            if (context.HttpContext.User.Identity is { IsAuthenticated: true })
            {
                var userRole = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);
                if (!_roles.Contains(userRole?.Value))
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    context.Result = new ObjectResult(new BaseResponse<object>(HttpStatusCode.Forbidden, null));
                }
            }
            else
            {
                context.Result = new UnauthorizedObjectResult(new BaseResponse<object>(HttpStatusCode.Unauthorized, null));
            }
        }
    }
}