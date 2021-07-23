using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class CarModelRequestValidator : AbstractValidator<CarModelRequest>
    {
        public CarModelRequestValidator()
        {
            RuleFor(x => x.CarModelDto.ModelId)
                .NotEmpty().WithMessage("Model Id Cannot Be Empty.")
                .NotNull().WithMessage("Model Id Is Required.")
                .Matches("^[A-Za-Z0-9]*$").WithMessage("Model Id Can Only Contain Letters And Numbers.")
                .Length(20).WithMessage("Model Id Length Exceeds 20 Characters.");

            RuleFor(x => x.CarModelDto.ModelTitle)
                .NotEmpty().WithMessage("Model Title Cannot Be Empty.")
                .NotNull().WithMessage("Model Title Is Required.")
                .Matches("^[A-Za-Z0-9]*$").WithMessage("Model Title Can Only Contain Letters.")
                .Length(50).WithMessage("Model Title Length Exceeds 50 Characters.");

            RuleFor(x => x.CarModelDto.ProductionYear)
                .NotEmpty().WithMessage("Production Year Cannot Be Empty.")
                .NotNull().WithMessage("Production Year Is Required.");

            RuleFor(x => x.CarModelDto.MakeId)
                .NotEmpty().WithMessage("Make Id Cannot Be Empty.")
                .NotNull().WithMessage("Make Id Is Required.");
        }
    }
}