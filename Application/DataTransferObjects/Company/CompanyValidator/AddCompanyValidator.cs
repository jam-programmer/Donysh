using Application.DataTransferObjects.Service;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DataTransferObjects.Company.CompanyValidator
{
    public class AddCompanyValidator: AbstractValidator<AddCompanyDto>
    {
        public AddCompanyValidator()
        {
            RuleFor(f => f.LogoFile).Must(CheckFileSize)
                .WithMessage("Please upload the logo.(The size of the uploaded file should be 350 kilobytes.)");
            RuleFor(f => f.CompanyType)
                .NotNull().WithMessage("Select the type of communication with the company.");
        }

        private bool CheckFileSize(IFormFile? file)
        {
            if (file != null)
            {
                //350KB
                if (file.Length > 350000)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
