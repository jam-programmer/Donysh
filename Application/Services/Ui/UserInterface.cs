
using System.Text;
using Application.Services.Setting;
using Mapster;
using Application.ViewModels.Ui.Home;
using Application.ConfigMapster.UiMap.HomeMap;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using Application.ViewModels.Ui.Project;
using Application.ViewModels.Ui.Service;
using Microsoft.EntityFrameworkCore;
using Application.ViewModels.Ui.General;
using Application.ViewModels.Main;
using Application.Core;
using Application.Services.Sender;
using Application.ViewModels.Sender;
using Donysh.Models;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;


namespace Application.Services.Ui
{
    public class UserInterface : IUserInterface
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IRepository<ScopeWorkEntity> _scopeRepository;
        private readonly ISetting _setting;
        private readonly IDapper<ProjectServices> _dapperService;
        private readonly IRepository<ServiceEntity> _service;
        private readonly IDapper<ProjectBox> _dapper;
        private readonly IRepository<TeamEntity> _team;
        private readonly IRepository<CompanyEntity> _company;
        private readonly IRepository<ProjectEntity> _projectRepository;
        private readonly IRepository<PictureEntity> _pictureRepository;
        private readonly IRepository<PageEntity> _pageRepository;
        private readonly IRepository<RequestEntity> _requestRepository;
        private readonly IRepository<AboutEntity> _about;
        private readonly IRepository<ContactEntity> _contactRepository;
        private readonly ISender _sender;
        private readonly IHttpContextAccessor _accessor;
        public UserInterface(IHttpContextAccessor accessor, IWebHostEnvironment environment, ISetting setting, IDapper<ProjectServices> dapperService, IRepository<ServiceEntity> service, IDapper<ProjectBox> dapper, IRepository<TeamEntity> team, IRepository<CompanyEntity> company, IRepository<ProjectEntity> projectRepository, IRepository<PictureEntity> pictureRepository, IRepository<PageEntity> pageRepository, IRepository<RequestEntity> requestRepository, IRepository<AboutEntity> about, IRepository<ContactEntity> contactRepository, ISender sender)
        {
            _hostingEnvironment = environment;
            _accessor = accessor;
            _setting = setting;
            _dapperService = dapperService;
            _service = service;
            _dapper = dapper;
            _team = team;
            _company = company;
            _projectRepository = projectRepository;
            _pictureRepository = pictureRepository;
            _pageRepository = pageRepository;
            _requestRepository = requestRepository;
            _about = about;
            _contactRepository = contactRepository;
            _sender = sender;
        }


        public async Task<HomeAboutSection> GetHomeAboutSection()
        {
            var setting = await _setting.GetSetting();
            HomeAboutSection homeAbout = setting.Adapt<HomeAboutSection>(UiHomeMapster.HomeAboutSection());
            return homeAbout;
        }

        public async Task<HomeServiceSection> GetHomeServiceSection()
        {
            var setting = await _setting.GetSetting();
            var service = await _service.GetAll();
            HomeServiceSection homeService = new HomeServiceSection();
            homeService.Description = setting.ServiceDescription;
            homeService.Services = service.Adapt<List<ServiceBox>>(UiHomeMapster.HomeServiceSection());
            return homeService;
        }

        public async Task<HomePortfolioSection> GetHomePortfolioSection(bool home)
        {
            var service = await _service.GetAll();
            var setting = await _setting.GetSetting();
            HomePortfolioSection homePortfolioSection = new();
            var projects = await _dapper.Execute("[dbo].[SP_GetLastProject]", home);
            homePortfolioSection.Projects = projects;
            homePortfolioSection.Description = setting.ProjectDescription;
            var serviceItems = service.ToList();
            homePortfolioSection.ServiceItems = serviceItems.Adapt<List<ServiceItem>>();
            return homePortfolioSection;
        }

        public async Task<HomeHeaderSection> GetHomeTopSection()
        {
            var setting = await _setting.GetSetting();
            HomeHeaderSection homeHeaderSection = setting.Adapt<HomeHeaderSection>(UiHomeMapster.HomeHeaderSection());
            return homeHeaderSection;
        }

        public async Task<HomeTeamSection> GetHomeTeamSection()
        {
            var setting = await _setting.GetSetting();
            var members = await _team.GetAll();
            HomeTeamSection homeTeamSection = new();
            homeTeamSection.Description = setting.TeamDescription;
            homeTeamSection.Team = members.Adapt<List<TeamBox>>();
            return homeTeamSection;
        }

        public async Task<HomeCompanySection> GetHomeCompanySection()
        {
            HomeCompanySection homeCompanySection = new();
            var companies = await _company.GetAll();
            companies = companies.Where(w => w.Type == CompanyType.Partner).ToList();
            homeCompanySection.Companies =
                companies.Adapt<List<CompanyBox>>();
            return homeCompanySection;
        }

        public async Task<HomeInformationSection> GetHomeInformationSection()
        {
            var setting = await _setting.GetSetting();
            HomeInformationSection homeInformationSection = setting.Adapt<HomeInformationSection>();
            return homeInformationSection;
        }

        public async Task<HeaderPage> GetHeaderPage(string titlePage)
        {
            var setting = await _setting.GetSetting();
            HeaderPage page = setting.Adapt<HeaderPage>();
            switch (titlePage)
            {
                case "About":
                    page.BannerPageHeader = setting.AboutBanner == "default.jpg" ? setting.BannerPageHeader : setting.AboutBanner;

                    break;
                case "Contat Us":
                    page.BannerPageHeader = setting.ContactBanner == "default.jpg" ? setting.BannerPageHeader : setting.ContactBanner;
                    break;

                case "REQUEST A QUOTE":
                    page.BannerPageHeader = setting.RequestBanner == "default.jpg" ? setting.BannerPageHeader : setting.RequestBanner;
                    break;
                case "Working With":
                    page.BannerPageHeader = setting.WorkWithBanner == "default.jpg" ? setting.BannerPageHeader : setting.WorkWithBanner;
                    break;
                case "Projects":
                    page.BannerPageHeader = setting.ProjectBanner == "default.jpg" ? setting.BannerPageHeader : setting.ProjectBanner;
                    break;
                case "Project Detail":
                    page.BannerPageHeader = setting.ProjectBanner == "default.jpg" ? setting.BannerPageHeader : setting.ProjectBanner;
                    break;
                case "Categories":
                    page.BannerPageHeader = setting.CategoryBanner == "default.jpg" ? setting.BannerPageHeader : setting.CategoryBanner;
                    break;
                case "Category Detail":
                    page.BannerPageHeader = setting.CategoryBanner == "default.jpg" ? setting.BannerPageHeader : setting.CategoryBanner;
                    break;
                default:
                    page.BannerPageHeader = setting.BannerPageHeader;
                    break;
            }
            return page;
        }

        public async Task<ProjectDetail> GetProjectById(string id)
        {
            ProjectDetail detail = new();
            var projectQuery = await _projectRepository.GetByQuery();

           

            var project = await projectQuery.Include(i => i.Status)
                .Include(i => i.ScopeWork).SingleOrDefaultAsync(s => s.Id == id);

            detail = project!.Adapt<ProjectDetail>();

            if (project!.Status!=null)
            {
                detail.Status = project.Status.Status;
            }

            if (project!.ScopeWork != null)
            {
                detail.Scope = project.ScopeWork.Title;
            }



          

            var services = await _dapperService.ExecuteQuery(
                $"select s.Id,s.Title from dbo.ProjectEntityServiceEntity as ps with(nolock)\r\nInner Join dbo.[Service] as s with(nolock) On ps.ServiceId=s.Id\r\nwhere ps.ProjectsId='{id}'");
            detail.Services = services;
            var query = await _pictureRepository.GetByQuery();
            var pictures = await query.Where(w => w.ProjectForeignKey == id).ToListAsync();
            detail.Pictures = pictures.Adapt<List<PictureProject>>();
            return detail;
        }

        public async Task<ServiceDetail> GetServiceDetailById(string id)
        {
            ServiceDetail serviceDetail = new();
            var service = await _service.GetByIdAsync(id);
            serviceDetail = service!.Adapt<ServiceDetail>();
            var project = await
                _dapper.ExecuteQuery($"SELECT S.Id AS ServiceId, S.Title AS ServiceTitle,\r\nP.Id,P.ProjectName,P.Location,P.Description,P.ProjectImage\r\nFROM [dbo].[ProjectEntityServiceEntity] AS PS WITH(NOLOCK)\r\nINNER JOIN Dbo.Project AS P WITH(NOLOCK) ON PS.ProjectsId = P.Id\r\nINNER JOIN Dbo.[Service] AS S WITH(NOLOCK) ON PS.ServiceId=S.Id\r\nWHERE PS.ServiceId='{id}'");
            serviceDetail.Projects = project;
            return serviceDetail;
        }

        public async Task<PdfOptions> ProjectPdfOption(string projectId)
        {
           

            var fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "PDF");
            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }
            var fileName = $"{Guid.NewGuid().ToString()}-file.pdf";
            PdfOptions options = new();
           
            try
            {
                StringBuilder htmlCodeBuilder = new StringBuilder();

                htmlCodeBuilder.Append(@"
    <html lang=""en"">
    <head>
        <meta charset=""UTF-8"">
        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
        <title>Project List</title>
    </head>
    <body>
        <div style=""padding: 10px;"">
            <h1 style=""background-color: goldenrod; padding: 5px;"">Project information </h1>
            ");

                    var data = await GetProjectById(projectId);
                    string itemProject = string.Empty;
                    itemProject = "<hr />";

                   

                        var webRootPath = _hostingEnvironment.WebRootPath;
                        var filePath = webRootPath + "/Project/" + data.ProjectImage!;
                        string base64String = string.Empty;
                        if (File.Exists(filePath))
                        {
                            byte[] fileBytes = await File.ReadAllBytesAsync(filePath);
                            base64String = Convert.ToBase64String(fileBytes);
                        }

                        itemProject += $" <img src=\"data:image/jpeg;base64, {base64String}\" style=\"width:200px;height:auto;\" >\r\n";
                    


                    itemProject += $"<h2>{data.ProjectName}</h2>";
                    itemProject += "<dl>";
                    if (data.IsBuilder && !string.IsNullOrEmpty(data.Builder))
                    {
                        itemProject += $"<dt>General Contractor/Builder/Construction Manager:</dt><dd>{data.Builder}</dd>";
                    }

                    if (data.IsArchitect && !string.IsNullOrEmpty(data.Architect))
                    {
                        itemProject += $"<dt>Architect:</dt><dd>{data.Architect}</dd>";
                    }

                    if (data.IsContractAmount && !string.IsNullOrEmpty(data.ContractAmount))
                    {
                        itemProject += $" <dt>Contract Amount:</dt><dd>{data.ContractAmount}</dd>";
                    }

                    if (data.IsOwnerOrDeveloper && !string.IsNullOrEmpty(data.OwnerOrDeveloper))
                    {
                        itemProject += $"<dt>Owner/Developer:</dt> <dd>{data.OwnerOrDeveloper}</dd>";
                    }
                    if (data.IsLocation && !string.IsNullOrEmpty(data.Location))
                    {
                        itemProject += $"<dt>Location:</dt><dd>{data.Location}</dd>";
                    }
                    if (data.IsStatusForeignKey && !string.IsNullOrEmpty(data.Status))
                    {
                        itemProject += $"<dt>Status:</dt><dd>{data.Status}</dd>";
                    }

                    if (data.IsScopeForeignKey && !string.IsNullOrEmpty(data.Scope))
                    {
                        itemProject += $"<dt>Scope:</dt><dd>{data.Scope}</dd>";
                    }

                    itemProject += "</dl><ul>";

                    if (data.IsScopeForeignKey && !string.IsNullOrEmpty(data.Scope))
                    {
                        itemProject += $"<dt>Scope:</dt><dd>{data.Scope}</dd>";
                    }

                    if (data.IsReferenceContactName && !string.IsNullOrEmpty(data.ReferenceContactName))
                    {
                        itemProject += $"<li> Name: < strong >{data.ReferenceContactName}</ strong ></ li >";
                    }

                    if (data.IsReferenceContactEmail && !string.IsNullOrEmpty(data.ReferenceContactEmail))
                    {
                        itemProject += $"<li> Email: < strong >{data.ReferenceContactEmail}</ strong ></ li >";
                    }

                    if (data.IsReferenceContactPhone && !string.IsNullOrEmpty(data.ReferenceContactPhone))
                    {
                        itemProject += $"<li> Phone Number: < strong >{data.ReferenceContactPhone}</ strong ></ li >";
                    }

                    if (data.IsReferenceContactAddress && !string.IsNullOrEmpty(data.ReferenceContactAddress))
                    {
                        itemProject += $"<li> Address: < strong >{data.ReferenceContactAddress}</ strong ></ li >";
                    }


                    itemProject += "</ul>";











                    htmlCodeBuilder.Append(itemProject);




                    if (data.Services != null && data.Services.Any())
                    {
                        htmlCodeBuilder.Append($@"  <h3>Service:</h3>");
                        foreach (var item in data.Services)
                        {
                            htmlCodeBuilder.Append($@"<span style=""border: 1px solid black; padding: 5px; margin: 5px;"">{item.Title}</span>");
                        }
                    }

                    if (data.IsDescription && !string.IsNullOrEmpty(data.Description))
                    {
                        string description = $"<br/><h3>Description:</h3>{data.Description}";
                        htmlCodeBuilder.Append(description);
                    }



                    //if (data.Pictures != null)
                    //{
                    //    foreach (var item in data.Pictures)
                    //    {
                    //        htmlCodeBuilder.Append($@"<img style=""width: 250px; height: 150px;"" src=""{item}"" />");
                    //    }
                    //}
                

                htmlCodeBuilder.Append(@"</div></body></html>");
                options.Content = htmlCodeBuilder.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            options.File = fileName;
            options.FilePath = fileDirectory = Path.Combine(fileDirectory, fileName!);
            return options;
        }

        public async Task<Footer> GetFooter()
        {
            Footer footer = new();
            var setting = await _setting.GetSetting();
            footer.ColumnOne = setting.Adapt<AboutAndMedia>();
            var pageQuery = await _pageRepository.GetByQuery();
            var page = await pageQuery.Where(w => w.Location == TabLocation.Footer).ToListAsync();
            var linkPages = page.Adapt<List<Pages>>();
            footer.ColumnTwo = linkPages;
            footer.WorkingHours = setting.WorkingHours;
            return footer;
        }

        public async Task<PageDetail> GetPage(string id)
        {
            var model = await _pageRepository.GetByIdAsync(id);
            PageDetail detail = model!.Adapt<PageDetail>();
            return detail;
        }

        public async Task<Header> GetMenu()
        {
            var pageQuery = await _pageRepository.GetByQuery();
            var page = await pageQuery.Where(w => w.Location == TabLocation.SubMenu).ToListAsync();
            Header header = new();
            header.Menu = page.Adapt<List<Pages>>();
            return header;
        }

        public async Task<ListGenerics<ProjectCard>> GetListProject(int page, string? filter = null)
        {
            int pageSelected = page;
            int count = await _projectRepository.GetCount();
            int pageSkip = (page - 1) * 10;
            var query = await _projectRepository.GetByQuery();
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Include(i => i.Status);
                query = query.Where(w => w.StatusForeignKey == filter);
            }
            var projects = await query.Skip(pageSkip).Take(10).ToListAsync();
            count = count.PageCount(10);
            ListGenerics<ProjectCard> result = new();
            result.List = projects.Adapt<List<ProjectCard>>();
            result.Count = count;
            result.CurrentPage = page;
            result.data =await query.Select(s => s.Status.Status).FirstOrDefaultAsync();
            if (count > 1 && projects.Count < 10 && page == 1)
            {
                result.Pagination = false;
            }

            return result;
        }

        public async Task<bool> AddRequest(RequestInfo request)
        {
            RequestEntity requestEntity = new();
            requestEntity = request.Adapt<RequestEntity>();

            try
            {
                await _requestRepository.Insert(requestEntity);
                if (request.Services.Count > 0)
                {
                    await _dapper.InsertWithOutColumn("Dbo.RequestEntityServiceEntity", requestEntity.Id, request.Services);
                }
                return true;
            }
            catch (Exception e)
            {
                // Console.WriteLine(e);
                return false;
            }
        }

        //public async Task<AboutPage> GetAboutPage()
        //{
        //    AboutPage about = new();
        //    var setting = await _setting.GetSetting();
        //    about.TeamDescription = setting?.TeamDescription;
        //    var aboutEntity = await _about.FirstOrDefaultAsync();
        //    about = aboutEntity!.Adapt<AboutPage>();
        //    var companies = await _company.GetAll();

        //    about.Companies = new List<CompanyBox>();
        //    about.Companies = companies.Adapt<List<CompanyBox>>();
        //    var members = await _team.GetAll();
        //    about.Members = members.Adapt<List<TeamBox>>();
        //    return about;
        //}
        public async Task<AboutPage> GetAboutPage()
        {
            AboutPage about = new AboutPage();

            var setting = await _setting.GetSetting();
            if (setting != null)
            {
                about.TeamDescription = setting.TeamDescription;
            }

            var aboutEntity = await _about.FirstOrDefaultAsync();
            if (aboutEntity != null)
            {
                about = aboutEntity.Adapt<AboutPage>();
            }

            var companies = await _company.GetAll();
            if (companies != null)
            {
                about.Companies = companies.Adapt<List<CompanyBox>>();
            }

            var members = await _team.GetAll();
            if (members != null)
            {
                about.Members = members.Adapt<List<TeamBox>>();
            }

            return about;
        }

        public async Task<bool> AddContactRequest(RequestContact request)
        {
            ContactEntity contactEntity = new();
            contactEntity = request.Adapt<ContactEntity>();
            try
            {
                await _contactRepository.Insert(contactEntity);
                SenderViewModel sender = new SenderViewModel();
                sender.Subject = "New message from the donysh site";
                sender.Body = $"{request.FullName} wrote a new message for you.";
                await _sender.SendAsync(sender);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }



        public async Task<List<ItemViewModel>> GetServices()
        {
            var query = await _service.GetByQuery();

            var modifiedQuery = query.Select(s => new ItemViewModel()
            {
                Title = s.Title,
                Id = s.Id
            }).ToList<object>();
            List<ItemViewModel> items = modifiedQuery.Adapt<List<ItemViewModel>>();
            return items;
        }

        public async Task<PdfOptions> ProjectsPdfOption(ExportRequest request)
        {
            var fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "PDF");
            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }

            var fileName = $"{Guid.NewGuid().ToString()}-file.pdf";
            PdfOptions options = new();
            options.File = fileName;
            options.FilePath = Path.Combine(fileDirectory, fileName);

            try
            {
                StringBuilder htmlCodeBuilder = new StringBuilder();

                htmlCodeBuilder.Append(@"
    <html lang=""en"">
    <head>
        <meta charset=""UTF-8"">
        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
        <title>Project List</title>
    </head>
    <body>
        <div style=""padding: 10px;"">
            <h1 style=""background-color: goldenrod; padding: 5px;"">Project List</h1>
            ");

                foreach (var projectId in request.request)
                {
                    var data = await GetProjectById(projectId.Id);
                    string itemProject = string.Empty;
                    itemProject = "<hr />";

                    if (request.Image == 1)
                    {

                        var webRootPath = _hostingEnvironment.WebRootPath;
                        var filePath = webRootPath + "/Project/" + data.ProjectImage!;
                        string base64String = string.Empty;
                        if (File.Exists(filePath))
                        {
                            byte[] fileBytes = await File.ReadAllBytesAsync(filePath);
                            base64String = Convert.ToBase64String(fileBytes);
                        }

                        itemProject += $" <img src=\"data:image/jpeg;base64, {base64String}\" style=\"width:200px;height:auto;\" >\r\n";
                    }


                    itemProject += $"<h2>{data.ProjectName}</h2>";
                    itemProject += "<dl>";
                    if (data.IsBuilder && !string.IsNullOrEmpty(data.Builder))
                    {
                        itemProject += $"<dt>General Contractor/Builder/Construction Manager:</dt><dd>{data.Builder}</dd>";
                    }

                    if (data.IsArchitect && !string.IsNullOrEmpty(data.Architect))
                    {
                        itemProject += $"<dt>Architect:</dt><dd>{data.Architect}</dd>";
                    }

                    if (data.IsContractAmount && !string.IsNullOrEmpty(data.ContractAmount))
                    {
                        itemProject += $" <dt>Contract Amount:</dt><dd>{data.ContractAmount}</dd>";
                    }

                    if (data.IsOwnerOrDeveloper && !string.IsNullOrEmpty(data.OwnerOrDeveloper))
                    {
                        itemProject += $"<dt>Owner/Developer:</dt> <dd>{data.OwnerOrDeveloper}</dd>";
                    }
                    if (data.IsLocation && !string.IsNullOrEmpty(data.Location))
                    {
                        itemProject += $"<dt>Location:</dt><dd>{data.Location}</dd>";
                    }
                    if (data.IsStatusForeignKey && !string.IsNullOrEmpty(data.Status))
                    {
                        itemProject += $"<dt>Status:</dt><dd>{data.Status}</dd>";
                    }

                    if (data.IsScopeForeignKey && !string.IsNullOrEmpty(data.Scope))
                    {
                        itemProject += $"<dt>Scope:</dt><dd>{data.Scope}</dd>";
                    }

                    itemProject += "</dl><ul>";

                    if (data.IsScopeForeignKey && !string.IsNullOrEmpty(data.Scope))
                    {
                        itemProject += $"<dt>Scope:</dt><dd>{data.Scope}</dd>";
                    }

                    if (data.IsReferenceContactName && !string.IsNullOrEmpty(data.ReferenceContactName))
                    {
                        itemProject += $"<li> Name: < strong >{data.ReferenceContactName}</ strong ></ li >";
                    }

                    if (data.IsReferenceContactEmail && !string.IsNullOrEmpty(data.ReferenceContactEmail))
                    {
                        itemProject += $"<li> Email: < strong >{data.ReferenceContactEmail}</ strong ></ li >";
                    }

                    if (data.IsReferenceContactPhone && !string.IsNullOrEmpty(data.ReferenceContactPhone))
                    {
                        itemProject += $"<li> Phone Number: < strong >{data.ReferenceContactPhone}</ strong ></ li >";
                    }

                    if (data.IsReferenceContactAddress && !string.IsNullOrEmpty(data.ReferenceContactAddress))
                    {
                        itemProject += $"<li> Address: < strong >{data.ReferenceContactAddress}</ strong ></ li >";
                    }


                    itemProject += "</ul>";











                    htmlCodeBuilder.Append(itemProject);


                   

                    if (data.Services != null && data.Services.Any())
                    {
                        htmlCodeBuilder.Append($@"  <h3>Service:</h3>");
                        foreach (var item in data.Services)
                        {
                            htmlCodeBuilder.Append($@"<span style=""border: 1px solid black; padding: 5px; margin: 5px;"">{item.Title}</span>");
                        }
                    }

                    if (data.IsDescription && !string.IsNullOrEmpty(data.Description))
                    {
                        string description = $"<br/><h3>Description:</h3>{data.Description}";
                        htmlCodeBuilder.Append(description);
                    }

                   

                    //if (data.Pictures != null)
                    //{
                    //    foreach (var item in data.Pictures)
                    //    {
                    //        htmlCodeBuilder.Append($@"<img style=""width: 250px; height: 150px;"" src=""{item}"" />");
                    //    }
                    //}
                }

                htmlCodeBuilder.Append(@"</div></body></html>");
                options.Content = htmlCodeBuilder.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return options;
        }

        public async Task<List<ScopeItem>> GetScopes()
        {
            var result = await _scopeRepository.GetAll();
            List<ScopeItem> scopes = result.Adapt<List<ScopeItem>>();
            return scopes;
        }
    }
}
