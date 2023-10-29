using Application.DataTransferObjects.Project;
using Application.ViewModels.Project;
using Application.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Project
{
    public interface IProject
    {
        Task<ListGenerics<ProjectViewModel>> GetProjectsAsync(int page, int pageSize, string search = "");
        Task<ListGenerics<ProjectViewModel>> GetTrashProjectsAsync(int page, int pageSize, string search = "");
        Task AddProject(AddProjectDto model);
        Task UpdateProject(UpdateProjectDto model);
        Task<UpdateProjectDto> GetProjectById(string id);
        Task<bool> DeleteProjectById(string id);
        Task<bool> BackProjectById(string id);
        Task<bool> RemoveProjectById(string id);
    }
}
