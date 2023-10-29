using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DataTransferObjects.Identity.User.UserValidator
{
    public class SignInValidator:AbstractValidator<SignInDto>
    {
        public SignInValidator()
        {
            RuleFor(f => f.UserName).NotNull().WithMessage("Enter username or email.");
            RuleFor(f => f.Password).NotNull().WithMessage("Enter your password.");

        }
    }
}
