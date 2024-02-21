using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Company
{
    public class CompanyViewModel
    {
        public string? Id { set; get; }
        public string? LogoPath { set; get; }
        public string? Link { set; get; }
        public  string? Name { set;get; }
        public CompanyType Type { set; get; }
    }
}
