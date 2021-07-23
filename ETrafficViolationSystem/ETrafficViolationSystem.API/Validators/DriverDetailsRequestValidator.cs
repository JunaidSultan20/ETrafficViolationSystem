using System;
using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class DriverDetailsRequestValidator : AbstractValidator<DriverDetailsRequest>
    {
        public DriverDetailsRequestValidator()
        {
            RuleFor(x => x.DriverDetailsDto.FirstName)
                .NotEmpty().WithMessage("First Name Cannot Be Empty.")
                .NotNull().WithMessage("First Name Is Required.")
                .Matches("^[A-Za-z]*$").WithMessage("First Name Can Only Contain Letters.")
                .Length(20).WithMessage("First Name Exceeds 20 Characters Length.");

            RuleFor(x => x.DriverDetailsDto.MiddleName)
                .NotEmpty().WithMessage("Middle Name Cannot Be Empty.")
                .Matches("^[A-Za-z]*$").WithMessage("Middle Name Can Only Contain Letters.")
                .Length(20).WithMessage("Middle Name Exceeds 20 Characters Length.");

            RuleFor(x => x.DriverDetailsDto.LastName)
                .NotEmpty().WithMessage("Last Name Cannot Be Empty.")
                .NotNull().WithMessage("Last Name Is Required.")
                .Matches("^[A-Za-z]*$").WithMessage("Last Name Can Only Contain Letters.")
                .Length(20).WithMessage("Last Name Exceeds 20 Characters Length.");

            RuleFor(x => x.DriverDetailsDto.FatherName)
                .NotEmpty().WithMessage("Father Name Cannot Be Empty.")
                .NotNull().WithMessage("Father Name Is Required.")
                .Matches("^[A-Za-z]*$").WithMessage("Father Name Can Only Contain Letters.")
                .Length(50).WithMessage("Father Name Exceeds 50 Characters Length.");

            RuleFor(x => x.DriverDetailsDto.CNIC)
                .NotEmpty().WithMessage("CNIC Cannot Be Empty.")
                .NotNull().WithMessage("CNIC Is Required.")
                .Matches("^[0-9]{5}-[0-9]{7}-[0-9]{1}$").WithMessage("CNIC Can Only Contain Numbers.")
                .Length(15).WithMessage("CNIC Exceeds 15 Characters Length.");

            RuleFor(x => x.DriverDetailsDto.Dob)
                .NotEmpty().WithMessage("DOB Cannot Be Empty.")
                .NotNull().WithMessage("DOB Name Is Required.")
                .LessThan(x => DateTime.Now).WithMessage("DOB Cannot Be Same As Current Date.");

            RuleFor(x => x.DriverDetailsDto.Gender)
                .NotEmpty().WithMessage("Gender Cannot Be Empty.")
                .NotNull().WithMessage("Gender Is Required.")
                .GreaterThan(Convert.ToByte(0)).WithMessage("Gender Value Should Be Greater Than 0.")
                .LessThan(Convert.ToByte(4)).WithMessage("Gender Value Should Be Less Than 4.");

            RuleFor(x => x.DriverDetailsDto.Religion)
                .NotEmpty().WithMessage("Religion Cannot Be Empty.")
                .NotNull().WithMessage("Religion Is Required.")
                .GreaterThan(Convert.ToByte(1)).WithMessage("Religion Value Should Be Greater Than 0.");

            RuleFor(x => x.DriverDetailsDto.PostalAddress)
                .NotEmpty().WithMessage("Postal Address Cannot Be Empty.")
                .NotNull().WithMessage("Postal Address Is Required.")
                .Matches("^[A-Za-Z0-9-/]*$").WithMessage("Postal Address Can Only Contain Alphanumerics And Special Characters(-, /).")
                .Length(255).WithMessage("Postal Address Length Exceeds 255 Characters Length.");

            RuleFor(x => x.DriverDetailsDto.CityId)
                .NotEmpty().WithMessage("City Id Cannot Be Empty.")
                .NotNull().WithMessage("City Id Is Required.")
                .GreaterThan(0).WithMessage("City Id Should Be Greater Than 0.");

            RuleFor(x => x.DriverDetailsDto.PermanentAddress)
                .NotEmpty().WithMessage("Permanent Address Cannot Be Empty.")
                .NotNull().WithMessage("Permanent Address Is Required.")
                .Matches("^[A-Za-Z0-9-/]*$").WithMessage("Permanent Address Can Only Contain Alphanumerics And Special Characters(-, /).")
                .Length(255).WithMessage("Permanent Address Length Exceeds 255 Characters Length.");

            RuleFor(x => x.DriverDetailsDto.MobileNumber)
                .NotEmpty().WithMessage("Mobile Number Cannot Be Empty.")
                .NotNull().WithMessage("Mobile Number Is Required.")
                .Matches("^[0-9]{20}").WithMessage("Mobile Number Can Only Contain Digits.")
                .Length(20).WithMessage("Permanent Address Length Exceeds 20 Characters Length.");

            RuleFor(x => x.DriverDetailsDto.HomePhone)
                .Matches("^[0-9]*{20}").WithMessage("Mobile Phone Can Only Contain Digits.")
                .Length(20).WithMessage("Mobile Phone Length Exceeds 20 Characters Length.");

            RuleFor(x => x.DriverDetailsDto.Email)
                .EmailAddress().WithMessage("Email Address Is Not Valid.")
                .Length(255).WithMessage("Email Address Exceeds 255 Characters Length.");

            RuleFor(x => x.DriverDetailsDto.BloodGroupId)
                .NotEmpty().WithMessage("Blood Group Id Cannot Be Empty.")
                .NotNull().WithMessage("Blood Group Id Is Required.")
                .GreaterThan(Convert.ToByte(0)).WithMessage("Blood Group Id Should Be Greater Than 0.")
                .LessThan(Convert.ToByte(9)).WithMessage("Blood Group Id Should Be Less Than 9.");

            RuleFor(x => x.DriverDetailsDto.Height)
                .NotEmpty().WithMessage("Height Cannot Be Empty.")
                .NotNull().WithMessage("Height Is Required.")
                .Matches("^[0-9]{1}'[0-9]{2}\"$").WithMessage("Height Is Not In Valid Format.")
                .Length(5).WithMessage("Height Exceeds 5 Characters Length.");

            RuleFor(x => x.DriverDetailsDto.Mark)
                .NotEmpty().WithMessage("Mark Cannot Be Empty.")
                .NotNull().WithMessage("Mark Is Required.")
                .Matches("^[A-Za-z0-9]*$").WithMessage("Mark Can Only Contain Alphanumerics.")
                .Length(255).WithMessage("Mark Exceeds 255 Characters Length.");

            RuleFor(x => x.DriverDetailsDto.Disability)
                .NotEmpty().WithMessage("Disability Cannot Be Empty.")
                .NotNull().WithMessage("Disability Is Required.");

            RuleFor(x => x.DriverDetailsDto.DisabilityDescription)
                .NotEmpty().WithMessage("Disability Description Cannot Be Empty.")
                .NotNull().WithMessage("Disability Description Is Required.")
                .Matches("^[A-Za-z0-9]*$").WithMessage("Disability Description Can Only Contain Alphanumerics.");
        }
    }
}