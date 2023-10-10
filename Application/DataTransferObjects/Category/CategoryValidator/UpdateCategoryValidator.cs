using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DataTransferObjects.Category.CategoryValidator
{
    public class UpdateCategoryValidator:AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(f => f.Title).NotNull().NotEmpty()
                .WithMessage("The title cannot be saved without a value.");
            RuleFor(f => f.Id).NotNull().NotEmpty();
        }
    }
}
