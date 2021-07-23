using System;
using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class DesignationRequestValidator : AbstractValidator<DesignationRequest>
    {
        public DesignationRequestValidator()
        {
            RuleFor(x => x.DesignationDto.Title)
                .NotEmpty().WithMessage("Title Cannot Be Empty.")
                .NotNull().WithMessage("Title Is Required.")
                .Matches("^[A-Za-Z]*$").WithMessage("Title Can Only Contain Letters.")
                .Length(50).WithMessage("Title Exceeds 50 Characters Length.");

            RuleFor(x => x.DesignationDto.ReportsTo)
                .GreaterThan(Convert.ToByte(0)).WithMessage("Reports To Should Be Greater Than 0.");
        }
    }
}