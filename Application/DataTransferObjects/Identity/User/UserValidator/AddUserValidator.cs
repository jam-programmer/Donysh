using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DataTransferObjects.Identity.User.UserValidator
{
    public class AddUserValidator:AbstractValidator<AddUserDto>
    {
        public AddUserValidator()
        {
            RuleFor(f => f.Role).NotNull().WithMessage("Please select a user role.");
            RuleFor(f => f.UserName).NotNull().WithMessage("The user name cannot be empty.");
            RuleFor(f => f.Email).EmailAddress().WithMessage("The email address is invalid.");
            RuleFor(f => f.PhoneNumber).NotNull().WithMessage("The phone number cannot be empty.");
            RuleFor(f => f.Password)
                .Equal(e => e.PasswordConfirmed)
                .When(w=>!string.IsNullOrEmpty(w.Password)).WithMessage("The password is not the same.");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Your password cannot be empty")
                .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");

        }
    }
}
