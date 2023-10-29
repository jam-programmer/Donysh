using Application.DataTransferObjects.Identity.User;
using Application.ViewModels.Identity.User;
using Application.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Identity.User
{
    public interface IUser
    {
        Task<ListGenerics<UserViewModel>> GetUsers(int page, int pageSize, string search = "");
        Task AddUser(AddUserDto model);
        Task<string> UpdateUser(UpdateUserDto model);
        Task<bool> RemoveUser(string id);
        Task<UpdateUserDto> GetUserById(string id);
    }
}
