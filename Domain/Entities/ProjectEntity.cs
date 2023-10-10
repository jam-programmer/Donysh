namespace Domain.Entities
{
    public partial class ProjectEntity : BaseEntity
    {
        public string? ProjectName { set; get; }
        public string? Location { set; get; }
        public string? Description { set; get; }
        public string? OwnerOrDeveloper { set; get; }
        public string? Architect { set; get; }
        //General Contractor/Builder/Construction Manager
        public string? Builder { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime CompletionDate { set; get; }
        public string? ContractAmount { set; get; }
        public string? ReferenceContactName { set; get; }
        public string? ReferenceContactEmail { set; get; }
        public string? ReferenceContactPhone { set; get; }
        public string? ReferenceContactAddress { set; get; }

        #region  Relation
        public List<ServiceEntity>? Service { set; get; }
        public StatusEntity? Status { set; get; }
        public string? StatusForeignKey { set; get; }
        #endregion
    }
}
