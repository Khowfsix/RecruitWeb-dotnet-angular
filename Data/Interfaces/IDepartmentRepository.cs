using Data.Models;

namespace Data.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentModel>> GetAllDepartment(string? request);

        Task<DepartmentModel> SaveDepartment(DepartmentModel request);

        Task<bool> UpdateDepartment(DepartmentModel request, Guid requestId);

        Task<bool> DeleteDepartment(Guid requestId);
    }
}