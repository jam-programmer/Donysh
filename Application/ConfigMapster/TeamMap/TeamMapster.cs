using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Core;
using Application.DataTransferObjects.Team;
using Application.ViewModels.Team;
using Domain.Entities;
using Mapster;

namespace Application.ConfigMapster.TeamMap
{
    public static class TeamMapster
    {
        public static TypeAdapterConfig MapTeamToViewModel()
        {
            var config= new TypeAdapterConfig();
            config.NewConfig<TeamEntity,TeamViewModel>()
                .Map(v=>v.FullName,e=>e.FullName)
                .Map(v=>v.JobTitle,e=>e.JobTitle)
                .Map(v=>v.Id,e=>e.Id)
                .Map(v=>v.AvatarPath,e=>e.AvatarPath).Compile();
            return config;
        }

        public static TypeAdapterConfig MapAddTeamToTeam()
        {
            var config=new TypeAdapterConfig();
            config.NewConfig<AddTeamDto,TeamEntity>()
                .Map(e=>e.FullName,d=>d.FullName)
                .Map(e=>e.JobTitle,d=>d.JobTitle)
                .Map(e=>e.AvatarPath,d=>FileProcessing.FileUpload(d.AvatarFile,null,"Team"))
                .Compile();
            return config;
        }

        public static TypeAdapterConfig MapUpdateToTeam()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<UpdateTeamDto, TeamEntity>()
                .Map(e => e.FullName, d => d.FullName)
                .Map(e => e.JobTitle, d => d.JobTitle)
                .Map(e => e.Id, d => d.Id)
                .Compile();
            return config;
        }
    }
    
}
