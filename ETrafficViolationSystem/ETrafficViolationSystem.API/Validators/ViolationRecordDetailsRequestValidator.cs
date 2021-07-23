using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class ViolationRecordDetailsRequestValidator : AbstractValidator<ViolationRecordDetailsRequest>
    {
        public ViolationRecordDetailsRequestValidator()
        {
            RuleFor(x => x.ViolationRecordDetailsDto.ViolationId)
                .NotEmpty().WithMessage("Violation Id Cannot Be Empty.")
                .NotNull().WithMessage("Violation Id Is Required.")
                .GreaterThan(0).WithMessage("Violation Id Should Be Greater Than 0.");

            RuleFor(x => x.ViolationRecordDetailsDto.InfractionId)
                .NotEmpty().WithMessage("Infraction Id Cannot Be Empty.")
                .NotNull().WithMessage("Infraction Id Is Required.")
                .GreaterThan(0).WithMessage("Infraction Id Should Be Greater Than 0.");
        }
    }
}