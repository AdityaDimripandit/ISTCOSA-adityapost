using FluentValidation;
using ISTCOSA.Application.CommandAndQuries.Profession.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.Profession.Validation
{
    public class CreateUserProfessionCommandValidator:AbstractValidator<CreateUserProfessionCommand>
    {
        public CreateUserProfessionCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Profession name is required.")
                .MaximumLength(50).WithMessage("Profession name must not exceed 50 characters.");
        }
    }
}
