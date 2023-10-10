namespace Domain.Entities
{
    public partial class RequestEntity : BaseEntity
    {
        public string? Email { set; get; }
        public string? FirstName { set; get; }
        public string? LastName { set; get; }

        #region Relation
        public List<ServiceEntity>? Service { set; get; }
        #endregion

    }
}
