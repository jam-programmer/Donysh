using Application.Services.Ui;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Components
{
    public class InformationSectionComponent:ViewComponent
    {
        private readonly IUserInterface _userInterface;

        public InformationSectionComponent(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model = await _userInterface.GetHomeInformationSection();
            return View("/Views/Shared/ViewComponent/InformationSection.cshtml", model);
        }
    }
}
