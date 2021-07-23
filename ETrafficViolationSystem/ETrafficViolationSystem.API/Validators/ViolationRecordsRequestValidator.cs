using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class ViolationRecordsRequestValidator : AbstractValidator<ViolationRecordsRequest>
    {
        public ViolationRecordsRequestValidator()
        {
            RuleFor(x => x.ViolationRecordsDto.LicenseNo)
                .NotEmpty().WithMessage("License No Cannot Be Empty.")
                .NotNull().WithMessage("License No Is Required.")
                .GreaterThan(0).WithMessage("License No Should Be Greater Than 0.");

            RuleFor(x => x.ViolationRecordsDto.VehicleDetailId)
                .NotEmpty().WithMessage("Vehicle Detail Id Cannot Be Empty.")
                .NotNull().WithMessage("Vehicle Detail Id Is Required.")
                .GreaterThan(0).WithMessage("Vehicle Detail Id Should Be Greater Than 0.");

            RuleFor(x => x.ViolationRecordsDto.CityId)
                .NotEmpty().WithMessage("City Id Cannot Be Empty.")
                .NotNull().WithMessage("City Id Is Required.")
                .GreaterThan(0).WithMessage("City Id Should Be Greater Than 0.");

            RuleFor(x => x.ViolationRecordsDto.LicenseNo)
                .NotEmpty().WithMessage("License No Cannot Be Empty.")
                .NotNull().WithMessage("License No Is Required.")
                .GreaterThan(0).WithMessage("License No Should Be Greater Than 0.");

            RuleFor(x => x.ViolationRecordsDto.LocationLatitude)
                .NotEmpty().WithMessage("Location Latitude Cannot Be Empty.")
                .NotNull().WithMessage("Location Latitude Is Required.")
                .Length(50).WithMessage("Location Latitude Exceeds 50 Characters Length.");

            RuleFor(x => x.ViolationRecordsDto.LocationLongitude)
                .NotEmpty().WithMessage("Location Longitude Cannot Be Empty.")
                .NotNull().WithMessage("Location Longitude Is Required.")
                .Length(50).WithMessage("Location Longitude Exceeds 50 Characters Length.");

            RuleFor(x => x.ViolationRecordsDto.DateTime)
                .NotEmpty().WithMessage("Date Time Cannot Be Empty.")
                .NotNull().WithMessage("Date Time Is Required.");

            RuleFor(x => x.ViolationRecordsDto.PointsDeducted)
                .NotEmpty().WithMessage("Points Deducted Cannot Be Empty.")
                .NotNull().WithMessage("Points Deducted Is Required.")
                .GreaterThanOrEqualTo(1).WithMessage("Points Deducted Should Be Greater Than Or Equal To 1.")
                .LessThanOrEqualTo(20).WithMessage("Points Deducted Should Be Less Than Or Equal To 20.");

            RuleFor(x => x.ViolationRecordsDto.ChallanNo)
                .NotEmpty().WithMessage("Challan No Cannot Be Empty.")
                .NotNull().WithMessage("Challan No Is Required.");

            RuleFor(x => x.ViolationRecordsDto.BookedBy)
                .NotEmpty().WithMessage("Booked By Cannot Be Empty.")
                .NotNull().WithMessage("Booked By Is Required.")
                .Matches("^[A-Za-z0-9-]*$").WithMessage("Booked By Can Only Contain Alphanumerics.");
        }
    }
}