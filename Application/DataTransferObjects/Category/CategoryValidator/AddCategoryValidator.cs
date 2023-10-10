using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.Category.CategoryValidator
{
    public class AddCategoryValidator: AbstractValidator<AddCategoryDto>
    {
        public AddCategoryValidator()
        {
            RuleFor(f => f.Title).NotNull().NotEmpty()
              
                .WithMessage("Please Insert Title.");
        }
    }
}
