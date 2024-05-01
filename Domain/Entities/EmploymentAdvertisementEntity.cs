using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmploymentAdvertisementEntity:BaseEntity
    {
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
        public ICollection<ResumeEntity> Resumes { set; get; }
        public bool Active { set; get; } 
    }
}
