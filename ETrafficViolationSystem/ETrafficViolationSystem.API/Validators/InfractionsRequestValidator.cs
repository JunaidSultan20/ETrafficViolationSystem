using System;
using ETrafficViolationSystem.Entities.Request;
using FluentValidation;

namespace ETrafficViolationSystem.API.Validators
{
    public class InfractionsRequestValidator : AbstractValidator<InfractionsRequest>
    {
        public InfractionsRequestValidator()
        {
            RuleFor(x => x.InfractionsDto.Description)
                .NotEmpty().WithMessage("Description Cannot Be Empty.")
                .NotNull().WithMessage("Description Is Required.")
                .Matches("^[A-Za-z0-9]*$").WithMessage("Description Can Only Contain Letters And Digits.")
                .Length(255).WithMessage("Description Exceeds 255 Characters Length.");

            RuleFor(x => x.InfractionsDto.Penalty)
                .NotEmpty().WithMessage("Penalty Cannot Be Empty.")
                .NotNull().WithMessage("Penalty Is Required.")
                .GreaterThanOrEqualTo(100).WithMessage("Penalty Should Be Greater Than Or Equal To 100")
                .LessThanOrEqualTo(5000).WithMessage("Penalty Should Be Less Than Or Equal To 5000");

            RuleFor(x => x.InfractionsDto.Points)
                .NotEmpty().WithMessage("Points Cannot Be Empty.")
                .NotNull().WithMessage("Points Is Required.")
                .GreaterThanOrEqualTo(Convert.ToByte(1)).WithMessage("Penalty Should Be Greater Or Equal To 1.")
                .LessThanOrEqualTo(Convert.ToByte(20)).WithMessage("Penalty Should Be Less Than Or Equal To 20.");
        }
    }
}