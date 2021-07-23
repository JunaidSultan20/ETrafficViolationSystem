using System;
using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class LicenseRecordsRequestValidator : AbstractValidator<LicenseRecordsRequest>
    {
        public LicenseRecordsRequestValidator()
        {
            RuleFor(x => x.LicenseRecordsDto.DriverId)
                .NotEmpty().WithMessage("Driver Id Cannot Be Empty.")
                .NotNull().WithMessage("Driver Id Is Required.")
                .GreaterThan(0).WithMessage("Driver Id Must Be Greater Than 0.");

            RuleFor(x => x.LicenseRecordsDto.LicenseTypeId)
                .NotEmpty().WithMessage("License Type Id Cannot Be Empty.")
                .NotNull().WithMessage("License Type Id Is Required.")
                .GreaterThan(Convert.ToByte(0)).WithMessage("License Type Id Must Be Greater Than 0.");

            RuleFor(x => x.LicenseRecordsDto.IssueDate)
                .NotEmpty().WithMessage("Issue Date Cannot Be Empty.")
                .NotNull().WithMessage("Issue Date Is Required.");

            RuleFor(x => x.LicenseRecordsDto.ExpiryDate)
                .NotEmpty().WithMessage("Expiry Date Cannot Be Empty.")
                .NotNull().WithMessage("Expiry Date Is Required.");

            RuleFor(x => x.LicenseRecordsDto.Points)
                .NotEmpty().WithMessage("Points Cannot Be Empty.")
                .NotNull().WithMessage("Points Id Is Required.")
                .GreaterThan(0).WithMessage("Points Must Be Greater Than 0.")
                .LessThanOrEqualTo(20).WithMessage("Points Must Be Less Than Or Equal To 20.");

            RuleFor(x => x.LicenseRecordsDto.Suspended)
                .NotEmpty().WithMessage("Suspended CheckCannot Be Empty.")
                .NotNull().WithMessage("Suspended Check Is Required.");

            RuleFor(x => x.LicenseRecordsDto.Terminated)
                .NotEmpty().WithMessage("Terminated Check Cannot Be Empty.")
                .NotNull().WithMessage("Terminated Check Is Required.");

            RuleFor(x => x.LicenseRecordsDto.LicenseImageFront)
                .NotEmpty().WithMessage("License Image Front Cannot Be Empty.")
                .NotNull().WithMessage("License Image Front Is Required.")
                .Length(255).WithMessage("License Image Front Exceeds 255 Characters Length.");
            
            RuleFor(x => x.LicenseRecordsDto.LicenseImageBack)
                .NotEmpty().WithMessage("License Image Back Cannot Be Empty.")
                .NotNull().WithMessage("License Image Back Is Required.")
                .Length(255).WithMessage("License Image Back Exceeds 255 Characters Length.");
        }
    }
}