using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DataTransferObjects.Identity.Role.RoleValidator
{
    public class AddRoleValidator:AbstractValidator<AddRoleDto>
    {
        public AddRoleValidator()
        {
            RuleFor(f => f.RoleName).NotNull().WithMessage("The role name is required.");

        }
    }
}
