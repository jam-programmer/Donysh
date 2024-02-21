using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.Project
{
    public class UpdateProjectDto
    {
        public string? Id { get; set; }  
        public string? ProjectImage { set; get; }
        public IFormFile? ImageProject { set; get; }
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

        public bool IsLocation { set; get; }
        public bool IsProjectName { set; get; }
        public bool IsDescription { set; get; }
        public bool IsOwnerOrDeveloper { set; get; }
        public bool IsArchitect { set; get; }
        public bool IsBuilder { set; get; }
        public bool IsStartDate { set; get; }
        public bool IsCompletionDate { set; get; }
        public bool IsContractAmount { set; get; }
        public bool IsReferenceContactName { set; get; }
        public bool IsReferenceContactEmail { set; get; }
        public bool IsReferenceContactPhone { set; get; }
        public bool IsReferenceContactAddress { set; get; }
        public bool IsStatusForeignKey { set; get; }
        public bool IsScopeForeignKey { set; get; }
    }
}
