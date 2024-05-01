using Application.DataTransferObjects.Team;
using Application.ViewModels.Main;
using Application.ViewModels.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.EmploymentAdvertisement;
using Application.DataTransferObjects.EmploymentAdvertisement;

namespace Application.Services.EmploymentAdvertisement
{
    public interface IEmploymentAdvertisement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ListGenerics<EmploymentAdvertisementViewModel>> GetEmploymentAdvertisementsAsync(int page, int pageSize, string search = "");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        Task AddEmploymentAdvertisement(AddEmploymentAdvertisementDto? model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UpdateEmploymentAdvertisementDto?> GetEmploymentAdvertisementById(string id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateEmploymentAdvertisementAsync(UpdateEmploymentAdvertisementDto? model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteEmploymentAdvertisementAsync(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ListGenerics<EmploymentAdvertisementViewModel>> GetTrashEmploymentAdvertisementsAsync(int page, int pageSize, string search = "");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> BackEmploymentAdvertisementAsync(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> RemoveEmploymentAdvertisementAsync(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        Task AddResumeAsync(AddResumeDto resume);
    }
}
