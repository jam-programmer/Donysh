using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DataTransferObjects.Picture.PictureValidator
{
    public class AddPictureValidator:AbstractValidator<AddPictureDto>
    {
        public AddPictureValidator()
        {
            RuleFor(f => f.File).NotNull()
                .WithMessage("Please upload the file.");
        }
    }
}
