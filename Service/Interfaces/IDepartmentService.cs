using Api.ViewModels.Department;

namespace Service.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentViewModel>> GetAllDepartment(string? request);

        Task<DepartmentViewModel> SaveDepartment(DepartmentAddModel request);

        Task<bool> UpdateDepartment(DepartmentUpdateModel request, Guid requestId);

        Task<bool> DeleteDepartment(Guid requestId);
    }
}