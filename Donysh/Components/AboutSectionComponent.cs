using Application.Services.Ui;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Components
{
    public class AboutSectionComponent:ViewComponent
    {
        private readonly  IUserInterface _userInterface;

        public AboutSectionComponent(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model = await _userInterface.GetHomeAboutSection();
            return View("/Views/Shared/ViewComponent/AboutSection.cshtml", model);
        }
    }
}
