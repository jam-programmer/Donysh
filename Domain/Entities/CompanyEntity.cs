using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enum;

namespace Domain.Entities
{
   

    public partial class CompanyEntity :BaseEntity
    {
        public string? LogoPath { set; get; }
        public string? Link { set; get; }
        public string? Name { set; get; }   
        public CompanyType Type { set; get; }
    }
}
