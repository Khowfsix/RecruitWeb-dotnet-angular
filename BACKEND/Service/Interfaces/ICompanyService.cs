using Service.Models;

namespace Service.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyModel>> GetAllCompany(bool isAdmin, string? request);

        Task<CompanyModel> SaveCompany(CompanyModel request);

        Task<bool> UpdateCompany(CompanyModel request, Guid requestId);

        Task<bool> DeleteCompany(Guid requestId);
    }
}