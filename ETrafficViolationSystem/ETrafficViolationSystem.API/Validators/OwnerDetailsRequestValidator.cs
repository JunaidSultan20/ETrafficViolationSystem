using System;
using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class OwnerDetailsRequestValidator : AbstractValidator<OwnerDetailsRequest>
    {
        public OwnerDetailsRequestValidator()
        {
            RuleFor(x => x.OwnerDetailsDto.FirstName)
                .NotEmpty().WithMessage("First Name Cannot Be Empty.")
                .NotNull().WithMessage("First Name Is Required.")
                .Matches("^[A-Za-z]*$").WithMessage("First Name Can Only Contain Alphabets.")
                .Length(20).WithMessage("First Name Exceeds 20 Characters Length.");

            RuleFor(x => x.OwnerDetailsDto.MiddleName)
                .Matches("^[A-Za-z]*$").WithMessage("Middle Name Can Only Contain Alphabets.")
                .Length(20).WithMessage("Middle Name Exceeds 20 Characters Length.");

            RuleFor(x => x.OwnerDetailsDto.LastName)
                .NotEmpty().WithMessage("Last Name Cannot Be Empty.")
                .NotNull().WithMessage("Last Name Is Required.")
                .Matches("^[A-Za-z]*$").WithMessage("Last Name Can Only Contain Alphabets.")
                .Length(20).WithMessage("Last Name Exceeds 20 Characters Length.");

            RuleFor(x => x.OwnerDetailsDto.FatherName)
                .NotEmpty().WithMessage("Father Name Cannot Be Empty.")
                .NotNull().WithMessage("Father Name Is Required.")
                .Matches("^[A-Za-z]*$").WithMessage("Father Name Can Only Contain Alphabets.")
                .Length(50).WithMessage("Father Name Exceeds 50 Characters Length.");

            RuleFor(x => x.OwnerDetailsDto.CNIC)
                .NotEmpty().WithMessage("CNIC Cannot Be Empty.")
                .NotNull().WithMessage("CNIC Is Required.")
                .Matches("^[0-9]{5}-[0-9]{7}-[0-9]{1}$").WithMessage("CNIC Can Only Contain Numbers.")
                .Length(15).WithMessage("CNIC Exceeds 15 Characters Length.");

            RuleFor(x => x.OwnerDetailsDto.Dob)
                .NotEmpty().WithMessage("Dob Cannot Be Empty.")
                .NotNull().WithMessage("Dob Is Required.")
                .LessThan(x => DateTime.Now).WithMessage("Dob Should Be Less Than Current Date.");

            RuleFor(x => x.OwnerDetailsDto.Gender)
                .NotEmpty().WithMessage("Gender Cannot Be Empty.")
                .NotNull().WithMessage("Gender Is Required.")
                .GreaterThanOrEqualTo(Convert.ToByte(0)).WithMessage("Gender Should Be Greater Than Or Equal To 1.")
                .LessThanOrEqualTo(Convert.ToByte(3)).WithMessage("Gender Should Be Less Than Or Equal To 3.");

            RuleFor(x => x.OwnerDetailsDto.Religion)
                .NotEmpty().WithMessage("Religion Cannot Be Empty.")
                .NotNull().WithMessage("Religion Is Required.")
                .Matches("^[A-Za-z0-9]*$").WithMessage("Religion Can Only Contain Alphanumerics.")
                .Length(50).WithMessage("Religion Exceeds 50 Characters Length.");

            RuleFor(x => x.OwnerDetailsDto.PostalAddress)
                .NotEmpty().WithMessage("Postal Address Cannot Be Empty.")
                .NotNull().WithMessage("Postal Address Is Required.")
                .Matches(@"^[A-Za-z0-9-/\#]*$").WithMessage("Postal Address Can Only Contain Alphanumerics And Special Characters {-, /, #}.")
                .Length(255).WithMessage("Postal Address Exceeds 255 Characters Length.");

            RuleFor(x => x.OwnerDetailsDto.CityId)
                .NotEmpty().WithMessage("City Id Cannot Be Empty.")
                .NotNull().WithMessage("City Id Is Required.")
                .GreaterThanOrEqualTo(1).WithMessage("City Id Should Be Greater Than Or Equal To 1.");

            RuleFor(x => x.OwnerDetailsDto.PermanentAddress)
                .NotEmpty().WithMessage("Permanent Address Cannot Be Empty.")
                .NotNull().WithMessage("Permanent Address Is Required.")
                .Matches(@"^[A-Za-z0-9-/\#]*$").WithMessage("Permanent Address Can Only Contain Alphanumerics And Special Characters {-, /, #}.")
                .Length(255).WithMessage("Permanent Address Exceeds 255 Characters Length.");

            RuleFor(x => x.OwnerDetailsDto.MobileNumber)
                .NotEmpty().WithMessage("Mobile Number Cannot Be Empty.")
                .NotNull().WithMessage("Mobile Number Is Required.")
                .Matches("^[0-9]{20}").WithMessage("Mobile Number Can Only Contain Digits.")
                .Length(20).WithMessage("Mobile Number Exceeds 20 Characters Length.");

            RuleFor(x => x.OwnerDetailsDto.HomePhone)
                .Matches("^[0-9]{20}").WithMessage("Home Phone Can Only Contain Digits.")
                .Length(20).WithMessage("Home Phone Exceeds 20 Characters Length.");

            RuleFor(x => x.OwnerDetailsDto.Email)
                .EmailAddress().WithMessage("Email Address Is Invalid.")
                .Length(255).WithMessage("Email Exceeds 255 Characters Length.");

            RuleFor(x => x.OwnerDetailsDto.OwnerImage)
                .NotEmpty().WithMessage("Owner Image Cannot Be Empty.")
                .NotNull().WithMessage("Owner Image Is Required.")
                .Length(255).WithMessage("Owner Image Exceeds 255 Characters Length.");
        }
    }
}