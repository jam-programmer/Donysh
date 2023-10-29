using Application.DataTransferObjects.Status;
using Application.ViewModels.Main;
using Application.ViewModels.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ConfigMapster.StatusMap;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;
using Application.ConfigMapster.ServiceMap;
using Application.Core;
using Application.ViewModels.Service;

namespace Application.Services.Status
{
    public class Status : IStatus
    {
        private readonly IRepository<StatusEntity> _repository;
        private readonly IDapper<StatusEntity> _dapper;

        public Status(IRepository<StatusEntity> repository, IDapper<StatusEntity> dapper)
        {
            _repository = repository;
            _dapper = dapper;
        }
        public async Task AddStatus(AddStatusDto model)
        {
            if (model == null) throw new ArgumentNullException();
            StatusEntity status = model.Adapt<StatusEntity>(StatusMapster.MapAddStatusToStatus());
            await _repository.Insert(status);
        }

        public async Task<bool> BackStatusAsync(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var status = await _repository.GetDeletedByIdAsync(id);
            if (status != null)
            {
                status.IsDeleted = false;
                try
                {

                    await _repository.Update(status);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task<bool> DeleteStatusAsync(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var status = await _repository.GetByIdAsync(id);
            if (status != null)
            {
                status.IsDeleted = true;
                try
                {

                    await _repository.Update(status);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task<UpdateStatusDto?> GetStatusById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {

            }
            var status=await _repository.GetByIdAsync(id);
            if (status == null)
            {
              
            }
            UpdateStatusDto model = status!.Adapt<UpdateStatusDto>(StatusMapster.MapUpdateStatusToStatus());
            return model;
        }

        public async Task<ListGenerics<StatusViewModel>> GetStatusesAsync(int page, int pageSize, string search = "")
        {
            var statuses = await _dapper
                .GetListAsync(false, "[dbo].[SP_GetStatuses]", page, pageSize, search);
            if (!statuses.Any())
            {

            }
            List<StatusViewModel> listStatus = statuses.Adapt<List<StatusViewModel>>(StatusMapster.MapStatusToViewModel());
            var count = await _repository.GetCount();
            count = count.PageCount(pageSize);
            ListGenerics<StatusViewModel> result = new();
            result.List = listStatus;
            result.Count = count;
            result.CurrentPage = page;
            result.SearchKeyword = search;
            if (count > 1 && listStatus.Count < 10 && !string.IsNullOrEmpty(search) && page == 1)
            {
                result.Pagination = false;
            }

            return result;
        }

        public async Task<List<ItemViewModel>> GetStatusesItemAsync()
        {
            var model = await _repository.GetAll();
            List<ItemViewModel> items = new List<ItemViewModel>();
            foreach (var item in model)
            {
                items.Add(new ItemViewModel()
                {
                    Id = item.Id,
                    Title = item.Status
                });
            }
            return items;
        }

        public async Task<ListGenerics<StatusViewModel>> GetTrashStatusesAsync(int page, int pageSize, string search = "")
        {
            var statuses = await _dapper
                .GetListAsync(true, "[dbo].[SP_GetStatuses]", page, pageSize, search);
            if (!statuses.Any())
            {

            }
            List<StatusViewModel> listStatus = statuses.Adapt<List<StatusViewModel>>(StatusMapster.MapStatusToViewModel());
            var count = await _repository.GetTrashCount();
            count = count.PageCount(pageSize);
            ListGenerics<StatusViewModel> result = new();
            result.List = listStatus;
            result.Count = count;
            result.CurrentPage = page;
            result.SearchKeyword = search;
            if (count > 1 && listStatus.Count < 10 && !string.IsNullOrEmpty(search) && page == 1)
            {
                result.Pagination = false;
            }

            return result;
        }

        public async Task<bool> RemoveStatusAsync(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var status = await _repository.GetDeletedByIdAsync(id);
            if (status != null)
            {
               
                try
                {

                    await _repository.Delete(status);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task UpdateStatusAsync(UpdateStatusDto? model)
        {
            if (model != null)
            {
                
            }
            var status = await _repository.GetByIdAsync(model!.Id ?? string.Empty);
            if (status==null)
            {
                
            }

            status = model.Adapt<StatusEntity>(StatusMapster.MapUpdateStatusToStatus());
            status.UpdateTime=DateTimeOffset.Now;
            await _repository.Update(status);

        }
    }
}
