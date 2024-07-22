using FluentValidation;
using ISTCOSA.Application.CommandAndQuries.UserPersonal.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.UserPersonal.Validation
{
    public class CreateUserPersonalCommandValidator : AbstractValidator<CreateUserPersonalCommand>
    {
        public CreateUserPersonalCommandValidator()
        {
            RuleFor(v => v.ISTCAbout)
                .NotEmpty().WithMessage("ISTC About is required.")
                .MaximumLength(250).WithMessage("ISTC About must not exceed 250 characters.");

            RuleFor(v => v.MaritalStatus)
                .NotEmpty().WithMessage("Marital status is required.")
                .Must(status => status == "Single" || status == "Married" || status == "Divorced" || status == "Widowed")
                .WithMessage("Marital status must be 'Single', 'Married', 'Divorced', or 'Widowed'.");

            RuleFor(v => v.WhatsappNumber)
                .NotEmpty().WithMessage("WhatsApp number is required.")
                .Matches(@"^\d{10}$").WithMessage("Whatsapp number must be exactly 10 digits.");

            RuleFor(v => v.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(500).WithMessage("Address must not exceed 500 characters.");
        }
    }
}
