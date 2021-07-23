using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class BanksRequestValidator : AbstractValidator<BankRequest>
    {
        public BanksRequestValidator()
        {
            RuleFor(x => x.BanksDto.Title)
                .NotEmpty().WithMessage("Bank Title Cannot Be Null.")
                .NotNull().WithMessage("Bank Title Is Required.")
                .Matches("^[A-Za-z]*$").WithMessage("Bank Title Can Only Contain Letters.")
                .Length(255).WithMessage("Bank Title Exceeds 255 Characters Length");

            RuleFor(x => x.BanksDto.ShortCode)
                .NotEmpty().WithMessage("Short Code Cannot Be Null.")
                .NotNull().WithMessage("Short Code Is Required.")
                .Matches("^[A-Za-z]*$").WithMessage("Short Code Can Only Contain Letters.")
                .Length(10).WithMessage("Short Code Exceeds 10 Characters Length");
        }
    }
}