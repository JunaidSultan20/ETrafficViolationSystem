using System;
using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class VehiclesRequestValidator : AbstractValidator<VehiclesRequest>
    {
        public VehiclesRequestValidator()
        {
            RuleFor(x => x.VehiclesDto.ChassisNo)
                .NotEmpty().WithMessage("Chassis No Cannot Be Empty.")
                .NotNull().WithMessage("Chassis No Is Required.")
                .Matches("^[A-Za-z0-9]*$").WithMessage("Chassis No Can Only Contain Alphanumerics.")
                .Length(50).WithMessage("Chassis No Exceeds 50 Characters Length.");

            RuleFor(x => x.VehiclesDto.EngineNo)
                .NotEmpty().WithMessage("Engine No Cannot Be Empty.")
                .NotNull().WithMessage("Engine No Is Required.")
                .Matches("^[A-Za-z0-9]*$").WithMessage("Engine No Can Only Contain Alphanumerics.")
                .Length(50).WithMessage("Engine No Exceeds 50 Characters Length.");

            RuleFor(x => x.VehiclesDto.FrameNo)
                .NotEmpty().WithMessage("Frame No Cannot Be Empty.")
                .NotNull().WithMessage("Frame No Is Required.")
                .Matches("^[A-Za-z0-9]*$").WithMessage("Frame No Can Only Contain Alphanumerics.")
                .Length(50).WithMessage("Frame No Exceeds 50 Characters Length.");

            RuleFor(x => x.VehiclesDto.MakeId)
                .NotEmpty().WithMessage("Make Id Cannot Be Empty.")
                .NotNull().WithMessage("Make Id Is Required.")
                .GreaterThan(Convert.ToInt16(0)).WithMessage("Make Id Should Be Greater Than 0.");

            RuleFor(x => x.VehiclesDto.Year)
                .NotEmpty().WithMessage("Year Cannot Be Empty.")
                .NotNull().WithMessage("Year Is Required.");

            RuleFor(x => x.VehiclesDto.CategoryId)
                .NotEmpty().WithMessage("Category Id Cannot Be Empty.")
                .NotNull().WithMessage("Category Id Is Required.")
                .Matches("^[A-Za-z0-9]*$").WithMessage("Category Id Can Only Contain Alphanumerics.");

            RuleFor(x => x.VehiclesDto.BodyTypeId)
                .NotEmpty().WithMessage("Body Type Id Cannot Be Empty.")
                .NotNull().WithMessage("Body Type Id Is Required.")
                .GreaterThan(Convert.ToByte(0)).WithMessage("Body Type Id Should Be Greater Than 0.");

            RuleFor(x => x.VehiclesDto.ClassId)
                .NotEmpty().WithMessage("Class Id Cannot Be Empty.")
                .NotNull().WithMessage("Class Id Is Required.")
                .GreaterThan(Convert.ToByte(0)).WithMessage("Class Id Should Be Greater Than 0.");

            RuleFor(x => x.VehiclesDto.Capacity)
                .NotEmpty().WithMessage("Capacity Cannot Be Empty.")
                .NotNull().WithMessage("Capacity Is Required.")
                .GreaterThan(Convert.ToByte(0)).WithMessage("Capacity Should Be Greater Than 0.");

            RuleFor(x => x.VehiclesDto.HorsePower)
                .NotEmpty().WithMessage("Horse Power Cannot Be Empty.")
                .NotNull().WithMessage("Horse Power Is Required.")
                .GreaterThan(Convert.ToInt16(0)).WithMessage("Horse Power Should Be Greater Than 0.");

            RuleFor(x => x.VehiclesDto.Cylinders)
                .NotEmpty().WithMessage("Cylinders Cannot Be Empty.")
                .NotNull().WithMessage("Cylinders Is Required.")
                .GreaterThan(Convert.ToByte(0)).WithMessage("Cylinders Should Be Greater Than 0.");

            RuleFor(x => x.VehiclesDto.ColorId)
                .NotEmpty().WithMessage("Color Id Cannot Be Empty.")
                .NotNull().WithMessage("Color Id Is Required.")
                .GreaterThan(Convert.ToInt16(0)).WithMessage("Body Type Id Should Be Greater Than 0.");
        }
    }
}