using Application.Services.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IDashboard _dashboard;
        public DashboardController(IDashboard dashboard)
        {
            _dashboard = dashboard;   
        }
        [HttpGet]
        [Route("Admin")]
        public async Task<IActionResult> Index()
        {
            var pageModel=await _dashboard.GetDashboardAsync();
            return View(pageModel);
        }
    }
}
