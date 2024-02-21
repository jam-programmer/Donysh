using Application.ConfigMapster.UserMap;
using Application.Core;
using Application.DataTransferObjects.Identity.User;
using Application.ViewModels.Identity.User;
using Application.ViewModels.Main;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Identity.User
{
    public class User : IUser
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public User(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task AddUser(AddUserDto model)
        {
            IdentityUser user = model.Adapt<IdentityUser>(UserMapster.MapUserToAddUserDto());

            user.EmailConfirmed = model.Active;
            user.PhoneNumberConfirmed = model.Active;
            var resultAddUser = await _userManager.CreateAsync(user, model.Password!);

            if (resultAddUser.Succeeded)
            {
                var resultAddUserRole = await _userManager.AddToRolesAsync(user, model.Role!);
                if (resultAddUserRole.Succeeded)
                {

                }
            }

        }

        public async Task<UpdateUserDto> GetUserById(string id)
        {
            var model = await _userManager.FindByIdAsync(id);
            UpdateUserDto user = model!.Adapt<UpdateUserDto>(UserMapster.MapUserToUpdateUserDto());
            var roles = await _userManager.GetRolesAsync(model!);
            List<string> userRoles = new List<string>();
            foreach (var roleName in roles)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    userRoles.Add(role.Name!);
                }
            }

            user.Role = userRoles;
            return user;
        }

        public async Task<ListGenerics<UserViewModel>> GetUsers(int page, int pageSize, string search = "")
        {

            ListGenerics<UserViewModel> result = new();
            List<UserViewModel> users = new();
            var model = await _userManager.
                Users.Where(w => w.UserName!.Contains(search)).ToListAsync();
            users = model.Adapt<List<UserViewModel>>(UserMapster.MapUserToViewModel());
            var count = _userManager.Users.Count();
            count = count.PageCount(pageSize);
            result.Count = count;
            result.CurrentPage = page;
            result.List = users;
            result.SearchKeyword = search;
            if (count > 1 && users.Count < 10 && !string.IsNullOrEmpty(search) && page == 1)
            {
                result.Pagination = false;
            }

            return result;
        }

        public async Task<bool> RemoveUser(string id)
        {
            var model = await _userManager.FindByIdAsync(id);
            try
            {
                await _userManager.DeleteAsync(model!);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<string> UpdateUser(UpdateUserDto model)
        {
            string message = "";
            var user = await _userManager.FindByIdAsync(model.Id!);
            model.Adapt(user, UserMapster.MapUserToUpdateUserDto());
           
                user.EmailConfirmed = model.Active;
                user.PhoneNumberConfirmed = model.Active;
            
            var resultUpdateUser = await _userManager.UpdateAsync(user!);
            if (resultUpdateUser.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.Password) && !string.IsNullOrEmpty(model.PasswordConfirmed))
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user!);
                    var restPassword = await _userManager.ResetPasswordAsync(user!, token, model.Password);
                    if (!restPassword.Succeeded)
                    {
                        foreach (var error in restPassword.Errors)
                        {
                            message += error.Description + "\n\r";
                        }
                    }
                }

                var roles = await _userManager.GetRolesAsync(user!);
                var removeRole = await _userManager.RemoveFromRolesAsync(user!, roles);
                if (!removeRole.Succeeded)
                {
                    foreach (var error in removeRole.Errors)
                    {
                        message += error.Description + "\n\r";
                    }
                }
                var addRole = await _userManager.AddToRolesAsync(user!, model.Role!);
                if (!addRole.Succeeded)
                {
                    foreach (var error in addRole.Errors)
                    {
                        message += error.Description + "\n\r";
                    }
                }
            }
            foreach (var error in resultUpdateUser.Errors)
            {
                message += error.Description + "\n\r";
            }

            return message;
        }

    }
}
