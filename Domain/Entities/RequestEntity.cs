namespace Domain.Entities
{
    public partial class RequestEntity : BaseEntity
    {
        public string? Email { set; get; }
        public string? FirstName { set; get; }
        public string? LastName { set; get; }
        public string? Description { set; get; }
        public  bool Show { set; get; }=false;


        #region Relation
        public List<ServiceEntity>? Service { set; get; }
        #endregion

    }
}
