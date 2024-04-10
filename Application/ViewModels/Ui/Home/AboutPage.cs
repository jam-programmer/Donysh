using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Ui.Home
{
    public class AboutPage
    {
        public string? Banner { set; get; }
        public string? TeamDescription { set; get; }
        public string? Description { set; get; }
        public List<CompanyBox>? Companies { set; get; } 
        public List<TeamBox>? Members { set; get; }
    }
}
