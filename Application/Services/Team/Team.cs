using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ConfigMapster.ScopeWorkMap;
using Application.ConfigMapster.TeamMap;
using Application.Core;
using Application.DataTransferObjects.Team;
using Application.ViewModels.ScopeWork;
using Application.ViewModels.Main;
using Application.ViewModels.Team;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;

namespace Application.Services.Team
{
    public class Team : ITeam
    {
        private readonly IRepository<TeamEntity> _repository;
        private readonly IDapper<TeamEntity> _dapper;

        public Team(IRepository<TeamEntity> repository, IDapper<TeamEntity> dapper)
        {
            _repository = repository;
            _dapper = dapper;
        }

        public async Task<ListGenerics<TeamViewModel>> GetTeamsAsync(int page, int pageSize, string search = "")
        {
            var teams = await _dapper
                .GetListAsync(false, "[dbo].[SP_GetTeams]", page, pageSize, search);
            if (!teams.Any())
            {

            }
            List<TeamViewModel> listTeam = teams.Adapt<List<TeamViewModel>>(TeamMapster.MapTeamToViewModel());
            var count = await _repository.GetCount();
            count = count.PageCount(pageSize);
            ListGenerics<TeamViewModel> result = new();
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

        public async Task AddTeam(AddTeamDto? model)
        {
            if (model != null)
            {
                TeamEntity team = model.Adapt<TeamEntity>(TeamMapster.MapAddTeamToTeam());
                await _repository.Insert(team);
            }
        }

        public async Task<UpdateTeamDto?> GetTeamById(string id)
        {
            var team = await _repository.GetByIdAsync(id);
            if (team != null)
            {
                UpdateTeamDto updateTeam = team.Adapt<UpdateTeamDto>(TeamMapster.MapUpdateToTeam());
                return updateTeam;
            }

            return null;
        }

        public async Task UpdateTeamAsync(UpdateTeamDto? model)
        {
            if (model == null || string.IsNullOrEmpty(model!.Id))
            {
                throw new Exception();
            }
            var team = await _repository.GetByIdAsync(model.Id);
            if (team != null)
            {
                team = model.Adapt<TeamEntity>(TeamMapster.MapUpdateToTeam());
                team.AvatarPath = FileProcessing.FileUpload(model.Avatar, model.AvatarPath, "Team");
                team.UpdateTime=DateTimeOffset.Now;
                await _repository.Update(team);
            }
        }

        public async Task<bool> DeleteTeamAsync(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var team = await _repository.GetByIdAsync(id);
            if (team != null)
            {
                team.IsDeleted = true;
                try
                {

                    await _repository.Update(team);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task<ListGenerics<TeamViewModel>> GetTrashTeamsAsync(int page, int pageSize, string search = "")
        {
            var teams = await _dapper
                .GetListAsync(true, "[dbo].[SP_GetTeams]", page, pageSize, search);
            if (!teams.Any())
            {

            }
            List<TeamViewModel> listTeam = teams.Adapt<List<TeamViewModel>>(TeamMapster.MapTeamToViewModel());
            var count = await _repository.GetTrashCount();
            count = count.PageCount(pageSize);
            ListGenerics<TeamViewModel> result = new();
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

        public async Task<bool> BackTeamAsync(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var team = await _repository.GetDeletedByIdAsync(id);
            if (team != null)
            {
                team.IsDeleted = false;
                try
                {

                    await _repository.Update(team);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task<bool> RemoveTeamAsync(string id)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id))
            {
                result = false;
            }
            var team = await _repository.GetDeletedByIdAsync(id);
            if (team != null)
            {
                try
                {
                    FileProcessing.RemoveFile(team.AvatarPath ?? string.Empty,"Team");
                    await _repository.Delete(team);
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public async Task<MemberInformationViewModel> GetMemberInformationByIdAsync(string id)
        {
            var model = await _repository.GetByIdAsync(id);
            MemberInformationViewModel information = model!.Adapt<MemberInformationViewModel>();
            return information;
        }
    }
}
