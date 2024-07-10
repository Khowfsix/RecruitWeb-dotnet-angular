using Data.CustomModel.Application;
using Data.CustomModel.Position;
using Data.Entities;
using Data.Interfaces;
using Data.Sorting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RoleRepository : Repository<IdentityRole>, IRoleRepository
    {
        private readonly IUnitOfWork _uow;

        public RoleRepository(RecruitmentWebContext context, IUnitOfWork uow)
            : base(context)
        {
            _uow = uow;
        } 

        public async Task<IEnumerable<IdentityRole>> GetAllRoles()
        {
            var listData = await Entities.ToListAsync();
            return listData;
        }

        public async Task<IdentityRole> SaveRole(IdentityRole role)
        {
            try
            {
                role.Id = Guid.NewGuid().ToString();
                var entity = new IdentityRole(role.Name);
                entity.NormalizedName = role.Name.Normalize();
                Entities.Add(entity);
                _uow.SaveChanges();

                return await Task.FromResult(role);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateRole(IdentityRole role, string roleId)
        {
            try
            {
                var foundRole = await this.GetRoleById(roleId);
                if (foundRole == null)
                {
                    return await Task.FromResult(false);
                }
                foundRole.Name = role.Name;
                foundRole.NormalizedName = role.Name.Normalize();
                Entities.Update(foundRole);
                _uow.SaveChanges();

                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<IdentityRole> GetRoleById(string roleId)
        {
            var data = await Entities.Where(a => a.Id.Equals(roleId))
                                     .FirstOrDefaultAsync();
            if (data != null)
            {
                return data;
            }
            return null;
        }
    }
}