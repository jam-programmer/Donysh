using Application.DataTransferObjects.Page;
using Application.DataTransferObjects.Page.PageValidator;
using Application.Services.Page;
using Donysh.Tools;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageController : Controller
    {
        private readonly Generator _generator;
        private readonly IPage _page;
        private string rootStatic;
        public PageController(IPage page,IWebHostEnvironment environment, Generator generator)
        {
            _generator = generator;
            _page = page;
            rootStatic = environment.WebRootPath;
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
            ViewBag.Base = _generator.UrlSite() + "/Page/";
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
            ViewBag.Base = _generator.UrlSite() + "/Page/";
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


        [HttpPost]
        public IActionResult Upload()
        {
            var file = Request.Form.Files[0];
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return Ok(new { url = "/uploads/" + file.FileName });
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("/CKUpload")]
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]

        public IActionResult UploadImage()
        {
            var myFile = Request.Form.Files[0];
            if (myFile==null)
            {
                var fileNotSelect = new
                {
                    uploaded = false,
                    url = string.Empty
                };
                return Json(fileNotSelect);
            }

            var file = myFile;
            var oldFileName=file.FileName;
            var newFileName = Guid.NewGuid() + System.IO.Path.GetExtension(oldFileName);
            var pathSave = System.IO.Path.Combine(rootStatic, "UploadEditor", newFileName);
            using (var fileStream=new System.IO.FileStream(pathSave,FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            var pathFile = "/UploadEditor/" + newFileName;
            var uploadSuccess = new
            {
                uploaded = true,
                url = pathFile
            };
            return Json(uploadSuccess);
        }
    }
}
