using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DataTransferObjects.Identity.Role;
using Application.ViewModels.Identity.Role;
using Application.ViewModels.Main;

namespace Application.Services.Identity.Role
{
    public interface IRole
    {
        Task<ListGenerics<RoleViewModel>> GetRoles(int page, int pageSize, string search = "");
        Task AddRole(AddRoleDto role);
        Task UpdateRole(UpdateRoleDto role);
        Task<bool> RemoveRole(string id);
        Task<UpdateRoleDto> GetRoleById(string id);
        Task<List<ItemViewModel>> GetSelectRoles();
    }
}
