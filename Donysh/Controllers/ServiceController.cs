using Application.Services.Ui;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IUserInterface _userInterface;

        public ServiceController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }
        public async Task<IActionResult> Services()
        {
            var pageModel = await _userInterface.GetHomeServiceSection();
            return View(pageModel);
        }
        public async Task<IActionResult> ServiceDetail(string serviceId)
        {
            var pageModel = await _userInterface.GetServiceDetailById(serviceId);
            return View(pageModel);
        }
    }
}
