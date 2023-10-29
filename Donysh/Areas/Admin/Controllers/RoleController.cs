using Application.DataTransferObjects.Identity.Role;
using Application.DataTransferObjects.Identity.Role.RoleValidator;
using Application.DataTransferObjects.Service.ServiceValidator;
using Application.Services.Identity.Role;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRole _role;

        public RoleController(IRole role)
        {
            _role = role;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string search = "")
        {
            var pageModel = await _role.GetRoles(page, pageSize, search);
            return View(pageModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddRoleDto model)
        {
            var validate = new AddRoleValidator();
            var results = await validate.ValidateAsync(model);
            if (results.IsValid)
            {
                await _role.AddRole(model);
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
            var pageModel = await _role.GetRoleById(id);
            return View(pageModel); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateRoleDto model)
        {
            var validate = new UpdateRoleValidator();
            var results = await validate.ValidateAsync(model);
            if (results.IsValid)
            {
                await _role.UpdateRole(model);
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in results.Errors)
            {
                ViewBag.Alert = error.ErrorMessage;
            }
            return View(model);
        }
        [HttpGet]
        [Route("/Admin/Role/Remove/{id}")]
        public async Task<bool> Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            var result = await _role.RemoveRole(id);
            return result;
        }
    }
}
