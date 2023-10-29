using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DataTransferObjects.Status.StatusValidator
{
    public  class AddStatusValidator : AbstractValidator<AddStatusDto>
    {
        public AddStatusValidator()
        {
            RuleFor(f => f.Status).NotNull().WithMessage("Status cannot be empty.");
        }
    }
}
