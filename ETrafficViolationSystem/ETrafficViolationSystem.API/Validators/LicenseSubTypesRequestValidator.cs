using System;
using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class LicenseSubTypesRequestValidator : AbstractValidator<LicenseSubTypesRequest>
    {
        public LicenseSubTypesRequestValidator()
        {
            RuleFor(x => x.LicenseSubTypesDto.LicenseTypeId)
                .NotEmpty().WithMessage("License Type Id Cannot Be Empty.")
                .NotNull().WithMessage("License Type Id Is Required.")
                .GreaterThan(Convert.ToByte(0)).WithMessage("License Type Id Must Be Greater Than 0.");

            RuleFor(x => x.LicenseSubTypesDto.Title)
                .NotEmpty().WithMessage("Title Cannot Be Empty.")
                .NotNull().WithMessage("Title Is Required.")
                .Matches("^[A-Za-z0-9]*$").WithMessage("Title Can Only Contain Letters And Numbers.")
                .Length(50).WithMessage("Title Exceeds 50 Characters Length.");

            RuleFor(x => x.LicenseSubTypesDto.SubTypeClass)
                .NotEmpty().WithMessage("Sub Type Class Cannot Be Empty.")
                .Matches("^[A-Za-z0-9]*$").WithMessage("Sub Type Class Can Only Contain Letters And Numbers.")
                .Length(10).WithMessage("Sub Type Class Exceeds 10 Characters Length.");
        }
    }
}