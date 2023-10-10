using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DataTransferObjects.Category;
using Application.ViewModels.Category;
using Domain.Entities;
using Mapster;

namespace Application.ConfigMapster.CategoryMap
{
    public static class CategoryMapster
    {
        public static TypeAdapterConfig MapCategoryToViewModel()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<CategoryEntity, CategoryViewModel>()
                .Map(v => v.Id, e => e.Id)
                .Map(v => v.Title, e => e.Title)
                .Compile();
            return config;
        }
        public static TypeAdapterConfig MapCategoryToAddCategoryDto()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<CategoryEntity, UpdateCategoryDto>()
                
                .Map(d => d.Title, e => e.Title)
                .Compile();
            return config;
        }
        public static TypeAdapterConfig MapCategoryToUpdateCategoryDto()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<CategoryEntity, UpdateCategoryDto>()
                .Map(d => d.Id, e => e.Id)
                .Map(d => d.Title, e => e.Title)
                .Compile();
            return config;
        }

       
    }
}
