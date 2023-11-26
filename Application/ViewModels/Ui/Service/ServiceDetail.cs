using Application.ViewModels.Ui.Home;

namespace Application.ViewModels.Ui.Service
{
    public class ServiceDetail
    {
        public string Id { set; get; }
        public string? Image { set; get; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<ProjectBox> Projects { set; get; }
    }
}
