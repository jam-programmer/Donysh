using Application.Services.Ui;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Components
{
    public class ScopeItemComponent:ViewComponent
    {
        private readonly IUserInterface _userInterface;

        public ScopeItemComponent(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model = await _userInterface.GetScopes();
            return View("/Views/Shared/ViewComponent/ScopeItem.cshtml", model);
        }
    }
}
