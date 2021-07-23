using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class BankBranchRequestValidator : AbstractValidator<BankBranchRequest>
    {
        public BankBranchRequestValidator()
        {
            RuleFor(x => x.BankBranchDto.BranchCode)
                .NotEmpty().WithMessage("Branch Code Cannot Be Empty.")
                .NotNull().WithMessage("Branch Code Is Required.");

            RuleFor(x => x.BankBranchDto.BranchTitle)
                .NotEmpty().WithMessage("Branch Title Cannot Be Empty.")
                .NotNull().WithMessage("Branch Title Is Required")
                .Matches("^[A-Za-z0-9]*$").WithMessage("Country Title Can Only Contain Letters.")
                .Length(255).WithMessage("Branch Tile Exceeds 255 Characters");

            RuleFor(x => x.BankBranchDto.BankId)
                .NotEmpty().WithMessage("Bank Id Cannot Be Empty.")
                .NotNull().WithMessage("Bank Id Is Required.");

            RuleFor(x => x.BankBranchDto.CityId)
                .NotEmpty().WithMessage("City Id Cannot Be Empty.")
                .NotNull().WithMessage("City Id Is Required.");
        }
    }
}