using Application.Services.Ui;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Components
{
    public class ServiceSectionComponent:ViewComponent
    {
        private readonly IUserInterface _userInterface;

        public ServiceSectionComponent(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _userInterface.GetHomeServiceSection();
            return View("~/Views/Shared/ViewComponent/ServiceSection.cshtml", model);
        }
    }
}
