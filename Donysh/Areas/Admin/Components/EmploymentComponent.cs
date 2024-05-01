using Application.Services.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Areas.Admin.Components
{
    public class EmploymentComponent:ViewComponent
    {
        private readonly IDashboard _dashboard;

        public EmploymentComponent(IDashboard dashboard)
        {
            _dashboard = dashboard;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _dashboard.GetLastResumes();
            return View("/Areas/Admin/Views/Shared/ViewComponent/EmploymentBox.cshtml", model);

        }
    }
}
