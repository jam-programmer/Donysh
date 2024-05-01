using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Ui.Home
{
    public class ProjectBox
    {
        public string? Location { set; get; }
        public string? Description { set; get; }
        public string? StatusForeignKey { set; get; }
        public string? StatusTitle { set; get; }
        public string? Id { set; get; }
        public string? ProjectName { get; set; }
        public string? ProjectImage { set; get; }
    }
}
