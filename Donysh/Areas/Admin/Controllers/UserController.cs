using Application.DataTransferObjects.Identity.Role.RoleValidator;
using Application.DataTransferObjects.Identity.User;
using Application.DataTransferObjects.Identity.User.UserValidator;
using Application.Services.Identity.Role;
using Application.Services.Identity.User;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Donysh.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUser _user;
        private readonly IRole _role;

        public UserController(IUser user, IRole role)
        {
            _user = user;
            _role = role;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string search = "")
        {
            var pageModel = await _user.GetUsers(page,pageSize,search);
            return View(pageModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await Roles(null);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddUserDto model)
        {
            var validate = new AddUserValidator();
            var results = await validate.ValidateAsync(model);
            if (results.IsValid)
            {
                await _user.AddUser(model);
                return RedirectToAction(nameof(Index));
            }

            await Roles(model.Role);
            ViewBag.Alert = "";
            foreach (var error in results.Errors)
            {
                ViewBag.Alert += error.ErrorMessage;
            }
            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var pageModel = await _user.GetUserById(id);
            await Roles(pageModel.Role);
            return View(pageModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUserDto model)
        {
            ViewBag.Alert = "";
            var validate = new UpdateUserValidator();
            var results = await validate.ValidateAsync(model);
            if (results.IsValid)
            {
                var result=await _user.UpdateUser(model);
                if (string.IsNullOrEmpty(result))
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Alert += result + "\n\r";
            }
            await Roles(model.Role);
         
            foreach (var error in results.Errors)
            {
                ViewBag.Alert += error.ErrorMessage + "\n\r";
            }
            return View(model);
        }


        [HttpGet]
        [Route("/Admin/User/Remove/{id}")]
        public async Task<bool> Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            var result = await _user.RemoveUser(id);
            return result;
        }



        #region Utility

        public async Task Roles(List<string>? selected)
        {
            var roles = await _role.GetSelectRoles();
          

            if (selected!=null)
            {
                ViewBag.Roles = new SelectList(roles, "Title", "Title", selected);
            }
            else
            {
                ViewBag.Roles = new SelectList(roles, "Title", "Title");
            }
       
        }

        #endregion

    }
}
