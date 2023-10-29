using Application.DataTransferObjects.Status;
using Application.DataTransferObjects.Status.StatusValidator;
using Application.Services.Status;
using Application.Services.Team;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class StatusController : Controller
    {
        private readonly IStatus _status;

        public StatusController(IStatus status)
        {
            _status = status;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int page=1,int pageSize=10,string search="")
        {
            var pageModel = await _status.GetStatusesAsync(page, pageSize, search);
            return View(pageModel);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(AddStatusDto model)
        {
            var validate = new AddStatusValidator();
            var result=await validate.ValidateAsync(model);
            if (result.IsValid)
            {
                await _status.AddStatus(model);
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in result.Errors)
            {
                ViewBag.Alert = error.ErrorMessage;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var pageModel = await _status.GetStatusById(id);
            return View(pageModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateStatusDto model)
        {
            var validate = new UpdateStatusValidator();
            var result=await validate.ValidateAsync(model);
            if (result.IsValid)
            {
                await _status.UpdateStatusAsync(model);
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in result.Errors)
            {
                ViewBag.Alert = error.ErrorMessage;
            }
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Status/Delete/{id}")]
        public async Task<bool> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            var result = await _status.DeleteStatusAsync(id);
            return result;
        }




        #region Trash

        [HttpGet]
        public async Task<IActionResult> Trash(int page = 1, int pageSize = 10, string search = "")
        {
            var pageModel = await _status.GetTrashStatusesAsync(page, pageSize, search);
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Status/Back/{id}")]
        public async Task<bool> Back(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            var result = await _status.BackStatusAsync(id);
            return result;
        }

        [HttpGet]
        [Route("/Admin/Status/Remove/{id}")]
        public async Task<bool> Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            var result = await _status.RemoveStatusAsync(id);
            return result;
        }


        #endregion
    }
}
