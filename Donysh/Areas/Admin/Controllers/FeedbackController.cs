using Application.DataTransferObjects.Company.CompanyValidator;
using Application.DataTransferObjects.Company;
using Application.DataTransferObjects.Feedback;
using Application.Services.Feedback;
using Application.Services.Team;
using Donysh.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        [HttpGet]
        public async Task<IActionResult> Review(string id)
        {
            var pageModel = await _feedback.GetById(id);
            ViewBag.Base = _generator.UrlSite() + "/Feedback/";
            return View(pageModel);
        }

        [HttpPost]
        public async Task<IActionResult> Review(UpdateFeedbackDto model)
        {

            await _feedback.UpdateAsync(model);
                return RedirectToAction(nameof(Index));
         
        }
    }
}
