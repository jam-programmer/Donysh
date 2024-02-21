using Application.Services.Feedback;
using Application.Services.Team;
using Donysh.Tools;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeedbackController : Controller
    {
        private readonly IFeedback _feedback;
        private readonly Generator _generator;

        public FeedbackController(IFeedback feedback, Generator generator)
        {
            _feedback = feedback;
            _generator = generator;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string search = "")
        {
            ViewBag.Base = _generator.UrlSite() + "/Feedback/";
            var pageModel = 
                await _feedback.GetFeedbackAsync(page, pageSize, search);
            return View(pageModel);
        }
    }
}
