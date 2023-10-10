using Application.Core;
using Application.DataTransferObjects.Company;
using Application.ViewModels.Company;
using Domain.Entities;
using Mapster;

namespace Application.ConfigMapster.CompanyMap
{
    public static class CompanyMapster
    {
        public static TypeAdapterConfig MapCompanyToViewModel()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<CompanyEntity, CompanyViewModel>()
                .Map(v => v.Id, e => e.Id)
                .Map(v => v.Name, e => e.Name)
                .Map(v => v.LogoPath, e => e.LogoPath)
                .Map(v => v.Link, e => e.Link)
                .Compile();
            return config;
        }

        public static TypeAdapterConfig MapCompanyToAddCompanyDto()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<AddCompanyDto, CompanyEntity>()
                .Map(d => d.Type, e => e.CompanyType)
                .Map(d => d.Name, e => e.Name)
                .Map(d => d.Link, e => e.Link)
                .Map(d => d.LogoPath, e => FileProcessing.FileUpload(e.LogoFile, null, "Company"))
                .Compile();
            return config;
        }

        public static TypeAdapterConfig MapCompanyToUpdateCompanyDto()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<UpdateCompanyDto, CompanyEntity>()
                .Map(d => d.Link, e => e.Link).TwoWays()
                .Map(d => d.Type, e => e.CompanyType)
                .Map(d => d.Id, e => e.Id)
                .Map(d => d.LogoPath, e => e.Path)
                .Map(d => d.Name, e => e.Name);
            return config;
        }
    }
}
