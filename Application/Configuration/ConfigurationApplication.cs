using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration
{
    public static class ConfigurationApplication
    {
        public static IServiceCollection ApplicationServices
        (this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddFluentValidationAutoValidation();
            ServiceRegister.AddService(services);
            ValidatorRegister.AddValidator(services);
            return services;
        }
    }
}
