using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DataTransferObjects.Identity.Role.RoleValidator
{
    public class UpdateRoleValidator:AbstractValidator<UpdateRoleDto>
    {
        public UpdateRoleValidator()
        {
            RuleFor(f => f.RoleName).NotNull().WithMessage("The role name is required.");
        }
    }
}
