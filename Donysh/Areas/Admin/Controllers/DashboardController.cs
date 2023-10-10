using Microsoft.AspNetCore.Mvc;

namespace Donysh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        [HttpGet]
        [Route("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
