using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class PaymentModeRequestValidator : AbstractValidator<PaymentModeRequest>
    {
        public PaymentModeRequestValidator()
        {
            RuleFor(x => x.PaymentModeDto.Title)
                .NotEmpty().WithMessage("Title Cannot Be Empty.")
                .NotNull().WithMessage("Title Is Required.")
                .Matches("^[A-Za-z0-9]*$").WithMessage("Title Can Only Contain Letters And Numbers.")
                .Length(255).WithMessage("Title Exceeds 255 Characters Length.");
        }
    }
}