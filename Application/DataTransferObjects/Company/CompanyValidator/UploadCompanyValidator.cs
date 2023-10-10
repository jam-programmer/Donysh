using Application.DataTransferObjects.Service;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.Company.CompanyValidator
{
    public class UploadCompanyValidator: AbstractValidator<UpdateCompanyDto>
    {
        public UploadCompanyValidator()
        {

            RuleFor(f => f.LogoFile)
                .Must(CheckFileSize).WithMessage("The size of the uploaded file should be 350 kilobytes.");
            RuleFor(f => f.CompanyType)
                .NotEmpty().NotNull().WithMessage("Select the type of communication with the company.");
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
