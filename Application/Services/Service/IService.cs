using Application.DataTransferObjects.Service;
using Application.ViewModels.Main;
using Application.ViewModels.Service;

namespace Application.Services.Service
{
    public interface IService
    {  /// <summary>
       /// 
       /// </summary>
       /// <param name="page"></param>
       /// <param name="pageSize"></param>
       /// <param name="search"></param>
       /// <returns></returns>
        Task<ListGenerics<ServiceViewModel>> GetServicesAsync(int page, int pageSize, string search = "");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        Task AddService(AddServiceDto model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UpdateServiceDto?> GetServiceById(string id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateServiceAsync(UpdateServiceDto? model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteServiceAsync(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ListGenerics<ServiceViewModel>> GetTrashServicesAsync(int page, int pageSize, string search = "");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> BackServiceAsync(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> RemoveServiceAsync(string id);
    }
}
