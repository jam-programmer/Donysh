using Application.ConfigMapster.ServiceMap;
using Application.Core;
using Application.DataTransferObjects.Service;
using Application.Services.Company;
using Application.ViewModels.Main;
using Application.ViewModels.Service;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;

namespace Application.Services.Service
{
    public class Service : IService
    {
        private readonly IRepository<ServiceEntity> _repository;
        private readonly IDapper<ServiceEntity> _dapper;

        public Service(IRepository<ServiceEntity> repository, IDapper<ServiceEntity> dapper)
        {
            _repository = repository;
            _dapper = dapper;
        }
        public async Task<ListGenerics<ServiceViewModel>> GetServicesAsync(int page, int pageSize, string search = "")
        {
            var services = await _dapper
                .GetListAsync(false, "[dbo].[SP_GetService]", page, pageSize, search);
            if (!services.Any())
            {

            }
            List<ServiceViewModel> listService = services.Adapt<List<ServiceViewModel>>(ServiceMapster.MapServiceToViewModel());
            var count = await _repository.GetCount();
            count = count.PageCount(pageSize);
            ListGenerics<ServiceViewModel> result = new();
            result.List = listService;
            result.Count = count;
            result.CurrentPage = page;
            result.SearchKeyword = search;
            if (count > 1 && listService.Count < 10 && !string.IsNullOrEmpty(search) && page == 1)
            {
                result.Pagination = false;
            }

            return result;

        }

        public async Task AddService(AddServiceDto model)
        {
            ServiceEntity service = new();
            service = model.Adapt<ServiceEntity>(ServiceMapster.MapServiceToAddServiceDto());
            await _repository.Insert(service);
        }

        public async Task<UpdateServiceDto?> GetServiceById(string id)
        {
            var service = await _repository.GetByIdAsync(id);
            if (service == null)
            {
                return null;
            }
            UpdateServiceDto model = service.Adapt<UpdateServiceDto>(ServiceMapster.MapServiceToUpdateServiceDto());
            return model;
        }

        public async Task UpdateServiceAsync(UpdateServiceDto? model)
        {
            if (model == null)
            {
                //Exception
            }
            var service = await _repository.GetByIdAsync(model.Id);
            if (service == null)
            {
                //Exception
            }

            service = model.Adapt<ServiceEntity>(ServiceMapster.MapServiceToUpdateServiceDto());
            service.Image = FileProcessing.FileUpload(model.ImageFile, model.Image, "Service");
            service.UpdateTime = DateTimeOffset.Now;
            await _repository.Update(service);
        }

        public async Task<bool> DeleteServiceAsync(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var service = await _repository.GetByIdAsync(id);
            if (service != null)
            {
                service.IsDeleted = true;
                try
                {

                    await _repository.Update(service);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task<ListGenerics<ServiceViewModel>> GetTrashServicesAsync(int page, int pageSize, string search = "")
        {
            var services = await _dapper
                .GetListAsync(true, "[dbo].[SP_GetService]", page, pageSize, search);
            if (!services.Any())
            {

            }
            List<ServiceViewModel> listService = services.Adapt<List<ServiceViewModel>>(ServiceMapster.MapServiceToViewModel());
            var count = await _repository.GetTrashCount();
            count = count.PageCount(pageSize);
            ListGenerics<ServiceViewModel> result = new();
            result.List = listService;
            result.Count = count;
            result.CurrentPage = page;
            result.SearchKeyword = search;
            if (count > 1 && listService.Count < 10 && !string.IsNullOrEmpty(search) && page == 1)
            {
                result.Pagination = false;
            }

            return result;
        }

        public async Task<bool> BackServiceAsync(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var service = await _repository.GetDeletedByIdAsync(id);
            if (service != null)
            {
                service.IsDeleted = false;
                try
                {

                    await _repository.Update(service);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task<bool> RemoveServiceAsync(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var service = await _repository.GetDeletedByIdAsync(id);
            if (service != null)
            {

                try
                {

                    await _repository.Delete(service);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task<List<ItemViewModel>> GetServiceItemAsync()
        {
            var model =await _repository.GetAll();
            List<ItemViewModel> items = new List<ItemViewModel>();
            foreach (var item in model)
            {
                items.Add(new ItemViewModel()
                {
                    Id = item.Id,Title = item.Title
                });
            }
            return items;
        }
    }
}
