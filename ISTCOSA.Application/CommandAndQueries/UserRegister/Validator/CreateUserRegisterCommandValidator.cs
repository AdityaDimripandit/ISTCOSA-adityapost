using FluentValidation;
using ISTCOSA.Application.CommandAndQuries.UserRegister.Commands.CreateUserRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ISTCOSA.Application.CommandAndQuries.UserRegister.Validation
{
    public class CreateUserRegisterCommandValidator:AbstractValidator<CreateUserRegisterCommands>
    {
        public CreateUserRegisterCommandValidator()
        {
            RuleFor(v => v.RollNumberId)
                .NotEmpty().WithMessage("Roll number ID is required.")
                .GreaterThan(0).WithMessage("Roll number ID must be greater than 0.");

            RuleFor(v => v.CityId)
                .NotEmpty().WithMessage("City ID is required.")
                .GreaterThan(0).WithMessage("City ID must be greater than 0.");

            RuleFor(v => v.FullName)
                .NotEmpty().WithMessage("Full name is required.")
                .MaximumLength(50).WithMessage("Full name must not exceed 50 characters.");

            RuleFor(v => v.Gender)
                .NotEmpty().WithMessage("Gender is required.")
                .Must(g => g == "Male" || g == "Female" || g == "Other").WithMessage("Gender must be 'Male', 'Female', or 'Other'.");

            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(100).WithMessage("Email must not exceed 100 characters.");

            RuleFor(v => v.Pincode)
                .NotEmpty().WithMessage("Pincode is required.")
                .Matches(@"^\d{6}$").WithMessage("Pincode must be exactly 6 digits.");

            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .MaximumLength(100).WithMessage("Password must not exceed 100 characters.");

            RuleFor(v => v.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\d{10}$").WithMessage("Phone number must be exactly 10 digits.");

            RuleFor(v => v.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required.")
                .Must(BeAValidDate).WithMessage("Invalid date of birth.")
                .LessThan(DateTime.Now).WithMessage("Date of birth must be in the past.");
        }

        private bool BeAValidDate(DateTime? date)
        {
            return !date.Equals(default(DateTime));
        }

    }
}
