using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ETrafficViolationSystem.Entities.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ETrafficViolationSystem.API.Filters
{
    public class CustomModelValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                BaseResponse<object> response = new BaseResponse<object>(HttpStatusCode.BadRequest,
                    "One or more validation errors occurred.", null)
                {
                    IsSuccessful = false,
                    ApiException = new ApiException("Model State validation failed.", null, null, null,
                        context.ModelState.Keys.SelectMany(key => context.ModelState[key].Errors.Select(x =>
                            new ValidationError
                                (key, x.ErrorMessage))).AsEnumerable())
                };
                context.Result = new UnprocessableEntityObjectResult(response);
                return;
            }
            await next();
        }
    }
}