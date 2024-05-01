using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.EmploymentAdvertisement
{
    public class RequestResumeViewModel
    {
        public DateTimeOffset CreateTime { set; get; }

        public string Description { set; get; }
        public string FullName { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Id { set; get; }
        public string CvFilePath { set; get; }
    }

    public class RequestEmployment
    {
        public string Id { set; get; }
        public string JobTitle { set; get; }
        public ICollection<RequestResumeViewModel> Resumes { set; get; }
    }
}
