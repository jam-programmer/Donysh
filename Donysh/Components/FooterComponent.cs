using Application.Services.Ui;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Components
{
    public class FooterComponent:ViewComponent
    {
        private readonly IUserInterface _userInterface;

        public FooterComponent(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _userInterface.GetFooter();
            return View("/Views/Shared/ViewComponent/Footer.cshtml", model);
        }
    }
}
