using Data.CustomModel.Application;
using Data.CustomModel.Position;
using Data.Entities;
using Data.Interfaces;
using Data.Sorting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Repositories
{
    public class UserRoleRepository : Repository<IdentityUserRole<string>>, IUserRoleRepository
    {
        private readonly IUnitOfWork _uow;

        public UserRoleRepository(RecruitmentWebContext context, IUnitOfWork uow)
            : base(context)
        {
            _uow = uow;
        } 

        public async Task<IEnumerable<IdentityUserRole<string>>> GetAllUserRoles()
        {
            var listData = await Entities.ToListAsync();
            return listData;
        }

        public async Task<IdentityUserRole<string>> SaveUserRole(IdentityUserRole<string> userRole)
        {
            try
            {
                Entities.Add(userRole);
                _uow.SaveChanges();

                return await Task.FromResult(userRole);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteUserRole(IdentityUserRole<string> userRole)
        {
            try
            { 
                if (userRole == null)
                    return await Task.FromResult(false);

                Entities.Remove(userRole);

                _uow.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }
    }
}