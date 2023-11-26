using Application.Services.Ui;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Components
{
    public class TeamSectionComponent:ViewComponent
    {
        private  readonly  IUserInterface _userInterface;
        public TeamSectionComponent(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _userInterface.GetHomeTeamSection();
            return View("/Views/Shared/ViewComponent/TeamSection.cshtml", model);
        }
    }
}
