using Application.ConfigMapster.CategoryMap;
using Application.Core;
using Application.DataTransferObjects.Category;
using Application.ViewModels.Category;
using Application.ViewModels.Main;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;

namespace Application.Services.Category
{
    public class Category : ICategory
    {
        private readonly IRepository<CategoryEntity> _categoryRepository;
        private readonly IDapper<CategoryEntity> _categoryDapper;
        public Category(IRepository<CategoryEntity> categoryRepository, IDapper<CategoryEntity> categoryDapper)
        {
            _categoryRepository = categoryRepository;
            _categoryDapper = categoryDapper;
        }

        public async Task<ListGenerics<CategoryViewModel>> GetCategoriesAsync(int page, int pageSize, string search = "")
        {
            var categories = await _categoryDapper
                .GetListAsync(false, "[dbo].[SP_GetCategories]", page, pageSize, search);
            if (!categories.Any())
            {

            }
            List<CategoryViewModel> listCategory = categories.Adapt<List<CategoryViewModel>>(CategoryMapster.MapCategoryToViewModel());
            var count = await _categoryRepository.GetCount();
            count = count.PageCount(pageSize);
            ListGenerics<CategoryViewModel> result = new();
            result.List = listCategory;
            result.Count = count;
            result.CurrentPage = page;
            result.SearchKeyword = search;
            if (count > 1 && listCategory.Count < 10 && !string.IsNullOrEmpty(search) && page == 1)
            {
                result.Pagination = false;
            }

            return result;
        }

        public async Task AddCategory(AddCategoryDto model)
        {
            CategoryEntity category = new();
            category = model.Adapt<CategoryEntity>(CategoryMapster.MapCategoryToAddCategoryDto());
            await _categoryRepository.Insert(category);
        }

        public async Task<UpdateCategoryDto?> GetCategoryById(string id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return null;
            }
            UpdateCategoryDto model = category.Adapt<UpdateCategoryDto>(CategoryMapster.MapCategoryToUpdateCategoryDto());
            return model;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto? model)
        {
            if (model == null)
            {
                //Exception
            }
            var category = await _categoryRepository.GetByIdAsync(model.Id);
            if (category == null)
            {
                //Exception
            }

            category = model.Adapt<CategoryEntity>(CategoryMapster.MapCategoryToUpdateCategoryDto());
            category.UpdateTime = DateTimeOffset.Now;
            await _categoryRepository.Update(category);
        }

        public async Task<bool> DeleteCategoryAsync(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category != null)
            {
                category.IsDeleted = true;
                try
                {

                    await _categoryRepository.Update(category);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task<ListGenerics<CategoryViewModel>> GetTrashCategoriesAsync(int page, int pageSize, string search = "")
        {
            var categories = await _categoryDapper
                .GetListAsync(true, "[dbo].[SP_GetCategories]", page, pageSize, search);
            if (!categories.Any())
            {

            }
            List<CategoryViewModel> listCategory = categories.Adapt<List<CategoryViewModel>>(CategoryMapster.MapCategoryToViewModel());
            var count = await _categoryRepository.GetTrashCount();
            count = count.PageCount(pageSize);
            ListGenerics<CategoryViewModel> result = new();
            result.List = listCategory;
            result.Count = count;
            result.CurrentPage = page;
            result.SearchKeyword = search;
            if (count > 1 && listCategory.Count < 10 && !string.IsNullOrEmpty(search) && page == 1)
            {
                result.Pagination = false;
            }

            return result;
        }

        public async Task<bool> BackCategoryAsync(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var category = await _categoryRepository.GetDeletedByIdAsync(id);
            if (category != null)
            {
                category.IsDeleted = false;
                try
                {

                    await _categoryRepository.Update(category);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task<bool> RemoveCategoryAsync(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var category = await _categoryRepository.GetDeletedByIdAsync(id);
            if (category != null)
            {

                try
                {

                    await _categoryRepository.Delete(category);
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
