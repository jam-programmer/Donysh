using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Request
{
    public class RequestViewModel
    {
        public bool Show { set; get; } 
        public string? Email { set; get; }
        public string? FirstName { set; get; }
        public string? LastName { set; get; }
        public string? Id { set; get; }
    }
}
