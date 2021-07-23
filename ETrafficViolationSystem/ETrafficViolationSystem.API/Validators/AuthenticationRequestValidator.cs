using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
    {
        public AuthenticationRequestValidator()
        {
            RuleFor(x => x.AuthenticationDto.Email)
                .NotEmpty().WithMessage("Email Cannot Be Empty.")
                .NotNull().WithMessage("Email Is Required.");

            RuleFor(x => x.AuthenticationDto.Password)
                .NotEmpty().WithMessage("Password Cannot Be Empty.")
                .NotNull().WithMessage("Password Is Required.")
                .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[\/!@$*]).{8,}$").WithMessage(
                    "Password Must Contain At Least One Upper Case Letter, One Lower Case Letter, One Digit And One Special Character {/, !, @, $, *} And Minimum 8 Characters In Length.");
        }
    }
}