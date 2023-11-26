using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using Application.ConfigMapster.CompanyMap;
using Application.ViewModels.Company;
using System.Drawing.Printing;
using Application.Core;

namespace Application.Services.Ui
{
    public class UserInterface : IUserInterface
    {
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

        public UserInterface(ISetting setting, IDapper<ProjectServices> dapperService, IRepository<ServiceEntity> service, IDapper<ProjectBox> dapper, IRepository<TeamEntity> team, IRepository<CompanyEntity> company, IRepository<ProjectEntity> projectRepository, IRepository<PictureEntity> pictureRepository, IRepository<PageEntity> pageRepository, IRepository<RequestEntity> requestRepository, IRepository<AboutEntity> about, IRepository<ContactEntity> contactRepository)
        {
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
            var projects = await _dapper.Execute("[dbo].[SP_GetLastProject]",home);
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

        public async Task<HeaderPage> GetHeaderPage()
        {
            var setting = await _setting.GetSetting();
            HeaderPage page = setting.Adapt<HeaderPage>();
            return page;
        }

        public async Task<ProjectDetail> GetProjectById(string id)
        {
            ProjectDetail detail = new();
            var project = await _projectRepository.GetByIdAsync(id);
            detail = project!.Adapt<ProjectDetail>();
            var services = await _dapperService.ExecuteQuery(
                $"select s.Id,s.Title from dy.ProjectEntityServiceEntity as ps with(nolock)\r\nInner Join dy.[Service] as s with(nolock) On ps.ServiceId=s.Id\r\nwhere ps.ProjectsId='{id}'");
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
                _dapper.ExecuteQuery($"SELECT S.Id AS ServiceId, S.Title AS ServiceTitle,\r\nP.Id,P.ProjectName,P.ProjectImage\r\nFROM [Dy].[ProjectEntityServiceEntity] AS PS WITH(NOLOCK)\r\nINNER JOIN DY.Project AS P WITH(NOLOCK) ON PS.ProjectsId = P.Id\r\nINNER JOIN DY.[Service] AS S WITH(NOLOCK) ON PS.ServiceId=S.Id\r\nWHERE PS.ServiceId='{id}'");
            serviceDetail.Projects = project;
            return serviceDetail;
        }

        public async Task<PdfOptions> ProjectPdfOption(string projectId)
        {
            var data = await GetProjectById(projectId);

            string htmlCode = $@"
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Document</title>
</head>

<body>
    <div style=""padding: 10px;"">
        <h1 style=""background-color: goldenrod;
        padding: 5px;"">{data.ProjectName}</h1>
        <hr />
        <h3>Detail:</h3>
        <dl>
            <dt style="" color: darkblue;
        font-family: bold;
        font-size: 18px;"">General Contractor/Builder/Construction Manager:</dt>
            <dd style=""color: red;
        font-family: bold;
        font-size: 20px;"">{data.Builder}</dd>

            <dt style="" color: darkblue;
        font-family: bold;
        font-size: 18px;"">Architect:</dt>
            <dd  style=""color: red;
        font-family: bold;
        font-size: 20px;"">{data.Architect}</dd>

            <dt style="" color: darkblue;
        font-family: bold;
        font-size: 18px;"">Contract Amount:</dt>
            <dd  style=""color: red;
        font-family: bold;
        font-size: 20px;"">{data.ContractAmount}</dd>

            <dt style="" color: darkblue;
        font-family: bold;
        font-size: 18px;"">Owner/Developer:</dt>
            <dd>{data.Builder}</dd>

            <dt style="" color: darkblue;
        font-family: bold;
        font-size: 18px;"">Location:</dt>
            <dd  style=""color: red;
        font-family: bold;
        font-size: 20px;"">{data.Location}</dd>

            <dt style="" color: darkblue;
        font-family: bold;
        font-size: 18px;"">Status:</dt>
            <dd  style=""color: red;
        font-family: bold;
        font-size: 20px;"">{data.Status}</dd>

            <dt style="" color: darkblue;
        font-family: bold;
        font-size: 18px;"">Scope:</dt>
            <dd  style=""color: red;
        font-family: bold;
        font-size: 20px;"">{data.Scope}</dd>
        </dl>
        <ul>
            <li>Name:<strong>{data.ReferenceContactName}</strong></li>
            <li>Email:<strong>{data.ReferenceContactEmail}</strong></li>
            <li>Phone Number:<strong>{data.ReferenceContactPhone}</strong></li>
            <li>Address:<strong>{data.ReferenceContactAddress}</strong></li>
        </ul>
        <br><h3>Service:</h3>";

            if (data.Services!=null)
            {
                foreach (var item in data.Services!)
                {
                    htmlCode += $@"<span style="" border: 1px solid black;padding: 5px;margin: 5px;"">{item.Title}</span>";
                }
            }
           

            htmlCode += $@"<br/><h3>Description:</h3>{data.Description}";
            if (data.Pictures != null)
            {
                foreach (var item in data.Pictures!)
                {
                    htmlCode += $@" <img style=""width: 250;height: 150;"" src=""{data.ProjectImage}"" />";
                }
            }
            htmlCode += @"</div></body></html> ";
           
            var fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "PDF");
            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }
            var fileName = $"{Guid.NewGuid().ToString()}-file.pdf";
            PdfOptions options = new();
            options.Content = htmlCode;
            options.File = fileName;
            options.FilePath = fileDirectory = Path.Combine(fileDirectory,fileName!);
            return options;
        }

        public async Task<Footer> GetFooter()
        {
          Footer footer = new();
          var setting = await _setting.GetSetting();
          footer.ColumnOne = setting.Adapt<AboutAndMedia>();
          var pageQuery = await _pageRepository.GetByQuery();
          var page =await pageQuery.Where(w => w.Location == TabLocation.Footer).ToListAsync();
         var linkPages = page.Adapt<List<Pages>>();
         footer.ColumnTwo = linkPages;
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
            header.Menu=page.Adapt<List<Pages>>();
            return header;
        }

        public async Task<ListGenerics<ProjectCard>> GetListProject(int page)
        {
            int pageSelected = page;
            int count =await _projectRepository.GetCount();
            int pageSkip = (page - 1) * 10;
            var query = await _projectRepository.GetByQuery();
            var projects =await query.Skip(pageSkip).Take(10).ToListAsync();
            count = count.PageCount(10);
            ListGenerics<ProjectCard> result = new();
            result.List = projects.Adapt<List<ProjectCard>>();
            result.Count = count;
            result.CurrentPage = page;

            if (count > 1 && projects.Count < 10 &&  page == 1)
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
                    await _dapper.InsertWithOutColumn("Dy.RequestEntityServiceEntity", requestEntity.Id, request.Services);
                }
                return true;
            }
            catch (Exception e)
            {
               // Console.WriteLine(e);
                return false;
            }
        }

        public async Task<AboutPage> GetAboutPage()
        {
            AboutPage about = new();
            var setting = await _setting.GetSetting();
            about.TeamDescription=setting.TeamDescription;  
            var aboutEntity = await _about.FirstOrDefaultAsync();
            about = aboutEntity!.Adapt<AboutPage>();
            var companies = await _company.GetAll();
            about.Companies = companies.Adapt<List<CompanyBox>>();
            var members = await _team.GetAll();
            about.Members = members.Adapt<List<TeamBox>>();
            return about;
        }

        public async Task<bool> AddContactRequest(RequestContact request)
        {
           ContactEntity contactEntity = new();
           contactEntity = request.Adapt<ContactEntity>();
           try
           {
               await _contactRepository.Insert(contactEntity);
               return true;
           }
           catch (Exception e)
           {
               return false;
           }

        }
    }
}
