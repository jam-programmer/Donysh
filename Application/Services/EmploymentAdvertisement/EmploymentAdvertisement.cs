
using Application.ConfigMapster.TeamMap;
using Application.Core;
using Application.DataTransferObjects.EmploymentAdvertisement;
using Application.DataTransferObjects.Team;
using Application.ViewModels.EmploymentAdvertisement;
using Application.ViewModels.Main;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;

namespace Application.Services.EmploymentAdvertisement
{
    public class EmploymentAdvertisement: IEmploymentAdvertisement
    {
        private readonly IRepository<EmploymentAdvertisementEntity> _repository;
        private readonly IDapper<EmploymentAdvertisementEntity> _dapper;
        private readonly IRepository<ResumeEntity> _resume;

        public EmploymentAdvertisement(IRepository<EmploymentAdvertisementEntity> repository, IDapper<EmploymentAdvertisementEntity> dapper, IRepository<ResumeEntity> resume)
        {
            _repository = repository;
            _dapper = dapper;
            _resume = resume;
        }
        public async Task<ListGenerics<EmploymentAdvertisementViewModel>> GetEmploymentAdvertisementsAsync(int page, int pageSize, string search = "")
        {
            var employmentAdvertisements = await _dapper
                .GetListAsync(false, "[dbo].[SP_GetEmploymentAdvertisements]", page, pageSize, search);
            if (!employmentAdvertisements.Any())
            {

            }
            List<EmploymentAdvertisementViewModel> listTeam = employmentAdvertisements.Adapt<List<EmploymentAdvertisementViewModel>>();
            var count = await _repository.GetCount();
            count = count.PageCount(pageSize);
            ListGenerics<EmploymentAdvertisementViewModel> result = new();
            result.List = listTeam;
            result.Count = count;
            result.CurrentPage = page;
            result.SearchKeyword = search;
            if (count > 1 && listTeam.Count < 10 && !string.IsNullOrEmpty(search) && page == 1)
            {
                result.Pagination = false;
            }

            return result;
        }

        public async Task AddEmploymentAdvertisement(AddEmploymentAdvertisementDto? model)
        {
            if (model != null)
            {
                EmploymentAdvertisementEntity entity = model.Adapt<EmploymentAdvertisementEntity>();
                await _repository.Insert(entity);
            }
        }

        public async Task<UpdateEmploymentAdvertisementDto?> GetEmploymentAdvertisementById(string id)
        {
            var team = await _repository.GetByIdAsync(id);
            if (team != null)
            {
                UpdateEmploymentAdvertisementDto update = team.Adapt<UpdateEmploymentAdvertisementDto>();
                return update;
            }

            return null;
        }

        public async Task UpdateEmploymentAdvertisementAsync(UpdateEmploymentAdvertisementDto? model)
        {
            if (model == null || string.IsNullOrEmpty(model!.Id))
            {
                throw new Exception();
            }
            var entity = await _repository.GetByIdAsync(model.Id);
            if (entity != null)
            {
                entity = model.Adapt<EmploymentAdvertisementEntity>();

                entity.UpdateTime = DateTimeOffset.Now;
                await _repository.Update(entity);
            }
        }

        public async Task<bool> DeleteEmploymentAdvertisementAsync(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                try
                {

                    await _repository.Update(entity);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task<ListGenerics<EmploymentAdvertisementViewModel>> GetTrashEmploymentAdvertisementsAsync(int page, int pageSize, string search = "")
        {
            var employmentAdvertisements = await _dapper
                .GetListAsync(true, "[dbo].[SP_GetEmploymentAdvertisements]", page, pageSize, search);
            if (!employmentAdvertisements.Any())
            {

            }
            List<EmploymentAdvertisementViewModel> listTeam = employmentAdvertisements.Adapt<List<EmploymentAdvertisementViewModel>>();
            var count = await _repository.GetTrashCount();
            count = count.PageCount(pageSize);
            ListGenerics<EmploymentAdvertisementViewModel> result = new();
            result.List = listTeam;
            result.Count = count;
            result.CurrentPage = page;
            result.SearchKeyword = search;
            if (count > 1 && listTeam.Count < 10 && !string.IsNullOrEmpty(search) && page == 1)
            {
                result.Pagination = false;
            }

            return result;
        }

        public async Task<bool> BackEmploymentAdvertisementAsync(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var entity = await _repository.GetDeletedByIdAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = false;
                try
                {

                    await _repository.Update(entity);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task<bool> RemoveEmploymentAdvertisementAsync(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var entity = await _repository.GetDeletedByIdAsync(id);
            if (entity != null)
            {
                try
                {
                   
                    await _repository.Delete(entity);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task AddResumeAsync(AddResumeDto resume)
        {
            ResumeEntity entity = new();
            entity = resume.Adapt<ResumeEntity>();
            entity.CvFilePath = FileProcessing.PdfUpload(resume.CvFilePath, null,
                "Resume");

            try
            {
                await _resume.Insert(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
