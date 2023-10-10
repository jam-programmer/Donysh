using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Enum;
using Microsoft.AspNetCore.Http;

namespace Application.DataTransferObjects.Company
{
    public class AddCompanyDto
    {
        public IFormFile? LogoFile { set; get; }
        public string? Link { set; get; }
        public string? Name { set; get; }
        public CompanyTypeEnum? CompanyType { set; get; }
    }
}
