using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class CountryRequestValidator : AbstractValidator<CountryRequest>
    {
        public CountryRequestValidator()
        {
            RuleFor(x => x.Country.Title)
                .NotEmpty().WithMessage("Country Title Cannot Be Empty.")
                .NotNull().WithMessage("Country Tile Is Required.")
                .Matches("^[A-Za-z]*$").WithMessage("Country Title Can Only Contain Letters.")
                .MaximumLength(255).WithMessage("Country Title Exceeds 255 Characters Length.");

            RuleFor(x => x.Country.ShortCode)
                .NotEmpty().WithMessage("Short Code Cannot Be Empty.")
                .NotNull().WithMessage("Short Code Is Required.")
                .Matches("^[A-Za-z]*$").WithMessage("Short Code Can Only Contain Letters.")
                .MaximumLength(5).WithMessage("Short Code Exceeds 5 Characters Length.");
        }
    }
}