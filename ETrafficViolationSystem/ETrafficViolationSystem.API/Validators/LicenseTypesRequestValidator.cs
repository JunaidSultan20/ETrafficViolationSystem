using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class LicenseTypesRequestValidator : AbstractValidator<LicenseTypesRequest>
    {
        public LicenseTypesRequestValidator()
        {
            RuleFor(x => x.LicenseTypesDto.Title)
                .NotEmpty().WithMessage("Title Cannot Be Empty.")
                .NotNull().WithMessage("Title Is Required.")
                .Matches("^[A-Za-z0-9]*$").WithMessage("Title Can Only Contain Letters And Numbers.")
                .Length(50).WithMessage("Title Exceeds 50 Characters Length.");
        }
    }
}