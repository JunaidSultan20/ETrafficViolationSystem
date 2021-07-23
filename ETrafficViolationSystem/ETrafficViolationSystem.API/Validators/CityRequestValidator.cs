using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class CityRequestValidator : AbstractValidator<CityRequest>
    {
        public CityRequestValidator()
        {
            RuleFor(x => x.CityDto.CityTitle)
                .NotEmpty().WithMessage("City Title Cannot Be Empty.")
                .NotNull().WithMessage("City Title Is Required.")
                .Matches("^[A-Za-z]*$").WithMessage("City Title Can Only Contain Letters.")
                .Length(50).WithMessage("City Title Exceeds 50 Characters Length.");

            RuleFor(x => x.CityDto.PostalCode)
                .NotEmpty().WithMessage("Postal Code Cannot Be Empty.")
                .NotNull().WithMessage("Postal Code Is Required.")
                .GreaterThan(0).WithMessage("Postal Code Must Be Greater Than Zero.");

            RuleFor(x => x.CityDto.StateId)
                .NotEmpty().WithMessage("State Id Cannot Be Empty.");
        }
    }
}