using Application.DataTransferObjects.Service;
using Application.ViewModels.Service;
using Domain.Entities;
using Mapster;


namespace Application.ConfigMapster.ServiceMap
{
    public static class ServiceMapster
    {
        public static TypeAdapterConfig MapServiceToViewModel()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<ServiceEntity, ServiceViewModel>()
                .Map(v => v.Id, e => e.Id)
                .Map(v => v.Title, e => e.Title)
                .Compile();
            return config;
        }
        public static TypeAdapterConfig MapServiceToUpdateServiceDto()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<ServiceEntity, UpdateServiceDto>()
                .Map(d => d.Id, e => e.Id)
                .Map(d => d.Title, e => e.Title)
                .Map(d => d.Description, e => e.Description)
                .Compile();
            return config;
        }

        public static TypeAdapterConfig MapServiceToAddServiceDto()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<ServiceEntity, AddServiceDto>()
              
                .Map(d => d.Title, e => e.Title)
                .Map(d => d.Description, e => e.Description)
                .Compile();
            return config;
        }
    }
}
