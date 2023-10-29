using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DataTransferObjects.Project.ProjectValidator
{
    public class AddProjectValidator:AbstractValidator<AddProjectDto>
    {
        public AddProjectValidator()
        {
            RuleFor(f => f.ProjectName).NotNull().WithMessage("Project title is required.");
            RuleFor(f => f.Description).NotNull().WithMessage("Project description is required.");
        }
    }
}
