using Application.ConfigMapster.ScopeWorkMap;
using Application.ConfigMapster.SettingMao;
using Application.ConfigMapster.UserMap;
using Application.Core;
using Application.DataTransferObjects.Setting;
using Application.Services.Identity.User;
using Application.Services.ScopeWork;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;
using static Dapper.SqlMapper;

namespace Application.Services.Setting
{
    public class Setting : ISetting
    {
        private readonly IRepository<SettingEntity> _repository;
        private readonly IRepository<AboutEntity> _aboutRepository;

        public Setting(IRepository<SettingEntity> repository, IRepository<AboutEntity> aboutRepository)
        {
            _repository = repository;
            _aboutRepository = aboutRepository;
        }

        public async Task<AboutDto> GetAbout()
        {
            AboutDto about = new();
            var findAbout = await _aboutRepository.FirstOrDefaultAsync();
            if (findAbout == null)
            {
                about.Banner= "default.jpg";
                return about;
            }

            about = findAbout.Adapt<AboutDto>();
            return about;
        }
        public async Task UpdateAbout(AboutDto about)
        {
            var banner = FileProcessing.FileUpload(about.File, about.Banner, "About");
          
            var findAbout = await _aboutRepository.FirstOrDefaultAsync();
            if (findAbout == null)
            {
                AboutEntity aboutEntity = new();
                aboutEntity.Description = about.Description;
                aboutEntity.Id = Guid.NewGuid().ToString();
                aboutEntity.Banner=banner;
                await _aboutRepository.Insert(aboutEntity);
            }
            else
            {
                findAbout.Banner = banner;
                findAbout.UpdateTime = DateTimeOffset.Now;
                findAbout.Description=about.Description;
                await _aboutRepository.Update(findAbout);
            }
        }

        public async Task<SettingDto> GetSetting()
        {
            SettingDto setting = new SettingDto();
            var findSetting = await _repository.FirstOrDefaultAsync();
            if (findSetting == null)
            {
                setting.Logo = "default.jpg";
                setting.Banner = "default.jpg";
                return setting;
            }
            setting = findSetting.Adapt<SettingDto>(SettingMapster.MapSetting());
            return setting;
        }

      
        public async Task UpdateSetting(SettingDto? setting)
        {
            if (setting!.BannerFile != null)
            {
                setting.Banner = FileProcessing.FileUpload(setting.BannerFile, setting.Banner, "Setting");
            }

            if (setting.LogoFile != null)
            {
                setting.Logo = FileProcessing.FileUpload(setting.LogoFile, setting.Logo, "Setting");
            }
            if (setting.AboutImageFile != null)
            {
                setting.AboutImage = FileProcessing.FileUpload(setting.AboutImageFile, setting.AboutImage, "Setting");
            }  
            if (setting.BannerPageHeaderFile != null)
            {
                setting.BannerPageHeader = FileProcessing.FileUpload(setting.BannerPageHeaderFile, setting.BannerPageHeader, "Setting");
            }

            var findSetting = await _repository.FirstOrDefaultAsync();
            if (findSetting == null)
            {
                SettingEntity entity = new SettingEntity();
                setting.Adapt(entity, SettingMapster.MapSetting());
                entity.Id = Guid.NewGuid().ToString();
                await _repository.Insert(entity);
            }
            else
            {
                findSetting.UpdateTime=DateTimeOffset.Now;
                setting.Adapt(findSetting, SettingMapster.MapSetting());
                await _repository.Update(findSetting);
            }
        }
    }
}
