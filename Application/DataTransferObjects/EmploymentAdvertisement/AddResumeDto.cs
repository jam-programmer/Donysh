
using Microsoft.AspNetCore.Http;

namespace Application.DataTransferObjects.EmploymentAdvertisement
{
    public class AddResumeDto
    {
        public string FullName { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Description { set; get; }
        public IFormFile CvFilePath { set; get; }
        public string EmploymentId { set; get; }
    }
}
