using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DataTransferObjects.Project
{
    public class AddProjectDto
    {
        public IFormFile? ProjectImage { set; get; }
        public string? ProjectName { set; get; }
        public string? Location { set; get; }
        public string? Description { set; get; }
        public string? OwnerOrDeveloper { set; get; }
        public string? Architect { set; get; }
        public string? Builder { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime CompletionDate { set; get; }
        public string? ContractAmount { set; get; }
        public string? ReferenceContactName { set; get; }
        public string? ReferenceContactEmail { set; get; }
        public string? ReferenceContactPhone { set; get; }
        public string? ReferenceContactAddress { set; get; }
        public string? StatusForeignKey { set; get; }
        public string? ScopeForeignKey { set; get; }
        public List<string>? Services { set; get; }
    }
}
