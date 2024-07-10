using Data.CustomModel.Application;
using Microsoft.AspNetCore.Identity;
using Service.Models;

namespace Service.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleModel>> GetAllRoles();
        Task<RoleModel?> GetRoleById(string roleId);
        Task<RoleModel> SaveRole(RoleModel roleModel);
        Task<bool> UpdateRole(RoleModel roleModel, string roleId);
    }
}