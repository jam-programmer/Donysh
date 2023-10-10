using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DataTransferObjects.Service.ServiceValidator
{
    public class AddServiceValidator:AbstractValidator<AddServiceDto>
    {
        public AddServiceValidator()
        {
            RuleFor(f=>f.Title).NotEmpty()
                .NotNull().WithMessage("Please Insert Title.");
        }
    }
}
