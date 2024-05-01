using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Setting;
using Application.ViewModels.Ui.Home;
using Domain.Entities;
using Mapster;

namespace Application.ConfigMapster.UiMap.HomeMap
{
    public static class UiHomeMapster
    {
        public static TypeAdapterConfig HomeHeaderSection()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<SettingEntity, HomeHeaderSection>()
                .Map(v => v.Banner, e => e.Banner)
                .Map(v => v.Description, e => e.Description)
                .Map(v => v.SiteTitle, e => e.SiteTitle)
                .Map(v => v.Logo, e => e.Logo)
                .Compile();
            return config;
        }
        public static TypeAdapterConfig HomeAboutSection()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<SettingEntity, HomeAboutSection>()
                .Map(v => v.AboutImage, e => e.AboutImage)
                .Map(v => v.AboutDescription, e => e.AboutDescription)
                .Map(v => v.CompletedProject, e => e.CompletedProject)
                .Map(v => v.WorkExperience, e => e.WorkExperience)
                .Compile();
            return config;
        }
        public static TypeAdapterConfig HomeServiceSection()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<ServiceEntity, ServiceBox>()
                .Map(v => v.Id, e => e.Id)
                .Map(v => v.SmallDescription, e => e.SmallDescription)
                .Map(v => v.Title, e => e.Title)
                .Map(v => v.Image, e => e.Image)
                .Compile();
            return config;
        }

        public static TypeAdapterConfig HomePortfolioSectionServiceItem()
        {
            var config=new TypeAdapterConfig();
            config.NewConfig<StatusEntity,ServiceItem>()
                .Map(v=>v.Id,e=>e.Id)
                .Map(v=>v.Status,e=>e.Status)
                .Compile();
            return  config;
        }
       
    }
}
