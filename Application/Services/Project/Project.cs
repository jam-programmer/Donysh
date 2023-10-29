using Application.ConfigMapster.ProjectMap;
using Application.Core;
using Application.DataTransferObjects.Project;
using Application.ViewModels.Main;
using Application.ViewModels.Project;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;

namespace Application.Services.Project
{
    public class Project : IProject
    {
        private readonly IDapper<ProjectEntity> _dapper;
        private readonly IRepository<ProjectEntity> _repository;

        public Project(IDapper<ProjectEntity> dapper, IRepository<ProjectEntity> repository)
        {
            _dapper = dapper;
            _repository = repository;
        }
        public async Task AddProject(AddProjectDto model)
        {
            ProjectEntity project = model.Adapt<ProjectEntity>(ProjectMapster.MapProjectToAddProjectDto());
            await _repository.Insert(project);
            if (model.Services != null)
            {
                await _dapper.InsertWithOutColumn("Dy.ProjectEntityServiceEntity", project.Id, model.Services!);
            }

        }

        public async Task<bool> BackProjectById(string id)
        {
            var model = await _repository.GetDeletedByIdAsync(id);
            try
            {
                model!.IsDeleted = false;
                await _repository.Update(model);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProjectById(string id)
        {
            var model = await _repository.GetByIdAsync(id);
            try
            {
                model!.IsDeleted = true;
                await _repository.Update(model);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<UpdateProjectDto> GetProjectById(string id)
        {
            var model = await _repository.GetByIdAsync(id);
            UpdateProjectDto project = model!.Adapt<UpdateProjectDto>(ProjectMapster.MapProjectToUpdateProjectDto());
            project.Services = await _dapper.GetRelations("[Dy].[ProjectEntityServiceEntity]", "ServiceId", "ProjectsId", id);
            return project;
        }












        public async Task<ListGenerics<ProjectViewModel>> GetProjectsAsync(int page, int pageSize, string search = "")
        {
            var projects = await _dapper
                .GetListAsync(false, "[dbo].[SP_GetProjects]", page, pageSize, search);
            if (!projects.Any())
            {

            }
            List<ProjectViewModel> listProject = projects.Adapt<List<ProjectViewModel>>(ProjectMapster.MapProjectToViewModel());
            var count = await _repository.GetCount();
            count = count.PageCount(pageSize);
            ListGenerics<ProjectViewModel> result = new();
            result.List = listProject;
            result.Count = count;
            result.CurrentPage = page;
            result.SearchKeyword = search;
            if (count > 1 && listProject.Count < 10 && !string.IsNullOrEmpty(search) && page == 1)
            {
                result.Pagination = false;
            }

            return result;
        }

        public async Task<ListGenerics<ProjectViewModel>> GetTrashProjectsAsync(int page, int pageSize, string search = "")
        {
            var projects = await _dapper
                .GetListAsync(true, "[dbo].[SP_GetProjects]", page, pageSize, search);
            if (!projects.Any())
            {

            }
            List<ProjectViewModel> listProject = projects.Adapt<List<ProjectViewModel>>(ProjectMapster.MapProjectToViewModel());
            var count = await _repository.GetTrashCount();
            count = count.PageCount(pageSize);
            ListGenerics<ProjectViewModel> result = new();
            result.List = listProject;
            result.Count = count;
            result.CurrentPage = page;
            result.SearchKeyword = search;
            if (count > 1 && listProject.Count < 10 && !string.IsNullOrEmpty(search) && page == 1)
            {
                result.Pagination = false;
            }

            return result;
        }

        public async Task<bool> RemoveProjectById(string id)
        {
            var model = await _repository.GetDeletedByIdAsync(id);
            try
            {
                await _dapper.DeleteAsync("[Dy].[ProjectEntityServiceEntity]", "ProjectsId", model!.Id!);
                FileProcessing.RemoveFile(model!.ProjectImage!, "Project");
                await _repository.Delete(model!);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }



            
        }

        public async Task UpdateProject(UpdateProjectDto model)
        {
            var project = await _repository.GetByIdAsync(model.Id!);
            if (project == null)
            {

            }
            project = model.Adapt<ProjectEntity>(ProjectMapster.MapProjectToUpdateProjectDto());
            project.ProjectImage = FileProcessing.FileUpload(model.ImageProject, model.ProjectImage, "Project");

            if (model.Services != null)
            {
                await _dapper.DeleteAsync("[Dy].[ProjectEntityServiceEntity]", "ProjectsId", model.Id!);
                await _dapper.InsertWithOutColumn("[Dy].[ProjectEntityServiceEntity]", project.Id, model.Services!);
            }

            await _repository.Update(project);
        }
    }
}
