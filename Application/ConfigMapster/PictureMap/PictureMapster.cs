using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Core;
using Application.DataTransferObjects.Company;
using Application.DataTransferObjects.Picture;
using Domain.Entities;
using Mapster;

namespace Application.ConfigMapster.PictureMap
{
    public static class PictureMapster
    {
        public static TypeAdapterConfig AddPictureToPictureEntity()
        {
            var config=new TypeAdapterConfig();
            config.NewConfig<AddPictureDto, PictureEntity>()
                .Map(e => e.Path,
                    d => FileProcessing
                        .FileUpload(d.File, null, "Picture"))
                .Map(e=>e.ProjectForeignKey,d=>d.ProjectForeignKey)
                .Map(e=>e.Alt,d=>d.Alt)
                .Map(e=>e.Title,d=>d.Title)
                .Compile();
            return config;



        }
    }
}
