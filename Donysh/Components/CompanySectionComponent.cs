using Application.Services.Ui;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Components
{
    public class CompanySectionComponent:ViewComponent
    {
        private readonly IUserInterface _userInterface;

        public CompanySectionComponent(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _userInterface.GetHomeCompanySection();
            return View("/Views/Shared/ViewComponent/CompanySection.cshtml", model);
        }
    }
}
