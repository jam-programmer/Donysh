using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DataTransferObjects.Setting;
using Domain.Entities;
using Mapster;

namespace Application.ConfigMapster.SettingMao
{
    public static class SettingMapster
    {
        public static TypeAdapterConfig MapSetting()
        {
            var config=new TypeAdapterConfig();
            config.NewConfig<SettingEntity, SettingDto>()
            
                .Map(d => d.AboutDescription, e => e.AboutDescription)
                .Map(d => d.Address, e => e.Address)
                .Map(d => d.Banner, e => e.Banner)
                .Map(d => d.Description, e => e.Description)
                .Map(d => d.Email, e => e.Email)
                .Map(d => d.FaceBook, e => e.FaceBook)
                .Map(d => d.Instagram, e => e.Instagram)
                .Map(d => d.Linkedin, e => e.Linkedin)
                .Map(d => d.Logo, e => e.Logo)
                .Map(d => d.PartnerDescription, e => e.PartnerDescription)
                .Map(d => d.PhoneNumber, e => e.PhoneNumber)
                .Map(d => d.ProjectDescription, e => e.ProjectDescription)
                .Map(d => d.ServiceDescription, e => e.ServiceDescription)
                .Map(d => d.SiteTitle, e => e.SiteTitle)
                .Map(d => d.TeamDescription, e => e.TeamDescription)
                .Map(d => d.Twitter, e => e.Twitter).Compile();
            return config;

        }
    }
}
