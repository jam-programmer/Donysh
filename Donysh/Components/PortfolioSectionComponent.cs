using Application.Services.Ui;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Components
{
    public class PortfolioSectionComponent:ViewComponent
    {
        private readonly IUserInterface _userInterface;

        public PortfolioSectionComponent(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model = await _userInterface.GetHomePortfolioSection(true);
            return View("/Views/Shared/ViewComponent/PortfolioSection.cshtml", model);
        }
    }
}
