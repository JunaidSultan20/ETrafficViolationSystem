using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class CarMakeRequestValidator : AbstractValidator<CarMakeRequest>
    {
        public CarMakeRequestValidator()
        {
            RuleFor(x => x.CarMakeDto.MakeTitle)
                .NotEmpty().WithMessage("Make Title Cannot Be Empty.")
                .NotNull().WithMessage("Make Title Is Required.")
                .Matches("^[A-Za-z]*$").WithMessage("Make Title Can Only Contain Letters.")
                .Length(50).WithMessage("Make Title Length Exceeds 50 Characters.");

            RuleFor(x => x.CarMakeDto.OriginCountryId)
                .NotEmpty().WithMessage("Origin Country Id Cannot Be Empty.")
                .NotNull().WithMessage("Origin Country Id Is Required.")
                .GreaterThan(0).WithMessage("Origin Country Id Must Be Greater Than 0");
        }
    }
}