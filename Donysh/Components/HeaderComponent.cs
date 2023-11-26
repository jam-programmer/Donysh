using Application.Services.Ui;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Components
{
    public class HeaderComponent:ViewComponent
    {
        private readonly IUserInterface _userInterface;

        public HeaderComponent(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }
        public async Task<IViewComponentResult> InvokeAsync(string title)
        {
            var model = await _userInterface.GetHeaderPage();
            model.PageTitle=title;
            return View("/Views/Shared/ViewComponent/Header.cshtml", model);
        }
    }
}
