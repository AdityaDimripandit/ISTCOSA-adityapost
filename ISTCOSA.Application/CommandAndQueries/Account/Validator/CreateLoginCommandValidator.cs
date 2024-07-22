using FluentValidation;
using ISTCOSA.Application.CommandAndQuries.Account.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.Account.Validation
{
    public class CreateLoginCommandValidator:AbstractValidator<CreateLoginCommand>
    {
        public CreateLoginCommandValidator()
        {
            RuleFor(v => v.RollNumber)
                .NotEmpty().WithMessage("Roll number is required.")
                .MaximumLength(20).WithMessage("Roll number must not exceed 20 characters.");

            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .MaximumLength(100).WithMessage("Password must not exceed 100 characters.");
        }
    }
}
