
namespace Domain.Entities
{
    public class ResumeEntity:BaseEntity
    {
        public string FullName { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Description { set; get; }
        public string CvFilePath { set; get; }
        public string EmploymentId { set; get; }
        public EmploymentAdvertisementEntity Employment { set; get; }
    }
}
