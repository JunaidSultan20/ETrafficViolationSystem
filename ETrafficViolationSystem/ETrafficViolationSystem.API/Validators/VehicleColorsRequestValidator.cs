using System;
using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class VehicleColorsRequestValidator : AbstractValidator<VehicleColorsRequest>
    {
        public VehicleColorsRequestValidator()
        {
            RuleFor(x => x.VehicleColorsDto.ColorTypeId)
                .NotEmpty().WithMessage("Color Type Id Cannot Be Empty.")
                .NotNull().WithMessage("Color Type Id Is Required.")
                .GreaterThan(Convert.ToByte(0)).WithMessage("Color Type Id Should Be Greater Than 0.");

            RuleFor(x => x.VehicleColorsDto.ColorName)
                .NotEmpty().WithMessage("Color Name Cannot Be Empty.")
                .NotNull().WithMessage("Color Name Is Required.")
                .Matches("^[A-Za-z0-9]*$").WithMessage("Color Name Can Only Contain Alphanumerics.")
                .Length(50).WithMessage("Color Name Exceeds 50 Characters Length.");
            
            RuleFor(x => x.VehicleColorsDto.ColorCode)
                .NotEmpty().WithMessage("Color Code Cannot Be Empty.")
                .NotNull().WithMessage("Color Code Is Required.")
                .Matches("^[A-Za-z0-9]*$").WithMessage("Color Code Can Only Contain Alphanumerics.")
                .Length(50).WithMessage("Color Code Exceeds 50 Characters Length.");
        }
    }
}