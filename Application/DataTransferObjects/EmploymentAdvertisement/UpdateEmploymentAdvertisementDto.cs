
namespace Application.DataTransferObjects.EmploymentAdvertisement
{
    public class UpdateEmploymentAdvertisementDto
    {
        public bool Active { set; get; } 
        public string Id { set; get; }
        public string JobTitle { set; get; }
        public string Description { set; get; }
        public string SpecificDutiesResponsibilities { set; get; }
        public string MinimumPositionRequirements { set; get; }

        public string EmploymentType { set; get; }
        public string Experience { set; get; }
        public string WorkplaceInformation { set; get; }
        public string Rate { set; get; }
        public string Education { set; get; }
        public string DatePosted { set; get; }

    }
}
