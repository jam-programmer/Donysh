using Application.ViewModels.Contact;
using Application.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Application.ConfigMapster.CompanyMap;
using Application.ViewModels.Company;
using Mapster;
using Application.Core;
using Application.Services.Sender;

namespace Application.Services.Contact
{
    public class Contact : IContact
    {
        private readonly IDapper<ContactEntity> _contact;
        private readonly IRepository<ContactEntity> _repository;
        private readonly ISender _sender;

        public Contact(IDapper<ContactEntity> contact, IRepository<ContactEntity> repository, ISender sender)
        {
            _contact = contact;
            _repository = repository;
            _sender = sender;
        }
        public async Task<ContactDetail> 
            GetById(string id)
        {
            var model = await _repository.GetByIdAsync(id);
            model.Show = true;
            await _repository.Update(model);
            ContactDetail detail = new();
            detail = model.Adapt<ContactDetail>();
          
            return detail;
        }

        public async Task<ListGenerics<ContactViewModel>> GetContactAsync(int page, int pageSize, string search = "")
        {
            var message = await _contact
                .GetListAsync(false, "[dbo].[SP_GetContact]", page, pageSize, search);
            if (!message.Any())
            {

            }
            List<ContactViewModel> listMessage = message.Adapt<List<ContactViewModel>>();
            var count = await _repository.GetCount();
            count = count.PageCount(pageSize);
            ListGenerics<ContactViewModel> result = new();
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
