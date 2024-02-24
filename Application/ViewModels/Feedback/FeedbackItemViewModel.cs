using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Feedback
{
    public class FeedbackItemViewModel
    {
        public string? FullName { set; get; }
        public string? CompanyName { set; get; }
        public string? Description { set; get; }
        public string? FilePath { set; get; }
    }
}
