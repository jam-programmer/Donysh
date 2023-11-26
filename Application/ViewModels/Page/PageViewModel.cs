using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Page
{
    public class PageViewModel
    {
        public string Id { set; get; }
        public string Title { set; get; }
        public TabLocation Location { set; get; }
    }
}
