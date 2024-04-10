using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Ui.Project
{
    public class ProjectCard
    {
     public string? Id { set; get; }
        public string? ProjectImage { set; get; }
        public string? ProjectName { set; get; }
        public string? Description { set; get; }
        public string? Architect { set; get; }
        public string? Location { set; get; }
        public string? ScopeForeignKey { set; get; }
    }
}
