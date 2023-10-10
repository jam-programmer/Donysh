using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DataTransferObjects.Team.TeamValidator
{
    public class AddTeamValidator:AbstractValidator<AddTeamDto>
    {
        public AddTeamValidator()
        {
            RuleFor(f => f.JobTitle).NotNull().NotEmpty().WithMessage("The job title cannot be empty");
            RuleFor(f => f.FullName).NotNull().NotEmpty().WithMessage("Name and surname cannot be empty");
        }
    }
}
