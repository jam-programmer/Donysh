using Application.DataTransferObjects.Feedback;
using Application.ViewModels.Feedback;
using Application.ViewModels.Main;


namespace Application.Services.Feedback
{
    public interface IFeedback
    {
        Task<ListGenerics<FeedbackViewModel>> GetFeedbackAsync(int page, int pageSize, string search = "");
        Task<UpdateFeedbackDto> GetById(string id);
        Task<bool> DeleteFeedbackById(string id);
        Task AddAsync(AddFeedbackDto model);
        Task UpdateAsync(UpdateFeedbackDto model);
        Task<bool> RemoveById(string id);

        Task<List<FeedbackItemViewModel>> GetActiveFeedbackAsync();
    }
}
