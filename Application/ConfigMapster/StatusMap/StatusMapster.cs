using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DataTransferObjects.Status;
using Application.ViewModels.Status;
using Domain.Entities;
using Mapster;

namespace Application.ConfigMapster.StatusMap
{
    public static class StatusMapster
    {
        public static TypeAdapterConfig MapStatusToViewModel()
        {
            var config=new TypeAdapterConfig();
            config.NewConfig<StatusEntity,StatusViewModel>()
                .Map(e=>e.Status,v=>v.Status)
                .Map(e=>e.Id,v=>v.Id)
                .Compile();
            return config;
        }

        public static TypeAdapterConfig MapAddStatusToStatus()
        {
            var config=new TypeAdapterConfig();
            config.NewConfig<AddStatusDto,StatusEntity>()
                .Map(d=>d.Status,e=>e.Status)
                .Compile();
            return config;  
        }

        public static TypeAdapterConfig MapUpdateStatusToStatus()
        {
            var config=new TypeAdapterConfig();
            config.NewConfig<UpdateStatusDto,StatusEntity>()
                .Map(e=>e.Status,d=>d.Status)
                .Map(e=>e.Id,d=>d.Id)
                .Compile();
            return config;
        }
    }
}
