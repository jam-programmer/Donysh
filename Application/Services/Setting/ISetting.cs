using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DataTransferObjects.Setting;

namespace Application.Services.Setting
{
    public interface ISetting
    {
        Task UpdateSetting(SettingDto? setting);
        Task<SettingDto> GetSetting();  
    }
}
