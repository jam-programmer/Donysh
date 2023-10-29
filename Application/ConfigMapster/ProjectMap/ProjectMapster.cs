using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Core;
using Application.DataTransferObjects.Project;
using Application.ViewModels.Project;
using Domain.Entities;
using Mapster;

namespace Application.ConfigMapster.ProjectMap
{
    public static class ProjectMapster
    {
        public static TypeAdapterConfig MapProjectToViewModel()
        {
            var config= new TypeAdapterConfig();
            config.NewConfig<ProjectEntity,ProjectViewModel>()
                .Map(v=>v.Id,e=>e.Id)
                .Map(v=>v.ProjectName,e=>e.ProjectName)
                .Map(v=>v.OwnerOrDeveloper,e=>e.OwnerOrDeveloper)
                .Map(v=>v.ProjectImage,e=>e.ProjectImage)
                .Compile();
            return config;
        }

        public static TypeAdapterConfig MapProjectToAddProjectDto()
        {
            var config=new TypeAdapterConfig();
            config.NewConfig<AddProjectDto,ProjectEntity>()
                .Map(e => e.ScopeForeignKey, d => d.ScopeForeignKey)
                .Map(e=>e.OwnerOrDeveloper,d=>d.OwnerOrDeveloper)
                .Map(e=>e.ProjectName,d=>d.ProjectName)
                .Map(e=>e.StatusForeignKey,d=>d.StatusForeignKey)
                .Map(e=>e.Architect,d=>d.Architect)
                .Map(e=>e.Builder,d=>d.Builder)
                .Map(e=>e.CompletionDate,d=>d.CompletionDate)
                .Map(e=>e.ContractAmount,d=>d.ContractAmount)
                .Map(e=>e.Description,d=>d.Description)
                .Map(e=>e.Location,d=>d.Location)
                .Map(e=>e.ReferenceContactAddress,d=>d.ReferenceContactAddress)
                .Map(e=>e.ReferenceContactEmail,d=>d.ReferenceContactEmail)
                .Map(e=>e.ReferenceContactName,d=>d.ReferenceContactName)
                .Map(e=>e.ReferenceContactPhone,d=>d.ReferenceContactPhone)
                .Map(e=>e.StartDate,d=>d.StartDate)
                .Map(e=>e.ProjectImage,d=>FileProcessing.FileUpload(d.ProjectImage,null,"Project"))
                .Compile();
            return config;
        }
        public static TypeAdapterConfig MapProjectToUpdateProjectDto()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<UpdateProjectDto, ProjectEntity>()
                .Map(e => e.Id, d => d.Id)
                .Map(e => e.ProjectImage, d => d.ProjectImage)
                .Map(e => e.ProjectName, d => d.ProjectName)
                .Map(e => e.StatusForeignKey, d => d.StatusForeignKey)
                .Map(e => e.ScopeForeignKey, d => d.ScopeForeignKey)
                .Map(e => e.Architect, d => d.Architect)
                .Map(e => e.Builder, d => d.Builder)
                .Map(e => e.CompletionDate, d => d.CompletionDate)
                .Map(e => e.ContractAmount, d => d.ContractAmount)
                .Map(e => e.Description, d => d.Description)
                .Map(e => e.Location, d => d.Location)
                .Map(e => e.ReferenceContactAddress, d => d.ReferenceContactAddress)
                .Map(e => e.ReferenceContactEmail, d => d.ReferenceContactEmail)
                .Map(e => e.ReferenceContactName, d => d.ReferenceContactName)
                .Map(e => e.ReferenceContactPhone, d => d.ReferenceContactPhone)
                .Map(e => e.StartDate, d => d.StartDate)
                .Compile(); 
            return config;
        }

     
    }
}
