using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Builder;
using Application.Common.Interface;
using Domain.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure.Configuration
{
    public static class ConfigurationInfrastructure
    {
        public static IServiceCollection InfrastructureServices
        (this IServiceCollection services,
            IConfiguration configuration)
        {
         
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DataBaseContext>()
                .AddRoles<IdentityRole>()
                .AddDefaultTokenProviders(); ;

            services.AddDbContext<DataBaseContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DonyshDataBase"));
            });
            services.AddScoped<ISqlServer>(provider => provider.GetRequiredService<DataBaseContext>());
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); 
            services.AddScoped(typeof(IDapper<>), typeof(DapperRepository<>));
            ConnectionOptions.ConnectionString = configuration.GetConnectionString("DonyshDataBase");
            return services;
        }
    }
}
