using Application.ConfigMapster.ScopeWorkMap;
using Application.Core;
using Application.DataTransferObjects.ScopeWork;
using Application.ViewModels.ScopeWork;
using Application.ViewModels.Main;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;

namespace Application.Services.ScopeWork
{
    public class ScopeWork : IScopeWork
    {
        private readonly IRepository<ScopeWorkEntity> _ScopeWorkRepository;
        private readonly IDapper<ScopeWorkEntity> _ScopeWorkDapper;
        public ScopeWork(IRepository<ScopeWorkEntity> ScopeWorkRepository, IDapper<ScopeWorkEntity> ScopeWorkDapper)
        {
            _ScopeWorkRepository = ScopeWorkRepository;
            _ScopeWorkDapper = ScopeWorkDapper;
        }

        public async Task<ListGenerics<ScopeWorkViewModel>> GetScopesAsync(int page, int pageSize, string search = "")
        {
            var Scopes = await _ScopeWorkDapper
                .GetListAsync(false, "[dbo].[SP_GetScopes]", page, pageSize, search);
            if (!Scopes.Any())
            {

            }
            List<ScopeWorkViewModel> listScopeWork = Scopes.Adapt<List<ScopeWorkViewModel>>(ScopeWorkMapster.MapScopeWorkToViewModel());
            var count = await _ScopeWorkRepository.GetCount();
            count = count.PageCount(pageSize);
            ListGenerics<ScopeWorkViewModel> result = new();
            result.List = listScopeWork;
            result.Count = count;
            result.CurrentPage = page;
            result.SearchKeyword = search;
            if (count > 1 && listScopeWork.Count < 10 && !string.IsNullOrEmpty(search) && page == 1)
            {
                result.Pagination = false;
            }

            return result;
        }

        public async Task AddScopeWork(AddScopeWorkDto model)
        {
            ScopeWorkEntity ScopeWork = new();
            ScopeWork = model.Adapt<ScopeWorkEntity>(ScopeWorkMapster.MapScopeWorkToAddScopeWorkDto());
            await _ScopeWorkRepository.Insert(ScopeWork);
        }

        public async Task<UpdateScopeWorkDto?> GetScopeWorkById(string id)
        {
            var ScopeWork = await _ScopeWorkRepository.GetByIdAsync(id);
            if (ScopeWork == null)
            {
                return null;
            }
            UpdateScopeWorkDto model = ScopeWork.Adapt<UpdateScopeWorkDto>(ScopeWorkMapster.MapScopeWorkToUpdateScopeWorkDto());
            return model;
        }

        public async Task UpdateScopeWorkAsync(UpdateScopeWorkDto? model)
        {
            if (model == null)
            {
                //Exception
            }
            var ScopeWork = await _ScopeWorkRepository.GetByIdAsync(model.Id);
            if (ScopeWork == null)
            {
                //Exception
            }

            ScopeWork = model.Adapt<ScopeWorkEntity>(ScopeWorkMapster.MapScopeWorkToUpdateScopeWorkDto());
            ScopeWork.UpdateTime = DateTimeOffset.Now;
            await _ScopeWorkRepository.Update(ScopeWork);
        }

        public async Task<bool> DeleteScopeWorkAsync(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var ScopeWork = await _ScopeWorkRepository.GetByIdAsync(id);
            if (ScopeWork != null)
            {
                ScopeWork.IsDeleted = true;
                try
                {

                    await _ScopeWorkRepository.Update(ScopeWork);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task<ListGenerics<ScopeWorkViewModel>> GetTrashScopesAsync(int page, int pageSize, string search = "")
        {
            var Scopes = await _ScopeWorkDapper
                .GetListAsync(true, "[dbo].[SP_GetScopes]", page, pageSize, search);
            if (!Scopes.Any())
            {

            }
            List<ScopeWorkViewModel> listScopeWork = Scopes.Adapt<List<ScopeWorkViewModel>>(ScopeWorkMapster.MapScopeWorkToViewModel());
            var count = await _ScopeWorkRepository.GetTrashCount();
            count = count.PageCount(pageSize);
            ListGenerics<ScopeWorkViewModel> result = new();
            result.List = listScopeWork;
            result.Count = count;
            result.CurrentPage = page;
            result.SearchKeyword = search;
            if (count > 1 && listScopeWork.Count < 10 && !string.IsNullOrEmpty(search) && page == 1)
            {
                result.Pagination = false;
            }

            return result;
        }

        public async Task<bool> BackScopeWorkAsync(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var ScopeWork = await _ScopeWorkRepository.GetDeletedByIdAsync(id);
            if (ScopeWork != null)
            {
                ScopeWork.IsDeleted = false;
                try
                {

                    await _ScopeWorkRepository.Update(ScopeWork);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task<bool> RemoveScopeWorkAsync(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var ScopeWork = await _ScopeWorkRepository.GetDeletedByIdAsync(id);
            if (ScopeWork != null)
            {

                try
                {

                    await _ScopeWorkRepository.Delete(ScopeWork);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task<List<ItemViewModel>> GetScopsItemAsync()
        {
            var model = await _ScopeWorkRepository.GetAll();
            List<ItemViewModel> items = new List<ItemViewModel>();
            foreach (var item in model)
            {
                items.Add(new ItemViewModel()
                {
                    Id = item.Id,
                    Title = item.Title
                });
            }
            return items;
        }
    }


}
