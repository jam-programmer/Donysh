using Application.DataTransferObjects.Identity.User;
using Application.DataTransferObjects.Identity.User.UserValidator;
using Application.Services.Identity.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public Task<IActionResult> SignIn()
        {
            return Task.FromResult<IActionResult>(View());
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDto model)
        {
            ViewBag.Alert = "";
            var validate = new SignInValidator();
            var result=await validate.ValidateAsync(model);
            if (result.IsValid)
            {
                //Check With UserName
                var findByUsername = await _userManager.FindByNameAsync(model.UserName!);
                var findByEmail = await _userManager.FindByEmailAsync(model.UserName!);
                if (findByUsername != null)
                {
                    var checkPassword =
                        await _signInManager.CheckPasswordSignInAsync(findByUsername!, model.Password!, true);

                    if (checkPassword.Succeeded)
                    {
                        await _signInManager.SignInAsync(findByUsername!, model.SaveInfo);
                        return Redirect("/");
                    }

                    if (checkPassword.IsLockedOut)
                    {
                        ViewBag.Alert += "Your account is blocked.";
                    }  
                    
                    if (checkPassword.IsNotAllowed)
                    {
                        ViewBag.Alert += "Your entry is unauthorized.";
                    }
                }
                else if (findByEmail != null)
                {
                    var checkPassword =
                        await _signInManager.CheckPasswordSignInAsync(findByEmail!, model.Password!, true);

                    if (checkPassword.Succeeded)
                    {
                        await _signInManager.SignInAsync(findByEmail!, model.SaveInfo);
                        return Redirect("/");
                    }

                    if (checkPassword.IsLockedOut)
                    {
                        ViewBag.Alert += "Your account is blocked.";
                    }

                    if (checkPassword.IsNotAllowed)
                    {
                        ViewBag.Alert += "Your entry is unauthorized.";
                    }
                }
                else
                {
                    ViewBag.Alert += "User account not found.";
                }

            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ViewBag.Alert += error + "\n\r";
                }
            }
            return View(model);
        }
    }
}
