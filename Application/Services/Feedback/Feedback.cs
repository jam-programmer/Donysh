using Application.Core;
using Application.DataTransferObjects.Feedback;
using Application.Services.Sender;
using Application.ViewModels.Feedback;
using Application.ViewModels.Main;
using Application.ViewModels.Sender;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Feedback
{
    public class Feedback : IFeedback
    {
        private readonly IDapper<FeedbackEntity> _contact;
        private readonly IRepository<FeedbackEntity> _repository;
        private readonly ISender _sender;

        public Feedback(IDapper<FeedbackEntity> contact, IRepository<FeedbackEntity> repository, ISender sender)
        {
            _contact = contact;
            _repository = repository;
            _sender = sender;
        }

        public async Task<UpdateFeedbackDto> GetById(string id)
        {
            var model = await _repository.GetByIdAsync(id);
            UpdateFeedbackDto feedback = model!.Adapt<UpdateFeedbackDto>();
            return feedback;
        }

        public async Task AddAsync(AddFeedbackDto model)
        {
            FeedbackEntity feedback = new();
            feedback = model.Adapt<FeedbackEntity>();
            feedback.FilePath = FileProcessing.FileUpload(model.FilePath, null, "Feedback");

            await _repository.Insert(feedback);
            SenderViewModel sender = new();
            sender.Body = $"{model.FullName} from {model.CompanyName} Company wrote a feedback for you. Feedback text:{ (string.IsNullOrEmpty(model.Description) ? "" : model.Description) }";
            sender.Subject = "New feedback has been registered";
            await _sender.SendAsync(sender);
        }

        public async Task UpdateAsync(UpdateFeedbackDto model)
        {
            var feedback = await _repository.GetByIdAsync(model.Id!);
            if (feedback == null)
            {

            }
            if (model.File != null)
            {
                feedback.FilePath = FileProcessing.FileUpload(model.File, model.FilePath, "Feedback");
            }
            feedback!.IsShow = model.IsShow;
            feedback!.UpdateTime = DateTimeOffset.Now;
            feedback.Description = model.Description;
            feedback.FullName = model.FullName;
            feedback.EmailAddress = model.EmailAddress;
            feedback.CompanyName = model.CompanyName;

            await _repository.Update(feedback);
        }

        public async Task<ListGenerics<FeedbackViewModel>> GetFeedbackAsync(int page, int pageSize, string search = "")
        {
            var message = await _contact
                .GetListAsync(false, "[dbo].[SP_GetFeedback]", page, pageSize, search);
            if (!message.Any())
            {

            }
            List<FeedbackViewModel> models = message.Adapt<List<FeedbackViewModel>>();
            var count = await _repository.GetCount();
            count = count.PageCount(pageSize);
            ListGenerics<FeedbackViewModel> result = new();
            result.List = models;
            result.Count = count;
            result.CurrentPage = page;
            result.SearchKeyword = search;
            if (count > 1 && models.Count < 10 && !string.IsNullOrEmpty(search) && page == 1)
            {
                result.Pagination = false;
            }

            return result;
        }

        public async Task<bool> RemoveById(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var feedback = await _repository.GetByIdAsync(id);
            if (feedback != null)
            {

                try
                {
                    if (feedback.FilePath != null)
                    {
                        FileProcessing.RemoveFile(feedback.FilePath, "Feedback");
                    }
                    await _repository.Delete(feedback);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task<List<FeedbackItemViewModel>> GetActiveFeedbackAsync()
        {
            var query = await _repository.GetByQuery();
            var model = await query.Where(w => w.IsShow == true && w.IsDeleted == false).ToListAsync();
            List<FeedbackItemViewModel> items = model.Adapt<List<FeedbackItemViewModel>>();
            return items;
        }




        public async Task<bool> DeleteFeedbackById(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var model = await _repository.GetByIdAsync(id);
            if (model != null)
            {
                model.IsDeleted = true;
                try
                {

                    await _repository.Update(model);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
