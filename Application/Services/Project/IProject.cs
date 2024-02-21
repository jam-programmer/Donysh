using Application.DataTransferObjects.Picture;
using Application.DataTransferObjects.Project;
using Application.ViewModels.Main;
using Application.ViewModels.Project;

namespace Application.Services.Project
{
    public interface IProject
    {
        Task<ListGenerics<ProjectViewModel>> GetProjectsAsync(int page, int pageSize, string search = "", string? status = null);
        Task<ListGenerics<ProjectViewModel>> GetTrashProjectsAsync(int page, int pageSize, string search = "");
        Task AddProject(AddProjectDto model);
        Task UpdateProject(UpdateProjectDto model);
        Task<UpdateProjectDto> GetProjectById(string id);
        Task<bool> DeleteProjectById(string id);
        Task<bool> BackProjectById(string id);
        Task<bool> RemoveProjectById(string id);
        Task<List<PictureViewModel>> GetPicturesOfProject(string projectId);
        Task AddPicture(AddPictureDto model);
        Task<bool> RemoveImage(string id);
    }
}
