using Application.DataTransferObjects.Page;
using Application.ViewModels.Page;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;

namespace Application.Services.Page
{
    public class Page : IPage
    {
        private readonly IRepository<PageEntity> _repository;

        public Page(IRepository<PageEntity> repository)
        {
            _repository = repository;
        }
        public async Task<List<PageViewModel>> GetPagesAsync()
        {
            var model = await _repository.GetAll();
            List<PageViewModel> page = new();
            page = model.Adapt<List<PageViewModel>>();
            return page;
        }

        public async Task<UpdatePageDto> GetPageById(string id)
        {
            var model = await _repository.GetByIdAsync(id);
            UpdatePageDto pageDto = model!.Adapt<UpdatePageDto>();
            return pageDto;
        }

        public async Task AddPage(AddPageDto model)
        {
            PageEntity page = model.Adapt<PageEntity>();
            await _repository.Insert(page);

        }

        public async Task UpdatePage(UpdatePageDto model)
        {
            var page = await _repository.GetByIdAsync(model.Id);
            page = model.Adapt<PageEntity>();
            await _repository.Update(page);
        }

        public async Task<bool> DeletePage(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }

            var page = await _repository.GetByIdAsync(id);
            if (page != null)
            {

                try
                {
                    await _repository.Delete(page);
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
