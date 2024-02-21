namespace Domain.Entities
{
    public partial class ProjectEntity : BaseEntity
    {
        public string? ProjectImage { set; get; }
        public string? ProjectName { set; get; }
        public bool? IsProjectName { set; get; }

        public string? Location { set; get; }
        public bool? IsLocation { set; get; }
        public string? Description { set; get; }
        public bool? IsDescription { set; get; }
        public string? OwnerOrDeveloper { set; get; }
        public bool? IsOwnerOrDeveloper { set; get; }
        public string? Architect { set; get; }
        public bool? IsArchitect { set; get; }
        //General Contractor/Builder/Construction Manager
        public string? Builder { set; get; }
        public bool? IsBuilder { set; get; }

        public string? StartDate { set; get; }
        public bool? IsStartDate { set; get; }
        public string? CompletionDate { set; get; }
        public bool? IsCompletionDate { set; get; }
        public string? ContractAmount { set; get; }
        public bool? IsContractAmount { set; get; }
        public string? ReferenceContactName { set; get; }
        public bool? IsReferenceContactName { set; get; }
        public string? ReferenceContactEmail { set; get; }
        public bool? IsReferenceContactEmail { set; get; }
        public string? ReferenceContactPhone { set; get; }
        public bool? IsReferenceContactPhone { set; get; }
        public string? ReferenceContactAddress { set; get; }
        public bool? IsReferenceContactAddress { set; get; }
        #region  Relation
        public List<ServiceEntity>? Service { set; get; }
        public StatusEntity? Status { set; get; }
        public string? StatusForeignKey { set; get; }
        public bool? IsStatusForeignKey { set; get; }


        public string? ScopeForeignKey { set; get; }
        public bool? IsScopeForeignKey { set; get; }


        public ScopeWorkEntity? ScopeWork { set; get; }
        #endregion
    }
}
