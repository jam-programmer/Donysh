using Application.Services.ScopeWork;
using Application.Services.Company;
using Application.Services.Contact;
using Application.Services.Identity.Role;
using Application.Services.Identity.User;
using Application.Services.Page;
using Application.Services.Project;
using Application.Services.Request;
using Application.Services.Service;
using Application.Services.Setting;
using Application.Services.Status;
using Application.Services.Team;
using Application.Services.Ui;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration
{
    public static class ServiceRegister
    {
        public static void AddService(IServiceCollection service)
        {
            service.AddScoped<IScopeWork, ScopeWork>();
            service.AddScoped<IService, Service>(); 
            service.AddScoped<ICompany, Company>();
            service.AddScoped<ITeam, Team>();
            service.AddScoped<IStatus,Status>();
            service.AddScoped<ISetting, Setting>();
            service.AddScoped<IProject,Project>();
            service.AddScoped<IRole,Role>();
            service.AddScoped<IUser, User>();
            service.AddScoped<IUserInterface,UserInterface>();
            service.AddScoped<IPage, Page>();
            service.AddScoped<IContact,Contact>();
            service.AddScoped<IRequest,Request>();
        }
    }
}
