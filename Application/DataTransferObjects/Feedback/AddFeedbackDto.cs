
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects.Feedback
{
    public class AddFeedbackDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string? FullName { set; get; }
        [Required(ErrorMessage = "Company name is required")]
        public string? CompanyName { set; get; }
        public string? EmailAddress { set; get; }
        [Required(ErrorMessage = "Feedback text is required")]
        public string? Description { set; get; }
        public IFormFile? FilePath { set; get; }
        public bool IsShow { set; get; } = false;
    }
}
