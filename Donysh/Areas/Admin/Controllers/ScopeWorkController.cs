using Application.DataTransferObjects.ScopeWork;
using Application.DataTransferObjects.ScopeWork.ScopeWorkValidator;
using Application.Services.ScopeWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ScopeWorkController : Controller
    {
        private readonly IScopeWork _ScopeWork;


        public ScopeWorkController(IScopeWork ScopeWork)
        {
            _ScopeWork = ScopeWork;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string search = "")
        {
            var pageModel = await _ScopeWork.GetScopesAsync(page, pageSize, search);
            return View(pageModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddScopeWorkDto model)
        {
            var validate = new AddScopeWorkValidator();
            var results = validate.Validate(model);
            if (results.IsValid)
            {
                _ScopeWork.AddScopeWork(model);
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
            var pageModel = await _ScopeWork.GetScopeWorkById(id);
            if (pageModel == null)
            {
                return Redirect("/404");
            }

            return View(pageModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateScopeWorkDto model)
        {
            var validate = new UpdateScopeWorkValidator();
            var results = await validate.ValidateAsync(model);
            if (results.IsValid)
            {
                await _ScopeWork.UpdateScopeWorkAsync(model);
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in results.Errors)
            {
                ViewBag.Alert = error.ErrorMessage;
            }
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/ScopeWork/Delete/{id}")]
        public async Task<bool> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            var result = await _ScopeWork.DeleteScopeWorkAsync(id);
            return result;
        }



        #region Trash
        public async Task<IActionResult> Trash(int page = 1, int pageSize = 10, string search = "")
        {
            var pageModel = await _ScopeWork.GetTrashScopesAsync(page, pageSize, search);
            return View(pageModel);
        }


        [HttpGet]
        [Route("/Admin/ScopeWork/Back/{id}")]
        public async Task<bool> Back(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            var result = await _ScopeWork.BackScopeWorkAsync(id);
            return result;
        }

        [HttpGet]
        [Route("/Admin/ScopeWork/Remove/{id}")]
        public async Task<bool> Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            var result = await _ScopeWork.RemoveScopeWorkAsync(id);
            return result;
        }


        #endregion
    }

}
