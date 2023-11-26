using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DataTransferObjects.Page.PageValidator
{
    public class UpdatePageValidator:AbstractValidator<UpdatePageDto>
    {
        public UpdatePageValidator()
        {
            RuleFor(f => f.Location).NotNull();
            RuleFor(f => f.Title).NotNull();

        }
    }
}
