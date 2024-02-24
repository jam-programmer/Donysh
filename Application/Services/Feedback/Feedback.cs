using Application.ViewModels.Contact;
using Application.ViewModels.Feedback;
using Application.ViewModels.Main;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Core;
using Application.DataTransferObjects.Feedback;
using Mapster;
using Application.ConfigMapster.CompanyMap;
using Application.Services.Company;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Feedback
{
    public class Feedback: IFeedback
    {
        private readonly IDapper<FeedbackEntity> _contact;
        private readonly IRepository<FeedbackEntity> _repository;

        public Feedback(IDapper<FeedbackEntity> contact, IRepository<FeedbackEntity> repository)
        {
            _contact = contact;
            _repository = repository;
        }

        public async Task<UpdateFeedbackDto> GetById(string id)
        {
            var model= await _repository.GetByIdAsync(id);
            UpdateFeedbackDto feedback = model!.Adapt<UpdateFeedbackDto>();
            return feedback;
        }

        public async Task AddAsync(AddFeedbackDto model)
        {
            FeedbackEntity feedback = new();
            feedback = model.Adapt<FeedbackEntity>();
            feedback.FilePath = FileProcessing.FileUpload(model.FilePath, null, "Feedback");

            await _repository.Insert(feedback);
        }

        public async Task UpdateAsync(UpdateFeedbackDto model)
        {
            var feedback = await _repository.GetByIdAsync(model.Id!);
            if (feedback == null)
            {

            }
            feedback!.IsShow = model.IsShow;
            feedback!.UpdateTime = DateTimeOffset.Now;
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
            var query =await _repository.GetByQuery();
            var model=await query.Where(w => w.IsShow == true).ToListAsync();
            List<FeedbackItemViewModel> items = model.Adapt<List<FeedbackItemViewModel>>();
            return items;
        }
    }
}
