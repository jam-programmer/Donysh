
namespace Application.DataTransferObjects.Feedback
{
    public class UpdateFeedbackDto
    {
        public string? Id { set; get; }
        public string? FullName { set; get; }
        public string? CompanyName { set; get; }
        public string? EmailAddress { set; get; }
        public string? Description { set; get; }
        public string? FilePath { set; get; }
        public bool IsShow { set; get; }
    }
}
