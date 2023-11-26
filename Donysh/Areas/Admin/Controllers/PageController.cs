using Application.DataTransferObjects.Page;
using Application.DataTransferObjects.Page.PageValidator;
using Application.Services.Page;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageController : Controller
    {
        private readonly IPage _page;

        public PageController(IPage page)
        {
            _page = page;
        }

        public async Task<IActionResult> Index()
        {
            var pageModel = await _page.GetPagesAsync();
            return View(pageModel);
        }
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(AddPageDto model)
        {
            var validate = new AddPageValidator();
            var result = await validate.ValidateAsync(model);
            if (result.IsValid)
            {
                await _page.AddPage(model);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Alert = "";
            foreach (var error in result.Errors)
            {
                ViewBag.Alert += error.ErrorMessage + "\r\n";
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var pageModel = await _page.GetPageById(id);
            return View(pageModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdatePageDto model)
        {
            var validate = new UpdatePageValidator();
            var result = await validate.ValidateAsync(model);
            if (result.IsValid)
            {
                await _page.UpdatePage(model);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Alert = "";
            foreach (var error in result.Errors)
            {
                ViewBag.Alert += error.ErrorMessage + "\r\n";
            }
            return View(model);
        }
        [HttpGet]
        [Route("/Admin/Page/Remove/{id}")]
        public async Task<bool> Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            var result = await _page.DeletePage(id);
            return result;
        }
    }
}
