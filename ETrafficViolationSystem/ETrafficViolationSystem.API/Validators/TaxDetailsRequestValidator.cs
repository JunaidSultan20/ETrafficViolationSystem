using System;
using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class TaxDetailsRequestValidator : AbstractValidator<TaxDetailsRequest>
    {
        public TaxDetailsRequestValidator()
        {
            RuleFor(x => x.TaxDetailsDto.VehicleId)
                .NotEmpty().WithMessage("Vehicle Id Cannot Be Empty.")
                .NotNull().WithMessage("Vehicle Id Is Required.")
                .GreaterThan(0).WithMessage("Vehicle Id Should Be Greater Than 0.");

            RuleFor(x => x.TaxDetailsDto.OwnerId)
                .NotEmpty().WithMessage("Owner Id Cannot Be Empty.")
                .NotNull().WithMessage("Owner Id Is Required.")
                .GreaterThan(0).WithMessage("Owner Id Should Be Greater Than 0.");

            RuleFor(x => x.TaxDetailsDto.TaxFilerType)
                .NotEmpty().WithMessage("Tax Filer Type Cannot Be Empty.")
                .NotNull().WithMessage("Tax Filer Type Is Required.")
                .GreaterThanOrEqualTo(Convert.ToByte(1)).WithMessage("Tax Filer Type Should Be Greater Than Or Equal To 1.")
                .LessThanOrEqualTo(Convert.ToByte(2)).WithMessage("Tax Filer Type Should Be Less Than Or Equal To 2.");

            RuleFor(x => x.TaxDetailsDto.AmountPaid)
                .NotEmpty().WithMessage("Amount Paid Cannot Be Empty.")
                .NotNull().WithMessage("Amount Paid Is Required.")
                .GreaterThan(0).WithMessage("Amount Paid Should Be Greater Than 0.");

            RuleFor(x => x.TaxDetailsDto.PaidDate)
                .NotEmpty().WithMessage("Paid Date Cannot Be Empty.")
                .NotNull().WithMessage("Paid Date Is Required.");

            RuleFor(x => x.TaxDetailsDto.PaidUpToDate)
                .NotEmpty().WithMessage("Paid Up To Date Cannot Be Empty.")
                .NotNull().WithMessage("Paid Up To Date Required.");
        }
    }
}