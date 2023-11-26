using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DataTransferObjects.Page;
using Application.ViewModels.Page;

namespace Application.Services.Page
{
    public interface IPage
    {
        Task<List<PageViewModel>> GetPagesAsync();
        Task<UpdatePageDto> GetPageById(string id);
        Task AddPage(AddPageDto model);
        Task UpdatePage(UpdatePageDto model);
        Task<bool> DeletePage(string id);
    }
}
