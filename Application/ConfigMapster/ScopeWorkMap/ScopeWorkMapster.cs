using Application.DataTransferObjects.ScopeWork;
using Application.ViewModels.ScopeWork;
using Domain.Entities;
using Mapster;

namespace Application.ConfigMapster.ScopeWorkMap
{
    public static class ScopeWorkMapster
    {
        public static TypeAdapterConfig MapScopeWorkToViewModel()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<ScopeWorkEntity, ScopeWorkViewModel>()
                .Map(v => v.Id, e => e.Id)
                .Map(v => v.Title, e => e.Title)
                .Compile();
            return config;
        }
        public static TypeAdapterConfig MapScopeWorkToAddScopeWorkDto()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<ScopeWorkEntity, UpdateScopeWorkDto>()

                .Map(d => d.Title, e => e.Title)
                .Compile();
            return config;
        }
        public static TypeAdapterConfig MapScopeWorkToUpdateScopeWorkDto()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<ScopeWorkEntity, UpdateScopeWorkDto>()
                .Map(d => d.Id, e => e.Id)
                .Map(d => d.Title, e => e.Title)
                .Compile();
            return config;
        }


    }
}
