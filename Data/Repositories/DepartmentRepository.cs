using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly IUnitOfWork _uow;

        public DepartmentRepository(RecruitmentWebContext context, IUnitOfWork uow) : base(context)
        {
            _uow = uow;
        }

        public async Task<bool> DeleteDepartment(Guid requestId)
        {
            try
            {
                var department = GetById(requestId);
                if (department == null)
                    throw new ArgumentNullException(nameof(department));

                //Entities.Remove(department);
                department.IsDeleted = true;
                Entities.Update(department);

                _uow.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Department>> GetAllDepartment(string? request)
        {
            try
            {
                var listData = new List<Department>();
                if (string.IsNullOrEmpty(request))
                {
                    listData = await Entities.ToListAsync();
                }
                else
                {
                    listData = await Entities
                        .Where(rp => rp.DepartmentName.Contains(request))
                        .ToListAsync();
                }

                return listData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Department> SaveDepartment(Department request)
        {
            try
            {
                request.DepartmentId = Guid.NewGuid();

                Entities.Add(request);
                _uow.SaveChanges();

                return await Task.FromResult(request);
            }
            catch (Exception)
            {
                return null!;
            }
        }

        public async Task<bool> UpdateDepartment(Department request, Guid requestId)
        {
            try
            {
                request.DepartmentId = requestId;

                Entities.Update(request);
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