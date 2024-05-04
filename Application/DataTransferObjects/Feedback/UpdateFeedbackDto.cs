
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects.Feedback
{
    public class UpdateFeedbackDto
    {
        public string? Id { set; get; }
        [Required(ErrorMessage = "Name is required")]
        public string? FullName { set; get; }
        [Required(ErrorMessage = "Company name is required")]
        public string? CompanyName { set; get; }
        public string? EmailAddress { set; get; }
        [Required(ErrorMessage = "Feedback text is required")]
        public string? Description { set; get; }
        public string? FilePath { set; get; }
        public IFormFile? File { set; get; }
        public bool IsShow { set; get; }
    }
}
