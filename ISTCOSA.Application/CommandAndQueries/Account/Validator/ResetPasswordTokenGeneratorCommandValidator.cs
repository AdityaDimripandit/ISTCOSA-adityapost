using FluentValidation;
using ISTCOSA.Application.CommandAndQuries.Account.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.Account.Validation
{
    public class ResetPasswordTokenGeneratorCommandValidator:AbstractValidator<CreateResetPasswordTokenGenerateCommand>
    {
        public ResetPasswordTokenGeneratorCommandValidator()
        {
            RuleFor(v => v.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }
}
