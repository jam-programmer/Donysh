
using Microsoft.AspNetCore.Http;

namespace Application.DataTransferObjects.Feedback
{
    public class AddFeedbackDto
    {
        public string? FullName { set; get; }
        public string? CompanyName { set; get; }
        public string? EmailAddress { set; get; }
        public string? Description { set; get; }
        public IFormFile? FilePath { set; get; }
        public bool IsShow { set; get; } = false;
    }
}
