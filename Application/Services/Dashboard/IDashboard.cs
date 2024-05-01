using Application.ViewModels.Dashboard;
using Application.ViewModels.EmploymentAdvertisement;


namespace Application.Services.Dashboard
{
    public interface IDashboard
    {
        Task<List<RequestEmployment>> GetLastResumes();
        Task<DashboardViewModel> GetDashboardAsync();
    }
}
