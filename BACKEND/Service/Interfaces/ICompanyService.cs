using Service.Models;

namespace Service.Interfaces
{
    public interface ICompanyService
    {
        Task<CompanyModel> GetCompanyById(bool isAdmin, Guid companyId);
        Task<IEnumerable<CompanyModel>> GetAllCompany(bool isAdmin, string? request);

        Task<CompanyModel> SaveCompany(CompanyModel request);

        Task<bool> UpdateCompany(CompanyModel request, Guid requestId);
        Task<bool> UpdateStatus(bool isActived, bool isDeleted, Guid requestId);

        Task<bool> DeleteCompany(Guid requestId);
    }
}