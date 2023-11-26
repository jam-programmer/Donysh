using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.Main;

namespace Application.ViewModels.Request
{
    public class RequestDetail
    {
        public DateTimeOffset CreateTime { set; get; }
        public string? Email { set; get; }
        public string? FirstName { set; get; }
        public string? LastName { set; get; }
        public string? Description { set; get; }
        public List<ItemViewModel>? Services { set; get; } = new List<ItemViewModel>();
    }
}
