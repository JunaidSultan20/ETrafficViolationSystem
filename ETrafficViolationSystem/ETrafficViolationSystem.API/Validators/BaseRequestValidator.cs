using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class BaseRequestValidator : AbstractValidator<BaseRequest>
    {
        public BaseRequestValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("User Id Must Be Greater Than 0.");

            RuleFor(x => x.StartPage)
                .GreaterThan(0).WithMessage("Start Page Must Be Greater Than 0.");

            RuleFor(x => x.PageLimit)
                .GreaterThan(0).WithMessage("Page Limit Must Be Greater Than 0.");
        }
    }
}