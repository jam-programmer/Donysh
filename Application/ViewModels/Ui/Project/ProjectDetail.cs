using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Ui.Project
{
    public class ProjectDetail
    {
        public string? Id { set; get; }
        public string? ProjectImage { set; get; }
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
        public string? Status { set; get; }
        public string? Scope { set; get; }
        public List<ProjectServices>? Services { set; get; }
        public List<PictureProject>? Pictures { set; get; }
    }
}
