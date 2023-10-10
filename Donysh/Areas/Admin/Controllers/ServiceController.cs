using Application.DataTransferObjects.Category.CategoryValidator;
using Application.DataTransferObjects.Category;
using Application.DataTransferObjects.Service;
using Application.DataTransferObjects.Service.ServiceValidator;
using Application.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IService _service;

        public ServiceController(IService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string search = "")
        {
            var pageModel = await _service.GetServicesAsync(page, pageSize, search);
            return View(pageModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddServiceDto model)
        {
            var validate = new AddServiceValidator();
            var results = await validate.ValidateAsync(model);
            if (results.IsValid)
            {
                await _service.AddService(model);
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in results.Errors)
            {
                ViewBag.Alert = error.ErrorMessage;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var pageModel = await _service.GetServiceById(id);
            if (pageModel == null)
            {
                return Redirect("/404");
            }

            return View(pageModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateServiceDto model)
        {
            var validate = new UpdateServiceValidator();
            var results = await validate.ValidateAsync(model);
            if (results.IsValid)
            {
                await _service.UpdateServiceAsync(model);
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in results.Errors)
            {
                ViewBag.Alert = error.ErrorMessage;
            }
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Service/Delete/{id}")]
        public async Task<bool> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            var result = await _service.DeleteServiceAsync(id);
            return result;
        }
        public async Task<IActionResult> Trash(int page = 1, int pageSize = 10, string search = "")
        {
            var pageModel = await _service.GetTrashServicesAsync(page, pageSize, search);
            return View(pageModel);
        }


        [HttpGet]
        [Route("/Admin/Service/Back/{id}")]
        public async Task<bool> Back(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            var result = await _service.BackServiceAsync(id);
            return result;
        }

        [HttpGet]
        [Route("/Admin/Service/Remove/{id}")]
        public async Task<bool> Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            var result = await _service.RemoveServiceAsync(id);
            return result;
        }


    }
}
