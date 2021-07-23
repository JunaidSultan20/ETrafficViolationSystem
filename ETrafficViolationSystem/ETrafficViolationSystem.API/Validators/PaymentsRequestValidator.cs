using System;
using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class PaymentsRequestValidator : AbstractValidator<PaymentsRequest>
    {
        public PaymentsRequestValidator()
        {
            RuleFor(x => x.PaymentsDto.TotalAmount)
                .NotEmpty().WithMessage("Total Amount Cannot Be Empty.")
                .NotNull().WithMessage("Total Amount Is Required.")
                .GreaterThanOrEqualTo(100).WithMessage("Total Amount Should Be Greater Or Equal To 100.");

            RuleFor(x => x.PaymentsDto.PaidAmount)
                .NotEmpty().WithMessage("Paid Amount Cannot Be Empty.")
                .NotNull().WithMessage("Paid Amount Is Required.")
                .GreaterThanOrEqualTo(1).WithMessage("Total Amount Should Be Greater Or Equal To 1.");

            RuleFor(x => x.PaymentsDto.DateTime)
                .NotEmpty().WithMessage("Date Time Cannot Be Empty.")
                .NotNull().WithMessage("Date Time Is Required.");

            RuleFor(x => x.PaymentsDto.PaymentModeId)
                .NotEmpty().WithMessage("Payment Mode Id Cannot Be Empty.")
                .NotNull().WithMessage("Payment Mode Id Is Required.")
                .GreaterThan(Convert.ToByte(0)).WithMessage("Payment Mode Id Should Be Greater Than 0.");

            RuleFor(x => x.PaymentsDto.BankBranchId)
                .NotEmpty().WithMessage("Bank Branch Id Cannot Be Empty.")
                .NotNull().WithMessage("Bank Branch Id Is Required.")
                .GreaterThan(Convert.ToByte(0)).WithMessage("Bank Branch Id Should Be Greater Than 0.");
        }
    }
}