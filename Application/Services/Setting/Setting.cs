using Application.ConfigMapster.ScopeWorkMap;
using Application.ConfigMapster.SettingMao;
using Application.Core;
using Application.DataTransferObjects.Setting;
using Application.Services.ScopeWork;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;

namespace Application.Services.Setting
{
    public class Setting : ISetting
    {
        private readonly IRepository<SettingEntity> _repository;

        public Setting(IRepository<SettingEntity> repository)
        {
            _repository = repository;
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

            var findSetting = await _repository.GetByIdAsync(setting.Id!);
            if (findSetting == null)
            {
                SettingEntity entity = new();
                entity = setting!.Adapt<SettingEntity>(SettingMapster.MapSetting());
                await _repository.Insert(entity);
            }
            else
            {
                findSetting.UpdateTime=DateTimeOffset.Now;
                findSetting = setting.Adapt<SettingEntity>(SettingMapster.MapSetting());
                await _repository.Update(findSetting);
            }
        }
    }
}
