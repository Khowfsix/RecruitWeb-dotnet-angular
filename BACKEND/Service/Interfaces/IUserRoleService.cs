using Data.CustomModel.Application;
using Microsoft.AspNetCore.Identity;
using Service.Models;

namespace Service.Interfaces
{
    public interface IUserRoleService
    {
        Task<IEnumerable<UserRoleModel>> GetAllUserRoles();
        Task<UserRoleModel> SaveUserRole(UserRoleModel userRoleModel);
        Task<bool> DeleteUserRole(UserRoleModel userRoleModel);
    }
}