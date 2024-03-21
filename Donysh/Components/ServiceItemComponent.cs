using Application.Services.Ui;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Components
{
    public class ServiceItemComponent : ViewComponent
    {
        private readonly IUserInterface _userInterface;

        public ServiceItemComponent(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model = await _userInterface.GetServices();
            return View("/Views/Shared/ViewComponent/ServiceItem.cshtml", model);
        }
    }
}
