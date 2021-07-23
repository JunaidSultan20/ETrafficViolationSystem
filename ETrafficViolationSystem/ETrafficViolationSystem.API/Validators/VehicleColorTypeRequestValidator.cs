using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class VehicleColorTypeRequestValidator : AbstractValidator<VehicleColorTypeRequest>
    {
        public VehicleColorTypeRequestValidator()
        {
            RuleFor(x => x.VehicleColorTypeDto.ColorTypeTitle)
                .NotEmpty().WithMessage("Color Type Title Cannot Be Empty.")
                .NotNull().WithMessage("Color Type Title Is Required.")
                .Matches("^[A-Za-z]*$").WithMessage("Color Type Title Can Only Contain Letters.")
                .Length(50).WithMessage("Color Type Title Exceeds 50 Characters Length.");
        }
    }
}