using Application.ViewModels.Company;
using Application.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.Contact;

namespace Application.Services.Contact
{
    public interface IContact
    {
        Task<ListGenerics<ContactViewModel>> GetContactAsync(int page, int pageSize, string search = "");
        Task<ContactDetail> GetById(string id);
        Task<bool> RemoveById(string id);
      
    }
}
