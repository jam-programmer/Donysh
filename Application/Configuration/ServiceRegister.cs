using Application.Services.Category;
using Application.Services.Company;
using Application.Services.Service;
using Application.Services.Team;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration
{
    public static class ServiceRegister
    {
        public static void AddService(IServiceCollection service)
        {
            service.AddScoped<ICategory, Category>();
            service.AddScoped<IService, Service>(); 
            service.AddScoped<ICompany, Company>();
            service.AddScoped<ITeam, Team>();
        }
    }
}
