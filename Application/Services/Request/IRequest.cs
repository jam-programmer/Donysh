using Application.ViewModels.Contact;
using Application.ViewModels.Main;
using Application.ViewModels.Request;

namespace Application.Services.Request
{
    public interface IRequest
    {
        Task<ListGenerics<RequestViewModel>> GetRequestAsync(int page, int pageSize, string search = "");
        Task<RequestDetail> GetById(string id);
        Task<bool> RemoveById(string id);
    }
}
