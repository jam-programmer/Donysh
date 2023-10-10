using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DataTransferObjects.Service.ServiceValidator
{
    public class UpdateServiceValidator:AbstractValidator<UpdateServiceDto>
    {
        public UpdateServiceValidator()
        {
            RuleFor(f => f.Title).NotNull().NotEmpty()
                .WithMessage("The title cannot be saved without a value.");
            RuleFor(f => f.Id).NotNull().NotEmpty();
        }
    }
}
