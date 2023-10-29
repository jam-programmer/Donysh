using Application.DataTransferObjects.Setting;
using Application.Services.Setting;
using Donysh.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SettingController : Controller
    {
        private readonly ISetting _setting;
        private readonly Generator _generator;

        public SettingController(ISetting setting, Generator generator)
        {
            _setting = setting;
            _generator = generator;
        }
        [HttpGet]
        public async Task<IActionResult> General()
        {
            var pageModel = await _setting.GetSetting();
            ViewBag.Base = _generator.UrlSite()+ "/Setting/";
            return View(pageModel);
        }
        [HttpPost]
        public async Task<IActionResult> General(SettingDto setting)
        {
            await _setting.UpdateSetting(setting);
            return RedirectToAction(nameof(General));
        }
    }
}
