using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Core;
using Application.DataTransferObjects.Identity.Role;
using Application.ViewModels.Identity.Role;
using Application.ViewModels.Main;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Identity.Role
{
    public class Role:IRole
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public Role(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<ListGenerics<RoleViewModel>> GetRoles(int page, int pageSize, string search = "")
        {
            ListGenerics<RoleViewModel> result = new ();
            List<RoleViewModel> roles=new List<RoleViewModel>();
            var model = await _roleManager.Roles.Where(w=>w.Name!.Contains(search)).ToListAsync();
            foreach (var role in model)
            {
                roles.Add(new RoleViewModel()
                {
                    Id = role.Id,
                    Name = role.Name
                });
            }

            var count = _roleManager.Roles.Count();
            count = count.PageCount(pageSize);
            result.Count = count;
            result.CurrentPage = page;
            result.List=roles;
            result.SearchKeyword = search;
            if (count > 1 && roles.Count < 10 && !string.IsNullOrEmpty(search) && page == 1)
            {
                result.Pagination = false;
            }

            return result;
        }

        public async Task AddRole(AddRoleDto role)
        {
            await _roleManager.CreateAsync(new IdentityRole()
            {
                Name = role.RoleName
            });
        }

        public async Task UpdateRole(UpdateRoleDto role)
        {
            var model = await _roleManager.FindByIdAsync(role.Id!);
            model!.Name = role.RoleName;
            await _roleManager.UpdateAsync(model);
        }

        public async Task<bool> RemoveRole(string id)
        {
            var model = await _roleManager.FindByIdAsync(id);
            try
            {
                await _roleManager.DeleteAsync(model!);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<UpdateRoleDto> GetRoleById(string id)
        {
            var model = await _roleManager.Roles.SingleOrDefaultAsync(s => s.Id == id);
            UpdateRoleDto role = new UpdateRoleDto()
            {
                RoleName = model!.Name,
                Id = model.Id
            };
            return role;
        }

        public async Task<List<ItemViewModel>> GetSelectRoles()
        {
           List<ItemViewModel> items = new List<ItemViewModel>();
           var roles = await _roleManager.Roles.ToListAsync();
           foreach (var role in roles)
           {
               items.Add(new ItemViewModel()
               {
                   Id = role.Id,
                   Title = role.Name
               });
           }
           return items;
        }
    }
}
