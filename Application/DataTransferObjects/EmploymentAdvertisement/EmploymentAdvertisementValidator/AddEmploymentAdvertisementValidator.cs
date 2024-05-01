using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DataTransferObjects.EmploymentAdvertisement.EmploymentAdvertisementValidator
{
    public class AddEmploymentAdvertisementValidator
    :AbstractValidator<AddEmploymentAdvertisementDto>
    {
        public AddEmploymentAdvertisementValidator()
        {
            RuleFor(f=>f.JobTitle).NotEmpty()
                .NotNull();
            RuleFor(f=>f.Description).NotEmpty()
                .NotNull();
            RuleFor(f=>f.SpecificDutiesResponsibilities).NotEmpty()
                .NotNull();
            RuleFor(f=>f.MinimumPositionRequirements).NotEmpty()
                .NotNull();
            RuleFor(f=>f.EmploymentType).NotEmpty()
                .NotNull();
            RuleFor(f=>f.Experience).NotEmpty()
                .NotNull();
            RuleFor(f=>f.WorkplaceInformation).NotEmpty()
                .NotNull();
            RuleFor(f=>f.Rate).NotEmpty()
                .NotNull();       
            RuleFor(f=>f.Education).NotEmpty()
                .NotNull();   
            RuleFor(f=>f.DatePosted).NotEmpty()
                .NotNull();


        }
    }
}
