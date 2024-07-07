using Data.CustomModel.Application;
using Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Data.Interfaces
{
    public interface IRoleRepository
    { 
        Task<IEnumerable<IdentityRole>> GetAllRoles(); 
        Task<IdentityRole> GetRoleById(string roleId); 
        Task<IdentityRole> SaveRole(IdentityRole role);
        Task<bool> UpdateRole(IdentityRole role, string roleId);
    }
}