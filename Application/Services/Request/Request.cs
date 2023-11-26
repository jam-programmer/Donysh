using Application.ViewModels.Main;
using Application.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;
using Application.Core;
using Application.ViewModels.Contact;

namespace Application.Services.Request
{
    public class Request : IRequest
    {
        private readonly IRepository<ServiceEntity> _service;
        private readonly IRepository<RequestEntity> _repository;
        private readonly IDapper<RequestEntity> _dapper;

        public Request(IRepository<ServiceEntity> service, IRepository<RequestEntity> repository, IDapper<RequestEntity> dapper)
        {
            _service = service;
            _repository = repository;
            _dapper = dapper;
        }

        public async Task<RequestDetail> GetById(string id)
        {
            var result = await _repository.GetByIdAsync(id);
            RequestDetail request = new();
            request = result!.Adapt<RequestDetail>();
            var relations = await _dapper.
                GetRelations("Dy.RequestEntityServiceEntity", "ServiceId", "RequestsId", id);
            List<ItemViewModel> items = new List<ItemViewModel>();
            foreach (var rel in relations)
            {
                var item = await _service.GetByIdAsync(rel);
                if (item != null)
                {
                    items.Add(new ItemViewModel()
                    {
                        Id = item.Id,
                        Title = item.Title
                    });
                }

            }

            request.Services = items;
            return request;
        }

        public async Task<ListGenerics<RequestViewModel>> GetRequestAsync(int page, int pageSize, string search = "")
        {
            var message = await _dapper
                .GetListAsync(false, "[dbo].[SP_GetRequest]", page, pageSize, search);
            if (!message.Any())
            {

            }
            List<RequestViewModel> listMessage = message.Adapt<List<RequestViewModel>>();
            var count = await _repository.GetCount();
            count = count.PageCount(pageSize);
            ListGenerics<RequestViewModel> result = new();
            result.List = listMessage;
            result.Count = count;
            result.CurrentPage = page;
            result.SearchKeyword = search;
            if (count > 1 && listMessage.Count < 10 && !string.IsNullOrEmpty(search) && page == 1)
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
            var contact = await _repository.GetByIdAsync(id);
            if (contact != null)
            {

                try
                {

                    await _repository.Delete(contact);
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
