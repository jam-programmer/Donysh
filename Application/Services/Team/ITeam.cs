using Application.DataTransferObjects.Team;
using Application.ViewModels.Team;
using Application.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Team
{
    public interface ITeam
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ListGenerics<TeamViewModel>> GetTeamsAsync(int page, int pageSize, string search = "");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        Task AddTeam(AddTeamDto? model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UpdateTeamDto?> GetTeamById(string id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateTeamAsync(UpdateTeamDto? model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteTeamAsync(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ListGenerics<TeamViewModel>> GetTrashTeamsAsync(int page, int pageSize, string search = "");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> BackTeamAsync(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> RemoveTeamAsync(string id);
    }
}
