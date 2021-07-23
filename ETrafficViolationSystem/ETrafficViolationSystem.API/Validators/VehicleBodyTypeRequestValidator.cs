using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class VehicleBodyRequestValidator : AbstractValidator<VehicleBodyTypeRequest>
    {
        public VehicleBodyRequestValidator()
        {
            RuleFor(x => x.VehicleBodyTypeDto.BodyType)
                .NotEmpty().WithMessage("Body Type Cannot Be Empty.")
                .NotNull().WithMessage("Body Type Is Required.")
                .Matches("^[A-Za-z]*$").WithMessage("Body Type Can Only Contain Letters.")
                .Length(20).WithMessage("Body Type Exceeds 20 Characters Length.");
        }
    }
}