using Application.DataTransferObjects.Project;
using Application.ViewModels.Main;
using Application.ViewModels.Ui.General;
using Application.ViewModels.Ui.Home;
using Application.ViewModels.Ui.Project;
using Application.ViewModels.Ui.Service;
using Donysh.Models;

namespace Application.Services.Ui
{
    public interface IUserInterface
    {
        Task<HomeHeaderSection> GetHomeTopSection();
        Task<HomeAboutSection> GetHomeAboutSection();
        Task<HomeServiceSection> GetHomeServiceSection();
        Task<HomePortfolioSection> GetHomePortfolioSection(bool home);
        Task<HomeTeamSection> GetHomeTeamSection();
        Task<HomeCompanySection> GetHomeCompanySection();
        Task<HomeInformationSection> GetHomeInformationSection();
        Task<HeaderPage> GetHeaderPage(string titlePage);
        Task<ProjectDetail> GetProjectById(string id);
        Task<ServiceDetail> GetServiceDetailById(string id);
        Task<PdfOptions> ProjectPdfOption(string projectId);
        Task<Footer> GetFooter();
        Task<PageDetail> GetPage(string id);
        Task<Header> GetMenu();
        Task<ListGenerics<ProjectCard>> GetListProject(int page, string? filter = null);
        Task<bool> AddRequest(RequestInfo request);
        Task<AboutPage> GetAboutPage();
        Task<bool> AddContactRequest(RequestContact request);
        Task<List<ItemViewModel>> GetServices();
        Task<PdfOptions> ProjectsPdfOption(ExportRequest request);
        Task<List<ScopeItem>> GetScopes();
    }
}
