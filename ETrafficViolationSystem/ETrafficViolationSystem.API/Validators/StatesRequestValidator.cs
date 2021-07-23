using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class StatesRequestValidator : AbstractValidator<StatesRequest>
    {
        public StatesRequestValidator()
        {
            RuleFor(x => x.StatesDto.StateTitle)
                .NotEmpty().WithMessage("State Title Cannot Be Empty.")
                .NotNull().WithMessage("State Title Is Required.")
                .Matches("^[A-Za-Z0-9-]*$").WithMessage("State Title Can Only Contain Letters And Numbers.")
                .Length(50).WithMessage("State Tile Exceeds 50 Characters Length.");

            RuleFor(x => x.StatesDto.CountryId)
                .NotEmpty().WithMessage("Country Id Cannot Be Empty.")
                .NotNull().WithMessage("Country Id Is Required.")
                .GreaterThan(0).WithMessage("Country Id Should Be Greater Than 0.");
        }
    }
}