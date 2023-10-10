using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.Main;

namespace Application.ViewModels.Category
{
    public class CategoryViewModel:BaseViewModel
    {
        public string? Id { set; get; }
        public string? Title { set; get; }
    }
}
