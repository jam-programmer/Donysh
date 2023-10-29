
using Application.DataTransferObjects.ScopeWork;
using Application.ViewModels.ScopeWork;
using Application.ViewModels.Main;

namespace Application.Services.ScopeWork
{
    public interface IScopeWork
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ListGenerics<ScopeWorkViewModel>> GetScopesAsync(int page, int pageSize, string search = "");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        Task AddScopeWork(AddScopeWorkDto model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UpdateScopeWorkDto?> GetScopeWorkById(string id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateScopeWorkAsync(UpdateScopeWorkDto? model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteScopeWorkAsync(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ListGenerics<ScopeWorkViewModel>> GetTrashScopesAsync(int page, int pageSize, string search = "");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> BackScopeWorkAsync(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> RemoveScopeWorkAsync(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<ItemViewModel>> GetScopsItemAsync();
    }
}
