using Application.Services.Identity.User;
using Application.Services.Ui;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Components
{
    public class MenuComponent:ViewComponent
    {
        private readonly IUserInterface _userInterface;

        public MenuComponent(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _userInterface.GetMenu();
            return View("/Views/Shared/ViewComponent/Menu.cshtml", model);
        }
    }
}
