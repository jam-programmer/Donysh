using Application.Common.Enum;
using Mapster;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.DataTransferObjects.Company
{
   

    public class UpdateCompanyDto
    {
        public string? Id { set; get; }
        public string? Path { set; get; }
        public IFormFile? LogoFile { set; get; }
        public string? Link { set; get; }
        public string? Name { set; get; }
        public CompanyTypeEnum? CompanyType { set; get; }
    }
}
