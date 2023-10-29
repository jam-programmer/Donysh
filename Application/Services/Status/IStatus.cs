using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DataTransferObjects.Status;
using Application.ViewModels.Main;
using Application.ViewModels.Status;

namespace Application.Services.Status
{
    public interface IStatus
    {   /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ListGenerics<StatusViewModel>> GetStatusesAsync(int page, int pageSize, string search = "");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        Task AddStatus(AddStatusDto model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UpdateStatusDto?> GetStatusById(string id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateStatusAsync(UpdateStatusDto? model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteStatusAsync(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ListGenerics<StatusViewModel>> GetTrashStatusesAsync(int page, int pageSize, string search = "");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> BackStatusAsync(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> RemoveStatusAsync(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<ItemViewModel>> GetStatusesItemAsync();
    }
}
