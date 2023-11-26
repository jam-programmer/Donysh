using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Ui.Home
{
    public class HomePortfolioSection
    {
        public string? Description { set; get; }
        public List<ProjectBox>? Projects { set; get; }  

        public List<ServiceItem>? ServiceItems { set; get; }
    }
}
