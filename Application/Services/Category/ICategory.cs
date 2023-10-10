using Application.DataTransferObjects.Category;
using Application.ViewModels.Category;
using Application.ViewModels.Main;

namespace Application.Services.Category
{
    public interface ICategory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ListGenerics<CategoryViewModel>> GetCategoriesAsync(int page, int pageSize, string search = "");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        Task AddCategory(AddCategoryDto model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UpdateCategoryDto?> GetCategoryById(string id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateCategoryAsync(UpdateCategoryDto? model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteCategoryAsync(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ListGenerics<CategoryViewModel>> GetTrashCategoriesAsync(int page, int pageSize, string search = "");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> BackCategoryAsync(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> RemoveCategoryAsync(string id);
    }
}
