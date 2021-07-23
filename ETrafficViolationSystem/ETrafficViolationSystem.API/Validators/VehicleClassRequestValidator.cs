using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class VehicleClassRequestValidator : AbstractValidator<VehicleClassRequest>
    {
        public VehicleClassRequestValidator()
        {
            RuleFor(x => x.VehicleClassDto.ClassTitle)
                .NotEmpty().WithMessage("Class Title Cannot Be Empty.")
                .NotNull().WithMessage("Class Title Is Required.")
                .Matches("^[A-Za-z]*$").WithMessage("Class Title Can Only Contain Letters.")
                .Length(10).WithMessage("Class Title Exceeds 10 Characters Length.");
        }
    }
}