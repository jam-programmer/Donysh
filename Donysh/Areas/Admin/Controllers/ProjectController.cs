using Application.DataTransferObjects.Project;
using Application.DataTransferObjects.Project.ProjectValidator;
using Application.Services.Project;
using Application.Services.ScopeWork;
using Application.Services.Service;
using Application.Services.Status;
using Donysh.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Donysh.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProject _project;
        private readonly Generator _generator;
        private readonly IService _service;
        private readonly IScopeWork _scopeWork;
        private readonly IStatus _status;

        public ProjectController(IProject project, Generator generator, IService service, IScopeWork scopeWork, IStatus status)
        {
            _project = project;
            _generator = generator;
            _service = service;
            _scopeWork = scopeWork;
            _status = status;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string search = "")
        {
            ViewBag.Base = _generator.UrlSite() + "/Project/";
            var pageModel =await _project.GetProjectsAsync(page, pageSize, search);
            return View(pageModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await Dependency();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProjectDto model)
        {
            var validate = new AddProjectValidator();
            var result =await validate.ValidateAsync(model);
            if (result.IsValid)
            {
                await _project.AddProject(model);
                return RedirectToAction(nameof(Index));
            }

            await Dependency(model.ScopeForeignKey, model.StatusForeignKey);
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
            ViewBag.Base = _generator.UrlSite() + "/Project/";
            var pageModel =await _project.GetProjectById(id);
            await Dependency(pageModel.ScopeForeignKey, pageModel.StatusForeignKey);
            return View(pageModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProjectDto model)
        {
            var validate = new UpdateProjectValidator();
            var result=await validate.ValidateAsync(model);
            if (result.IsValid)
            {
                await _project.UpdateProject(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Base = _generator.UrlSite() + "/Project/";
            await Dependency(model.ScopeForeignKey, model.StatusForeignKey);
            ViewBag.Alert = "";
            foreach (var error in result.Errors)
            {
                ViewBag.Alert += error.ErrorMessage + "\r\n";
            }
            return View(model);
        }


        [HttpGet]
        [Route("/Admin/Project/Delete/{id}")]
        public async Task<bool> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            var result = await _project.DeleteProjectById(id);
            return result;
        }

        #region Trash

        [HttpGet]
        public async Task<IActionResult> Trash(int page = 1, int pageSize = 10, string search = "")
        {
            ViewBag.Base = _generator.UrlSite() + "/Project/";
            var pageModel = await _project.GetTrashProjectsAsync(page, pageSize, search);
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Project/Back/{id}")]
        public async Task<bool> Back(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            var result = await _project.BackProjectById(id);
            return result;
        }

        [HttpGet]
        [Route("/Admin/Project/Remove/{id}")]
        public async Task<bool> Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            var result = await _project.RemoveProjectById(id);
            return result;
        }

        #endregion





        #region Utility
        private async Task Dependency(string? scope = "", string? status = "")
        {
            ViewBag.Services = await _service.GetServiceItemAsync();
            ViewBag.Status = new SelectList(await _status.GetStatusesItemAsync(), "Id", "Title", status);
            ViewBag.Scope = new SelectList(await _scopeWork.GetScopsItemAsync(), "Id", "Title", scope);
        }
        #endregion

    }
}
