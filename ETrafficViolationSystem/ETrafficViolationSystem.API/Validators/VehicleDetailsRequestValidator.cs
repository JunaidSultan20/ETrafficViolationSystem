using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class VehicleDetailsRequestValidator : AbstractValidator<VehicleDetailsRequest>
    {
        public VehicleDetailsRequestValidator()
        {
            RuleFor(x => x.VehicleDetailsDto.VehicleId)
                .NotEmpty().WithMessage("Vehicle Id Cannot Be Empty.")
                .NotNull().WithMessage("Vehicle Id Is Required.")
                .GreaterThan(0).WithMessage("Vehicle Id Should Be Greater Than 0.");

            RuleFor(x => x.VehicleDetailsDto.RegistrationNo)
                .NotEmpty().WithMessage("Registration No Cannot Be Empty.")
                .NotNull().WithMessage("Registration No Is Required.")
                .Matches("[A-Z0-9-]*$").WithMessage("Registration No Can Only Contain Alphanumerics And Special Characters {-}")
                .Length(20).WithMessage("Registration No Exceeds 20 Characters Length.");
            
            RuleFor(x => x.VehicleDetailsDto.RegistrationCityId)
                .NotEmpty().WithMessage("Registration City Id Cannot Be Empty.")
                .NotNull().WithMessage("Registration City Id Is Required.")
                .GreaterThan(0).WithMessage("Registration City Id Should Be Greater Than 0.");
            
            RuleFor(x => x.VehicleDetailsDto.OwnerId)
                .NotEmpty().WithMessage("Owner Id Cannot Be Empty.")
                .NotNull().WithMessage("Owner Id Is Required.")
                .GreaterThan(0).WithMessage("Owner Id Should Be Greater Than 0.");

            RuleFor(x => x.VehicleDetailsDto.ClearanceStatus)
                .NotEmpty().WithMessage("Clearance Status Cannot Be Empty.")
                .NotNull().WithMessage("Clearance Status Is Required.");
        }
    }
}