using Data.Entities;

namespace Data.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartment(string? request);

        Task<Department> SaveDepartment(Department request);

        Task<bool> UpdateDepartment(Department request, Guid requestId);

        Task<bool> DeleteDepartment(Guid requestId);
    }
}