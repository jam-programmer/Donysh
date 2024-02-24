using Application.Services.Feedback;
using Application.Services.Team;
using Application.Services.Ui;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Components
{
    public class FeedbackComponent:ViewComponent
    {
        private readonly IFeedback _feedback;

        public FeedbackComponent(IFeedback feedback)
        {
            _feedback = feedback;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model = await _feedback.GetActiveFeedbackAsync();
            return View("/Views/Shared/ViewComponent/FeedbackSection.cshtml", model);
        }

    }
}
