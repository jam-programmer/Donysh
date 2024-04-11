using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DataTransferObjects.Page.PageValidator
{
    public class AddPageValidator:AbstractValidator<AddPageDto>
    {
        public AddPageValidator()
        {
            RuleFor(f => f.Location).NotNull();
            RuleFor(f => f.Title).NotNull();
            RuleFor(f => f.Body).NotNull();
            
        }
    }
}
