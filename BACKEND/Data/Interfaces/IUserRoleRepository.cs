using Data.CustomModel.Application;
using Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Data.Interfaces
{
    public interface IUserRoleRepository
    { 
        Task<IEnumerable<IdentityUserRole<string>>> GetAllUserRoles(); 
        Task<IdentityUserRole<string>> SaveUserRole(IdentityUserRole<string> userRole);
        Task<bool> DeleteUserRole(IdentityUserRole<string> userRole);
    }
}