using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DataTransferObjects.Identity.User;
using Application.ViewModels.Identity.User;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Application.ConfigMapster.UserMap
{
    public static class UserMapster
    {
        public static TypeAdapterConfig MapUserToViewModel()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<IdentityUser, UserViewModel>()
                .Map(v => v.Email, e => e.Email)
                .Map(v => v.UserName, e => e.UserName)
                .Map(v => v.Id, e => e.Id).Compile();
            return config;
        }

        public static TypeAdapterConfig MapUserToAddUserDto()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<AddUserDto, IdentityUser>()
                .Map(e => e.PhoneNumber, d => d.PhoneNumber)
                .Map(e => e.Email, d => d.Email)
                .Map(e => e.UserName, d => d.UserName)
                .Map(e => e.EmailConfirmed, d => d.Active)
                .Map(e => e.PhoneNumberConfirmed, d => d.Active)
                .Compile();
            return config;
        }

        public static TypeAdapterConfig MapUserToUpdateUserDto()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<IdentityUser,UpdateUserDto>()
                .Map(e => e.PhoneNumber, d => d.PhoneNumber)
                .Map(e => e.Email, d => d.Email)
                .Map(e => e.UserName, d => d.UserName)
                .Map(e => e.Active, d => d.EmailConfirmed)
                .Map(e => e.Active, d => d.PhoneNumberConfirmed)
                .TwoWays();
            return config;
        }

    }
}
