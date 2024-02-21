using Application.Services.Status;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Components
{
    public class StatusSectionComponent : ViewComponent
    {
        private readonly IStatus _status;

        public StatusSectionComponent(IStatus status)
        {
            _status = status;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _status.GetStatusesItemAsync();
            return View("/Views/Shared/ViewComponent/StatusSection.cshtml", model);
        }
    }
}
