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
        public async Task<IViewComponentResult> InvokeAsync(HeaderModel header)
        {
            var model = await _userInterface.GetHeaderPage(header.title,header.project);
            model.PageTitle= header.title;
            return View("/Views/Shared/ViewComponent/Header.cshtml", model);
        }
    }

    public class HeaderModel
    {
        public string title { set; get; }
        public bool project { set; get; } = false;
    }
}
