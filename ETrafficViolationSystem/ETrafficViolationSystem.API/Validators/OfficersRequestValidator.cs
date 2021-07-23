using System;
using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class OfficersRequestValidator : AbstractValidator<OfficersRequest>
    {
        public OfficersRequestValidator()
        {
            RuleFor(x => x.OfficersDto.OfficerId)
                .NotEmpty().WithMessage("Officer Id Cannot Be Empty.")
                .NotNull().WithMessage("Officer Id Is Required.")
                .Matches("^[A-Za-z0-9-]*$").WithMessage("Officer Id Can Only Contain Alphanumerics.")
                .Length(50).WithMessage("Officer Id Exceeds 50 Characters Length.");

            RuleFor(x => x.OfficersDto.FirstName)
                .NotEmpty().WithMessage("First Name Cannot Be Empty.")
                .NotNull().WithMessage("First Name Is Required.")
                .Matches("^[A-Za-z]*$").WithMessage("First Name Can Only Contain Letters.")
                .Length(20).WithMessage("First Name Exceeds 20 Characters Length.");

            RuleFor(x => x.OfficersDto.MiddleName)
                .Matches("^[A-Za-z]*$").WithMessage("Middle Name Can Only Contain Letters.")
                .Length(20).WithMessage("Middle Name Exceeds 20 Characters Length.");

            RuleFor(x => x.OfficersDto.LastName)
                .NotEmpty().WithMessage("Last Name Cannot Be Empty.")
                .NotNull().WithMessage("Last Name Is Required.")
                .Matches("^[A-Za-z]*$").WithMessage("Last Name Can Only Contain Letters.")
                .Length(20).WithMessage("Last Name Exceeds 20 Characters Length.");

            RuleFor(x => x.OfficersDto.FatherName)
                .NotEmpty().WithMessage("Father Name Cannot Be Empty.")
                .NotNull().WithMessage("Father Name Is Required.")
                .Matches("^[A-Za-z]*$").WithMessage("Father Name Can Only Contain Letters.")
                .Length(50).WithMessage("Father Name Exceeds 50 Characters Length.");

            RuleFor(x => x.OfficersDto.Cnic)
                .NotEmpty().WithMessage("CNIC Cannot Be Empty.")
                .NotNull().WithMessage("CNIC Is Required.")
                .Matches("^[0-9]{5}-[0-9]{7}-[0-9]{1}$").WithMessage("CNIC Can Only Contain Numbers.")
                .Length(15).WithMessage("CNIC Exceeds 15 Characters Length.");

            RuleFor(x => x.OfficersDto.Dob)
                .NotEmpty().WithMessage("Dob Cannot Be Empty.")
                .NotNull().WithMessage("Dob Is Required.")
                .LessThan(x => DateTime.Now).WithMessage("Dob Should Be Less Than Current Date.");

            RuleFor(x => x.OfficersDto.Gender)
                .NotEmpty().WithMessage("Gender Cannot Be Empty.")
                .NotNull().WithMessage("Gender Is Required.")
                .GreaterThanOrEqualTo(Convert.ToByte(0)).WithMessage("Gender Should Be Greater Than Or Equal To 1.")
                .LessThanOrEqualTo(Convert.ToByte(3)).WithMessage("Gender Should Be Less Than Or Equal To 3.");

            RuleFor(x => x.OfficersDto.Religion)
                .NotEmpty().WithMessage("Religion Cannot Be Empty.")
                .NotNull().WithMessage("Religion Is Required.")
                .Matches("^[A-Za-z0-9]*$").WithMessage("Religion Can Only Contain Alphanumerics.")
                .Length(50).WithMessage("Religion Exceeds 50 Characters Length.");

            RuleFor(x => x.OfficersDto.PostalAddress)
                .NotEmpty().WithMessage("Postal Address Cannot Be Empty.")
                .NotNull().WithMessage("Postal Address Is Required.")
                .Matches(@"^[A-Za-z0-9-/\#]*$").WithMessage("Postal Address Can Only Contain Alphanumerics And Special Characters {-, /, #}.")
                .Length(255).WithMessage("Postal Address Exceeds 255 Characters Length.");

            RuleFor(x => x.OfficersDto.CityId)
                .NotEmpty().WithMessage("City Id Cannot Be Empty.")
                .NotNull().WithMessage("City Id Is Required.")
                .GreaterThanOrEqualTo(1).WithMessage("City Id Should Be Greater Than Or Equal To 1.");

            RuleFor(x => x.OfficersDto.PermanentAddress)
                .NotEmpty().WithMessage("Permanent Address Cannot Be Empty.")
                .NotNull().WithMessage("Permanent Address Is Required.")
                .Matches(@"^[A-Za-z0-9-/\#]*$").WithMessage("Permanent Address Can Only Contain Alphanumerics And Special Characters {-, /, #}.")
                .Length(255).WithMessage("Permanent Address Exceeds 255 Characters Length.");

            RuleFor(x => x.OfficersDto.MobileNumber)
                .NotEmpty().WithMessage("Mobile Number Cannot Be Empty.")
                .NotNull().WithMessage("Mobile Number Is Required.")
                .Matches("^[0-9]{20}").WithMessage("Mobile Number Can Only Contain Digits.")
                .Length(20).WithMessage("Mobile Number Exceeds 20 Characters Length.");

            RuleFor(x => x.OfficersDto.HomePhone)
                .Matches("^[0-9]{20}").WithMessage("Home Phone Can Only Contain Digits.")
                .Length(20).WithMessage("Home Phone Exceeds 20 Characters Length.");

            RuleFor(x => x.OfficersDto.Email)
                .EmailAddress().WithMessage("Email Address Is Invalid.")
                .Length(255).WithMessage("Email Exceeds 255 Characters Length.");

            RuleFor(x => x.OfficersDto.BloodGroupId)
                .NotEmpty().WithMessage("Blood Group Id Cannot Be Empty.")
                .NotNull().WithMessage("Blood Group Id Is Required.")
                .GreaterThanOrEqualTo(Convert.ToByte(1)).WithMessage("Blood Group Id Should Be Greater Than Or Equal To 1.")
                .LessThanOrEqualTo(Convert.ToByte(8)).WithMessage("Blood Group Id Should Be Less Than Or Equal To 8.");

            RuleFor(x => x.OfficersDto.DesignationId)
                .NotEmpty().WithMessage("Designation Id Cannot Be Empty.")
                .NotNull().WithMessage("Designation Id Is Required.")
                .GreaterThanOrEqualTo(Convert.ToByte(1)).WithMessage("Designation Id Should Be Greater Than Or Equal To 1.");

            RuleFor(x => x.OfficersDto.OfficerImage)
                .NotEmpty().WithMessage("Officer Image Cannot Be Empty.")
                .NotNull().WithMessage("Officer Image Is Required.")
                .Length(255).WithMessage("Officer Image Exceeds 255 Characters Length.");
        }
    }
}