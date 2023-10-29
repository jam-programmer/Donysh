using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Project
{
    public class ProjectViewModel
    {
        public string? Id { set; get; }
        public string? ProjectImage { set; get; }
        public string? ProjectName { set; get; }
        public string? OwnerOrDeveloper { set; get; }
    }
}
